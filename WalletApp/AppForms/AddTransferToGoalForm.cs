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
    /// Форма добавления перевода в цель накоплений.
    /// </summary>
    public partial class AddTransferToGoalForm : Form
    {
        // Поле для хранения целевой записи, в которую будет сделан перевод
        private savings_goals _savings_goals;

        /// <summary>
        /// Конструктор формы. Инициализирует компоненты и сохраняет ссылку на цель накоплений.
        /// </summary>
        /// <param name="savings_goals">Объект цели накоплений, в которую будет добавлен перевод</param>
        public AddTransferToGoalForm(savings_goals savings_goals)
        {
            InitializeComponent();
            _savings_goals = savings_goals;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Отмена". Закрывает форму без сохранения изменений.
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить".
        /// Валидирует ввод, создаёт запись перевода и сохраняет её в БД.
        /// </summary>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // Проверяем корректность введённых данных
            if (ValidateFields())
            {
                // Создаём новый объект перевода
                savings_transfers savings_Transfers = new savings_transfers();

                // Заполняем свойства перевода
                savings_Transfers.transfer_date = DateTime.Now;  // Текущая дата и время
                savings_Transfers.amount = Convert.ToDecimal(AmountTextBox.Text);  // Сумма из TextBox
                savings_Transfers.goal_id = _savings_goals.goal_id;  // ID целевой записи

                // Добавляем запись в контекст EF и сохраняем изменения в БД
                Program.context.savings_transfers.Add(savings_Transfers);
                Program.context.SaveChanges();

                // Показываем уведомление об успехе и закрываем форму
                DialogResult = MessageBox.Show(
                    "Данные сохранены",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
        }

        /// <summary>
        /// Валидирует поля формы перед сохранением.
        /// </summary>
        /// <returns>True, если все поля заполнены корректно; иначе False</returns>
        private bool ValidateFields()
        {
            // ⚠️ Примечание: текущая проверка Length <= 1 не позволяет ввести сумму "1", "2" и т.д.
            // Рекомендуется заменить на проверку: string.IsNullOrWhiteSpace() + decimal.TryParse()

            if (AmountTextBox.Text.Length <= 1)
            {
                MessageBox.Show(
                    "Укажите, какую сумму вы хотите отложить",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Обработчик нажатия клавиш в поле ввода суммы.
        /// Ограничивает ввод только цифрами, запятой (десятичный разделитель) и управляющими символами.
        /// </summary>
        private void AmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ✅ Разрешаем ввод цифр 0-9
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                return;

            // 🔄 Автоматически заменяем точку на запятую (локаль РФ)
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // 🔢 Обработка запятой: разрешаем только одну и не в начале строки
            if (e.KeyChar == ',')
            {
                // Если запятая уже есть ИЛИ поле пустое — отменяем ввод
                if (AmountTextBox.Text.IndexOf(',') != -1 || AmountTextBox.Text.Length == 0)
                {
                    e.Handled = true; // Блокируем ввод символа
                }
                return;
            }

            // ⌨️ Разрешаем управляющие символы (Backspace, Delete, Ctrl+C и т.д.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // ❌ Все остальные символы (буквы, спецсимволы) — блокируем
            e.Handled = true;
        }

        /// <summary>
        /// Обработчик загрузки формы.
        /// Здесь можно добавить инициализацию данных, настройку UI и т.д.
        /// </summary>
        private void AddTransferToGoalForm_Load(object sender, EventArgs e)
        {
            // 🔹 Место для дополнительной инициализации при загрузке формы
            // Например: установка фокуса, загрузка данных, настройка форматирования
        }
    }
}
