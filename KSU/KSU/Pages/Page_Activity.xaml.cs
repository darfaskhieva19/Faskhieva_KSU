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
        Disposals disposal;
        Receipts receipts;
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
            WindowReceiptsOne addReceipts = new WindowReceiptsOne();
            addReceipts.ShowDialog();
            dgReceipt.ItemsSource = DataBase.Base.Receipts.ToList(); //перезагрузка страницы
        }

        private void btnResult_Click(object sender, RoutedEventArgs e) // Формирование итогов
        {
            spRes.Visibility = Visibility.Visible;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) // Удаление из таблицы Выбытие
        {
            if(MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Системное сообщение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;
                int index = Convert.ToInt32(btn.Uid);

                //this.dgDisposals.Items.Remove(this.dgDisposals.SelectedItem);

            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btnDeleteR_Click(object sender, RoutedEventArgs e) // Удаление из таблицы Поступление
        {

        }

        private void dgReceipt_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Receipts receipt = new Receipts();
                foreach (Receipts receip in dgReceipt.SelectedItems)
                {
                    receipt = receip;
                }
                if (receipt == null)
                {
                    return;
                }
                else
                {
                    WindowReceiptsOne windowReceipts = new WindowReceiptsOne(receipt);
                    windowReceipts.ShowDialog();
                    dgReceipt.ItemsSource = DataBase.Base.Receipts.ToList();
                }
            }
            catch
            {
                MessageBox.Show("Нажмите на 1 объект!");
            }
        }

        private void dgDisposals_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Disposals disposals = new Disposals();
                foreach (Disposals disp in dgDisposals.SelectedItems)
                {
                    disposals = disp;
                }
                if (disposals == null)
                {
                    return;
                }
                else
                {
                    WindowDisposalsOne windowDisposals = new WindowDisposalsOne(disposal);
                    windowDisposals.ShowDialog();
                    dgDisposals.ItemsSource = DataBase.Base.Disposals.ToList();
                }
            }
            catch
            {
                MessageBox.Show("Нажмите на 1 объект!");
            }
        }
    }
}
