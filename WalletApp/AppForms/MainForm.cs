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
using System.Web.UI.WebControls.WebParts;
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
            

            var period = Program.context.budget_periods.Where(b => b.user_id == _user.user_id)
                .OrderByDescending(b => b.start_date)
                .FirstOrDefault();

            if (period != null)
            {
                if (period.end_date >= DateTime.Today)
                {
                    FillExpenseList();
                    FillIncomeList();
                    FillMainPage();
                    FillGoalsPage();
                }
            }
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
            if (transferToGoalTextBox == null) 
            {
                budget_Periods.planned_budget = Convert.ToInt32(AddBudgetTextBox.Text) - Convert.ToInt32(transferToGoalTextBox.Text);
            }
            else 
                budget_Periods.planned_budget = Convert.ToInt32(AddBudgetTextBox.Text);

            Program.context.budget_periods.Add(budget_Periods);
            Program.context.SaveChanges();
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
            //заполнение статистики по категриям на главной форме
            var categoriesStat = (from t in Program.context.transactions
                                  join c in Program.context.categories
                                      on t.category_id equals c.category_id // 🔍 Проверьте имена полей!
                                  where t.user_id == _user.user_id
                                     && t.transaction_date >= period.start_date
                                     && t.transaction_date <= period.end_date
                                  group t by new { c.category_id, c.name } into g
                                  select new
                                  {
                                      CategoryId = g.Key.category_id,
                                      CategoryName = g.Key.name,
                                      TotalAmount = g.Sum(x => (decimal?)x.amount) ?? 0m,
                                      TransactionCount = g.Count()
                                  })
                     .OrderBy(x => x.CategoryName)
                     .ToList();
            foreach (var item in categoriesStat)
            {
                var labelCat = new Label
                {
                    Text = $"{item.CategoryName}: {item.TotalAmount:N2} ₽ ({item.TransactionCount} шт.)",
                    AutoSize = true,
                    Margin = new Padding(5),
                    Font = new Font("Segoe UI", 9.5f),
                    Tag = item.CategoryId // Полезно: сохраняем ID в теге для будущих кликов
                };

                // Добавляем именно контрол, а не его свойство!
                flowLayoutPanelMainCat.Controls.Add(labelCat);
            }
            RenderPieChart(categoriesStat, MainChartCategories);


            if (period != null)
            {
                BudgetMainLabel.Text = "Бюджет \n\n" + period.planned_budget.ToString();
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
            PlusMainLabel.Text = "Доходы \n\n" + transactions
                .Where(t => t.is_income)
                .Sum(t => t.amount).ToString();

            MinusMainLabel.Text = "Расходы \n\n" + transactions
                .Where(t => !t.is_income)
                .Sum(t => t.amount).ToString();
            ChartCenterLabel.Text = transactions
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

        private void FillGoalsPage()
        {
            var period = Program.context.budget_periods.Where(b => b.user_id == _user.user_id)
                .OrderByDescending(b => b.start_date)
                .FirstOrDefault();

            List<savings_goals> savings_Goals = Program.context.savings_goals.Where(p => p.user_id == _user.user_id).OrderBy(p => p.name).ToList();
            if (savings_Goals.Count != 0)
            {
                ExpensesGradientPanel.Visible = true;
                foreach (savings_goals savings in savings_Goals)
                {
                    var saves = new GoalUserControl(savings);
                    flowLayoutPanel3.Controls.Add(saves);
                }
            }

            

            var categoriesStat = (from t in Program.context.transactions
                                  join c in Program.context.categories
                                      on t.category_id equals c.category_id // 🔍 Проверьте имена полей!
                                  where t.user_id == _user.user_id
                                     && t.transaction_date >= period.start_date
                                     && t.transaction_date <= period.end_date
                                  group t by new { c.category_id, c.name } into g
                                  select new
                                  {
                                      CategoryId = g.Key.category_id,
                                      CategoryName = g.Key.name,
                                      TotalAmount = g.Sum(x => (decimal?)x.amount) ?? 0m,
                                      TransactionCount = g.Count()
                                  })
                     .OrderBy(x => x.CategoryName)
                     .ToList();
            foreach (var item in categoriesStat) 
            {
                var labelCat = new Label
                {
                    Text = $"{item.CategoryName}: {item.TotalAmount:N2} ₽ ({item.TransactionCount} шт.)",
                    AutoSize = true,
                    Margin = new Padding(5),
                    Font = new Font("Segoe UI", 9.5f),
                    Tag = item.CategoryId // Полезно: сохраняем ID в теге для будущих кликов
                };

                // Добавляем именно контрол, а не его свойство!
                CategotyFlowLayoutPanel.Controls.Add(labelCat);
            }
            RenderPieChart(categoriesStat, CategoriesChart);
            var lastTransactions = Program.context.transactions
                .Where(t => t.user_id == _user.user_id)
                .OrderByDescending(t => t.transaction_date) // Сначала новые
                .Take(15)
                .ToList()
                .OrderBy(t => t.transaction_date) // 🔥 Разворот: старые → новые слева направо
                .ToList();
            RenderLastTransactionsChart(lastTransactions, AllTransactionCatChart);
        }

        

        void RenderLastTransactionsChart(List<transactions> transactions, Chart nameChart)
        {
            nameChart.Series.Clear();
            nameChart.Legends.Clear();
            nameChart.Titles.Clear();

            var series = nameChart.Series.Add("Transactions");
            series.ChartType = SeriesChartType.Doughnut;
            series.IsValueShownAsLabel = true;
            series.Label = "#VAL{N0} ₽";
            series.Palette = ChartColorPalette.SeaGreen;

            // Настройка осей
            nameChart.ChartAreas[0].AxisX.Title = "Дата";
            nameChart.ChartAreas[0].AxisY.Title = "Сумма (₽)";
            nameChart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            nameChart.ChartAreas[0].AxisX.Interval = 1;

            // 🔥 Добавляем точки
            foreach (var t in transactions)
            {
                string xLabel = $"{t.transaction_date:dd.MM}";
                double yValue = (double)t.amount;

                // 🔥 FIX: AddXY возвращает индекс (int), получаем точку через него
                int pointIndex = series.Points.AddXY(xLabel, yValue);
                var dataPoint = series.Points[pointIndex]; // ← Теперь это DataPoint

                // Цвет по типу транзакции
                if (t.amount < 0)
                    dataPoint.Color = Color.IndianRed;
                else
                    dataPoint.Color = Color.MediumSeaGreen;

                // Tooltip
                dataPoint.ToolTip = $"{t.transaction_date:dd.MM.yyyy HH:mm}\n{t.amount:N2} ₽";
            }

            // Заголовок и сетка
            nameChart.Titles.Add("Последние 15 операций")
                .Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            nameChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            nameChart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
        }

        //статистика по категориям
        void RenderPieChart(object categoriesStatObj, Chart ChartName)
        {
            // Приводим к IEnumerable<dynamic> для работы с свойствами через динамический доступ
            var categoriesStat = ((System.Collections.IEnumerable)categoriesStatObj)
                .Cast<object>()
                .Select(item => (dynamic)item)
                .ToList();

            ChartName.Series.Clear();
            ChartName.Legends.Clear();
            ChartName.Titles.Clear();

            var series = ChartName.Series.Add("Categories");
            series.ChartType = SeriesChartType.Doughnut;
            series["DoughnutRadius"] = "70";
            series.BorderColor = Color.FromArgb(50, 50, 50);
            series.BorderWidth = 3;
            series.IsValueShownAsLabel = true;
            series.Label = "#PERCENT{P1}\n#VAL{N0} ₽";
            series.LegendText = "#AXISLABEL";
            series.Palette = ChartColorPalette.Pastel;

            ChartName.ChartAreas[0].BackColor = Color.Transparent;
            ChartName.BackColor = Color.Transparent;
            if (ChartName.Legends.Count > 0)
                ChartName.Legends[0].BackColor = Color.Transparent;

            // добаление точек
            foreach (var item in categoriesStat)
            {
                series.Points.AddXY(item.CategoryName, (double)item.TotalAmount);
            }

        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewNoteMainLabel_Click(object sender, EventArgs e)
        {
            NewNoteForm newNoteForm = new NewNoteForm(_user);
            newNoteForm.ShowDialog();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            NewGoalForm newGoalForm = new NewGoalForm(_user);
            newGoalForm.ShowDialog();
        }
    }

}
