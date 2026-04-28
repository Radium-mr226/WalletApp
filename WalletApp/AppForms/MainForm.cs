using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WalletApp.CustomUserControl;
using WalletApp.Models;

namespace WalletApp.AppForms
{
    public partial class MainForm : Form
    {
        users _user;
        public MainForm(users user)
        {
            InitializeComponent();
            _user = user;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Autorization autorization = this.Owner as Autorization;
            autorization.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BudgetEndDateTimePicker.MinDate = DateTime.Now;
            BudgetStartDateTimePicker.MinDate = DateTime.Now;
            // 1. Очищаем старые данные
            chart1.Series.Clear();

            // 2. Создаем серию данных
            Series series = new Series("Expenses");
            series.ChartType = SeriesChartType.Doughnut;
            series["DoughnutRadius"] = "70";
            series.BorderColor = Color.FromArgb(50, 50, 50);
            series.BorderWidth = 10;
            series.Label = "#PERCENT{P0}";

            // 3. Добавляем данные
            series.Points.AddXY("Еда", 3000);
            series.Points.AddXY("Транспорт", 1500);
            series.Points.AddXY("Жилье", 10000);
            series.Points.AddXY("Развлечения", 2000);

            // 4. Добавляем серию на диаграмму
            chart1.Series.Add(series);

            // 5. Убираем лишнее
            chart1.Legends.Clear();
            chart1.ChartAreas[0].BackColor = Color.Transparent;
            chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;

            // 6. Текст в центре (через Label поверх графика)
            ChartCenterLabel.Text = "16 500 ₽";
            ChartCenterLabel.BringToFront();

            FillExpenseList();
            FillIncomeList();
            FillMainPage();

        }
        private void FillExpenseList()
        {
            List<transactions> _transactionList = Program.context.transactions.Where(p => p.is_income == false && p.user_id == _user.user_id).OrderBy(p => p.transaction_date).ToList();
            if (_transactionList.Count != 0)
            {
                ExpensesGradientPanel.Visible = true;
                foreach (transactions trans in _transactionList)
                {
                    var transaction = new IncomeExpensesUserControl(trans);
                    ExStatfFowLayoutPanel.Controls.Add(transaction);
                }
            }
            else if (_transactionList.Count == 0)
            {
               ExpensesGradientPanel.Visible = false;


            }
        }

        private void FillIncomeList()
        {
            List<transactions> _transactionList = Program.context.transactions.Where(p => p.is_income == true && p.user_id == _user.user_id).OrderBy(p => p.transaction_date).ToList();
            if (_transactionList.Count != 0)
            {
                foreach (transactions trans in _transactionList)
                {
                    var transaction = new IncomeExpensesUserControl(trans);
                    IncomeStatfFowLayoutPanel.Controls.Add(transaction);
                }
            }
            else if (_transactionList.Count == 0)
            {
                IncomeStatfFowLayoutPanel.Visible = false;
            }
        }

        private void AddBudgetTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                if (AddBudgetTextBox.Text.IndexOf(',') != -1 || AddBudgetTextBox.Text.Length == 0)
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

        private void guna2CustomGradientPanel4_Click(object sender, EventArgs e)
        {
             // новая форма для копилки

        }

        private void transferToGoalTextBox1_KeyPress(object sender, KeyPressEventArgs e)
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
                if (AddBudgetTextBox.Text.IndexOf(',') != -1 || AddBudgetTextBox.Text.Length == 0)
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

        // Сохранине нового бюджета
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!ValidateNewBudget())
            {
                return;
            }
            budget_periods budget_Periods = new budget_periods();
            budget_Periods.user_id = _user.user_id;
            budget_Periods.start_date = BudgetStartDateTimePicker.Value;
            budget_Periods.end_date = BudgetEndDateTimePicker.Value;
            budget_Periods.planned_budget = Convert.ToInt32(AddBudgetTextBox.Text) - Convert.ToInt32(transferToGoalTextBox.Text);
            Program.context.budget_periods.Add(budget_Periods);
        }

        private bool ValidateNewBudget()
        {
            if (BudgetStartDateTimePicker.Value == BudgetEndDateTimePicker.Value)
            {
                MessageBox.Show("", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void FillMainPage()
        {
            var period = Program.context.budget_periods.Where(b => b.user_id == _user.user_id)
                .OrderByDescending(b => b.start_date)
                .FirstOrDefault();
            if (period != null)
            {
                BudgetMainLabel.Text = period.planned_budget.ToString();
            }
            else
            {
                BudgetMainLabel.Text = "У вас нет бюджета";
                
            }
            
            

            
            var transactions = Program.context.transactions
                .Where(t => t.user_id == period.user_id &&
                            t.transaction_date >= period.start_date &&
                            t.transaction_date <= period.end_date)
                .ToList();

            // 3. Считаем доходы и расходы
            PlusMainLabel.Text = transactions
                .Where(t => t.is_income)
                .Sum(t => t.amount).ToString();

            MinusMainLabel.Text = transactions
                .Where(t => !t.is_income)
                .Sum(t => t.amount).ToString();
            decimal spentForDay = Program.context.transactions
                    .Where(p => p.user_id == _user.user_id
                     && !p.is_income
                     && p.transaction_date == DateTime.Today)
                    .Sum(p => (decimal?)p.amount) ?? 0m;
            int inclusiveDays = (int)(period.end_date.Date - period.start_date.Date).TotalDays + 1;
            decimal leftMoneyForDay = (decimal)(period.planned_budget / (period.end_date - period.start_date).Days - spentForDay);


            DayLeftMoneyMainLabel.Text = "На этот день у вас осталось " + leftMoneyForDay.ToString("N2");


        }
    }
}
