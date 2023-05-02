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
    /// Логика взаимодействия для WindowAddPlace.xaml
    /// </summary>
    public partial class WindowAddPlace : Window
    {
        public WindowAddPlace()
        {
            InitializeComponent();
        }

        private void btnCanel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Проверка на заполненность строки
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool checkDataPlace(string a)
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (checkDataPlace(tbPlace.Text))
            {
                Place place = new Place();
                place.Kind = tbPlace.Text;
                DataBase.Base.Place.Add(place);
                DataBase.Base.SaveChanges();
                this.Close();
            }
        }
    }
}
