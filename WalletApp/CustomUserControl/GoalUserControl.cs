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
    public partial class GoalUserControl : UserControl
    {
        savings_goals _saving_Goals;

        public GoalUserControl(savings_goals savings_Goals)
        {
            InitializeComponent();
            _saving_Goals = savings_Goals;
        }

        private void GoalUserControl_Load(object sender, EventArgs e)
        {
            GoalNameLabel.Text = _saving_Goals.name;
            decimal currentAmount = Program.context.savings_transfers
                .Where(p => p.goal_id == _saving_Goals.goal_id)
                .Sum(p => (decimal?)p.amount) ?? 0m;

            HaveNeedGoalLabel.Text = $"Имеется: {currentAmount:N0} ₽   Всего необходимо: {_saving_Goals.target_amount:N2} ₽";
            decimal percentage = _saving_Goals.target_amount > 0
            ? (currentAmount / _saving_Goals.target_amount) * 100m
            : 0m;

            // 2. Округляем и ограничиваем диапазон [0; 100]
            int progressValue = (int)Math.Round(Math.Max(0m, Math.Min(100m, percentage)));
            // 💡 Если у вас .NET Framework (< 5.0), замените Math.Clamp на:
            // int progressValue = (int)Math.Round(Math.Max(0m, Math.Min(100m, percentage)));

            // 3. Настраиваем Guna2ProgressBar
            AmountProgressBar.Minimum = 0;
            AmountProgressBar.Maximum = 100;
            AmountProgressBar.Value = progressValue;
            AmountProgressBar.ShowText = true;                     // Включаем отображение текста
            GoalDescriptionLabel.Text = _saving_Goals.description;
        }

        private void FillButton1_Click(object sender, EventArgs e)
        {
            AddTransferToGoalForm transferToGoalForm = new AddTransferToGoalForm(_saving_Goals);
            DialogResult isSaved = transferToGoalForm.ShowDialog();
            if (isSaved == DialogResult.OK)
            {
                MainForm mainForm = this.FindForm() as MainForm;
                if (mainForm != null)
                {
                    mainForm.RefreshGoals();
                }
            }
        }
    }
}
