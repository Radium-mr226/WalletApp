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

            HaveNeedGoalLabel.Text = $"{currentAmount}\n{_saving_Goals.target_amount}";
            GoalDescriptionLabel.Text = _saving_Goals.description;
        }
    }
}
