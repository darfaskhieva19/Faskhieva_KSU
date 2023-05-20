using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using static KSU.ClassResultThree;

namespace KSU
{
    public class ClassTotalResults
    {
        /// <summary>
        /// Класс для хранения данных
        /// </summary>
        public class TotalResults
        {
            public string FundMomentTotal { get; set; }
            public int TotalCount { get; set; }
            public double TotalCost { get; set; }
            public int NaturalSocialTotal { get; set; }
            public int SocialTotal { get; set; }
            public int HumanitarianTotal { get; set; }
            public int MetodicalTotal { get; set; }
            public int ReferenceTotal { get; set; }
            public int ArtTotal { get; set; }
            public int PrentedTotal { get; set; }
            public int ElectronicTotal { get; set; }
            public int PeriodichTotal { get; set; }
            public string NotesTotal { get; set; }
        }

        public List<TotalResults> DataList { get; }

        /// <summary>
        /// Для подсчетов общих итогов
        /// </summary>
        public ClassTotalResults()
        {
            //Состоит на начало 2018 года
            int _count = 103149, _natural = 12034, _social = 5973, _human = 65147, _metodical = 31, _reference = 640, _art = 19324, _print = 103149, _electr = 0, _period = 0;
            double _cost = 0;
            // идентификатор книг по содержанию, количество которой нужно подсчитать
            int contentId = 1, contentIdTwo = 2, contentIdThree = 3, contentIdFour = 4, contentIdFive = 5, contentIdSix = 6;
            // идентификатор книг по виду, количество которой нужно подсчитать 
            int viewId = 1, viewIdTwo = 2, viewIdThree = 3;

            int startYear = 2018;
            DateTime _startDate = new DateTime(startYear, 1, 1);
            DateTime _endDate = new DateTime(startYear, 12, 31);
            string _title = "Состоит на 01.01." + startYear + " г.";
            string _titl = "Поступило за " + startYear + " г.";
            //Поступление за выбранный год
            var _item = DataBase.Base.Receipts.Where(x => x.Date >= _startDate && x.Date <= _endDate);
            int _totCount = 0, _nat = 0, _soc = 0, _hum = 0, _met = 0, _ref = 0, _arts = 0, _prt = 0, _el = 0, _per = 0;
            double _totCost = 0;
            foreach (var item in _item)
            {
                _totCount += item.TotalInstances;
                _totCost += item.Cost;
            }
            foreach (var item in _item)
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _nat += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _soc += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _hum += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _met += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _ref += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _arts += (int)itemContent.Counts; }
                }
            }
            foreach (var item in _item)
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _prt += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _el += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _per += (int)itemView.Counts; }
                }
            }
            int _year19 = 2019;
            DateTime _startDat = new DateTime(_year19, 1, 1);
            DateTime _endDat = new DateTime(_year19, 12, 31);
            string _title19 = "Состоит на 01.01." + _year19 + " г.";
            string _titl19 = "Поступило за " + _year19 + " г.";
            string title = "Выбыло за " + _year19 + " г.";
            int _count19 = _count + _totCount, _natural19 = _natural + _nat, _social19 = _social + _soc, _human19 = _human + _hum, _metodical19 = _metodical + _met, _reference19 = _reference + _ref, _art19 = _art + _arts, _print19 = _print + _prt, _electr19 = _electr + _el, _period19 = _period + _per;
            double _cost19 = 0;
            //Поступление 2019
            var _ite = DataBase.Base.Receipts.Where(x => x.Date >= _startDat && x.Date <= _endDat);
            int _totCount19 = 0, _nat19 = 0, _soc19 = 0, _hum19 = 0, _met19 = 0, _ref19 = 0, _arts19 = 0, _prt19 = 0, _el19 = 0, _per19 = 0;
            double _totCost19 = 0;
            foreach (var item in _ite)
            {
                _totCount19 += item.TotalInstances;
                _totCost19 += item.Cost;
            }
            foreach (var item in _ite)
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _nat19 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _soc19 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _hum19 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _met19 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _ref19 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _arts19 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in _ite)
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _prt19 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _el19 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _per19 += (int)itemView.Counts; }
                }
            }
            //Выбытие 2019
            var _it = DataBase.Base.Disposals.Where(x => x.Date >= _startDat && x.Date <= _endDat);
            int totCount = 0, nat = 0, soc = 0, hum = 0, met = 0, refs = 0, art = 0, prt = 0, el = 0, per = 0;
            double cost = 0;
            foreach (var item in _it)
            {
                totCount += item.TotalNumber;
                cost += item.Cost;
            }
            foreach (var item in _it)
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { nat += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { soc += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { hum += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { met += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { refs += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art += (int)itemContent.Counts; }
                }
            }
            foreach (var item in _it)
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { prt += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { el += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { per += (int)itemView.Counts; }
                }
            }

            int _year20 = 2020;
            DateTime _startDate20 = new DateTime(_year20, 1, 1);
            DateTime _endDate20 = new DateTime(_year20, 12, 31);
            string _title20 = "Состоит на 01.01." + _year20 + " г.";
            string _titl20 = "Поступило за " + _year20 + " г.";
            string title20 = "Выбыло за " + _year20 + " г.";
            int _count20 = _count19 + _totCount19 - totCount, _natural20 = _natural19 + _nat19 - nat, _social20 = _social19 + _soc19 - soc, _human20 = _human19 + _hum19 - hum, _metodical20 = _metodical19 + _met19 - met, _reference20 = _reference19 + _ref19 - refs, _art20 = _art19 + _arts19 - art, _print20 = _print19 + _prt19 - prt, _electr20 = _electr19 + _el19 - el, _period20 = _period19 + _per19 - per;
            double _cost20 = 0;
            //Поступление 2020
            var _item20 = DataBase.Base.Receipts.Where(x => x.Date >= _startDate20 && x.Date <= _endDate20);
            int _totCount20 = 0, _nat20 = 0, _soc20 = 0, _hum20 = 0, _met20 = 0, _ref20 = 0, _arts20 = 0, _prt20 = 0, _el20 = 0, _per20 = 0;
            double _totCost20 = 0;
            foreach (var item in _item20)
            {
                _totCount20 += item.TotalInstances;
                _totCost20 += item.Cost;
            }
            foreach (var item in _item20)
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _nat20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _soc20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _hum20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _met20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _ref20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _arts20 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in _item20)
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _prt20 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _el20 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _per20 += (int)itemView.Counts; }
                }
            }
            //Выбытие 2020
            var _it20 = DataBase.Base.Disposals.Where(x => x.Date >= _startDate20 && x.Date <= _endDate20);
            int totCount20 = 0, nat20 = 0, soc20 = 0, hum20 = 0, met20 = 0, refs20 = 0, art20 = 0, prt20 = 0, el20 = 0, per20 = 0;
            double cost20 = 0;
            foreach (var item in _it20)
            {
                totCount20 += item.TotalNumber;
                cost20 += item.Cost;
            }
            foreach (var item in _it20)
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { nat20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { soc20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { hum20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { met20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { refs20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art20 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in _it20)
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { prt20 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { el20 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { per20 += (int)itemView.Counts; }
                }
            }

            int _year21 = 2021;
            // Диапазон первого квартала
            DateTime January = new DateTime(_year21, 1, 1);
            DateTime March = new DateTime(_year21, 3, 31);
            // Диапазон второго квартала
            DateTime April = new DateTime(_year21, 4, 1);
            DateTime June = new DateTime(_year21, 6, 30);
            // Диапазон третьего квартала
            DateTime July = new DateTime(_year21, 7, 1);
            DateTime September = new DateTime(_year21, 9, 30);
            // Диапазон четвертого квартала
            DateTime October = new DateTime(_year21, 10, 1);
            DateTime December = new DateTime(_year21, 12, 31);
            string _title21 = "Состоит на 01.01." + _year21 + " г.";
            string title21 = "Выбыло за 1 кв. " + _year21 + " г.";
            int _count21 = _count20 + _totCount20 - totCount20, _natural21 = _natural20 + _nat20 - nat20, _social21 = _social20 + _soc20 - soc20, _human21 = _human20 + _hum20 - hum20, _metodical21 = _metodical20 + _met20 - met20, _reference21 = _reference20 + _ref20 - refs20, _art21 = _art20 + _arts20 - art20, _print21 = _print20 + _prt20 - prt20, _electr21 = _electr20 + _el20 - el20, _period21 = _period20 + _per20 - per20;
            double _cost21 = 0;
            //Выбытие 2021
            var _it21 = DataBase.Base.Disposals.Where(x => x.Date >= January && x.Date <= March);
            int totCount21 = 0, nat21 = 0, soc21 = 0, hum21 = 0, met21 = 0, refs21 = 0, art21 = 0, prt21 = 0, el21 = 0, per21 = 0;
            double cost21 = 0;
            foreach (var item in _it21)
            {
                totCount21 += item.TotalNumber;
                cost21 += item.Cost;
            }
            foreach (var item in _it21)
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { nat21 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { soc21 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { hum21 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { met21 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { refs21 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art21 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in _it21)
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { prt21 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { el21 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { per21 += (int)itemView.Counts; }
                }
            }
            string _titl21 = "Поступило за 2 кв. " + _year21 + " г.";
            string _title21Q2 = "Состоит на 2 кв. 01.01." + _year21 + " г.";
            int _count21Q2 = _count21 - totCount21, _natural21Q2 = _natural21 - nat21, _social21Q2 = _social21 - soc21, _human21Q2 = _human21 - hum21, _metodical21Q2 = _metodical21 - met21, _reference21Q2 = _reference21 - refs21, _art21Q2 = _art21 - art21, _print21Q2 = _print21 - prt21, _electr21Q2 = _electr21 - el21, _period21Q2 = _period21 - per21;
            double _cost21Q2 = 0;
            //Поступление 2021 2 кв.
            var _item21 = DataBase.Base.Receipts.Where(x =>x.Date >= April && x.Date <= June);
            int _totCount21 = 0, _nat21 = 0, _soc21 = 0, _hum21 = 0, _met21 = 0, _ref21 = 0, _arts21 = 0, _prt21 = 0, _el21 = 0, _per21 = 0;
            double _totCost21 = 0;
            foreach (var item in _item21)
            {
                _totCount21 += item.TotalInstances;
                _totCost21 += item.Cost;
            }
            foreach (var item in _item21)
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _nat21 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _soc21 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _hum21 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _met21 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _ref21 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _arts21 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in _item21)
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _prt21 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _el21 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _per21 += (int)itemView.Counts; }
                }
            }
            string _title21Q4 = "Состоит на 4 кв. 01.01." + _year21 + " г.";
            int _count21Q4 = _count21 - totCount21, _natural21Q4 = _natural21Q2 + _nat21, _social21Q4 = _social21Q2 + _soc21, _human21Q4 = _human21Q2 + _hum21, _metodical21Q4 = _metodical21Q2 + _met21, _reference21Q4 = _reference21Q2 + _ref21, _art21Q4 = _art21Q2 + _art21, _print21Q4 = _print21Q2 + _prt21, _electr21Q4 = _electr21Q2 + _el21, _period21Q4 = _period21Q2 + _per21;
            double _cost21Q4 = 0;



            DataList = new List<TotalResults>();
            DataList.Add(new TotalResults() { FundMomentTotal = _title, TotalCount = 103149, TotalCost = 0, NaturalSocialTotal = 12034, SocialTotal = 5973, HumanitarianTotal = 65147, MetodicalTotal = 31, ReferenceTotal = 640, ArtTotal = 19324, PrentedTotal = 103149, ElectronicTotal = 0, PeriodichTotal = 0, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = _titl, TotalCount = _totCount, TotalCost = _totCost, NaturalSocialTotal = _nat, SocialTotal = _soc, HumanitarianTotal = _hum, MetodicalTotal = _met, ReferenceTotal = _ref, ArtTotal = _arts, PrentedTotal = _prt, ElectronicTotal = _el, PeriodichTotal = _per, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = _title19, TotalCount = _count19, TotalCost = _cost19, NaturalSocialTotal = _natural19, SocialTotal = _social19, HumanitarianTotal = _human19, MetodicalTotal = _metodical19, ReferenceTotal = _reference19, ArtTotal = _art19, PrentedTotal = _print19, ElectronicTotal = _electr19, PeriodichTotal = _period19, NotesTotal = "" });
            //2019
            DataList.Add(new TotalResults() { FundMomentTotal = _titl19, TotalCount = _totCount19, TotalCost = _totCost19, NaturalSocialTotal = _nat19, SocialTotal = _soc19, HumanitarianTotal = _hum19, MetodicalTotal = _met19, ReferenceTotal = _ref19, ArtTotal = _arts19, PrentedTotal = _prt19, ElectronicTotal = _el19, PeriodichTotal = _per19, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = title, TotalCount = totCount, TotalCost = cost, NaturalSocialTotal = nat, SocialTotal = soc, HumanitarianTotal = hum, MetodicalTotal = met, ReferenceTotal = refs, ArtTotal = art, PrentedTotal = prt, ElectronicTotal = el, PeriodichTotal = per, NotesTotal = "" });
            //2020
            DataList.Add(new TotalResults() { FundMomentTotal = _title20, TotalCount = _count20, TotalCost = _cost20, NaturalSocialTotal = _natural20, SocialTotal = _social20, HumanitarianTotal = _human20, MetodicalTotal = _metodical20, ReferenceTotal = _reference20, ArtTotal = _art20, PrentedTotal = _print20, ElectronicTotal = _electr20, PeriodichTotal = _period20, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = _titl20, TotalCount = _totCount20, TotalCost = _totCost20, NaturalSocialTotal = _nat20, SocialTotal = _soc20, HumanitarianTotal = _hum20, MetodicalTotal = _met20, ReferenceTotal = _ref20, ArtTotal = _arts20, PrentedTotal = _prt20, ElectronicTotal = _el20, PeriodichTotal = _per20, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = title20, TotalCount = totCount20, TotalCost = cost20, NaturalSocialTotal = nat20, SocialTotal = soc20, HumanitarianTotal = hum20, MetodicalTotal = met20, ReferenceTotal = refs20, ArtTotal = art20, PrentedTotal = prt20, ElectronicTotal = el20, PeriodichTotal = per20, NotesTotal = "" });
            //2021
            DataList.Add(new TotalResults() { FundMomentTotal = _title21, TotalCount = _count21, TotalCost = _cost21, NaturalSocialTotal = _natural21, SocialTotal = _social21, HumanitarianTotal = _human21, MetodicalTotal = _metodical21, ReferenceTotal = _reference21, ArtTotal = _art21, PrentedTotal = _print21, ElectronicTotal = _electr21, PeriodichTotal = _period21, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = title21, TotalCount = totCount21, TotalCost = cost21, NaturalSocialTotal = nat21, SocialTotal = soc21, HumanitarianTotal = hum21, MetodicalTotal = met21, ReferenceTotal = refs21, ArtTotal = art21, PrentedTotal = prt21, ElectronicTotal = el21, PeriodichTotal = per21, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = _title21Q2, TotalCount = _count21Q2, TotalCost = _cost21Q2, NaturalSocialTotal = _natural21Q2, SocialTotal = _social21Q2, HumanitarianTotal = _human21Q2, MetodicalTotal = _metodical21Q2, ReferenceTotal = _reference21Q2, ArtTotal = _art21Q2, PrentedTotal = _print21Q2, ElectronicTotal = _electr21Q2, PeriodichTotal = _period21Q2, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = _titl21, TotalCount = _totCount21, TotalCost = _totCost21, NaturalSocialTotal = _nat21, SocialTotal = _soc21, HumanitarianTotal = _hum21, MetodicalTotal = _met21, ReferenceTotal = _ref21, ArtTotal = _arts21, PrentedTotal = _prt21, ElectronicTotal = _el21, PeriodichTotal = _per21, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = _title21Q4, TotalCount = _count21Q4, TotalCost = _cost21Q4, NaturalSocialTotal = _natural21Q4, SocialTotal = _social21Q4, HumanitarianTotal = _human21Q4, MetodicalTotal = _metodical21Q4, ReferenceTotal = _reference21Q4, ArtTotal = _art21Q4, PrentedTotal = _print21Q4, ElectronicTotal = _electr21Q4, PeriodichTotal = _period21Q4, NotesTotal = "" });




        }         
    }
}
