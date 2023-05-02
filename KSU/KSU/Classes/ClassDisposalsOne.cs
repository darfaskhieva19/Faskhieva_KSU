using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSU
{
    public partial class Disposals
    {
        public string dateDisp // Дата записи
        {
            get
            {
                return string.Format("{0:dd.MM.yyyy}", Date);
            }
        }
        public string Places // Место выбытия
        {
            get
            {
                return Place.Kind;
            }
        }
        public string Price //Сумма
        {
            get
            {
                return string.Format("{0:N2}", Cost);
            }
        }

        public string NaturalSocial // Естественные науки
        {
            get
            {
                List<ContentsDisposals> contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == Id).ToList();
                string str = "";
                if (contentsDisposals != null)
                {
                    for (int i = 0; i < contentsDisposals.Count; i++)
                    {
                        if (contentsDisposals[i].IdContents == 1)
                        {
                            str = contentsDisposals[i].Counts.ToString();
                        }
                    }
                }
                else
                {
                    str = null;
                }
                return str;
            }
        }
        public string Social // Технические науки, хоз-во
        {
            get
            {
                List<ContentsDisposals> contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == Id).ToList();
                string str = "";
                if (contentsDisposals != null)
                {
                    for (int i = 0; i < contentsDisposals.Count; i++)
                    {
                        if (contentsDisposals[i].IdContents == 2)
                        {
                            str = contentsDisposals[i].Counts.ToString();
                        }
                    }
                }
                else
                {
                    str = null;
                }
                return str;
            }
        }

        public string Humanitarian // Общественные, гуманитарные науки
        {
            get
            {
                List<ContentsDisposals> contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == Id).ToList();
                string str = "";
                if (contentsDisposals != null)
                {
                    for (int i = 0; i < contentsDisposals.Count; i++)
                    {
                        if (contentsDisposals[i].IdContents == 3)
                        {
                            str = contentsDisposals[i].Counts.ToString();
                        }
                    }
                }
                else
                {
                    str = null;
                }
                return str;
            }
        }

        public string Metodical // Методическая литература
        {
            get
            {
                List<ContentsDisposals> contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == Id).ToList();
                string str = "";
                if (contentsDisposals != null)
                {
                    for (int i = 0; i < contentsDisposals.Count; i++)
                    {
                        if (contentsDisposals[i].IdContents == 4)
                        {
                            str = contentsDisposals[i].Counts.ToString();
                        }
                    }
                }
                else
                {
                    str = null;
                }
                return str;
            }
        }

        public string ReferenceLiterature // Справочная литература 
        {
            get
            {
                List<ContentsDisposals> contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == Id).ToList();
                string str = "";
                if (contentsDisposals != null)
                {
                    for (int i = 0; i < contentsDisposals.Count; i++)
                    {
                        if (contentsDisposals[i].IdContents == 5)
                        {
                            str = contentsDisposals[i].Counts.ToString();
                        }
                    }
                }
                else
                {
                    str = null;
                }
                return str;
            }
        }

        public string Art // Художественная литература
        {
            get
            {
                List<ContentsDisposals> contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == Id).ToList();
                string str = "";
                if (contentsDisposals != null)
                {
                    for (int i = 0; i < contentsDisposals.Count; i++)
                    {
                        if (contentsDisposals[i].IdContents == 6)
                        {
                            str = contentsDisposals[i].Counts.ToString();
                        }
                    }
                }
                else
                {
                    str = null;
                }
                return str;
            }
        }

        public string printed // Печатный вид
        {
            get
            {
                List<ViewsDisposals> viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == Id).ToList();
                string str = "";
                if (viewsDisposals != null)
                {
                    for (int i = 0; i < viewsDisposals.Count; i++)
                    {
                        if (viewsDisposals[i].IdViews == 1)
                        {
                            str = viewsDisposals[i].Counts.ToString();
                        }
                    }
                }
                else
                {
                    str = null;
                }
                return str;
            }
        }

        public string Electronic // Электронный вид
        {
            get
            {
                List<ViewsDisposals> viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == Id).ToList();
                string str = "";
                if (viewsDisposals != null)
                {
                    for (int i = 0; i < viewsDisposals.Count; i++)
                    {
                        if (viewsDisposals[i].IdViews == 2)
                        {
                            str = viewsDisposals[i].Counts.ToString();
                        }
                    }
                }
                else
                {
                    str = null;
                }
                return str;
            }
        }

        public string Period //Периодические издания
        {
            get
            {
                List<ViewsDisposals> viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == Id).ToList();
                string str = "";
                if (viewsDisposals != null)
                {
                    for (int i = 0; i < viewsDisposals.Count; i++)
                    {
                        if (viewsDisposals[i].IdViews == 3)
                        {
                            str = viewsDisposals[i].Counts.ToString();
                        }
                    }
                }
                else
                {
                    str = null;
                }
                return str;
            }
        }
        // Место выбытия
        public string causes // Ветхость
        {
            get
            {
                List<ReasonDisposals> reasonDisposals = DataBase.Base.ReasonDisposals.Where(x => x.IdDisposals == Id).ToList();
                string str = "";
                if (reasonDisposals != null)
                {
                    for (int i = 0; i < reasonDisposals.Count; i++)
                    {
                        if (reasonDisposals[i].IdReason == 1)
                        {
                            str = reasonDisposals[i].Counts.ToString();
                        }
                    }
                }
                else
                {
                    str = null;
                }
                return str;
            }
        }

        public string obsolescence // Устарелость
        {
            get
            {
                List<ReasonDisposals> reasonDisposals = DataBase.Base.ReasonDisposals.Where(x => x.IdDisposals == Id).ToList();
                string str = "";
                if (reasonDisposals != null)
                {
                    for (int i = 0; i < reasonDisposals.Count; i++)
                    {
                        if (reasonDisposals[i].IdReason == 2)
                        {
                            str = reasonDisposals[i].Counts.ToString();
                        }
                    }
                }
                else
                {
                    str = null;
                }
                return str;
            }
        }

        public string defectiveness //Дефектность
        {
            get
            {
                List<ReasonDisposals> reasonDisposals = DataBase.Base.ReasonDisposals.Where(x => x.IdDisposals == Id).ToList();
                string str = "";
                if (reasonDisposals != null)
                {
                    for (int i = 0; i < reasonDisposals.Count; i++)
                    {
                        if (reasonDisposals[i].IdReason == 3)
                        {
                            str = reasonDisposals[i].Counts.ToString();
                        }
                    }
                }
                else
                {
                    str = null;
                }
                return str;
            }
        }
        public string loss //Утрата
        {
            get
            {
                List<ReasonDisposals> reasonDisposals = DataBase.Base.ReasonDisposals.Where(x => x.IdDisposals == Id).ToList();
                string str = "";
                if (reasonDisposals != null)
                {
                    for (int i = 0; i < reasonDisposals.Count; i++)
                    {
                        if (reasonDisposals[i].IdReason == 4)
                        {
                            str = reasonDisposals[i].Counts.ToString();
                        }
                    }
                }
                else
                {
                    str = null;
                }
                return str;
            }
        }
        //public SolidColorBrush Colors
        //{
        //    get
        //    {

        //    }
        //}
    }
}
