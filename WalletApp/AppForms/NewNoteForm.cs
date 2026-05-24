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
    // Форма для создания новой записи о транзакции
    public partial class NewNoteForm : Form
    {
        private bool categoryType; // Флаг типа категории: false - расход, true - доход
        private users _user; // Текущий пользователь, для которого создаётся транзакция

        // Конструктор формы, принимает объект пользователя
        public NewNoteForm(users users)
        {
            InitializeComponent(); // Инициализация компонентов формы
            _user = users; // Сохранение ссылки на пользователя
        }

        // Обработчик события загрузки формы
        private void NewNoteForm_Load(object sender, EventArgs e)
        {
            // Установка первого элемента в комбобоксе типа категории как выбранного по умолчанию
            CategoryTypeComboBox.SelectedIndex = 0;
        }

        // Обработчик нажатия кнопки "Отмена"
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрытие формы без сохранения
        }

        // Обработчик изменения выбранной категории в первом уровне
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверка что выбран не заглушка (индекс > 0) и что выбранное значение — целое число
            if (CategoryComboBox.SelectedIndex > 0 && CategoryComboBox.SelectedValue is int parentId)
            {
                // Получение подкатегорий из БД, у которых parent_id равен выбранной категории
                var categories = Program.context.categories
                    .Where(c => c.parent_id == parentId)
                    .ToList();

                // Если подкатегории найдены
                if (categories.Count > 0)
                {
                    // Отображение элементов интерфейса для выбора подкатегории
                    UnderCategoty_Label.Visible = true;
                    label6.Visible = true;
                    guna2PictureBox5.Visible = true;
                    CategoryComboBox1.Visible = true;

                    // Добавление заглушки в начало списка
                    categories.Insert(0, new categories { category_id = 0, name = "--Выберите категорию--" });

                    // Привязка списка подкатегорий к комбобоксу
                    CategoryComboBox1.DataSource = categories;
                    CategoryComboBox1.DisplayMember = "name"; // Отображаемое поле
                    CategoryComboBox1.ValueMember = "category_id"; // Значение, которое возвращается
                    CategoryComboBox1.SelectedIndex = 0; // Выбор заглушки по умолчанию
                }
            }
            else
            {
                // Если выбрана заглушка — список подкатегорий очищаем и скрываем элементы управления!
                CategoryComboBox1.DataSource = null;
                CategoryComboBox1.Visible = false;
                UnderCategoty_Label.Visible = false;
                label6.Visible = false;
                guna2PictureBox5.Visible = false;
            }
        }

        // Обработчик изменения выбранной подкатегории во втором уровне
        private void CategoryComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверка что выбран не заглушка и что выбранное значение — целое число
            if (CategoryComboBox1.SelectedIndex > 0 && CategoryComboBox1.SelectedValue is int parentId)
            {
                // Получение подкатегорий третьего уровня из БД
                var categories = Program.context.categories
                    .Where(c => c.parent_id == parentId)
                    .ToList();

                // Если категории третьего уровня найдены
                if (categories.Count > 0)
                {
                    // Отображение элементов интерфейса для выбора категории третьего уровня
                    CategoryComboBox2.Visible = true;
                    CategotyType_Label.Visible = true;
                    label7.Visible = true;
                    guna2PictureBox6.Visible = true;

                    // Добавление заглушки в начало списка
                    categories.Insert(0, new categories { category_id = 0, name = "--Выберите категорию--" });

                    // Привязка списка к комбобоксу (создаётся новая копия списка)
                    CategoryComboBox2.DataSource = new List<categories>(categories);
                    CategoryComboBox2.DisplayMember = "name";
                    CategoryComboBox2.ValueMember = "category_id";
                    CategoryComboBox2.SelectedIndex = 0;
                }
            }
            else
            {
                // Если выбрана заглушка — список подкатегорий очищаем и скрываем элементы управления!
                CategoryComboBox2.DataSource = null;
                CategoryComboBox2.Visible = false;
                CategotyType_Label.Visible = false;
                label7.Visible = false;
                guna2PictureBox6.Visible = false;
            }
        }

        // Обработчик нажатия клавиш в поле ввода суммы
        private void AmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                return;

            // Заменяем точку на запятую (для десятичного разделителя в русской локали)
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Обработка запятой: разрешаем только одну и не в начале пустой строки
            if (e.KeyChar == ',')
            {
                if (AmountTextBox.Text.IndexOf(',') != -1 || AmountTextBox.Text.Length == 0)
                {
                    e.Handled = true; // Отменяем ввод
                }
                return;
            }

            // Разрешаем управляющие символы (например, Backspace, Delete, стрелки)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Любые другие символы — отменяем ввод
            e.Handled = true;
        }

        // Обработчик изменения типа категории (Доход/Расход)
        private void CategoryTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Если выбран не элемент-заглушка
            if (CategoryTypeComboBox.SelectedIndex > 0)
            {
                // Определение типа транзакции на основе выбранного индекса
                if (CategoryTypeComboBox.SelectedIndex == 1)
                    categoryType = false; // Расход
                else if (CategoryTypeComboBox.SelectedIndex == 2)
                    categoryType = true; // Доход
                else categoryType = false; // По умолчанию - расход

                // Получение корневых категорий из БД, фильтруя по типу (доход/расход)
                var categories = Program.context.categories
                    .Where(c => c.parent_id == null && c.is_income == categoryType)
                    .ToList();

                // Если категории найдены
                if (categories.Count > 0)
                {
                    // Отображение элементов интерфейса для выбора категории
                    Category_Label.Visible = true;
                    label3.Visible = true;
                    guna2PictureBox4.Visible = true;
                    CategoryComboBox.Visible = true;

                    // Добавление заглушки в начало списка
                    categories.Insert(0, new categories { category_id = 0, name = "--Выберите категорию--" });

                    // Привязка списка категорий к комбобоксу
                    CategoryComboBox.DataSource = new List<categories>(categories);
                    CategoryComboBox.DisplayMember = "name";
                    CategoryComboBox.ValueMember = "category_id";
                    CategoryComboBox.SelectedIndex = 0;
                }
            }
            else
            {
                // Если выбрана заглушка — список категорий очищаем и скрываем элементы управления!
                CategoryComboBox.DataSource = null;
                CategoryComboBox.Visible = false;
                Category_Label.Visible = false;
                label3.Visible = false;
                guna2PictureBox4.Visible = false;
            }
        }

        // Обработчик нажатия кнопки "Сохранить"
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // Валидация полей формы перед сохранением
            if (ValidateFields())
            {
                // Создание нового объекта транзакции
                transactions transaction = new transactions();
                transaction.user_id = _user.user_id; // Привязка к текущему пользователю

                // Определение категории: если выбран третий уровень — используем его, иначе второй
                if (CategoryComboBox2.SelectedIndex > 0)
                    transaction.category_id = (int)CategoryComboBox2.SelectedValue;
                else transaction.category_id = (int)CategoryComboBox1.SelectedValue;

                // Установка суммы: для расходов добавляем знак минус
                if (categoryType == false)
                    transaction.amount = Convert.ToDecimal("-" + AmountTextBox.Text);
                else transaction.amount = Convert.ToDecimal(AmountTextBox.Text);

                // Установка даты транзакции и типа (доход/расход)
                transaction.transaction_date = DateTime.Now;
                transaction.is_income = categoryType;

                // Уведомление пользователя об успешном сохранении
                MessageBox.Show("Транзакция сохранена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Добавление транзакции в контекст БД и сохранение изменений
                Program.context.transactions.Add(transaction);
                Program.context.SaveChanges();

                this.Close(); // Закрытие формы после сохранения
            }
        }

        // Метод валидации полей формы
        private bool ValidateFields()
        {
            // Проверка: поле суммы не должно быть пустым
            if (AmountTextBox.Text.Length <= 0)
            {
                MessageBox.Show("Введите сумму бюджета", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Проверка: выбран ли тип транзакции
            else if (CategoryTypeComboBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Выберите тип транзакции", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Проверка: выбрана ли категория первого уровня
            else if (CategoryComboBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Выберите категрию", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Проверка: выбрана ли подкатегория (второй уровень)
            else if (CategoryComboBox1.SelectedIndex <= 0)
            {
                MessageBox.Show("Выберите подкатегрию", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Все проверки пройдены
            return true;
        }
    }
}
