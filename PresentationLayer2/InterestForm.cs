using Business_Layer;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer2
{
    public partial class InterestForm : Form
    {
        private DbManager<Interest, int> dbManager = new DbManager<Interest, int>(ContextGenerator.GetInterestContext());
        private Interest selectedInterest;
        public InterestForm()
        {
            InitializeComponent();
            LoadInterest();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                Interest interesi = new Interest(name);
                dbManager.Create(interesi);
                MessageBox.Show("Interes created successfully! :)", "😎", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInterest();

                ClearTextBoxes();

                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "😭", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedInterest != null)
                {
                    dbManager.Delete(selectedInterest.InterestID);
                    MessageBox.Show("User ☠️ successfully!", "💀", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxes();
                    selectedInterest = null;
                    LoadInterest();
                }
                else
                {
                    MessageBox.Show("Choose user from the table! 🧙‍♂", "👎🏼", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "😭", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                selectedInterest.Name = textBox1.Text;


                dbManager.Update(selectedInterest);

                MessageBox.Show("Interes updated successfully! :)", "😎", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInterest();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "😭", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
              MenuForm menu = new MenuForm();
                menu.Show();
                this.Close();
            
        }
        private void interesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                MessageBox.Show("🔥");
                return;
            }
            selectedInterest = dataGridView1.Rows[e.RowIndex].DataBoundItem as Interest;
            FillTextBoxes(GetSelectedInteres());
        }

        private void FillTextBoxes(Interest selectedInteres)
        {
            if (selectedInteres != null)
            {
                textBox1.Text = selectedInteres.Name;
            }
        }
        private void LoadInterest()
        {
            dataGridView1.DataSource = dbManager.ReadAll();
        }
        private void ClearTextBoxes()
        {
            textBox1.Text = string.Empty;
        }
        private Interest GetSelectedInteres()
        {
            return selectedInterest;
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
