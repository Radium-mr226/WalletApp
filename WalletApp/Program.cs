using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WalletApp.AppForms;
using WalletApp.Models;

namespace WalletApp
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        public static CourseProjectDB context = new CourseProjectDB();
        [STAThread]
        static void Main()
        {
            if (!context.Database.Exists())
            {
                MessageBox.Show("Не удается установить соединение с базой данных");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Autorization());
        }
    }
}
