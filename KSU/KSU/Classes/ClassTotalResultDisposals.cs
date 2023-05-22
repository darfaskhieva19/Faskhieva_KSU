using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KSU.ClassTotalResults;

namespace KSU
{
    public class ClassTotalResultDisposals
    {
        public class TotalResultDisposals
        {
            public string DateDisposals { get; set; }
            public int ActNumber { get; set; }
            public int TotalNumber { get; set; }
            public double Price { get; set; }
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
            public string Place { get; set; }
        }
        public List<TotalResultDisposals> DataList { get; }
       
        public ClassTotalResultDisposals()
        {
            // идентификатор книг по содержанию, количество которой нужно подсчитать
            int contentId = 1, contentIdTwo = 2, contentIdThree = 3, contentIdFour = 4, contentIdFive = 5, contentIdSix = 6;
            // идентификатор книг по виду, количество которой нужно подсчитать 
            int viewId = 1, viewIdTwo = 2, viewIdThree = 3;
            //индентификатор книг по причине выбытия, количество которой нужно посчитать
            int reasonId = 1, reasonIdTwo = 2, reasonIdThree = 3, reasonIdFour = 4;

            string dateTitle = "21.10.2019";
            string placetitle = "ООО «Исток 52»";
            DateTime date = new DateTime(2019, 10, 21); // задаем нужную дату
            var _it = DataBase.Base.Disposals.Where(x => x.Date >= date && x.Date <= date); // выбираем все записи на данную дату
            int totCount = 0, nat = 0, soc = 0, hum = 0, met = 0, refs = 0, art = 0, prt = 0, el = 0, per = 0, dil = 0, obs = 0, def = 0, loss = 0;
            double cost = 0;

            foreach (var item in _it)
            {
                totCount += item.TotalNumber; // суммируем общее количество документов 
                cost += item.Cost; // суммируем общую стоимость документов
                
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {                   
                    if (itemContent.IdContents == contentId)
                    { nat += (int)itemContent.Counts; } // естественные науки
                    if (itemContent.IdContents == contentIdTwo)
                    { soc += (int)itemContent.Counts; } // технические науки
                    if (itemContent.IdContents == contentIdThree)
                    { hum += (int)itemContent.Counts; } // Гуманитарные науки
                    if (itemContent.IdContents == contentIdFour)
                    { met += (int)itemContent.Counts; } // Методическая литература
                    if (itemContent.IdContents == contentIdFive)
                    { refs += (int)itemContent.Counts; } // Справочная литература
                    if (itemContent.IdContents == contentIdSix)
                    { art += (int)itemContent.Counts; } // Художественная литература
                }
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {                 
                    if (itemView.IdViews == viewId)
                    { prt += (int)itemView.Counts; } // Печатный
                    if (itemView.IdViews == viewIdTwo)
                    { el += (int)itemView.Counts; } // Электронный
                    if (itemView.IdViews == viewIdThree)
                    { per += (int)itemView.Counts; } // Периодические издания
                }
                var reasonDisposals = DataBase.Base.ReasonDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var reasonView in reasonDisposals)
                {
                    if (reasonView.IdReason == reasonId)
                    { dil += (int)reasonView.Counts; } // Ветхость
                    if (reasonView.IdReason == reasonIdTwo)
                    { obs += (int)reasonView.Counts; } // Устарелость
                    if (reasonView.IdReason == reasonIdThree)
                    { def += (int)reasonView.Counts; } // Дефектность
                    if (reasonView.IdReason == reasonIdFour)
                    { loss += (int)reasonView.Counts; } // Утрата
                }
            }


            DataList = new List<TotalResultDisposals>();
            DataList.Add(new TotalResultDisposals() { DateDisposals = dateTitle, ActNumber = 1, TotalNumber = totCount, Price = cost, NaturalSocial = nat, Social = soc, Humanitarian = hum, Metodical = met, Reference = refs, Art = art, Printed = prt, Electronic = el, Periodich = per, Dilapidation = dil, Obsolescence = obs, Defectiveness = def, Loss = loss, Place = placetitle }); 
        
        }
    }
}
