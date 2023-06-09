using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using static KSU.ClassResultThree;
using static KSU.ClassTotalResultDisposals;
using System.Collections.ObjectModel;
using static KSU.ClassTotalResultReceipts;
using System.Data.Entity;

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
            int _count21Q4 = _count21Q2 + _totCount21, _natural21Q4 = _natural21Q2 + _nat21, _social21Q4 = _social21Q2 + _soc21, _human21Q4 = _human21Q2 + _hum21, _metodical21Q4 = _metodical21Q2 + _met21, _reference21Q4 = _reference21Q2 + _ref21, _art21Q4 = _art21Q2 + _arts21, _print21Q4 = _print21Q2 + _prt21, _electr21Q4 = _electr21Q2 + _el21, _period21Q4 = _period21Q2 + _per21;
            double _cost21Q4 = 0;
            //Поступление 2021 4 кв.
            var _item21Q4 = DataBase.Base.Receipts.Where(x => x.Date >= October && x.Date <= December);
            string _titl21Q4 = "Поступило за 4 кв. " + _year21 + " г.";
            int _totCount21Q4 = 0, _nat21Q4 = 0, _soc21Q4 = 0, _hum21Q4 = 0, _met21Q4 = 0, _ref21Q4 = 0, _arts21Q4 = 0, _prt21Q4 = 0, _el21Q4 = 0, _per21Q4 = 0;
            double _totCost21Q4 = 0;
            foreach (var item in _item21Q4)
            {
                _totCount21Q4 += item.TotalInstances;
                _totCost21Q4 += item.Cost;

                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _nat21Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _soc21Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _hum21Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _met21Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _ref21Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _arts21Q4 += (int)itemContent.Counts; }
                }
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _prt21Q4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _el21Q4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _per21Q4 += (int)itemView.Counts; }
                }
            }
            var _it21Q4 = DataBase.Base.Disposals.Where(x => x.Date >= October && x.Date <= December);
            string title21Q4 = "Выбыло за 4 кв. " + _year21 + " г.";
            int totCount21Q4 = 0, nat21Q4 = 0, soc21Q4 = 0, hum21Q4 = 0, met21Q4 = 0, refs21Q4 = 0, art21Q4 = 0, prt21Q4 = 0, el21Q4 = 0, per21Q4 = 0;
            double cost21Q4 = 0;
            foreach (var item in _it21Q4)
            {
                totCount21Q4 += item.TotalNumber;
                cost21Q4 += item.Cost;
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { nat21Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { soc21Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { hum21Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { met21Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { refs21Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art21Q4 += (int)itemContent.Counts; }
                }
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { prt21Q4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { el21Q4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { per21Q4 += (int)itemView.Counts; }
                }
            }
            DateTime startDate2021 = new DateTime(_year21, 1, 1);
            DateTime endDate2021 = new DateTime(_year21, 12, 31);
            string title2021 = "Итого поступило за " + _year21 + " г.";
            var Items2021 = DataBase.Base.Receipts.Where(x =>x.Date >= startDate2021 && x.Date <= endDate2021);
            int _totalCount2021 = 0, _natural2021 = 0, _social2021 = 0, _human2021 = 0, _metodical2021 = 0, _reference2021 = 0, _art2021 = 0, _print2021 = 0, _electr2021 = 0, _period2021 = 0;
            double _totalCost2021 = 0;
            foreach (var item in Items2021)
            {
                _totalCount2021 = _totCount21 + _totCount21Q4;
                _totalCost2021 = _totCost21 + _totCost21Q4;
                _natural2021 = _nat21 + _nat21Q4;
                _social2021 = _soc21 + _soc21Q4;
                _human2021 = _hum21 + _hum21Q4;
                _metodical2021 = _met21 + _met21Q4;
                _reference2021 = _ref21 + _ref21Q4;
                _art2021 = _arts21 + _arts21Q4;
                _print2021 = _prt21 + _prt21Q4;
                _electr2021 = _el21 + _el21Q4;
                _period2021 = _per21 + _per21Q4;
            }
            string titleDis2021 = "Выбыло за " + _year21 + " г.";
            int totCount2021 = 0, nat2021 = 0, soc2021 = 0, hum2021 = 0, met2021 = 0, refs2021 = 0, art2021 = 0, prt2021 = 0, el2021 = 0, per2021 = 0;
            double cost2021 = 0;
            var _it2021 = DataBase.Base.Disposals.Where(x => x.Date >= startDate2021 && x.Date <= endDate2021);
            foreach (var item in _it2021)
            {
                totCount2021 = totCount21 + totCount21Q4;
                cost2021 = cost21 + cost21Q4;
                nat2021 = nat21 + nat21Q4;
                soc2021 = soc21 + soc21Q4;
                hum2021 = hum21 + hum21Q4;
                met2021 = met21 + met21Q4;
                refs2021 = refs21 + refs21Q4;
                art2021 = art21 + art21Q4;
                prt2021 = prt21 + prt21Q4;
                el2021 = el21 + el21Q4;
                per2021 = per21 + per21Q4;
            }
            int _year22 = 2022;
            // Диапазон первого квартала
            DateTime Januarys = new DateTime(_year22, 1, 1);
            DateTime Marchs = new DateTime(_year22, 3, 31);
            // Диапазон второго квартала
            DateTime Aprils = new DateTime(_year22, 4, 1);
            DateTime Junes = new DateTime(_year22, 6, 30);
            // Диапазон четвертого квартала
            DateTime Octobers = new DateTime(_year22, 10, 1);
            DateTime Decembers = new DateTime(_year22, 12, 31);
            string _title22 = "Состоит на 01.01." + _year22 + " г.";
            int _count22 = _count21Q4 + _totCount21Q4 - totCount21Q4, _natural22 = _natural21Q4 + _nat21Q4 - nat21Q4, _social22 = _social21Q4 + _soc21Q4 - soc21Q4, _human22 = _human21Q4 + _hum21Q4 - hum21Q4, _metodical22 = _metodical21Q4 + _met21Q4 - met21Q4, _reference22 = _reference21Q4 + _ref21Q4 - refs21Q4, _art22 = _art21Q4 + _arts21Q4 - art21Q4, _print22 = _print21Q4 + _prt21Q4 - prt21Q4, _electr22 = _electr21Q4 + _el21Q4 - el21Q4, _period22 = _period21Q4 + _per21Q4 - per21Q4;
            double _cost22 = 0;
            string title22 = "Выбыло за 1 кв. " + _year22 + " г.";
            var _it22 = DataBase.Base.Disposals.Where(x => x.Date >= Januarys && x.Date <= Marchs);
            int totCount22 = 0, nat22 = 0, soc22 = 0, hum22 = 0, met22 = 0, refs22 = 0, art22 = 0, prt22 = 0, el22 = 0, per22 = 0;
            double cost22 = 0;
            foreach (var item in _it22)
            {
                totCount22 += item.TotalNumber;
                cost22 += item.Cost;
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { nat22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { soc22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { hum22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { met22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { refs22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art22 += (int)itemContent.Counts; }
                }
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { prt22 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { el22 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { per22 += (int)itemView.Counts; }
                }
            }
            string _title22Q2 = "Состоит на 2 кв. 01.01." + _year22 + " г.";
            int _count22Q2 = _count22 - totCount22, _natural22Q2 = _natural22 - nat22, _social22Q2 = _social22 - soc22, _human22Q2 = _human22 - hum22, _metodical22Q2 = _metodical22 - met22, _reference22Q2 = _reference22 - refs22, _art22Q2 = _art22 - art22, _print22Q2 = _print22 - prt22, _electr22Q2 = _electr22 - el22, _period22Q2 = _period22 - per22;
            double _cost22Q2 = 0;
            string _titl22 = "Поступило за 2 кв. " + _year22 + " г.";
            var _item22 = DataBase.Base.Receipts.Where(x => x.Date >= Aprils && x.Date <= Junes);
            int _totCount22 = 0, _nat22 = 0, _soc22 = 0, _hum22 = 0, _met22 = 0, _ref22 = 0, _arts22 = 0, _prt22 = 0, _el22 = 0, _per22 = 0;
            double _totCost22 = 0;
            foreach (var item in _item22)
            {
                _totCount22 += item.TotalInstances;
                _totCost22 += item.Cost;

                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _nat22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _soc22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _hum22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _met22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _ref22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _arts22 += (int)itemContent.Counts; }
                }
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _prt22 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _el22 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _per22 += (int)itemView.Counts; }
                }
            }
            string title22Q2 = "Выбыло за 2 кв. " + _year22 + " г.";
            var _it22Q2 = DataBase.Base.Disposals.Where(x => x.Date >= Aprils && x.Date <= Junes);
            int totCount22Q2 = 0, nat22Q2 = 0, soc22Q2 = 0, hum22Q2 = 0, met22Q2 = 0, refs22Q2 = 0, art22Q2 = 0, prt22Q2 = 0, el22Q2 = 0, per22Q2 = 0;
            double cost22Q2 = 0;
            foreach (var item in _it22Q2)
            {
                totCount22Q2 += item.TotalNumber;
                cost22Q2 += item.Cost;
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { nat22Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { soc22Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { hum22Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { met22Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { refs22Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art22Q2 += (int)itemContent.Counts; }
                }
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { prt22Q2 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { el22Q2 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { per22Q2 += (int)itemView.Counts; }
                }
            }
            string _title22Q4 = "Состоит на 4 кв. 01.01." + _year22 + " г.";
            int _count22Q4 = _count22Q2 + _totCount22 - totCount22Q2, _natural22Q4 = _natural22Q2 + _nat22 - nat22Q2, _social22Q4 = _social22Q2 + _soc22 - soc22Q2, _human22Q4 = _human22Q2 + _hum22 - hum22Q2, _metodical22Q4 = _metodical22Q2 + _met22 - met22Q2, _reference22Q4 = _reference22Q2 + _ref22 - refs22Q2, _art22Q4 = _art22Q2 + _arts22 - art22Q2, _print22Q4 = _print22Q2 + _prt22 - prt22Q2, _electr22Q4 = _electr22Q2 + _el22 - el22Q2, _period22Q4 = _period22Q2 + _per22 - per22Q2;
            double _cost22Q4 = 0;
            string _titl22Q4 = "Поступило за 4 кв. " + _year22 + " г.";
            var _item22Q4 = DataBase.Base.Receipts.Where(x => x.Date >= Octobers && x.Date <= Decembers);
            int _totCount22Q4 = 0, _nat22Q4 = 0, _soc22Q4 = 0, _hum22Q4 = 0, _met22Q4 = 0, _ref22Q4 = 0, _arts22Q4 = 0, _prt22Q4 = 0, _el22Q4 = 0, _per22Q4 = 0;
            double _totCost22Q4 = 0;
            foreach (var item in _item22Q4)
            {
                _totCount22Q4 += item.TotalInstances;
                _totCost22Q4 += item.Cost;

                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _nat22Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _soc22Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _hum22Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _met22Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _ref22Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _arts22Q4 += (int)itemContent.Counts; }
                }
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _prt22Q4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _el22Q4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _per22Q4 += (int)itemView.Counts; }
                }
            }
            string title2022 = "Итого поступило за " + _year22 + " г.";
            DateTime startDate2022 = new DateTime(_year22, 1, 1);
            DateTime endDate2022 = new DateTime(_year22, 12, 31);
            var Items2022 = DataBase.Base.Receipts.Where(x => x.Date >= startDate2022 && x.Date <= endDate2022);
            int _totalCount2022 = 0, _natural2022 = 0, _social2022 = 0, _human2022 = 0, _metodical2022 = 0, _reference2022 = 0, _art2022 = 0, _print2022 = 0, _electr2022 = 0, _period2022 = 0;
            double _totalCost2022 = 0;
            foreach (var item in Items2022)
            {
                _totalCount2022 = _totCount22 + _totCount22Q4;
                _totalCost2022 = _totCost22 + _totCost22Q4;
                _natural2022 = _nat22 + _nat22Q4;
                _social2022 = _soc22 + _soc22Q4;
                _human2022 = _hum22 + _hum22Q4;
                _metodical2022 = _met22 + _met22Q4;
                _reference2022 = _ref22 + _ref22Q4;
                _art2022 = _arts22 + _arts22Q4;
                _print2022 = _prt22 + _prt22Q4;
                _electr2022 = _el22 + _el22Q4;
                _period2022 = _per22 + _per22Q4;
            }
            string titleDis2022 = "Выбыло за " + _year22 + " г.";
            int totCount2022 = 0, nat2022 = 0, soc2022 = 0, hum2022 = 0, met2022 = 0, refs2022 = 0, art2022 = 0, prt2022 = 0, el2022 = 0, per2022 = 0;
            double cost2022 = 0;
            var _it2022 = DataBase.Base.Disposals.Where(x => x.Date >= startDate2022 && x.Date <= endDate2022);
            foreach (var item in _it2022)
            {
                totCount2022 = totCount22 + totCount22Q2;
                cost2022 = cost22 + cost22Q2;
                nat2022 = nat22 + nat22Q2;
                soc2022 = soc22 + soc22Q2;
                hum2022 = hum22 + hum22Q2;
                met2022 = met22 + met22Q2;
                refs2022 = refs22 + refs22Q2;
                art2022 = art22 + art22Q2;
                prt2022 = prt22 + prt22Q2;
                el2022 = el22 + el22Q2;
                per2022 = per22 + per22Q2;
            }
            int _year23 = 2023;
            // Диапазон первого квартала
            DateTime Januar = new DateTime(_year23, 1, 1);
            DateTime Marc = new DateTime(_year23, 3, 31);
            // Диапазон второго квартала
            DateTime Aprl = new DateTime(_year23, 4, 1);
            DateTime Jun = new DateTime(_year23, 6, 30);
            // Диапазон третьего квартала
            DateTime Jul = new DateTime(_year23, 7, 1);
            DateTime Septem = new DateTime(_year23, 9, 30);
            // Диапазон четвертого квартала
            DateTime Octob = new DateTime(_year23, 10, 1);
            DateTime Decem = new DateTime(_year23, 12, 31);
            string _title23 = "Состоит на 01.01." + _year23 + " г.";
            int _count23 = _count22Q4 + _totCount22Q4, _natural23 = _natural22Q4 + _nat22Q4, _social23 = _social22Q4 + _soc22Q4, _human23 = _human22Q4 + _hum22Q4, _metodical23 = _metodical22Q4 + _met22Q4, _reference23 = _reference22Q4 + _ref22Q4, _art23 = _art22Q4 + _arts22Q4, _print23 = _print22Q4 + _prt22Q4, _electr23 = _electr22Q4 + _el22Q4, _period23 = _period22Q4 + _per22Q4;
            double _cost23 = 0;
            string _titl23 = "Поступило за 1 кв. " + _year23 + " г.";
            var _item23 = DataBase.Base.Receipts.Where(x => x.Date >= Januar && x.Date <= Marc);
            int _totCount23 = 0, _nat23 = 0, _soc23 = 0, _hum23 = 0, _met23 = 0, _ref23 = 0, _arts23 = 0, _prt23 = 0, _el23 = 0, _per23 = 0;
            double _totCost23 = 0;
            foreach (var item in _item23)
            {
                _totCount23 += item.TotalInstances;
                _totCost23 += item.Cost;

                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _nat23 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _soc23 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _hum23 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _met23 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _ref23 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _arts23 += (int)itemContent.Counts; }
                }
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _prt23 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _el23 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _per23 += (int)itemView.Counts; }
                }
            }
            string _title23Q2 = "Состоит на 2 кв. 01.01." + _year23 + " г.";
            int _count23Q2 = _count23 + _totCount23, _natural23Q2 = _natural23 + _nat23, _social23Q2 = _social23 + _soc23, _human23Q2 = _human23 + _hum23, _metodical23Q2 = _metodical23 + _met23, _reference23Q2 = _reference23 + _ref23, _art23Q2 = _art23 + _arts23, _print23Q2 = _print23 + _prt23, _electr23Q2 = _electr23 + _el23, _period23Q2 = _period23 + _per23;
            double _cost23Q2 = 0;

            string _titl23Q2 = "Поступило за 2 кв. " + _year23 + " г.";
            var _item23Q2 = DataBase.Base.Receipts.Where(x => x.Date >= Aprl && x.Date <= Jun);
            int _totCount23Q2 = 0, _nat23Q2 = 0, _soc23Q2 = 0, _hum23Q2 = 0, _met23Q2 = 0, _ref23Q2 = 0, _arts23Q2 = 0, _prt23Q2 = 0, _el23Q2 = 0, _per23Q2 = 0;
            double _totCost23Q2 = 0;
            foreach (var item in _item23Q2)
            {
                _totCount23Q2 += item.TotalInstances;
                _totCost23Q2 += item.Cost;

                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _nat23Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _soc23Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _hum23Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _met23Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _ref23Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _arts23Q2 += (int)itemContent.Counts; }
                }
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _prt23Q2 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _el23Q2 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _per23Q2 += (int)itemView.Counts; }
                }
            }
            string title23Q2 = "Выбыло за 2 кв. " + _year23 + " г.";
            var _it23Q2 = DataBase.Base.Disposals.Where(x => x.Date >= Aprl && x.Date <= Jun);
            int totCount23Q2 = 0, nat23Q2 = 0, soc23Q2 = 0, hum23Q2 = 0, met23Q2 = 0, refs23Q2 = 0, art23Q2 = 0, prt23Q2 = 0, el23Q2 = 0, per23Q2 = 0;
            double cost23Q2 = 0;
            foreach (var item in _it23Q2)
            {
                totCount23Q2 += item.TotalNumber;
                cost23Q2 += item.Cost;
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { nat23Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { soc23Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { hum23Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { met23Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { refs23Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art23Q2 += (int)itemContent.Counts; }
                }
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { prt23Q2 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { el23Q2 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { per23Q2 += (int)itemView.Counts; }
                }
            }
            string _title23Q3 = "Состоит на 3 кв. 01.01." + _year23 + " г.";
            int _count23Q3 = _count23Q2 + _totCount23Q2 - totCount23Q2, _natural23Q3 = _natural23Q2 + _nat23Q2 - nat23Q2, _social23Q3 = _social23Q2 + _soc23Q2 - soc23Q2, _human23Q3 = _human23Q2 + _hum23Q2 - hum23Q2, _metodical23Q3 = _metodical23Q2 + _met23Q2 - met23Q2, _reference23Q3 = _reference23Q2 + _ref23Q2 - refs23Q2, _art23Q3 = _art23Q2 + _arts23Q2 - art23Q2, _print23Q3 = _print23Q2 + _prt23Q2 - prt23Q2, _electr23Q3 = _electr23Q2 + _el23Q2 - el23Q2, _period23Q3 = _period23Q2 + _per23Q2 - per23Q2;
            double _cost23Q3 = 0;
            string _titl23Q3 = "Поступило за 3 кв. " + _year23 + " г.";
            var _item23Q3 = DataBase.Base.Receipts.Where(x => x.Date >= Jul && x.Date <= Septem);
            int _totCount23Q3 = 0, _nat23Q3 = 0, _soc23Q3 = 0, _hum23Q3 = 0, _met23Q3 = 0, _ref23Q3 = 0, _arts23Q3 = 0, _prt23Q3 = 0, _el23Q3 = 0, _per23Q3 = 0;
            double _totCost23Q3 = 0;
            foreach (var item in _item23Q3)
            {
                _totCount23Q3 += item.TotalInstances;
                _totCost23Q3 += item.Cost;

                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _nat23Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _soc23Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _hum23Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _met23Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _ref23Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _arts23Q3 += (int)itemContent.Counts; }
                }
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _prt23Q3 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _el23Q3 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _per23Q3 += (int)itemView.Counts; }
                }
            }
            string title23Q3 = "Выбыло за 3 кв. " + _year23 + " г.";
            var _it23Q3 = DataBase.Base.Disposals.Where(x => x.Date >= Jul && x.Date <= Septem);
            int totCount23Q3 = 0, nat23Q3 = 0, soc23Q3 = 0, hum23Q3 = 0, met23Q3 = 0, refs23Q3 = 0, art23Q3 = 0, prt23Q3 = 0, el23Q3 = 0, per23Q3 = 0;
            double cost23Q3 = 0;
            foreach (var item in _it23Q3)
            {
                totCount23Q3 += item.TotalNumber;
                cost23Q3 += item.Cost;
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { nat23Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { soc23Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { hum23Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { met23Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { refs23Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art23Q3 += (int)itemContent.Counts; }
                }
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { prt23Q3 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { el23Q3 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { per23Q3 += (int)itemView.Counts; }
                }
            }
            string _title23Q4 = "Состоит на 4 кв. 01.01." + _year23 + " г.";
            int _count23Q4 = _count23Q3 + _totCount23Q3 - totCount23Q3, _natural23Q4 = _natural23Q3 + _nat23Q3 - nat23Q3, _social23Q4 = _social23Q3 + _soc23Q3 - soc23Q3, _human23Q4 = _human23Q3 + _hum23Q3 - hum23Q3, _metodical23Q4 = _metodical23Q3 + _met23Q3 - met23Q3, _reference23Q4 = _reference23Q3 + _ref23Q3 - refs23Q3, _art23Q4 = _art23Q3 + _arts23Q3 - art23Q3, _print23Q4 = _print23Q3 + _prt23Q3 - prt23Q3, _electr23Q4 = _electr23Q3 + _el23Q3 - el23Q3, _period23Q4 = _period23Q3 + _per23Q3 - per23Q3;
            double _cost23Q4 = 0;
            string _titl23Q4 = "Поступило за 4 кв. " + _year23 + " г.";
            var _item23Q4 = DataBase.Base.Receipts.Where(x => x.Date >= Octob && x.Date <= Decem);
            int _totCount23Q4 = 0, _nat23Q4 = 0, _soc23Q4 = 0, _hum23Q4 = 0, _met23Q4 = 0, _ref23Q4 = 0, _arts23Q4 = 0, _prt23Q4 = 0, _el23Q4 = 0, _per23Q4 = 0;
            double _totCost23Q4 = 0;
            foreach (var item in _item23Q4)
            {
                _totCount23Q4 += item.TotalInstances;
                _totCost23Q4 += item.Cost;

                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _nat23Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _soc23Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _hum23Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _met23Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _ref23Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _arts23Q4 += (int)itemContent.Counts; }
                }
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _prt23Q4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _el23Q4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _per23Q4 += (int)itemView.Counts; }
                }
            }
            string title23Q4 = "Выбыло за 4 кв. " + _year23 + " г.";
            var _it23Q4 = DataBase.Base.Disposals.Where(x => x.Date >= Octob && x.Date <= Decem);
            int totCount23Q4 = 0, nat23Q4 = 0, soc23Q4 = 0, hum23Q4 = 0, met23Q4 = 0, refs23Q4 = 0, art23Q4 = 0, prt23Q4 = 0, el23Q4 = 0, per23Q4 = 0;
            double cost23Q4 = 0;
            foreach (var item in _it23Q4)
            {
                totCount23Q4 += item.TotalNumber;
                cost23Q4 += item.Cost;
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { nat23Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { soc23Q4 = (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { hum23Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { met23Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { refs23Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art23Q4 += (int)itemContent.Counts; }
                }
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { prt23Q4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { el23Q4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { per23Q4 += (int)itemView.Counts; }
                }
            }
            string title2023 = "Итого поступило за " + _year23 + " г.";
            DateTime startDate2023 = new DateTime(_year23, 1, 1);
            DateTime endDate2023 = new DateTime(_year23, 12, 31);
            var Items2023 = DataBase.Base.Receipts.Where(x => x.Date >= startDate2023 && x.Date <= endDate2023);
            int _totalCount2023 = 0, _natural2023 = 0, _social2023 = 0, _human2023 = 0, _metodical2023 = 0, _reference2023 = 0, _art2023 = 0, _print2023 = 0, _electr2023 = 0, _period2023 = 0;
            double _totalCost2023 = 0;
            foreach (var item in Items2023)
            {
                _totalCount2023 = _totCount23 + _totCount23Q2 + _totCount23Q3 + _totCount23Q4;
                _totalCost2023 = _totCost23 + _totCost23Q2 + _totCost23Q3 + _totCost23Q4;
                _natural2023 = _nat23 + _nat23Q2 + _nat23Q3 + _nat23Q4;
                _social2023 = _soc23 + _soc23Q2 + _soc23Q3 + _soc23Q4;
                _human2023 = _hum23 + _hum23Q2 + _hum23Q3 + _hum23Q4;
                _metodical2023 = _met23 + _met23Q2 + _met23Q3 + _met23Q4;
                _reference2023 = _ref23 + _ref23Q2 + _ref23Q3 + _ref23Q4;
                _art2023 = _arts23 + _arts23Q2 + _arts23Q3 + _arts23Q4;
                _print2023 = _prt23 + _prt23Q2 + _prt23Q3 + _prt23Q4;
                _electr2023 = _el23 + _el23Q2 + _el23Q3 + _el23Q4;
                _period2023 = _per23 + _per23Q2 + _per23Q3 + _per23Q4;
            }
            string titleDis2023 = "Выбыло за " + _year23 + " г.";
            int totCount2023 = 0, nat2023 = 0, soc2023 = 0, hum2023 = 0, met2023 = 0, refs2023 = 0, art2023 = 0, prt2023 = 0, el2023 = 0, per2023 = 0;
            double cost2023 = 0;            
            var _it2023 = DataBase.Base.Disposals.Where(x => x.Date >= startDate2023 && x.Date <= endDate2023);
            foreach (var item in _it2023)
            {
                totCount2023 = totCount23Q2 + totCount23Q3 + totCount23Q4;
                cost2023 = cost23Q2 + cost23Q3 + cost23Q4;
                nat2023 = nat23Q2 + nat23Q3 + nat23Q4;
                soc2023 = soc23Q2 + soc23Q3 + soc23Q4;
                hum2023 = hum23Q2 + hum23Q3 + hum23Q4;
                met2023 = met23Q2 + met23Q3 + met23Q4;
                refs2023 = refs23Q2 + refs23Q3 + refs23Q4;
                art2023 = art23Q2 + art23Q3 + art23Q4;
                prt2023 = prt23Q2 + prt23Q3 + prt23Q4;
                el2023 = el23Q2 + el23Q3 + el23Q4;
                per2023 = per23Q2 + per23Q3 + per23Q4;
            }

            int _year24 = 2024;
            // Диапазон первого квартала
            DateTime Jan = new DateTime(_year24, 1, 1);
            DateTime Mar = new DateTime(_year24, 3, 31);
            // Диапазон второго квартала
            DateTime Apr = new DateTime(_year24, 4, 1);
            DateTime Jn = new DateTime(_year24, 6, 30);
            // Диапазон третьего квартала
            DateTime Jl = new DateTime(_year24, 7, 1);
            DateTime Sept = new DateTime(_year24, 9, 30);
            // Диапазон четвертого квартала
            DateTime Oct = new DateTime(_year24, 10, 1);
            DateTime Dec = new DateTime(_year24, 12, 31);
            string _title24 = "Состоит на 01.01." + _year24 + " г.";
            int _count24 = _count23Q4 + _totCount23Q4 - totCount23Q4, _natural24 = _natural23Q4 + _nat23Q4 - nat23Q4, _social24 = _social23Q4 + _soc23Q4 - soc23Q4, _human24 = _human23Q4 + _hum23Q4 - hum23Q4, _metodical24 = _metodical23Q4 + _met23Q4 - met23Q4, _reference24 = _reference23Q4 + _ref23Q4 - refs23Q4, _art24 = _art23Q4 + _arts23Q4 - art23Q4, _print24 = _print23Q4 + _prt23Q4 - prt23Q4, _electr24 = _electr23Q4 + _el23Q4 - el23Q4, _period24 = _period23Q4 + _per23Q4 - per23Q4;
            double _cost24 = 0;
            string _titl24 = "Поступило за 1 кв. " + _year24 + " г.";
            var _item24 = DataBase.Base.Receipts.Where(x => x.Date >= Jan && x.Date <= Mar);
            int _totCount24 = 0, _nat24 = 0, _soc24 = 0, _hum24 = 0, _met24 = 0, _ref24 = 0, _arts24 = 0, _prt24 = 0, _el24 = 0, _per24 = 0;
            double _totCost24 = 0;
            foreach (var item in _item24)
            {
                _totCount24 += item.TotalInstances;
                _totCost24 += item.Cost;

                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _nat24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _soc24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _hum24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _met24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _ref24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _arts24 += (int)itemContent.Counts; }
                }
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _prt24 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _el24 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _per24 += (int)itemView.Counts; }
                }
            }
            string title24 = "Выбыло за 1 кв. " + _year24 + " г.";
            var _it24 = DataBase.Base.Disposals.Where(x => x.Date >= Jan && x.Date <= Mar);
            int totCount24 = 0, nat24 = 0, soc24 = 0, hum24 = 0, met24 = 0, refs24 = 0, art24 = 0, prt24 = 0, el24 = 0, per24 = 0;
            double cost24 = 0;
            foreach (var item in _it24)
            {
                totCount24 += item.TotalNumber;
                cost24 += item.Cost;
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { nat24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { soc24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { hum24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { met24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { refs24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art24 += (int)itemContent.Counts; }
                }
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { prt24 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { el24 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { per24 += (int)itemView.Counts; }
                }
            }
            string _title24Q2 = "Состоит на 2 кв. 01.01." + _year24 + " г.";
            int _count24Q2 = _count24 + _totCount24 - totCount24, _natural24Q2 = _natural24 + _nat24 - nat24, _social24Q2 = _social24 + _soc24 - soc24, _human24Q2 = _human24 + _hum24 - hum24, _metodical24Q2 = _metodical24 + _met24 - met24, _reference24Q2 = _reference24 + _ref24 - refs24, _art24Q2 = _art24 + _arts24 - art24, _print24Q2 = _print24 + _prt24 - prt24, _electr24Q2 = _electr24 + _el24 - el24, _period24Q2 = _period24 + _per24 - per24;
            double _cost24Q2 = 0;

            string _titl24Q2 = "Поступило за 2 кв. " + _year23 + " г.";
            var _item24Q2 = DataBase.Base.Receipts.Where(x => x.Date >= Apr && x.Date <= Jn);
            int _totCount24Q2 = 0, _nat24Q2 = 0, _soc24Q2 = 0, _hum24Q2 = 0, _met24Q2 = 0, _ref24Q2 = 0, _arts24Q2 = 0, _prt24Q2 = 0, _el24Q2 = 0, _per24Q2 = 0;
            double _totCost24Q2 = 0;
            foreach (var item in _item24Q2)
            {
                _totCount24Q2 += item.TotalInstances;
                _totCost24Q2 += item.Cost;

                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _nat24Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _soc24Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _hum24Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _met24Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _ref24Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _arts24Q2 += (int)itemContent.Counts; }
                }
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _prt24Q2 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _el24Q2 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _per24Q2 += (int)itemView.Counts; }
                }
            }
            string title24Q2 = "Выбыло за 2 кв. " + _year24 + " г.";
            var _it24Q2 = DataBase.Base.Disposals.Where(x => x.Date >= Apr && x.Date <= Jn);
            int totCount24Q2 = 0, nat24Q2 = 0, soc24Q2 = 0, hum24Q2 = 0, met24Q2 = 0, refs24Q2 = 0, art24Q2 = 0, prt24Q2 = 0, el24Q2 = 0, per24Q2 = 0;
            double cost24Q2 = 0;
            foreach (var item in _it24Q2)
            {
                totCount24Q2 += item.TotalNumber;
                cost24Q2 += item.Cost;
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { nat24Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { soc24Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { hum24Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { met24Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { refs24Q2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art24Q2 += (int)itemContent.Counts; }
                }
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { prt24Q2 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { el24Q2 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { per24Q2 += (int)itemView.Counts; }
                }
            }
            string _title24Q3 = "Состоит на 3 кв. 01.01." + _year24 + " г.";
            int _count24Q3 = _count24Q2 + _totCount24Q2 - totCount24Q2, _natural24Q3 = _natural24Q2 + _nat24Q2 - nat24Q2, _social24Q3 = _social24Q2 + _soc23Q2 - soc23Q2, _human24Q3 = _human24Q2 + _hum24Q2 - hum24Q2, _metodical24Q3 = _metodical24Q2 + _met24Q2 - met24Q2, _reference24Q3 = _reference24Q2 + _ref24Q2 - refs24Q2, _art24Q3 = _art24Q2 + _arts24Q2 - art24Q2, _print24Q3 = _print24Q2 + _prt24Q2 - prt24Q2, _electr24Q3 = _electr24Q2 + _el24Q2 - el24Q2, _period24Q3 = _period24Q2 + _per24Q2 - per24Q2;
            double _cost24Q3 = 0;
            string _titl24Q3 = "Поступило за 3 кв. " + _year24 + " г.";
            var _item24Q3 = DataBase.Base.Receipts.Where(x => x.Date >= Jl && x.Date <= Sept);
            int _totCount24Q3 = 0, _nat24Q3 = 0, _soc24Q3 = 0, _hum24Q3 = 0, _met24Q3 = 0, _ref24Q3 = 0, _arts24Q3 = 0, _prt24Q3 = 0, _el24Q3 = 0, _per24Q3 = 0;
            double _totCost24Q3 = 0;
            foreach (var item in _item24Q3)
            {
                _totCount24Q3 += item.TotalInstances;
                _totCost24Q3 += item.Cost;

                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _nat24Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _soc24Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _hum24Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _met24Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _ref24Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _arts24Q3 += (int)itemContent.Counts; }
                }
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _prt24Q3 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _el24Q3 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _per24Q3 += (int)itemView.Counts; }
                }
            }
            string title24Q3 = "Выбыло за 3 кв. " + _year24 + " г.";
            var _it24Q3 = DataBase.Base.Disposals.Where(x => x.Date >= Jl && x.Date <= Sept);
            int totCount24Q3 = 0, nat24Q3 = 0, soc24Q3 = 0, hum24Q3 = 0, met24Q3 = 0, refs24Q3 = 0, art24Q3 = 0, prt24Q3 = 0, el24Q3 = 0, per24Q3 = 0;
            double cost24Q3 = 0;
            foreach (var item in _it24Q3)
            {
                totCount24Q3 += item.TotalNumber;
                cost24Q3 += item.Cost;
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { nat24Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { soc24Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { hum24Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { met24Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { refs24Q3 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art24Q3 += (int)itemContent.Counts; }
                }
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { prt24Q3 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { el24Q3 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { per24Q3 += (int)itemView.Counts; }
                }
            }
            string _title24Q4 = "Состоит на 4 кв. 01.01." + _year24 + " г.";
            int _count24Q4 = _count24Q3 + _totCount24Q3 - totCount24Q3, _natural24Q4 = _natural24Q3 + _nat24Q3 - nat24Q3, _social24Q4 = _social24Q3 + _soc24Q3 - soc24Q3, _human24Q4 = _human24Q3 + _hum24Q3 - hum24Q3, _metodical24Q4 = _metodical24Q3 + _met24Q3 - met24Q3, _reference24Q4 = _reference24Q3 + _ref24Q3 - refs24Q3, _art24Q4 = _art24Q3 + _arts24Q3 - art24Q3, _print24Q4 = _print24Q3 + _prt24Q3 - prt24Q3, _electr24Q4 = _electr24Q3 + _el24Q3 - el24Q3, _period24Q4 = _period24Q3 + _per24Q3 - per24Q3;
            double _cost24Q4 = 0;
            string _titl24Q4 = "Поступило за 4 кв. " + _year23 + " г.";
            var _item24Q4 = DataBase.Base.Receipts.Where(x => x.Date >= Oct && x.Date <= Dec);
            int _totCount24Q4 = 0, _nat24Q4 = 0, _soc24Q4 = 0, _hum24Q4 = 0, _met24Q4 = 0, _ref24Q4 = 0, _arts24Q4 = 0, _prt24Q4 = 0, _el24Q4 = 0, _per24Q4 = 0;
            double _totCost24Q4 = 0;
            foreach (var item in _item24Q4)
            {
                _totCount24Q4 += item.TotalInstances;
                _totCost24Q4 += item.Cost;

                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _nat24Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _soc24Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _hum24Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _met24Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _ref24Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _arts24Q4 += (int)itemContent.Counts; }
                }
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _prt24Q4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _el24Q4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _per24Q4 += (int)itemView.Counts; }
                }
            }
            string title24Q4 = "Выбыло за 4 кв. " + _year24 + " г.";
            var _it24Q4 = DataBase.Base.Disposals.Where(x => x.Date >= Oct && x.Date <= Dec);
            int totCount24Q4 = 0, nat24Q4 = 0, soc24Q4 = 0, hum24Q4 = 0, met24Q4 = 0, refs24Q4 = 0, art24Q4 = 0, prt24Q4 = 0, el24Q4 = 0, per24Q4 = 0;
            double cost24Q4 = 0;
            foreach (var item in _it24Q4)
            {
                totCount24Q4 += item.TotalNumber;
                cost24Q4 += item.Cost;
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { nat24Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { soc24Q4 = (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { hum24Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { met24Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { refs24Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art24Q4 += (int)itemContent.Counts; }
                }
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { prt24Q4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { el24Q4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { per24Q4 += (int)itemView.Counts; }
                }
            }
            string title2024 = "Итого поступило за " + _year24 + " г.";
            DateTime startDate2024 = new DateTime(_year24, 1, 1);
            DateTime endDate2024 = new DateTime(_year24, 12, 31);
            var Items2024 = DataBase.Base.Receipts.Where(x => x.Date >= startDate2023 && x.Date <= endDate2023);
            int _totalCount2024 = 0, _natural2024 = 0, _social2024 = 0, _human2024 = 0, _metodical2024 = 0, _reference2024 = 0, _art2024 = 0, _print2024 = 0, _electr2024 = 0, _period2024 = 0;
            double _totalCost2024 = 0;
            foreach (var item in Items2024)
            {
                _totalCount2024 = _totCount24 + _totCount24Q2 + _totCount24Q3 + _totCount24Q4;
                _totalCost2024 = _totCost24 + _totCost24Q2 + _totCost24Q3 + _totCost24Q4;
                _natural2024 = _nat24 + _nat24Q2 + _nat24Q3 + _nat24Q4;
                _social2024 = _soc24 + _soc24Q2 + _soc24Q3 + _soc24Q4;
                _human2024 = _hum24 + _hum24Q2 + _hum24Q3 + _hum24Q4;
                _metodical2024 = _met24 + _met24Q2 + _met24Q3 + _met24Q4;
                _reference2024 = _ref24 + _ref24Q2 + _ref24Q3 + _ref24Q4;
                _art2024 = _arts24 + _arts24Q2 + _arts24Q3 + _arts24Q4;
                _print2024 = _prt24 + _prt24Q2 + _prt24Q3 + _prt24Q4;
                _electr2024 = _el24 + _el24Q2 + _el24Q3 + _el24Q4;
                _period2024 = _per24 + _per24Q2 + _per24Q3 + _per24Q4;
            }
            string titleDis2024 = "Выбыло за " + _year24 + " г.";
            int totCount2024 = 0, nat2024 = 0, soc2024 = 0, hum2024 = 0, met2024 = 0, refs2024 = 0, art2024 = 0, prt2024 = 0, el2024 = 0, per2024 = 0;
            double cost2024 = 0;
            var _it2024 = DataBase.Base.Disposals.Where(x => x.Date >= startDate2024 && x.Date <= endDate2024);
            foreach (var item in _it2024)
            {
                totCount2024 = totCount24 + totCount24Q2 + totCount24Q3 + totCount24Q4;
                cost2024 = cost24 + cost24Q2 + cost24Q3 + cost24Q4;
                nat2024 = nat24 + nat24Q2 + nat24Q3 + nat24Q4;
                soc2024 = soc24 + soc24Q2 + soc24Q3 + soc24Q4;
                hum2024 = hum24 + hum24Q2 + hum24Q3 + hum24Q4;
                met2024 = met24 + met24Q2 + met24Q3 + met24Q4;
                refs2024 = refs24 + refs24Q2 + refs24Q3 + refs24Q4;
                art2024 = art24 + art24Q2 + art24Q3 + art24Q4;
                prt2024 = prt24 + prt24Q2 + prt24Q3 + prt24Q4;
                el2024 = el24 + el24Q2 + el24Q3 + el24Q4;
                per2024 = per24 + per24Q2 + per24Q3 + per24Q4;
            }
            int _year25 = 2025;
            // Диапазон первого квартала
            DateTime Jan25 = new DateTime(_year24, 1, 1);
            DateTime Mar25 = new DateTime(_year24, 3, 31);
            // Диапазон второго квартала
            DateTime Apr25 = new DateTime(_year24, 4, 1);
            DateTime Jn25 = new DateTime(_year24, 6, 30);
            // Диапазон третьего квартала
            DateTime Jl25 = new DateTime(_year24, 7, 1);
            DateTime Sept25 = new DateTime(_year24, 9, 30);
            // Диапазон четвертого квартала
            DateTime Oct25 = new DateTime(_year24, 10, 1);
            DateTime Dec52 = new DateTime(_year24, 12, 31);
            string _title25 = "Состоит на 01.01." + _year25 + " г.";
            int _count25 = _count24Q4 + _totCount24Q4 - totCount24Q4, _natural25 = _natural24Q4 + _nat24Q4 - nat24Q4, _social25 = _social24Q4 + _soc24Q4 - soc24Q4, _human25 = _human24Q4 + _hum24Q4 - hum24Q4, _metodical25 = _metodical24Q4 + _met24Q4 - met24Q4, _reference25 = _reference24Q4 + _ref24Q4 - refs24Q4, _art25 = _art24Q4 + _arts24Q4 - art24Q4, _print25= _print24Q4 + _prt24Q4 - prt24Q4, _electr25 = _electr24Q4 + _el24Q4 - el24Q4, _period25 = _period24Q4 + _per24Q4 - per24Q4;
            double _cost25 = 0;




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
            //1 кв.
            DataList.Add(new TotalResults() { FundMomentTotal = title21, TotalCount = totCount21, TotalCost = cost21, NaturalSocialTotal = nat21, SocialTotal = soc21, HumanitarianTotal = hum21, MetodicalTotal = met21, ReferenceTotal = refs21, ArtTotal = art21, PrentedTotal = prt21, ElectronicTotal = el21, PeriodichTotal = per21, NotesTotal = "" });
            //2 кв.
            DataList.Add(new TotalResults() { FundMomentTotal = _title21Q2, TotalCount = _count21Q2, TotalCost = _cost21Q2, NaturalSocialTotal = _natural21Q2, SocialTotal = _social21Q2, HumanitarianTotal = _human21Q2, MetodicalTotal = _metodical21Q2, ReferenceTotal = _reference21Q2, ArtTotal = _art21Q2, PrentedTotal = _print21Q2, ElectronicTotal = _electr21Q2, PeriodichTotal = _period21Q2, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = _titl21, TotalCount = _totCount21, TotalCost = _totCost21, NaturalSocialTotal = _nat21, SocialTotal = _soc21, HumanitarianTotal = _hum21, MetodicalTotal = _met21, ReferenceTotal = _ref21, ArtTotal = _arts21, PrentedTotal = _prt21, ElectronicTotal = _el21, PeriodichTotal = _per21, NotesTotal = "" });
            //4 кв.
            DataList.Add(new TotalResults() { FundMomentTotal = _title21Q4, TotalCount = _count21Q4, TotalCost = _cost21Q4, NaturalSocialTotal = _natural21Q4, SocialTotal = _social21Q4, HumanitarianTotal = _human21Q4, MetodicalTotal = _metodical21Q4, ReferenceTotal = _reference21Q4, ArtTotal = _art21Q4, PrentedTotal = _print21Q4, ElectronicTotal = _electr21Q4, PeriodichTotal = _period21Q4, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = _titl21Q4, TotalCount = _totCount21Q4, TotalCost = _totCost21Q4, NaturalSocialTotal = _nat21Q4, SocialTotal = _soc21Q4, HumanitarianTotal = _hum21Q4, MetodicalTotal = _met21Q4, ReferenceTotal = _ref21Q4, ArtTotal = _arts21Q4, PrentedTotal = _prt21Q4, ElectronicTotal = _el21Q4, PeriodichTotal = _per21Q4, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = title21Q4, TotalCount = totCount21Q4, TotalCost = cost21Q4, NaturalSocialTotal = nat21Q4, SocialTotal = soc21Q4, HumanitarianTotal = hum21Q4, MetodicalTotal = met21Q4, ReferenceTotal = refs21Q4, ArtTotal = art21Q4, PrentedTotal = prt21Q4, ElectronicTotal = el21Q4, PeriodichTotal = per21Q4, NotesTotal = "" });
            //Итоги
            DataList.Add(new TotalResults() { FundMomentTotal = title2021, TotalCount = _totalCount2021, TotalCost = _totalCost2021, NaturalSocialTotal = _natural2021, SocialTotal = _social2021, HumanitarianTotal = _human2021, MetodicalTotal = _metodical2021, ReferenceTotal = _reference2021, ArtTotal = _art2021, PrentedTotal = _print2021, ElectronicTotal = _electr2021, PeriodichTotal = _period2021, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = titleDis2021, TotalCount = totCount2021, TotalCost = cost2021, NaturalSocialTotal = nat2021, SocialTotal = soc2021, HumanitarianTotal = hum2021, MetodicalTotal = met2021, ReferenceTotal = refs2021, ArtTotal = art2021, PrentedTotal = prt2021, ElectronicTotal = el2021, PeriodichTotal = per2021, NotesTotal = "" });
            //2022 
            DataList.Add(new TotalResults() { FundMomentTotal = _title22, TotalCount = _count22, TotalCost = _cost22, NaturalSocialTotal = _natural22, SocialTotal = _social22, HumanitarianTotal = _human22, MetodicalTotal = _metodical22, ReferenceTotal = _reference22, ArtTotal = _art22, PrentedTotal = _print22, ElectronicTotal = _electr22, PeriodichTotal = _period22, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = title22, TotalCount = totCount22, TotalCost = cost22, NaturalSocialTotal = nat22, SocialTotal = soc22, HumanitarianTotal = hum22, MetodicalTotal = met22, ReferenceTotal = refs22, ArtTotal = art22, PrentedTotal = prt22, ElectronicTotal = el22, PeriodichTotal = per22, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = _title22Q2, TotalCount = _count22Q2, TotalCost = _cost22Q2, NaturalSocialTotal = _natural22Q2, SocialTotal = _social22Q2, HumanitarianTotal = _human22Q2, MetodicalTotal = _metodical22Q2, ReferenceTotal = _reference22Q2, ArtTotal = _art22Q2, PrentedTotal = _print22Q2, ElectronicTotal = _electr22Q2, PeriodichTotal = _period22Q2, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = _titl22, TotalCount = _totCount22, TotalCost = _totCost22, NaturalSocialTotal = _nat22, SocialTotal = _soc22, HumanitarianTotal = _hum22, MetodicalTotal = _met22, ReferenceTotal = _ref22, ArtTotal = _arts22, PrentedTotal = _prt22, ElectronicTotal = _el22, PeriodichTotal = _per22, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = title22Q2, TotalCount = totCount22Q2, TotalCost = cost22Q2, NaturalSocialTotal = nat22Q2, SocialTotal = soc22Q2, HumanitarianTotal = hum22Q2, MetodicalTotal = met22Q2, ReferenceTotal = refs22Q2, ArtTotal = art22Q2, PrentedTotal = prt22Q2, ElectronicTotal = el22Q2, PeriodichTotal = per22Q2, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = _title22Q4, TotalCount = _count22Q4, TotalCost = _cost22Q4, NaturalSocialTotal = _natural22Q4, SocialTotal = _social22Q4, HumanitarianTotal = _human22Q4, MetodicalTotal = _metodical22Q4, ReferenceTotal = _reference22Q4, ArtTotal = _art22Q4, PrentedTotal = _print22Q4, ElectronicTotal = _electr22Q4, PeriodichTotal = _period22Q4, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = _titl22Q4, TotalCount = _totCount22Q4, TotalCost = _totCost22Q4, NaturalSocialTotal = _nat22Q4, SocialTotal = _soc22Q4, HumanitarianTotal = _hum22Q4, MetodicalTotal = _met22Q4, ReferenceTotal = _ref22Q4, ArtTotal = _arts22Q4, PrentedTotal = _prt22Q4, ElectronicTotal = _el22Q4, PeriodichTotal = _per22Q4, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = title2022, TotalCount = _totalCount2022, TotalCost = _totalCost2022, NaturalSocialTotal = _natural2022, SocialTotal = _social2022, HumanitarianTotal = _human2022, MetodicalTotal = _metodical2022, ReferenceTotal = _reference2022, ArtTotal = _art2022, PrentedTotal = _print2022, ElectronicTotal = _electr2022, PeriodichTotal = _period2022, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = titleDis2022, TotalCount = totCount2022, TotalCost = cost2022, NaturalSocialTotal = nat2022, SocialTotal = soc2022, HumanitarianTotal = hum2022, MetodicalTotal = met2022, ReferenceTotal = refs2022, ArtTotal = art2022, PrentedTotal = prt2022, ElectronicTotal = el2022, PeriodichTotal = per2022, NotesTotal = "" });
            //2023
            DataList.Add(new TotalResults() { FundMomentTotal = _title23, TotalCount = _count23, TotalCost = _cost23, NaturalSocialTotal = _natural23, SocialTotal = _social23, HumanitarianTotal = _human23, MetodicalTotal = _metodical23, ReferenceTotal = _reference23, ArtTotal = _art23, PrentedTotal = _print23, ElectronicTotal = _electr23, PeriodichTotal = _period23, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = _titl23, TotalCount = _totCount23, TotalCost = _totCost23, NaturalSocialTotal = _nat23, SocialTotal = _soc23, HumanitarianTotal = _hum23, MetodicalTotal = _met23, ReferenceTotal = _ref23, ArtTotal = _arts23, PrentedTotal = _prt23, ElectronicTotal = _el23, PeriodichTotal = _per23, NotesTotal = "" });
            DataList.Add(new TotalResults() { FundMomentTotal = _title23Q2, TotalCount = _count23Q2, TotalCost = _cost23Q2, NaturalSocialTotal = _natural23Q2, SocialTotal = _social23Q2, HumanitarianTotal = _human23Q2, MetodicalTotal = _metodical23Q2, ReferenceTotal = _reference23Q2, ArtTotal = _art23Q2, PrentedTotal = _print23Q2, ElectronicTotal = _electr23Q2, PeriodichTotal = _period23Q2, NotesTotal = "" });

            // Отображаем DataGrid только если убедились, что есть данные в других таблицах
            if (AreOtherTablesPopulated())
            {
                //2 кв.
                DataList.Add(new TotalResults() { FundMomentTotal = _titl23Q2, TotalCount = _totCount23Q2, TotalCost = _totCost23Q2, NaturalSocialTotal = _nat23Q2, SocialTotal = _soc23Q2, HumanitarianTotal = _hum23Q2, MetodicalTotal = _met23Q2, ReferenceTotal = _ref23Q2, ArtTotal = _arts23Q2, PrentedTotal = _prt23Q2, ElectronicTotal = _el23Q2, PeriodichTotal = _per23Q2, NotesTotal = "" });
                DataList.Add(new TotalResults() { FundMomentTotal = title23Q2, TotalCount = totCount23Q2, TotalCost = cost23Q2, NaturalSocialTotal = nat23Q2, SocialTotal = soc23Q2, HumanitarianTotal = hum23Q2, MetodicalTotal = met23Q2, ReferenceTotal = refs23Q2, ArtTotal = art23Q2, PrentedTotal = prt23Q2, ElectronicTotal = el23Q2, PeriodichTotal = per23Q2, NotesTotal = "" });
                //3 кв.
                DataList.Add(new TotalResults() { FundMomentTotal = _title23Q3, TotalCount = _count23Q3, TotalCost = _cost23Q3, NaturalSocialTotal = _natural23Q3, SocialTotal = _social23Q3, HumanitarianTotal = _human23Q3, MetodicalTotal = _metodical23Q3, ReferenceTotal = _reference23Q3, ArtTotal = _art23Q3, PrentedTotal = _print23Q3, ElectronicTotal = _electr23Q3, PeriodichTotal = _period23Q3, NotesTotal = "" });
                DataList.Add(new TotalResults() { FundMomentTotal = _titl23Q3, TotalCount = _totCount23Q3, TotalCost = _totCost23Q3, NaturalSocialTotal = _nat23Q3, SocialTotal = _soc23Q3, HumanitarianTotal = _hum23Q3, MetodicalTotal = _met23Q3, ReferenceTotal = _ref23Q3, ArtTotal = _arts23Q3, PrentedTotal = _prt23Q3, ElectronicTotal = _el23Q3, PeriodichTotal = _per23Q3, NotesTotal = "" });
                DataList.Add(new TotalResults() { FundMomentTotal = title23Q3, TotalCount = totCount23Q3, TotalCost = cost23Q3, NaturalSocialTotal = nat23Q3, SocialTotal = soc23Q3, HumanitarianTotal = hum23Q3, MetodicalTotal = met23Q3, ReferenceTotal = refs23Q3, ArtTotal = art23Q3, PrentedTotal = prt23Q3, ElectronicTotal = el23Q3, PeriodichTotal = per23Q3, NotesTotal = "" });
                //4 кв.
                DataList.Add(new TotalResults() { FundMomentTotal = _title23Q4, TotalCount = _count23Q4, TotalCost = _cost23Q4, NaturalSocialTotal = _natural23Q4, SocialTotal = _social23Q4, HumanitarianTotal = _human23Q4, MetodicalTotal = _metodical23Q4, ReferenceTotal = _reference23Q4, ArtTotal = _art23Q4, PrentedTotal = _print23Q4, ElectronicTotal = _electr23Q4, PeriodichTotal = _period23Q4, NotesTotal = "" });
                DataList.Add(new TotalResults() { FundMomentTotal = _titl23Q4, TotalCount = _totCount23Q4, TotalCost = _totCost23Q4, NaturalSocialTotal = _nat23Q4, SocialTotal = _soc23Q4, HumanitarianTotal = _hum23Q4, MetodicalTotal = _met23Q4, ReferenceTotal = _ref23Q4, ArtTotal = _arts23Q4, PrentedTotal = _prt23Q4, ElectronicTotal = _el23Q4, PeriodichTotal = _per23Q4, NotesTotal = "" });
                DataList.Add(new TotalResults() { FundMomentTotal = title23Q4, TotalCount = totCount23Q4, TotalCost = cost23Q4, NaturalSocialTotal = nat23Q4, SocialTotal = soc23Q4, HumanitarianTotal = hum23Q4, MetodicalTotal = met23Q4, ReferenceTotal = refs23Q4, ArtTotal = art23Q4, PrentedTotal = prt23Q4, ElectronicTotal = el23Q4, PeriodichTotal = per23Q4, NotesTotal = "" });
                //Итоги
                DataList.Add(new TotalResults() { FundMomentTotal = title2023, TotalCount = _totalCount2023, TotalCost = _totalCost2023, NaturalSocialTotal = _natural2023, SocialTotal = _social2023, HumanitarianTotal = _human2023, MetodicalTotal = _metodical2023, ReferenceTotal = _reference2023, ArtTotal = _art2023, PrentedTotal = _print2023, ElectronicTotal = _electr2023, PeriodichTotal = _period2023, NotesTotal = "" });
                DataList.Add(new TotalResults() { FundMomentTotal = titleDis2023, TotalCount = totCount2023, TotalCost = cost2023, NaturalSocialTotal = nat2023, SocialTotal = soc2023, HumanitarianTotal = hum2023, MetodicalTotal = met2023, ReferenceTotal = refs2023, ArtTotal = art2023, PrentedTotal = prt2023, ElectronicTotal = el2023, PeriodichTotal = per2023, NotesTotal = "" });
                //2024
                //DataList.Add(new TotalResults() { FundMomentTotal = _title24, TotalCount = _count24, TotalCost = _cost24, NaturalSocialTotal = _natural24, SocialTotal = _social24, HumanitarianTotal = _human24, MetodicalTotal = _metodical24, ReferenceTotal = _reference24, ArtTotal = _art24, PrentedTotal = _print24, ElectronicTotal = _electr24, PeriodichTotal = _period24, NotesTotal = "" });
                ////1 кв.
                //DataList.Add(new TotalResults() { FundMomentTotal = _titl24, TotalCount = _totCount24, TotalCost = _totCost24, NaturalSocialTotal = _nat24, SocialTotal = _soc24, HumanitarianTotal = _hum24, MetodicalTotal = _met24, ReferenceTotal = _ref24, ArtTotal = _art24, PrentedTotal = _prt24, ElectronicTotal = _el24, PeriodichTotal = _per24, NotesTotal = "" });
                //DataList.Add(new TotalResults() { FundMomentTotal = title24, TotalCount = totCount24, TotalCost = cost24, NaturalSocialTotal = nat24, SocialTotal = soc24, HumanitarianTotal = hum24, MetodicalTotal = met24, ReferenceTotal = refs24, ArtTotal = art24, PrentedTotal = prt24, ElectronicTotal = el24, PeriodichTotal = per24, NotesTotal = "" });
                ////2 кв.
                //DataList.Add(new TotalResults() { FundMomentTotal = _title24Q2, TotalCount = _count24Q2, TotalCost = _cost24Q2, NaturalSocialTotal = _natural24Q2, SocialTotal = _social24Q2, HumanitarianTotal = _human24Q2, MetodicalTotal = _metodical24Q2, ReferenceTotal = _reference24Q2, ArtTotal = _art24Q2, PrentedTotal = _print24Q2, ElectronicTotal = _electr24Q2, PeriodichTotal = _period24Q2, NotesTotal = "" });
                //DataList.Add(new TotalResults() { FundMomentTotal = _titl24Q2, TotalCount = _totCount24Q2, TotalCost = _totCost24Q2, NaturalSocialTotal = _nat24Q2, SocialTotal = _soc24Q2, HumanitarianTotal = _hum24Q2, MetodicalTotal = _met24Q2, ReferenceTotal = _ref24Q2, ArtTotal = _arts24Q2, PrentedTotal = _prt24Q2, ElectronicTotal = _el24Q2, PeriodichTotal = _per24Q2, NotesTotal = "" });
                //DataList.Add(new TotalResults() { FundMomentTotal = title24Q2, TotalCount = totCount24Q2, TotalCost = cost24Q2, NaturalSocialTotal = nat24Q2, SocialTotal = soc24Q2, HumanitarianTotal = hum24Q2, MetodicalTotal = met24Q2, ReferenceTotal = refs24Q2, ArtTotal = art24Q2, PrentedTotal = prt24Q2, ElectronicTotal = el24Q2, PeriodichTotal = per24Q2, NotesTotal = "" });
                ////3 кв.
                //DataList.Add(new TotalResults() { FundMomentTotal = _title24Q3, TotalCount = _count24Q3, TotalCost = _cost24Q3, NaturalSocialTotal = _natural24Q3, SocialTotal = _social24Q3, HumanitarianTotal = _human24Q3, MetodicalTotal = _metodical24Q3, ReferenceTotal = _reference24Q3, ArtTotal = _art24Q3, PrentedTotal = _print24Q3, ElectronicTotal = _electr24Q3, PeriodichTotal = _period24Q3, NotesTotal = "" });
                //DataList.Add(new TotalResults() { FundMomentTotal = _titl24Q3, TotalCount = _totCount24Q3, TotalCost = _totCost24Q3, NaturalSocialTotal = _nat24Q3, SocialTotal = _soc24Q3, HumanitarianTotal = _hum24Q3, MetodicalTotal = _met24Q3, ReferenceTotal = _ref24Q3, ArtTotal = _arts24Q3, PrentedTotal = _prt24Q3, ElectronicTotal = _el24Q3, PeriodichTotal = _per24Q3, NotesTotal = "" });
                //DataList.Add(new TotalResults() { FundMomentTotal = title24Q3, TotalCount = totCount24Q3, TotalCost = cost24Q3, NaturalSocialTotal = nat24Q3, SocialTotal = soc24Q3, HumanitarianTotal = hum24Q3, MetodicalTotal = met24Q3, ReferenceTotal = refs24Q3, ArtTotal = art24Q3, PrentedTotal = prt24Q3, ElectronicTotal = el24Q3, PeriodichTotal = per24Q3, NotesTotal = "" });
                ////4 кв.
                //DataList.Add(new TotalResults() { FundMomentTotal = _title24Q4, TotalCount = _count24Q4, TotalCost = _cost24Q4, NaturalSocialTotal = _natural24Q4, SocialTotal = _social24Q4, HumanitarianTotal = _human24Q4, MetodicalTotal = _metodical24Q4, ReferenceTotal = _reference24Q4, ArtTotal = _art24Q4, PrentedTotal = _print24Q4, ElectronicTotal = _electr24Q4, PeriodichTotal = _period24Q4, NotesTotal = "" });
                //DataList.Add(new TotalResults() { FundMomentTotal = _titl24Q4, TotalCount = _totCount24Q4, TotalCost = _totCost24Q4, NaturalSocialTotal = _nat24Q4, SocialTotal = _soc24Q4, HumanitarianTotal = _hum24Q4, MetodicalTotal = _met24Q4, ReferenceTotal = _ref24Q4, ArtTotal = _arts24Q4, PrentedTotal = _prt24Q4, ElectronicTotal = _el24Q4, PeriodichTotal = _per24Q4, NotesTotal = "" });
                //DataList.Add(new TotalResults() { FundMomentTotal = title24Q4, TotalCount = totCount24Q4, TotalCost = cost24Q4, NaturalSocialTotal = nat24Q4, SocialTotal = soc24Q4, HumanitarianTotal = hum24Q4, MetodicalTotal = met24Q4, ReferenceTotal = refs24Q4, ArtTotal = art24Q4, PrentedTotal = prt24Q4, ElectronicTotal = el24Q4, PeriodichTotal = per24Q4, NotesTotal = "" });
                ////Итоги
                //DataList.Add(new TotalResults() { FundMomentTotal = title2024, TotalCount = _totalCount2024, TotalCost = _totalCost2024, NaturalSocialTotal = _natural2024, SocialTotal = _social2024, HumanitarianTotal = _human2024, MetodicalTotal = _metodical2024, ReferenceTotal = _reference2024, ArtTotal = _art2024, PrentedTotal = _print2024, ElectronicTotal = _electr2024, PeriodichTotal = _period2024, NotesTotal = "" });
                //DataList.Add(new TotalResults() { FundMomentTotal = titleDis2024, TotalCount = totCount2024, TotalCost = cost2024, NaturalSocialTotal = nat2024, SocialTotal = soc2024, HumanitarianTotal = hum2024, MetodicalTotal = met2024, ReferenceTotal = refs2024, ArtTotal = art2024, PrentedTotal = prt2024, ElectronicTotal = el2024, PeriodichTotal = per2024, NotesTotal = "" });
                ////2025
                //DataList.Add(new TotalResults() { FundMomentTotal = _title25, TotalCount = _count25, TotalCost = _cost25, NaturalSocialTotal = _natural25, SocialTotal = _social25, HumanitarianTotal = _human25, MetodicalTotal = _metodical25, ReferenceTotal = _reference25, ArtTotal = _art25, PrentedTotal = _print25, ElectronicTotal = _electr25, PeriodichTotal = _period25, NotesTotal = "" });
                //1 кв.

                //2 кв.

                //3 кв.

                //4 кв.

                //Итоги

                //2026
                //DataList.Add(new TotalResults() { FundMomentTotal = _title26, TotalCount = _count26, TotalCost = _cost26, NaturalSocialTotal = _natural26, SocialTotal = _social26, HumanitarianTotal = _human26, MetodicalTotal = _metodical26, ReferenceTotal = _reference26, ArtTotal = _art26, PrentedTotal = _print26, ElectronicTotal = _electr26, PeriodichTotal = _period26, NotesTotal = "" });

            }
        }
        /// <summary>
        /// Проверяем наличие данных в других таблицах
        /// </summary>
        /// <returns></returns>
        private bool AreOtherTablesPopulated()
        {
            ClassTotalResultDisposals resultDisposals = new ClassTotalResultDisposals();
            ObservableCollection<TotalResultDisposals> disposals = new ObservableCollection<TotalResultDisposals>(resultDisposals.DataList);

            //ClassTotalResultReceipts resultReceipts = new ClassTotalResultReceipts();
            //ObservableCollection<TotalResultReceipts> receipts = new ObservableCollection<TotalResultReceipts>(resultReceipts.DataList);

            List<Receipts> receiptsList =  DataBase.Base.Receipts.ToList();
            ObservableCollection<Receipts> receipts = new ObservableCollection<Receipts>(receiptsList);

            if (disposals.Count > 0 && receipts.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
