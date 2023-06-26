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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresentationLayer2
{
    public partial class UserForm : Form
    {
        private DbManager<User, int> dbManager = new DbManager<User, int>(ContextGenerator.GetUserContext());
        private User selectedUser;
        public UserForm()
        {
            InitializeComponent();
            LoadUser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string familyname = textBox2.Text;
                decimal age = numericUpDown1.Value;
                string username = textBox3.Text;
                string password = textBox4.Text;
                string email = textBox5.Text;
                User potrebitel = new User(name, familyname, age, username, password, email);
                dbManager.Create(potrebitel);
                MessageBox.Show("User created successfully! :)", "😎", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUser();

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

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                selectedUser.Name = textBox1.Text;
                selectedUser.Surname = textBox1.Text;
                selectedUser.Age = numericUpDown1.Value;
                selectedUser.Username = textBox2.Text;
                selectedUser.Password = textBox3.Text;
                selectedUser.Email = textBox4.Text;


                dbManager.Update(selectedUser);

                MessageBox.Show("User updated successfully! :)", "😎", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUser();
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
                if (selectedUser != null)
                {
                    dbManager.Delete(selectedUser.ID);
                    MessageBox.Show("User ☠️ successfully!", "💀", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxes();
                    selectedUser= null;
                    LoadUser();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                MessageBox.Show("🔥");
                return;
            }
            selectedUser = dataGridView1.Rows[e.RowIndex].DataBoundItem as User;
            FillTextBoxes(GetSelectedPotrebitel());
        }
        private void clear_btn_Click(object sender, EventArgs e)
        {
            selectedUser = null;
            ClearTextBoxes();
        }
        private void ClearTextBoxes()
        {
            textBox1.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            numericUpDown1.Value = 0;
            textBox4.Text = string.Empty;
        }

        private User GetSelectedPotrebitel()
        {
            return selectedUser;
        }

        private void FillTextBoxes(User selectedPotrebitel)
        {
            if (selectedPotrebitel != null)
            {
                textBox1.Text = selectedPotrebitel.Name;
                textBox1.Text = selectedPotrebitel.Surname;
                numericUpDown1.Value = selectedPotrebitel.Age;
                textBox2.Text = selectedPotrebitel.Username;
                textBox3.Text = selectedPotrebitel.Password;
                textBox4.Text = selectedPotrebitel.Email;

            }
        }

        private void LoadUser()
        {
            dataGridView1.DataSource = dbManager.ReadAll();
        }

        private void age_numericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MenuForm menu = new MenuForm();
            menu.Show();
            this.Close();
        }
    }
}
