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
    public partial class NewGoalForm : Form
    {
        private users _user;
        public NewGoalForm(users users)
        {
            InitializeComponent();
            _user = users;
        }

        private void NewGoalForm_Load(object sender, EventArgs e)
        {
            
        }

        
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Length >=2 && AmountTextBox.Text.Length >=1)
            {
                savings_goals savings_Goals = new savings_goals();
                savings_Goals.user_id = _user.user_id;
                savings_Goals.name = NameTextBox.Text;
                savings_Goals.target_amount = Convert.ToDecimal(AmountTextBox.Text);
                Program.context.savings_goals.Add(savings_Goals);
                Program.context.SaveChanges();
                MessageBox.Show("Новая цель сохранена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
