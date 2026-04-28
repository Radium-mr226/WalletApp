using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
        private budget_periods _period;
        private List<CategoryStat> _categoriesStat;
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
            _period = Program.context.budget_periods.Where(b => b.user_id == _user.user_id)
                            .OrderByDescending(b => b.start_date)
                            .FirstOrDefault();
            BudgetStartDateTimePicker.Value = DateTime.Today;
            BudgetEndDateTimePicker.Value = DateTime.Today;
            FillPages();
            
        }

        private void FillPages()
        {


            FillGoalsPage();
            if (_period != null && _period.end_date >= DateTime.Now)
            {
                _categoriesStat = GetCategoriesStatistics();

                flowLayoutPanel1.Visible = true;
                flowLayoutPanel2.Visible = true;
                flowLayoutPanel3.Visible = true;
                WarningMainLabel.Visible = false;
                if (_period.end_date >= DateTime.Today)
                {
                    FillExpenseList();
                    FillIncomeList();
                    FillMainPage();
                    FillStatisticPage();
                }
                List<savings_goals> savings_Goals = Program.context.savings_goals.Where(p => p.user_id == _user.user_id).OrderBy(p => p.name).ToList();
                
            }
            else
            {
                flowLayoutPanel1.Visible = false;
                flowLayoutPanel2.Visible = false;
                //flowLayoutPanel3.Visible = false;
                WarningMainLabel.Visible = true;
                WarningGoalsLabel.Visible = true;
                WarningStatLabel.Visible = true;
            }
        }

        private void FillExpenseList()
        {
            List<transactions> _transactionList = Program.context.transactions.Where(p => p.is_income == false && p.user_id == _user.user_id).OrderByDescending(p => p.transaction_date).ToList();
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
            List<transactions> _transactionList = Program.context.transactions.Where(p => p.is_income == true && p.user_id == _user.user_id).OrderByDescending(p => p.transaction_date).ToList();
            if (_transactionList.Count != 0)
            {
                IncomesGradientPanel.Visible = true;
                foreach (transactions trans in _transactionList)
                {
                    var transaction = new IncomeExpensesUserControl(trans);
                    IncomeStatfFowLayoutPanel.Controls.Add(transaction);
                }
            }
            else if (_transactionList.Count <= 0)
            {
                IncomesGradientPanel.Visible = false;
            }
        }

        

        // Сохранине нового бюджета
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!ValidateNewBudget())
            {
                return;
            }
            _period = new budget_periods();
            _period.user_id = _user.user_id;
            _period.start_date = BudgetStartDateTimePicker.Value;
            _period.end_date = BudgetEndDateTimePicker.Value;
            if (transferToGoalTextBox == null) 
            {
                _period.planned_budget = Convert.ToInt32(AddBudgetTextBox.Text) - Convert.ToInt32(transferToGoalTextBox.Text);
            }
            else
                _period.planned_budget = Convert.ToInt32(AddBudgetTextBox.Text);
            AddBudgetTextBox.Text = null;
            transferToGoalTextBox.Text = null;
            BudgetStartDateTimePicker.Value = DateTime.Today;
            BudgetEndDateTimePicker.Value = DateTime.Today;

            Program.context.budget_periods.Add(_period);
            Program.context.SaveChanges();
            guna2TabControl1.SelectedTab = MainPage;
            FillPages();
        }

        private bool ValidateNewBudget()
        {
            if (BudgetStartDateTimePicker.Value >= BudgetEndDateTimePicker.Value)
            {
                MessageBox.Show("Неверные данные бюджета", "Ошбика ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(AddBudgetTextBox.Text.Length <=1)
            {
                MessageBox.Show("Укажите корректную сумму планируемого бюджета", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void FillMainPage()
        {
            var transactions = Program.context.transactions
                .Where(t => t.user_id == _period.user_id &&
                            t.transaction_date >= _period.start_date &&
                            t.transaction_date <= _period.end_date)
                .ToList();
            //заполнение статистики по категриям на главной форме
            if (transactions.Count >= 1)
            {
                ChartSpentsMainPanel.Visible = true;
                guna2CustomGradientPanel8.Visible = true;
                _categoriesStat = GetCategoriesStatistics();

                RenderPieChart(_categoriesStat, MainChartCategories, tableLayoutPanelCategories);
            }
            else 
            { 
                ChartSpentsMainPanel.Visible = false;
                guna2CustomGradientPanel8.Visible = false;
            }

            if (_period != null)
            {
                BudgetMainLabel.Text =  $"{_period.planned_budget.ToString():N0} ₽";
            }
            else
            {
                BudgetMainLabel.Text = "У вас нет бюджета";
            }

            // 3. Считаем доходы и расходы
            var incomes = transactions
                .Where(t => t.is_income)
                .Sum(t => t.amount).ToString();
            var spent = transactions
                .Where(t => !t.is_income)
                .Sum(t => t.amount).ToString();
            var spentCategoryChart = transactions
                .Where(t => !t.is_income)
                .Sum(t => t.amount).ToString();

            PlusMainLabel.Text = $"{incomes:N0} ₽";

            MinusMainLabel.Text = $"{spent:N0} ₽";
            ChartCenterLabel.Text = $"{spentCategoryChart:N0} ₽";

            decimal spentForDay = transactions
                    .Where(p => p.user_id == _user.user_id
                     && !p.is_income
                     && p.transaction_date == DateTime.Today)
                    .Sum(p => (decimal?)p.amount) ?? 0m;
            int inclusiveDays = (int)(_period.end_date.Date - _period.start_date.Date).TotalDays + 1;
            decimal leftMoneyForDay = (decimal)(_period.planned_budget / (_period.end_date - _period.start_date).Days - spentForDay);

            DayLeftMoneyMainLabel.Text = $"{leftMoneyForDay.ToString("N2")} ₽";
        }

        private void FillStatisticPage()
        {
            var transactions = Program.context.transactions
                .Where(t => t.user_id == _period.user_id &&
                            t.transaction_date >= _period.start_date &&
                            t.transaction_date <= _period.end_date)
                .ToList();
            //заполнение статистики по категриям на главной форме
            if (transactions.Count >= 1)
            {
                guna2CustomGradientPanel2.Visible = true;

                _categoriesStat = GetCategoriesStatistics();
                RenderPieChart(_categoriesStat, CategoriesChart, tableLayoutPanelCategoriesStatistics);
            }
            else guna2CustomGradientPanel2.Visible = false;

            var lastTransactions = Program.context.transactions
                .Where(t => t.user_id == _user.user_id)
                .OrderByDescending(t => t.transaction_date) // Сначала новые
                .Take(15)
                .ToList()
                .OrderBy(t => t.transaction_date) // 🔥 Разворот: старые → новые слева направо
                .ToList();
            RenderLastTransactionsChart(lastTransactions, AllTransactionCatChart);
        }

        // получаем все транзакции по категориям
        private List<CategoryStat> GetCategoriesStatistics()
        {
            if (_period == null) return new List<CategoryStat>();

            var categoriesStat = (from t in Program.context.transactions
                                  join c in Program.context.categories
                                      on t.category_id equals c.category_id
                                  where t.user_id == _user.user_id
                                     && t.transaction_date >= _period.start_date
                                     && t.transaction_date <= _period.end_date
                                  group t by new { c.category_id, c.name } into g
                                  select new CategoryStat
                                  {
                                      CategoryId = g.Key.category_id,
                                      CategoryName = g.Key.name,
                                      TotalAmount = g.Sum(x => (decimal?)x.amount) ?? 0m,
                                      TransactionCount = g.Count()
                                  })
                 .OrderBy(x => x.CategoryName)
                 .ToList();

            return categoriesStat;
        }


        private void FillGoalsPage()
        {
            List<savings_goals> savings_Goals = Program.context.savings_goals.Where(p => p.user_id == _user.user_id).OrderBy(p => p.name).ToList();
            if (savings_Goals.Count > 0)
            {
                foreach (savings_goals savings in savings_Goals)
                {
                    var saves = new GoalUserControl(savings);
                    flowLayoutPanel3.Controls.Add(saves);
                }
                    guna2CustomGradientPanel9.Visible = true;
            }
            else
            {
                guna2CustomGradientPanel9.Visible = false;
            }
            
        }

        
        // генерация последних 15 транзакций в Статистике
        void RenderLastTransactionsChart(List<transactions> transactions, Chart nameChart)
        {
            nameChart.Series.Clear();
            nameChart.Legends.Clear();
            nameChart.Titles.Clear();

            var series = nameChart.Series.Add("Transactions");
            series.ChartType = SeriesChartType.Line;
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
        void RenderPieChart(object categoriesStatObj, Chart ChartName, TableLayoutPanel tableName)
        {
            var categoriesStat = ((System.Collections.IEnumerable)categoriesStatObj)
                .Cast<object>()
                .Select(item => (dynamic)item)
                .ToList();

            // === НАСТРОЙКА ДИАГРАММЫ ===
            ChartName.Series.Clear();
            ChartName.Legends.Clear();
            ChartName.Titles.Clear();

            var series = ChartName.Series.Add("Categories");
            series.ChartType = SeriesChartType.Doughnut;
            series["DoughnutRadius"] = "70";
            series.BorderColor = Color.White;
            series.BorderWidth = 2;
            series.IsValueShownAsLabel = false;
            series.Palette = ChartColorPalette.Pastel;

            // === НАСТРОЙКА TABLELAYOUTPANEL ===
            tableName.Controls.Clear();
            tableName.RowCount = 0;

            tableName.ColumnCount = 4;
            tableName.ColumnStyles.Clear();
            tableName.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20));
            tableName.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableName.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableName.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

            // === ДОБАВЛЕНИЕ ДАННЫХ ===
            for (int i = 0; i < categoriesStat.Count; i++)
            {
                var item = categoriesStat[i];

                // ✅ Добавляем точку в диаграмму
                int pointIndex = series.Points.AddXY(item.CategoryName, (double)item.TotalAmount);

                // ✅ Генерируем уникальный пастельный цвет для каждой категории
                Color categoryColor = GeneratePastelColor(i, categoriesStat.Count);
                series.Points[pointIndex].Color = categoryColor;

                var lblColor = new PictureBox
                {
                    AutoSize = false,
                    Size = new Size(16, 16),
                    BackColor = categoryColor,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5, 2, 5, 2)
                };

                var lblName = new Label
                {
                    Text = item.CategoryName.ToString(),
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 9.5f),
                    Margin = new Padding(2)
                };

                var lblAmount = new Label
                {
                    Text = $"{item.TotalAmount:N0} ₽",
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    Margin = new Padding(2)
                };

                var lblCount = new Label
                {
                    Text = $"({item.TransactionCount} шт.)",
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 9f),
                    Margin = new Padding(2)
                };

                tableName.Controls.Add(lblColor, 0, i);
                tableName.Controls.Add(lblName, 1, i);
                tableName.Controls.Add(lblAmount, 2, i);
                tableName.Controls.Add(lblCount, 3, i);

                tableName.RowCount++;
            }

            // === ФИНАЛЬНАЯ НАСТРОЙКА ===
            ChartName.ChartAreas[0].BackColor = Color.Transparent;
            ChartName.BackColor = Color.Transparent;
        }

        // ✅ Метод для генерации уникальных пастельных цветов
        private Color GeneratePastelColor(int index, int totalCount)
        {
            // Используем HSL (Hue, Saturation, Lightness) для создания пастельных цветов
            float hue = (index * 360f) / totalCount; // Распределяем по всему спектру
            float saturation = 0.7f; // Пастельные цвета имеют среднюю насыщенность
            float lightness = 0.75f; // Пастельные цвета светлые

            return ColorFromHSL(hue, saturation, lightness);
        }

        // ✅ Конвертация HSL в RGB
        private Color ColorFromHSL(float hue, float saturation, float lightness)
        {
            float c = (1 - Math.Abs(2 * lightness - 1)) * saturation;
            float hPrime = hue / 60f;
            float x = c * (1 - Math.Abs((hPrime % 2) - 1));
            float r = 0, g = 0, b = 0;

            if (hPrime >= 0 && hPrime < 1)
            {
                r = c; g = x; b = 0;
            }
            else if (hPrime >= 1 && hPrime < 2)
            {
                r = x; g = c; b = 0;
            }
            else if (hPrime >= 2 && hPrime < 3)
            {
                r = 0; g = c; b = x;
            }
            else if (hPrime >= 3 && hPrime < 4)
            {
                r = 0; g = x; b = c;
            }
            else if (hPrime >= 4 && hPrime < 5)
            {
                r = x; g = 0; b = c;
            }
            else if (hPrime >= 5 && hPrime < 6)
            {
                r = c; g = 0; b = x;
            }

            float m = lightness - c / 2;
            int red = (int)Math.Round((r + m) * 255);
            int green = (int)Math.Round((g + m) * 255);
            int blue = (int)Math.Round((b + m) * 255);

            return Color.FromArgb(
                Math.Max(0, Math.Min(255, red)),
                Math.Max(0, Math.Min(255, green)),
                Math.Max(0, Math.Min(255, blue))
            );
        }
        public void RefreshGoals()
        {

            var goals = flowLayoutPanel3.Controls.OfType<GoalUserControl>().ToList();
            foreach (var goal in goals)
            {
                flowLayoutPanel3.Controls.Remove(goal);
                goal.Dispose(); // Освобождение ресурсов
            }
            FillGoalsPage();

        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewNoteMainLabel_Click(object sender, EventArgs e)
        {
            NewNoteForm newNoteForm = new NewNoteForm(_user);
            newNoteForm.ShowDialog();
            RenderPieChart(_categoriesStat, MainChartCategories, tableLayoutPanelCategories);
            RenderPieChart(_categoriesStat, CategoriesChart, tableLayoutPanelCategoriesStatistics);

            ExStatfFowLayoutPanel.Controls.Clear();
            FillExpenseList();
            IncomeStatfFowLayoutPanel.Controls.Clear();
            FillIncomeList();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            NewGoalForm newGoalForm = new NewGoalForm(_user);
            DialogResult isSaved = newGoalForm.ShowDialog();
            if (isSaved == DialogResult.OK)
            {
                var goals = flowLayoutPanel3.Controls.OfType<GoalUserControl>().ToList();
                foreach (var goal in goals)
                {
                    flowLayoutPanel3.Controls.Remove(goal);
                    goal.Dispose(); // Освобождение ресурсов
                }
                FillGoalsPage();
            }
        }

        private void settingsPictureBox_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(_user);
            settingsForm.ShowDialog();
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

    }

}
