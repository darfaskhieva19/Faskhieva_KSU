using KSU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace KSU
{
    public partial class ReceiptsOne
    {

        public string dateReceipts
        {
            get
            {
                return string.Format("{0:dd.MM.yyyy}", Date);
            }
        }
        public string Istochik
        {
            get
            {
                return SourceOfReceipt.Kind;
            }
        }
        public string IstochikK
        {
            get
            {
                return SourceOfAcquisition.Kind;
            }
        }
        public string Ins //Вывод данных о сопроводительном документе
        {
            get
            {
                return NumberDocument + " " + InsDate;
            }
        }
        public string InsDate
        {
            get
            {
                return string.Format("{0:dd.MM.yyyy}", DocumentDate);
            }
        }

        public int Total
        {
            get
            {
                return TotalInstances;
            }
        }

        public int Inst
        {
            get
            {
                return (int)Count;
            }
        }

        public string InstCost
        {
            get
            {
                return string.Format("{0:N2}", Cost);
            }
        }

        public int NotBalance
        {
            get
            {
                return Convert.ToInt32(DocumentsNotAcceptedForBalance);
            }
        }

        public string NaturalS // Естественные науки
        {
            get
            {
                Contents contents = DataBase.Base.Contents.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (contents != null)
                {
                    List<ContentsReceipts> contentAndAdmissions = DataBase.Base.ContentsReceipts.Where(x => x.IdContents == contents.Id).ToList();
                    if (contentAndAdmissions.Count > 0)
                    {
                        foreach (ContentsReceipts content in contentAndAdmissions)
                        {
                            if (Id == 1)
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
        public string SocialS // Технические науки, хоз-во
        {
            get
            {
                Contents contents = DataBase.Base.Contents.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (contents != null)
                {
                    List<ContentsReceipts> contentAndAdmissions = DataBase.Base.ContentsReceipts.Where(x => x.IdContents == contents.Id).ToList();
                    if (contentAndAdmissions.Count > 0)
                    {
                        foreach (ContentsReceipts content in contentAndAdmissions)
                        {
                            if (Id == 2)
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
        public string HumanitarianS // Общественные, гуманитарные науки
        {
            get
            {
                Contents contents = DataBase.Base.Contents.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (contents != null)
                {
                    List<ContentsReceipts> contentAndAdmissions = DataBase.Base.ContentsReceipts.Where(x => x.IdContents == contents.Id).ToList();
                    if (contentAndAdmissions.Count > 0)
                    {
                        foreach (ContentsReceipts content in contentAndAdmissions)
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
        public string MetodicalS // Методическая литература
        {
            get
            {
                Contents contents = DataBase.Base.Contents.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (contents != null)
                {
                    List<ContentsReceipts> contentAndAdmissions = DataBase.Base.ContentsReceipts.Where(x => x.IdContents == contents.Id).ToList();
                    if (contentAndAdmissions.Count > 0)
                    {
                        foreach (ContentsReceipts content in contentAndAdmissions)
                        {
                            if (Id == 4)
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
        public string ReferenceLiteratureS // Справочная литература 
        {
            get
            {
                Contents contents = DataBase.Base.Contents.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (contents != null)
                {
                    List<ContentsReceipts> contentAndAdmissions = DataBase.Base.ContentsReceipts.Where(x => x.IdContents == contents.Id).ToList();
                    if (contentAndAdmissions.Count > 0)
                    {
                        foreach (ContentsReceipts content in contentAndAdmissions)
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
        public string ArtS // Художественная литература
        {
            get
            {
                Contents contents = DataBase.Base.Contents.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (contents != null)
                {
                    List<ContentsReceipts> contentAndAdmissions = DataBase.Base.ContentsReceipts.Where(x => x.IdContents == contents.Id).ToList();
                    if (contentAndAdmissions.Count > 0)
                    {
                        foreach (ContentsReceipts content in contentAndAdmissions)
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

        public string printedR // Печатный вид
        {
            get
            {
                Views views = DataBase.Base.Views.FirstOrDefault(z => z.Id == Id);
                string str = "";
                if (views != null)
                {
                    List<ViewsReceipts> viewsAndReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdViews == views.Id).ToList();
                    if (viewsAndReceipts.Count > 0)
                    {
                        foreach (ViewsReceipts viewsAnd in viewsAndReceipts)
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
        public string electr // Электронный вид
        {
            get
            {
                Views views = DataBase.Base.Views.FirstOrDefault(z => z.Id == Id);
                string strEl = "";
                if (views != null)
                {
                    List<ViewsReceipts> viewsAndReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdViews == views.Id).ToList();
                    foreach (ViewsReceipts viewsAnd in viewsAndReceipts)
                    {
                        if (Id == 2)
                        {
                            strEl = viewsAnd.Count.ToString();
                        }
                        else
                        {
                            strEl = null;
                        }
                    }
                }
                return strEl;
            }
        }
        public string periodich // Периодические издания
        {
            get
            {
                Views views = DataBase.Base.Views.FirstOrDefault(z => z.Id == Id);
                string strEl = "";
                if (views != null)
                {
                    List<ViewsReceipts> viewsAndReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdViews == views.Id).ToList();
                    foreach (ViewsReceipts viewsAnd in viewsAndReceipts)
                    {
                        if (Id == 3)
                        {
                            strEl = viewsAnd.Count.ToString();
                        }
                        else
                        {
                            strEl = null;
                        }
                    }
                }
                return strEl;
            }
        }
    }
}
