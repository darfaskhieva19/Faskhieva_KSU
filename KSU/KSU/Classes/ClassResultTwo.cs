using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSU
{
    public class ClassResultTwo
    {
        public class ResultsTwo
        {
            public string FundMomentTwo { get; set; }
            public int TotalCountTwo { get; set; }
            public double TotalCostTwo { get; set; }
            public int NaturalSocialTwo { get; set; }
            public int SocialTwo { get; set; }
            public int HumanitarianTwo { get; set; }
            public int MetodicalTwo { get; set; }
            public int ReferenceTwo { get; set; }
            public int ArtTwo { get; set; }
            public int PrentedTwo { get; set; }
            public int ElectronicTwo { get; set; }
            public int PeriodichTwo { get; set; }
            public string NotesTwo { get; set; }
        }

        public List<ResultsTwo> DataList { get; }

        public ClassResultTwo()
        {
            int _twocount = 17764, _twonatural = 2621, _twosocial = 1144, _twohuman = 9211, _twometodical = 10, _tworeference = 115, _twoart = 4663, _twoprint = 17764, _twoelectr = 0, _twoperiod = 0;
            double _twocost = 0;
            // идентификатор книг по содержанию, количество которой нужно подсчитать
            int contentId = 1, contentIdTwo = 2, contentIdThree = 3, contentIdFour = 4, contentIdFive = 5, contentIdSix = 6;
            // идентификатор книг по виду, количество которой нужно подсчитать 
            int viewId = 1, viewIdTwo = 2, viewIdThree = 3;

            int _year = 2018;
            DateTime _startDate = new DateTime(_year, 1, 1);
            DateTime _endDate = new DateTime(_year, 12, 31);
            // Рассчитываем Поступление за 2018 год 
            var _item = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 2 && x.Date >= _startDate && x.Date <= _endDate);
            int _totalCount = 0, _natural18 = 0, _social18 = 0, _human18 = 0, _metodical18 = 0, _reference18 = 0, _art18 = 0, _print18 = 0, _electr18 = 0, _period18 = 0;
            double _totalCost = 0;
            foreach (var item in _item) { _totalCount += item.TotalInstances; _totalCost += item.Cost; }
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
            //Состоит на начало 2020 года
            int _countBeginingYear19 = 0, _costYear19 = 0, _naturalYear19 = 0, _socialYear19 = 0, _humanYear19 = 0, _metodicalYear19 = 0, _referenceYear19 = 0, _artYear19 = 0, _printYear19 = 0, _electrYear19 = 0, _periodYear19 = 0;
            _countBeginingYear19 = _twocount + _totalCount;
            _naturalYear19 = _twonatural + _natural18;
            _socialYear19 = _twosocial + _social18;
            _referenceYear19 = _tworeference + _reference18;
            _humanYear19 = _twohuman + _human18;
            _metodicalYear19 = _twometodical + _metodical18;
            _artYear19 = _twoart + _art18;
            _printYear19 = _twoprint + _print18;
            _electrYear19 = _twoelectr + _electr18;
            _periodYear19 = _twoperiod + _period18;
            int _year20 = 2020;
            DateTime _startDate20 = new DateTime(_year20, 1, 1);
            DateTime _endDate20 = new DateTime(_year20, 12, 31);
            //Поступление за 2020 год 
            var _items = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 2 && x.Date >= _startDate20 && x.Date <= _endDate20);
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
            //Выбытие 2020 год
            int totalCountDis20 = 0, naturalDis20 = 0, socialDis20 = 0, humanDis20 = 0, metodicalDis20 = 0, referenceDis20 = 0, artDis20 = 0, printDis20 = 0, electrDis20 = 0, periodDis20 = 0;
            double totalCostDis20 = 0; //Общая стоимость
            var itemss20 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 2 && x.Date >= _startDate20 && x.Date <= _endDate20);
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
            //Состоит на начало 2020 года
            int _countBeginingYear21Q2 = 0, _costYear21Q2 = 0, _naturalYear21Q2 = 0, _socialYear21Q2 = 0, _humanYear21Q2 = 0, _metodicalYear21Q2 = 0, _referenceYear21Q2 = 0, _artYear21Q2 = 0, _printYear21Q2 = 0, _electrYear21Q2 = 0, _periodYear21Q2 = 0;
            _countBeginingYear21Q2 = _countBeginingYear19 + _totalCount20 - totalCountDis20;
            _naturalYear21Q2 = _naturalYear19 + _natural20 - naturalDis20;
            _socialYear21Q2 = _socialYear19 + _social20 - socialDis20;
            _referenceYear21Q2 = _referenceYear19 + _reference20 - referenceDis20;
            _humanYear21Q2 = _humanYear19 + _human20 - humanDis20;
            _metodicalYear21Q2 = _metodicalYear19 + _metodical20 - metodicalDis20;
            _artYear21Q2 = _artYear19 + _art20 - artDis20;
            _printYear21Q2 = _printYear19 + _print20 - printDis20;
            _electrYear21Q2 = _electrYear19 + _electr20 - electrDis20;
            _periodYear21Q2 = _periodYear19 + _period20 - periodDis20;
            //Поступило на 2 кв. 2021
            int year21 = 2021;
            // Диапазон второго квартала
            DateTime April = new DateTime(year21, 4, 1);
            DateTime June = new DateTime(year21, 6, 30);
            // Диапазон четвертого квартала
            DateTime October = new DateTime(year21, 10, 1);
            DateTime December = new DateTime(year21, 12, 31);
            var items2021Q2 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 2 && x.Date >= April && x.Date <= June);
            int totalCountQ2 = 0, naturalQ2 = 0, socialQ2 = 0, humanQ2 = 0, metodicalQ2 = 0, referenceQ2 = 0, artQ2 = 0, printQ2 = 0, electrQ2 = 0, periodQ2 = 0;
            double totalCostQ2 = 0; //Общая стоимость
            foreach (var item in items2021Q2) { totalCountQ2 += item.TotalInstances; totalCostQ2 += item.Cost; }
            foreach (var item in items2021Q2) //По содержанию
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { naturalQ2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { socialQ2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { humanQ2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodicalQ2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { referenceQ2 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { artQ2 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in items2021Q2) //По виду
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { printQ2 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { electrQ2 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { periodQ2 += (int)itemView.Counts; }
                }
            }
            //Состоит на 4 кв. 2021
            int _countBeginingYear21Q4 = 0, _costYear21Q4 = 0, _naturalYear21Q4 = 0, _socialYear21Q4 = 0, _humanYear21Q4 = 0, _metodicalYear21Q4 = 0, _referenceYear21Q4 = 0, _artYear21Q4 = 0, _printYear21Q4 = 0, _electrYear21Q4 = 0, _periodYear21Q4 = 0;
            _countBeginingYear21Q4 = _countBeginingYear21Q2 + totalCountQ2;
            _naturalYear21Q4 = _naturalYear21Q2 + naturalQ2;
            _socialYear21Q4 = _socialYear21Q2 + socialQ2;
            _referenceYear21Q4 = _referenceYear21Q2 + referenceQ2;
            _humanYear21Q4 = _humanYear21Q2 + humanQ2;
            _metodicalYear21Q4 = _metodicalYear21Q2 + metodicalQ2;
            _artYear21Q4 = _artYear21Q2 + artQ2;
            _printYear21Q4 = _printYear21Q2 + printQ2;
            _electrYear21Q4 = _electrYear21Q2 + electrQ2;
            _periodYear21Q4 = _periodYear21Q2 + periodQ2;
            //Поступление 2021 год за 4 квартал
            var items2021Q4 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 2 && x.Date >= October && x.Date <= December);
            int totalCountQ4 = 0, naturalQ4 = 0, socialQ4 = 0, humanQ4 = 0, metodicalQ4 = 0, referenceQ4 = 0, artQ4 = 0, printQ4 = 0, electrQ4 = 0, periodQ4 = 0;
            double totalCostQ4 = 0; //Общая стоимость
            foreach (var item in items2021Q4) { totalCountQ4 += item.TotalInstances; totalCostQ4 += item.Cost; }
            foreach (var item in items2021Q4) //По содержанию
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { naturalQ4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { socialQ4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { humanQ4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodicalQ4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { referenceQ4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { artQ4 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in items2021Q4) //По виду
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { printQ4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { electrQ4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { periodQ4 += (int)itemView.Counts; }
                }
            }
            //Выбыло 2021 год за 4 квартал
            int totalCountDis21K4 = 0, naturalDis21K4 = 0, socialDis21K4 = 0, humanDis21K4 = 0, metodicalDis21K4 = 0, referenceDis21K4 = 0, artDis21K4 = 0, printDis21K4 = 0, electrDis21K4 = 0, periodDis21K4 = 0;
            double totalCostDis21K4 = 0; //Общая стоимость
            var itemss21K4 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 2 && x.Date >= October && x.Date <= December);
            foreach (var item in itemss21K4)
            {
                totalCountDis21K4 += item.TotalNumber;
                totalCostDis21K4 += item.Cost;
            }
            foreach (var item in itemss21K4) //По содержанию
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { naturalDis21K4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки                    
                    { socialDis21K4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки                    
                    { humanDis21K4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodicalDis21K4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература                    
                    { referenceDis21K4 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { artDis21K4 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in itemss21K4) // По виду
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатные
                    { printDis21K4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронные
                    { electrDis21K4 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree) //Периодические издания
                    { periodDis21K4 += (int)itemView.Counts; }
                }
            }
            //Итого поступило
            DateTime startDate2021 = new DateTime(year21, 1, 1);
            DateTime endDate2021 = new DateTime(year21, 12, 31);
            var _items2021 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 2 && x.Date >= startDate2021 && x.Date <= endDate2021);
            int totalCount2021 = 0, natural2021 = 0, social2021 = 0, human2021 = 0, metodical2021 = 0, reference2021 = 0, art2021 = 0, print2021 = 0, electr2021 = 0, period2021 = 0;
            double totalCost2021 = 0;
            foreach (var item in _items2021)
            {
                totalCount2021 = totalCountQ2 + totalCountQ4;
                totalCost2021 = totalCostQ2 + totalCostQ4;
                natural2021 = naturalQ2 + naturalQ4;
                social2021 = socialQ2 + socialQ4;
                human2021 = humanQ2 + humanQ4;
                metodical2021 = metodicalQ2 + metodicalQ4;
                reference2021 = referenceQ2 + referenceQ4;
                art2021 = artQ2 + artQ4;
                print2021 = printQ2 + printQ4;
                electr2021 = electrQ2 + electrQ4;
                period2021 = periodQ2 + periodQ4;
            }
            //Выбыло
            int totalCountDis2021 = 0, naturalDis2021 = 0, socialDis2021 = 0, humanDis2021 = 0, metodicalDis2021 = 0, referenceDis2021 = 0, artDis2021 = 0, printDis2021 = 0, electrDis2021 = 0, periodDis2021 = 0;
            double totalCostDis2021 = 0; //Общая стоимость
            var itemss2021 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 2 && x.Date >= startDate2021 && x.Date <= endDate2021);
            foreach (var item in itemss2021)
            {
                totalCountDis2021 = totalCountDis21K4;
                totalCostDis2021 = totalCostDis21K4;
                naturalDis2021 = naturalDis21K4;
                socialDis2021 = socialDis21K4;
                humanDis2021 = humanDis21K4;
                metodicalDis2021 = metodicalDis21K4;
                referenceDis2021 = referenceDis21K4;
                artDis2021 = artDis21K4;
                printDis2021 = printDis21K4;
                electrDis2021 = electrDis21K4;
                periodDis2021 = periodDis21K4;
            }
            //Состоит на 2022
            int year22 = 2022;
            // Диапазон второго квартала
            DateTime AprilTwo = new DateTime(year22, 4, 1);
            DateTime JuneTwo = new DateTime(year22, 6, 30);
            int _countBeginingYear22 = 0, _costYear22 = 0, _naturalYear22 = 0, _socialYear22 = 0, _humanYear22 = 0, _metodicalYear22 = 0, _referenceYear22 = 0, _artYear22 = 0, _printYear22 = 0, _electrYear22 = 0, _periodYear22 = 0;
            //Подсчеты сколько состоит на начало 2021 года
            _countBeginingYear22 = _countBeginingYear21Q4 + totalCountQ4 - totalCountDis21K4;
            _naturalYear22 = _naturalYear21Q4 + naturalQ4 - naturalDis21K4;
            _socialYear22 = _socialYear21Q4 + socialQ4 - socialDis21K4;
            _referenceYear22 = _referenceYear21Q4 + referenceQ4 - referenceDis21K4;
            _humanYear22 = _humanYear21Q4 + humanQ4 - humanDis21K4;
            _metodicalYear22 = _metodicalYear21Q4 + metodicalQ4 - metodicalDis21K4;
            _artYear22 = _artYear21Q4 + artQ4 - artDis21K4;
            _printYear22 = _printYear21Q4 + printQ4 - printDis21K4;
            _electrYear22 = _electrYear21Q4 + electrQ4 - electrDis21K4;
            _periodYear22 = _periodYear21Q4 + periodQ4 - periodDis21K4;
            //Поступление 2 кв. 2022
            int totalCountQ222 = 0, naturalQ222 = 0, socialQ222 = 0, humanQ222 = 0, metQ222 = 0, refQ222 = 0, artQ222 = 0, printQ222 = 0, electrQ222 = 0, periodQ222 = 0;
            double totalCostQ222 = 0;
            var items2022Q22 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 2 && x.Date >= AprilTwo && x.Date <= JuneTwo);
            foreach (var item in items2022Q22) { totalCountQ222 += item.TotalInstances; totalCostQ222 += item.Cost; }
            foreach (var item in items2022Q22) //По содержанию
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { naturalQ222 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { socialQ222 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { humanQ222 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metQ222 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { refQ222 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { artQ222 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in items2022Q22) //По виду
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { printQ222 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { electrQ222 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { periodQ222 += (int)itemView.Counts; }
                }
            }
            //Состоит на 2023
            int year23 = 2023;
            // Диапазон первого квартала
            DateTime Jans = new DateTime(year23, 1, 1);
            DateTime Mars = new DateTime(year23, 3, 31);
            // Диапазон второго квартала
            DateTime Aprs = new DateTime(year23, 4, 1);
            DateTime Juns = new DateTime(year23, 6, 30);
            // Диапазон третьего квартала
            DateTime Juls = new DateTime(year23, 7, 1);
            DateTime Seps = new DateTime(year23, 9, 30);
            // Диапазон четвертого квартала
            DateTime Octs = new DateTime(year23, 10, 1);
            DateTime Decs = new DateTime(year23, 12, 31);
            int _countBeginingYear23 = 0, _costYear23 = 0, _naturalYear23 = 0, _socialYear23 = 0, _humanYear23 = 0, _metodicalYear23 = 0, _referenceYear23 = 0, _artYear23 = 0, _printYear23 = 0, _electrYear23 = 0, _periodYear23 = 0;
            //Подсчеты сколько состоит на начало 2021 года
            _countBeginingYear23 = _countBeginingYear22 + totalCountQ222;
            _naturalYear23 = _naturalYear22 + naturalQ222;
            _socialYear23 = _socialYear22 + socialQ222;
            _referenceYear23 = _referenceYear22 + refQ222;
            _humanYear23 = _humanYear22 + humanQ222;
            _metodicalYear23 = _metodicalYear22 + metQ222;
            _artYear23 = _artYear22 + artQ222;
            _printYear23 = _printYear22 + printQ222;
            _electrYear23 = _electrYear22 + electrQ222;
            _periodYear23 = _periodYear22 + periodQ222;
            var items2023Q1 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 2 && x.Date >= Jans && x.Date <= Mars);
            int totalCountQ1 = 0, naturalQ1 = 0, socialQ1 = 0, humanQ1 = 0, metodicalQ1 = 0, referenceQ1 = 0, artQ1 = 0, printQ1 = 0, electrQ1 = 0, periodQ1 = 0;
            double totalCostQ1 = 0; //Общая стоимость
            foreach (var item in items2023Q1) { totalCountQ1 += item.TotalInstances; totalCostQ1 += item.Cost; }
            foreach (var item in items2023Q1) //По содержанию
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { naturalQ1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { socialQ1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { humanQ1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodicalQ1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { referenceQ1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { artQ1 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in items2023Q1) //По виду
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { printQ1 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { electrQ1 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { periodQ1 += (int)itemView.Counts; }
                }
            }
            //Состоит на 2 кв.2023

            //Поступление 2 кв.2023

            //Выбытие 2 кв. 2023

            //Состоит на 3 кв.2023

            //Поступление 3 кв.2023

            //Выбытие 3 кв. 2023

            //Состоит на 4 кв.2023

            //Поступление 4 кв.2023

            //Выбытие 4 кв. 2023

            //Итого поступило

            //Выбыло

            //Состоит на 01.01.2024

            // В конструкторе заполняем список данных
            DataList = new List<ResultsTwo>();
            DataList.Add(new ResultsTwo() { FundMomentTwo = "Состоит на 01.01.2018 г.", TotalCountTwo = 17764, TotalCostTwo = 0, NaturalSocialTwo = 2621, SocialTwo = 2621, HumanitarianTwo = 9211, MetodicalTwo = 10, ReferenceTwo = 115, ArtTwo = 4663, PrentedTwo = 17764, ElectronicTwo = 0, PeriodichTwo = 0, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = "Поступило за 2018 г.", TotalCountTwo = _totalCount, TotalCostTwo = _totalCost, NaturalSocialTwo = _natural18, SocialTwo = _social18, HumanitarianTwo = _human18, MetodicalTwo = _metodical18, ReferenceTwo = _reference18, ArtTwo = _art18, PrentedTwo = _print18, ElectronicTwo = _electr18, PeriodichTwo = _period18, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = "Состоит на 01.01.2020 г.", TotalCountTwo = _countBeginingYear19, TotalCostTwo = _costYear19, NaturalSocialTwo = _naturalYear19, SocialTwo = _socialYear19, HumanitarianTwo = _humanYear19, MetodicalTwo = _metodicalYear19, ReferenceTwo = _referenceYear19, ArtTwo = _artYear19, PrentedTwo = _printYear19, ElectronicTwo = _electrYear19, PeriodichTwo = _periodYear19, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = "Поступило за 2020 г.", TotalCountTwo = _totalCount20, TotalCostTwo = _totalCost20, NaturalSocialTwo = _natural20, SocialTwo = _social20, HumanitarianTwo = _human20, MetodicalTwo = _metodical20, ReferenceTwo = _reference20, ArtTwo = _art20, PrentedTwo = _print20, ElectronicTwo = _electr20, PeriodichTwo = _period20, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = "Выбыло за 2020 г.", TotalCountTwo = totalCountDis20, TotalCostTwo = totalCostDis20, NaturalSocialTwo = naturalDis20, SocialTwo = socialDis20, HumanitarianTwo = humanDis20, MetodicalTwo = metodicalDis20, ReferenceTwo = referenceDis20, ArtTwo = artDis20, PrentedTwo = printDis20, ElectronicTwo = electrDis20, PeriodichTwo = periodDis20, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = "Состоит на 2 кв. 2021 г.", TotalCountTwo = _countBeginingYear21Q2, TotalCostTwo = _costYear21Q2, NaturalSocialTwo = _naturalYear21Q2, SocialTwo = _socialYear21Q2, HumanitarianTwo = _humanYear21Q2, MetodicalTwo = _metodicalYear21Q2, ReferenceTwo = _referenceYear21Q2, ArtTwo = _artYear21Q2, PrentedTwo = _printYear21Q2, ElectronicTwo = _electrYear21Q2, PeriodichTwo = _periodYear21Q2, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = "Поступило за 2 кв. 2021 г.", TotalCountTwo = totalCountQ2, TotalCostTwo = totalCostQ2, NaturalSocialTwo = naturalQ2, SocialTwo = socialQ2, HumanitarianTwo = humanQ2, MetodicalTwo = metodicalQ2, ReferenceTwo = referenceQ2, ArtTwo = artQ2, PrentedTwo = printQ2, ElectronicTwo = electrQ2, PeriodichTwo = periodQ2, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = "Состоит на 4 кв. 2021 г.", TotalCountTwo = _countBeginingYear21Q4, TotalCostTwo = _costYear21Q4, NaturalSocialTwo = _naturalYear21Q4, SocialTwo = _socialYear21Q4, HumanitarianTwo = _humanYear21Q4, MetodicalTwo = _metodicalYear21Q4, ReferenceTwo = _referenceYear21Q4, ArtTwo = _artYear21Q4, PrentedTwo = _printYear21Q4, ElectronicTwo = _electrYear21Q4, PeriodichTwo = _periodYear21Q4, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = "Поступило за 4 кв. 2021 г.", TotalCountTwo = totalCountQ4, TotalCostTwo = totalCostQ4, NaturalSocialTwo = naturalQ4, SocialTwo = socialQ4, HumanitarianTwo = humanQ4, MetodicalTwo = metodicalQ4, ReferenceTwo = referenceQ4, ArtTwo = artQ4, PrentedTwo = printQ4, ElectronicTwo = electrQ4, PeriodichTwo = periodQ4, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = "Выбыло за 4 кв. 2021 г.", TotalCountTwo = totalCountDis21K4, TotalCostTwo = totalCostDis21K4, NaturalSocialTwo = naturalDis21K4, SocialTwo = socialDis21K4, HumanitarianTwo = humanDis21K4, MetodicalTwo = metodicalDis21K4, ReferenceTwo = referenceDis21K4, ArtTwo = artDis21K4, PrentedTwo = printDis21K4, ElectronicTwo = electrDis21K4, PeriodichTwo = periodDis21K4, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = "Итого поступило", TotalCountTwo = totalCount2021, TotalCostTwo = totalCost2021, NaturalSocialTwo = natural2021, SocialTwo = social2021, HumanitarianTwo = human2021, MetodicalTwo = metodical2021, ReferenceTwo = reference2021, ArtTwo = art2021, PrentedTwo = print2021, ElectronicTwo = electr2021, PeriodichTwo = period2021, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = "Выбыло", TotalCountTwo = totalCountDis2021, TotalCostTwo = totalCostDis2021, NaturalSocialTwo = naturalDis2021, SocialTwo = socialDis2021, HumanitarianTwo = humanDis2021, MetodicalTwo = metodicalDis2021, ReferenceTwo = referenceDis2021, ArtTwo = artDis2021, PrentedTwo = printDis2021, ElectronicTwo = electrDis2021, PeriodichTwo = periodDis2021, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = "Состоит на 01.01.2022 г.", TotalCountTwo = _countBeginingYear22, TotalCostTwo = _costYear22, NaturalSocialTwo = _naturalYear22, SocialTwo = _socialYear22, HumanitarianTwo = _referenceYear22, MetodicalTwo = _metodicalYear22, ReferenceTwo = _referenceYear22, ArtTwo = _artYear22, PrentedTwo = _printYear22, ElectronicTwo = _electrYear22, PeriodichTwo = _periodYear22, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = "Поступление за 2 кв. 2022 г.", TotalCountTwo = totalCountQ222, TotalCostTwo = totalCostQ222, NaturalSocialTwo = naturalQ222, SocialTwo = socialQ222, HumanitarianTwo = humanQ222, MetodicalTwo = metQ222, ReferenceTwo = refQ222, ArtTwo = artQ222, PrentedTwo = printQ222, ElectronicTwo = electrQ222, PeriodichTwo = periodQ222, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = "Состоит на 01.01.2023 г.", TotalCountTwo = _countBeginingYear23, TotalCostTwo = _costYear23, NaturalSocialTwo = _naturalYear23, SocialTwo = _socialYear23, HumanitarianTwo = _referenceYear23, MetodicalTwo = _metodicalYear23, ReferenceTwo = _referenceYear23, ArtTwo = _artYear23, PrentedTwo = _printYear23, ElectronicTwo = _electrYear23, PeriodichTwo = _periodYear23, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = "Поступление за 1 кв. 2023 г.", TotalCountTwo = totalCountQ1, TotalCostTwo = totalCostQ1, NaturalSocialTwo = naturalQ1, SocialTwo = socialQ1, HumanitarianTwo = humanQ1, MetodicalTwo = metodicalQ1, ReferenceTwo = referenceQ1, ArtTwo = artQ1, PrentedTwo = printQ1, ElectronicTwo = electrQ1, PeriodichTwo = periodQ1, NotesTwo = "" });


        }       
    }
}
