using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using static KSU.ClassResultTwo;
using static KSU.ClassTotalResultDisposals;
using static KSU.ClassTotalResults;

namespace KSU
{
    public class ClassResultThree
    {
        /// <summary>
        /// Класс для хранения итогов
        /// </summary>
        public class ResultsThree
        {
            public string FundMomentThree { get; set; }
            public int TotalCountThree { get; set; }
            public double TotalCostThree { get; set; }
            public int NaturalSocialThree { get; set; }
            public int SocialThree { get; set; }
            public int HumanitarianThree { get; set; }
            public int MetodicalThree { get; set; }
            public int ReferenceThree { get; set; }
            public int ArtThree { get; set; }
            public int PrentedThree { get; set; }
            public int ElectronicThree { get; set; }
            public int PeriodichThree { get; set; }
            public string NotesThree { get; set; }

            public bool IsVisible { get; set; } = true;
        }

        public List<ResultsThree> DataList { get; }

        /// <summary>
        /// Для подсчетов итогов о 3 корпусу
        /// </summary>
        public ClassResultThree()
        {

            int _twocount = 42730, _twonatural = 3132, _twosocial = 1525, _twohuman = 29791, _twometodical = 0, _tworeference = 307, _twoart = 7975, _twoprint = 42730, _twoelectr = 0, _twoperiod = 0;
            double _twocost = 0;
            // идентификатор книг по содержанию, количество которой нужно подсчитать
            int contentId = 1, contentIdTwo = 2, contentIdThree = 3, contentIdFour = 4, contentIdFive = 5, contentIdSix = 6;
            // идентификатор книг по виду, количество которой нужно подсчитать 
            int viewId = 1, viewIdTwo = 2, viewIdThree = 3;
            int _year = 2018;
            DateTime _startDate = new DateTime(_year, 1, 1);
            DateTime _endDate = new DateTime(_year, 12, 31);
            //Поступление за 2018 год 
            var _item = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= _startDate && x.Date <= _endDate);
            int _totalCount18 = 0, _natural18 = 0, _social18 = 0, _human18 = 0, _metodical18 = 0, _reference18 = 0, _art18 = 0, _print18 = 0, _electr18 = 0, _period18 = 0;
            double _totalCost18 = 0;
            foreach (var item in _item) { _totalCount18 += item.TotalInstances; _totalCost18 += item.Cost; }
            foreach (var item in _item) //По содержанию
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _natural18 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _social18 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _human18 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _metodical18 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _reference18 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _art18 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in _item) //По виду
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _print18 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _electr18 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _period18 += (int)itemView.Counts; }
                }
            }
            //Состоит на начало 2019 года
            int _year19 = 2019;
            DateTime _startDate19 = new DateTime(_year19, 1, 1);
            DateTime _endDate19 = new DateTime(_year19, 12, 31);
            int _countBeginingYear19 = 0, _costYear19 = 0, _naturalYear19 = 0, _socialYear19 = 0, _humanYear19 = 0, _metodicalYear19 = 0, _referenceYear19 = 0, _artYear19 = 0, _printYear19 = 0, _electrYear19 = 0, _periodYear19 = 0;
            //Подсчеты сколько состоит на начало 2019 года
            _countBeginingYear19 = _twocount + _totalCount18;
            _naturalYear19 = _twonatural + _natural18;
            _socialYear19 = _twosocial + _social18;
            _referenceYear19 = _tworeference + _reference18;
            _humanYear19 = _twohuman + _human18;
            _metodicalYear19 = _twometodical + _metodical18;
            _artYear19 = _twoart + _art18;
            _printYear19 = _twoprint + _print18;
            _electrYear19 = _twoelectr + _electr18;
            _periodYear19 = _twoperiod + _period18;
            //Поступление за 2018 год 
            var _item19 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= _startDate19 && x.Date <= _endDate19);
            int _totalCount19 = 0, _natural19 = 0, _social19 = 0, _human19 = 0, _metodical19 = 0, _reference19 = 0, _art19 = 0, _print19 = 0, _electr19 = 0, _period19 = 0;
            double _totalCost19 = 0;
            foreach (var item in _item19) { _totalCount19 += item.TotalInstances; _totalCost19 += item.Cost; }
            foreach (var item in _item19) //По содержанию
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _natural19 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _social19 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _human19 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _metodical19 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _reference19 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _art19 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in _item19) //По виду
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _print19 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _electr19 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _period19 += (int)itemView.Counts; }
                }
            }
            //Выбытие 2019 год
            int totalCountDis = 0, naturalDis = 0, socialDis = 0, humanDis = 0, metodicalDis = 0, referenceDis = 0, artDis = 0, printDis = 0, electrDis = 0, periodDis = 0;
            double totalCostDis = 0; //Общая стоимость
            var itemss = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 3 && x.Date >= _startDate19 && x.Date <= _endDate19);
            foreach (var item in itemss)
            { totalCountDis += item.TotalNumber; totalCostDis += item.Cost; } //Вычисление кол-ва и стоимости
            foreach (var item in itemss)
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { naturalDis += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { socialDis += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { humanDis += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodicalDis += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { referenceDis += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { artDis += (int)itemContent.Counts; }
                }
            } //Вычисление по содержанию
            foreach (var item in itemss)
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId)
                    { printDis += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo)
                    { electrDis += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)
                    { periodDis += (int)itemView.Counts; }
                }
            } //Вычисление по виду
            //Состоит на 2020
            int _year20 = 2020;
            DateTime _startDate20 = new DateTime(_year20, 1, 1);
            DateTime _endDate20 = new DateTime(_year20, 12, 31);
            int _countBeginingYear20 = 0, _costYear20 = 0, _naturalYear20 = 0, _socialYear20 = 0, _humanYear20 = 0, _metodicalYear20 = 0, _referenceYear20 = 0, _artYear20 = 0, _printYear20 = 0, _electrYear20 = 0, _periodYear20 = 0;
            _countBeginingYear20 = _countBeginingYear19 + _totalCount19 - totalCountDis;
            _naturalYear20 = _naturalYear19 + _natural19 - naturalDis;
            _socialYear20 = _socialYear19 + _social19 - socialDis;
            _referenceYear20 = _printYear19 + _reference19 - referenceDis;
            _humanYear20 = _humanYear19 + _human19 - humanDis;
            _metodicalYear20 = _metodicalYear19 + _metodical19 - metodicalDis;
            _artYear20 = _artYear19 + _art19 - artDis;
            _printYear20 = _printYear19 + _print19 - printDis;
            _electrYear20 = _electrYear19 + _electr19 - electrDis;
            _periodYear20 = _periodYear19 + _period19 - periodDis;
            //Поступление 2020
            var _items = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= _startDate20 && x.Date <= _endDate20);
            int _totalCount20 = 0, _natural20 = 0, _social20 = 0, _human20 = 0, _metodical20 = 0, _reference20 = 0, _art20 = 0, _print20 = 0, _electr20 = 0, _period20 = 0;
            double _totalCost20 = 0;
            foreach (var item in _items) { _totalCount20 += item.TotalInstances; _totalCost20 += item.Cost; }
            foreach (var item in _items) //По содержанию
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _natural20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _social20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _human20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _metodical20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _reference20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _art20 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in _items) //По виду
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _print20 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _electr20 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _period20 += (int)itemView.Counts; }
                }
            }
            //Выбытие 2020
            int totalCountDis20 = 0, naturalDis20 = 0, socialDis20 = 0, humanDis20 = 0, metodicalDis20 = 0, referenceDis20 = 0, artDis20 = 0, printDis20 = 0, electrDis20 = 0, periodDis20 = 0;
            double totalCostDis20 = 0;
            var itemss20 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 3 && x.Date >= _startDate20 && x.Date <= _endDate20);
            foreach (var item in itemss20)
            {
                totalCountDis20 += item.TotalNumber;
                totalCostDis20 += item.Cost;
            }
            foreach (var item in itemss20)
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { naturalDis20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { socialDis20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { humanDis20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodicalDis20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { referenceDis20 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { artDis20 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in itemss20)
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатные
                    { printDis20 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронные
                    { electrDis20 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { periodDis20 += (int)itemView.Counts; }
                }
            }
            int _year21 = 2021;
            // Диапазон второго квартала
            DateTime April = new DateTime(_year21, 4, 1);
            DateTime June = new DateTime(_year21, 6, 30);
            // Диапазон четвертого квартала
            DateTime October = new DateTime(_year21, 10, 1);
            DateTime December = new DateTime(_year21, 12, 31);
            int _countBeginingYear21 = 0, _costYear21 = 0, _naturalYear21 = 0, _socialYear21 = 0, _humanYear21 = 0, _metodicalYear21 = 0, _referenceYear21 = 0, _artYear21 = 0, _printYear21 = 0, _electrYear21 = 0, _periodYear21 = 0;
            _countBeginingYear21 = _countBeginingYear20 + _totalCount20 - totalCountDis20;
            _naturalYear21 = _naturalYear20 + _natural20 - naturalDis20;
            _socialYear21 = _socialYear20 + _social20 - socialDis20;
            _referenceYear21 = _printYear20 + _reference20 - referenceDis20;
            _humanYear21 = _humanYear20 + _human20 - humanDis20;
            _metodicalYear21 = _metodicalYear20 + _metodical20 - metodicalDis20;
            _artYear21 = _artYear20 + _art20 - artDis20;
            _printYear21 = _printYear20 + _print20 - printDis20;
            _electrYear21 = _electrYear20 + _electr20 - electrDis20;
            _periodYear21 = _periodYear20 + _period20 - periodDis20;
            //Поступление 2 кв. 2021
            var _items21 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= April && x.Date <= June);
            int _totalCount21 = 0, _natural21 = 0, _social21 = 0, _human21 = 0, _metodical21 = 0, _reference21 = 0, _art21 = 0, _print21 = 0, _electr21 = 0, _period21 = 0;
            double _totalCost21 = 0;
            foreach (var item in _items21) { _totalCount21 += item.TotalInstances; _totalCost21 += item.Cost; }
            foreach (var item in _items21) //По содержанию
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _natural21 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _social21 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _human21 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _metodical21 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _reference21 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _art21 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in _items21) //По виду
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _print21 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _electr21 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _period21 += (int)itemView.Counts; }
                }
            }
            //Состоит на 4 кв. 2021
            int _countBeginingYear21Q4 = 0, _costYear21Q4 = 0, _naturalYear21Q4 = 0, _socialYear21Q4 = 0, _humanYear21Q4 = 0, _metodicalYear21Q4 = 0, _referenceYear21Q4 = 0, _artYear21Q4 = 0, _printYear21Q4 = 0, _electrYear21Q4 = 0, _periodYear21Q4 = 0;
            _countBeginingYear21Q4 = _countBeginingYear21 + _totalCount21;
            _naturalYear21Q4 = _naturalYear21 + _natural21;
            _socialYear21Q4 = _socialYear21 + _social21;
            _referenceYear21Q4 = _printYear21 + _reference21;
            _humanYear21Q4 = _humanYear21 + _human21;
            _metodicalYear21Q4 = _metodicalYear21 + _metodical21;
            _artYear21Q4 = _artYear21 + _art21;
            _printYear21Q4 = _printYear21 + _print21;
            _electrYear21Q4 = _electrYear21 + _electr21;
            _periodYear21Q4 = _periodYear21 + _period21;
            //Поступление 4 кв. 
            var _items24 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= October && x.Date <= December);
            int _totalCount24 = 0, _natural24 = 0, _social24 = 0, _human24 = 0, _metodical24 = 0, _reference24 = 0, _art24 = 0, _print24 = 0, _electr24 = 0, _period24 = 0;
            double _totalCost24 = 0;
            foreach (var item in _items24) { _totalCount24 += item.TotalInstances; _totalCost24 += item.Cost; }
            foreach (var item in _items24) //По содержанию
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _natural24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _social24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _human24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _metodical24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _reference24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _art24 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in _items24) //По виду
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _print24 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _electr24 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _period24 += (int)itemView.Counts; }
                }
            }
            //Выбытие 4 кв.
            int totalCountDis24 = 0, naturalDis24 = 0, socialDis24 = 0, humanDis24 = 0, metodicalDis24 = 0, referenceDis24 = 0, artDis24 = 0, printDis24 = 0, electrDis24 = 0, periodDis24 = 0;
            double totalCostDis24 = 0;
            var itemss24 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 3 && x.Date >= October && x.Date <= December);
            foreach (var item in itemss24)
            {
                totalCountDis24 += item.TotalNumber;
                totalCostDis24 += item.Cost;
            }
            foreach (var item in itemss24)
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { naturalDis24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { socialDis24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { humanDis24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodicalDis24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { referenceDis24 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { artDis24 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in itemss24)
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатные
                    { printDis24 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронные
                    { electrDis24 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { periodDis24 += (int)itemView.Counts; }
                }
            }
            DateTime startDate2021 = new DateTime(_year21, 1, 1);
            DateTime endDate2021 = new DateTime(_year21, 12, 31);
            var Items2021 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= startDate2021 && x.Date <= endDate2021);
            int _totalCount2021 = 0, _natural2021 = 0, _social2021 = 0, _human2021 = 0, _metodical2021 = 0, _reference2021 = 0, _art2021 = 0, _print2021 = 0, _electr2021 = 0, _period2021 = 0;
            double _totalCost2021 = 0;
            foreach (var item in Items2021)
            {
                _totalCount2021 = _totalCount21 + _totalCount24;
                _totalCost2021 = _totalCost21 + _totalCost24;
                _natural2021 = _natural21 + _natural24;
                _social2021 = _social21 + _social24;
                _human2021 = _human21 + _human24;
                _metodical2021 = _metodical21 + _metodical24;
                _reference2021 = _reference21 + _reference24;
                _art2021 = _art21 + _art24;
                _print2021 = _print21 + _print24;
                _electr2021 = _electr21 + _electr24;
                _period2021 = _period21 + _period24;
            }
            //Выбыло
            int totalCountDis2021 = 0, naturalDis2021 = 0, socialDis2021 = 0, humanDis2021 = 0, metodicalDis2021 = 0, referenceDis2021 = 0, artDis2021 = 0, printDis2021 = 0, electrDis2021 = 0, periodDis2021 = 0;
            double totalCostDis2021 = 0; //Общая стоимость
            var itemss2021 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 3 && x.Date >= startDate2021 && x.Date <= endDate2021);
            foreach (var item in itemss2021)
            {
                totalCountDis2021 = totalCountDis24;
                totalCostDis2021 = totalCostDis24;
                naturalDis2021 = naturalDis24;
                socialDis2021 = socialDis24;
                humanDis2021 = humanDis24;
                metodicalDis2021 = metodicalDis24;
                referenceDis2021 = referenceDis24;
                artDis2021 = artDis24;
                printDis2021 = printDis24;
                electrDis2021 = electrDis24;
                periodDis2021 = periodDis24;
            }
            //Состоит на 2022
            int _year22 = 2022;
            // Диапазон второго квартала
            DateTime Aprils = new DateTime(_year22, 4, 1);
            DateTime Junes = new DateTime(_year22, 6, 30);
            // Диапазон четвертого квартала
            DateTime Oct = new DateTime(_year22, 10, 1);
            DateTime Dec = new DateTime(_year22, 12, 31);
            int _countBeginingYear22 = 0, _costYear22 = 0, _naturalYear22 = 0, _socialYear22 = 0, _humanYear22 = 0, _metodicalYear22 = 0, _referenceYear22 = 0, _artYear22 = 0, _printYear22 = 0, _electrYear22 = 0, _periodYear22 = 0;
            //Подсчеты сколько состоит на начало 2022 года
            _countBeginingYear22 = _countBeginingYear21Q4 + _totalCount24 - totalCountDis24;
            _naturalYear22 = _naturalYear21Q4 + _natural24 - naturalDis24;
            _socialYear22 = _socialYear21Q4 + _social24 - socialDis24;
            _referenceYear22 = _referenceYear21Q4 + _reference24 - referenceDis24;
            _humanYear22 = _humanYear21Q4 + _human24 - humanDis24;
            _metodicalYear22 = _metodicalYear21Q4 + _metodical24 - metodicalDis24;
            _artYear22 = _artYear21Q4 + _art24 - artDis24;
            _printYear22 = _printYear21Q4 + _print24 - printDis24;
            _electrYear22 = _electrYear21Q4 + _electr24 - electrDis24;
            _periodYear22 = _periodYear21Q4 + _period24 - periodDis24;
            //Поступило 2 кв. 2022
            var _items22 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= Aprils && x.Date <= Junes);
            int _totalCount22 = 0, _natural22 = 0, _social22 = 0, _human22 = 0, _metodical22 = 0, _reference22 = 0, _art22 = 0, _print22 = 0, _electr22 = 0, _period22 = 0;
            double _totalCost22 = 0;
            foreach (var item in _items22) { _totalCount22 += item.TotalInstances; _totalCost22 += item.Cost; }
            foreach (var item in _items22) //По содержанию
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _natural22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _social22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _human22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _metodical22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _reference22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _art22 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in _items22) //По виду
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { _print22 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { _electr22 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { _period22 += (int)itemView.Counts; }
                }
            }
            //Выбыло 2 кв
            int totalCountDis22 = 0, naturalDis22 = 0, socialDis22 = 0, humanDis22 = 0, metodicalDis22 = 0, referenceDis22 = 0, artDis22 = 0, printDis22 = 0, electrDis22 = 0, periodDis22 = 0;
            double totalCostDis22 = 0;
            var itemss22 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 3 && x.Date >= Aprils && x.Date <= Junes);
            foreach (var item in itemss22)
            {
                totalCountDis22 += item.TotalNumber;
                totalCostDis22 += item.Cost;
            }
            foreach (var item in itemss22)
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { naturalDis22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { socialDis22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { humanDis22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodicalDis22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { referenceDis22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { artDis22 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in itemss22)
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатные
                    { printDis22 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронные
                    { electrDis22 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { periodDis22 += (int)itemView.Counts; }
                }
            }
            //Состоит на 4 кв.
            string _title22Q4 = "Состоит на 4 кв. " + _year22 + " г.";
            int _count22Q4 = _countBeginingYear22 + _totalCount22 - totalCountDis22, _natural22Q4 = _naturalYear22 + _natural22 - naturalDis22, _social22Q4 = _socialYear22 + _social22 - socialDis22, _human22Q4 = _humanYear22 + _human22 - humanDis22, _metodical22Q4 = _metodicalYear22 + _metodical22 - metodicalDis22, _reference22Q4 = _referenceYear22 + _reference22 - referenceDis22, _art22Q4 = _artYear22 + _art22 - artDis22, _print22Q4 = _printYear22 + _print22 - printDis22, _electr22Q4 = _electrYear22 + _electr22 - electrDis22, _period22Q4 = _periodYear22 + _period22 - periodDis22;
            double _cost22Q4 = 0;
            string title224 = "Поступило за 4 кв." + _year22 + "г.";
            int _totalCount22Q4 = 0, _nat22Q4 = 0, _socl22Q4 = 0, _hum22Q4 = 0, _met22Q4 = 0, _ref22Q4 = 0, _ar22Q4 = 0, _prt22Q4 = 0, _el22Q4 = 0, _per22Q4 = 0;
            double _totalCost22Q4 = 0;
            var itemss22Q4 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= Oct && x.Date <= Dec);
            foreach (var item in itemss22Q4)
            {
                _totalCount22Q4 += item.TotalInstances; _totalCost22Q4 += item.Cost;
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { _nat22Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { _socl22Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { _hum22Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { _met22Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { _ref22Q4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { _ar22Q4 += (int)itemContent.Counts; }
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
            var Items2022 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= startDate2022 && x.Date <= endDate2022);
            int _totalCount2022 = 0, _natural2022 = 0, _social2022 = 0, _human2022 = 0, _metodical2022 = 0, _reference2022 = 0, _art2022 = 0, _print2022 = 0, _electr2022 = 0, _period2022 = 0;
            double _totalCost2022 = 0;
            foreach (var item in Items2022)
            {
                _totalCount2022 = _totalCount22 + _totalCount22Q4;
                _totalCost2022 = _totalCost22 + _totalCost22Q4;
                _natural2022 = _natural22 + _nat22Q4;
                _social2022 = _social22 + _socl22Q4;
                _human2022 = _human22 + _hum22Q4;
                _metodical2022 = _metodical22 + _met22Q4;
                _reference2022 = _reference22 + _ref22Q4;
                _art2022 = _art22 + _ar22Q4;
                _print2022 = _print22 + _prt22Q4;
                _electr2022 = _electr22 + _el22Q4;
                _period2022 = _period22 + _per22Q4;
            }
            string titleDis2022 = "Выбыло за " + _year22 + " г.";
            int totCount2022 = 0, nat2022 = 0, soc2022 = 0, hum2022 = 0, met2022 = 0, refs2022 = 0, art2022 = 0, prt2022 = 0, el2022 = 0, per2022 = 0;
            double cost2022 = 0;
            var _it2022 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 3 && x.Date >= startDate2022 && x.Date <= endDate2022);
            foreach (var item in _it2022)
            {
                totCount2022 = totalCountDis22;
                cost2022 = totalCostDis22;
                nat2022 = naturalDis22;
                soc2022 = socialDis22;
                hum2022 = humanDis22;
                met2022 = metodicalDis22;
                refs2022 = referenceDis22;
                art2022 = artDis22;
                prt2022 = printDis22;
                el2022 = electrDis22;
                per2022 = periodDis22;
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
            int _count23 = _count22Q4 + _totalCount22Q4, _natural23 = _natural22Q4 + _nat22Q4, _social23 = _social22Q4 + _socl22Q4, _human23 = _human22Q4 + _hum22Q4, _metodical23 = _metodical22Q4 + _met22Q4, _reference23 = _reference22Q4 + _ref22Q4, _art23 = _art22Q4 + _ar22Q4, _print23 = _print22Q4 + _prt22Q4, _electr23 = _electr22Q4 + _el22Q4, _period23 = _period22Q4 + _per22Q4;
            double _cost23 = 0;



            string _titl23 = "Поступило за 1 кв. " + _year23 + " г.";
            var _item23 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= Januar && x.Date <= Marc);
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
            var _item23Q2 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= Aprl && x.Date <= Jun);
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
            var _it23Q2 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 3 && x.Date >= Aprl && x.Date <= Jun);
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
            var _item23Q3 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= Jul && x.Date <= Septem);
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
            var _it23Q3 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 3 && x.Date >= Jul && x.Date <= Septem);
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
            var _item23Q4 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= Octob && x.Date <= Decem);
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
            var _it23Q4 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 3 && x.Date >= Octob && x.Date <= Decem);
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
            var Items2023 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= startDate2023 && x.Date <= endDate2023);
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
            var _it2023 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 3 && x.Date >= startDate2023 && x.Date <= endDate2023);
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
           
            
            //Надо скрыть
            int _year24 = 2024;
            // Диапазон первого квартала
            DateTime Jan24 = new DateTime(_year24, 1, 1);
            DateTime Mar24 = new DateTime(_year24, 3, 31);
            // Диапазон второго квартала
            DateTime Apr = new DateTime(_year24, 4, 1);
            DateTime Jn = new DateTime(_year24, 6, 30);
            // Диапазон третьего квартала
            DateTime Jl = new DateTime(_year24, 7, 1);
            DateTime Sept = new DateTime(_year24, 9, 30);
            // Диапазон четвертого квартала
            DateTime Oct24 = new DateTime(_year24, 10, 1);
            DateTime Dec24 = new DateTime(_year24, 12, 31);
            string _title24 = "Состоит на 01.01." + _year24 + " г.";
            int _count24 = _count23Q4 + _totCount23Q4 - totCount23Q4, _natl24 = _natural23Q4 + _nat23Q4 - nat23Q4, _socl24 = _social23Q4 + _soc23Q4 - soc23Q4, _humn24 = _human23Q4 + _hum23Q4 - hum23Q4, _metodic24 = _metodical23Q4 + _met23Q4 - met23Q4, _referen24 = _reference23Q4 + _ref23Q4 - refs23Q4, _ars24 = _art23Q4 + _arts23Q4 - art23Q4, _prnt24 = _print23Q4 + _prt23Q4 - prt23Q4, _elctr24 = _electr23Q4 + _el23Q4 - el23Q4, _perd24 = _period23Q4 + _per23Q4 - per23Q4;
            double _cost24 = 0;
            string _titl24 = "Поступило за 1 кв. " + _year24 + " г.";
            var _item24 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= Jan24 && x.Date <= Mar24);
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
            var _it24 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 3 && x.Date >= Jan24 && x.Date <= Mar24);
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
            string _title24Q2 = "Состоит на 2 кв. " + _year24 + " г.";
            int _count24Q2 = _count24 + _totCount24 - totCount24, _natural24Q2 = _natl24 + _nat24 - nat24, _social24Q2 = _socl24 + _soc24 - soc24, _human24Q2 = _humn24 + _hum24 - hum24, _metodic24Q2 = _metodic24 + _met24 - met24, _reference24Q2 = _referen24 + _ref24 - refs24, _art24Q2 = _art24 + _ars24 - art24, _print24Q2 = _prnt24 + _prt24 - prt24, _elctr24Q2 = _elctr24 + _el24 - el24, _period24Q2 = _perd24 + _per24 - per24;
            double _cost24Q2 = 0;
            string _titl24Q2 = "Поступило за 2 кв. " + _year24 + " г.";
            var _item24Q2 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= Apr && x.Date <= Jn);
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
            var _it24Q2 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 3 && x.Date >= Apr && x.Date <= Jn);
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
            string _title24Q3 = "Состоит на 3 кв. " + _year24 + " г.";
            int _count24Q3 = _count24Q2 + _totCount24Q2 - totCount24Q2, _natural24Q3 = _natural24Q2 + _nat24Q2 - nat24Q2, _social24Q3 = _social24Q2 + _soc23Q2 - soc23Q2, _human24Q3 = _human24Q2 + _hum24Q2 - hum24Q2, _metodical24Q3 = _metodic24Q2 + _met24Q2 - met24Q2, _reference24Q3 = _reference24Q2 + _ref24Q2 - refs24Q2, _art24Q3 = _art24Q2 + _arts24Q2 - art24Q2, _print24Q3 = _print24Q2 + _prt24Q2 - prt24Q2, _electr24Q3 = _elctr24Q2 + _el24Q2 - el24Q2, _period24Q3 = _period24Q2 + _per24Q2 - per24Q2;
            double _cost24Q3 = 0;
            string _titl24Q3 = "Поступило за 3 кв. " + _year24 + " г.";
            var _item24Q3 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= Jl && x.Date <= Sept);
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
            var _it24Q3 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 3 && x.Date >= Jl && x.Date <= Sept);
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
            string _title24Q4 = "Состоит на 4 кв." + _year24 + " г.";
            int _count24Q4 = _count24Q3 + _totCount24Q3 - totCount24Q3, _natural24Q4 = _natural24Q3 + _nat24Q3 - nat24Q3, _social24Q4 = _social24Q3 + _soc24Q3 - soc24Q3, _human24Q4 = _human24Q3 + _hum24Q3 - hum24Q3, _metodical24Q4 = _metodical24Q3 + _met24Q3 - met24Q3, _reference24Q4 = _reference24Q3 + _ref24Q3 - refs24Q3, _art24Q4 = _art24Q3 + _arts24Q3 - art24Q3, _print24Q4 = _print24Q3 + _prt24Q3 - prt24Q3, _electr24Q4 = _electr24Q3 + _el24Q3 - el24Q3, _period24Q4 = _period24Q3 + _per24Q3 - per24Q3;
            double _cost24Q4 = 0;
            string _titl24Q4 = "Поступило за 4 кв. " + _year23 + " г.";
            var _item24Q4 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= Oct24 && x.Date <= Dec24);
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
            var _it24Q4 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 3 && x.Date >= Oct && x.Date <= Dec);
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
            var Items2024 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= startDate2023 && x.Date <= endDate2023);
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
            var _it2024 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 3 && x.Date >= startDate2024 && x.Date <= endDate2024);
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
            int _count25 = _count24Q4 + _totCount24Q4 - totCount24Q4, _natural25 = _natural24Q4 + _nat24Q4 - nat24Q4, _social25 = _social24Q4 + _soc24Q4 - soc24Q4, _human25 = _human24Q4 + _hum24Q4 - hum24Q4, _metodical25 = _metodical24Q4 + _met24Q4 - met24Q4, _reference25 = _reference24Q4 + _ref24Q4 - refs24Q4, _art25 = _art24Q4 + _arts24Q4 - art24Q4, _print25 = _print24Q4 + _prt24Q4 - prt24Q4, _electr25 = _electr24Q4 + _el24Q4 - el24Q4, _period25 = _period24Q4 + _per24Q4 - per24Q4;
            double _cost25 = 0;


            DataList = new List<ResultsThree>();
            DataList.Add(new ResultsThree() { FundMomentThree = "Состоит на 01.01.2018 г.", TotalCountThree = 42730, TotalCostThree = 0, NaturalSocialThree = 3132, SocialThree = 1525, HumanitarianThree = 29791, MetodicalThree = 0, ReferenceThree = 307, ArtThree = 7975, PrentedThree = 42730, ElectronicThree = 0, PeriodichThree = 0, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Поступило за 2018 г.", TotalCountThree = _totalCount18, TotalCostThree = _totalCost18, NaturalSocialThree = _natural18, SocialThree = _social18, HumanitarianThree = _human18, MetodicalThree = _metodical18, ReferenceThree = _reference18, ArtThree = _art18, PrentedThree = _print18, ElectronicThree = _electr18, PeriodichThree = _period18, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Состоит на 01.01.2019 г.", TotalCountThree = _countBeginingYear19, TotalCostThree = _costYear19, NaturalSocialThree = _naturalYear19, SocialThree = _socialYear19, HumanitarianThree = _humanYear19, MetodicalThree = _metodicalYear19, ReferenceThree = _referenceYear19, ArtThree = _artYear19, PrentedThree = _printYear19, ElectronicThree = _electrYear19, PeriodichThree = _periodYear19, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Поступило за 2019 г.", TotalCountThree = _totalCount19, TotalCostThree = _totalCost19, NaturalSocialThree = _natural19, SocialThree = _social19, HumanitarianThree = _human19, MetodicalThree = _metodical19, ReferenceThree = _reference19, ArtThree = _art19, PrentedThree = _print19, ElectronicThree = _electr19, PeriodichThree = _period19, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Выбыло за 2019 г.", TotalCountThree = totalCountDis, TotalCostThree = totalCostDis, NaturalSocialThree = naturalDis, SocialThree = socialDis, HumanitarianThree = humanDis, MetodicalThree = metodicalDis, ReferenceThree = referenceDis, ArtThree = artDis, PrentedThree = printDis, ElectronicThree = electrDis, PeriodichThree = periodDis, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Состоит на 01.01.2020 г.", TotalCountThree = _countBeginingYear20, TotalCostThree = _costYear20, NaturalSocialThree = _naturalYear20, SocialThree = _socialYear20, HumanitarianThree = _humanYear20, MetodicalThree = _metodicalYear20, ReferenceThree = _referenceYear20, ArtThree = _artYear20, PrentedThree = _printYear20, ElectronicThree = _electrYear20, PeriodichThree = _periodYear20, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Поступило за 2020 г.", TotalCountThree = _totalCount20, TotalCostThree = _totalCost20, NaturalSocialThree = _natural20, SocialThree = _social20, HumanitarianThree = _human20, MetodicalThree = _metodical20, ReferenceThree = _reference20, ArtThree = _art20, PrentedThree = _print20, ElectronicThree = _electr20, PeriodichThree = _period20, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Выбыло за 2020 г.", TotalCountThree = totalCountDis20, TotalCostThree = totalCostDis20, NaturalSocialThree = naturalDis20, SocialThree = socialDis20, HumanitarianThree = humanDis20, MetodicalThree = metodicalDis20, ReferenceThree = referenceDis20, ArtThree = artDis20, PrentedThree = printDis20, ElectronicThree = electrDis20, PeriodichThree = periodDis20, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Состоит на 2 кв. 2021 г.", TotalCountThree = _countBeginingYear21, TotalCostThree = _costYear21, NaturalSocialThree = _naturalYear21, SocialThree = _socialYear21, HumanitarianThree = _humanYear21, MetodicalThree = _metodicalYear21, ReferenceThree = _referenceYear21, ArtThree = _artYear21, PrentedThree = _printYear21, ElectronicThree = _electrYear21, PeriodichThree = _periodYear21, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Поступило за 2 кв. 2021 г.", TotalCountThree = _totalCount21, TotalCostThree = _totalCost21, NaturalSocialThree = _natural21, SocialThree = _social21, HumanitarianThree = _human21, MetodicalThree = _metodical21, ReferenceThree = _reference21, ArtThree = _art21, PrentedThree = _print21, ElectronicThree = _electr21, PeriodichThree = _period21, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Состоит на 4 кв. 2021 г.", TotalCountThree = _countBeginingYear21Q4, TotalCostThree = _costYear21Q4, NaturalSocialThree = _naturalYear21Q4, SocialThree = _socialYear21Q4, HumanitarianThree = _humanYear21Q4, MetodicalThree = _metodicalYear21Q4, ReferenceThree = _referenceYear21Q4, ArtThree = _artYear21Q4, PrentedThree = _printYear21Q4, ElectronicThree = _electrYear21Q4, PeriodichThree = _periodYear21Q4, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Поступило за 4 кв. 2021 г.", TotalCountThree = _totalCount24, TotalCostThree = _totalCost24, NaturalSocialThree = _natural24, SocialThree = _social24, HumanitarianThree = _human24, MetodicalThree = _metodical24, ReferenceThree = _reference24, ArtThree = _art24, PrentedThree = _print24, ElectronicThree = _electr24, PeriodichThree = _period24, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Выбыло за 4 кв. 2021 г.", TotalCountThree = totalCountDis24, TotalCostThree = totalCostDis24, NaturalSocialThree = naturalDis24, SocialThree = socialDis24, HumanitarianThree = humanDis24, MetodicalThree = metodicalDis24, ReferenceThree = referenceDis24, ArtThree = artDis24, PrentedThree = printDis24, ElectronicThree = electrDis24, PeriodichThree = periodDis24, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Итого поступило", TotalCountThree = _totalCount2021, TotalCostThree = _totalCost2021, NaturalSocialThree = _natural24, SocialThree = _social2021, HumanitarianThree = _human2021, MetodicalThree = _metodical2021, ReferenceThree = _reference2021, ArtThree = _art2021, PrentedThree = _print2021, ElectronicThree = _electr2021, PeriodichThree = _period2021, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Выбыло", TotalCountThree = totalCountDis2021, TotalCostThree = totalCostDis2021, NaturalSocialThree = naturalDis2021, SocialThree = socialDis24, HumanitarianThree = humanDis2021, MetodicalThree = metodicalDis2021, ReferenceThree = referenceDis2021, ArtThree = artDis2021, PrentedThree = printDis2021, ElectronicThree = electrDis2021, PeriodichThree = periodDis2021, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Состоит на 01.01.2022 г.", TotalCountThree = _countBeginingYear22, TotalCostThree = _costYear22, NaturalSocialThree = _naturalYear22, SocialThree = _socialYear22, HumanitarianThree = _humanYear22, MetodicalThree = _metodicalYear22, ReferenceThree = _referenceYear22, ArtThree = _artYear22, PrentedThree = _printYear22, ElectronicThree = _electrYear22, PeriodichThree = _periodYear22, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Поступило за 2 кв. 2022 г.", TotalCountThree = _totalCount22, TotalCostThree = _totalCost22, NaturalSocialThree = _natural22, SocialThree = _social22, HumanitarianThree = _human22, MetodicalThree = _metodical22, ReferenceThree = _reference22, ArtThree = _art22, PrentedThree = _print22, ElectronicThree = _electr22, PeriodichThree = _period22, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Выбыло за 2 кв. 2022 г.", TotalCountThree = totalCountDis22, TotalCostThree = totalCostDis22, NaturalSocialThree = naturalDis22, SocialThree = socialDis22, HumanitarianThree = humanDis22, MetodicalThree = metodicalDis22, ReferenceThree = referenceDis22, ArtThree = artDis22, PrentedThree = printDis22, ElectronicThree = electrDis22, PeriodichThree = periodDis22, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = _title22Q4, TotalCountThree = _count22Q4, TotalCostThree = _cost22Q4, NaturalSocialThree = _natural22Q4, SocialThree = _social22Q4, HumanitarianThree = _human22Q4, MetodicalThree = _metodical22Q4, ReferenceThree = _reference22Q4, ArtThree = _art22Q4, PrentedThree = _print22Q4, ElectronicThree = _electr22Q4, PeriodichThree = _period22Q4, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = title224, TotalCountThree = _totalCount22Q4, TotalCostThree = _totalCost22Q4, NaturalSocialThree = _nat22Q4, SocialThree = _socl22Q4, HumanitarianThree = _hum22Q4, MetodicalThree = _met22Q4, ReferenceThree = _ref22Q4, ArtThree = _ar22Q4, PrentedThree = _prt22Q4, ElectronicThree = _el22Q4, PeriodichThree = _per22Q4, NotesThree = "" });


            DataList.Add(new ResultsThree() { FundMomentThree = title2022, TotalCountThree = _totalCount2022, TotalCostThree = _totalCost2022, NaturalSocialThree = _natural2022, SocialThree = _social2022, HumanitarianThree = _human2022, MetodicalThree = _metodical2022, ReferenceThree = _reference2022, ArtThree = _art2022, PrentedThree = _print2022, ElectronicThree = _electr2022, PeriodichThree = _period2022, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = titleDis2022, TotalCountThree = totCount2022, TotalCostThree = cost2022, NaturalSocialThree = nat2022, SocialThree = soc2022, HumanitarianThree = hum2022, MetodicalThree = met2022, ReferenceThree = refs2022, ArtThree = art2022, PrentedThree = prt2022, ElectronicThree = el2022, PeriodichThree = per2022, NotesThree = "" });
            //2023
            DataList.Add(new ResultsThree() { FundMomentThree = _title23, TotalCountThree = _count23, TotalCostThree = _cost23, NaturalSocialThree = _natural23, SocialThree = _social23, HumanitarianThree = _human23, MetodicalThree = _metodical23, ReferenceThree = _reference23, ArtThree = _art23, PrentedThree = _print23, ElectronicThree = _electr23, PeriodichThree = _period23, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = _titl23, TotalCountThree = _totCount23, TotalCostThree = _totCost23, NaturalSocialThree = _nat23, SocialThree = _soc23, HumanitarianThree = _hum23, MetodicalThree = _met23, ReferenceThree = _ref23, ArtThree = _arts23, PrentedThree = _prt23, ElectronicThree = _el23, PeriodichThree = _per23, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = _title23Q2, TotalCountThree = _count23Q2, TotalCostThree = _cost23Q2, NaturalSocialThree = _natural23Q2, SocialThree = _social23Q2, HumanitarianThree = _human23Q2, MetodicalThree = _metodical23Q2, ReferenceThree = _reference23Q2, ArtThree = _art23Q2, PrentedThree = _print23Q2, ElectronicThree = _electr23Q2, PeriodichThree = _period23Q2, NotesThree = "" });

            //2 кв.
            DataList.Add(new ResultsThree() { FundMomentThree = _titl23Q2, TotalCountThree = _totCount23Q2, TotalCostThree = _totCost23Q2, NaturalSocialThree = _nat23Q2, SocialThree = _soc23Q2, HumanitarianThree = _hum23Q2, MetodicalThree = _met23Q2, ReferenceThree = _ref23Q2, ArtThree = _arts23Q2, PrentedThree = _prt23Q2, ElectronicThree = _el23Q2, PeriodichThree = _per23Q2, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = title23Q2, TotalCountThree = totCount23Q2, TotalCostThree = cost23Q2, NaturalSocialThree = nat23Q2, SocialThree = soc23Q2, HumanitarianThree = hum23Q2, MetodicalThree = met23Q2, ReferenceThree = refs23Q2, ArtThree = art23Q2, PrentedThree = prt23Q2, ElectronicThree = el23Q2, PeriodichThree = per23Q2, NotesThree = "" });
            //3 кв.
            DataList.Add(new ResultsThree() { FundMomentThree = _title23Q3, TotalCountThree = _count23Q3, TotalCostThree = _cost23Q3, NaturalSocialThree = _natural23Q3, SocialThree = _social23Q3, HumanitarianThree = _human23Q3, MetodicalThree = _metodical23Q3, ReferenceThree = _reference23Q3, ArtThree = _art23Q3, PrentedThree = _print23Q3, ElectronicThree = _electr23Q3, PeriodichThree = _period23Q3, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = _titl23Q3, TotalCountThree = _totCount23Q3, TotalCostThree = _totCost23Q3, NaturalSocialThree = _nat23Q3, SocialThree = _soc23Q3, HumanitarianThree = _hum23Q3, MetodicalThree = _met23Q3, ReferenceThree = _ref23Q3, ArtThree = _arts23Q3, PrentedThree = _prt23Q3, ElectronicThree = _el23Q3, PeriodichThree = _per23Q3, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = title23Q3, TotalCountThree = totCount23Q3, TotalCostThree = cost23Q3, NaturalSocialThree = nat23Q3, SocialThree = soc23Q3, HumanitarianThree = hum23Q3, MetodicalThree = met23Q3, ReferenceThree = refs23Q3, ArtThree = art23Q3, PrentedThree = prt23Q3, ElectronicThree = el23Q3, PeriodichThree = per23Q3, NotesThree = "" });



            //4 кв.
            DataList.Add(new ResultsThree() { FundMomentThree = _title23Q4, TotalCountThree = _count23Q4, TotalCostThree = _cost23Q4, NaturalSocialThree = _natural23Q4, SocialThree = _social23Q4, HumanitarianThree = _human23Q4, MetodicalThree = _metodical23Q4, ReferenceThree = _reference23Q4, ArtThree = _art23Q4, PrentedThree = _print23Q4, ElectronicThree = _electr23Q4, PeriodichThree = _period23Q4, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = _titl23Q4, TotalCountThree = _totCount23Q4, TotalCostThree = _totCost23Q4, NaturalSocialThree = _nat23Q4, SocialThree = _soc23Q4, HumanitarianThree = _hum23Q4, MetodicalThree = _met23Q4, ReferenceThree = _ref23Q4, ArtThree = _arts23Q4, PrentedThree = _prt23Q4, ElectronicThree = _el23Q4, PeriodichThree = _per23Q4, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = title23Q4, TotalCountThree = totCount23Q4, TotalCostThree = cost23Q4, NaturalSocialThree = nat23Q4, SocialThree = soc23Q4, HumanitarianThree = hum23Q4, MetodicalThree = met23Q4, ReferenceThree = refs23Q4, ArtThree = art23Q4, PrentedThree = prt23Q4, ElectronicThree = el23Q4, PeriodichThree = per23Q4, NotesThree = "" });
            //Итоги
            DataList.Add(new ResultsThree() { FundMomentThree = title2023, TotalCountThree = _totalCount2023, TotalCostThree = _totalCost2023, NaturalSocialThree = _natural2023, SocialThree = _social2023, HumanitarianThree = _human2023, MetodicalThree = _metodical2023, ReferenceThree = _reference2023, ArtThree = _art2023, PrentedThree = _print2023, ElectronicThree = _electr2023, PeriodichThree = _period2023, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = titleDis2023, TotalCountThree = totCount2023, TotalCostThree = cost2023, NaturalSocialThree = nat2023, SocialThree = soc2023, HumanitarianThree = hum2023, MetodicalThree = met2023, ReferenceThree = refs2023, ArtThree = art2023, PrentedThree = prt2023, ElectronicThree = el2023, PeriodichThree = per2023, NotesThree = "" });
            //2024
            DataList.Add(new ResultsThree() { FundMomentThree = _title24, TotalCountThree = _count24, TotalCostThree = _cost24, NaturalSocialThree = _natural24, SocialThree = _social24, HumanitarianThree = _human24, MetodicalThree = _metodical24, ReferenceThree = _reference24, ArtThree = _art24, PrentedThree = _print24, ElectronicThree = _electr24, PeriodichThree = _period24, NotesThree = "" });
            //1 кв.
            DataList.Add(new ResultsThree() { FundMomentThree = _titl24, TotalCountThree = _totCount24, TotalCostThree = _totCost24, NaturalSocialThree = _nat24, SocialThree = _soc24, HumanitarianThree = _hum24, MetodicalThree = _met24, ReferenceThree = _ref24, ArtThree = _art24, PrentedThree = _prt24, ElectronicThree = _el24, PeriodichThree = _per24, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = title24, TotalCountThree = totCount24, TotalCostThree = cost24, NaturalSocialThree = nat24, SocialThree = soc24, HumanitarianThree = hum24, MetodicalThree = met24, ReferenceThree = refs24, ArtThree = art24, PrentedThree = prt24, ElectronicThree = el24, PeriodichThree = per24, NotesThree = "" });
            //2 кв.
            DataList.Add(new ResultsThree() { FundMomentThree = _title24Q2, TotalCountThree = _count24Q2, TotalCostThree = _cost24Q2, NaturalSocialThree = _natural24Q2, SocialThree = _social24Q2, HumanitarianThree = _human24Q2, MetodicalThree = _metodic24Q2, ReferenceThree = _reference24Q2, ArtThree = _art24Q2, PrentedThree = _print24Q2, ElectronicThree = _elctr24Q2, PeriodichThree = _period24Q2, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = _titl24Q2, TotalCountThree = _totCount24Q2, TotalCostThree = _totCost24Q2, NaturalSocialThree = _nat24Q2, SocialThree = _soc24Q2, HumanitarianThree = _hum24Q2, MetodicalThree = _met24Q2, ReferenceThree = _ref24Q2, ArtThree = _arts24Q2, PrentedThree = _prt24Q2, ElectronicThree = _el24Q2, PeriodichThree = _per24Q2, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = title24Q2, TotalCountThree = totCount24Q2, TotalCostThree = cost24Q2, NaturalSocialThree = nat24Q2, SocialThree = soc24Q2, HumanitarianThree = hum24Q2, MetodicalThree = met24Q2, ReferenceThree = refs24Q2, ArtThree = art24Q2, PrentedThree = prt24Q2, ElectronicThree = el24Q2, PeriodichThree = per24Q2, NotesThree = "" });
            //3 кв.
            DataList.Add(new ResultsThree() { FundMomentThree = _title24Q3, TotalCountThree = _count24Q3, TotalCostThree = _cost24Q3, NaturalSocialThree = _natural24Q3, SocialThree = _social24Q3, HumanitarianThree = _human24Q3, MetodicalThree = _metodical24Q3, ReferenceThree = _reference24Q3, ArtThree = _art24Q3, PrentedThree = _print24Q3, ElectronicThree = _electr24Q3, PeriodichThree = _period24Q3, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = _titl24Q3, TotalCountThree = _totCount24Q3, TotalCostThree = _totCost24Q3, NaturalSocialThree = _nat24Q3, SocialThree = _soc24Q3, HumanitarianThree = _hum24Q3, MetodicalThree = _met24Q3, ReferenceThree = _ref24Q3, ArtThree = _arts24Q3, PrentedThree = _prt24Q3, ElectronicThree = _el24Q3, PeriodichThree = _per24Q3, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = title24Q3, TotalCountThree = totCount24Q3, TotalCostThree = cost24Q3, NaturalSocialThree = nat24Q3, SocialThree = soc24Q3, HumanitarianThree = hum24Q3, MetodicalThree = met24Q3, ReferenceThree = refs24Q3, ArtThree = art24Q3, PrentedThree = prt24Q3, ElectronicThree = el24Q3, PeriodichThree = per24Q3, NotesThree = "" });
            //4 кв.
            DataList.Add(new ResultsThree() { FundMomentThree = _title24Q4, TotalCountThree = _count24Q4, TotalCostThree = _cost24Q4, NaturalSocialThree = _natural24Q4, SocialThree = _social24Q4, HumanitarianThree = _human24Q4, MetodicalThree = _metodical24Q4, ReferenceThree = _reference24Q4, ArtThree = _art24Q4, PrentedThree = _print24Q4, ElectronicThree = _electr24Q4, PeriodichThree = _period24Q4, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = _titl24Q4, TotalCountThree = _totCount24Q4, TotalCostThree = _totCost24Q4, NaturalSocialThree = _nat24Q4, SocialThree = _soc24Q4, HumanitarianThree = _hum24Q4, MetodicalThree = _met24Q4, ReferenceThree = _ref24Q4, ArtThree = _arts24Q4, PrentedThree = _prt24Q4, ElectronicThree = _el24Q4, PeriodichThree = _per24Q4, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = title24Q4, TotalCountThree = totCount24Q4, TotalCostThree = cost24Q4, NaturalSocialThree = nat24Q4, SocialThree = soc24Q4, HumanitarianThree = hum24Q4, MetodicalThree = met24Q4, ReferenceThree = refs24Q4, ArtThree = art24Q4, PrentedThree = prt24Q4, ElectronicThree = el24Q4, PeriodichThree = per24Q4, NotesThree = "" });
            //Итоги
            DataList.Add(new ResultsThree() { FundMomentThree = title2024, TotalCountThree = _totalCount2024, TotalCostThree = _totalCost2024, NaturalSocialThree = _natural2024, SocialThree = _social2024, HumanitarianThree = _human2024, MetodicalThree = _metodical2024, ReferenceThree = _reference2024, ArtThree = _art2024, PrentedThree = _print2024, ElectronicThree = _electr2024, PeriodichThree = _period2024, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = titleDis2024, TotalCountThree = totCount2024, TotalCostThree = cost2024, NaturalSocialThree = nat2024, SocialThree = soc2024, HumanitarianThree = hum2024, MetodicalThree = met2024, ReferenceThree = refs2024, ArtThree = art2024, PrentedThree = prt2024, ElectronicThree = el2024, PeriodichThree = per2024, NotesThree = "" });
            //2025
            DataList.Add(new ResultsThree() { FundMomentThree = _title25, TotalCountThree = _count25, TotalCostThree = _cost25, NaturalSocialThree = _natural25, SocialThree = _social25, HumanitarianThree = _human25, MetodicalThree = _metodical25, ReferenceThree = _reference25, ArtThree = _art25, PrentedThree = _print25, ElectronicThree = _electr25, PeriodichThree = _period25, NotesThree = "" });

        }
       
    }
    
}
