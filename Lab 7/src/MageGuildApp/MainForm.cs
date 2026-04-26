using MageGuildLibrary.Models;

namespace MageGuildApp;

public partial class MainForm : Form
{
    private readonly MageGuild guild;
    private ListBox resultBox;
    private FlowLayoutPanel buttonPanel;

    public MainForm()
    {
        guild = GuildFactory.BuildDemoGuild();
        InitializeComponent();
        BuildUi();
    }

    private void BuildUi()
    {
        Text = "Mage Guild LINQ Queries";
        Width = 1200;
        Height = 800;
        StartPosition = FormStartPosition.CenterScreen;

        // results list on the right
        resultBox = new ListBox
        {
            Dock = DockStyle.Right,
            Width = 600,
            Font = new Font("Consolas", 9F),
            HorizontalScrollbar = true
        };
        Controls.Add(resultBox);

        // scrollable panel for buttons on the left
        buttonPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            AutoScroll = true,
            WrapContents = false,
            Padding = new Padding(8)
        };
        Controls.Add(buttonPanel);

        // 1) all mages
        AddSimpleQuery("1) Show all mages",
            () => FormatList(guild.GetAllMages()));

        // 2) experienced mages, takes min level
        AddParameterizedQuery("2) Experienced mages above level",
            new[] { ("Min level", "5") },
            args => FormatList(guild.GetExperiencedMages(int.Parse(args[0]))));

        // 3) talented mages, takes max level
        AddParameterizedQuery("3) Talented mages (INT > 20)",
            new[] { ("Max level", "12") },
            args => FormatList(guild.GetTalentedMages(int.Parse(args[0]))));

        // 4) total combat mana
        AddSimpleQuery("4) Combat mages total mana",
            () => new List<string> { $"Total mana potential: {guild.GetCombatMagesManaPotential()}" });

        // 5) biggest spell arsenal
        AddParameterizedQuery("5) Biggest arsenal (min spells)",
            new[] { ("Min spells", "4") },
            args => FormatList(guild.GetMagesWithBiggestArsenal(int.Parse(args[0]))));

        // 6) most versatile
        AddSimpleQuery("6) Most versatile mages",
            () => FormatList(guild.GetMostVersatileMages()));

        // 7) most spells learned
        AddSimpleQuery("7) Mages with most spells",
            () => guild.GetMagesWithMostSpells().ToList());

        // 8) all unique spells
        AddSimpleQuery("8) All unique spells",
            () => FormatList(guild.GetAllUniqueSpells()));

        // 9) unique spells by type
        AddParameterizedQuery("9) Unique spells by type",
            new[] { ("Type (Offensive/Defensive/Healing)", "Offensive") },
            args =>
            {
                var type = Enum.Parse<SpellType>(args[0], true);
                return FormatList(guild.GetUniqueSpellsByType(type));
            });

        // 10) mage spells by type
        AddParameterizedQuery("10) Mage spells by type",
            new[] { ("Mage name", "Gandalf"), ("Type", "Offensive") },
            args =>
            {
                var type = Enum.Parse<SpellType>(args[1], true);
                return FormatList(guild.GetMageSpellsByType(args[0], type));
            });

        // 11) spell counts by type guild wide
        AddSimpleQuery("11) Guild spell counts by type",
            () => FormatList(guild.GetSpellCountsByType()));

        // 12) spell counts by type for a mage
        AddParameterizedQuery("12) Mage spell counts by type",
            new[] { ("Mage name", "Gandalf") },
            args => FormatList(guild.GetMageSpellCountsByType(args[0])));

        // 13) most powerful mages with skip and take
        AddParameterizedQuery("13) Most powerful (skip / take)",
            new[] { ("Skip", "1"), ("Take", "3") },
            args => FormatList(guild.GetMostPowerfulMages(int.Parse(args[0]), int.Parse(args[1]))));

        // 14) all ready
        AddSimpleQuery("14) All ready for tournament?",
            () => new List<string> { guild.AreAllReadyForTournament() ? "Yes" : "No" });

        // 15) anyone fainted
        AddSimpleQuery("15) Did anyone faint?",
            () => new List<string> { guild.DidAnyoneFaint() ? "Yes" : "No" });

        // 16) best for special mission
        AddParameterizedQuery("16) Best for special mission",
            new[] { ("Min level", "5") },
            args => FormatList(guild.GetBestForSpecialMission(int.Parse(args[0]))));
    }

    // adds a button that runs a query without parameters
    private void AddSimpleQuery(string label, Func<IEnumerable<string>> action)
    {
        var group = new GroupBox
        {
            Text = label,
            Width = 540,
            Height = 60
        };
        var btn = new Button
        {
            Text = "Run",
            Left = 10,
            Top = 22,
            Width = 80
        };
        btn.Click += (_, _) => ShowResults(action());
        group.Controls.Add(btn);
        buttonPanel.Controls.Add(group);
    }

    // adds a button with a configurable number of textboxes
    private void AddParameterizedQuery(string label,
                                       (string label, string defaultValue)[] inputs,
                                       Func<string[], IEnumerable<string>> action)
    {
        var group = new GroupBox
        {
            Text = label,
            Width = 540,
            Height = 90
        };

        var textBoxes = new List<TextBox>();
        int x = 10;
        foreach (var (lbl, def) in inputs)
        {
            var lblCtrl = new Label
            {
                Text = lbl,
                Left = x,
                Top = 22,
                AutoSize = true
            };
            group.Controls.Add(lblCtrl);
            var tb = new TextBox
            {
                Left = x,
                Top = 42,
                Width = 140,
                Text = def
            };
            group.Controls.Add(tb);
            textBoxes.Add(tb);
            x += 150;
        }

        var btn = new Button
        {
            Text = "Run",
            Left = x + 5,
            Top = 40,
            Width = 80
        };
        btn.Click += (_, _) =>
        {
            try
            {
                var values = textBoxes.Select(t => t.Text).ToArray();
                ShowResults(action(values));
            }
            catch (Exception ex)
            {
                ShowResults(new List<string> { "Error: " + ex.Message });
            }
        };
        group.Controls.Add(btn);
        buttonPanel.Controls.Add(group);
    }

    // clears the list and pushes lines, with a blank line between items for readability
    private void ShowResults(IEnumerable<string> lines)
    {
        resultBox.Items.Clear();
        var list = lines.ToList();
        if (list.Count == 0)
        {
            resultBox.Items.Add("(no results)");
            return;
        }
        for (int i = 0; i < list.Count; i++)
        {
            resultBox.Items.Add(list[i]);
            if (i < list.Count - 1)
            {
                resultBox.Items.Add(string.Empty);
            }
        }
    }

    // helper to convert any enumerable into a list of strings
    private static List<string> FormatList<T>(IEnumerable<T> source)
    {
        return source.Select(x => x.ToString()).ToList();
    }
}
