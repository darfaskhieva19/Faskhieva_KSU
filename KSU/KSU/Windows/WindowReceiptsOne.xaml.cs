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
    /// Логика взаимодействия для WindowReceiptsOne.xaml
    /// </summary>
    public partial class WindowReceiptsOne : Window
    {
        Receipts receipts;
        bool flag = false;
        public WindowReceiptsOne()
        {
            InitializeComponent();
            listFild();
        }
        public WindowReceiptsOne(Receipts receipts) // Конструктор для редактирования
        {
            InitializeComponent();
            this.receipts = receipts;
            flag = true;

            lbContent.ItemsSource = DataBase.Base.Contents.ToList();
            lbViews.ItemsSource = DataBase.Base.Views.ToList();

            List<SourceOfAcquisition> sourceOfAcquisitions = DataBase.Base.SourceOfAcquisition.ToList();
            cbSourceOfAcquisition.Items.Add("не выбрано");
            for (var i = 0; i < sourceOfAcquisitions.Count; i++)
            {
                cbSourceOfAcquisition.Items.Add(sourceOfAcquisitions[i].Kind);
            }
            cbSourceOfAcquisition.SelectedIndex = receipts.IdSourceOfAcquisition-1;

            List<SourceOfReceipt> sourceOfReceipts = DataBase.Base.SourceOfReceipt.ToList();
            cbSourceOfReceipt.Items.Add("не выбрано");
            for (var i = 0; i < sourceOfReceipts.Count; i++)
            {
                cbSourceOfReceipt.Items.Add(sourceOfReceipts[i].Kind);
            }
            cbSourceOfReceipt.Items.Add("Добавить источник");
            cbSourceOfReceipt.SelectedIndex = receipts.IdSourceOfReceipt-1;

            // находим содержания, которого мы редактируем
            List<ContentsReceipts> cr = DataBase.Base.ContentsReceipts.Where(x => x.IdContents == receipts.Id).ToList();

            // цикл для отображения содержаний и их количества:
            foreach (Contents Cn in lbContent.Items)
            {
                if (cr.FirstOrDefault(x => x.IdContents == Cn.Id) != null)
                {
                    Cn.QM = cr.Count;
                }
            }

            // находим виды, которого мы редактируем
            List<ViewsReceipts> vr = DataBase.Base.ViewsReceipts.Where(x => x.IdViews == receipts.Id).ToList();

            // цикл для отображения виды и их количества:
            foreach (Views v in lbViews.Items)
            {
                if (vr.FirstOrDefault(x => x.IdViews == v.Id) != null)
                {
                    v.QM = vr.Count;
                }
            }

            dpDate.SelectedDate = receipts.Date;
            tbNumber.Text = Convert.ToString(receipts.NumberInOrder);
            tbNumberOfDocument.Text = receipts.NumberDocument;
            dpDateDocuments.SelectedDate = receipts.DocumentDate;
            tbTotalInstances.Text = Convert.ToString(receipts.TotalInstances);
            tbCountNumber.Text = Convert.ToString(receipts.Count);
            tbCost.Text = Convert.ToString(receipts.Cost);
            tbCount.Text = Convert.ToString(receipts.DocumentsNotAcceptedForBalance);

            tbHeader.Text = "Изменение данных";
            btnSave.Content = "Сохранить";
        }

        /// <summary>
        /// Заполнение ComboBox
        /// </summary>
        public void listFild()
        {
            lbContent.ItemsSource = DataBase.Base.Contents.ToList();
            lbViews.ItemsSource = DataBase.Base.Views.ToList();

            List<SourceOfAcquisition> sourceOfAcquisitions = DataBase.Base.SourceOfAcquisition.ToList();
            cbSourceOfAcquisition.Items.Add("не выбрано");
            for (var i = 0; i < sourceOfAcquisitions.Count; i++)
            {
                cbSourceOfAcquisition.Items.Add(sourceOfAcquisitions[i].Kind);
            }
            cbSourceOfAcquisition.SelectedIndex = 0;


            List<SourceOfReceipt> sourceOfReceipts = DataBase.Base.SourceOfReceipt.ToList();
            cbSourceOfReceipt.Items.Add("не выбрано");
            for (var i = 0; i < sourceOfReceipts.Count; i++)
            {
                cbSourceOfReceipt.Items.Add(sourceOfReceipts[i].Kind);
            }
            cbSourceOfReceipt.Items.Add("Добавить источник");
            cbSourceOfReceipt.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (dpDate.Text.Replace(" ", "") == "" || tbNumber.Text == "" || cbSourceOfAcquisition.Text == "" || cbSourceOfReceipt.Text == "" || tbNumberOfDocument.Text == "" || dpDateDocuments.Text.Replace(" ", "") == "" || tbTotalInstances.Text == "" || tbCountNumber.Text == "" || tbCost.Text == "")
            {
                MessageBox.Show("Обязательные поля не заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                receipts = new Receipts(); //таблица поступлений
                receipts.Date = Convert.ToDateTime(dpDate.SelectedDate);
                receipts.NumberInOrder = Convert.ToInt32(tbNumber.Text);
                receipts.IdSourceOfReceipt = cbSourceOfReceipt.SelectedIndex;
                receipts.IdSourceOfAcquisition = cbSourceOfAcquisition.SelectedIndex;

                receipts.NumberDocument = tbNumberOfDocument.Text; // Сопроводительный документ
                receipts.DocumentDate = Convert.ToDateTime(dpDateDocuments.SelectedDate);

                receipts.TotalInstances = Convert.ToInt32(tbTotalInstances.Text);


                if (tbCountNumber.Text == "")  //Документы, принятые на баланс
                {
                    receipts.Count = null;
                }
                else
                {
                    receipts.Count = Convert.ToInt32(tbCountNumber.Text);
                }

                receipts.Cost = Convert.ToDouble(tbCost.Text);

                if (tbCount.Text == "")
                {
                    receipts.DocumentsNotAcceptedForBalance = null;
                }
                else
                {
                    receipts.DocumentsNotAcceptedForBalance = Convert.ToInt32(tbCount.Text);
                }
                DataBase.Base.Receipts.Add(receipts);

                // находим список с содержанием
                List<ContentsReceipts> contents = DataBase.Base.ContentsReceipts.Where(x => receipts.Id == x.IdReceipts).ToList();
                // если список не пустой, удаляем из него все содержания
                if (contents.Count > 0)
                {
                    foreach (ContentsReceipts t in contents)
                    {
                        DataBase.Base.ContentsReceipts.Remove(t);
                    }
                }
                // перезаписываем содержание (или добавляем содержание)
                foreach (Contents Con in lbContent.Items)
                {
                    if (Con.QM > 0)
                    {
                        ContentsReceipts CAA = new ContentsReceipts()  // объект для записи в таблицу ContentAndAdmission
                        {
                            IdReceipts = receipts.Id,
                            IdContents = Con.Id,
                            Counts = Con.QM
                        };
                        DataBase.Base.ContentsReceipts.Add(CAA);
                    }
                }

                // находим список с видами
                //List<ViewsReceipts> viewsAnds = DataBase.Base.ViewsReceipts.Where(x => receipts.Id == x.IdReceipts).ToList();
                //// если список не пустой, удаляем из него все виды
                //if (viewsAnds.Count > 0)
                //{
                //    foreach (ViewsReceipts v in viewsAnds)
                //    {
                //        DataBase.Base.ViewsReceipts.Remove(v);
                //    }
                //}
                //// перезаписываем виды (или добавляем виды)
                //foreach (ViewsReceipts View in lbViews.Items)
                //{
                //    if (View.QM > 0)
                //    {
                //        ViewsReceipts VAR = new ViewsReceipts()
                //        {
                //            IdReceipts = receipts.Id,
                //            IdViews = View.Id,
                //            Count = View.QM
                //        };
                //        DataBase.Base.ViewsReceipts.Add(VAR);
                //    }
                //}
                DataBase.Base.SaveChanges();
                MessageBox.Show("Информация добавлена");
                Close();
            }
        }

        private void tbNumber_PreviewTextInput(object sender, TextCompositionEventArgs e) // Ограничение на ввод символов
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void cbSourceOfReceipt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<SourceOfReceipt> sourceOfReceipts = DataBase.Base.SourceOfReceipt.ToList();
            if (cbSourceOfReceipt.SelectedIndex == (sourceOfReceipts.Count + 1))
            {
                WindowAddSourceOfReceipts windowSource = new WindowAddSourceOfReceipts();
                windowSource.ShowDialog();

                List<SourceOfReceipt> sources = DataBase.Base.SourceOfReceipt.ToList();
                cbSourceOfReceipt.Items.Remove("не выбрано");
                for (var i = 0; i < sources.Count; i++)
                {
                    cbSourceOfReceipt.Items.Remove(sources[i].Kind);
                }
                cbSourceOfReceipt.Items.Remove("Добавить источник поступления");
                cbSourceOfReceipt.Items.Add("не выбрано");
                for (var i = 0; i < sources.Count; i++)
                {
                    cbSourceOfReceipt.Items.Add(sources[i].Kind);
                }
                cbSourceOfReceipt.Items.Add("Добавить источник поступления");
                cbSourceOfReceipt.SelectedIndex = 0;
            }
        }
    }
}
