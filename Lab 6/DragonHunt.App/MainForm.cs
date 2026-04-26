using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DragonHunt.Library;

namespace DragonHunt.App
{
    public class MainForm : Form
    {
        // party members
        private Warrior warrior;
        private Archer archer;
        private Wizard wizard;
        private Dragon dragon;

        // ui controls for each fighter
        private Label labelWarrior, labelArcher, labelWizard, labelDragon;
        private ProgressBar barWarrior, barArcher, barWizard, barDragon;
        private Button potionWarrior, potionArcher, potionWizard;
        private TextBox expWarrior, expArcher, expWizard;
        private Button addExpWarrior, addExpArcher, addExpWizard;

        private Label labelPotionsLeft;
        private Label labelStatus;
        private Button buttonRound;
        private Button buttonReset;

        private int potionsLeft = 3;

        public MainForm()
        {
            BuildUi();
            ResetBattle();
        }

        // create the party from scratch and wire up the dragon event
        private void SetupHeroesAndDragon()
        {
            warrior = new Warrior("Aldric");
            archer = new Archer("Lyra");
            wizard = new Wizard("Merlin");

            // object initializer for dragon, no constructors defined in library
            dragon = new Dragon
            {
                Name = "Smaug",
                Level = 10,
                ExperiencePoints = 0,
                Strength = 30,
                Dexterity = 15,
                Intelligence = 20,
                MaxHealth = 300,
                CurrentHealth = 300,
                Damage = 25,
                DamageResistance = 10,
                ExperienceReward = 1000
            };

            // lambda subscription, every party member takes fire damage
            dragon.OnFireBreath += (intensity) =>
            {
                warrior.TakeDamage(intensity);
                archer.TakeDamage(intensity);
                wizard.TakeDamage(intensity);
            };
        }

        private void BuildUi()
        {
            Text = "Dragon Hunt";
            Width = 900;
            Height = 520;
            StartPosition = FormStartPosition.CenterScreen;

            labelPotionsLeft = new Label { Left = 20, Top = 10, Width = 300, Text = "Healing potions: 3" };
            Controls.Add(labelPotionsLeft);

            // warrior column
            labelWarrior = MakeLabel(20, 50);
            barWarrior = MakeBar(20, 75);
            potionWarrior = MakeButton(20, 110, "Drink potion");
            potionWarrior.Click += (s, e) => UsePotion(warrior);
            expWarrior = new TextBox { Left = 20, Top = 145, Width = 80, Text = "0" };
            addExpWarrior = MakeButton(110, 143, "Add EXP", 90);
            addExpWarrior.Click += (s, e) => AddExperience(warrior, expWarrior);
            Controls.AddRange(new Control[] { labelWarrior, barWarrior, potionWarrior, expWarrior, addExpWarrior });

            // archer column
            labelArcher = MakeLabel(220, 50);
            barArcher = MakeBar(220, 75);
            potionArcher = MakeButton(220, 110, "Drink potion");
            potionArcher.Click += (s, e) => UsePotion(archer);
            expArcher = new TextBox { Left = 220, Top = 145, Width = 80, Text = "0" };
            addExpArcher = MakeButton(310, 143, "Add EXP", 90);
            addExpArcher.Click += (s, e) => AddExperience(archer, expArcher);
            Controls.AddRange(new Control[] { labelArcher, barArcher, potionArcher, expArcher, addExpArcher });

            // wizard column
            labelWizard = MakeLabel(420, 50);
            barWizard = MakeBar(420, 75);
            potionWizard = MakeButton(420, 110, "Drink potion");
            potionWizard.Click += (s, e) => UsePotion(wizard);
            expWizard = new TextBox { Left = 420, Top = 145, Width = 80, Text = "0" };
            addExpWizard = MakeButton(510, 143, "Add EXP", 90);
            addExpWizard.Click += (s, e) => AddExperience(wizard, expWizard);
            Controls.AddRange(new Control[] { labelWizard, barWizard, potionWizard, expWizard, addExpWizard });

            // dragon column
            labelDragon = MakeLabel(620, 50, 240);
            barDragon = MakeBar(620, 75, 240);
            Controls.AddRange(new Control[] { labelDragon, barDragon });

            buttonRound = new Button { Left = 20, Top = 220, Width = 200, Height = 40, Text = "Fight one round!" };
            buttonRound.Click += (s, e) => DoRound();
            Controls.Add(buttonRound);

            buttonReset = new Button { Left = 240, Top = 220, Width = 200, Height = 40, Text = "Reset battle" };
            buttonReset.Click += (s, e) => ResetBattle();
            Controls.Add(buttonReset);

            labelStatus = new Label { Left = 20, Top = 280, Width = 800, Height = 60, Text = "" };
            Controls.Add(labelStatus);
        }

        private static Label MakeLabel(int left, int top, int width = 180)
        {
            return new Label { Left = left, Top = top, Width = width, Text = "" };
        }

        private static ProgressBar MakeBar(int left, int top, int width = 180)
        {
            return new ProgressBar { Left = left, Top = top, Width = width, Height = 25 };
        }

        private static Button MakeButton(int left, int top, string text, int width = 120)
        {
            return new Button { Left = left, Top = top, Width = width, Text = text };
        }

        // single round: party hits dragon, then dragon strikes back
        public static void PerformRound(Warrior w, Archer a, Wizard m, Dragon d)
        {
            if (!w.IsDead) d.TakeDamage(w.RoundDamage);
            if (!a.IsDead) d.TakeDamage(a.RoundDamage);
            if (!m.IsDead) d.TakeDamage(m.RoundDamage);

            if (!d.IsDead)
            {
                d.BreatheFire();
            }
        }

        private void DoRound()
        {
            PerformRound(warrior, archer, wizard, dragon);
            UpdateAllControls();
            CheckBattleEnd();
        }

        private void CheckBattleEnd()
        {
            bool partyDead = warrior.IsDead && archer.IsDead && wizard.IsDead;
            if (dragon.IsDead)
            {
                buttonRound.Enabled = false;
                labelStatus.Text = "Victory! The dragon has fallen.";
            }
            else if (partyDead)
            {
                buttonRound.Enabled = false;
                labelStatus.Text = "Defeat... the dragon devoured the party.";
            }
        }

        private void UsePotion(Character target)
        {
            if (potionsLeft <= 0 || target.IsDead) return;
            target.DrinkFullHealingPotion();
            potionsLeft--;
            labelPotionsLeft.Text = $"Healing potions: {potionsLeft}";

            if (potionsLeft == 0)
            {
                potionWarrior.Enabled = false;
                potionArcher.Enabled = false;
                potionWizard.Enabled = false;
            }
            UpdateAllControls();
        }

        private void AddExperience(Character target, TextBox input)
        {
            if (int.TryParse(input.Text, out int amount) && amount > 0)
            {
                target.GainExperience(amount);
                UpdateAllControls();
            }
        }

        private void UpdateAllControls()
        {
            UpdateBar(labelWarrior, barWarrior, warrior);
            UpdateBar(labelArcher, barArcher, archer);
            UpdateBar(labelWizard, barWizard, wizard);
            UpdateBar(labelDragon, barDragon, dragon);
        }

        private static void UpdateBar(Label label, ProgressBar bar, Character c)
        {
            label.Text = $"{c.Name} (Lvl {c.Level}) {c.CurrentHealth}/{c.MaxHealth}";
            bar.Minimum = 0;
            bar.Maximum = c.MaxHealth;
            bar.Value = Math.Max(0, Math.Min(c.CurrentHealth, c.MaxHealth));
        }

        private void ResetBattle()
        {
            SetupHeroesAndDragon();
            potionsLeft = 3;
            labelPotionsLeft.Text = $"Healing potions: {potionsLeft}";
            potionWarrior.Enabled = true;
            potionArcher.Enabled = true;
            potionWizard.Enabled = true;
            buttonRound.Enabled = true;
            labelStatus.Text = "";
            UpdateAllControls();
        }
    }
}
