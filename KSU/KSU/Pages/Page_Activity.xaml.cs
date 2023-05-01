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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KSU
{
    /// <summary>
    /// Логика взаимодействия для Page_Activity.xaml
    /// </summary>
    public partial class Page_Activity : Page
    {
        public Page_Activity()
        {
            InitializeComponent();
            

            dgReceipt.ItemsSource = DataBase.Base.Receipts.ToList();
            dgDisposals.ItemsSource = DataBase.Base.Disposals.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e) // Добавление записи в таблицу Выбытие
        {
            WindowDisposalsOne addDisposals = new WindowDisposalsOne();
            addDisposals.ShowDialog();
            dgDisposals.ItemsSource = DataBase.Base.Disposals.ToList(); //перезагрузка страницы
        }

        private void btnNewAdd_Click(object sender, RoutedEventArgs e) // Добавление записи в таблицу Поступление
        {

        }

        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            spRes.Visibility = Visibility.Visible;
        }
    }
}
