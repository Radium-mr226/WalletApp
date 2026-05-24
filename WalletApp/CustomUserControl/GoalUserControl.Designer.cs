namespace WalletApp.CustomUserControl
{
    partial class GoalUserControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GoalDescriptionLabel = new System.Windows.Forms.Label();
            this.GoalNameLabel = new System.Windows.Forms.Label();
            this.guna2CustomGradientPanel10 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.AmountProgressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.FillButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.HaveNeedGoalLabel = new System.Windows.Forms.Label();
            this.guna2CustomGradientPanel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // GoalDescriptionLabel
            // 
            this.GoalDescriptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.GoalDescriptionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GoalDescriptionLabel.Location = new System.Drawing.Point(18, 64);
            this.GoalDescriptionLabel.Name = "GoalDescriptionLabel";
            this.GoalDescriptionLabel.Size = new System.Drawing.Size(1090, 66);
            this.GoalDescriptionLabel.TabIndex = 4;
            this.GoalDescriptionLabel.Text = "Описание цели";
            // 
            // GoalNameLabel
            // 
            this.GoalNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.GoalNameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GoalNameLabel.Location = new System.Drawing.Point(15, 20);
            this.GoalNameLabel.Name = "GoalNameLabel";
            this.GoalNameLabel.Size = new System.Drawing.Size(629, 44);
            this.GoalNameLabel.TabIndex = 3;
            this.GoalNameLabel.Text = "Название цели";
            // 
            // guna2CustomGradientPanel10
            // 
            this.guna2CustomGradientPanel10.BorderRadius = 30;
            this.guna2CustomGradientPanel10.Controls.Add(this.HaveNeedGoalLabel);
            this.guna2CustomGradientPanel10.Controls.Add(this.FillButton1);
            this.guna2CustomGradientPanel10.Controls.Add(this.AmountProgressBar);
            this.guna2CustomGradientPanel10.Controls.Add(this.GoalNameLabel);
            this.guna2CustomGradientPanel10.Controls.Add(this.GoalDescriptionLabel);
            this.guna2CustomGradientPanel10.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel10.Name = "guna2CustomGradientPanel10";
            this.guna2CustomGradientPanel10.Padding = new System.Windows.Forms.Padding(20);
            this.guna2CustomGradientPanel10.Size = new System.Drawing.Size(1139, 293);
            this.guna2CustomGradientPanel10.TabIndex = 12;
            // 
            // AmountProgressBar
            // 
            this.AmountProgressBar.ForeColor = System.Drawing.Color.White;
            this.AmountProgressBar.Location = new System.Drawing.Point(23, 167);
            this.AmountProgressBar.Name = "AmountProgressBar";
            this.AmountProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.AmountProgressBar.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.AmountProgressBar.Size = new System.Drawing.Size(1093, 38);
            this.AmountProgressBar.TabIndex = 5;
            this.AmountProgressBar.Text = "guna2ProgressBar1";
            this.AmountProgressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // FillButton1
            // 
            this.FillButton1.BorderRadius = 15;
            this.FillButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.FillButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.FillButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.FillButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.FillButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.FillButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(205)))), ((int)(((byte)(255)))));
            this.FillButton1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(205)))), ((int)(((byte)(255)))));
            this.FillButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FillButton1.ForeColor = System.Drawing.Color.Black;
            this.FillButton1.Location = new System.Drawing.Point(23, 225);
            this.FillButton1.Name = "FillButton1";
            this.FillButton1.Size = new System.Drawing.Size(180, 45);
            this.FillButton1.TabIndex = 6;
            this.FillButton1.Text = "Пополнить";
            this.FillButton1.Click += new System.EventHandler(this.FillButton1_Click);
            // 
            // HaveNeedGoalLabel
            // 
            this.HaveNeedGoalLabel.AutoSize = true;
            this.HaveNeedGoalLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HaveNeedGoalLabel.Location = new System.Drawing.Point(20, 144);
            this.HaveNeedGoalLabel.Name = "HaveNeedGoalLabel";
            this.HaveNeedGoalLabel.Size = new System.Drawing.Size(169, 23);
            this.HaveNeedGoalLabel.TabIndex = 7;
            this.HaveNeedGoalLabel.Text = "Всего необходимо: ";
            // 
            // GoalUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2CustomGradientPanel10);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "GoalUserControl";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(1139, 293);
            this.Load += new System.EventHandler(this.GoalUserControl_Load);
            this.guna2CustomGradientPanel10.ResumeLayout(false);
            this.guna2CustomGradientPanel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label GoalDescriptionLabel;
        private System.Windows.Forms.Label GoalNameLabel;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel10;
        private Guna.UI2.WinForms.Guna2GradientButton FillButton1;
        private Guna.UI2.WinForms.Guna2ProgressBar AmountProgressBar;
        private System.Windows.Forms.Label HaveNeedGoalLabel;
    }
}
