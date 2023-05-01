using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Логика взаимодействия для WindowDisposalsOne.xaml
    /// </summary>
    public partial class WindowDisposalsOne : Window
    {
        Disposals disposal;
        bool flag = false;
        public WindowDisposalsOne()
        {
            InitializeComponent();
            listFild();
        }
        public WindowDisposalsOne(Disposals disposal) // Конструктор для редактирования
        {
            InitializeComponent();
            this.disposal = disposal;
            flag = true;

            List<Place> places = DataBase.Base.Place.ToList();
            cbPlace.Items.Add("не выбрано");
            for (var i = 0; i < places.Count; i++)
            {
                cbPlace.Items.Add(places[i].Kind);
            }
            cbPlace.SelectedIndex = disposal.IdPlace;

            List<Enclosures> enclosures = DataBase.Base.Enclosures.ToList();
            cbEnclousures.Items.Add("не выбрано");
            for (var i = 0; i < enclosures.Count; i++)
            {
                cbEnclousures.Items.Add(enclosures[i].Kind);
            }
            cbEnclousures.SelectedIndex = disposal.IdEnclosures;

            lbContent.ItemsSource = DataBase.Base.Contents.ToList();
            lbViews.ItemsSource = DataBase.Base.Views.ToList();
            lbReason.ItemsSource = DataBase.Base.Reason.ToList();

            // находим содержания, которого мы редактируем
            List<ContentsDisposals> cd = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == disposal.Id).ToList();

            // цикл для отображения содержаний и их количества:
            foreach (Contents Cn in lbContent.Items)
            {
                if (cd.FirstOrDefault(x => x.IdContents == Cn.Id) != null)
                {
                    Cn.QM = cd.Count;
                }
            }

            // находим виды, которого мы редактируем
            List<ViewsDisposals> vd = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == disposal.Id).ToList();

            // цикл для отображения виды и их количества:
            foreach (Views v in lbViews.Items)
            {
                if (vd.FirstOrDefault(x => x.IdViews == v.Id) != null)
                {
                    v.QM = vd.Count;
                }
            }

            // находим причины, которого мы редактируем
            List<ReasonDisposals> rd = DataBase.Base.ReasonDisposals.Where(x => x.IdDisposals == disposal.Id).ToList();

            // цикл для отображения причин и их количества:
            foreach (Reason r in lbReason.Items)
            {
                if (rd.FirstOrDefault(x => x.IdReason == r.Id) != null)
                {
                    r.QM = rd.Count;
                }
            }

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
            lbReason.ItemsSource = DataBase.Base.Reason.ToList();

            List<Place> places = DataBase.Base.Place.ToList();
            cbPlace.Items.Add("не выбрано");
            for (var i = 0; i < places.Count; i++)
            {
                cbPlace.Items.Add(places[i].Kind);
            }
            cbPlace.SelectedIndex = 0;

            List<Enclosures> enclosures = DataBase.Base.Enclosures.ToList();
            cbEnclousures.Items.Add("не выбрано");
            for(var i = 0; i < enclosures.Count; i++)
            {
                cbEnclousures.Items.Add(enclosures[i].Kind);
            }
            cbEnclousures.SelectedIndex = 0;            
        }

        private void tbTotalNumber_PreviewTextInput(object sender, TextCompositionEventArgs e) // Ограничение на ввод символов
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //if (flag == false)
            //{
                if (dpDate.Text.Replace(" ", "") == "" || tbNumber.Text == "" || tbTotalNumber.Text == "" || tbCost.Text == "" || cbPlace.Text == "" || cbEnclousures.Text == "")
                {
                    MessageBox.Show("Обязательные поля не заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    disposal = new Disposals();
                    disposal.Date = Convert.ToDateTime(dpDate.SelectedDate);
                    disposal.ActNumber = Convert.ToInt32(tbNumber.Text);
                    disposal.TotalNumber = Convert.ToInt32(tbTotalNumber.Text);
                    disposal.Cost = Convert.ToDouble(tbCost.Text);
                    disposal.IdPlace = cbPlace.SelectedIndex;
                    disposal.IdEnclosures = cbEnclousures.SelectedIndex;
                    DataBase.Base.Disposals.Add(disposal);

                    List<ContentsDisposals> contents = DataBase.Base.ContentsDisposals.Where(x => disposal.Id == x.IdDisposals).ToList();
                // если список не пустой, удаляем из него все содержания
                if (contents.Count > 0)
                {
                    foreach (ContentsDisposals c in contents)
                    {
                        DataBase.Base.ContentsDisposals.Remove(c);
                    }
                }
                // перезаписываем содержание (или добавляем содержание)
                foreach (Contents Con in lbContent.Items)
                    {
                        if (Con.QM > 0)
                        {
                            ContentsDisposals CAD = new ContentsDisposals()  // объект для записи в таблицу ContentAndDisposals
                            {
                                IdContents = Con.Id,
                                IdDisposals = disposal.Id,
                                Counts = Con.QM
                            };
                            DataBase.Base.ContentsDisposals.Add(CAD);
                        }
                    }
                //List<ViewsDisposals> viewsAnds = DataBase.Base.ViewsDisposals.Where(x => disposal.Id == x.IdDisposals).ToList();
                //// если список не пустой, удаляем из него все виды
                //if (viewsAnds.Count > 0)
                //{
                //    foreach (ViewsDisposals v in viewsAnds)
                //    {
                //        DataBase.Base.ViewsDisposals.Remove(v);
                //    }
                //}
                //// перезаписываем виды (или добавляем виды)
                //foreach (ViewsDisposals View in lbViews.Items)
                //{
                //    if (View.QM > 0)
                //    {
                //        ViewsDisposals VAD = new ViewsDisposals()
                //        {
                //            IdDisposals = disposal.Id,
                //            IdViews = View.Id,
                //            Count = View.QM
                //        };
                //        DataBase.Base.ViewsDisposals.Add(VAD);
                //    }
                //}
                //List<ReasonDisposals> reason = DataBase.Base.ReasonDisposals.Where(x => disposal.Id == x.IdDisposals).ToList();
                //// если список не пустой, удаляем из него все виды
                //if (reason.Count > 0)
                //{
                //    foreach (ReasonDisposals v in reason)
                //    {
                //        DataBase.Base.ReasonDisposals.Remove(v);
                //    }
                //}
                //// перезаписываем виды (или добавляем виды)
                //foreach (ReasonDisposals causes in lbReason.Items)
                //{
                //    if (causes.QM > 0)
                //    {
                //        ReasonDisposals CAD = new ReasonDisposals()
                //        {
                //            IdDisposals = disposal.Id,
                //            IdReason = causes.Id,
                //            Count = causes.QM
                //        };
                //        DataBase.Base.ReasonDisposals.Add(CAD);
                //    }
                //}
                DataBase.Base.SaveChanges();
                    MessageBox.Show("Информация добавлена");
                    Close();
                //}
            }            
        }
    }
}
