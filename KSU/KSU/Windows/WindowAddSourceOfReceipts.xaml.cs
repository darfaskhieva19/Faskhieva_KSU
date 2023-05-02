using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KSU
{
    /// <summary>
    /// Логика взаимодействия для WindowAddSourceOfReceipts.xaml
    /// </summary>
    public partial class WindowAddSourceOfReceipts : Window
    {
        public WindowAddSourceOfReceipts()
        {
            InitializeComponent();
        }

        private void btnCanel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (checkData(tbSourceOfReceipt.Text))
            {
                SourceOfAcquisition source = new SourceOfAcquisition();
                source.Kind = tbSourceOfReceipt.Text;
                DataBase.Base.SourceOfAcquisition.Add(source);
                DataBase.Base.SaveChanges();
                this.Close();
            }
        }
        /// <summary>
        /// Проверка на заполненность строки
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool checkData(string a)
        {
            if (a == "")
            {
                MessageBox.Show("Обязательные поля не заполнены", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
