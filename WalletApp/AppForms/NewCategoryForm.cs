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
    /// Форма создания новой категории расходов/доходов.
    /// Позволяет пользователю выбрать тип категории (доход/расход), 
    /// родительскую категорию, подкатегорию и указать имя новой категории.
    /// </summary>
    public partial class NewCategoryForm : Form
    {
        /// <summary>
        /// Флаг типа категории: true = доход, false = расход.
        /// </summary>
        private bool categoryType;

        /// <summary>
        /// Текущий авторизованный пользователь.
        /// </summary>
        private users _user;

        /// <summary>
        /// Инициализирует новый экземпляр формы создания категории.
        /// </summary>
        /// <param name="user">Объект пользователя, для которого создаётся категория.</param>
        public NewCategoryForm(users user)
        {
            InitializeComponent();
            _user = user;
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
        /// Событие загрузки формы.
        /// Здесь можно добавить инициализацию элементов управления при необходимости.
        /// </summary>
        private void NewCategoryForm_Load(object sender, EventArgs e)
        {
            // Инициализация при загрузке формы (пока пусто)
        }

        /// <summary>
        /// Обработчик изменения выбранной родительской категории.
        /// Если выбрана валидная категория — загружает и отображает список её подкатегорий.
        /// Если выбрана заглушка ("--Выберите категорию--") — скрывает элементы выбора подкатегории.
        /// </summary>
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем, что выбран реальный элемент (не заглушка с индексом 0)
            // и что выбранное значение можно привести к int (ID категории)
            if (CategoryComboBox.SelectedIndex > 0 && CategoryComboBox.SelectedValue is int parentId)
            {
                // Запрашиваем из БД все подкатегории для выбранного родителя
                var categories = Program.context.categories
                    .Where(c => c.parent_id == parentId)
                    .ToList();

                // Если подкатегории существуют — показываем второй комбобокс
                if (categories.Count > 0)
                {
                    this.category_idLabel1.Visible = true;
                    CategoryComboBox1.Visible = true;

                    // Добавляем заглушку в начало списка для удобства выбора
                    categories.Insert(0, new categories { category_id = 0, name = "--Выберите категорию--" });

                    // Привязываем данные к комбобоксу подкатегорий
                    CategoryComboBox1.DataSource = categories;
                    CategoryComboBox1.DisplayMember = "name";  // Что показывать пользователю
                    CategoryComboBox1.ValueMember = "category_id"; // Что хранить как значение
                    CategoryComboBox1.SelectedIndex = 0; // Выбираем заглушку по умолчанию
                }
            }
            else
            {
                // Если выбрана заглушка или ничего не выбрано — скрываем элементы подкатегории
                CategoryComboBox1.DataSource = null;
                CategoryComboBox1.Visible = false;
                category_idLabel1.Visible = false;
            }
        }

        /// <summary>
        /// Обработчик изменения типа категории (доход/расход).
        /// Фильтрует список корневых категорий в соответствии с выбранным типом.
        /// </summary>
        private void CategoryTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обрабатываем выбор типа: 1 = расход (false), 2 = доход (true)
            if (CategoryTypeComboBox.SelectedIndex > 0)
            {
                categoryType = CategoryTypeComboBox.SelectedIndex == 2;

                // Загружаем только корневые категории (parent_id == null) нужного типа
                var categories = Program.context.categories
                    .Where(c => c.parent_id == null && c.is_income == categoryType)
                    .ToList();

                // Если категории найдены — показываем комбобокс выбора
                if (categories.Count > 0)
                {
                    this.category_idLabel.Visible = true;
                    CategoryComboBox.Visible = true;

                    // Добавляем заглушку в начало списка
                    categories.Insert(0, new categories { category_id = 0, name = "--Выберите категорию--" });

                    // Важно: создаём новый список, чтобы не модифицировать исходную коллекцию
                    CategoryComboBox.DataSource = new List<categories>(categories);
                    CategoryComboBox.DisplayMember = "name";
                    CategoryComboBox.ValueMember = "category_id";
                    CategoryComboBox.SelectedIndex = 0;
                }
            }
            else
            {
                // Сбрасываем элементы выбора, если тип не определён
                CategoryComboBox.DataSource = null;
                CategoryComboBox.Visible = false;
                category_idLabel.Visible = false;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить".
        /// Валидирует ввод и сохраняет новую категорию в базу данных.
        /// </summary>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // Валидация: имя категории должно быть не короче 3 символов
            if (CategoryNameTextBox.Text.Length >= 3)
            {
                // Создаём новый объект категории
                categories newCategory = new categories
                {
                    // Устанавливаем ID родительской категории (может быть 0, если подкатегория не выбрана)
                    parent_id = CategoryComboBox1.SelectedValue is int selectedId ? selectedId : (int?)null,
                    user_id = _user.user_id,           // Привязываем к текущему пользователю
                    name = CategoryNameTextBox.Text,    // Имя из текстового поля
                    is_income = categoryType            // Тип категории (доход/расход)
                };

                // Добавляем в контекст EF и сохраняем изменения в БД
                Program.context.categories.Add(newCategory);
                Program.context.SaveChanges();

                // Уведомляем пользователя об успехе
                MessageBox.Show("Категория создана", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Закрываем форму
            }
            else
            {
                // Опционально: можно добавить сообщение об ошибке валидации
                MessageBox.Show("Имя категории должно содержать не менее 3 символов",
                    "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Обработчик изменения выбранной подкатегории.
        /// Показывает поле ввода имени новой категории только когда выбрана валидная подкатегория.
        /// </summary>
        private void CategoryComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Проверяем, что выбрана реальная подкатегория (не заглушка)
            if (CategoryComboBox1.SelectedIndex > 0 && CategoryComboBox1.SelectedValue is int)
            {
                // Показываем поле для ввода имени новой категории
                CategoryNameTextBox.Visible = true;
                category_idLabel2.Visible = true;
            }
            else
            {
                // Скрываем поле ввода, если подкатегория не выбрана
                CategoryNameTextBox.Visible = false;
                category_idLabel2.Visible = false;
            }
        }
    }
}
