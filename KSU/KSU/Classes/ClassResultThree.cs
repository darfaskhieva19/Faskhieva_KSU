using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KSU.ClassResultTwo;

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
            //Диапазон первого квартала
            DateTime Jan = new DateTime(_year22, 1, 1);
            DateTime Mar = new DateTime(_year22, 3, 31);
            // Диапазон второго квартала
            DateTime Aprils = new DateTime(_year22, 4, 1);
            DateTime Junes = new DateTime(_year22, 6, 30);
            int _countBeginingYear22 = 0, _costYear22 = 0, _naturalYear22 = 0, _socialYear22 = 0, _humanYear22 = 0, _metodicalYear22 = 0, _referenceYear22 = 0, _artYear22 = 0, _printYear22 = 0, _electrYear22 = 0, _periodYear22 = 0;
            //Подсчеты сколько состоит на начало 2021 года
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
            //Поступило 1 кв. 2022
            var _items22 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= Jan && x.Date <= Mar);
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
            //Состоит на 2 кв
            int _countBeginingYear22Q2 = 0, _costYear22Q2 = 0, _naturalYear22Q2 = 0, _socialYear22Q2 = 0, _humanYear22Q2 = 0, _metodicalYear22Q2 = 0, _referenceYear22Q2 = 0, _artYear22Q2 = 0, _printYear22Q2 = 0, _electrYear22Q2 = 0, _periodYear22Q2 = 0;
            _countBeginingYear22Q2 = _countBeginingYear22 + _totalCount22;
            _naturalYear22Q2 = _naturalYear22 + _natural22;
            _socialYear22Q2 = _socialYear22 + _social22;
            _referenceYear22Q2 = _printYear22 + _reference22;
            _humanYear22Q2 = _humanYear22 + _human22;
            _metodicalYear22Q2 = _metodicalYear22 + _metodical22;
            _artYear22Q2 = _artYear22 + _art22;
            _printYear22Q2 = _printYear22 + _print22;
            _electrYear22Q2 = _electrYear22 + _electr22;
            _periodYear22Q2 = _periodYear22 + _period22;
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
            //Состоит на 2023
            int _year23 = 2023;


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
            DataList.Add(new ResultsThree() { FundMomentThree = "Поступило за 1 кв. 2022 г.", TotalCountThree = _totalCount22, TotalCostThree = _totalCost22, NaturalSocialThree = _natural22, SocialThree = _social22, HumanitarianThree = _human22, MetodicalThree = _metodical22, ReferenceThree = _reference22, ArtThree = _art22, PrentedThree = _print22, ElectronicThree = _electr22, PeriodichThree = _period22, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Состоит на 2 кв. 2022 г.", TotalCountThree = _countBeginingYear22Q2, TotalCostThree = _costYear22Q2, NaturalSocialThree = _naturalYear22Q2, SocialThree = _socialYear22Q2, HumanitarianThree = _humanYear21Q4, MetodicalThree = _metodicalYear22Q2, ReferenceThree = _referenceYear22Q2, ArtThree = _artYear22Q2, PrentedThree = _printYear22Q2, ElectronicThree = _electrYear22Q2, PeriodichThree = _periodYear22Q2, NotesThree = "" });
            DataList.Add(new ResultsThree() { FundMomentThree = "Выбыло за 2 кв. 2022 г.", TotalCountThree = totalCountDis22, TotalCostThree = totalCostDis22, NaturalSocialThree = naturalDis22, SocialThree = socialDis22, HumanitarianThree = humanDis22, MetodicalThree = metodicalDis22, ReferenceThree = referenceDis22, ArtThree = artDis22, PrentedThree = printDis22, ElectronicThree = electrDis22, PeriodichThree = periodDis22, NotesThree = "" });

        }
    }
    
}
