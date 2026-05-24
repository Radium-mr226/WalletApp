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
    /// Форма настроек пользователя: редактирование логина, пароля и управление категориями
    /// </summary>
    public partial class SettingsForm : Form
    {
        private users _user;              // Текущий пользователь, данные которого редактируются
        private bool isPassVisible = false; // Флаг видимости пароля в поле ввода

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="users">Объект пользователя для редактирования</param>
        public SettingsForm(users users)
        {
            InitializeComponent();
            _user = users;
        }

        /// <summary>
        /// Переключение видимости пароля при клике на иконку в TextBox
        /// </summary>
        private void guna2TextBox1_IconRightClick(object sender, EventArgs e)
        {
            // Инвертируем режим отображения: если был скрыт — показываем, и наоборот
            PasswordTextBox.UseSystemPasswordChar = isPassVisible;
            isPassVisible = !isPassVisible;
        }

        /// <summary>
        /// Закрытие формы без сохранения изменений
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Сохранение изменений пользователя после валидации
        /// </summary>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // Сохраняем данные только если все поля прошли проверку
            if (ValidateFields())
            {
                _user.user_login = LoginTextBox.Text;
                _user.password_hash = PasswordTextBox.Text; // ⚠️ Внимание: в реальном проекте пароль нужно хешировать!
            }
        }

        /// <summary>
        /// Валидация полей формы перед сохранением
        /// </summary>
        /// <returns>True, если все поля корректны; иначе False</returns>
        private bool ValidateFields()
        {
            // Проверка длины логина (минимум 3 символа)
            if (LoginTextBox.Text.Length <= 2)
            {
                MessageBox.Show("Логин должен быть больше 2 символов", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Проверка длины пароля (минимум 8 символов)
            if (PasswordTextBox.Text.Length <= 7)
            {
                MessageBox.Show("Пароль должен быть не менее 8 символов", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Открытие формы создания новой категории расходов/доходов
        /// </summary>
        private void NewCategoryGradientButton_Click(object sender, EventArgs e)
        {
            // Передаём текущего пользователя в форму категории для связи данных
            NewCategoryForm newCategoryForm = new NewCategoryForm(_user);
            newCategoryForm.ShowDialog(); // Модальное окно
        }

        /// <summary>
        /// Инициализация формы при загрузке: настройка UI и заполнение данными пользователя
        /// </summary>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Скрываем пароль при старте
            PasswordTextBox.UseSystemPasswordChar = true;

            // Заполняем поля текущими данными пользователя
            LoginTextBox.Text = _user.user_login;
            PasswordTextBox.Text = _user.password_hash;
        }
    }
}
