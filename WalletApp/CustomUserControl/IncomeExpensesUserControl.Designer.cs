namespace WalletApp.CustomUserControl
{
    partial class IncomeExpensesUserControl
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
            this.CatergotyNameLabel = new System.Windows.Forms.Label();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CatergotyNameLabel
            // 
            this.CatergotyNameLabel.AutoSize = true;
            this.CatergotyNameLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.CatergotyNameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CatergotyNameLabel.Location = new System.Drawing.Point(0, 0);
            this.CatergotyNameLabel.Name = "CatergotyNameLabel";
            this.CatergotyNameLabel.Size = new System.Drawing.Size(153, 38);
            this.CatergotyNameLabel.TabIndex = 0;
            this.CatergotyNameLabel.Text = "Категория";
            this.CatergotyNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmountLabel
            // 
            this.AmountLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.AmountLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmountLabel.Location = new System.Drawing.Point(395, 0);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(292, 69);
            this.AmountLabel.TabIndex = 1;
            this.AmountLabel.Text = "Сумма";
            this.AmountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(4, 38);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(39, 16);
            this.DateLabel.TabIndex = 2;
            this.DateLabel.Text = "Дата";
            // 
            // IncomeExpensesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.AmountLabel);
            this.Controls.Add(this.CatergotyNameLabel);
            this.Name = "IncomeExpensesUserControl";
            this.Size = new System.Drawing.Size(687, 69);
            this.Load += new System.EventHandler(this.IncomeExpensesUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CatergotyNameLabel;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.Label DateLabel;
    }
}
