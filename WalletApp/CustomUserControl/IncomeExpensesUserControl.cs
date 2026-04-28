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

namespace WalletApp.CustomUserControl
{
    public partial class IncomeExpensesUserControl : UserControl
    {
        transactions _transaction;
        public IncomeExpensesUserControl(transactions transactions)
        {
            InitializeComponent();
            _transaction = transactions;
        }

        private void FillFields()
        {
            CatergotyNameLabel.Text = _transaction.categories.name;
            AmountLabel.Text = _transaction.amount.ToString();
            
        }

        private void IncomeExpensesUserControl_Load(object sender, EventArgs e)
        {
            FillFields();
        }
    }
}
