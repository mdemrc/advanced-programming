using System.ComponentModel;
using System.Reflection;
using System.Xml.Serialization;
using ContactsLibrary;

namespace ContactManagerApp;

public partial class Form1 : Form
{
    private List<Contact> _contacts = new List<Contact>();
    private BindingSource _contactBindingSource = new BindingSource();
    private List<string> _loadedPluginsInfo = new List<string>();

    public Form1()
    {
        InitializeComponent();
        
        // initialize binding source
        _contactBindingSource.DataSource = _contacts;
        _dataGridView.DataSource = _contactBindingSource;
        
        // configure datagridview
        _dataGridView.AutoGenerateColumns = true;
        _dataGridView.AllowUserToAddRows = true;
        _dataGridView.AllowUserToDeleteRows = true;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        LoadPlugins();
    }

    private void LoadPlugins()
    {
        string exePath = Assembly.GetExecutingAssembly().Location;
        string exeDir = Path.GetDirectoryName(exePath);
        string pluginsDir = Path.Combine(exeDir, "Plugins");

        if (!Directory.Exists(pluginsDir))
        {
            return;
        }

        string[] dlls = Directory.GetFiles(pluginsDir, "*.dll");
        foreach (string dll in dlls)
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(dll);
                var pluginTypes = assembly.GetTypes()
                    .Where(t => typeof(IPluginable).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                foreach (var type in pluginTypes)
                {
                    IPluginable plugin = (IPluginable)Activator.CreateInstance(type);
                    if (plugin == null) continue;

                    // get custom InfoAttribute
                    var infoAttr = type.GetCustomAttribute<InfoAttribute>();
                    string author = infoAttr != null ? infoAttr.Author : "Unknown";
                    _loadedPluginsInfo.Add($"{plugin.Format} Plugin by {author}");

                    // dynamically add save/load options
                    AddPluginMenuOptions(plugin);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load plugin from {Path.GetFileName(dll)}: {ex.Message}", "Plugin Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void AddPluginMenuOptions(IPluginable plugin)
    {
        // Add save option
        ToolStripMenuItem pluginSaveItem = new ToolStripMenuItem(plugin.Format);
        pluginSaveItem.Click += (s, e) => SaveWithPlugin(plugin);
        _saveToMenuItem.DropDownItems.Add(pluginSaveItem);

        // Add load option
        ToolStripMenuItem pluginLoadItem = new ToolStripMenuItem(plugin.Format);
        pluginLoadItem.Click += (s, e) => LoadWithPlugin(plugin);
        _loadFromMenuItem.DropDownItems.Add(pluginLoadItem);
    }

    private void SaveWithPlugin(IPluginable plugin)
    {
        using SaveFileDialog sfd = new SaveFileDialog();
        sfd.Filter = $"{plugin.Format} files (*.{plugin.Format.ToLower()})|*.{plugin.Format.ToLower()}|All files (*.*)|*.*";
        
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                // Force ending edit on DataGridView to commit any pending changes
                _dataGridView.EndEdit();
                plugin.Save(_contacts, sfd.FileName);
                MessageBox.Show($"Successfully saved contacts using {plugin.Format} plugin.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving contacts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void LoadWithPlugin(IPluginable plugin)
    {
        using OpenFileDialog ofd = new OpenFileDialog();
        ofd.Filter = $"{plugin.Format} files (*.{plugin.Format.ToLower()})|*.{plugin.Format.ToLower()}|All files (*.*)|*.*";

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                List<Contact> loaded = plugin.Load(ofd.FileName);
                _contacts.Clear();
                if (loaded != null)
                {
                    _contacts.AddRange(loaded);
                }
                _contactBindingSource.ResetBindings(false);
                MessageBox.Show($"Successfully loaded contacts using {plugin.Format} plugin.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading contacts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void saveXmlMenuItem_Click(object sender, EventArgs e)
    {
        using SaveFileDialog sfd = new SaveFileDialog();
        sfd.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                _dataGridView.EndEdit();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
                using StreamWriter writer = new StreamWriter(sfd.FileName);
                serializer.Serialize(writer, _contacts);
                MessageBox.Show("Successfully saved contacts using XML.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving XML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void loadXmlMenuItem_Click(object sender, EventArgs e)
    {
        using OpenFileDialog ofd = new OpenFileDialog();
        ofd.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
                using StreamReader reader = new StreamReader(ofd.FileName);
                List<Contact> loaded = (List<Contact>)serializer.Deserialize(reader);
                _contacts.Clear();
                if (loaded != null)
                {
                    _contacts.AddRange(loaded);
                }
                _contactBindingSource.ResetBindings(false);
                MessageBox.Show("Successfully loaded contacts from XML.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading XML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void exitMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void aboutMenuItem_Click(object sender, EventArgs e)
    {
        string pluginList = _loadedPluginsInfo.Count > 0 
            ? string.Join("\n- ", _loadedPluginsInfo) 
            : "None";
            
        MessageBox.Show(
            $"Contact Manager App v1.0\n\nActive Plugins:\n- {pluginList}",
            "About",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );
    }
}
