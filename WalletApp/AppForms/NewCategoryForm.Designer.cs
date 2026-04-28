namespace WalletApp.AppForms
{
    partial class NewCategoryForm
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
            System.Windows.Forms.Label is_incomeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCategoryForm));
            this.category_idLabel2 = new System.Windows.Forms.Label();
            this.category_idLabel1 = new System.Windows.Forms.Label();
            this.category_idLabel = new System.Windows.Forms.Label();
            this.CancelButton = new Guna.UI2.WinForms.Guna2Button();
            this.CategoryComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.CategoryComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ButtonSave = new Guna.UI2.WinForms.Guna2Button();
            this.CategoryNameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.CategoryTypeComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            is_incomeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // category_idLabel2
            // 
            this.category_idLabel2.AutoSize = true;
            this.category_idLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.category_idLabel2.Location = new System.Drawing.Point(31, 261);
            this.category_idLabel2.Name = "category_idLabel2";
            this.category_idLabel2.Size = new System.Drawing.Size(406, 46);
            this.category_idLabel2.TabIndex = 32;
            this.category_idLabel2.Text = "Назовите подкатегрию: ";
            this.category_idLabel2.Visible = false;
            // 
            // category_idLabel1
            // 
            this.category_idLabel1.AutoSize = true;
            this.category_idLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.category_idLabel1.Location = new System.Drawing.Point(31, 176);
            this.category_idLabel1.Name = "category_idLabel1";
            this.category_idLabel1.Size = new System.Drawing.Size(404, 46);
            this.category_idLabel1.TabIndex = 31;
            this.category_idLabel1.Text = "Выберите подкатегрию:";
            this.category_idLabel1.Visible = false;
            // 
            // category_idLabel
            // 
            this.category_idLabel.AutoSize = true;
            this.category_idLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.category_idLabel.Location = new System.Drawing.Point(31, 101);
            this.category_idLabel.Name = "category_idLabel";
            this.category_idLabel.Size = new System.Drawing.Size(344, 46);
            this.category_idLabel.TabIndex = 30;
            this.category_idLabel.Text = "Выберите категрию:";
            this.category_idLabel.Visible = false;
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
            this.CancelButton.Location = new System.Drawing.Point(39, 399);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(373, 73);
            this.CancelButton.TabIndex = 29;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
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
            this.CategoryComboBox.Location = new System.Drawing.Point(461, 106);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(383, 36);
            this.CategoryComboBox.TabIndex = 27;
            this.CategoryComboBox.Visible = false;
            this.CategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
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
            this.CategoryComboBox1.Location = new System.Drawing.Point(461, 181);
            this.CategoryComboBox1.Name = "CategoryComboBox1";
            this.CategoryComboBox1.Size = new System.Drawing.Size(383, 36);
            this.CategoryComboBox1.TabIndex = 26;
            this.CategoryComboBox1.Visible = false;
            this.CategoryComboBox1.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox1_SelectedIndexChanged_1);
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
            this.ButtonSave.Location = new System.Drawing.Point(455, 399);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(373, 73);
            this.ButtonSave.TabIndex = 25;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // CategoryNameTextBox
            // 
            this.CategoryNameTextBox.BorderRadius = 15;
            this.CategoryNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CategoryNameTextBox.DefaultText = "";
            this.CategoryNameTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.CategoryNameTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.CategoryNameTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CategoryNameTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CategoryNameTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CategoryNameTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CategoryNameTextBox.ForeColor = System.Drawing.Color.Black;
            this.CategoryNameTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CategoryNameTextBox.Location = new System.Drawing.Point(461, 256);
            this.CategoryNameTextBox.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.CategoryNameTextBox.Name = "CategoryNameTextBox";
            this.CategoryNameTextBox.PlaceholderText = "";
            this.CategoryNameTextBox.SelectedText = "";
            this.CategoryNameTextBox.Size = new System.Drawing.Size(383, 57);
            this.CategoryNameTextBox.TabIndex = 33;
            this.CategoryNameTextBox.Visible = false;
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
            this.CategoryTypeComboBox.Location = new System.Drawing.Point(461, 31);
            this.CategoryTypeComboBox.Name = "CategoryTypeComboBox";
            this.CategoryTypeComboBox.Size = new System.Drawing.Size(383, 36);
            this.CategoryTypeComboBox.TabIndex = 35;
            this.CategoryTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryTypeComboBox_SelectedIndexChanged);
            // 
            // is_incomeLabel
            // 
            is_incomeLabel.AutoSize = true;
            is_incomeLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            is_incomeLabel.Location = new System.Drawing.Point(31, 26);
            is_incomeLabel.Name = "is_incomeLabel";
            is_incomeLabel.Size = new System.Drawing.Size(249, 46);
            is_incomeLabel.TabIndex = 34;
            is_incomeLabel.Text = "Выберите тип:";
            // 
            // NewCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 498);
            this.Controls.Add(this.CategoryTypeComboBox);
            this.Controls.Add(is_incomeLabel);
            this.Controls.Add(this.CategoryNameTextBox);
            this.Controls.Add(this.category_idLabel2);
            this.Controls.Add(this.category_idLabel1);
            this.Controls.Add(this.category_idLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.CategoryComboBox1);
            this.Controls.Add(this.ButtonSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewCategoryForm";
            this.Text = "Добавить категорию";
            this.Load += new System.EventHandler(this.NewCategoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label category_idLabel2;
        private System.Windows.Forms.Label category_idLabel1;
        private System.Windows.Forms.Label category_idLabel;
        private Guna.UI2.WinForms.Guna2Button CancelButton;
        private Guna.UI2.WinForms.Guna2ComboBox CategoryComboBox;
        private Guna.UI2.WinForms.Guna2ComboBox CategoryComboBox1;
        private Guna.UI2.WinForms.Guna2Button ButtonSave;
        private Guna.UI2.WinForms.Guna2TextBox CategoryNameTextBox;
        private Guna.UI2.WinForms.Guna2ComboBox CategoryTypeComboBox;
    }
}