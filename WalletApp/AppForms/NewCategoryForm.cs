using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WalletApp.Models;

namespace WalletApp.AppForms
{
    public partial class NewCategoryForm : Form
    {
        private bool categoryType;
        private users _user;
        public NewCategoryForm(users users)
        {
            InitializeComponent();
            _user  = users;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewCategoryForm_Load(object sender, EventArgs e)
        {
            
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверка что выбран не заглушка
            if (CategoryComboBox.SelectedIndex > 0 && CategoryComboBox.SelectedValue is int parentId)
            {
                var categories = Program.context.categories
                    .Where(c => c.parent_id == parentId)
                    .ToList();
                if (categories.Count > 0)
                {
                    this.category_idLabel1.Visible = true;
                    CategoryComboBox1.Visible = true;
                    categories.Insert(0, new categories { category_id = 0, name = "--Выберите категорию--" });

                    CategoryComboBox1.DataSource = categories;
                    CategoryComboBox1.DisplayMember = "name";
                    CategoryComboBox1.ValueMember = "category_id";
                    CategoryComboBox1.SelectedIndex = 0;
                }
            }
            else
            {
                // Если выбрана заглушка — список подкатегорий очищаем!
                CategoryComboBox1.DataSource = null;
                CategoryComboBox1.Visible = false;
                category_idLabel1.Visible = false;
            }
        }

        

        

        private void CategoryTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryTypeComboBox.SelectedIndex > 0)
            {
                if (CategoryTypeComboBox.SelectedIndex == 1)
                    categoryType = false;
                else if (CategoryTypeComboBox.SelectedIndex == 2)
                    categoryType = true;
                else categoryType = false;

                var categories = Program.context.categories
                    .Where(c => c.parent_id == null && c.is_income == categoryType)
                    .ToList();


                if (categories.Count > 0)
                {
                    this.category_idLabel.Visible = true;
                    CategoryComboBox.Visible = true;
                    categories.Insert(0, new categories { category_id = 0, name = "--Выберите категорию--" });

                    CategoryComboBox.DataSource = new List<categories>(categories);
                    CategoryComboBox.DisplayMember = "name";
                    CategoryComboBox.ValueMember = "category_id";
                    CategoryComboBox.SelectedIndex = 0;
                }
            }
            else
            {
                // Если выбрана заглушка — список подкатегорий очищаем!
                CategoryComboBox.DataSource = null;
                CategoryComboBox.Visible = false;
                category_idLabel.Visible = false;
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (CategoryNameTextBox.Text.Length >=3)
            {
                categories categoriess = new categories();
                categoriess.parent_id = (int)CategoryComboBox1.SelectedValue;
                categoriess.user_id = _user.user_id;
                categoriess.name = CategoryNameTextBox.Text;
                categoriess.is_income = categoryType;
                Program.context.categories.Add(categoriess);
                Program.context.SaveChanges();
                MessageBox.Show("Категория создана", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void CategoryComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (CategoryComboBox1.SelectedIndex > 0 && CategoryComboBox1.SelectedValue is int parentId)
            {
                CategoryNameTextBox.Visible = true;
                category_idLabel2.Visible = true;               
            }
            else
            {
                // Если выбрана заглушка — список подкатегорий очищаем!
                CategoryNameTextBox.Visible = false;
                category_idLabel2.Visible = false;
            }
        }
    }
}
