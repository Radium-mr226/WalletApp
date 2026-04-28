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
    public partial class SettingsForm : Form
    {
        private users _user;
        private bool isPassVisible = false;

        public SettingsForm(users users)
        {
            InitializeComponent();
            _user = users;
        }

        private void guna2TextBox1_IconRightClick(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = isPassVisible;
            isPassVisible = !isPassVisible;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                _user.user_login = LoginTextBox.Text;
                _user.password_hash = PasswordTextBox.Text;
            }
        }

        private bool ValidateFields()
        {
            if (LoginTextBox.Text.Length <=2)
            {
                MessageBox.Show("Логин должен быть больше 2 символов","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (PasswordTextBox.Text.Length <=7)
            {
                MessageBox.Show("Пароль должен быть не менее 8 символов","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void NewCategoryGradientButton_Click(object sender, EventArgs e)
        {
            NewCategoryForm newCategoryForm = new NewCategoryForm(_user);
            newCategoryForm.ShowDialog();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = true;
            LoginTextBox.Text = _user.user_login;
            PasswordTextBox.Text = _user.password_hash;
        }
    }
}
