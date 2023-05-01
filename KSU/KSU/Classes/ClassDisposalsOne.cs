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
                Contents contents = DataBase.Base.Contents.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (contents != null)
                {
                    List<ContentsDisposals> contentAndDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdContents == contents.Id).ToList();
                    if (contentAndDisposals.Count > 0)
                    {
                        foreach (ContentsDisposals content in contentAndDisposals)
                        {
                            if (Id == 1)
                            {
                                int k = content.IdContents;
                                if (k == 1)
                                {
                                    str = content.Count.ToString();
                                }
                            }
                            else
                            {
                                str = null;
                            }
                        }
                    }
                }
                return str;
            }
        }
        public string Social // Технические науки, хоз-во
        {
            get
            {
                Contents contents = DataBase.Base.Contents.FirstOrDefault(z => z.Id == Id);
                string strSocial = "";
                if (contents != null)
                {
                    List<ContentsDisposals> contentAndDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdContents == contents.Id).ToList();
                    if (contentAndDisposals.Count > 0)
                    {
                        foreach (ContentsDisposals content in contentAndDisposals)
                        {
                            if (content.Id == 2)
                            {
                                strSocial = content.Count.ToString();
                            }
                            else
                            {
                                strSocial = null;
                            }
                        }
                    }
                }
                return strSocial;
            }
        }

        public string Humanitarian // Общественные, гуманитарные науки
        {
            get
            {
                Contents contents = DataBase.Base.Contents.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (contents != null)
                {
                    List<ContentsDisposals> contentAndDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdContents == contents.Id).ToList();
                    if (contentAndDisposals.Count > 0)
                    {
                        foreach (ContentsDisposals content in contentAndDisposals)
                        {
                            if (Id == 3)
                            {
                                str = content.Count.ToString();
                            }
                            else
                            {
                                str = null;
                            }
                        }
                    }
                }
                return str;
            }
        }

        public string Metodical // Методическая литература
        {
            get
            {
                Contents contents = DataBase.Base.Contents.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (contents != null)
                {
                    List<ContentsDisposals> contentAndDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdContents == contents.Id).ToList();
                    if (contentAndDisposals.Count > 0)
                    {
                        foreach (ContentsDisposals content in contentAndDisposals)
                        {
                            if (Id == 3)
                            {
                                str = content.Count.ToString();
                            }
                            else
                            {
                                str = null;
                            }
                        }
                    }
                }
                return str;
            }
        }

        public string ReferenceLiterature // Справочная литература 
        {
            get
            {
                Contents contents = DataBase.Base.Contents.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (contents != null)
                {
                    List<ContentsDisposals> contentAndDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdContents == contents.Id).ToList();
                    if (contentAndDisposals.Count > 0)
                    {
                        foreach (ContentsDisposals content in contentAndDisposals)
                        {
                            if (Id == 5)
                            {
                                str = content.Count.ToString();
                            }
                            else
                            {
                                str = null;
                            }
                        }
                    }
                }
                return str;
            }
        }

        public string Art // Художественная литература
        {
            get
            {
                Contents contents = DataBase.Base.Contents.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (contents != null)
                {
                    List<ContentsDisposals> contentAndDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdContents == contents.Id).ToList();
                    if (contentAndDisposals.Count > 0)
                    {
                        foreach (ContentsDisposals content in contentAndDisposals)
                        {
                            if (Id == 6)
                            {
                                str = content.Count.ToString();
                            }
                            else
                            {
                                str = null;
                            }
                        }
                    }
                }
                return str;
            }
        }

        public string printed // Печатный вид
        {
            get
            {
                Views views = DataBase.Base.Views.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (views != null)
                {
                    List<ViewsDisposals> viewsAndDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdViews == views.Id).ToList();
                    if (viewsAndDisposals.Count > 0)
                    {
                        foreach (ViewsDisposals viewsAnd in viewsAndDisposals)
                        {
                            if (Id == 1)
                            {
                                str = viewsAnd.Count.ToString();
                            }
                            else
                            {
                                str = null;
                            }
                        }
                    }
                }
                return str;
            }
        }

        public string Electronic // Электронный вид
        {
            get
            {
                Views views = DataBase.Base.Views.FirstOrDefault(z => z.Id == Id);
                string el = "";
                if (views != null)
                {
                    List<ViewsDisposals> viewsAndDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdViews == views.Id).ToList();
                    if (viewsAndDisposals.Count > 0)
                    {
                        foreach (ViewsDisposals viewsAnd in viewsAndDisposals)
                        {
                            if (Id != 1)
                            {
                                el = viewsAnd.Count.ToString();
                            }
                            else
                            {
                                el = null;
                            }
                        }
                    }
                }
                return el;
            }
        }

        public string Period //Периодические издания
        {
            get
            {
                Views views = DataBase.Base.Views.FirstOrDefault(z => z.Id == Id);
                string el = "";
                if (views != null)
                {
                    List<ViewsDisposals> viewsAndDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdViews == views.Id).ToList();
                    if (viewsAndDisposals.Count > 0)
                    {
                        foreach (ViewsDisposals viewsAnd in viewsAndDisposals)
                        {
                            if (Id != 1 && Id != 2)
                            {
                                el = viewsAnd.Count.ToString();
                            }
                            else
                            {
                                el = null;
                            }
                        }
                    }
                }
                return el;
            }
        }
        // Место выбытия
        public string causes // Ветхость
        {
            get
            {
                Reason reason = DataBase.Base.Reason.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (reason != null)
                {
                    List<ReasonDisposals> causesAnds = DataBase.Base.ReasonDisposals.Where(x => x.IdReason == reason.Id).ToList();
                    if (causesAnds.Count > 0)
                    {
                        foreach (ReasonDisposals causesAndDisposals in causesAnds)
                        {
                            if (Id == 1)
                            {
                                str = causesAndDisposals.Count.ToString();
                            }
                            else
                            {
                                str = null;
                            }
                        }
                    }
                }
                return str;
            }
        }

        public string obsolescence // Устарелость
        {
            get
            {
                Reason reason = DataBase.Base.Reason.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (reason != null)
                {
                    List<ReasonDisposals> causesAnds = DataBase.Base.ReasonDisposals.Where(x => x.IdReason == reason.Id).ToList();
                    if (causesAnds.Count > 0)
                    {
                        foreach (ReasonDisposals causesAndDisposals in causesAnds)
                        {
                            if (Id == 2)
                            {
                                str = causesAndDisposals.Count.ToString();
                            }
                            else
                            {
                                str = null;
                            }
                        }
                    }
                }
                return str;
            }
        }

        public string defectiveness //Дефектность
        {
            get
            {
                Reason reason = DataBase.Base.Reason.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (reason != null)
                {
                    List<ReasonDisposals> causesAnds = DataBase.Base.ReasonDisposals.Where(x => x.IdReason == reason.Id).ToList();
                    if (causesAnds.Count > 0)
                    {
                        foreach (ReasonDisposals causesAndDisposals in causesAnds)
                        {
                            if (Id == 3)
                            {
                                str = causesAndDisposals.Count.ToString();
                            }
                            else
                            {
                                str = null;
                            }
                        }
                    }
                }
                return str;
            }
        }
        public string loss //Утрата
        {
            get
            {
                Reason reason = DataBase.Base.Reason.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (reason != null)
                {
                    List<ReasonDisposals> causesAnds = DataBase.Base.ReasonDisposals.Where(x => x.IdReason == reason.Id).ToList();
                    if (causesAnds.Count > 0)
                    {
                        foreach (ReasonDisposals causesAndDisposals in causesAnds)
                        {
                            if (Id == 3)
                            {
                                str = causesAndDisposals.Count.ToString();
                            }
                            else
                            {
                                str = null;
                            }
                        }
                    }
                }
                return str;
            }
        }
    }
}
