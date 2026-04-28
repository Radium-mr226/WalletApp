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
    public partial class Autorization : Form
    {
        private bool isSignIn = true;
        private bool isPassVisible = false;
        private bool isPassVisible1 = false;
        public Autorization()
        {
            InitializeComponent();
            PasswordTextBox.UseSystemPasswordChar = true;
            PasswordTextBox1.UseSystemPasswordChar = true;
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            isSignIn = true;
            PasswordLabel1.Visible = false;
            PasswordTextBox1.Visible = false;
            LoginButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            LoginButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            RegistrationButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(205)))), ((int)(((byte)(255)))));
            RegistrationButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(205)))), ((int)(((byte)(255)))));
            AuthorizationButton.Text = "Вход";
            LoginTextBox.Text = null;
            PasswordTextBox.Text = null;
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            isSignIn = false;
            PasswordLabel1.Visible = true;
            PasswordTextBox1.Visible = true;
            RegistrationButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            RegistrationButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            LoginButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(205)))), ((int)(((byte)(255)))));
            LoginButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(205)))), ((int)(((byte)(255)))));
            AuthorizationButton.Text = "Регистрация";
            LoginTextBox.Text = null;
            PasswordTextBox.Text = null;
        }

        private void AuthorizationButton_Click(object sender, EventArgs e)
        {
            if (isSignIn)
            {
                string username = LoginTextBox.Text;
                string password = PasswordTextBox.Text;
                string password1 = PasswordTextBox1.Text;

                try
                {
                    List<users> users = Program.context.users.ToList();
                    users u = users.FirstOrDefault(p => p.user_login == username && p.password_hash == password);
                    if (u != null)
                    {
                        MainForm mainForm = new MainForm(u);
                        mainForm.Owner = this;
                        this.Hide();
                        PasswordTextBox.Clear();
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                

                try
                {

                    // 2. ПРОВЕРКА: Есть ли уже такой логин в базе?
                    // .Any() возвращает true, если найдена хотя бы одна запись
                    bool userExists = Program.context.users.Any(u => u.user_login == LoginTextBox.Text);

                    if (userExists)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует!");
                        return; // Прерываем метод, не даем зарегистрироваться
                    }

                    if (PasswordTextBox.Text != PasswordTextBox1.Text)
                    {
                        MessageBox.Show("Пароли не совпадают!");
                        return; // Прерываем метод, не даем зарегистрироваться
                    }
                    // 3. Если логин свободен — создаем нового пользователя
                    users newUser = new users();
                    
                    newUser.user_login = LoginTextBox.Text;
                    newUser.password_hash = PasswordTextBox.Text;

                    Program.context.users.Add(newUser);
                    Program.context.SaveChanges(); // ⚠️ Обязательно сохраняем изменения в БД!

                    MessageBox.Show("Регистрация успешна!");
                    MainForm mainForm = new MainForm(newUser);
                    mainForm.Owner = this;
                    this.Hide();
                    PasswordTextBox.Clear();
                    mainForm.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void PasswordTextBox_IconRightClick(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = isPassVisible;
            isPassVisible = !isPassVisible;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PasswordTextBox1_IconRightClick(object sender, EventArgs e)
        {
            PasswordTextBox1.UseSystemPasswordChar = isPassVisible1;
            isPassVisible1 = !isPassVisible1;
        }
    }
}
