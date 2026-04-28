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
    public partial class AddTransferToGoalForm : Form
    {
        private savings_goals _savings_goals;
        public AddTransferToGoalForm(savings_goals savings_goals)
        {
            InitializeComponent();
            _savings_goals = savings_goals;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                savings_transfers savings_Transfers  = new savings_transfers();
                savings_Transfers.transfer_date = DateTime.Now;
                savings_Transfers.amount = Convert.ToDecimal(AmountTextBox.Text);
                savings_Transfers.goal_id = _savings_goals.goal_id;
                Program.context.savings_transfers.Add(savings_Transfers);
                Program.context.SaveChanges();
                DialogResult = MessageBox.Show("Данные сохранены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private bool ValidateFields()
        {
            if( AmountTextBox.Text.Length <= 1)
            {
                MessageBox.Show("Укажите, какую сумму вы хотите отложить", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
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

        private void AddTransferToGoalForm_Load(object sender, EventArgs e)
        {
            
            
            
        }
    }
}
