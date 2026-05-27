namespace ContactManagerApp;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.MenuStrip _menuStrip;
    private System.Windows.Forms.ToolStripMenuItem _fileMenuItem;
    private System.Windows.Forms.ToolStripMenuItem _saveToMenuItem;
    private System.Windows.Forms.ToolStripMenuItem _saveXmlMenuItem;
    private System.Windows.Forms.ToolStripMenuItem _loadFromMenuItem;
    private System.Windows.Forms.ToolStripMenuItem _loadXmlMenuItem;
    private System.Windows.Forms.ToolStripMenuItem _exitMenuItem;
    private System.Windows.Forms.ToolStripMenuItem _helpMenuItem;
    private System.Windows.Forms.ToolStripMenuItem _aboutMenuItem;
    private System.Windows.Forms.DataGridView _dataGridView;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        _menuStrip = new System.Windows.Forms.MenuStrip();
        _fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        _saveToMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        _saveXmlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        _loadFromMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        _loadXmlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        _exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        _helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        _aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        _dataGridView = new System.Windows.Forms.DataGridView();
        
        _menuStrip.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_dataGridView).BeginInit();
        SuspendLayout();

        // 
        // _menuStrip
        // 
        _menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _fileMenuItem,
            _helpMenuItem
        });
        _menuStrip.Location = new System.Drawing.Point(0, 0);
        _menuStrip.Name = "_menuStrip";
        _menuStrip.Size = new System.Drawing.Size(800, 24);
        _menuStrip.TabIndex = 0;
        _menuStrip.Text = "menuStrip1";

        // 
        // _fileMenuItem
        // 
        _fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _saveToMenuItem,
            _loadFromMenuItem,
            _exitMenuItem
        });
        _fileMenuItem.Name = "_fileMenuItem";
        _fileMenuItem.Size = new System.Drawing.Size(37, 20);
        _fileMenuItem.Text = "&File";

        // 
        // _saveToMenuItem
        // 
        _saveToMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _saveXmlMenuItem
        });
        _saveToMenuItem.Name = "_saveToMenuItem";
        _saveToMenuItem.Size = new System.Drawing.Size(180, 22);
        _saveToMenuItem.Text = "&Save to";

        // 
        // _saveXmlMenuItem
        // 
        _saveXmlMenuItem.Name = "_saveXmlMenuItem";
        _saveXmlMenuItem.Size = new System.Drawing.Size(98, 22);
        _saveXmlMenuItem.Text = "XML";
        _saveXmlMenuItem.Click += new System.EventHandler(saveXmlMenuItem_Click);

        // 
        // _loadFromMenuItem
        // 
        _loadFromMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _loadXmlMenuItem
        });
        _loadFromMenuItem.Name = "_loadFromMenuItem";
        _loadFromMenuItem.Size = new System.Drawing.Size(180, 22);
        _loadFromMenuItem.Text = "&Load from";

        // 
        // _loadXmlMenuItem
        // 
        _loadXmlMenuItem.Name = "_loadXmlMenuItem";
        _loadXmlMenuItem.Size = new System.Drawing.Size(98, 22);
        _loadXmlMenuItem.Text = "XML";
        _loadXmlMenuItem.Click += new System.EventHandler(loadXmlMenuItem_Click);

        // 
        // _exitMenuItem
        // 
        _exitMenuItem.Name = "_exitMenuItem";
        _exitMenuItem.Size = new System.Drawing.Size(180, 22);
        _exitMenuItem.Text = "E&xit";
        _exitMenuItem.Click += new System.EventHandler(exitMenuItem_Click);

        // 
        // _helpMenuItem
        // 
        _helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _aboutMenuItem
        });
        _helpMenuItem.Name = "_helpMenuItem";
        _helpMenuItem.Size = new System.Drawing.Size(44, 20);
        _helpMenuItem.Text = "&Help";

        // 
        // _aboutMenuItem
        // 
        _aboutMenuItem.Name = "_aboutMenuItem";
        _aboutMenuItem.Size = new System.Drawing.Size(107, 22);
        _aboutMenuItem.Text = "&About";
        _aboutMenuItem.Click += new System.EventHandler(aboutMenuItem_Click);

        // 
        // _dataGridView
        // 
        _dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        _dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
        _dataGridView.Location = new System.Drawing.Point(0, 24);
        _dataGridView.Name = "_dataGridView";
        _dataGridView.RowTemplate.Height = 25;
        _dataGridView.Size = new System.Drawing.Size(800, 426);
        _dataGridView.TabIndex = 1;

        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(_dataGridView);
        Controls.Add(_menuStrip);
        MainMenuStrip = _menuStrip;
        Name = "Form1";
        Text = "Contact Manager";
        Load += new System.EventHandler(Form1_Load);
        _menuStrip.ResumeLayout(false);
        _menuStrip.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_dataGridView).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
