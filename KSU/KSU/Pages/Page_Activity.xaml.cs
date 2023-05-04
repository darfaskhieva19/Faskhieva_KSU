using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
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
            // 1 Корпус
            dgReceipt.ItemsSource = DataBase.Base.Receipts.Where(z => z.IdEnclosures == 1).ToList();
            dgDisposals.ItemsSource = DataBase.Base.Disposals.Where(z => z.IdEnclosures == 1).ToList();
            dgResults.ItemsSource = DataBase.Base.Results.Where(z => z.IdEnclosures == 1).ToList();

            // 2 Корпус
            dgReceiptTwo.ItemsSource = DataBase.Base.Receipts.Where(z => z.IdEnclosures == 2).ToList();
            dgDisposalsTwo.ItemsSource = DataBase.Base.Disposals.Where(z=>z.IdEnclosures == 2).ToList();
            dgResultsTwo.ItemsSource = DataBase.Base.Results.Where(z => z.IdEnclosures == 2).ToList();

            // 3 Корпус
            dgReceiptThree.ItemsSource = DataBase.Base.Receipts.Where(z => z.IdEnclosures == 3).ToList();
            dgDisposalsThree.ItemsSource = DataBase.Base.Disposals.Where(z => z.IdEnclosures == 3).ToList();
            dgResultsThree.ItemsSource = DataBase.Base.Results.Where(z => z.IdEnclosures == 3).ToList();

            // Все корпуса
            dgReceiptResult.ItemsSource = DataBase.Base.Receipts.OrderBy(x => x.Date).ToList();
            dgDisposalsResults.ItemsSource = DataBase.Base.Disposals.ToList();
            dgTotalResults.ItemsSource = DataBase.Base.Results.ToList();

            DateTime today = DateTime.Today;
            int year = today.Year;
            DateTime September = new DateTime(year,9,1);
            DateTime November = new DateTime(year, 11, 30);
            DateTime December = new DateTime(year, 12, 1);
            DateTime Marchs = new DateTime(year+1, 3, 1);
            DateTime March = new DateTime(year, 3, 1);
            DateTime May = new DateTime(year, 5, 31);
            DateTime June = new DateTime(year, 6, 1);
            DateTime August = new DateTime(year, 8, 31);
            if (December <= DateTime.Today && DateTime.Today < Marchs)
            {
                var uri = new Uri(@"Themes\WinterTheme.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                // очищаем коллекцию ресурсов приложения
                Application.Current.Resources.Clear();
                // добавляем загруженный словарь ресурсов
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
            else if (March <= DateTime.Today && DateTime.Today <= May)
            {
                var uri = new Uri(@"Themes\SpringTheme.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                // очищаем коллекцию ресурсов приложения
                Application.Current.Resources.Clear();
                // добавляем загруженный словарь ресурсов
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
            else if (June <= DateTime.Today && DateTime.Today <= August)
            {
                var uri = new Uri(@"Themes\SummerTheme.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                // очищаем коллекцию ресурсов приложения
                Application.Current.Resources.Clear();
                // добавляем загруженный словарь ресурсов
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
            else if (September <= DateTime.Today && DateTime.Today <= November)
            {
                var uri = new Uri(@"Themes\AutumnTheme.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                // очищаем коллекцию ресурсов приложения
                Application.Current.Resources.Clear();
                // добавляем загруженный словарь ресурсов
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
        }

        private void dgReceipt_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Receipts receipts = (Receipts)e.Row.DataContext;
            DateTime date = receipts.Date;
            int year = date.Year;
            var brush = new BrushConverter();
            if (year <= 2018)
            {
                e.Row.Background = (SolidColorBrush)(Brush)brush.ConvertFrom("#F2F3B1");
            }
            else if (year <= 2019 && year <= 2024)
            {
                e.Row.Background = (SolidColorBrush)(Brush)brush.ConvertFrom("#BEF3B1");
            }
            else if ((year <= 2020 && year <= 2025))
            {
                e.Row.Background = (SolidColorBrush)(Brush)brush.ConvertFrom("#B1C7F3");
            }
            else if(year <= 2021 && year <= 2026)
            {
                e.Row.Background = (SolidColorBrush)(Brush)brush.ConvertFrom("#F3DDB1");
            }
            else if(year <= 2022) 
            {
                e.Row.Background = (SolidColorBrush)(Brush)brush.ConvertFrom("#BEF3B1");
            }
            else if (year <= 2023)
            {
                e.Row.Background = (SolidColorBrush)(Brush)brush.ConvertFrom("#F2F3B1");
            }
            //EED2FF
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e) // Добавление записи в таблицу Выбытие
        {
            WindowDisposalsOne addDisposals = new WindowDisposalsOne();
            WindowDisposalsOne.index = 1;
            addDisposals.ShowDialog();
            dgDisposals.ItemsSource = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1).ToList();
        }

        private void btnNewAdd_Click(object sender, RoutedEventArgs e) // Добавление записи в таблицу Поступление 1 корпус
        {
            WindowReceiptsOne addReceipts = new WindowReceiptsOne();
            WindowReceiptsOne.index = 1;
            addReceipts.ShowDialog();
            dgReceipt.ItemsSource = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1).ToList();
        }       

        private void dgReceipt_MouseDoubleClick(object sender, MouseButtonEventArgs e) // 1 корпус Поступление редактирование
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
                    WindowReceiptsOne.index = 1;                   
                    windowReceipts.ShowDialog();
                    dgReceipt.ItemsSource = DataBase.Base.Receipts.Where(z => z.IdEnclosures == 1).ToList();                     
                }
            }
            catch
            {
                MessageBox.Show("Нажмите на 1 объект!");
            }
        }

        private void dgDisposals_MouseDoubleClick(object sender, MouseButtonEventArgs e) // 1 корпус Выбытие редактирование
        {
            try
            {
                Disposals disposal = new Disposals();
                foreach (Disposals disp in dgDisposals.SelectedItems)
                {
                    disposal = disp;
                }
                if (disposal == null)
                {
                    return;
                }
                else
                {
                    WindowDisposalsOne windowDisposals = new WindowDisposalsOne(disposal);
                    WindowDisposalsOne.index = 1;
                    windowDisposals.ShowDialog();
                    dgDisposals.ItemsSource = DataBase.Base.Disposals.Where(z => z.IdEnclosures == 1).ToList();
                }
            }
            catch
            {
                MessageBox.Show("Нажмите на 1 объект!");
            }
        }

        private void btnNAdd_Click(object sender, RoutedEventArgs e) //2 корпус Поступление добавление
        {
            WindowReceiptsOne addReceipts = new WindowReceiptsOne();
            WindowReceiptsOne.index = 2;
            addReceipts.ShowDialog();
            dgReceiptTwo.ItemsSource = DataBase.Base.Receipts.Where(x=>x.IdEnclosures==2).ToList();
        }

        private void btnAddThree_Click(object sender, RoutedEventArgs e) //3 корпус Поступление добавление
        {
            WindowReceiptsOne addReceipts = new WindowReceiptsOne();
            WindowReceiptsOne.index = 3;
            addReceipts.ShowDialog();
            dgReceiptThree.ItemsSource = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3).ToList();
        }

        private void btnAddThreeD_Click(object sender, RoutedEventArgs e) // 3 корпус Выбытие добавление
        {
            WindowDisposalsOne addDisposals = new WindowDisposalsOne();
            WindowDisposalsOne.index = 3;
            addDisposals.ShowDialog();
            dgDisposalsThree.ItemsSource = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 3).ToList();
        }

        private void btnAddDisposalsTwo_Click(object sender, RoutedEventArgs e) // 2 корпус Выбытие добавление
        {
            WindowDisposalsOne addDisposals = new WindowDisposalsOne();
            WindowDisposalsOne.index = 2;
            addDisposals.ShowDialog();
            dgDisposalsTwo.ItemsSource = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 2).ToList();
        }

        private void dgDisposalsTwo_MouseDoubleClick(object sender, MouseButtonEventArgs e) // 2 корпус Выбытие редактирование
        {
            try
            {
                Disposals disposal = new Disposals();
                foreach (Disposals disp in dgDisposalsTwo.SelectedItems)
                {
                    disposal = disp;
                }
                if (disposal == null)
                {
                    return;
                }
                else
                {
                    WindowDisposalsOne windowDisposals = new WindowDisposalsOne(disposal);
                    WindowDisposalsOne.index = 2;
                    windowDisposals.ShowDialog();
                    dgDisposalsTwo.ItemsSource = DataBase.Base.Disposals.Where(z => z.IdEnclosures == 2).ToList();
                }
            }
            catch
            {
                MessageBox.Show("Нажмите на 1 объект!");
            }
        }

        private void dgReceiptTwo_MouseDoubleClick(object sender, MouseButtonEventArgs e) // 2 корпус Поступление редактирование
        {
            try
            {
                Receipts receipt = new Receipts();
                foreach (Receipts receip in dgReceiptTwo.SelectedItems)
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
                    WindowReceiptsOne.index = 2;
                    windowReceipts.ShowDialog();
                    dgReceiptTwo.ItemsSource = DataBase.Base.Receipts.Where(z => z.IdEnclosures == 2).ToList();
                }
            }
            catch
            {
                MessageBox.Show("Нажмите на 1 объект!");
            }
        }

        private void dgReceiptThree_MouseDoubleClick(object sender, MouseButtonEventArgs e) // 3 корпус Поступление редактирование
        {
            try
            {
                Receipts receipt = new Receipts();
                foreach (Receipts receip in dgReceiptThree.SelectedItems)
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
                    WindowReceiptsOne.index = 3;
                    windowReceipts.ShowDialog();
                    dgReceiptThree.ItemsSource = DataBase.Base.Receipts.Where(z => z.IdEnclosures == 3).ToList();
                }
            }
            catch
            {
                MessageBox.Show("Нажмите на 1 объект!");
            }
        }

        private void dgDisposalsThree_MouseDoubleClick(object sender, MouseButtonEventArgs e) // 3 корпус Выбытие редактирование
        {
            try
            {
                Disposals disposal = new Disposals();
                foreach (Disposals disp in dgDisposalsThree.SelectedItems)
                {
                    disposal = disp;
                }
                if (disposal == null)
                {
                    return;
                }
                else
                {
                    WindowDisposalsOne windowDisposals = new WindowDisposalsOne(disposal);
                    WindowDisposalsOne.index = 3;
                    windowDisposals.ShowDialog();
                    dgDisposalsThree.ItemsSource = DataBase.Base.Disposals.Where(z => z.IdEnclosures == 3).ToList();
                }
            }
            catch
            {
                MessageBox.Show("Нажмите на 1 объект!");
            }
        }

        private void btnResult_Click(object sender, RoutedEventArgs e) // Формирование итогов 1 корпус
        {
            spRes.Visibility = Visibility.Visible;


        }

        private void btnResultTwo_Click(object sender, RoutedEventArgs e) // Формирование итогов 2 корпус
        {
            spResultTwo.Visibility = Visibility.Visible;


        }

        private void btnResultThree_Click(object sender, RoutedEventArgs e) // Формирование итогов 3 корпус
        {
            spResThree.Visibility = Visibility.Visible;


        }

        private void btnTotalResult_Click(object sender, RoutedEventArgs e) // Формирование итогов всех 3 корпусов
        {
            spResults.Visibility = Visibility.Visible;


        }       
    }
}
