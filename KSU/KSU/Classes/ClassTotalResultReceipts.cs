using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSU
{
    public class ClassTotalResultReceipts
    {
        public class TotalResultReceipts
        {
            public string DateReceipts { get; set; }
            public int Number { get; set; }
            public string SourceOfReceipt { get; set; }
            public string SourceOfAcquisition { get; set; }
            public string NumberDocument { get; set; }
            public string DocumentDate { get; set; }
            public int TotalInstances { get; set; }
            public int Counts { get; set; }
            public double Price { get; set; }
            public int DocumentsNotForBalance { get; set; }
            public int NaturalSocial { get; set; }
            public int Social { get; set; }
            public int Humanitarian { get; set; }
            public int Metodical { get; set; }
            public int Reference { get; set; }
            public int Art { get; set; }
            public int Printed { get; set; }
            public int Electronic { get; set; }
            public int Periodich { get; set; }
            public int Dilapidation { get; set; }
            public int Obsolescence { get; set; }
            public int Defectiveness { get; set; }
            public int Loss { get; set; }
        }
        public List<TotalResultReceipts> DataList { get; }

        public ClassTotalResultReceipts()
        {
            // идентификатор книг по содержанию, количество которой нужно подсчитать
            int contentId = 1, contentIdTwo = 2, contentIdThree = 3, contentIdFour = 4, contentIdFive = 5, contentIdSix = 6;
            // идентификатор книг по виду, количество которой нужно подсчитать 
            int viewId = 1, viewIdTwo = 2, viewIdThree = 3;

            string dateTitle = "20.02.2018";

            DateTime date = new DateTime(2018, 02, 20); // задаем нужную дату



            DataList = new List<TotalResultReceipts>();
        }
    }
}
