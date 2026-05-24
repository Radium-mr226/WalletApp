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
    /// Форма для создания новой финансовой цели пользователя.
    /// Позволяет ввести название цели и целевую сумму, после чего сохраняет данные в базу.
    /// </summary>
    public partial class NewGoalForm : Form
    {
        /// <summary>
        /// Текущий авторизованный пользователь, для которого создаётся цель.
        /// </summary>
        private users _user;

        /// <summary>
        /// Инициализирует новый экземпляр формы <see cref="NewGoalForm"/>.
        /// </summary>
        /// <param name="user">Объект пользователя, связываемый с новой целью.</param>
        public NewGoalForm(users user)
        {
            InitializeComponent();
            _user = user;
        }

        /// <summary>
        /// Обработчик события загрузки формы.
        /// Здесь можно добавить инициализацию элементов управления при необходимости.
        /// </summary>
        private void NewGoalForm_Load(object sender, EventArgs e)
        {
            // При необходимости: настройка элементов управления при загрузке
            // Example: AmountTextBox.Focus();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Отмена".
        /// Закрывает форму без сохранения изменений.
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Обработчик нажатия клавиш в поле ввода суммы.
        /// Фильтрует ввод: разрешает только цифры, одну запятую как десятичный разделитель,
        /// а также управляющие символы (Backspace, Delete и т.д.).
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события нажатия клавиши.</param>
        private void AmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод цифр 0–9
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                return;

            // Автоматически заменяем точку на запятую (стандартный десятичный разделитель в РФ)
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Обработка запятой: разрешаем только одну и не в начале пустой строки
            if (e.KeyChar == ',')
            {
                // Если запятая уже есть или поле пустое — отменяем ввод
                if (AmountTextBox.Text.IndexOf(',') != -1 || AmountTextBox.Text.Length == 0)
                {
                    e.Handled = true;
                }
                return;
            }

            // Разрешаем управляющие символы (Backspace, Delete, стрелки и т.п.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Все остальные символы (буквы, спецсимволы) — блокируем
            e.Handled = true;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить".
        /// Выполняет валидацию ввода, создаёт объект цели и сохраняет его в базу данных.
        /// </summary>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // Валидация: название от 2 символов, сумма — не пустая
            if (NameTextBox.Text.Length >= 2 && AmountTextBox.Text.Length >= 1)
            {
                // Создаём новую запись цели накоплений
                savings_goals savings_Goals = new savings_goals
                {
                    user_id = _user.user_id,                    // Привязываем к текущему пользователю
                    name = NameTextBox.Text,                    // Название цели из TextBox
                    target_amount = Convert.ToDecimal(AmountTextBox.Text) // Сумма цели (преобразование строки в decimal)
                };

                // Добавляем запись в контекст Entity Framework и сохраняем изменения в БД
                Program.context.savings_goals.Add(savings_Goals);
                Program.context.SaveChanges();

                // Уведомление пользователя об успехе
                MessageBox.Show(
                    "Новая цель сохранена",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Возвращаем результат диалога и закрываем форму
                DialogResult = DialogResult.OK;
                this.Close();
            }
            // При необходимости можно добавить else-блок с сообщением об ошибке валидации
        }
    }
}
