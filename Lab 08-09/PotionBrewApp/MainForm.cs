using System.Text.Json;
using PotionBrewLib.Models;
using PotionBrewLib.Services;
using PotionBrewLib.Queries;
using PotionBrewLib.Exceptions;

namespace PotionBrewApp;

public partial class MainForm : Form
{
    private readonly Brewery _brewery = new Brewery("Alchemist's Haven");
    private readonly BindingSource _ordersBindingSource = new BindingSource();

    public MainForm()
    {
        InitializeComponent();
        
        // Wire up events
        _brewery.OnBrewerHired += (b) => UpdateStatus($"Hired brewer: {b.Name}");
        _brewery.OnPotionAdded += (p) => UpdateStatus($"Added potion recipe: {p.Name}");
        _brewery.OnOrderPlaced += (o) => UpdateStatus($"Placed order #{o.Id} for {o.CustomerName}");
        _brewery.OnOrderCompleted += (o) => UpdateStatus($"Completed order #{o.Id}! {o.Brewer.Name} earned {o.Potion.Price}g");

        InitializeSampleData();
        
        // Setup Bindings
        _ordersBindingSource.DataSource = _brewery.GetAllOrders();
        _ordersDataGridView.DataSource = _ordersBindingSource;
        
        RefreshAllUI();
    }

    private void UpdateStatus(string message)
    {
        _statusLabel.Text = $"[{DateTime.Now.ToLongTimeString()}] {message}";
    }

    private void InitializeSampleData()
    {
        // 1. Ingredients
        var leaf = new HerbIngredient("Dragonscale Leaf", Rarity.Rare, 15m, "A glowing red leaf", "Volcanic Ridge");
        var kingsfoil = new HerbIngredient("Kingsfoil", Rarity.Common, 2m, "Simple healing herb", "Forest Fields");
        var ore = new MineralIngredient("Darksteel Ore", Rarity.Rare, 25m, "Heavy dark metal", "Deep Mines");
        var crystal = new MineralIngredient("Aether Crystal", Rarity.Legendary, 100m, "Pulsing magic crystal", "Mana Rift");
        var feather = new CreatureIngredient("Phoenix Feather", Rarity.Legendary, 150m, "Warm to the touch", "Fire Phoenix");
        var slime = new CreatureIngredient("Slime Jelly", Rarity.Common, 1m, "Sticky green goo", "Green Slime");

        _brewery.AddIngredient(leaf);
        _brewery.AddIngredient(kingsfoil);
        _brewery.AddIngredient(ore);
        _brewery.AddIngredient(crystal);
        _brewery.AddIngredient(feather);
        _brewery.AddIngredient(slime);

        // 2. Brewers
        var merlin = new Brewer("Merlin", 9, PotionEffect.Healing);
        var grom = new Brewer("Grom", 4, PotionEffect.Strength);
        var elena = new Brewer("Elena", 6, PotionEffect.Speed);

        _brewery.AddBrewer(merlin);
        _brewery.AddBrewer(grom);
        _brewery.AddBrewer(elena);

        // 3. Potions
        var healing = new Potion("Lesser Healing Potion", PotionEffect.Healing, Rarity.Common, new List<Ingredient> { kingsfoil, slime }, 5, 10m);
        var strength = new Potion("Elixir of Strength", PotionEffect.Strength, Rarity.Rare, new List<Ingredient> { leaf, ore }, 15, 60m);
        var speed = new Potion("Mana Potion", PotionEffect.Speed, Rarity.Uncommon, new List<Ingredient> { kingsfoil, crystal }, 10, 40m);
        var invis = new Potion("Invisibility Draught", PotionEffect.Invisibility, Rarity.Legendary, new List<Ingredient> { feather, crystal }, 30, 200m);

        _brewery.AddPotion(healing);
        _brewery.AddPotion(strength);
        _brewery.AddPotion(speed);
        _brewery.AddPotion(invis);

        // 4. Sample Orders
        _brewery.PlaceOrder("Lesser Healing Potion", "Merlin", "Geralt");
        _brewery.PlaceOrder("Elixir of Strength", "Elena", "Arthur"); // Elena is Lvl 6, Strength is Rare (Lvl 5)
    }

    private void RefreshAllUI()
    {
        RefreshIngredientsList();
        RefreshPotionsList();
        RefreshBrewersList();
        RefreshOrdersGrid();
        RefreshComboBoxes();
        RefreshQueriesTab();
    }

    private void RefreshIngredientsList()
    {
        _ingredientsListBox.Items.Clear();
        _potionIngredientsCheckedListBox.Items.Clear();
        foreach (var ingredient in _brewery.GetAllIngredients())
        {
            _ingredientsListBox.Items.Add(ingredient);
            _potionIngredientsCheckedListBox.Items.Add(ingredient);
        }
    }

    private void RefreshPotionsList()
    {
        _potionsListBox.Items.Clear();
        foreach (var potion in _brewery.GetAllPotions())
        {
            _potionsListBox.Items.Add(potion);
        }
    }

    private void RefreshBrewersList()
    {
        _brewersListBox.Items.Clear();
        foreach (var brewer in _brewery.GetAllBrewers())
        {
            _brewersListBox.Items.Add(brewer);
        }
    }

    private void RefreshOrdersGrid()
    {
        _ordersBindingSource.ResetBindings(false);
    }

    private void RefreshComboBoxes()
    {
        // Place Order selectors
        _orderPotionComboBox.Items.Clear();
        foreach (var p in _brewery.GetAllPotions())
        {
            _orderPotionComboBox.Items.Add(p.Name);
        }
        if (_orderPotionComboBox.Items.Count > 0) _orderPotionComboBox.SelectedIndex = 0;

        _orderBrewerComboBox.Items.Clear();
        foreach (var b in _brewery.GetAllBrewers())
        {
            _orderBrewerComboBox.Items.Add(b.Name);
        }
        if (_orderBrewerComboBox.Items.Count > 0) _orderBrewerComboBox.SelectedIndex = 0;

        // Populate Enum selectors in Forms
        if (_ingRarityComboBox.Items.Count == 0)
        {
            _ingRarityComboBox.DataSource = Enum.GetValues(typeof(Rarity));
            _potionRarityComboBox.DataSource = Enum.GetValues(typeof(Rarity));
            _potionEffectComboBox.DataSource = Enum.GetValues(typeof(PotionEffect));
            _brewerSpecComboBox.DataSource = Enum.GetValues(typeof(PotionEffect));
            
            _ingTypeComboBox.Items.AddRange(new[] { "Herb", "Mineral", "Creature" });
            _ingTypeComboBox.SelectedIndex = 0;
        }
    }

    private void RefreshQueriesTab()
    {
        _queriesOutputTextBox.Clear();
        
        var totalRev = _brewery.GetTotalRevenue();
        var avgSkill = _brewery.GetAverageBrewerSkill();
        var topBrewer = _brewery.GetTopBrewersByPotionsBrewed(1).FirstOrDefault();
        
        _queriesOutputTextBox.AppendText($"--- BREWERY STATS ---\r\n");
        _queriesOutputTextBox.AppendText($"Total Revenue: {totalRev}g\r\n");
        _queriesOutputTextBox.AppendText($"Average Brewer Skill: {avgSkill:F2}/10\r\n");
        _queriesOutputTextBox.AppendText($"Top Brewer: {(topBrewer != null ? $"{topBrewer.Name} ({topBrewer.PotionsBrewed} potions)" : "None")}\r\n\r\n");

        _queriesOutputTextBox.AppendText($"--- POTIONS BY EFFECT GROUP ---\r\n");
        foreach (var group in _brewery.GetPotionCountByEffect())
        {
            _queriesOutputTextBox.AppendText($"- {group.Effect}: {group.Count} recipes\r\n");
        }

        _queriesOutputTextBox.AppendText($"\r\n--- MOST EXPENSIVE RECIPES ---\r\n");
        foreach (var p in _brewery.GetMostExpensivePotions(3))
        {
            _queriesOutputTextBox.AppendText($"- {p.Name} ({p.Price}g)\r\n");
        }
    }

    private void _addIngredientButton_Click(object sender, EventArgs e)
    {
        try
        {
            string name = _ingNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(name)) throw new InvalidOperationException("Name cannot be empty.");
            
            Rarity rarity = (Rarity)_ingRarityComboBox.SelectedItem;
            decimal basePrice = _ingPriceNumeric.Value;
            string desc = _ingDescTextBox.Text.Trim();
            string type = _ingTypeComboBox.SelectedItem.ToString();
            string specParam = _ingSpecParamTextBox.Text.Trim();

            if (string.IsNullOrEmpty(specParam)) throw new InvalidOperationException("Specific parameter (Region/Mine/Creature) cannot be empty.");

            Ingredient ing = type switch
            {
                "Herb" => new HerbIngredient(name, rarity, basePrice, desc, specParam),
                "Mineral" => new MineralIngredient(name, rarity, basePrice, desc, specParam),
                "Creature" => new CreatureIngredient(name, rarity, basePrice, desc, specParam),
                _ => throw new InvalidOperationException("Invalid type")
            };

            _brewery.AddIngredient(ing);
            RefreshIngredientsList();
            RefreshComboBoxes();
            RefreshQueriesTab();
            _ingNameTextBox.Clear();
            _ingDescTextBox.Clear();
            _ingSpecParamTextBox.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void _ingTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        string type = _ingTypeComboBox.SelectedItem?.ToString();
        _ingSpecParamLabel.Text = type switch
        {
            "Herb" => "Region:",
            "Mineral" => "Mine Type:",
            "Creature" => "Creature Name:",
            _ => "Parameter:"
        };
    }

    private void _addBrewerButton_Click(object sender, EventArgs e)
    {
        try
        {
            string name = _brewerNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(name)) throw new InvalidOperationException("Name cannot be empty.");
            
            int skill = (int)_brewerSkillNumeric.Value;
            PotionEffect spec = (PotionEffect)_brewerSpecComboBox.SelectedItem;

            var brewer = new Brewer(name, skill, spec);
            _brewery.AddBrewer(brewer);
            
            RefreshBrewersList();
            RefreshComboBoxes();
            RefreshQueriesTab();
            _brewerNameTextBox.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void _addPotionButton_Click(object sender, EventArgs e)
    {
        try
        {
            string name = _potionNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(name)) throw new InvalidOperationException("Name cannot be empty.");

            PotionEffect effect = (PotionEffect)_potionEffectComboBox.SelectedItem;
            Rarity rarity = (Rarity)_potionRarityComboBox.SelectedItem;
            decimal price = _potionPriceNumeric.Value;
            int brewTime = (int)_potionTimeNumeric.Value;

            var selectedIngredients = new List<Ingredient>();
            foreach (var item in _potionIngredientsCheckedListBox.CheckedItems)
            {
                selectedIngredients.Add((Ingredient)item);
            }

            if (selectedIngredients.Count == 0)
            {
                throw new InvalidPotionException("A potion must contain at least one ingredient.");
            }

            var potion = new Potion(name, effect, rarity, selectedIngredients, brewTime, price);
            _brewery.AddPotion(potion);

            RefreshPotionsList();
            RefreshComboBoxes();
            RefreshQueriesTab();

            _potionNameTextBox.Clear();
            for (int i = 0; i < _potionIngredientsCheckedListBox.Items.Count; i++)
            {
                _potionIngredientsCheckedListBox.SetItemChecked(i, false);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void _placeOrderButton_Click(object sender, EventArgs e)
    {
        try
        {
            string potionName = _orderPotionComboBox.SelectedItem?.ToString();
            string brewerName = _orderBrewerComboBox.SelectedItem?.ToString();
            string customer = _orderCustomerTextBox.Text.Trim();

            if (string.IsNullOrEmpty(potionName) || string.IsNullOrEmpty(brewerName))
            {
                throw new InvalidOperationException("Potion and Brewer must be selected.");
            }
            if (string.IsNullOrEmpty(customer))
            {
                throw new InvalidOperationException("Customer name is required.");
            }

            _brewery.PlaceOrder(potionName, brewerName, customer);
            RefreshOrdersGrid();
            RefreshQueriesTab();
            _orderCustomerTextBox.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ordering Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void _completeOrderButton_Click(object sender, EventArgs e)
    {
        if (_ordersDataGridView.CurrentRow == null) return;
        var order = (BrewOrder)_ordersDataGridView.CurrentRow.DataBoundItem;
        if (order != null)
        {
            _brewery.CompleteOrder(order.Id);
            RefreshOrdersGrid();
            RefreshBrewersList(); // update brewer money
            RefreshQueriesTab();  // update revenue
        }
    }

    // JSON serialization classes
    private class BreweryData
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Potion> Potions { get; set; }
        public List<Brewer> Brewers { get; set; }
        public List<BrewOrder> Orders { get; set; }
    }

    private void saveJsonMenuItem_Click(object sender, EventArgs e)
    {
        using SaveFileDialog sfd = new SaveFileDialog();
        sfd.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                var data = new BreweryData
                {
                    Name = _brewery.Name,
                    Ingredients = _brewery.GetAllIngredients(),
                    Potions = _brewery.GetAllPotions(),
                    Brewers = _brewery.GetAllBrewers(),
                    Orders = _brewery.GetAllOrders()
                };

                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(sfd.FileName, json);
                MessageBox.Show("Successfully saved brewery data to JSON.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void loadJsonMenuItem_Click(object sender, EventArgs e)
    {
        using OpenFileDialog ofd = new OpenFileDialog();
        ofd.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                string json = File.ReadAllText(ofd.FileNames[0]);
                var data = JsonSerializer.Deserialize<BreweryData>(json);

                if (data != null)
                {
                    _brewery.Name = data.Name;
                    _brewery.LoadData(data.Ingredients, data.Potions, data.Brewers, data.Orders);
                    
                    RefreshAllUI();
                    MessageBox.Show("Successfully loaded brewery data from JSON.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void exitMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void aboutMenuItem_Click(object sender, EventArgs e)
    {
        MessageBox.Show(
            $"{_brewery.Name} Potion Brewery Workshop Management System\nDeveloped for Advanced Programming Lab 8-9.",
            "About",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );
    }
}
