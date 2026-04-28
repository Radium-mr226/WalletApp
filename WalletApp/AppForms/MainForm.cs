using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WalletApp.CustomUserControl;
using WalletApp.Models;

namespace WalletApp.AppForms
{
    /// <summary>
    /// Главная форма приложения после авторизации
    /// </summary>
    public partial class MainForm : Form
    {
        // Текущий авторизованный пользователь
        private readonly users _user;

        // Текущий активный бюджетный период пользователя
        private budget_periods _period;

        // Статистика по категориям расходов для текущего периода
        private List<CategoryStat> _categoriesStat;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="user">Авторизованный пользователь</param>
        public MainForm(users user)
        {
            InitializeComponent();
            _user = user;
        }

        /// <summary>
        /// Обработчик закрытия формы: возвращаем пользователя на экран авторизации
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Autorization autorization = this.Owner as Autorization;
            autorization?.Show();
        }

        /// <summary>
        /// Загрузка формы: инициализация данных и заполнение вкладок
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Получаем последний активный бюджетный период пользователя
            _period = Program.context.budget_periods
                .Where(b => b.user_id == _user.user_id)
                .OrderByDescending(b => b.start_date)
                .FirstOrDefault();

            // Устанавливаем даты по умолчанию для создания нового бюджета
            BudgetStartDateTimePicker.Value = DateTime.Today;
            BudgetEndDateTimePicker.Value = DateTime.Today;

            // Заполняем все вкладки формы данными
            FillPages();
        }

        /// <summary>
        /// Координирует заполнение всех вкладок формы в зависимости от наличия активного бюджета
        /// </summary>
        private void FillPages()
        {
            // Всегда заполняем вкладку целей (не зависит от периода)
            FillGoalsPage();

            // Если есть активный бюджетный период
            if (_period != null && _period.end_date >= DateTime.Now)
            {
                // Получаем статистику по категориям для текущего периода
                _categoriesStat = GetCategoriesStatistics();

                // Показываем панели с данными, скрываем предупреждения
                flowLayoutPanel1.Visible = true;
                flowLayoutPanel2.Visible = true;
                flowLayoutPanel3.Visible = true;
                WarningMainLabel.Visible = false;

                // Если период ещё не завершился — заполняем все основные данные
                if (_period.end_date >= DateTime.Today)
                {
                    FillExpenseList();    // Список расходов
                    FillIncomeList();     // Список доходов
                    FillMainPage();       // Главная статистика
                    FillStatisticPage();  // Детальная статистика
                }
            }
            else
            {
                // Если бюджета нет или он истёк — скрываем данные, показываем предупреждения
                flowLayoutPanel1.Visible = false;
                flowLayoutPanel2.Visible = false;
                WarningMainLabel.Visible = true;
                WarningGoalsLabel.Visible = true;
                WarningStatLabel.Visible = true;
            }
        }

        /// <summary>
        /// Заполняет панель списком расходов пользователя
        /// </summary>
        private void FillExpenseList()
        {
            // Получаем все расходы пользователя, сортируем по дате (сначала новые)
            List<transactions> _transactionList = Program.context.transactions
                .Where(p => p.is_income == false && p.user_id == _user.user_id)
                .OrderByDescending(p => p.transaction_date)
                .ToList();

            if (_transactionList.Count != 0)
            {
                ExpensesGradientPanel.Visible = true;

                // Создаём пользовательский контрол для каждой транзакции и добавляем на панель
                foreach (transactions trans in _transactionList)
                {
                    var transaction = new IncomeExpensesUserControl(trans);
                    ExStatfFowLayoutPanel.Controls.Add(transaction);
                }
            }
            else
            {
                // Если расходов нет — скрываем панель
                ExpensesGradientPanel.Visible = false;
            }
        }

        /// <summary>
        /// Заполняет панель списком доходов пользователя
        /// </summary>
        private void FillIncomeList()
        {
            // Получаем все доходы пользователя, сортируем по дате (сначала новые)
            List<transactions> _transactionList = Program.context.transactions
                .Where(p => p.is_income == true && p.user_id == _user.user_id)
                .OrderByDescending(p => p.transaction_date)
                .ToList();

            if (_transactionList.Count != 0)
            {
                IncomesGradientPanel.Visible = true;

                // Создаём пользовательский контрол для каждой транзакции и добавляем на панель
                foreach (transactions trans in _transactionList)
                {
                    var transaction = new IncomeExpensesUserControl(trans);
                    IncomeStatfFowLayoutPanel.Controls.Add(transaction);
                }
            }
            else
            {
                // Если доходов нет — скрываем панель
                IncomesGradientPanel.Visible = false;
            }
        }

        /// <summary>
        /// Обработчик кнопки сохранения нового бюджетного периода
        /// </summary>
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Валидация введённых данных
            if (!ValidateNewBudget())
            {
                return;
            }

            // Создаём и заполняем новый объект бюджетного периода
            _period = new budget_periods
            {
                user_id = _user.user_id,
                start_date = BudgetStartDateTimePicker.Value,
                end_date = BudgetEndDateTimePicker.Value,
                planned_budget = Convert.ToInt32(AddBudgetTextBox.Text)
            };

            // Сохраняем в базу данных и очищаем форму
            Program.context.budget_periods.Add(_period);
            Program.context.SaveChanges();

            AddBudgetTextBox.Text = null;
            BudgetStartDateTimePicker.Value = DateTime.Today;
            BudgetEndDateTimePicker.Value = DateTime.Today;

            // Переключаемся на главную вкладку и обновляем данные
            guna2TabControl1.SelectedTab = MainPage;
            FillPages();
        }

        /// <summary>
        /// Валидация данных при создании нового бюджета
        /// </summary>
        /// <returns>True если данные корректны, иначе false</returns>
        private bool ValidateNewBudget()
        {
            // Проверка: дата начала должна быть раньше даты окончания
            if (BudgetStartDateTimePicker.Value >= BudgetEndDateTimePicker.Value)
            {
                MessageBox.Show("Неверные данные бюджета", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Проверка: сумма бюджета должна быть заполнена
            if (string.IsNullOrWhiteSpace(AddBudgetTextBox.Text) || AddBudgetTextBox.Text.Length <= 1)
            {
                MessageBox.Show("Укажите корректную сумму планируемого бюджета", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Заполняет главную вкладку статистикой за текущий бюджетный период
        /// </summary>
        private void FillMainPage()
        {
            // Получаем все транзакции пользователя в рамках текущего периода
            var transactions = Program.context.transactions
                .Where(t => t.user_id == _period.user_id &&
                            t.transaction_date >= _period.start_date &&
                            t.transaction_date <= _period.end_date)
                .ToList();

            // Отображаем круговую диаграмму расходов по категориям, если есть данные
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

            // Отображаем сумму планируемого бюджета
            BudgetMainLabel.Text = _period != null
                ? $"{_period.planned_budget:N0} ₽"
                : "У вас нет бюджета";

            // Считаем суммы доходов и расходов за период
            var incomes = transactions.Where(t => t.is_income).Sum(t => t.amount);
            var spent = transactions.Where(t => !t.is_income).Sum(t => t.amount);

            PlusMainLabel.Text = $"{incomes:N0} ₽";
            MinusMainLabel.Text = $"{spent:N0} ₽";
            ChartCenterLabel.Text = $"{spent:N0} ₽";

            // Рассчитываем, сколько можно тратить в день до конца периода
            decimal spentForDay = transactions
                .Where(p => p.user_id == _user.user_id && !p.is_income && p.transaction_date == DateTime.Today)
                .Sum(p => (decimal?)p.amount) ?? 0m;

            int inclusiveDays = (int)(_period.end_date.Date - _period.start_date.Date).TotalDays + 1;
            decimal dailyBudget = _period.planned_budget / inclusiveDays;
            decimal leftMoneyForDay = dailyBudget - spentForDay;

            DayLeftMoneyMainLabel.Text = $"{leftMoneyForDay:N2} ₽";
        }

        /// <summary>
        /// Заполняет вкладку статистики: диаграммы и последние транзакции
        /// </summary>
        private void FillStatisticPage()
        {
            // Получаем транзакции за текущий период для диаграммы категорий
            var transactions = Program.context.transactions
                .Where(t => t.user_id == _period.user_id &&
                            t.transaction_date >= _period.start_date &&
                            t.transaction_date <= _period.end_date)
                .ToList();

            // Отображаем диаграмму по категориям, если есть данные
            if (transactions.Count >= 1)
            {
                guna2CustomGradientPanel2.Visible = true;
                _categoriesStat = GetCategoriesStatistics();
                RenderPieChart(_categoriesStat, CategoriesChart, tableLayoutPanelCategoriesStatistics);
            }
            else
            {
                guna2CustomGradientPanel2.Visible = false;
            }

            // Получаем последние 15 транзакций для линейного графика (сортируем по возрастанию для корректного отображения)
            var lastTransactions = Program.context.transactions
                .Where(t => t.user_id == _user.user_id)
                .OrderByDescending(t => t.transaction_date)
                .Take(15)
                .OrderBy(t => t.transaction_date)
                .ToList();

            RenderLastTransactionsChart(lastTransactions, AllTransactionCatChart);
        }

        /// <summary>
        /// Получает статистику расходов по категориям за текущий бюджетный период
        /// </summary>
        /// <returns>Список CategoryStat с данными по каждой категории</returns>
        private List<CategoryStat> GetCategoriesStatistics()
        {
            if (_period == null) return new List<CategoryStat>();

            // LINQ-запрос: группируем расходы по категориям и считаем суммы
            var categoriesStat = (from t in Program.context.transactions
                                  join c in Program.context.categories on t.category_id equals c.category_id
                                  where t.user_id == _user.user_id
                                     && t.transaction_date >= _period.start_date
                                     && t.transaction_date <= _period.end_date
                                     && !t.is_income  // Только расходы
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

        /// <summary>
        /// Заполняет вкладку "Цели" списком накоплений пользователя
        /// </summary>
        private void FillGoalsPage()
        {
            List<savings_goals> savings_Goals = Program.context.savings_goals
                .Where(p => p.user_id == _user.user_id)
                .OrderBy(p => p.name)
                .ToList();

            if (savings_Goals.Count > 0)
            {
                // Создаём контрол для каждой цели и добавляем на панель
                foreach (savings_goals savings in savings_Goals)
                {
                    var saves = new GoalUserControl(savings);
                    flowLayoutPanel3.Controls.Add(saves);
                }
            }
            // Если целей нет — панель остаётся пустой (можно добавить сообщение)
        }

        /// <summary>
        /// Рисует линейный график последних 15 транзакций
        /// </summary>
        /// <param name="transactions">Список транзакций для отображения</param>
        /// <param name="nameChart">Элемент Chart для отрисовки</param>
        void RenderLastTransactionsChart(List<transactions> transactions, Chart nameChart)
        {
            // Очищаем предыдущие данные графика
            nameChart.Series.Clear();
            nameChart.Legends.Clear();
            nameChart.Titles.Clear();

            // Настраиваем серию данных
            var series = nameChart.Series.Add("Transactions");
            series.ChartType = SeriesChartType.Line;
            series.IsValueShownAsLabel = true;
            series.Label = "#VAL{N0} ₽";
            series.Palette = ChartColorPalette.SeaGreen;

            // Настройка осей координат
            nameChart.ChartAreas[0].AxisX.Title = "Дата";
            nameChart.ChartAreas[0].AxisY.Title = "Сумма (₽)";
            nameChart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            nameChart.ChartAreas[0].AxisX.Interval = 1;

            // Добавляем точки на график
            foreach (var t in transactions)
            {
                string xLabel = $"{t.transaction_date:dd.MM}";
                double yValue = (double)t.amount;

                int pointIndex = series.Points.AddXY(xLabel, yValue);
                var dataPoint = series.Points[pointIndex];

                // Цвет точки: красный для расходов, зелёный для доходов
                dataPoint.Color = t.amount < 0 ? Color.IndianRed : Color.MediumSeaGreen;

                // Всплывающая подсказка с детальной информацией
                dataPoint.ToolTip = $"{t.transaction_date:dd.MM.yyyy HH:mm}\n{t.amount:N2} ₽";
            }

            // Заголовок и оформление сетки
            nameChart.Titles.Add("Последние 15 операций").Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            nameChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            nameChart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
        }

        /// <summary>
        /// Рисует круговую диаграмму расходов по категориям и заполняет легенду в TableLayoutPanel
        /// </summary>
        /// <param name="categoriesStatObj">Список статистики по категориям</param>
        /// <param name="ChartName">Элемент Chart для диаграммы</param>
        /// <param name="tableName">TableLayoutPanel для легенды</param>
        void RenderPieChart(object categoriesStatObj, Chart ChartName, TableLayoutPanel tableName)
        {
            // Приводим объект к списку динамических элементов (универсальный подход)
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
            series["DoughnutRadius"] = "70";  // Размер отверстия "пончика"
            series.BorderColor = Color.White;
            series.BorderWidth = 2;
            series.IsValueShownAsLabel = false;  // Значения показываем в легенде
            series.Palette = ChartColorPalette.Pastel;  // Пастельная палитра

            // === НАСТРОЙКА TABLELAYOUTPANEL ДЛЯ ЛЕГЕНДЫ ===
            tableName.Controls.Clear();
            tableName.RowCount = 0;
            tableName.ColumnCount = 4;
            tableName.ColumnStyles.Clear();
            tableName.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20));   // Цвет
            tableName.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));    // Название
            tableName.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));    // Сумма
            tableName.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));    // Количество

            // === ДОБАВЛЕНИЕ ДАННЫХ В ДИАГРАММУ И ЛЕГЕНДУ ===
            for (int i = 0; i < categoriesStat.Count; i++)
            {
                var item = categoriesStat[i];

                // Добавляем сектор в диаграмму
                int pointIndex = series.Points.AddXY(item.CategoryName, (double)item.TotalAmount);

                // Генерируем уникальный пастельный цвет для категории
                Color categoryColor = GeneratePastelColor(i, categoriesStat.Count);
                series.Points[pointIndex].Color = categoryColor;

                // Создаём элементы легенды
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

                // Добавляем элементы в таблицу
                tableName.Controls.Add(lblColor, 0, i);
                tableName.Controls.Add(lblName, 1, i);
                tableName.Controls.Add(lblAmount, 2, i);
                tableName.Controls.Add(lblCount, 3, i);
                tableName.RowCount++;
            }

            // === ФИНАЛЬНОЕ ОФОРМЛЕНИЕ ===
            ChartName.ChartAreas[0].BackColor = Color.Transparent;
            ChartName.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Генерирует уникальный пастельный цвет на основе индекса и общего количества
        /// </summary>
        private Color GeneratePastelColor(int index, int totalCount)
        {
            // Распределяем оттенки по всему цветовому спектру (HSL)
            float hue = (index * 360f) / totalCount;
            float saturation = 0.7f;   // Средняя насыщенность для пастельных тонов
            float lightness = 0.75f;   // Светлота для мягких цветов

            return ColorFromHSL(hue, saturation, lightness);
        }

        /// <summary>
        /// Конвертирует цвет из модели HSL в RGB
        /// </summary>
        private Color ColorFromHSL(float hue, float saturation, float lightness)
        {
            float c = (1 - Math.Abs(2 * lightness - 1)) * saturation;
            float hPrime = hue / 60f;
            float x = c * (1 - Math.Abs((hPrime % 2) - 1));
            float r = 0, g = 0, b = 0;

            // Определяем компоненты RGB в зависимости от сектора цветового круга
            if (hPrime >= 0 && hPrime < 1) { r = c; g = x; b = 0; }
            else if (hPrime >= 1 && hPrime < 2) { r = x; g = c; b = 0; }
            else if (hPrime >= 2 && hPrime < 3) { r = 0; g = c; b = x; }
            else if (hPrime >= 3 && hPrime < 4) { r = 0; g = x; b = c; }
            else if (hPrime >= 4 && hPrime < 5) { r = x; g = 0; b = c; }
            else if (hPrime >= 5 && hPrime < 6) { r = c; g = 0; b = x; }

            float m = lightness - c / 2;
            int red = (int)Math.Round((r + m) * 255);
            int green = (int)Math.Round((g + m) * 255);
            int blue = (int)Math.Round((b + m) * 255);

            // Ограничиваем значения диапазоном 0-255
            return Color.FromArgb(
                Math.Max(0, Math.Min(255, red)),
                Math.Max(0, Math.Min(255, green)),
                Math.Max(0, Math.Min(255, blue))
            );
        }

        /// <summary>
        /// Обновляет список целей на форме (вызывается после добавления/изменения цели)
        /// </summary>
        public void RefreshGoals()
        {
            // Удаляем все существующие контролы целей
            var goals = flowLayoutPanel3.Controls.OfType<GoalUserControl>().ToList();
            foreach (var goal in goals)
            {
                flowLayoutPanel3.Controls.Remove(goal);
                goal.Dispose(); // Освобождение ресурсов
            }
            // Перезаполняем панель актуальными данными
            FillGoalsPage();
        }

        /// <summary>
        /// Обработчик кнопки выхода: закрывает главную форму, возвращая к авторизации
        /// </summary>
        private void LogOutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Обработчик кнопки добавления новой транзакции
        /// </summary>
        private void NewNoteMainLabel_Click(object sender, EventArgs e)
        {
            NewNoteForm newNoteForm = new NewNoteForm(_user);
            newNoteForm.ShowDialog();

            // После добавления транзакции обновляем отображаемые данные
            RenderPieChart(_categoriesStat, MainChartCategories, tableLayoutPanelCategories);
            RenderPieChart(_categoriesStat, CategoriesChart, tableLayoutPanelCategoriesStatistics);
            ExStatfFowLayoutPanel.Controls.Clear();
            FillExpenseList();
            IncomeStatfFowLayoutPanel.Controls.Clear();
            FillIncomeList();
        }

        /// <summary>
        /// Обработчик кнопки добавления новой цели накопления
        /// </summary>
        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            NewGoalForm newGoalForm = new NewGoalForm(_user);
            DialogResult isSaved = newGoalForm.ShowDialog();

            // Если цель успешно сохранена — обновляем список
            if (isSaved == DialogResult.OK)
            {
                RefreshGoals();
            }
        }

        /// <summary>
        /// Обработчик кнопки открытия настроек приложения
        /// </summary>
        private void settingsPictureBox_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(_user);
            settingsForm.ShowDialog();
        }

        /// <summary>
        /// Обработчик ввода в поле суммы бюджета: разрешает только цифры и одну запятую
        /// </summary>
        private void AddBudgetTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод цифр
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                return;

            // Автоматически заменяем точку на запятую (русский формат)
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Обработка запятой: разрешаем только одну и не в начале строки
            if (e.KeyChar == ',')
            {
                if (AddBudgetTextBox.Text.IndexOf(',') != -1 || AddBudgetTextBox.Text.Length == 0)
                {
                    e.Handled = true; // Отменяем ввод
                }
                return;
            }

            // Разрешаем управляющие символы (Backspace, Delete и т.д.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Все остальные символы блокируем
            e.Handled = true;
        }
    }
}