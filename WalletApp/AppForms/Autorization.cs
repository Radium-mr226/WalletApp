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
    /// <summary>
    /// Форма авторизации пользователя.
    /// Предоставляет функционал входа в систему и регистрации нового пользователя.
    /// Поддерживает переключение между режимами "Вход" и "Регистрация".
    /// </summary>
    public partial class Autorization : Form
    {
        /// <summary>Флаг режима работы формы: true — вход, false — регистрация.</summary>
        private bool isSignIn = true;

        /// <summary>Флаг видимости пароля в поле ввода (основное поле).</summary>
        private bool isPassVisible = false;

        /// <summary>Флаг видимости пароля в поле подтверждения (дополнительное поле).</summary>
        private bool isPassVisible1 = false;

        /// <summary>
        /// Инициализирует новый экземпляр формы авторизации.
        /// Настраивает поля пароля для скрытого ввода символов.
        /// </summary>
        public Autorization()
        {
            InitializeComponent();
            // Включаем маскирование символов пароля при вводе
            PasswordTextBox.UseSystemPasswordChar = true;
            PasswordTextBox1.UseSystemPasswordChar = true;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Вход".
        /// Переключает форму в режим авторизации существующего пользователя.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Устанавливаем режим входа в систему
            isSignIn = true;

            // Скрываем поле подтверждения пароля (не нужно при входе)
            PasswordLabel1.Visible = false;
            PasswordTextBox1.Visible = false;

            // Визуально выделяем активную кнопку "Вход"
            LoginButton.FillColor = System.Drawing.Color.FromArgb(217, 217, 217);
            LoginButton.FillColor2 = System.Drawing.Color.FromArgb(217, 217, 217);
            RegistrationButton.FillColor = System.Drawing.Color.FromArgb(206, 205, 255);
            RegistrationButton.FillColor2 = System.Drawing.Color.FromArgb(206, 205, 255);

            // Меняем текст кнопки подтверждения на "Вход"
            AuthorizationButton.Text = "Вход";

            // Очищаем поля ввода
            LoginTextBox.Text = null;
            PasswordTextBox.Text = null;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Регистрация".
        /// Переключает форму в режим создания нового аккаунта.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            // Устанавливаем режим регистрации
            isSignIn = false;

            // Показываем поле подтверждения пароля (нужно при регистрации)
            PasswordLabel1.Visible = true;
            PasswordTextBox1.Visible = true;

            // Визуально выделяем активную кнопку "Регистрация"
            RegistrationButton.FillColor = System.Drawing.Color.FromArgb(217, 217, 217);
            RegistrationButton.FillColor2 = System.Drawing.Color.FromArgb(217, 217, 217);
            LoginButton.FillColor = System.Drawing.Color.FromArgb(206, 205, 255);
            LoginButton.FillColor2 = System.Drawing.Color.FromArgb(206, 205, 255);

            // Меняем текст кнопки подтверждения на "Регистрация"
            AuthorizationButton.Text = "Регистрация";

            // Очищаем поля ввода
            LoginTextBox.Text = null;
            PasswordTextBox.Text = null;
        }

        /// <summary>
        /// Обработчик нажатия основной кнопки авторизации.
        /// Выполняет вход или регистрацию в зависимости от текущего режима.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void AuthorizationButton_Click(object sender, EventArgs e)
        {
            if (isSignIn)
            {
                // ==================== РЕЖИМ ВХОДА ====================
                string username = LoginTextBox.Text;
                string password = PasswordTextBox.Text;
                string password1 = PasswordTextBox1.Text;

                try
                {
                    // Получаем список всех пользователей из базы данных
                    List<users> users = Program.context.users.ToList();

                    // Ищем пользователя с указанным логином и паролем
                    users u = users.FirstOrDefault(p => p.user_login == username && p.password_hash == password);

                    if (u != null)
                    {
                        // ✅ Пользователь найден — открываем главную форму
                        MainForm mainForm = new MainForm(u);
                        mainForm.Owner = this;
                        this.Hide();
                        PasswordTextBox.Clear();
                        mainForm.Show();
                    }
                    else
                    {
                        // ❌ Пользователь не найден или неверный пароль
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
                catch (Exception ex)
                {
                    // Обрабатываем возможные ошибки работы с БД
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                // ==================== РЕЖИМ РЕГИСТРАЦИИ ====================

                try
                {
                    // 1️⃣ ПРОВЕРКА: Есть ли уже пользователь с таким логином?
                    // .Any() возвращает true, если найдена хотя бы одна запись
                    bool userExists = Program.context.users.Any(u => u.user_login == LoginTextBox.Text);

                    if (userExists)
                    {
                        // ❌ Логин занят — не даём зарегистрироваться
                        MessageBox.Show("Пользователь с таким логином уже существует!");
                        return;
                    }

                    // 2️⃣ ПРОВЕРКА: Совпадают ли введённые пароли?
                    if (PasswordTextBox.Text != PasswordTextBox1.Text)
                    {
                        // ❌ Пароли не совпадают — требуем повторного ввода
                        MessageBox.Show("Пароли не совпадают!");
                        return;
                    }

                    // 3️⃣ Создаём нового пользователя, если все проверки пройдены
                    users newUser = new users();
                    newUser.user_login = LoginTextBox.Text;
                    newUser.password_hash = PasswordTextBox.Text;

                    // Добавляем пользователя в контекст и сохраняем изменения в БД
                    Program.context.users.Add(newUser);
                    Program.context.SaveChanges(); // ⚠️ Обязательно сохраняем!

                    // ✅ Регистрация успешна — открываем главную форму
                    MessageBox.Show("Регистрация успешна!");
                    MainForm mainForm = new MainForm(newUser);
                    mainForm.Owner = this;
                    this.Hide();
                    PasswordTextBox.Clear();
                    mainForm.Show();
                }
                catch (Exception ex)
                {
                    // Обрабатываем возможные ошибки (БД, валидация и т.д.)
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Обработчик нажатия иконки в поле ввода пароля.
        /// Переключает видимость символов пароля (показать/скрыть).
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void PasswordTextBox_IconRightClick(object sender, EventArgs e)
        {
            // Инвертируем режим отображения пароля
            PasswordTextBox.UseSystemPasswordChar = isPassVisible;
            isPassVisible = !isPassVisible;
        }

        /// <summary>
        /// Обработчик нажатия кнопки закрытия формы.
        /// Завершает работу приложения.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Обработчик нажатия иконки в поле подтверждения пароля.
        /// Переключает видимость символов пароля (показать/скрыть).
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void PasswordTextBox1_IconRightClick(object sender, EventArgs e)
        {
            // Инвертируем режим отображения пароля во втором поле
            PasswordTextBox1.UseSystemPasswordChar = isPassVisible1;
            isPassVisible1 = !isPassVisible1;
        }
    }
}