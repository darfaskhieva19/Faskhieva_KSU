using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using static KSU.ClassResultThree;
using static KSU.ClassResultTwo;

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

            // Создаем экземпляр класса
            ClassResultsOne data = new ClassResultsOne();
            // Создаем экземпляр ObservableCollection на основе списка объектов в классе MyDataClass
            ObservableCollection<Results> dataItems = new ObservableCollection<Results>(data.DataList);
            // Устанавливаем источник данных для DataGrid
            dgResults .ItemsSource = dataItems;

            // 2 Корпус
            dgReceiptTwo.ItemsSource = DataBase.Base.Receipts.Where(z => z.IdEnclosures == 2).ToList();
            dgDisposalsTwo.ItemsSource = DataBase.Base.Disposals.Where(z => z.IdEnclosures == 2).ToList();

            // Создаем экземпляр класса
            ClassResultTwo dataTwo = new ClassResultTwo();
            // Создаем экземпляр ObservableCollection на основе списка объектов в классе MyDataClass
            ObservableCollection<ResultsTwo> dataItemsTwo = new ObservableCollection<ResultsTwo>(dataTwo.DataList);
            // Устанавливаем источник данных для DataGrid
            dgResultsTwo.ItemsSource = dataItemsTwo;

            // 3 Корпус
            dgReceiptThree.ItemsSource = DataBase.Base.Receipts.Where(z => z.IdEnclosures == 3).ToList();
            dgDisposalsThree.ItemsSource = DataBase.Base.Disposals.Where(z => z.IdEnclosures == 3).ToList();

            // Создаем экземпляр класса
            ClassResultThree dataThree = new ClassResultThree();
            // Создаем экземпляр ObservableCollection на основе списка объектов в классе MyDataClass
            ObservableCollection<ResultsThree> dataItemsThree = new ObservableCollection<ResultsThree>(dataThree.DataList);
            // Устанавливаем источник данных для DataGrid
            dgResultsThree.ItemsSource = dataItemsThree;

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
            } //Зимняя тема
            else if (March <= DateTime.Today && DateTime.Today <= May)
            {
                var uri = new Uri(@"Themes\SpringTheme.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                // очищаем коллекцию ресурсов приложения
                Application.Current.Resources.Clear();
                // добавляем загруженный словарь ресурсов
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            } //Весенняя тема
            else if (June <= DateTime.Today && DateTime.Today <= August)
            {
                var uri = new Uri(@"Themes\SummerTheme.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                // очищаем коллекцию ресурсов приложения
                Application.Current.Resources.Clear();
                // добавляем загруженный словарь ресурсов
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            } //Летняя тема
            else if (September <= DateTime.Today && DateTime.Today <= November)
            {
                var uri = new Uri(@"Themes\AutumnTheme.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                // очищаем коллекцию ресурсов приложения
                Application.Current.Resources.Clear();
                // добавляем загруженный словарь ресурсов
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            } //Осенняя тема
        }

        //Метод для раскрашивания строк DataGrid
        private void dgReceipt_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Receipts receipts = (Receipts)e.Row.DataContext;
            DateTime date = receipts.Date;
            int year = date.Year;
            var brush = new BrushConverter();
            if (year <= 2018)
            { e.Row.Background = (SolidColorBrush)(Brush)brush.ConvertFrom("#F2F3B1"); }
            else if (year <= 2019 && year <= 2024)
            { e.Row.Background = (SolidColorBrush)(Brush)brush.ConvertFrom("#BEF3B1"); }
            else if ((year <= 2020 && year <= 2025))
            {  e.Row.Background = (SolidColorBrush)(Brush)brush.ConvertFrom("#B1C7F3"); }
            else if (year <= 2021 && year <= 2026)
            { e.Row.Background = (SolidColorBrush)(Brush)brush.ConvertFrom("#F3DDB1"); }
            else if (year <= 2022)
            { e.Row.Background = (SolidColorBrush)(Brush)brush.ConvertFrom("#BEF3B1"); }
            else if (year <= 2023)
            { e.Row.Background = (SolidColorBrush)(Brush)brush.ConvertFrom("#F2F3B1"); }
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
                    if (saveFileDialog.ShowDialog() == true) //Сохранение файла  
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
                //for (int i = 0; i < dgResultsTwo.Columns.Count; i++)
                //{
                //    var columnHeader = dgResultsTwo.Columns[i].Header.ToString();
                //    sheet3.Cells[1, i + 1].Value = columnHeader;
                //    sheet3.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
                //    sheet3.Cells.Style.Font.Size = 11; //размер шрифта                    
                //    sheet3.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                //    sheet3.Cells[1, i + 1].Style.WrapText = true;
                //    // Выравнивание по центру
                //    sheet3.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                //    sheet3.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                //    sheet2.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                //}
                //for (int i = 0; i < dgResultsTwo.Items.Count; i++)
                //{
                //    for (int j = 0; j < dgResultsTwo.Columns.Count; j++)
                //    {
                //        var value = dgResultsTwo.Columns[j].GetCellContent(dgResultsTwo.Items[i]) as TextBlock;
                //        if (value != null)
                //        {
                //            sheet3.Cells[i + 2, j + 1].Value = value.Text;
                //            sheet3.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                //            sheet3.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                //        }
                //    }
                //}
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
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;  // Убедитесь, что вы используете бесплатную лицензию
            //using (ExcelPackage excelPackage = new ExcelPackage())
            //{
            //    ExcelWorksheet sheet1 = excelPackage.Workbook.Worksheets.Add("Поступление");
            //    ExcelWorksheet sheet2 = excelPackage.Workbook.Worksheets.Add("Выбытие");
            //    ExcelWorksheet sheet3 = excelPackage.Workbook.Worksheets.Add("Итоги");

            //    // запись заголовков и данных первого DataGrid
            //    for (int i = 0; i < dgReceiptResult.Columns.Count; i++)
            //    {
            //        var columnHeader = dgReceiptResult.Columns[i].Header.ToString();
            //        sheet1.Cells[1, i + 1].Value = columnHeader;
            //        sheet1.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
            //        sheet1.Cells.Style.Font.Size = 11; //размер шрифта                    
            //        sheet1.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
            //        sheet1.Cells[1, i + 1].Style.WrapText = true;
            //        // Выравнивание по центру
            //        sheet1.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //        sheet1.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //        sheet1.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
            //    }

            //    for (int i = 0; i < dgReceiptResult.Items.Count; i++)
            //    {
            //        for (int j = 0; j < dgReceiptResult.Columns.Count; j++)
            //        {
            //            var value = dgReceiptResult.Columns[j].GetCellContent(dgReceiptResult.Items[i]) as TextBlock;
            //            if (value != null)
            //            {
            //                sheet1.Cells[i + 2, j + 1].Value = value.Text;
            //                sheet1.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
            //                sheet1.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
            //            }
            //        }
            //    }

            //    // запись заголовков и данных второго DataGrid
            //    for (int i = 0; i < dgDisposalsResults.Columns.Count; i++)
            //    {
            //        var columnHeader = dgDisposalsResults.Columns[i].Header.ToString();
            //        sheet2.Cells[1, i + 1].Value = columnHeader;
            //        sheet2.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
            //        sheet2.Cells.Style.Font.Size = 11; //размер шрифта                    
            //        sheet2.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
            //        sheet2.Cells[1, i + 1].Style.WrapText = true;
            //        // Выравнивание по центру
            //        sheet2.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //        sheet2.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //        sheet2.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
            //    }

            //    for (int i = 0; i < dgDisposalsResults.Items.Count; i++)
            //    {
            //        for (int j = 0; j < dgDisposalsResults.Columns.Count; j++)
            //        {
            //            var value = dgDisposalsResults.Columns[j].GetCellContent(dgDisposalsResults.Items[i]) as TextBlock;
            //            if (value != null)
            //            {
            //                sheet2.Cells[i + 2, j + 1].Value = value.Text;
            //                sheet2.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
            //                sheet2.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
            //            }
            //        }
            //    }

            //    // запись заголовков и данных третьего DataGrid
            //    for (int i = 0; i < dgTotalResults.Columns.Count; i++)
            //    {
            //        var columnHeader = dgTotalResults.Columns[i].Header.ToString();
            //        sheet3.Cells[1, i + 1].Value = columnHeader;
            //        sheet3.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
            //        sheet3.Cells.Style.Font.Size = 11; //размер шрифта                    
            //        sheet3.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
            //        sheet3.Cells[1, i + 1].Style.WrapText = true;
            //        // Выравнивание по центру
            //        sheet3.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //        sheet3.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //        sheet3.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
            //    }
            //    for (int i = 0; i < dgTotalResults.Items.Count; i++)
            //    {
            //        for (int j = 0; j < dgTotalResults.Columns.Count; j++)
            //        {
            //            var value = dgTotalResults.Columns[j].GetCellContent(dgTotalResults.Items[i]) as TextBlock;
            //            if (value != null)
            //            {
            //                sheet3.Cells[i + 2, j + 1].Value = value.Text;
            //                sheet3.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
            //                sheet3.Cells[i + 2, j + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
            //            }
            //        }
            //    }
            //    // Сохраните созданный Excel-файл
            //    SaveFileDialog saveFileDialog = new SaveFileDialog();
            //    saveFileDialog.FileName = "КСУ библитечного фонда"; // Имя по умолчанию
            //    saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            //    if (saveFileDialog.ShowDialog() == true)
            //    {
            //        var file = new FileInfo(saveFileDialog.FileName);
            //        excelPackage.SaveAs(file);
            //    }
            //    MessageBox.Show("Успешное сохранение файла!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
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
                //for (int i = 0; i < dgResultsThree.Columns.Count; i++)
                //{
                //    var columnHeader = dgResultsThree.Columns[i].Header.ToString();
                //    sheet3.Cells[1, i + 1].Value = columnHeader;
                //    sheet3.Cells[1, i + 1].Style.Font.Bold = true; // делаем шрифт жирным
                //    sheet3.Cells.Style.Font.Size = 11; //размер шрифта                    
                //    sheet3.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                //    sheet3.Cells[1, i + 1].Style.WrapText = true;
                //    // Выравнивание по центру
                //    sheet3.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                //    sheet3.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                //    sheet3.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                //    sheet3.Cells[i, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                //}
                //for (int i = 0; i < dgResultsThree.Items.Count; i++)
                //{
                //    for (int j = 0; j < dgResultsThree.Columns.Count; j++)
                //    {
                //        var value = dgResultsThree.Columns[j].GetCellContent(dgResultsThree.Items[i]) as TextBlock;
                //        if (value != null)
                //        {
                //            sheet3.Cells[i + 2, j + 1].Value = value.Text;
                //            sheet3.Cells.AutoFitColumns(); // Автоматически изменяем ширину столбцов на основе содержимого каждой ячейки
                //            sheet3.Cells[1, i + 1].Style.Font.Name = "Times New Roman"; // задаем имя шрифта
                //        }
                //    }
                //}
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
