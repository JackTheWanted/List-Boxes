//Jack
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace List_Boxes
{

    public partial class ListBoxes : Form
    {
        public ListBoxes()
        {
            
            InitializeComponent();
        }
        List<int> numbers = new List<int>();
        List<string> heroes = new List<string>();
        Random generator = new Random();
        private void btnNewNumbers_Click(object sender, EventArgs e)
        {
            numbers.Clear();
            for (int i = 0; i < 20; i++)
            {
                numbers.Add(generator.Next(100));
            }
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            lblStatus.Text = "Status; new numbers list";
        }

        private void btnSortNumbers_Click(object sender, EventArgs e)
        {
            numbers.Sort();
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            lblStatus.Text = "Status; numbers sorted";
        }

        private void btnNewHeroes_Click(object sender, EventArgs e)
        {
            heroes.Clear();
            heroes.Add("BATMAN");
            heroes.Add("SUPERMAN");
            lstHeroes.DataSource = null;
            lstHeroes.DataSource = heroes;
            lblStatus.Text = "Status; new heroes list";
        }

        private void btnSortHeroes_Click(object sender, EventArgs e)
        {
            heroes.Sort();
            lstHeroes.DataSource = null;
            lstHeroes.DataSource = heroes;
            lblStatus.Text = "Status; heros sorted";
        }

        private void btnRemoveNumber_Click(object sender, EventArgs e)
        {
            if (lstNumbers.SelectedIndex >= 0)
            {
                lblStatus.Text = ($"The number {(Int32)lstNumbers.SelectedItem} has been removed");
                numbers.RemoveAt(lstNumbers.SelectedIndex);
                lstNumbers.DataSource = null;
                lstNumbers.DataSource = numbers;
            }
            
        }

        private void btnRemoveAllNumbers_Click(object sender, EventArgs e)
        {
            lblStatus.Text = ($"All instances of the number {(Int32)lstNumbers.SelectedItem} have been removed");

            while (numbers.Contains((Int32)lstNumbers.SelectedItem))
            {

                numbers.Remove((Int32)lstNumbers.SelectedItem);
            }
            
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            
        }

        private void btnAddHero_Click(object sender, EventArgs e)
        {
            
            string newHero = txtAddHero.Text.Trim();
            if (newHero != "")
            {
                if (heroes.Contains(newHero.ToUpper()))
                {
                    lblStatus.Text = "Please enter a hero not already in the list";
                    txtAddHero.Text = "";
                }                
                else
                {
                    heroes.Add(newHero.ToUpper());
                    lstHeroes.DataSource = null;
                    lstHeroes.DataSource = heroes;                    
                    lblStatus.Text = ($"New hero named {newHero} had been added");
                    txtAddHero.Text = "";
                }

            }
            
        }

        private void btnRemoveHero_Click(object sender, EventArgs e)
        {
            if (heroes.Contains(txtAddHero.Text))
            {
                heroes.Remove(txtRemoveHero.Text.ToUpper());
                lstHeroes.DataSource = null;
                lstHeroes.DataSource = heroes;
                lblStatus.Text = (txtRemoveHero.Text + " has been removed");
                txtRemoveHero.Text = "";
            }
            
            else
            {
                lblStatus.Text = (txtRemoveHero.Text + " does not exist in the list of current heroes");
                txtRemoveHero.Text = "";
            }

        }

        private void ListBoxes_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                numbers.Add(generator.Next(100));
            }
            lstNumbers.DataSource = numbers;

            heroes.Add("BATMAN");
            heroes.Add("SUPERMAN");
            lstHeroes.DataSource = heroes;
        }

        private void lstHeroes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReverseNumbers_Click(object sender, EventArgs e)
        {
            numbers.Sort();
            numbers.Reverse();
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            lblStatus.Text = "Status; numbers sorted";
        }

        private void btnReverseHeroes_Click(object sender, EventArgs e)
        {
            heroes.Sort();
            heroes.Reverse();
            lstHeroes.DataSource = null;
            lstHeroes.DataSource = heroes;
            lblStatus.Text = "Status; heros sorted";
        }
    }
}
