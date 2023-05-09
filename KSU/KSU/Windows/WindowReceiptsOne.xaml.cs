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
        public static int index;
        public WindowReceiptsOne()
        {
            InitializeComponent();
            listFild();

            foreach (Contents Cn in lbContent.Items)
            {
                Cn.QM = 0;
            }
            foreach (Views v in lbViews.Items)
            {
                v.QM = 0;
            }
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
            cbSourceOfAcquisition.SelectedIndex = receipts.IdSourceOfAcquisition;

            List<SourceOfReceipt> sourceOfReceipts = DataBase.Base.SourceOfReceipt.ToList();
            cbSourceOfReceipt.Items.Add("не выбрано");
            for (var i = 0; i < sourceOfReceipts.Count; i++)
            {
                cbSourceOfReceipt.Items.Add(sourceOfReceipts[i].Kind);
            }
            cbSourceOfReceipt.Items.Add("Добавить источник");
            cbSourceOfReceipt.SelectedIndex = receipts.IdSourceOfReceipt;

            foreach (Contents Cn in lbContent.Items)
            {
                Cn.QM = 0;
            }

            // находим содержания, которого мы редактируем
            List<ContentsReceipts> cr = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == receipts.Id).ToList();

            for (int i = 0; i < cr.Count; i++)
            {
                foreach (Contents Cn in lbContent.Items)
                {

                    if (cr[i].IdContents == Cn.Id && cr[i].Counts != null)
                    {
                        Cn.QM = (int)cr[i].Counts;
                    }
                }
            }

            foreach (Views v in lbViews.Items)
            {
                v.QM = 0;
            }

            // находим виды, которого мы редактируем
            List<ViewsReceipts> vr = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == receipts.Id).ToList();

            for (int i = 0; i < vr.Count; i++)
            {
                foreach (Views v in lbViews.Items)
                {
                    if (vr[i].IdViews == v.Id && vr[i].Counts != null)
                    {
                        v.QM = (int)vr[i].Counts;
                    }
                }
            }

            dpDate.SelectedDate = receipts.Date;
            tbNumber.Text = receipts.NumberInOrder;
            tbNumberOfDocument.Text = receipts.NumberDocument;
            dpDateDocuments.SelectedDate = receipts.DocumentDate;
            tbTotalInstances.Text = Convert.ToString(receipts.TotalInstances);
            tbCountNumber.Text = Convert.ToString(receipts.Counts);
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
            this.Close();
        }

        /// <summary>
        /// Проверка на заполненность обязательных полей
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="h"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static bool CheckData(string a, string b, string c, string d, string e, string h, string j, string k, string l)
        {
            if (a == "" || b == "" || c == "" || d == "" || e == "" || h == "" || j == "" || k == "" || l == "")
            {
                MessageBox.Show("Обязательные поля не заполнены", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Проверка на дату
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool proverkaDate(DateTime date)
        {
            if (date <= DateTime.Today)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Введенная дата не должна превышать сегодняшнюю", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckData(dpDate.Text, tbNumber.Text, cbSourceOfAcquisition.Text, cbSourceOfReceipt.Text, tbNumberOfDocument.Text, dpDateDocuments.Text, tbTotalInstances.Text, tbCountNumber.Text, tbCost.Text))
                {
                    if (proverkaDate(Convert.ToDateTime(dpDate.Text)))
                    {
                        if (flag == false)
                        {
                            receipts = new Receipts();
                        }
                        receipts.Date = Convert.ToDateTime(dpDate.Text);
                        receipts.NumberInOrder = tbNumber.Text;
                        receipts.IdSourceOfReceipt = cbSourceOfReceipt.SelectedIndex;
                        receipts.IdSourceOfAcquisition = cbSourceOfAcquisition.SelectedIndex;
                        receipts.NumberDocument = tbNumberOfDocument.Text; // Сопроводительный документ
                        receipts.DocumentDate = Convert.ToDateTime(dpDate.Text);
                        receipts.TotalInstances = Convert.ToInt32(tbTotalInstances.Text);
                        if (tbCountNumber.Text == "")  //Документы, принятые на баланс 
                        {
                            receipts.Counts = null;
                        }
                        else
                        {
                            receipts.Counts = Convert.ToInt32(tbCountNumber.Text);
                        }
                        receipts.Cost = Convert.ToDouble(tbCost.Text);
                        if (tbCount.Text == "") // Документы, не принятые на баланс
                        {
                            receipts.DocumentsNotAcceptedForBalance = null;
                        }
                        else
                        {
                            receipts.DocumentsNotAcceptedForBalance = Convert.ToInt32(tbCount.Text);
                        }
                        receipts.IdEnclosures = index;
                        // если флаг равен false, то добавляем объект в базу
                        if (flag == false)
                        {
                            DataBase.Base.Receipts.Add(receipts);
                        }
                        // находим список с кормами для кота
                        List<ContentsReceipts> contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => receipts.Id == x.IdReceipts).ToList();

                        // если список не пустой, удаляем из него все содержания
                        if (contentsReceipts.Count > 0)
                        {
                            foreach (ContentsReceipts t in contentsReceipts)
                            {
                                DataBase.Base.ContentsReceipts.Remove(t);
                            }
                        }

                        // перезаписываем содержания (или добавляем содержания)
                        foreach (Contents f in lbContent.Items)
                        {
                            if (f.QM > 0)
                            {
                                ContentsReceipts FCT = new ContentsReceipts()  // объект для записи в таблицу ContentsReceipts
                                {
                                    IdReceipts = receipts.Id,
                                    IdContents = f.Id,
                                    Counts = f.QM
                                };
                                DataBase.Base.ContentsReceipts.Add(FCT);
                            }
                        }

                        List<ViewsReceipts> viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => receipts.Id == x.IdReceipts).ToList();

                        // если список не пустой, удаляем из него все корма для  этого кота
                        if (viewsReceipts.Count > 0)
                        {
                            foreach (ViewsReceipts t in viewsReceipts)
                            {
                                DataBase.Base.ViewsReceipts.Remove(t);
                            }
                        }

                        // перезаписываем корма для кота (или добавляем корма для нового кота)
                        foreach (Views v in lbViews.Items)
                        {
                            if (v.QM > 0)
                            {
                                ViewsReceipts FCT = new ViewsReceipts()  // объект для записи в таблицу FeedCatTable
                                {
                                    IdReceipts = receipts.Id,
                                    IdViews = v.Id,
                                    Counts = v.QM
                                };
                                DataBase.Base.ViewsReceipts.Add(FCT);
                            }
                        }
                        DataBase.Base.SaveChanges();
                        if (flag == false)
                        {
                            MessageBox.Show("Информация добавлена!");
                        }
                        else
                        {
                            MessageBox.Show("Информация изменена!");
                        }
                        this.Close();
                    }
                }
            }
            catch
            {
                if (flag == true)
                {
                    MessageBox.Show("При изменение возникла ошибка!");
                }
                else
                {
                    MessageBox.Show("При добавление возникла ошибка!");
                }
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
