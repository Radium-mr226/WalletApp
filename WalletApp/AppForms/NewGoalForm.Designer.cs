namespace WalletApp.AppForms
{
    partial class NewGoalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGoalForm));
            this.NameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.AmountTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CancelButton = new Guna.UI2.WinForms.Guna2Button();
            this.ButtonSave = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // NameTextBox
            // 
            this.NameTextBox.BorderRadius = 15;
            this.NameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NameTextBox.DefaultText = "";
            this.NameTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.NameTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.NameTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NameTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NameTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NameTextBox.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.NameTextBox.ForeColor = System.Drawing.Color.Black;
            this.NameTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NameTextBox.Location = new System.Drawing.Point(399, 76);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.PlaceholderText = "";
            this.NameTextBox.SelectedText = "";
            this.NameTextBox.Size = new System.Drawing.Size(363, 72);
            this.NameTextBox.TabIndex = 0;
            this.NameTextBox.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            this.NameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameTextBox_KeyPress);
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
            this.AmountTextBox.Location = new System.Drawing.Point(399, 199);
            this.AmountTextBox.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.PlaceholderText = "";
            this.AmountTextBox.SelectedText = "";
            this.AmountTextBox.Size = new System.Drawing.Size(363, 72);
            this.AmountTextBox.TabIndex = 1;
            this.AmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmountTextBox_KeyPress);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.NameLabel.Location = new System.Drawing.Point(31, 89);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(174, 46);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Название";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(31, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "Необходимая сумма";
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
            this.CancelButton.Location = new System.Drawing.Point(12, 362);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(373, 73);
            this.CancelButton.TabIndex = 23;
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
            this.ButtonSave.Location = new System.Drawing.Point(415, 362);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(373, 73);
            this.ButtonSave.TabIndex = 22;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // NewGoalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(800, 478);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.AmountTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewGoalForm";
            this.Text = "NewGoalForm";
            this.Load += new System.EventHandler(this.NewGoalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox NameTextBox;
        private Guna.UI2.WinForms.Guna2TextBox AmountTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button CancelButton;
        private Guna.UI2.WinForms.Guna2Button ButtonSave;
    }
}