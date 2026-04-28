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
            this.guna2CustomGradientPanel5 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.HaveNeedGoalLabel = new System.Windows.Forms.Label();
            this.GoalDescriptionLabel = new System.Windows.Forms.Label();
            this.GoalNameLabel = new System.Windows.Forms.Label();
            this.guna2CustomGradientPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2CustomGradientPanel5
            // 
            this.guna2CustomGradientPanel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel5.BorderRadius = 15;
            this.guna2CustomGradientPanel5.Controls.Add(this.HaveNeedGoalLabel);
            this.guna2CustomGradientPanel5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(255)))), ((int)(((byte)(132)))));
            this.guna2CustomGradientPanel5.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(255)))), ((int)(((byte)(132)))));
            this.guna2CustomGradientPanel5.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(255)))), ((int)(((byte)(132)))));
            this.guna2CustomGradientPanel5.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(255)))), ((int)(((byte)(132)))));
            this.guna2CustomGradientPanel5.Location = new System.Drawing.Point(679, 25);
            this.guna2CustomGradientPanel5.Name = "guna2CustomGradientPanel5";
            this.guna2CustomGradientPanel5.Padding = new System.Windows.Forms.Padding(15);
            this.guna2CustomGradientPanel5.Size = new System.Drawing.Size(256, 167);
            this.guna2CustomGradientPanel5.TabIndex = 5;
            // 
            // HaveNeedGoalLabel
            // 
            this.HaveNeedGoalLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HaveNeedGoalLabel.Location = new System.Drawing.Point(18, 15);
            this.HaveNeedGoalLabel.Name = "HaveNeedGoalLabel";
            this.HaveNeedGoalLabel.Size = new System.Drawing.Size(220, 137);
            this.HaveNeedGoalLabel.TabIndex = 0;
            this.HaveNeedGoalLabel.Text = "Имеется\r\nНеобходимо\r\n";
            this.HaveNeedGoalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GoalDescriptionLabel
            // 
            this.GoalDescriptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.GoalDescriptionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GoalDescriptionLabel.Location = new System.Drawing.Point(26, 97);
            this.GoalDescriptionLabel.Name = "GoalDescriptionLabel";
            this.GoalDescriptionLabel.Size = new System.Drawing.Size(629, 110);
            this.GoalDescriptionLabel.TabIndex = 4;
            this.GoalDescriptionLabel.Text = "Описание цели";
            // 
            // GoalNameLabel
            // 
            this.GoalNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.GoalNameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GoalNameLabel.Location = new System.Drawing.Point(23, 25);
            this.GoalNameLabel.Name = "GoalNameLabel";
            this.GoalNameLabel.Size = new System.Drawing.Size(629, 44);
            this.GoalNameLabel.TabIndex = 3;
            this.GoalNameLabel.Text = "Название цели";
            // 
            // GoalUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.Controls.Add(this.guna2CustomGradientPanel5);
            this.Controls.Add(this.GoalDescriptionLabel);
            this.Controls.Add(this.GoalNameLabel);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "GoalUserControl";
            this.Size = new System.Drawing.Size(962, 216);
            this.Load += new System.EventHandler(this.GoalUserControl_Load);
            this.guna2CustomGradientPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel5;
        private System.Windows.Forms.Label HaveNeedGoalLabel;
        private System.Windows.Forms.Label GoalDescriptionLabel;
        private System.Windows.Forms.Label GoalNameLabel;
    }
}
