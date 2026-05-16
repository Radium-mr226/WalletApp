namespace WalletApp.AppForms
{
    partial class NewNoteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label amountLabel;
            System.Windows.Forms.Label is_incomeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewNoteForm));
            this.courseProjectDataSet = new WalletApp.CourseProjectDataSet();
            this.transactionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionsTableAdapter = new WalletApp.CourseProjectDataSetTableAdapters.transactionsTableAdapter();
            this.tableAdapterManager = new WalletApp.CourseProjectDataSetTableAdapters.TableAdapterManager();
            this.ButtonSave = new Guna.UI2.WinForms.Guna2Button();
            this.CategoryTypeComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.AmountTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.CategoryComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.CategoryComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.CategoryComboBox2 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.CancelButton = new Guna.UI2.WinForms.Guna2Button();
            this.category_idLabel = new System.Windows.Forms.Label();
            this.category_idLabel1 = new System.Windows.Forms.Label();
            this.category_idLabel2 = new System.Windows.Forms.Label();
            amountLabel = new System.Windows.Forms.Label();
            is_incomeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.courseProjectDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // amountLabel
            // 
            amountLabel.AutoSize = true;
            amountLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            amountLabel.Location = new System.Drawing.Point(31, 48);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new System.Drawing.Size(134, 46);
            amountLabel.TabIndex = 7;
            amountLabel.Text = "Сумма:";
            // 
            // is_incomeLabel
            // 
            is_incomeLabel.AutoSize = true;
            is_incomeLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            is_incomeLabel.Location = new System.Drawing.Point(31, 131);
            is_incomeLabel.Name = "is_incomeLabel";
            is_incomeLabel.Size = new System.Drawing.Size(249, 46);
            is_incomeLabel.TabIndex = 11;
            is_incomeLabel.Text = "Выберите тип:";
            // 
            // courseProjectDataSet
            // 
            this.courseProjectDataSet.DataSetName = "CourseProjectDataSet";
            this.courseProjectDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // transactionsBindingSource
            // 
            this.transactionsBindingSource.DataMember = "transactions";
            this.transactionsBindingSource.DataSource = this.courseProjectDataSet;
            // 
            // transactionsTableAdapter
            // 
            this.transactionsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.budget_periodsTableAdapter = null;
            this.tableAdapterManager.categoriesTableAdapter = null;
            this.tableAdapterManager.savings_goalsTableAdapter = null;
            this.tableAdapterManager.savings_transfersTableAdapter = null;
            this.tableAdapterManager.transactionsTableAdapter = this.transactionsTableAdapter;
            this.tableAdapterManager.UpdateOrder = WalletApp.CourseProjectDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.usersTableAdapter = null;
            // 
            // ButtonSave
            // 
            this.ButtonSave.BackColor = System.Drawing.Color.Transparent;
            this.ButtonSave.BorderRadius = 15;
            this.ButtonSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ButtonSave.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.ButtonSave.ForeColor = System.Drawing.Color.White;
            this.ButtonSave.Location = new System.Drawing.Point(455, 522);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(373, 73);
            this.ButtonSave.TabIndex = 13;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // CategoryTypeComboBox
            // 
            this.CategoryTypeComboBox.BackColor = System.Drawing.Color.Transparent;
            this.CategoryTypeComboBox.BorderRadius = 15;
            this.CategoryTypeComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CategoryTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryTypeComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CategoryTypeComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CategoryTypeComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.CategoryTypeComboBox.ForeColor = System.Drawing.Color.Black;
            this.CategoryTypeComboBox.ItemHeight = 30;
            this.CategoryTypeComboBox.Items.AddRange(new object[] {
            "--Выберите тип категории--",
            "Трата",
            "Доход"});
            this.CategoryTypeComboBox.Location = new System.Drawing.Point(455, 141);
            this.CategoryTypeComboBox.Name = "CategoryTypeComboBox";
            this.CategoryTypeComboBox.Size = new System.Drawing.Size(383, 36);
            this.CategoryTypeComboBox.TabIndex = 16;
            this.CategoryTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryTypeComboBox_SelectedIndexChanged);
            // 
            // AmountTextBox
            // 
            this.AmountTextBox.BorderRadius = 15;
            this.AmountTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AmountTextBox.DefaultText = "";
            this.AmountTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.AmountTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.AmountTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.AmountTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.AmountTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.AmountTextBox.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.AmountTextBox.ForeColor = System.Drawing.Color.Black;
            this.AmountTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.AmountTextBox.Location = new System.Drawing.Point(455, 24);
            this.AmountTextBox.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.PlaceholderText = "";
            this.AmountTextBox.SelectedText = "";
            this.AmountTextBox.Size = new System.Drawing.Size(383, 70);
            this.AmountTextBox.TabIndex = 17;
            this.AmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmountTextBox_KeyPress);
            // 
            // CategoryComboBox1
            // 
            this.CategoryComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.CategoryComboBox1.BorderRadius = 15;
            this.CategoryComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CategoryComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CategoryComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CategoryComboBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CategoryComboBox1.ForeColor = System.Drawing.Color.Black;
            this.CategoryComboBox1.ItemHeight = 30;
            this.CategoryComboBox1.Location = new System.Drawing.Point(455, 307);
            this.CategoryComboBox1.Name = "CategoryComboBox1";
            this.CategoryComboBox1.Size = new System.Drawing.Size(383, 36);
            this.CategoryComboBox1.TabIndex = 18;
            this.CategoryComboBox1.Visible = false;
            this.CategoryComboBox1.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox1_SelectedIndexChanged);
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.BackColor = System.Drawing.Color.Transparent;
            this.CategoryComboBox.BorderRadius = 15;
            this.CategoryComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CategoryComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CategoryComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CategoryComboBox.ForeColor = System.Drawing.Color.Black;
            this.CategoryComboBox.ItemHeight = 30;
            this.CategoryComboBox.Location = new System.Drawing.Point(455, 224);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(383, 36);
            this.CategoryComboBox.TabIndex = 19;
            this.CategoryComboBox.Visible = false;
            this.CategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            // 
            // CategoryComboBox2
            // 
            this.CategoryComboBox2.BackColor = System.Drawing.Color.Transparent;
            this.CategoryComboBox2.BorderRadius = 15;
            this.CategoryComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CategoryComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryComboBox2.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CategoryComboBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CategoryComboBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CategoryComboBox2.ForeColor = System.Drawing.Color.Black;
            this.CategoryComboBox2.ItemHeight = 30;
            this.CategoryComboBox2.Location = new System.Drawing.Point(455, 390);
            this.CategoryComboBox2.Name = "CategoryComboBox2";
            this.CategoryComboBox2.Size = new System.Drawing.Size(383, 36);
            this.CategoryComboBox2.TabIndex = 20;
            this.CategoryComboBox2.Visible = false;
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelButton.BorderRadius = 15;
            this.CancelButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CancelButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CancelButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CancelButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CancelButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.CancelButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.CancelButton.ForeColor = System.Drawing.Color.White;
            this.CancelButton.Location = new System.Drawing.Point(39, 522);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(373, 73);
            this.CancelButton.TabIndex = 21;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // category_idLabel
            // 
            this.category_idLabel.AutoSize = true;
            this.category_idLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.category_idLabel.Location = new System.Drawing.Point(31, 214);
            this.category_idLabel.Name = "category_idLabel";
            this.category_idLabel.Size = new System.Drawing.Size(344, 46);
            this.category_idLabel.TabIndex = 22;
            this.category_idLabel.Text = "Выберите категрию:";
            this.category_idLabel.Visible = false;
            // 
            // category_idLabel1
            // 
            this.category_idLabel1.AutoSize = true;
            this.category_idLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.category_idLabel1.Location = new System.Drawing.Point(31, 297);
            this.category_idLabel1.Name = "category_idLabel1";
            this.category_idLabel1.Size = new System.Drawing.Size(404, 46);
            this.category_idLabel1.TabIndex = 23;
            this.category_idLabel1.Text = "Выберите подкатегрию:";
            this.category_idLabel1.Visible = false;
            // 
            // category_idLabel2
            // 
            this.category_idLabel2.AutoSize = true;
            this.category_idLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.category_idLabel2.Location = new System.Drawing.Point(31, 380);
            this.category_idLabel2.Name = "category_idLabel2";
            this.category_idLabel2.Size = new System.Drawing.Size(413, 92);
            this.category_idLabel2.TabIndex = 24;
            this.category_idLabel2.Text = "Выберите подкатегрию: \r\n(необязательно)";
            this.category_idLabel2.Visible = false;
            // 
            // NewNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(893, 635);
            this.Controls.Add(this.category_idLabel2);
            this.Controls.Add(this.category_idLabel1);
            this.Controls.Add(this.category_idLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CategoryComboBox2);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.CategoryComboBox1);
            this.Controls.Add(this.AmountTextBox);
            this.Controls.Add(this.CategoryTypeComboBox);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(amountLabel);
            this.Controls.Add(is_incomeLabel);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewNoteForm";
            this.Text = "Добавить транзакцию";
            this.Load += new System.EventHandler(this.NewNoteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.courseProjectDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CourseProjectDataSet courseProjectDataSet;
        private System.Windows.Forms.BindingSource transactionsBindingSource;
        private CourseProjectDataSetTableAdapters.transactionsTableAdapter transactionsTableAdapter;
        private CourseProjectDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private Guna.UI2.WinForms.Guna2Button ButtonSave;
        private Guna.UI2.WinForms.Guna2ComboBox CategoryTypeComboBox;
        private Guna.UI2.WinForms.Guna2TextBox AmountTextBox;
        private Guna.UI2.WinForms.Guna2ComboBox CategoryComboBox1;
        private Guna.UI2.WinForms.Guna2ComboBox CategoryComboBox;
        private Guna.UI2.WinForms.Guna2ComboBox CategoryComboBox2;
        private Guna.UI2.WinForms.Guna2Button CancelButton;
        private System.Windows.Forms.Label category_idLabel;
        private System.Windows.Forms.Label category_idLabel1;
        private System.Windows.Forms.Label category_idLabel2;
    }
}