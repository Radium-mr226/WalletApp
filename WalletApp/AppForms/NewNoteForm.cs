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
    public partial class NewNoteForm : Form
    {
        private bool categoryType;
        private users _user;
        public NewNoteForm( users users)
        {
            InitializeComponent();
            _user = users;
        }  

        private void NewNoteForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "courseProjectDataSet.transactions". При необходимости она может быть перемещена или удалена.
            this.transactionsTableAdapter.Fill(this.courseProjectDataSet.transactions);
            CategoryTypeComboBox.SelectedIndex = 0;
            

            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void CategoryComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryComboBox1.SelectedIndex > 0 && CategoryComboBox1.SelectedValue is int parentId)
            {
                var categories = Program.context.categories
                    .Where(c => c.parent_id == parentId)
                    .ToList();
                if (categories.Count > 0) {
                    CategoryComboBox2.Visible = true;
                    category_idLabel2.Visible = true;
                    categories.Insert(0, new categories { category_id = 0, name = "--Выберите категорию--" });

                    CategoryComboBox2.DataSource = new List<categories>(categories);
                    CategoryComboBox2.DisplayMember = "name";
                    CategoryComboBox2.ValueMember = "category_id";
                    CategoryComboBox2.SelectedIndex = 0;
                }
            }
            else
            {
                // Если выбрана заглушка — список подкатегорий очищаем!
                CategoryComboBox2.DataSource = null;
                CategoryComboBox2.Visible = false;
                category_idLabel2.Visible = false;
            }
        }

        private void AmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                return;

            // Заменяем точку на запятую (для десятичного разделителя)
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Обработка запятой: разрешаем только одну и не в начале пустой строки
            if (e.KeyChar == ',')
            {
                if (AmountTextBox.Text.IndexOf(',') != -1 || AmountTextBox.Text.Length == 0)
                {
                    e.Handled = true; // Отменяем ввод
                }
                return;
            }


            // Разрешаем управляющие символы (например, Backspace)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Любые другие символы — отменяем
            e.Handled = true;
        }

        private void CategoryTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryTypeComboBox.SelectedIndex > 0 )
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
            if (ValidateFields())
            {
                transactions transaction = new transactions();
                transaction.user_id = _user.user_id;
                if (CategoryComboBox2.SelectedIndex > 0)
                    transaction.category_id = (int)CategoryComboBox2.SelectedValue;
                else transaction.category_id = (int)CategoryComboBox1.SelectedValue;
                if(categoryType == false) 
                transaction.amount = Convert.ToDecimal("-" + AmountTextBox.Text);
                else transaction.amount = Convert.ToDecimal(AmountTextBox.Text);
                transaction.transaction_date = DateTime.Now;
                transaction.is_income = categoryType;
                MessageBox.Show("Транзакция сохранена","Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);   
                Program.context.transactions.Add(transaction);
                Program.context.SaveChanges();
                this.Close();
            }
        }

        private bool ValidateFields()
        {
            if (AmountTextBox.Text.Length <= 0)
            {
                MessageBox.Show("Введите сумму бюджета", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (CategoryTypeComboBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Выберите тип транзакции", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (CategoryComboBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Выберите категрию", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (CategoryComboBox1.SelectedIndex <= 0)
            {
                MessageBox.Show("Выберите подкатегрию", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
