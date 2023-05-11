using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KSU
{
    public class Results
    {
        public int Id { get; set; }
        public string FundMoment { get; set; }
        public int TotalCount { get; set; }
        public double TotalCost { get; set; }
        public int NaturalSocial { get; set; }
        public int Social { get; set; }
        public int Humanitarian { get; set; }
        public int Metodical { get; set; }
        public int Reference { get; set; }
        public int Art { get; set; }
        public int Prented { get; set; }
        public int Electronic { get; set; }
        public int Periodich { get; set; }
        public string Notes { get; set; }


        //public string CountsReceipts(int totalCount, double totalCost, int natural, int social, int human, int metodical, int reference, int art, int print, int electr, int period)
        //{
        //    int year = 2018;  // указываем год, за который хотим посчитать количество поступивших книг
        //    DateTime startDate = new DateTime(year, 1, 1, 0, 0, 0);
        //    DateTime endDate = new DateTime(year, 12, 31, 23, 59, 59);

        //    totalCount = 0; //Общее количество
        //    totalCost = 0; //Общая стоимость
        //    natural = 0;
        //    social = 0;
        //    human = 0;
        //    metodical = 0;
        //    reference = 0;
        //    art = 0;
        //    print = 0;
        //    electr = 0;
        //    period = 0;


        //    var items = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= startDate && x.Date <= endDate);
        //    string str = "";
        //    foreach (var item in items)
        //    {
        //        totalCount += item.TotalInstances;
        //        totalCost += item.Cost;
        //    }
        //    List<ContentsReceipts> contentAndAdmissions = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == Id).ToList();
        //    for (int i = 0; i < contentAndAdmissions.Count; i++)
        //    {
        //        if (contentAndAdmissions[i].IdContents == 1)
        //        {
        //            natural += (int)contentAndAdmissions[i].Counts;
        //        }
        //    }
        //    str = totalCount + "по стоимости " + totalCost + "\n" + natural;
        //}


    }
}
