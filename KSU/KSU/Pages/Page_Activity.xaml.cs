using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Globalization;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Windows.Controls.Primitives;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace KSU
{
    /// <summary>
    /// Логика взаимодействия для Page_Activity.xaml
    /// </summary>
    public partial class Page_Activity : Page
    {
        Receipts receipts;
        public Page_Activity()
        {
            InitializeComponent();
            // 1 Корпус
            dgReceipt.ItemsSource = DataBase.Base.Receipts.Where(z => z.IdEnclosures == 1).ToList();
            dgDisposals.ItemsSource = DataBase.Base.Disposals.Where(z => z.IdEnclosures == 1).ToList();
          
            // 2 Корпус
            dgReceiptTwo.ItemsSource = DataBase.Base.Receipts.Where(z => z.IdEnclosures == 2).ToList();
            dgDisposalsTwo.ItemsSource = DataBase.Base.Disposals.Where(z => z.IdEnclosures == 2).ToList();

            // 3 Корпус
            dgReceiptThree.ItemsSource = DataBase.Base.Receipts.Where(z => z.IdEnclosures == 3).ToList();
            dgDisposalsThree.ItemsSource = DataBase.Base.Disposals.Where(z => z.IdEnclosures == 3).ToList();

            // Все корпуса
            dgReceiptResult.ItemsSource = DataBase.Base.Receipts.OrderBy(x => x.Date).ToList();
            dgDisposalsResults.ItemsSource = DataBase.Base.Disposals.OrderBy(x => x.Date).ToList();

            // Настройка темы по временам года
            DateTime today = DateTime.Today;
            int year = today.Year;
            DateTime September = new DateTime(year, 9, 1);
            DateTime November = new DateTime(year, 11, 30);
            DateTime December = new DateTime(year, 12, 1);
            DateTime Marchs = new DateTime(year + 1, 3, 1);
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

        //Метод для раскрашивания строк DataGrid
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
            else if (year <= 2021 && year <= 2026)
            {
                e.Row.Background = (SolidColorBrush)(Brush)brush.ConvertFrom("#F3DDB1");
            }
            else if (year <= 2022)
            {
                e.Row.Background = (SolidColorBrush)(Brush)brush.ConvertFrom("#BEF3B1");
            }
            else if (year <= 2023)
            {
                e.Row.Background = (SolidColorBrush)(Brush)brush.ConvertFrom("#F2F3B1");
            }
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
            dgReceiptTwo.ItemsSource = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 2).ToList();
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
            // Состоит на начало 2018 года
            string BeginningOfTheYear = "Состоит на 01.01.2018 г.";
            int _countBegining = 42655;
            int _cost = 0;
            int _natural = 6281;
            int _social = 3304;
            int _human = 26145;
            int _metodical = 21;
            int _reference = 218;
            int _art = 6686;
            int _print = 42655;
            int _electr = 0;
            int _period = 0;

            // 2018 год
            int year = 2018;  // указываем год, за который хотим посчитать количество поступивших книг
            DateTime startDate = new DateTime(year, 1, 1);
            DateTime endDate = new DateTime(year, 12, 31);
            string Year2018 = "Поступило за 2018 г.";
            int totalCount = 0; //Общее количество
            double totalCost = 0; //Общая стоимость
            int natural = 0; //Естественные науки
            int social = 0; //Технические науки
            int human = 0; //Гуманитарные науки
            int metodical = 0; //Методическая литература
            int reference = 0; //Справочная литература
            int art = 0; //Художественная литература
            int print = 0; //Печатный вид
            int electr = 0; //Электронный вид
            int period = 0; //Периодические издания

            var items = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= startDate && x.Date <= endDate);
            foreach (var item in items)
            {
                totalCount += item.TotalInstances;
                totalCost += item.Cost;
            }
            int contentId = 1; // идентификатор книги, количество которой нужно подсчитать
            int contentIdTwo = 2;
            int contentIdThree = 3;
            int contentIdFour = 4;
            int contentIdFive = 5;
            int contentIdSix = 6;
            //По содержанию
            foreach (var item in items)
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    {
                        natural += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    {
                        social += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    {
                        human += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    {
                        metodical += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    {
                        reference += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    {
                        art += (int)itemContent.Counts;
                    }
                }
            }
            // По виду
            int viewId = 1; // идентификатор книги, количество которой нужно подсчитать            
            int viewIdTwo = 2;
            int viewIdThree = 3;
            foreach (var item in items)
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId)
                    {
                        print += (int)itemView.Counts; //Печатные
                    }                    
                    if (itemView.IdViews == viewIdTwo)
                    {
                        electr += (int)itemView.Counts; //Электронные
                    }
                    if (itemView.IdViews == viewIdThree)
                    {
                        period += (int)itemView.Counts; //Периодические издания
                    }
                }
            }

            //Состоит на начало 2019 года
            string BeginningOfTheYear19 = "Состоит на 01.01.2019 г.";
            int _countBeginingYear19 = 0;
            int _costYear19 = 0;
            int _naturalYear19 = 0;
            int _socialYear19 = 0;
            int _humanYear19 = 0;
            int _metodicalYear19 = 0;
            int _referenceYear19 = 0;
            int _artYear19 = 0;
            int _printYear19 = 0;
            int _electrYear19 = 0;
            int _periodYear19 = 0;

            _countBeginingYear19 = _countBegining + totalCount;
            _naturalYear19 = _natural + natural;
            _socialYear19 = _social + social;
            _referenceYear19 = _reference + reference;
            _humanYear19 = _human + human;
            _metodicalYear19 = _metodical + metodical;
            _artYear19 = _art + art;
            _printYear19 = _print + print;
            _electrYear19 = _electr + electr;
            _periodYear19 = _period + period;

            //Поступление 2019 год
            int year19 = 2019;
            DateTime startDate19 = new DateTime(year19, 1, 1);
            DateTime endDate19 = new DateTime(year19, 12, 31);            
            string Year2019 = "Поступило за 2019 г.";
            int totalCount19 = 0; //Общее количество
            double totalCost19 = 0; //Общая стоимость
            int natural19 = 0; //Естественные науки
            int social19 = 0; //Технические науки
            int human19 = 0; //Гуманитарные науки
            int metodical19 = 0; //Методическая литература
            int reference19 = 0; //Справочная литература
            int art19 = 0; //Художественная литература
            int print19 = 0; //Печатный вид
            int electr19 = 0; //Электронный вид
            int period19 = 0; //Периодические издания
            var items19 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= startDate19 && x.Date <= endDate19);
            foreach (var item in items19)
            {
                totalCount19 += item.TotalInstances;
                totalCost19 += item.Cost;
            }
            //По содержанию
            foreach (var item in items19)
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    {
                        natural19 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    {
                        social19 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    {
                        human19 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    {
                        metodical19 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    {
                        reference19 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    {
                        art19 += (int)itemContent.Counts;
                    }
                }
            }
            // По виду
            foreach (var item in items19)
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId)
                    {
                        print19 += (int)itemView.Counts; //Печатные
                    }
                    if (itemView.IdViews == viewIdTwo)
                    {
                        electr19 += (int)itemView.Counts; //Электронные
                    }
                    if (itemView.IdViews == viewIdThree)
                    {
                        period19 += (int)itemView.Counts; //Периодические издания
                    }
                }
            }

            //Выбытие 2019 год
            string DisYear2019 = "Выбыло за 2019 г.";
            int totalCountDis = 0; //Общее количество
            double totalCostDis = 0; //Общая стоимость
            int naturalDis = 0; //Естественные науки
            int socialDis = 0; //Технические науки
            int humanDis = 0; //Гуманитарные науки
            int metodicalDis = 0; //Методическая литература
            int referenceDis = 0; //Справочная литература
            int artDis = 0; //Художественная литература
            int printDis = 0; //Печатный вид
            int electrDis = 0; //Электронный вид
            int periodDis = 0; //Периодические издания

            var itemss = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= startDate19 && x.Date <= endDate19);
            foreach (var item in itemss)
            {
                totalCountDis += item.TotalNumber;
                totalCostDis += item.Cost;
            }
            //По содержанию
            foreach (var item in itemss)
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    {
                        naturalDis += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    {
                        socialDis += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    {
                        humanDis += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    {
                        metodicalDis += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    {
                        referenceDis += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    {
                        artDis += (int)itemContent.Counts;
                    }
                }
            }
            // По виду
            foreach (var item in itemss)
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId)
                    {
                        printDis += (int)itemView.Counts; //Печатные
                    }
                    if (itemView.IdViews == viewIdTwo)
                    {
                        electrDis += (int)itemView.Counts; //Электронные
                    }
                    if (itemView.IdViews == viewIdThree)
                    {
                        periodDis += (int)itemView.Counts; //Периодические издания
                    }
                }
            }

            //Состоит на начало 2020 года
            string BeginningOfTheYear20 = "Состоит на 01.01.2020 г.";
            int _countBeginingYear20 = 0;
            int _costYear20 = 0;
            int _naturalYear20 = 0;
            int _socialYear20 = 0;
            int _humanYear20 = 0;
            int _metodicalYear20 = 0;
            int _referenceYear20 = 0;
            int _artYear20 = 0;
            int _printYear20 = 0;
            int _electrYear20 = 0;
            int _periodYear20 = 0;

            _countBeginingYear20 = _countBeginingYear19 + totalCount19 - totalCountDis;
            _naturalYear20 = _naturalYear19 + natural19 - naturalDis;
            _socialYear20 = _socialYear19 + social19 - socialDis;
            _referenceYear20 = _referenceYear19 + reference19 - referenceDis;
            _humanYear20 = _humanYear19 + human19 - humanDis;
            _metodicalYear20 = _metodicalYear19 + metodical19 - metodicalDis;
            _artYear20 = _artYear19 + art19 - artDis;
            _printYear20 = _printYear19 + print19 - printDis;
            _electrYear20 = _electrYear19 + electr19 - electrDis;
            _periodYear20 = _periodYear19 + period19 - periodDis;

            //Поступление 2020 год
            int year20 = 2020;
            DateTime startDate20 = new DateTime(year20, 1, 1);
            DateTime endDate20 = new DateTime(year20, 12, 31);
            string Year2020 = "Поступило за 2020 г.";
            int totalCount20 = 0; //Общее количество
            double totalCost20 = 0; //Общая стоимость
            int natural20 = 0; //Естественные науки
            int social20 = 0; //Технические науки
            int human20 = 0; //Гуманитарные науки
            int metodical20 = 0; //Методическая литература
            int reference20 = 0; //Справочная литература
            int art20 = 0; //Художественная литература
            int print20 = 0; //Печатный вид
            int electr20 = 0; //Электронный вид
            int period20 = 0; //Периодические издания
            var items20 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= startDate20 && x.Date <= endDate20);
            foreach (var item in items20)
            {
                totalCount20 += item.TotalInstances;
                totalCost20 += item.Cost;
            }
            //По содержанию
            foreach (var item in items20)
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    {
                        natural20 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    {
                        social20 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    {
                        human20 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    {
                        metodical20 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    {
                        reference20 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    {
                        art20 += (int)itemContent.Counts;
                    }
                }
            }
            // По виду
            foreach (var item in items20)
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId)
                    {
                        print20 += (int)itemView.Counts; //Печатные
                    }
                    if (itemView.IdViews == viewIdTwo)
                    {
                        electr20 += (int)itemView.Counts; //Электронные
                    }
                    if (itemView.IdViews == viewIdThree)
                    {
                        period20 += (int)itemView.Counts; //Периодические издания
                    }
                }
            }


            //Выбытие 2020 год
            string DisYear2020 = "Выбыло за 2020 г.";
            int totalCountDis20 = 0; //Общее количество
            double totalCostDis20 = 0; //Общая стоимость
            int naturalDis20 = 0; //Естественные науки
            int socialDis20 = 0; //Технические науки
            int humanDis20 = 0; //Гуманитарные науки
            int metodicalDis20 = 0; //Методическая литература
            int referenceDis20 = 0; //Справочная литература
            int artDis20 = 0; //Художественная литература
            int printDis20 = 0; //Печатный вид
            int electrDis20 = 0; //Электронный вид
            int periodDis20 = 0; //Периодические издания

            var itemss20 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= startDate20 && x.Date <= endDate20);
            foreach (var item in itemss20)
            {
                totalCountDis20 += item.TotalNumber;
                totalCostDis20 += item.Cost;
            }
            //По содержанию
            foreach (var item in itemss20)
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    {
                        naturalDis20 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    {
                        socialDis20 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    {
                        humanDis20 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    {
                        metodicalDis20 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    {
                        referenceDis20 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    {
                        artDis20 += (int)itemContent.Counts;
                    }
                }
            }
            // По виду
            foreach (var item in itemss20)
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId)
                    {
                        printDis20 += (int)itemView.Counts; //Печатные
                    }
                    if (itemView.IdViews == viewIdTwo)
                    {
                        electrDis20 += (int)itemView.Counts; //Электронные
                    }
                    if (itemView.IdViews == viewIdThree)
                    {
                        periodDis20 += (int)itemView.Counts; //Периодические издания
                    }
                }
            }

            //Состоит на начало 2021 года
            string BeginningOfTheYear21 = "Состоит на 01.01.2021 г.";
            int _countBeginingYear21 = 0;
            int _costYear21 = 0;
            int _naturalYear21 = 0;
            int _socialYear21 = 0;
            int _humanYear21 = 0;
            int _metodicalYear21 = 0;
            int _referenceYear21 = 0;
            int _artYear21 = 0;
            int _printYear21 = 0;
            int _electrYear21 = 0;
            int _periodYear21 = 0;

            _countBeginingYear21 = _countBeginingYear20 + totalCount20 - totalCountDis20;
            _naturalYear21 = _naturalYear20 + natural20 - naturalDis20;
            _socialYear21 = _socialYear20 + social20 - socialDis20;
            _referenceYear21 = _referenceYear20 + reference20 - referenceDis20;
            _humanYear21 = _humanYear20 + human20 - humanDis20;
            _metodicalYear21 = _metodicalYear20 + metodical20 - metodicalDis20;
            _artYear21 = _artYear20 + art20 - artDis20;
            _printYear21 = _printYear20 + print20 - printDis20;
            _electrYear21 = _electrYear20 + electr20 - electrDis20;
            _periodYear21 = _periodYear20 + period20 - periodDis20;

            //Поступление 2021 год
            int year21 = 2021;
            //расчеты по кварталам
            DateTime January = new DateTime(year21, 1, 1);
            DateTime March = new DateTime(year, 3, 31);
            DateTime April = new DateTime(year, 4, 1);
            DateTime June = new DateTime(year, 6, 30);
            DateTime July = new DateTime(year, 7, 1);
            DateTime September = new DateTime(year21, 9, 30);
            DateTime October = new DateTime(year21, 10, 1);
            DateTime December = new DateTime(year21, 12, 31);
            //1 квартал
            var items21K1 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= January && x.Date <= March); 
            string Year2021K1 = "Поступило за 1 кв. 2021 г.";
            int totalCount21K1 = 0; //Общее количество
            double totalCost21K1 = 0; //Общая стоимость
            int natural21K1 = 0; //Естественные науки
            int social21K1 = 0; //Технические науки
            int human21K1 = 0; //Гуманитарные науки
            int metodical21K1 = 0; //Методическая литература
            int reference21K1 = 0; //Справочная литература
            int art21K1 = 0; //Художественная литература
            int print21K1 = 0; //Печатный вид
            int electr21K1 = 0; //Электронный вид
            int period21K1 = 0; //Периодические издания
            foreach (var item in items21K1)
            {
                totalCount21K1 += item.TotalInstances;
                totalCost21K1 += item.Cost;
            }            
            foreach (var item in items21K1) //По содержанию
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { natural21K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { social21K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { human21K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodical21K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { reference21K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art21K1 += (int)itemContent.Counts; }
                }
            }            
            foreach (var item in items21K1) // По виду
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { print21K1 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { electr21K1 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { period21K1 += (int)itemView.Counts; }
                }
            }
            string DisYear2021K1 = "Выбыло за 1 кв.2021 г.";
            int totalCountDis21K1 = 0; //Общее количество
            double totalCostDis21K1 = 0; //Общая стоимость
            int naturalDis21K1 = 0; //Естественные науки
            int socialDis21K1 = 0; //Технические науки
            int humanDis21K1 = 0; //Гуманитарные науки
            int metodicalDis21K1 = 0; //Методическая литература
            int referenceDis21K1 = 0; //Справочная литература
            int artDis21K1 = 0; //Художественная литература
            int printDis21K1 = 0; //Печатный вид
            int electrDis21K1 = 0; //Электронный вид
            int periodDis21K1 = 0; //Периодические издания
            var itemss21K1 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= January && x.Date <= March);
            foreach (var item in itemss20)
            {
                totalCountDis21K1 += item.TotalNumber;
                totalCostDis21K1 += item.Cost;
            }            
            foreach (var item in itemss21K1) //По содержанию
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { naturalDis21K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { socialDis21K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { humanDis21K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodicalDis21K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { referenceDis21K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { artDis21K1 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in itemss21K1) // По виду
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатные
                    { printDis21K1 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронные
                    { electrDis21K1 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree) //Периодические издания
                    { periodDis21K1 += (int)itemView.Counts; }
                }
            }

            //2 квартал
            //Состоит на начало 2021 года 
            string BeginningOfTheYear21K2 = "Состоит на 2 кв. 2021 г.";
            int _countBeginingYear21K2 = 0;
            int _costYear21K2 = 0;
            int _naturalYear21K2 = 0;
            int _socialYear21K2 = 0;
            int _humanYear21K2 = 0;
            int _metodicalYear21K2 = 0;
            int _referenceYear21K2 = 0;
            int _artYear21K2 = 0;
            int _printYear21K2 = 0;
            int _electrYear21K2 = 0;
            int _periodYear21K2 = 0;

            _countBeginingYear21K2 = _countBeginingYear21 + totalCount21K1 - totalCountDis21K1;
            _naturalYear21K2 = _naturalYear21 + natural21K1 - naturalDis21K1;
            _socialYear21K2 = _socialYear21 + social21K1 - socialDis21K1;
            _referenceYear21K2 = _referenceYear21 + reference21K1 - referenceDis21K1;
            _humanYear21K2 = _humanYear21 + human21K1 - humanDis21K1;
            _metodicalYear21K2 = _metodicalYear21 + metodical21K1 - metodicalDis21K1;
            _artYear21K2 = _artYear21 + art21K1 - artDis21K1;
            _printYear21K2 = _printYear21 + print21K1 - printDis21K1;
            _electrYear21K2 = _electrYear21 + electr21K1 - electrDis21K1;
            _periodYear21K2 = _periodYear21 + period21K1 - periodDis21K1;

            var items21K2 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= April && x.Date <= June);
            string Year2021K2 = "Поступило за 2 кв. 2021 г.";
            int totalCount21K2 = 0; //Общее количество
            double totalCost21K2 = 0; //Общая стоимость
            int natural21K2 = 0; //Естественные науки
            int social21K2 = 0; //Технические науки
            int human21K2 = 0; //Гуманитарные науки
            int metodical21K2 = 0; //Методическая литература
            int reference21K2 = 0; //Справочная литература
            int art21K2 = 0; //Художественная литература
            int print21K2 = 0; //Печатный вид
            int electr21K2 = 0; //Электронный вид
            int period21K2 = 0; //Периодические издания
            foreach (var item in items21K2)
            {
                totalCount21K2 += item.TotalInstances;
                totalCost21K2 += item.Cost;
            }
            foreach (var item in items21K2)
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { natural21K2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { social21K2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { human21K2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodical21K2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { reference21K2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art21K2 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in items21K2)
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { print21K2 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { electr21K2 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { period21K2 += (int)itemView.Counts; }
                }
            }

            string DisYear2021K2 = "Выбыло за 2 кв.2021 г.";
            int totalCountDis21K2 = 0; //Общее количество
            double totalCostDis21K2 = 0; //Общая стоимость
            int naturalDis21K2 = 0; //Естественные науки
            int socialDis21K2 = 0; //Технические науки
            int humanDis21K2 = 0; //Гуманитарные науки
            int metodicalDis21K2 = 0; //Методическая литература
            int referenceDis21K2 = 0; //Справочная литература
            int artDis21K2 = 0; //Художественная литература
            int printDis21K2 = 0; //Печатный вид
            int electrDis21K2 = 0; //Электронный вид
            int periodDis21K2 = 0; //Периодические издания
            var itemss21K2 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= April && x.Date <= June);
            foreach (var item in itemss21K2)
            {
                totalCountDis21K2 += item.TotalNumber;
                totalCostDis21K2 += item.Cost;
            }
            foreach (var item in itemss21K2) //По содержанию
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { naturalDis21K2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { socialDis21K2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { humanDis21K2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodicalDis21K2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { referenceDis21K2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { artDis21K2 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in itemss21K2) // По виду
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатные
                    { printDis21K2 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронные
                    { electrDis21K2 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree) //Периодические издания
                    { periodDis21K2 += (int)itemView.Counts; }
                }
            }

            //3 квартал
            //Состоит на начало 2021 года 
            string BeginningOfTheYear21K3 = "Состоит на 3 кв. 2021 г.";
            int _countBeginingYear21K3 = 0;
            int _costYear21K3 = 0;
            int _naturalYear21K3 = 0;
            int _socialYear21K3 = 0;
            int _humanYear21K3 = 0;
            int _metodicalYear21K3 = 0;
            int _referenceYear21K3 = 0;
            int _artYear21K3 = 0;
            int _printYear21K3 = 0;
            int _electrYear21K3 = 0;
            int _periodYear21K3 = 0;

            _countBeginingYear21K3 = _countBeginingYear21K2 + totalCount21K2 - totalCountDis21K2;
            _naturalYear21K3 = _naturalYear21K2 + natural21K2 - naturalDis21K2;
            _socialYear21K3 = _socialYear21K2 + social21K2 - socialDis21K2;
            _referenceYear21K3 = _referenceYear21K2 + reference21K2 - referenceDis21K2;
            _humanYear21K3 = _humanYear21K2 + human21K2 - humanDis21K2;
            _metodicalYear21K3 = _metodicalYear21K2 + metodical21K2 - metodicalDis21K2;
            _artYear21K3 = _artYear21K2 + art21K2 - artDis21K2;
            _printYear21K3 = _printYear21K2 + print21K2 - printDis21K2;
            _electrYear21K3 = _electrYear21K2 + electr21K2 - electrDis21K2;
            _periodYear21K3 = _periodYear21K2 + period21K2 - periodDis21K2;

            var items21K3 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= July && x.Date <= September);
            string Year2021K3 = "Поступило за 3 кв. 2021 г.";
            int totalCount21K3 = 0; //Общее количество
            double totalCost21K3 = 0; //Общая стоимость
            int natural21K3 = 0; //Естественные науки
            int social21K3 = 0; //Технические науки
            int human21K3 = 0; //Гуманитарные науки
            int metodical21K3 = 0; //Методическая литература
            int reference21K3 = 0; //Справочная литература
            int art21K3 = 0; //Художественная литература
            int print21K3 = 0; //Печатный вид
            int electr21K3 = 0; //Электронный вид
            int period21K3 = 0; //Периодические издания
            foreach (var item in items21K3)
            {
                totalCount21K3 += item.TotalInstances;
                totalCost21K3 += item.Cost;
            }
            foreach (var item in items21K3)
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { natural21K3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { social21K3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { human21K3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodical21K3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { reference21K3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art21K3 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in items21K3)
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { print21K3 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { electr21K3 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { period21K3 += (int)itemView.Counts; }
                }
            }

            string DisYear2021K3 = "Выбыло за 3 кв.2021 г.";
            int totalCountDis21K3 = 0; //Общее количество
            double totalCostDis21K3 = 0; //Общая стоимость
            int naturalDis21K3 = 0; //Естественные науки
            int socialDis21K3 = 0; //Технические науки
            int humanDis21K3 = 0; //Гуманитарные науки
            int metodicalDis21K3 = 0; //Методическая литература
            int referenceDis21K3 = 0; //Справочная литература
            int artDis21K3 = 0; //Художественная литература
            int printDis21K3 = 0; //Печатный вид
            int electrDis21K3 = 0; //Электронный вид
            int periodDis21K3 = 0; //Периодические издания
            var itemss21K3 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= July && x.Date <= September);
            foreach (var item in itemss21K3)
            {
                totalCountDis21K3 += item.TotalNumber;
                totalCostDis21K3 += item.Cost;
            }
            foreach (var item in itemss21K3) //По содержанию
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { naturalDis21K3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { socialDis21K3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { humanDis21K3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodicalDis21K3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { referenceDis21K3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { artDis21K3 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in itemss21K3) // По виду
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатные
                    { printDis21K3 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронные
                    { electrDis21K3 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree) //Периодические издания
                    { periodDis21K3 += (int)itemView.Counts; }
                }
            }

            //4 квартал
            //Состоит на начало 2021 года 
            string BeginningOfTheYear21K4 = "Состоит на 4 кв. 2021 г.";
            int _countBeginingYear21K4 = 0;
            int _costYear21K4 = 0;
            int _naturalYear21K4 = 0;
            int _socialYear21K4 = 0;
            int _humanYear21K4 = 0;
            int _metodicalYear21K4 = 0;
            int _referenceYear21K4 = 0;
            int _artYear21K4 = 0;
            int _printYear21K4 = 0;
            int _electrYear21K4 = 0;
            int _periodYear21K4 = 0;

            _countBeginingYear21K4 = _countBeginingYear21K3 + totalCount21K3 - totalCountDis21K3;
            _naturalYear21K4 = _naturalYear21K3 + natural21K3 - naturalDis21K3;
            _socialYear21K4 = _socialYear21K3 + social21K2 - socialDis21K3;
            _referenceYear21K4 = _referenceYear21K3 + reference21K3 - referenceDis21K3;
            _humanYear21K4 = _humanYear21K3 + human21K3 - humanDis21K3;
            _metodicalYear21K4 = _metodicalYear21K3 + metodical21K3 - metodicalDis21K3;
            _artYear21K4 = _artYear21K3 + art21K3 - artDis21K3;
            _printYear21K4 = _printYear21K3 + print21K3 - printDis21K3;
            _electrYear21K4 = _electrYear21K3 + electr21K3 - electrDis21K3;
            _periodYear21K4 = _periodYear21K3 + period21K3 - periodDis21K3;

            var items21K4 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= October && x.Date <= December);
            string Year2021K4 = "Поступило за 4 кв. 2021 г.";
            int totalCount21K4 = 0; //Общее количество
            double totalCost21K4 = 0; //Общая стоимость
            int natural21K4 = 0; //Естественные науки
            int social21K4 = 0; //Технические науки
            int human21K4 = 0; //Гуманитарные науки
            int metodical21K4 = 0; //Методическая литература
            int reference21K4 = 0; //Справочная литература
            int art21K4 = 0; //Художественная литература
            int print21K4 = 0; //Печатный вид
            int electr21K4 = 0; //Электронный вид
            int period21K4 = 0; //Периодические издания
            foreach (var item in items21K4)
            {
                totalCount21K4 += item.TotalInstances;
                totalCost21K4 += item.Cost;
            }
            foreach (var item in items21K4)
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { natural21K4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { social21K4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { human21K4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodical21K4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { reference21K4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art21K4 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in items21K4)
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { print21K4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { electr21K4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { period21K4 += (int)itemView.Counts; }
                }
            }

            string DisYear2021K4 = "Выбыло за 4 кв.2021 г.";
            int totalCountDis21K4 = 0; //Общее количество
            double totalCostDis21K4 = 0; //Общая стоимость
            int naturalDis21K4 = 0; //Естественные науки
            int socialDis21K4 = 0; //Технические науки
            int humanDis21K4 = 0; //Гуманитарные науки
            int metodicalDis21K4 = 0; //Методическая литература
            int referenceDis21K4 = 0; //Справочная литература
            int artDis21K4 = 0; //Художественная литература
            int printDis21K4 = 0; //Печатный вид
            int electrDis21K4 = 0; //Электронный вид
            int periodDis21K4 = 0; //Периодические издания
            var itemss21K4 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= October && x.Date <= December);
            foreach (var item in itemss21K4)
            {
                totalCountDis21K4 += item.TotalNumber;
                totalCostDis21K4 += item.Cost;
            }
            foreach (var item in itemss21K4) //По содержанию
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { naturalDis21K4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { socialDis21K4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { humanDis21K4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodicalDis21K4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { referenceDis21K4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { artDis21K4 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in itemss21K4) // По виду
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатные
                    { printDis21K4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронные
                    { electrDis21K4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree) //Периодические издания
                    { periodDis21K4 += (int)itemView.Counts; }
                }
            }


            tbPost.Text = BeginningOfTheYear + " - " + _countBegining + " " + _cost + " " + _natural + " " + _social + " " + _human + " " + _metodical + " " + _reference + " " + _art + " " + _print + " " + _electr + " " + _period;
            tbPt.Text = Year2018 + " - " + totalCount + " " + totalCost + " " + natural + " " + social + " " + human + " " + metodical + " " + reference + " " + art + " " + print + " " + electr + " " + period;           
            
            tbPos.Text = BeginningOfTheYear19 + " - " + _countBeginingYear19 + " " + _costYear19 + " " + _naturalYear19 + " " + _socialYear19 + " " + _humanYear19 + " " + _metodicalYear19 + " " + _referenceYear19 + " " + _artYear19 + " " + _printYear19 + " " + _electrYear19 + " " + _periodYear19;
            tbR19.Text = Year2019 + " - " + totalCount19 + " " + totalCost19 + " " + natural19 + " " + social19 + " " + human19 + " " + metodical19 + " " + reference19 + " " + art19 + " " + print19 + " " + electr19 + " " + period19;           
            tbD19.Text = DisYear2019 + " - " + totalCountDis + " " + totalCostDis + " " + naturalDis + " " + socialDis + " " + humanDis + " " + metodicalDis + " " + referenceDis + " " + artDis + " " + printDis + " " + electrDis + " " + periodDis;

            tbB20.Text = BeginningOfTheYear20 + " - " + _countBeginingYear20 + " " + _costYear20 + " " + _naturalYear20 + " " + _socialYear20 + " " + _humanYear20 + " " + _metodicalYear20 + " " + _referenceYear20 + " " + _artYear20 + " " + _printYear20 + " " + _electrYear20 + " " + _periodYear20; //на начало года 
            tbR20.Text = Year2020 + " - " + totalCount20 + " " + totalCost20 + " " + natural20 + " " + social20 + " " + human20 + " " + metodical20 + " " + reference20 + " " + art20 + " " + print20 + " " + electr20 + " " + period20;
            tbD20.Text = DisYear2020 + " - " + totalCountDis20 + " " + totalCostDis20 + " " + naturalDis20 + " " + socialDis20 + " " + humanDis20 + " " + metodicalDis20 + " " + referenceDis20 + " " + artDis20 + " " + printDis20 + " " + electrDis20 + " " + periodDis20;

            tbB21.Text = BeginningOfTheYear21 + " - " + _countBeginingYear21 + " " + _costYear21 + " " + _naturalYear21 + " " + _socialYear21 + " " + _humanYear21 + " " + _metodicalYear21 + " " + _referenceYear21 + " " + _artYear21 + " " + _printYear21 + " " + _electrYear21 + " " + _periodYear21; //на начало года 
            //tbR1K21.Text = Year2021K1 + " - " + totalCount21K1 + " " + totalCost21K1 + " " + natural21K1 + " " + social21K1 + " " + human21K1 + " " + metodical21K1 + " " + reference21K1 + " " + art21K1 + " " + print21K1 + " " + electr21K1 + " " + period21K1;
            tbD1K21.Text = DisYear2021K1 + " - " + totalCountDis21K1 + " " + totalCostDis21K1 + " " + naturalDis21K1 + " " + socialDis21K1 + " " + humanDis21K1 + " " + metodicalDis21K1 + " " + referenceDis21K1 + " " + artDis21K1 + " " + printDis21K1 + " " + electrDis21K1 + " " + periodDis21K1;


            //tbB21K3
            //tbR3K21
            //tbD3K21

        }

        private void btnResultTwo_Click(object sender, RoutedEventArgs e) // Формирование итогов 2 корпус
        {
            spResultTwo.Visibility = Visibility.Visible;
            //indexx = 2;

        }

        private void btnResultThree_Click(object sender, RoutedEventArgs e) // Формирование итогов 3 корпус
        {
            spResThree.Visibility = Visibility.Visible;
            //indexx = 3;

        }

        private void btnTotalResult_Click(object sender, RoutedEventArgs e) // Формирование итогов всех 3 корпусов
        {
            spResults.Visibility = Visibility.Visible;


        }

        private void tbExport_MouseDown(object sender, MouseButtonEventArgs e) // Экспорт данных по 1 корпусу
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;  // Убедитесь, что вы используете бесплатную лицензию
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet sheet1 = excelPackage.Workbook.Worksheets.Add("Поступление");
                    ExcelWorksheet sheet2 = excelPackage.Workbook.Worksheets.Add("Выбытие");
                    ExcelWorksheet sheet3 = excelPackage.Workbook.Worksheets.Add("Итоги");

                    //запись заголовков и данных первого DataGrid
                    for (int i = 0; i < dgReceipt.Columns.Count; i++)
                    {
                        var columnHeader = dgReceipt.Columns[i].Header.ToString();
                        sheet1.Cells[1, i + 1].Value = columnHeader;
                        sheet1.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
                        sheet1.Cells.Style.Font.Size = 11; //размер шрифта                    
                        sheet1.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                        sheet1.Cells[1, i + 1].Style.WrapText = true;
                        // Выравнивание по центру
                        sheet1.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        sheet1.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        sheet1.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                    }
                    for (int i = 0; i < dgReceipt.Items.Count; i++)
                    {
                        for (int j = 0; j < dgReceipt.Columns.Count; j++)
                        {
                            var value = dgReceipt.Columns[j].GetCellContent(dgReceipt.Items[i]) as TextBlock;
                            if (value != null)
                            {
                                sheet1.Cells[i + 2, j + 1].Value = value.Text;
                                sheet1.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                                sheet1.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                            }
                        }
                    }

                    //запись заголовков и данных второго DataGrid
                    for (int i = 0; i < dgDisposals.Columns.Count; i++)
                    {
                        var columnHeader = dgDisposals.Columns[i].Header.ToString();
                        sheet2.Cells[1, i + 1].Value = columnHeader;
                        sheet2.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
                        sheet2.Cells.Style.Font.Size = 11; //размер шрифта                    
                        sheet2.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                        sheet2.Cells[1, i + 1].Style.WrapText = true;
                        // Выравнивание по центру
                        sheet2.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        sheet2.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        sheet2.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                    }
                    for (int i = 0; i < dgDisposals.Items.Count; i++)
                    {
                        for (int j = 0; j < dgDisposals.Columns.Count; j++)
                        {
                            var value = dgDisposals.Columns[j].GetCellContent(dgDisposals.Items[i]) as TextBlock;
                            if (value != null)
                            {
                                sheet2.Cells[i + 2, j + 1].Value = value.Text;
                                sheet2.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                                sheet2.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                            }
                        }
                    }

                    //запись заголовков и данных третьего DataGrid
                    //for (int i = 0; i < dgResults.Columns.Count; i++)
                    //{
                    //    var columnHeader = dgResults.Columns[i].Header.ToString();
                    //    sheet3.Cells[1, i + 1].Value = columnHeader;
                    //    sheet3.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
                    //    sheet3.Cells.Style.Font.Size = 11; //размер шрифта                    
                    //    sheet3.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                    //    sheet3.Cells[1, i + 1].Style.WrapText = true;
                    //    // Выравнивание по центру
                    //    sheet3.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    //    sheet3.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    //    sheet3.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                    //}
                    //for (int i = 0; i < dgResults.Items.Count; i++)
                    //{
                    //    for (int j = 0; j < dgResults.Columns.Count; j++)
                    //    {
                    //        var value = dgResults.Columns[j].GetCellContent(dgResults.Items[i]) as TextBlock;
                    //        if (value != null)
                    //        {
                    //            sheet3.Cells[i + 2, j + 1].Value = value.Text;
                    //            sheet3.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                    //            sheet3.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                    //        }
                    //    }
                    //}
                    //Сохраните созданный Excel - файл
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = "КСУ 1 корпус"; // Имя по умолчанию
                    saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        var file = new FileInfo(saveFileDialog.FileName);
                        excelPackage.SaveAs(file);
                    }
                    MessageBox.Show("Успешное сохранение файла!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Ошибка сохранения файла:\n" + ex.Message);
            }
        }
        
        private void tbExportTwo_MouseDown(object sender, MouseButtonEventArgs e) // Экспорт данных по 2 корпусу
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;  // Убедитесь, что вы используете бесплатную лицензию
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet sheet1 = excelPackage.Workbook.Worksheets.Add("Поступление");
                ExcelWorksheet sheet2 = excelPackage.Workbook.Worksheets.Add("Выбытие");
                ExcelWorksheet sheet3 = excelPackage.Workbook.Worksheets.Add("Итоги");

                // запись заголовков и данных первого DataGrid
                for (int i = 0; i < dgReceiptTwo.Columns.Count; i++)
                {                    
                    var columnHeader = dgReceiptTwo.Columns[i].Header.ToString();
                    sheet1.Cells[1, i + 1].Value = columnHeader;
                    sheet1.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
                    sheet1.Cells.Style.Font.Size = 11; //размер шрифта                    
                    sheet1.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                    sheet1.Cells[1, i + 1].Style.WrapText = true;
                    // Выравнивание по центру
                    sheet1.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet1.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    sheet1.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                }

                for (int i = 0; i < dgReceiptTwo.Items.Count; i++)
                {
                    for (int j = 0; j < dgReceiptTwo.Columns.Count; j++)
                    {
                        var value = dgReceiptTwo.Columns[j].GetCellContent(dgReceiptTwo.Items[i]) as TextBlock;
                        if (value != null)
                        {
                            sheet1.Cells[i + 2, j + 1].Value = value.Text;
                            sheet1.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                            sheet1.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                        }
                    }
                }

                // запись заголовков и данных второго DataGrid
                for (int i = 0; i < dgDisposalsTwo.Columns.Count; i++)
                {
                    var columnHeader = dgDisposalsTwo.Columns[i].Header.ToString();
                    sheet2.Cells[1, i + 1].Value = columnHeader;
                    sheet2.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
                    sheet2.Cells.Style.Font.Size = 11; //размер шрифта                    
                    sheet2.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                    sheet2.Cells[1, i + 1].Style.WrapText = true;
                    // Выравнивание по центру
                    sheet2.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet2.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    sheet2.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                }

                for (int i = 0; i < dgDisposalsTwo.Items.Count; i++)
                {
                    for (int j = 0; j < dgDisposalsTwo.Columns.Count; j++)
                    {
                        var value = dgDisposalsTwo.Columns[j].GetCellContent(dgDisposalsTwo.Items[i]) as TextBlock;
                        if (value != null)
                        {
                            sheet2.Cells[i + 2, j + 1].Value = value.Text;
                            sheet2.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                            sheet2.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                        }
                    }
                }

                // запись заголовков и данных третьего DataGrid
                for (int i = 0; i < dgResultsTwo.Columns.Count; i++)
                {
                    var columnHeader = dgResultsTwo.Columns[i].Header.ToString();
                    sheet3.Cells[1, i + 1].Value = columnHeader;
                    sheet3.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
                    sheet3.Cells.Style.Font.Size = 11; //размер шрифта                    
                    sheet3.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                    sheet3.Cells[1, i + 1].Style.WrapText = true;
                    // Выравнивание по центру
                    sheet3.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet3.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    sheet2.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                }
                for (int i = 0; i < dgResultsTwo.Items.Count; i++)
                {
                    for (int j = 0; j < dgResultsTwo.Columns.Count; j++)
                    {
                        var value = dgResultsTwo.Columns[j].GetCellContent(dgResultsTwo.Items[i]) as TextBlock;
                        if (value != null)
                        {
                            sheet3.Cells[i + 2, j + 1].Value = value.Text;
                            sheet3.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                            sheet3.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                        }
                    }
                }
                // Сохраните созданный Excel-файл
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "КСУ 2 корпус"; // Имя по умолчанию
                saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    var file = new FileInfo(saveFileDialog.FileName);
                    excelPackage.SaveAs(file);
                }
                MessageBox.Show("Успешное сохранение файла!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void tbExportResults_MouseDown(object sender, MouseButtonEventArgs e) // Экспорт данных по всем корпусам
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;  // Убедитесь, что вы используете бесплатную лицензию
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet sheet1 = excelPackage.Workbook.Worksheets.Add("Поступление");
                ExcelWorksheet sheet2 = excelPackage.Workbook.Worksheets.Add("Выбытие");
                ExcelWorksheet sheet3 = excelPackage.Workbook.Worksheets.Add("Итоги");

                // запись заголовков и данных первого DataGrid
                for (int i = 0; i < dgReceiptResult.Columns.Count; i++)
                {
                    var columnHeader = dgReceiptResult.Columns[i].Header.ToString();
                    sheet1.Cells[1, i + 1].Value = columnHeader;
                    sheet1.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
                    sheet1.Cells.Style.Font.Size = 11; //размер шрифта                    
                    sheet1.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                    sheet1.Cells[1, i + 1].Style.WrapText = true;
                    // Выравнивание по центру
                    sheet1.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet1.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    sheet1.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                }

                for (int i = 0; i < dgReceiptResult.Items.Count; i++)
                {
                    for (int j = 0; j < dgReceiptResult.Columns.Count; j++)
                    {
                        var value = dgReceiptResult.Columns[j].GetCellContent(dgReceiptResult.Items[i]) as TextBlock;
                        if (value != null)
                        {
                            sheet1.Cells[i + 2, j + 1].Value = value.Text;
                            sheet1.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                            sheet1.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                        }
                    }
                }

                // запись заголовков и данных второго DataGrid
                for (int i = 0; i < dgDisposalsResults.Columns.Count; i++)
                {
                    var columnHeader = dgDisposalsResults.Columns[i].Header.ToString();
                    sheet2.Cells[1, i + 1].Value = columnHeader;
                    sheet2.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
                    sheet2.Cells.Style.Font.Size = 11; //размер шрифта                    
                    sheet2.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                    sheet2.Cells[1, i + 1].Style.WrapText = true;
                    // Выравнивание по центру
                    sheet2.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet2.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    sheet2.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                }

                for (int i = 0; i < dgDisposalsResults.Items.Count; i++)
                {
                    for (int j = 0; j < dgDisposalsResults.Columns.Count; j++)
                    {
                        var value = dgDisposalsResults.Columns[j].GetCellContent(dgDisposalsResults.Items[i]) as TextBlock;
                        if (value != null)
                        {
                            sheet2.Cells[i + 2, j + 1].Value = value.Text;
                            sheet2.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                            sheet2.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                        }
                    }
                }

                // запись заголовков и данных третьего DataGrid
                for (int i = 0; i < dgTotalResults.Columns.Count; i++)
                {
                    var columnHeader = dgTotalResults.Columns[i].Header.ToString();
                    sheet3.Cells[1, i + 1].Value = columnHeader;
                    sheet3.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
                    sheet3.Cells.Style.Font.Size = 11; //размер шрифта                    
                    sheet3.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                    sheet3.Cells[1, i + 1].Style.WrapText = true;
                    // Выравнивание по центру
                    sheet3.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet3.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    sheet3.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                }
                for (int i = 0; i < dgTotalResults.Items.Count; i++)
                {
                    for (int j = 0; j < dgTotalResults.Columns.Count; j++)
                    {
                        var value = dgTotalResults.Columns[j].GetCellContent(dgTotalResults.Items[i]) as TextBlock;
                        if (value != null)
                        {
                            sheet3.Cells[i + 2, j + 1].Value = value.Text;
                            sheet3.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                            sheet3.Cells[i + 2, j + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                        }
                    }
                }
                // Сохраните созданный Excel-файл
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "КСУ библитечного фонда"; // Имя по умолчанию
                saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    var file = new FileInfo(saveFileDialog.FileName);
                    excelPackage.SaveAs(file);
                }
                MessageBox.Show("Успешное сохранение файла!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void tbExportThree_MouseDown(object sender, MouseButtonEventArgs e) // Экспорт данных по 3 корпусу
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;  // Убедитесь, что вы используете бесплатную лицензию
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet sheet1 = excelPackage.Workbook.Worksheets.Add("Поступление");
                ExcelWorksheet sheet2 = excelPackage.Workbook.Worksheets.Add("Выбытие");
                ExcelWorksheet sheet3 = excelPackage.Workbook.Worksheets.Add("Итоги");

                // запись заголовков и данных первого DataGrid
                for (int i = 0; i < dgReceiptThree.Columns.Count; i++)
                {
                    var columnHeader = dgReceiptThree.Columns[i].Header.ToString();
                    sheet1.Cells[1, i + 1].Value = columnHeader;
                    sheet1.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
                    sheet1.Cells.Style.Font.Size = 11; //размер шрифта                    
                    sheet1.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                    sheet1.Cells[1, i + 1].Style.WrapText = true;
                    // Выравнивание по центру
                    sheet1.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet1.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    sheet1.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                }

                for (int i = 0; i < dgReceiptThree.Items.Count; i++)
                {
                    for (int j = 0; j < dgReceiptThree.Columns.Count; j++)
                    {
                        var value = dgReceiptThree.Columns[j].GetCellContent(dgReceiptThree.Items[i]) as TextBlock;
                        if(value != null)
                        {
                            sheet1.Cells[i + 2, j + 1].Value = value.Text;
                            sheet1.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                            sheet1.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                        }                       
                    }
                }               

                // запись заголовков и данных второго DataGrid
                for (int i = 0; i < dgDisposalsThree.Columns.Count; i++)
                {
                    var columnHeader = dgDisposalsThree.Columns[i].Header.ToString();
                    sheet2.Cells[1, i + 1].Value = columnHeader;
                    sheet2.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
                    sheet2.Cells.Style.Font.Size = 11; //размер шрифта                    
                    sheet2.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                    sheet2.Cells[1, i + 1].Style.WrapText = true;
                    // Выравнивание по центру
                    sheet2.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet2.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    sheet2.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                }

                for (int i = 0; i < dgDisposalsThree.Items.Count; i++)
                {
                    for (int j = 0; j < dgDisposalsThree.Columns.Count; j++)
                    {
                        var value = dgDisposalsThree.Columns[j].GetCellContent(dgDisposalsThree.Items[i]) as TextBlock;
                        if( value != null)
                        {
                            sheet2.Cells[i + 2, j + 1].Value = value.Text;
                            sheet2.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                            sheet2.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                        }                        
                    }
                }

                // запись заголовков и данных третьего DataGrid
                for (int i = 0; i < dgResultsThree.Columns.Count; i++)
                {
                    var columnHeader = dgResultsThree.Columns[i].Header.ToString();
                    sheet3.Cells[1, i + 1].Value = columnHeader;
                    sheet3.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
                    sheet3.Cells.Style.Font.Size = 11; //размер шрифта                    
                    sheet3.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                    sheet3.Cells[1, i + 1].Style.WrapText = true;
                    // Выравнивание по центру
                    sheet3.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet3.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    sheet3.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                    sheet3.Cells[i, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }
                for (int i = 0; i < dgResultsThree.Items.Count; i++)
                {
                    for (int j = 0; j < dgResultsThree.Columns.Count; j++)
                    {
                        var value = dgResultsThree.Columns[j].GetCellContent(dgResultsThree.Items[i]) as TextBlock;
                        if (value != null)
                        {
                            sheet3.Cells[i + 2, j + 1].Value = value.Text;
                            sheet3.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                            sheet3.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                        }
                    }
                }
                // Сохраните созданный Excel-файл
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "КСУ 3 корпус"; // Имя по умолчанию
                saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    var file = new FileInfo(saveFileDialog.FileName);
                    excelPackage.SaveAs(file);
                }
                MessageBox.Show("Успешное сохранение файла!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnDeleteDisposals_Click(object sender, RoutedEventArgs e) // Удаление данных из таблицы Выбытие 1 корпуса
        {
            // Получаем выбранный элемент
            var selectedItem = dgDisposals.SelectedItem as Disposals;
            if (selectedItem != null)
            {
                // Спрашиваем у пользователя подтверждение удаления
                var result = MessageBox.Show($"Вы уверены, что хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // Удаляем элемент из источника данных
                    DataBase.Base.Disposals.Remove(selectedItem);
                    DataBase.Base.SaveChanges();

                    // Обновляем содержимое DataGrid
                    dgDisposals.ItemsSource = DataBase.Base.Disposals.ToList();
                }
            }
        }

        private void btnDeleteReceipts_Click(object sender, RoutedEventArgs e) // Удаление данных из таблицы Поступления 1 корпуса
        {
            // Получаем выбранный элемент
            var selectedItem = dgReceipt.SelectedItem as Receipts;
            if (selectedItem != null)
            {
                // Спрашиваем у пользователя подтверждение удаления
                var result = MessageBox.Show($"Вы уверены, что хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // Удаляем элемент из источника данных
                    DataBase.Base.Receipts.Remove(selectedItem);
                    DataBase.Base.SaveChanges();

                    // Обновляем содержимое DataGrid
                    dgReceipt.ItemsSource = DataBase.Base.Receipts.ToList();
                }
            }
        }

        private void btnDeleteReceiptsTwo_Click(object sender, RoutedEventArgs e) // Удаление данных из таблицы Поступления 2 корпуса
        {
            // Получаем выбранный элемент
            var selectedItem = dgReceiptTwo.SelectedItem as Receipts;
            if (selectedItem != null)
            {
                // Спрашиваем у пользователя подтверждение удаления
                var result = MessageBox.Show($"Вы уверены, что хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // Удаляем элемент из источника данных
                    DataBase.Base.Receipts.Remove(selectedItem);
                    DataBase.Base.SaveChanges();

                    // Обновляем содержимое DataGrid
                    dgReceiptTwo.ItemsSource = DataBase.Base.Receipts.ToList();
                }
            }
        }

        private void btnDeleteReceiptsThree_Click(object sender, RoutedEventArgs e) // Удаление данных из таблицы Поступления 3 корпуса
        {
            // Получаем выбранный элемент
            var selectedItem = dgReceiptThree.SelectedItem as Receipts;
            if (selectedItem != null)
            {
                // Спрашиваем у пользователя подтверждение удаления
                var result = MessageBox.Show($"Вы уверены, что хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // Удаляем элемент из источника данных
                    DataBase.Base.Receipts.Remove(selectedItem);
                    DataBase.Base.SaveChanges();

                    // Обновляем содержимое DataGrid
                    dgReceiptThree.ItemsSource = DataBase.Base.Receipts.ToList();
                }
            }
        }

        private void btnDeleteDisposalsTwo_Click(object sender, RoutedEventArgs e) // Удаление данных из таблицы Выбытие 2 корпуса
        {
            // Получаем выбранный элемент
            var selectedItem = dgDisposalsTwo.SelectedItem as Disposals;
            if (selectedItem != null)
            {
                // Спрашиваем у пользователя подтверждение удаления
                var result = MessageBox.Show($"Вы уверены, что хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // Удаляем элемент из источника данных
                    DataBase.Base.Disposals.Remove(selectedItem);
                    DataBase.Base.SaveChanges();

                    // Обновляем содержимое DataGrid
                    dgDisposalsTwo.ItemsSource = DataBase.Base.Disposals.ToList();
                }
            }
        }

        private void btnDeleteDisposalsThree_Click(object sender, RoutedEventArgs e) // Удаление данных из таблицы Выбытие 3 корпуса
        {
            // Получаем выбранный элемент
            var selectedItem = dgDisposalsThree.SelectedItem as Disposals;
            if (selectedItem != null)
            {
                // Спрашиваем у пользователя подтверждение удаления
                var result = MessageBox.Show($"Вы уверены, что хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // Удаляем элемент из источника данных
                    DataBase.Base.Disposals.Remove(selectedItem);
                    DataBase.Base.SaveChanges();

                    // Обновляем содержимое DataGrid
                    dgDisposalsThree.ItemsSource = DataBase.Base.Disposals.ToList();
                }
            }
        }
    }
}
