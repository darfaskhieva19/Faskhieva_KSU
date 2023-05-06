using System;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;


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
            dgDisposalsTwo.ItemsSource = DataBase.Base.Disposals.Where(z => z.IdEnclosures == 2).ToList();
            dgResultsTwo.ItemsSource = DataBase.Base.Results.Where(z => z.IdEnclosures == 2).ToList();

            // 3 Корпус
            dgReceiptThree.ItemsSource = DataBase.Base.Receipts.Where(z => z.IdEnclosures == 3).ToList();
            dgDisposalsThree.ItemsSource = DataBase.Base.Disposals.Where(z => z.IdEnclosures == 3).ToList();
            dgResultsThree.ItemsSource = DataBase.Base.Results.Where(z => z.IdEnclosures == 3).ToList();

            // Все корпуса
            dgReceiptResult.ItemsSource = DataBase.Base.Receipts.OrderBy(x => x.Date).ToList();
            dgDisposalsResults.ItemsSource = DataBase.Base.Disposals.OrderBy(x => x.Date).ToList();
            dgTotalResults.ItemsSource = DataBase.Base.Results.ToList();

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

        private void ExportToExcel()
        {
            
        }

        private void tbExport_MouseDown(object sender, MouseButtonEventArgs e) // Экспорт данных по 1 корпусу
        {
                try
                {
                    // Создаем новый файл Excel
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = true;
                    Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                    Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                    Microsoft.Office.Interop.Excel.Worksheet sheet2 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[2];
                    Microsoft.Office.Interop.Excel.Worksheet sheet3 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[3];
                    sheet1.Name = "Поступление";
                    // Добавляем заголовки столбцов
                    for (int i = 0; i < dgReceiptTwo.Columns.Count; i++)
                    {
                        sheet1.Cells[1, i + 1] = dgReceiptTwo.Columns[i].Header;
                    }
                    // Добавление данных из DataGrid1
                    for (int i = 0; i < dgReceipt.Items.Count; i++)
                    {
                        for (int j = 0; j < dgReceipt.Columns.Count; j++)
                        {
                            string columnName = dgReceipt.Columns[j].Header.ToString();
                            Binding binding = (dgReceipt.Columns[j].ClipboardContentBinding as Binding);
                            PropertyInfo pi = dgReceipt.Items[i].GetType().GetProperty(binding.Path.Path);
                            string value = pi.GetValue(dgReceipt.Items[i], null).ToString();
                        }

                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Ошибка сохранения файла:\n" + ex.Message);
                }
        }

        private void tbExportTwo_MouseDown(object sender, MouseButtonEventArgs e) // Экспорт данных по 2 корпусу
        {
            // Создаем новый файл Excel
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Worksheet sheet2 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[2];
            Microsoft.Office.Interop.Excel.Worksheet sheet3 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[3];

            sheet1.Name = "Поступление";
            // Добавляем заголовки столбцов
            for (int i = 0; i < dgReceiptTwo.Columns.Count; i++)
            {
                sheet1.Cells[1, i + 1] = dgReceiptTwo.Columns[i].Header;
            }
            // Добавляем данные из DataGrid
            for (int i = 0; i < dgReceiptTwo.Items.Count; i++)
            {
                for (int j = 0; j < dgReceiptTwo.Columns.Count; j++)
                {
                    TextBlock b = dgReceiptTwo.Columns[j].GetCellContent(dgReceiptTwo.Items[i]) as TextBlock;
                    if (b != null)
                    {
                        sheet1.Cells[i + 2, j + 1] = b.Text;
                    }
                }
            }
            //sheet2.Name = "Выбытие";
            //// Добавляем заголовки столбцов
            //for (int i = 0; i < dgDisposalsTwo.Columns.Count; i++)
            //{
            //    sheet2.Cells[1, i + 1] = dgDisposalsTwo.Columns[i].Header;
            //}
            //// Добавляем данные из DataGrid
            //for (int i = 0; i < dgReceiptTwo.Items.Count; i++)
            //{
            //    for (int j = 0; j < dgDisposalsTwo.Columns.Count; j++)
            //    {
            //        TextBlock b = dgDisposalsTwo.Columns[j].GetCellContent(dgDisposalsTwo.Items[i]) as TextBlock;
            //        if (b != null)
            //        {
            //            sheet2.Cells[i + 2, j + 1] = b.Text;
            //        }
            //    }
            //}

            //sheet3.Name = "Итоги";
            //// Добавляем заголовки столбцов
            //for (int i = 0; i < dgResultsTwo.Columns.Count; i++)
            //{
            //    sheet2.Cells[1, i + 1] = dgResultsTwo.Columns[i].Header;
            //}
            //// Добавляем данные из DataGrid
            //for (int i = 0; i < dgResultsTwo.Items.Count; i++)
            //{
            //    for (int j = 0; j < dgResultsTwo.Columns.Count; j++)
            //    {
            //        TextBlock b = dgResultsTwo.Columns[j].GetCellContent(dgResultsTwo.Items[i]) as TextBlock;
            //        if (b != null)
            //        {
            //            sheet3.Cells[i + 2, j + 1] = b.Text;
            //        }
            //    }
            //}

            // Авто-размерим столбцы
            Microsoft.Office.Interop.Excel.Range range = sheet1.UsedRange;
            range.Cells.Font.Name = "Times New Roman";  // Шрифт для диапазона
            range.Cells.Font.Size = 10; // Размер шрифта для диапазона
            range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.EntireColumn.AutoFit();
            //Microsoft.Office.Interop.Excel.Range range2 = sheet2.UsedRange;
            //range2.EntireColumn.AutoFit();
            //Microsoft.Office.Interop.Excel.Range range3 = sheet3.UsedRange;
            //range3.EntireColumn.AutoFit();

            // Сохраняем файл
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "КСУ 2 корпус"; // Имя по умолчанию
            dlg.DefaultExt = ".xlsx"; // Формат файла Excel
            dlg.Filter = "Excel documents (.xlsx)|*.xlsx"; // Фильтр для сохранения
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                workbook.SaveAs(filename);
                excel.Quit();
            }


            //Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            //Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
            //Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.Worksheets[1];
            ////foreach (DataRow row in dgReceiptTwo.ItemsSource)
            ////{
            ////    for (int j = 0; j < dgReceiptTwo.Columns.Count; j++)
            ////    {
            ////        excelWorksheet.Cells[i + 1, j + 1] = dgReceiptTwo[i].Cells[j].Value;
            ////    }
            ////}

            //for (int j = 0; j < dgReceiptTwo.Columns.Count; j++)
            //{
            //    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)excelWorksheet.Cells[1, j + 1];
            //    excelWorksheet.Cells[1, j + 1].Font.Bold = true;
            //    excelWorksheet.Columns[j + 1].ColumnWidth = 15;
            //    myRange.Value2 = dgReceiptTwo.Columns[j].Header;
            //}

            //for (int i = 0; i < dgReceiptTwo.Items.Count; i++)
            //{
            //    for (int j = 0; j < dgReceiptTwo.Columns.Count; j++)
            //    {
            //        excelWorksheet.Cells[i + 1, j + 1] = dgReceiptTwo.Columns[j].GetCellContent(dgReceiptTwo.Items[i]).Parent as DataGridCell;


            //        //// Получаем ячейку с указанными координатами
            //        //var cell = dgReceiptTwo.Columns[j].GetCellContent(dgReceiptTwo.Items[row]).Parent as DataGridCell;
            //        //if (cell != null)
            //        //{
            //        //    // Обрабатываем ячейку
            //        //    // ...
            //        //}
            //    }
            //}

            //excelWorkbook.SaveAs("КСУ 2 корпус.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
            //excelWorkbook.Close(true, Type.Missing, Type.Missing);
            //excelApp.Quit();

            //for (int j = 0; j < dgReceiptTwo.Columns.Count; j++) 
            //{
            //    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, j + 1];
            //    worksheet.Cells[1, j + 1].Font.Bold = true;
            //    worksheet.Columns[j + 1].ColumnWidth = 15;
            //    myRange.Value2 = dgReceiptTwo.Columns[j].Header;
            //}

            //List<Receipts> receipts = DataBase.Base.Receipts.Where(z => z.IdEnclosures == 2).ToList();

            //for (int i = 0; i < receipts.Count; i++)
            //{
            //    for(int j = 0;j < dgReceiptTwo.Columns.Count; j++)
            //    {
            //        excelapp.Cells[i + 1, 1] = receipts[i].dateReceipts;
            //        excelapp.Cells[i + 1, 2] = receipts[i].NumberInOrder;
            //        excelapp.Cells[i + 1, 3] = receipts[i].Istochik;
            //        excelapp.Cells[i + 1, 4] = receipts[i].IstochikK;
            //        excelapp.Cells[i + 1, 5] = receipts[i].Ins;
            //        excelapp.Cells[i + 1, 6] = receipts[i].Total;
            //        excelapp.Cells[i + 1, 7] = receipts[i].Inst;
            //        excelapp.Cells[i + 1, 8] = receipts[i].InstCost;
            //        excelapp.Cells[i + 1, 9] = receipts[i].NotBalance;
            //        excelapp.Cells[i + 1, 10] = receipts[i].NaturalS;
            //        excelapp.Cells[i + 1, 11] = receipts[i].SocialS;
            //        excelapp.Cells[i + 1, 12] = receipts[i].HumanitarianS;
            //        excelapp.Cells[i + 1, 13] = receipts[i].MetodicalS;
            //        excelapp.Cells[i + 1, 14] = receipts[i].ReferenceLiteratureS;
            //        excelapp.Cells[i + 1, 15] = receipts[i].ArtS;
            //        excelapp.Cells[i + 1, 16] = receipts[i].printedR;
            //        excelapp.Cells[i + 1, 17] = receipts[i].electr;
            //        excelapp.Cells[i + 1, 18] = receipts[i].periodich;

            //        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[j + 2, i + 1];
            //        myRange.Value2 = dgReceiptTwo;
            //    }

            //}
            //excelapp.AlertBeforeOverwriting = false;
            //workbook.SaveAs(path);
            //excelapp.Quit();
        }

        private void tbExportResults_MouseDown(object sender, MouseButtonEventArgs e) // Экспорт данных по всем корпусам
        {

        }

        private void tbExportThree_MouseDown(object sender, MouseButtonEventArgs e) // Экспорт данных по 3 корпусу
        {

        }
    }
}
