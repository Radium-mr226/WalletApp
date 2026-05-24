using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WalletApp.AppForms;
using WalletApp.Models;

namespace WalletApp.CustomUserControl
{
    /// <summary>
    /// Пользовательский элемент управления для отображения карточки цели накоплений
    /// </summary>
    public partial class GoalUserControl : UserControl
    {
        // Хранит данные о конкретной цели накоплений, переданной извне
        private savings_goals _saving_Goals;

        /// <summary>
        /// Конструктор контрола
        /// </summary>
        /// <param name="savings_Goals">Объект цели, данные которой будут отображены</param>
        public GoalUserControl(savings_goals savings_Goals)
        {
            InitializeComponent();
            _saving_Goals = savings_Goals;
        }

        /// <summary>
        /// Обработчик загрузки контрола: инициализация отображаемых данных
        /// </summary>
        private void GoalUserControl_Load(object sender, EventArgs e)
        {
            // 1. Отображаем название цели
            GoalNameLabel.Text = _saving_Goals.name;

            // 2. Рассчитываем текущую накопленную сумму:
            //    - Берём все транзакции, привязанные к этой цели (по goal_id)
            //    - Суммируем их amounts
            //    - Если транзакций нет — возвращаем 0 (оператор ??)
            decimal currentAmount = Program.context.savings_transfers
                .Where(p => p.goal_id == _saving_Goals.goal_id)
                .Sum(p => (decimal?)p.amount) ?? 0m;

            // 3. Формируем текст с текущей и целевой суммой в рублях
            HaveNeedGoalLabel.Text = $"Имеется: {currentAmount:N0} ₽   Всего необходимо: {_saving_Goals.target_amount:N2} ₽";

            // 4. Вычисляем процент выполнения цели
            //    Защита от деления на ноль: если target_amount = 0, прогресс = 0%
            decimal percentage = _saving_Goals.target_amount > 0
                ? (currentAmount / _saving_Goals.target_amount) * 100m
                : 0m;

            // 5. Округляем процент до целого числа и ограничиваем диапазон [0; 100]
            //    (на случай, если пользователь накопил больше цели)
            int progressValue = (int)Math.Round(Math.Max(0m, Math.Min(100m, percentage)));

            // 6. Настраиваем визуальный индикатор прогресса
            AmountProgressBar.Minimum = 0;
            AmountProgressBar.Maximum = 100;
            AmountProgressBar.Value = progressValue;
            AmountProgressBar.ShowText = true; // Показываем процент внутри полосы прогресса

            // 7. Отображаем описание цели (если есть)
            GoalDescriptionLabel.Text = _saving_Goals.description;
        }

        /// <summary>
        /// Обработчик кнопки "Пополнить": открывает форму добавления транзакции к цели
        /// </summary>
        private void FillButton1_Click(object sender, EventArgs e)
        {
            // Создаём и показываем модальное окно для внесения средств в цель
            AddTransferToGoalForm transferToGoalForm = new AddTransferToGoalForm(_saving_Goals);
            DialogResult isSaved = transferToGoalForm.ShowDialog();

            // Если пользователь успешно добавил транзакцию (нажал ОК) —
            // обновляем список целей на главной форме, чтобы отобразить актуальные данные
            if (isSaved == DialogResult.OK)
            {
                // Ищем родительскую форму и вызываем метод обновления
                MainForm mainForm = this.FindForm() as MainForm;
                if (mainForm != null)
                {
                    mainForm.RefreshGoals();
                }
            }
        }
    }
}
