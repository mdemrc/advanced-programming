namespace PotionBrewApp;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    
    // Main components
    private System.Windows.Forms.MenuStrip _menuStrip;
    private System.Windows.Forms.ToolStripMenuItem _fileMenuItem;
    private System.Windows.Forms.ToolStripMenuItem _saveJsonMenuItem;
    private System.Windows.Forms.ToolStripMenuItem _loadJsonMenuItem;
    private System.Windows.Forms.ToolStripMenuItem _exitMenuItem;
    private System.Windows.Forms.ToolStripMenuItem _helpMenuItem;
    private System.Windows.Forms.ToolStripMenuItem _aboutMenuItem;
    private System.Windows.Forms.StatusStrip _statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel _statusLabel;
    private System.Windows.Forms.TabControl _tabControl;

    // Tab 1: Ingredients
    private System.Windows.Forms.TabPage _tabIngredients;
    private System.Windows.Forms.ListBox _ingredientsListBox;
    private System.Windows.Forms.Panel _ingredientsPanel;
    private System.Windows.Forms.TextBox _ingNameTextBox;
    private System.Windows.Forms.ComboBox _ingRarityComboBox;
    private System.Windows.Forms.NumericUpDown _ingPriceNumeric;
    private System.Windows.Forms.TextBox _ingDescTextBox;
    private System.Windows.Forms.ComboBox _ingTypeComboBox;
    private System.Windows.Forms.TextBox _ingSpecParamTextBox;
    private System.Windows.Forms.Label _ingSpecParamLabel;
    private System.Windows.Forms.Button _addIngredientButton;

    // Tab 2: Potions
    private System.Windows.Forms.TabPage _tabPotions;
    private System.Windows.Forms.ListBox _potionsListBox;
    private System.Windows.Forms.Panel _potionsPanel;
    private System.Windows.Forms.TextBox _potionNameTextBox;
    private System.Windows.Forms.ComboBox _potionEffectComboBox;
    private System.Windows.Forms.ComboBox _potionRarityComboBox;
    private System.Windows.Forms.NumericUpDown _potionPriceNumeric;
    private System.Windows.Forms.NumericUpDown _potionTimeNumeric;
    private System.Windows.Forms.CheckedListBox _potionIngredientsCheckedListBox;
    private System.Windows.Forms.Button _addPotionButton;

    // Tab 3: Brewers
    private System.Windows.Forms.TabPage _tabBrewers;
    private System.Windows.Forms.ListBox _brewersListBox;
    private System.Windows.Forms.Panel _brewersPanel;
    private System.Windows.Forms.TextBox _brewerNameTextBox;
    private System.Windows.Forms.NumericUpDown _brewerSkillNumeric;
    private System.Windows.Forms.ComboBox _brewerSpecComboBox;
    private System.Windows.Forms.Button _addBrewerButton;

    // Tab 4: Orders
    private System.Windows.Forms.TabPage _tabOrders;
    private System.Windows.Forms.DataGridView _ordersDataGridView;
    private System.Windows.Forms.Panel _ordersPanel;
    private System.Windows.Forms.ComboBox _orderPotionComboBox;
    private System.Windows.Forms.ComboBox _orderBrewerComboBox;
    private System.Windows.Forms.TextBox _orderCustomerTextBox;
    private System.Windows.Forms.Button _placeOrderButton;
    private System.Windows.Forms.Button _completeOrderButton;

    // Tab 5: Queries
    private System.Windows.Forms.TabPage _tabQueries;
    private System.Windows.Forms.TextBox _queriesOutputTextBox;

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
        _saveJsonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        _loadJsonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        _exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        _helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        _aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        
        _statusStrip = new System.Windows.Forms.StatusStrip();
        _statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        _tabControl = new System.Windows.Forms.TabControl();

        // Ingredients
        _tabIngredients = new System.Windows.Forms.TabPage();
        _ingredientsListBox = new System.Windows.Forms.ListBox();
        _ingredientsPanel = new System.Windows.Forms.Panel();
        _ingNameTextBox = new System.Windows.Forms.TextBox();
        _ingRarityComboBox = new System.Windows.Forms.ComboBox();
        _ingPriceNumeric = new System.Windows.Forms.NumericUpDown();
        _ingDescTextBox = new System.Windows.Forms.TextBox();
        _ingTypeComboBox = new System.Windows.Forms.ComboBox();
        _ingSpecParamTextBox = new System.Windows.Forms.TextBox();
        _ingSpecParamLabel = new System.Windows.Forms.Label();
        _addIngredientButton = new System.Windows.Forms.Button();

        // Potions
        _tabPotions = new System.Windows.Forms.TabPage();
        _potionsListBox = new System.Windows.Forms.ListBox();
        _potionsPanel = new System.Windows.Forms.Panel();
        _potionNameTextBox = new System.Windows.Forms.TextBox();
        _potionEffectComboBox = new System.Windows.Forms.ComboBox();
        _potionRarityComboBox = new System.Windows.Forms.ComboBox();
        _potionPriceNumeric = new System.Windows.Forms.NumericUpDown();
        _potionTimeNumeric = new System.Windows.Forms.NumericUpDown();
        _potionIngredientsCheckedListBox = new System.Windows.Forms.CheckedListBox();
        _addPotionButton = new System.Windows.Forms.Button();

        // Brewers
        _tabBrewers = new System.Windows.Forms.TabPage();
        _brewersListBox = new System.Windows.Forms.ListBox();
        _brewersPanel = new System.Windows.Forms.Panel();
        _brewerNameTextBox = new System.Windows.Forms.TextBox();
        _brewerSkillNumeric = new System.Windows.Forms.NumericUpDown();
        _brewerSpecComboBox = new System.Windows.Forms.ComboBox();
        _addBrewerButton = new System.Windows.Forms.Button();

        // Orders
        _tabOrders = new System.Windows.Forms.TabPage();
        _ordersDataGridView = new System.Windows.Forms.DataGridView();
        _ordersPanel = new System.Windows.Forms.Panel();
        _orderPotionComboBox = new System.Windows.Forms.ComboBox();
        _orderBrewerComboBox = new System.Windows.Forms.ComboBox();
        _orderCustomerTextBox = new System.Windows.Forms.TextBox();
        _placeOrderButton = new System.Windows.Forms.Button();
        _completeOrderButton = new System.Windows.Forms.Button();

        // Queries
        _tabQueries = new System.Windows.Forms.TabPage();
        _queriesOutputTextBox = new System.Windows.Forms.TextBox();

        _menuStrip.SuspendLayout();
        _statusStrip.SuspendLayout();
        _tabControl.SuspendLayout();
        
        _tabIngredients.SuspendLayout();
        _ingredientsPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_ingPriceNumeric).BeginInit();

        _tabPotions.SuspendLayout();
        _potionsPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_potionPriceNumeric).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_potionTimeNumeric).BeginInit();

        _tabBrewers.SuspendLayout();
        _brewersPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_brewerSkillNumeric).BeginInit();

        _tabOrders.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_ordersDataGridView).BeginInit();
        _ordersPanel.SuspendLayout();
        
        _tabQueries.SuspendLayout();
        SuspendLayout();

        // MenuStrip
        _menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { _fileMenuItem, _helpMenuItem });
        _menuStrip.Location = new System.Drawing.Point(0, 0);
        _menuStrip.Size = new System.Drawing.Size(850, 24);
        _menuStrip.TabIndex = 0;

        _fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { _saveJsonMenuItem, _loadJsonMenuItem, _exitMenuItem });
        _fileMenuItem.Text = "&File";
        
        _saveJsonMenuItem.Text = "&Save (JSON)";
        _saveJsonMenuItem.Click += new System.EventHandler(saveJsonMenuItem_Click);

        _loadJsonMenuItem.Text = "&Load (JSON)";
        _loadJsonMenuItem.Click += new System.EventHandler(loadJsonMenuItem_Click);

        _exitMenuItem.Text = "E&xit";
        _exitMenuItem.Click += new System.EventHandler(exitMenuItem_Click);

        _helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { _aboutMenuItem });
        _helpMenuItem.Text = "&Help";

        _aboutMenuItem.Text = "&About";
        _aboutMenuItem.Click += new System.EventHandler(aboutMenuItem_Click);

        // StatusStrip
        _statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { _statusLabel });
        _statusStrip.Location = new System.Drawing.Point(0, 528);
        _statusStrip.Size = new System.Drawing.Size(850, 22);

        _statusLabel.Text = "Welcome to Potion Brewery Manager";

        // TabControl
        _tabControl.Controls.Add(_tabIngredients);
        _tabControl.Controls.Add(_tabPotions);
        _tabControl.Controls.Add(_tabBrewers);
        _tabControl.Controls.Add(_tabOrders);
        _tabControl.Controls.Add(_tabQueries);
        _tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
        _tabControl.Location = new System.Drawing.Point(0, 24);
        _tabControl.Size = new System.Drawing.Size(850, 504);

        // 1. Ingredients Tab
        _tabIngredients.Controls.Add(_ingredientsListBox);
        _tabIngredients.Controls.Add(_ingredientsPanel);
        _tabIngredients.Text = "Ingredients";

        _ingredientsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
        _ingredientsListBox.Location = new System.Drawing.Point(0, 0);
        _ingredientsListBox.Size = new System.Drawing.Size(550, 478);

        _ingredientsPanel.Dock = System.Windows.Forms.DockStyle.Right;
        _ingredientsPanel.Width = 300;
        _ingredientsPanel.Location = new System.Drawing.Point(550, 0);
        
        // Ingredients Controls setup
        var lblIngName = new Label { Text = "Name:", Location = new Point(10, 15), Width = 80 };
        _ingNameTextBox.Location = new Point(100, 12);
        _ingNameTextBox.Width = 180;

        var lblIngType = new Label { Text = "Type:", Location = new Point(10, 45), Width = 80 };
        _ingTypeComboBox.Location = new Point(100, 42);
        _ingTypeComboBox.Width = 180;
        _ingTypeComboBox.SelectedIndexChanged += new EventHandler(_ingTypeComboBox_SelectedIndexChanged);

        var lblIngRarity = new Label { Text = "Rarity:", Location = new Point(10, 75), Width = 80 };
        _ingRarityComboBox.Location = new Point(100, 72);
        _ingRarityComboBox.Width = 180;

        var lblIngPrice = new Label { Text = "Base Price:", Location = new Point(10, 105), Width = 80 };
        _ingPriceNumeric.Location = new Point(100, 102);
        _ingPriceNumeric.Width = 180;
        _ingPriceNumeric.Maximum = 10000;

        var lblIngDesc = new Label { Text = "Description:", Location = new Point(10, 135), Width = 80 };
        _ingDescTextBox.Location = new Point(100, 132);
        _ingDescTextBox.Width = 180;

        _ingSpecParamLabel.Text = "Region:";
        _ingSpecParamLabel.Location = new Point(10, 165);
        _ingSpecParamLabel.Width = 85;
        
        _ingSpecParamTextBox.Location = new Point(100, 162);
        _ingSpecParamTextBox.Width = 180;

        _addIngredientButton.Text = "Add Ingredient";
        _addIngredientButton.Location = new Point(100, 200);
        _addIngredientButton.Width = 180;
        _addIngredientButton.Click += new EventHandler(_addIngredientButton_Click);

        _ingredientsPanel.Controls.AddRange(new Control[] {
            lblIngName, _ingNameTextBox,
            lblIngType, _ingTypeComboBox,
            lblIngRarity, _ingRarityComboBox,
            lblIngPrice, _ingPriceNumeric,
            lblIngDesc, _ingDescTextBox,
            _ingSpecParamLabel, _ingSpecParamTextBox,
            _addIngredientButton
        });

        // 2. Potions Tab
        _tabPotions.Controls.Add(_potionsListBox);
        _tabPotions.Controls.Add(_potionsPanel);
        _tabPotions.Text = "Potions";

        _potionsListBox.Dock = System.Windows.Forms.DockStyle.Fill;

        _potionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
        _potionsPanel.Width = 300;

        var lblPotName = new Label { Text = "Name:", Location = new Point(10, 15), Width = 80 };
        _potionNameTextBox.Location = new Point(100, 12);
        _potionNameTextBox.Width = 180;

        var lblPotEffect = new Label { Text = "Effect:", Location = new Point(10, 45), Width = 80 };
        _potionEffectComboBox.Location = new Point(100, 42);
        _potionEffectComboBox.Width = 180;

        var lblPotRarity = new Label { Text = "Rarity:", Location = new Point(10, 75), Width = 80 };
        _potionRarityComboBox.Location = new Point(100, 72);
        _potionRarityComboBox.Width = 180;

        var lblPotPrice = new Label { Text = "Price (g):", Location = new Point(10, 105), Width = 80 };
        _potionPriceNumeric.Location = new Point(100, 102);
        _potionPriceNumeric.Width = 180;
        _potionPriceNumeric.Maximum = 100000;

        var lblPotTime = new Label { Text = "Time (min):", Location = new Point(10, 135), Width = 80 };
        _potionTimeNumeric.Location = new Point(100, 132);
        _potionTimeNumeric.Width = 180;
        _potionTimeNumeric.Maximum = 1440;

        var lblPotIngs = new Label { Text = "Ingredients:", Location = new Point(10, 165), Width = 80 };
        _potionIngredientsCheckedListBox.Location = new Point(10, 185);
        _potionIngredientsCheckedListBox.Size = new Size(270, 160);

        _addPotionButton.Text = "Add Recipe";
        _addPotionButton.Location = new Point(100, 360);
        _addPotionButton.Width = 180;
        _addPotionButton.Click += new EventHandler(_addPotionButton_Click);

        _potionsPanel.Controls.AddRange(new Control[] {
            lblPotName, _potionNameTextBox,
            lblPotEffect, _potionEffectComboBox,
            lblPotRarity, _potionRarityComboBox,
            lblPotPrice, _potionPriceNumeric,
            lblPotTime, _potionTimeNumeric,
            lblPotIngs, _potionIngredientsCheckedListBox,
            _addPotionButton
        });

        // 3. Brewers Tab
        _tabBrewers.Controls.Add(_brewersListBox);
        _tabBrewers.Controls.Add(_brewersPanel);
        _tabBrewers.Text = "Brewers";

        _brewersListBox.Dock = System.Windows.Forms.DockStyle.Fill;

        _brewersPanel.Dock = System.Windows.Forms.DockStyle.Right;
        _brewersPanel.Width = 300;

        var lblBrewName = new Label { Text = "Name:", Location = new Point(10, 15), Width = 80 };
        _brewerNameTextBox.Location = new Point(100, 12);
        _brewerNameTextBox.Width = 180;

        var lblBrewSkill = new Label { Text = "Skill (1-10):", Location = new Point(10, 45), Width = 80 };
        _brewerSkillNumeric.Location = new Point(100, 42);
        _brewerSkillNumeric.Width = 180;
        _brewerSkillNumeric.Minimum = 1;
        _brewerSkillNumeric.Maximum = 10;
        _brewerSkillNumeric.Value = 1;

        var lblBrewSpec = new Label { Text = "Specialty:", Location = new Point(10, 75), Width = 80 };
        _brewerSpecComboBox.Location = new Point(100, 72);
        _brewerSpecComboBox.Width = 180;

        _addBrewerButton.Text = "Hire Brewer";
        _addBrewerButton.Location = new Point(100, 110);
        _addBrewerButton.Width = 180;
        _addBrewerButton.Click += new EventHandler(_addBrewerButton_Click);

        _brewersPanel.Controls.AddRange(new Control[] {
            lblBrewName, _brewerNameTextBox,
            lblBrewSkill, _brewerSkillNumeric,
            lblBrewSpec, _brewerSpecComboBox,
            _addBrewerButton
        });

        // 4. Orders Tab
        _tabOrders.Controls.Add(_ordersDataGridView);
        _tabOrders.Controls.Add(_ordersPanel);
        _tabOrders.Text = "Orders";

        _ordersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
        _ordersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

        _ordersPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        _ordersPanel.Height = 80;

        var lblOrdPot = new Label { Text = "Potion:", Location = new Point(10, 15), Width = 50 };
        _orderPotionComboBox.Location = new Point(60, 12);
        _orderPotionComboBox.Width = 130;

        var lblOrdBrew = new Label { Text = "Brewer:", Location = new Point(200, 15), Width = 50 };
        _orderBrewerComboBox.Location = new Point(250, 12);
        _orderBrewerComboBox.Width = 130;

        var lblOrdCust = new Label { Text = "Customer:", Location = new Point(390, 15), Width = 60 };
        _orderCustomerTextBox.Location = new Point(450, 12);
        _orderCustomerTextBox.Width = 120;

        _placeOrderButton.Text = "Place Order";
        _placeOrderButton.Location = new Point(585, 10);
        _placeOrderButton.Width = 110;
        _placeOrderButton.Click += new EventHandler(_placeOrderButton_Click);

        _completeOrderButton.Text = "Complete Selected";
        _completeOrderButton.Location = new Point(700, 10);
        _completeOrderButton.Width = 130;
        _completeOrderButton.Click += new EventHandler(_completeOrderButton_Click);

        _ordersPanel.Controls.AddRange(new Control[] {
            lblOrdPot, _orderPotionComboBox,
            lblOrdBrew, _orderBrewerComboBox,
            lblOrdCust, _orderCustomerTextBox,
            _placeOrderButton, _completeOrderButton
        });

        // 5. Queries Tab
        _tabQueries.Controls.Add(_queriesOutputTextBox);
        _tabQueries.Text = "Queries & Stats";

        _queriesOutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
        _queriesOutputTextBox.Multiline = true;
        _queriesOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        _queriesOutputTextBox.Font = new Font("Consolas", 10F, FontStyle.Regular);
        _queriesOutputTextBox.ReadOnly = true;

        // Form setup
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(850, 550);
        Controls.Add(_tabControl);
        Controls.Add(_statusStrip);
        Controls.Add(_menuStrip);
        MainMenuStrip = _menuStrip;
        Name = "MainForm";
        Text = "Alchemist's Haven - Potion Brewery Manager";

        _menuStrip.ResumeLayout(false);
        _menuStrip.PerformLayout();
        _statusStrip.ResumeLayout(false);
        _statusStrip.PerformLayout();
        _tabControl.ResumeLayout(false);

        _tabIngredients.ResumeLayout(false);
        _ingredientsPanel.ResumeLayout(false);
        _ingredientsPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_ingPriceNumeric).EndInit();

        _tabPotions.ResumeLayout(false);
        _potionsPanel.ResumeLayout(false);
        _potionsPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_potionPriceNumeric).EndInit();
        ((System.ComponentModel.ISupportInitialize)_potionTimeNumeric).EndInit();

        _tabBrewers.ResumeLayout(false);
        _brewersPanel.ResumeLayout(false);
        _brewersPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_brewerSkillNumeric).EndInit();

        _tabOrders.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_ordersDataGridView).EndInit();
        _ordersPanel.ResumeLayout(false);
        _ordersPanel.PerformLayout();

        _tabQueries.ResumeLayout(false);
        _tabQueries.PerformLayout();
        
        ResumeLayout(false);
        PerformLayout();
    }
}
