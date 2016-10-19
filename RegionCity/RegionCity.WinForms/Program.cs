using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegionCity.WinForms.Manager;

namespace RegionCity.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormLogin login = new FormLogin();
            if(login.ShowDialog() == DialogResult.OK)
            {
                if(ConnectToDb.IsConnect(login.textBox1.Text,login.textBox2.Text))
                {
                    Application.Run(new Form1(ConnectToDb.GetConnectionString(login.textBox1.Text, login.textBox2.Text)));
                }
                else
                {
                  
                    return;
                }
            }
          else
                return;
        }
    }
}
