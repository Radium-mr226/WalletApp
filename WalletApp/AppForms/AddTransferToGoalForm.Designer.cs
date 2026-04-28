namespace WalletApp.AppForms
{
    partial class AddTransferToGoalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTransferToGoalForm));
            this.CancelButton = new Guna.UI2.WinForms.Guna2Button();
            this.ButtonSave = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.AmountTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.SavingGoalsComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.SuspendLayout();
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
            this.CancelButton.Location = new System.Drawing.Point(30, 268);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(280, 59);
            this.CancelButton.TabIndex = 29;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
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
            this.ButtonSave.Location = new System.Drawing.Point(332, 268);
            this.ButtonSave.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(280, 59);
            this.ButtonSave.TabIndex = 28;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(23, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 37);
            this.label1.TabIndex = 27;
            this.label1.Text = "Необходимая сумма";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.NameLabel.Location = new System.Drawing.Point(23, 48);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(208, 37);
            this.NameLabel.TabIndex = 26;
            this.NameLabel.Text = "Выберите цель";
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
            this.AmountTextBox.Location = new System.Drawing.Point(304, 137);
            this.AmountTextBox.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.PlaceholderText = "";
            this.AmountTextBox.SelectedText = "";
            this.AmountTextBox.Size = new System.Drawing.Size(308, 58);
            this.AmountTextBox.TabIndex = 25;
            this.AmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmountTextBox_KeyPress);
            // 
            // SavingGoalsComboBox
            // 
            this.SavingGoalsComboBox.BackColor = System.Drawing.Color.Transparent;
            this.SavingGoalsComboBox.BorderRadius = 15;
            this.SavingGoalsComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SavingGoalsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SavingGoalsComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SavingGoalsComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SavingGoalsComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.SavingGoalsComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.SavingGoalsComboBox.ItemHeight = 30;
            this.SavingGoalsComboBox.Location = new System.Drawing.Point(304, 48);
            this.SavingGoalsComboBox.Name = "SavingGoalsComboBox";
            this.SavingGoalsComboBox.Size = new System.Drawing.Size(308, 36);
            this.SavingGoalsComboBox.TabIndex = 30;
            this.SavingGoalsComboBox.ValueMember = "goal_id";
            // 
            // AddTransferToGoalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(666, 366);
            this.Controls.Add(this.SavingGoalsComboBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.AmountTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddTransferToGoalForm";
            this.Text = "Перевод в копилку";
            this.Load += new System.EventHandler(this.AddTransferToGoalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button CancelButton;
        private Guna.UI2.WinForms.Guna2Button ButtonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NameLabel;
        private Guna.UI2.WinForms.Guna2TextBox AmountTextBox;
        private Guna.UI2.WinForms.Guna2ComboBox SavingGoalsComboBox;
    }
}