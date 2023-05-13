using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows;
using System.Net.NetworkInformation;

namespace KSU
{
    public class ClassResultsOne
    {
        public List<Results> DataList { get; }

        public ClassResultsOne()
        {
            int _countBegining = 42655, _cost = 0, _natural = 6281, _social = 3304, _human = 26145, _metodical = 21, _reference = 218, _art = 6686, _print = 42655, _electr = 0, _period = 0;
            // идентификатор книг по содержанию, количество которой нужно подсчитать
            int contentId = 1, contentIdTwo = 2, contentIdThree = 3, contentIdFour = 4, contentIdFive = 5, contentIdSix = 6;
            // идентификатор книг по виду, количество которой нужно подсчитать 
            int viewId = 1, viewIdTwo = 2, viewIdThree = 3;

            // 2018 год
            int year = 2018;  // указываем год, за который хотим посчитать
            DateTime startDate = new DateTime(year, 1, 1);
            DateTime endDate = new DateTime(year, 12, 31);
            int totalCount = 0, natural = 0, social = 0, human = 0, metodical = 0, reference = 0, art = 0, print = 0, electr = 0, period = 0;
            double totalCost = 0;
            var items = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= startDate && x.Date <= endDate);
            foreach (var item in items)
            {
                totalCount += item.TotalInstances;
                totalCost += item.Cost;
            }
            foreach (var item in items)
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { natural += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { social += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { human += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodical += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { reference += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art += (int)itemContent.Counts; }
                }
            }
            foreach (var item in items)
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатные
                    { print += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo)  //Электронные
                    { electr += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree) //Периодические издания
                    { period += (int)itemView.Counts; }
                }
            }
            int _countBeginingYear19 = 0, _costYear19 = 0, _naturalYear19 = 0, _socialYear19 = 0, _humanYear19 = 0, _metodicalYear19 = 0, _referenceYear19 = 0, _artYear19 = 0, _printYear19 = 0, _electrYear19 = 0, _periodYear19 = 0;
            //Подсчеты сколько состоит на начало 2019 года
            _countBeginingYear19 = _countBegining + totalCount; //Состоит на предыдущий год + Поступление - Выбытие
            _naturalYear19 = _natural + natural;
            _socialYear19 = _social + social;
            _referenceYear19 = _reference + reference;
            _humanYear19 = _human + human;
            _metodicalYear19 = _metodical + metodical;
            _artYear19 = _art + art;
            _printYear19 = _print + print;
            _electrYear19 = _electr + electr;
            _periodYear19 = _period + period;
            int year19 = 2019;
            DateTime startDate19 = new DateTime(year19, 1, 1);
            DateTime endDate19 = new DateTime(year19, 12, 31);
            int totalCount19 = 0, natural19 = 0, social19 = 0, human19 = 0, metodical19 = 0, reference19 = 0, art19 = 0, print19 = 0, electr19 = 0, period19 = 0;
            double totalCost19 = 0; //Общая стоимость
            var items19 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= startDate19 && x.Date <= endDate19);
            foreach (var item in items19)
            {
                totalCount19 += item.TotalInstances; totalCost19 += item.Cost;
            } //Вычисление кол-ва и стоимости
            foreach (var item in items19)
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    {
                        natural19 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    {
                        social19 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    {
                        human19 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    {
                        metodical19 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    {
                        reference19 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    {
                        art19 += (int)itemContent.Counts;
                    }
                }
            } //Вычисление по содержанию
            foreach (var item in items19)
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId)
                    {
                        print19 += (int)itemView.Counts; //Печатные
                    }
                    if (itemView.IdViews == viewIdTwo)
                    {
                        electr19 += (int)itemView.Counts; //Электронные
                    }
                    if (itemView.IdViews == viewIdThree)
                    {
                        period19 += (int)itemView.Counts; //Периодические издания
                    }
                }
            } //Вычисление по виду
            int totalCountDis = 0, naturalDis = 0, socialDis = 0, humanDis = 0, metodicalDis = 0, referenceDis = 0, artDis = 0, printDis = 0, electrDis = 0, periodDis = 0;
            double totalCostDis = 0; //Общая стоимость
            var itemss = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= startDate19 && x.Date <= endDate19);
            foreach (var item in itemss)
            {
                totalCountDis += item.TotalNumber;
                totalCostDis += item.Cost;
            } //Вычисление кол-ва и стоимости
            foreach (var item in itemss)
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    {
                        naturalDis += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    {
                        socialDis += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    {
                        humanDis += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    {
                        metodicalDis += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    {
                        referenceDis += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    {
                        artDis += (int)itemContent.Counts;
                    }
                }
            } //Вычисление по содержанию
            foreach (var item in itemss)
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId)
                    {
                        printDis += (int)itemView.Counts; //Печатные
                    }
                    if (itemView.IdViews == viewIdTwo)
                    {
                        electrDis += (int)itemView.Counts; //Электронные
                    }
                    if (itemView.IdViews == viewIdThree)
                    {
                        periodDis += (int)itemView.Counts; //Периодические издания
                    }
                }
            } //Вычисление по виду
            int _countBeginingYear20 = 0, _costYear20 = 0, _naturalYear20 = 0, _socialYear20 = 0, _humanYear20 = 0, _metodicalYear20 = 0, _referenceYear20 = 0, _artYear20 = 0, _printYear20 = 0, _electrYear20 = 0, _periodYear20 = 0;
            //Подсчеты сколько состоит на начало 2020 года
            _countBeginingYear20 = _countBeginingYear19 + totalCount19 - totalCountDis;
            _naturalYear20 = _naturalYear19 + natural19 - naturalDis;
            _socialYear20 = _socialYear19 + social19 - socialDis;
            _referenceYear20 = _referenceYear19 + reference19 - referenceDis;
            _humanYear20 = _humanYear19 + human19 - humanDis;
            _metodicalYear20 = _metodicalYear19 + metodical19 - metodicalDis;
            _artYear20 = _artYear19 + art19 - artDis;
            _printYear20 = _printYear19 + print19 - printDis;
            _electrYear20 = _electrYear19 + electr19 - electrDis;
            _periodYear20 = _periodYear19 + period19 - periodDis;
            int year20 = 2020;
            DateTime startDate20 = new DateTime(year20, 1, 1);
            DateTime endDate20 = new DateTime(year20, 12, 31);
            double totalCost20 = 0; //Общая стоимость
            int totalCount20 = 0, natural20 = 0, social20 = 0, human20 = 0, metodical20 = 0, reference20 = 0, art20 = 0, print20 = 0, electr20 = 0, period20 = 0;
            var items20 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= startDate20 && x.Date <= endDate20);
            foreach (var item in items20)
            {
                totalCount20 += item.TotalInstances;
                totalCost20 += item.Cost;
            } //Вычисление кол-ва и стоимости
            foreach (var item in items20)
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    {
                        natural20 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    {
                        social20 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    {
                        human20 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    {
                        metodical20 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    {
                        reference20 += (int)itemContent.Counts;
                    }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    {
                        art20 += (int)itemContent.Counts;
                    }
                }
            } //Вычисление по содержанию
            foreach (var item in items20)
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId)
                    {
                        print20 += (int)itemView.Counts; //Печатные
                    }
                    if (itemView.IdViews == viewIdTwo)
                    {
                        electr20 += (int)itemView.Counts; //Электронные
                    }
                    if (itemView.IdViews == viewIdThree)
                    {
                        period20 += (int)itemView.Counts; //Периодические издания
                    }
                }
            } //Вычисление по виду



            // В конструкторе заполняем список данных
            DataList = new List<Results>();           
            DataList.Add(new Results() { FundMomentOne = "Состоит на 01.01.2018 г.", TotalCountOne = 42655, TotalCostOne = 0, NaturalSocialOne = 6281, SocialOne = 3304, HumanitarianOne = 26145, MetodicalOne = 21, ReferenceOne = 218, ArtOne = 6686, PrentedOne = 42655, ElectronicOne = 0, PeriodichOne = 0, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Поступило за 2018 г.", TotalCountOne = totalCount, TotalCostOne = totalCost, NaturalSocialOne = natural, SocialOne = social, HumanitarianOne = human, MetodicalOne = metodical, ReferenceOne = reference, ArtOne = art, PrentedOne = print, ElectronicOne = electr, PeriodichOne = period, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Состоит на 01.01.2019 г.", TotalCountOne = _countBeginingYear19, TotalCostOne = _costYear19, NaturalSocialOne = _naturalYear19, SocialOne = _socialYear19, HumanitarianOne = _humanYear19, MetodicalOne = _metodicalYear19, ReferenceOne = _referenceYear19, ArtOne = _artYear19, PrentedOne = _printYear19, ElectronicOne = _electrYear19, PeriodichOne = _periodYear19, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Поступило за 2019 г.", TotalCountOne = totalCount19, TotalCostOne = totalCost19, NaturalSocialOne = natural19, SocialOne = social19, HumanitarianOne = human19, MetodicalOne = metodical19, ReferenceOne = reference19, ArtOne = art19, PrentedOne = print19, ElectronicOne = _electrYear19, PeriodichOne = period19, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Выбыло за 2019 г.", TotalCountOne = totalCountDis, TotalCostOne = totalCostDis, NaturalSocialOne = naturalDis, SocialOne = socialDis, HumanitarianOne = humanDis, MetodicalOne = metodicalDis, ReferenceOne = referenceDis, ArtOne = artDis, PrentedOne = printDis, ElectronicOne = electrDis, PeriodichOne = periodDis, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Состоит на 01.01.2020 г.", TotalCountOne = _countBeginingYear20, TotalCostOne = _costYear20, NaturalSocialOne = _naturalYear20, SocialOne = _socialYear20, HumanitarianOne = _humanYear20, MetodicalOne = _metodicalYear20, ReferenceOne = _referenceYear20, ArtOne = _artYear20, PrentedOne = _printYear20, ElectronicOne = _electrYear20, PeriodichOne = _periodYear20, NotesOne = "" });
            
            DataList.Add(new Results() { FundMomentOne = "Поступило за 2020 г.", TotalCountOne = _countBeginingYear19, TotalCostOne = _costYear19, NaturalSocialOne = _naturalYear19, SocialOne = _socialYear19, HumanitarianOne = _humanYear19, MetodicalOne = _metodicalYear19, ReferenceOne = _referenceYear19, ArtOne = _artYear19, PrentedOne = _printYear19, ElectronicOne = _electrYear19, PeriodichOne = _periodYear19, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Выбыло за 2020 г.", TotalCountOne = _countBeginingYear19, TotalCostOne = _costYear19, NaturalSocialOne = _naturalYear19, SocialOne = _socialYear19, HumanitarianOne = _humanYear19, MetodicalOne = _metodicalYear19, ReferenceOne = _referenceYear19, ArtOne = _artYear19, PrentedOne = _printYear19, ElectronicOne = _electrYear19, PeriodichOne = _periodYear19, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Состоит на 01.01.2021 г.", TotalCountOne = _countBeginingYear19, TotalCostOne = _costYear19, NaturalSocialOne = _naturalYear19, SocialOne = _socialYear19, HumanitarianOne = _humanYear19, MetodicalOne = _metodicalYear19, ReferenceOne = _referenceYear19, ArtOne = _artYear19, PrentedOne = _printYear19, ElectronicOne = _electrYear19, PeriodichOne = _periodYear19, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Выбыло за 1 кв. 2021 г.", TotalCountOne = _countBeginingYear19, TotalCostOne = _costYear19, NaturalSocialOne = _naturalYear19, SocialOne = _socialYear19, HumanitarianOne = _humanYear19, MetodicalOne = _metodicalYear19, ReferenceOne = _referenceYear19, ArtOne = _artYear19, PrentedOne = _printYear19, ElectronicOne = _electrYear19, PeriodichOne = _periodYear19, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Состоит на 2 кв. 2021 г.", TotalCountOne = _countBeginingYear19, TotalCostOne = _costYear19, NaturalSocialOne = _naturalYear19, SocialOne = _socialYear19, HumanitarianOne = _humanYear19, MetodicalOne = _metodicalYear19, ReferenceOne = _referenceYear19, ArtOne = _artYear19, PrentedOne = _printYear19, ElectronicOne = _electrYear19, PeriodichOne = _periodYear19, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Поступило за 2 кв. 2021 г.", TotalCountOne = _countBeginingYear19, TotalCostOne = _costYear19, NaturalSocialOne = _naturalYear19, SocialOne = _socialYear19, HumanitarianOne = _humanYear19, MetodicalOne = _metodicalYear19, ReferenceOne = _referenceYear19, ArtOne = _artYear19, PrentedOne = _printYear19, ElectronicOne = _electrYear19, PeriodichOne = _periodYear19, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Состоит на 3 кв. 2021 г.", TotalCountOne = _countBeginingYear19, TotalCostOne = _costYear19, NaturalSocialOne = _naturalYear19, SocialOne = _socialYear19, HumanitarianOne = _humanYear19, MetodicalOne = _metodicalYear19, ReferenceOne = _referenceYear19, ArtOne = _artYear19, PrentedOne = _printYear19, ElectronicOne = _electrYear19, PeriodichOne = _periodYear19, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Состоит на 4 кв. 2021 г.", TotalCountOne = _countBeginingYear19, TotalCostOne = _costYear19, NaturalSocialOne = _naturalYear19, SocialOne = _socialYear19, HumanitarianOne = _humanYear19, MetodicalOne = _metodicalYear19, ReferenceOne = _referenceYear19, ArtOne = _artYear19, PrentedOne = _printYear19, ElectronicOne = _electrYear19, PeriodichOne = _periodYear19, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Поступило за 4 кв. 2021 г.", TotalCountOne = _countBeginingYear19, TotalCostOne = _costYear19, NaturalSocialOne = _naturalYear19, SocialOne = _socialYear19, HumanitarianOne = _humanYear19, MetodicalOne = _metodicalYear19, ReferenceOne = _referenceYear19, ArtOne = _artYear19, PrentedOne = _printYear19, ElectronicOne = _electrYear19, PeriodichOne = _periodYear19, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Выбыло за 4 кв. 2021 г.", TotalCountOne = _countBeginingYear19, TotalCostOne = _costYear19, NaturalSocialOne = _naturalYear19, SocialOne = _socialYear19, HumanitarianOne = _humanYear19, MetodicalOne = _metodicalYear19, ReferenceOne = _referenceYear19, ArtOne = _artYear19, PrentedOne = _printYear19, ElectronicOne = _electrYear19, PeriodichOne = _periodYear19, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Итого поступило за год", TotalCountOne = _countBeginingYear19, TotalCostOne = _costYear19, NaturalSocialOne = _naturalYear19, SocialOne = _socialYear19, HumanitarianOne = _humanYear19, MetodicalOne = _metodicalYear19, ReferenceOne = _referenceYear19, ArtOne = _artYear19, PrentedOne = _printYear19, ElectronicOne = _electrYear19, PeriodichOne = _periodYear19, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Выбыло", TotalCountOne = _countBeginingYear19, TotalCostOne = _costYear19, NaturalSocialOne = _naturalYear19, SocialOne = _socialYear19, HumanitarianOne = _humanYear19, MetodicalOne = _metodicalYear19, ReferenceOne = _referenceYear19, ArtOne = _artYear19, PrentedOne = _printYear19, ElectronicOne = _electrYear19, PeriodichOne = _periodYear19, NotesOne = "" });

        }       
    }
    public class Results
    {
        public string FundMomentOne { get; set; }
        public int TotalCountOne { get; set; }
        public double TotalCostOne { get; set; }
        public int NaturalSocialOne { get; set; }
        public int SocialOne { get; set; }
        public int HumanitarianOne { get; set; }
        public int MetodicalOne { get; set; }
        public int ReferenceOne { get; set; }
        public int ArtOne { get; set; }
        public int PrentedOne { get; set; }
        public int ElectronicOne { get; set; }
        public int PeriodichOne { get; set; }
        public string NotesOne { get; set; }
    }
}
