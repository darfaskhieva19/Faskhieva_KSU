using KSU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace KSU
{
    public partial class Receipts
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
                return (int)Counts;
            }
        }

        public string InstCost
        {
            get
            {
                return string.Format("{0:N2}", Cost);
            }
        }

        public string NotBalance
        {
            get
            {
                if (Convert.ToString(DocumentsNotAcceptedForBalance) == null)
                {
                    return null;
                }
                else
                {
                    return Convert.ToString(DocumentsNotAcceptedForBalance);
                }                
            }
        }

        public string NaturalS // Естественные науки
        {
            get
            {
                List<ContentsReceipts> contentAndAdmissions = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == Id).ToList();
                string str = "";
                if(contentAndAdmissions != null)
                {
                    for(int i = 0; i < contentAndAdmissions.Count; i++)
                    {
                        if(contentAndAdmissions[i].IdContents == 1)
                        {
                            str = contentAndAdmissions[i].Counts.ToString();
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
        public string SocialS // Технические науки, хоз-во
        {
            get
            {
                List<ContentsReceipts> contentAndAdmissions = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == Id).ToList();
                string str = "";
                if (contentAndAdmissions != null)
                {
                    for (int i = 0; i < contentAndAdmissions.Count; i++)
                    {
                        if (contentAndAdmissions[i].IdContents == 2)
                        {
                            str = contentAndAdmissions[i].Counts.ToString();
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
        public string HumanitarianS // Общественные, гуманитарные науки
        {
            get
            {
                List<ContentsReceipts> contentAndAdmissions = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == Id).ToList();
                string str = "";
                if (contentAndAdmissions != null)
                {
                    for (int i = 0; i < contentAndAdmissions.Count; i++)
                    {
                        if (contentAndAdmissions[i].IdContents == 3)
                        {
                            str = contentAndAdmissions[i].Counts.ToString();
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
        public string MetodicalS // Методическая литература
        {
            get
            {
                List<ContentsReceipts> contentAndAdmissions = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == Id).ToList();
                string str = "";
                if (contentAndAdmissions != null)
                {
                    for (int i = 0; i < contentAndAdmissions.Count; i++)
                    {
                        if (contentAndAdmissions[i].IdContents == 4)
                        {
                            str = contentAndAdmissions[i].Counts.ToString();
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
        public string ReferenceLiteratureS // Справочная литература 
        {
            get
            {
                List<ContentsReceipts> contentAndAdmissions = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == Id).ToList();
                string str = "";
                if (contentAndAdmissions != null)
                {
                    for (int i = 0; i < contentAndAdmissions.Count; i++)
                    {
                        if (contentAndAdmissions[i].IdContents == 5)
                        {
                            str = contentAndAdmissions[i].Counts.ToString();
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
        public string ArtS // Художественная литература
        {
            get
            {
                List<ContentsReceipts> contentAndAdmissions = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == Id).ToList();
                string str = "";
                if (contentAndAdmissions != null)
                {
                    for (int i = 0; i < contentAndAdmissions.Count; i++)
                    {
                        if (contentAndAdmissions[i].IdContents == 6)
                        {
                            str = contentAndAdmissions[i].Counts.ToString();
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

        public string printedR // Печатный вид
        {
            get
            {
                List<ViewsReceipts> viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == Id).ToList();
                string str = "";
                if (viewsReceipts != null)
                {
                    for (int i = 0; i < viewsReceipts.Count; i++)
                    {
                        if (viewsReceipts[i].IdViews == 1)
                        {
                            str = viewsReceipts[i].Counts.ToString();
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
        public string electr // Электронный вид
        {
            get
            {
                List<ViewsReceipts> viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == Id).ToList();
                string str = "";
                if (viewsReceipts != null)
                {
                    for (int i = 0; i < viewsReceipts.Count; i++)
                    {
                        if (viewsReceipts[i].IdViews == 2)
                        {
                            str = viewsReceipts[i].Counts.ToString();
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
        public string periodich // Периодические издания
        {
            get
            {
                List<ViewsReceipts> viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == Id).ToList();
                string str = "";
                if (viewsReceipts != null)
                {
                    for (int i = 0; i < viewsReceipts.Count; i++)
                    {
                        if (viewsReceipts[i].IdViews == 3)
                        {
                            str = viewsReceipts[i].Counts.ToString();
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

        //public SolidColorBrush Color
        //{
        //    get
        //    {
        //        int k = Convert.ToInt32(Date);
        //        var brush = new BrushConverter();
        //        if (k == 2018 && k == 2023)
        //        {
        //            return (SolidColorBrush)(Brush)brush.ConvertFrom("#F2F3B1");
        //        }
        //        else if (k == 2019 && k == 2024)
        //        {
        //            return (SolidColorBrush)(Brush)brush.ConvertFrom("#BEF3B1");
        //        }
        //        else if (k == 2020 && k == 2025)
        //        {
        //            return (SolidColorBrush)(Brush)brush.ConvertFrom("#B1C7F3");
        //        }
        //        else
        //        {
        //            return (SolidColorBrush)(Brush)brush.ConvertFrom("#F3DDB1");
        //        }                
        //    }
        //}
    }
}
