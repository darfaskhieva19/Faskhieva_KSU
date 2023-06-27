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

            string _titl23Q2 = "Поступило за 2 кв. " + year23 + " г.";
            var _item23Q2 = DataBase.Base.Receipts.Where(x => x.Date >= Aprs && x.Date <= Juns);
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
            string title23Q2 = "Выбыло за 2 кв. " + year23 + " г.";
            var _it23Q2 = DataBase.Base.Disposals.Where(x => x.Date >= Aprs && x.Date <= Juns);
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
            string _title23Q3 = "Состоит на 3 кв. 01.01." + year23 + " г.";
            int _count23Q3 = _countBeginingYear23 + _totCount23Q2 - totCount23Q2, _natural23Q3 = _naturalYear23 + _nat23Q2 - nat23Q2, _social23Q3 = _socialYear23 + _soc23Q2 - soc23Q2, _human23Q3 = _humanYear23 + _hum23Q2 - hum23Q2, _metodical23Q3 = _metodicalYear23 + _met23Q2 - met23Q2, _reference23Q3 = _metodicalYear23 + _ref23Q2 - refs23Q2, _art23Q3 = _artYear23 + _arts23Q2 - art23Q2, _print23Q3 = _printYear23 + _prt23Q2 - prt23Q2, _electr23Q3 = _electrYear23 + _el23Q2 - el23Q2, _period23Q3 = _periodYear23 + _per23Q2 - per23Q2;
            double _cost23Q3 = 0;
            string _titl23Q3 = "Поступило за 3 кв. " + year23 + " г.";
            var _item23Q3 = DataBase.Base.Receipts.Where(x => x.Date >= Juls && x.Date <= Seps);
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
            string title23Q3 = "Выбыло за 3 кв. " + year23 + " г.";
            var _it23Q3 = DataBase.Base.Disposals.Where(x => x.Date >= Juls && x.Date <= Seps);
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
            string _title23Q4 = "Состоит на 4 кв. 01.01." + year23 + " г.";
            int _count23Q4 = _count23Q3 + _totCount23Q3 - totCount23Q3, _natural23Q4 = _natural23Q3 + _nat23Q3 - nat23Q3, _social23Q4 = _social23Q3 + _soc23Q3 - soc23Q3, _human23Q4 = _human23Q3 + _hum23Q3 - hum23Q3, _metodical23Q4 = _metodical23Q3 + _met23Q3 - met23Q3, _reference23Q4 = _reference23Q3 + _ref23Q3 - refs23Q3, _art23Q4 = _art23Q3 + _arts23Q3 - art23Q3, _print23Q4 = _print23Q3 + _prt23Q3 - prt23Q3, _electr23Q4 = _electr23Q3 + _el23Q3 - el23Q3, _period23Q4 = _period23Q3 + _per23Q3 - per23Q3;
            double _cost23Q4 = 0;
            string _titl23Q4 = "Поступило за 4 кв. " + year23 + " г.";
            var _item23Q4 = DataBase.Base.Receipts.Where(x => x.Date >= Octs && x.Date <= Decs);
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
            string title23Q4 = "Выбыло за 4 кв. " + year23 + " г.";
            var _it23Q4 = DataBase.Base.Disposals.Where(x => x.Date >= Octs && x.Date <= Decs);
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
            string title2023 = "Итого поступило за " + year23 + " г.";
            DateTime startDate2023 = new DateTime(year23, 1, 1);
            DateTime endDate2023 = new DateTime(year23, 12, 31);
            int _totalCount2023 = 0, _natural2023 = 0, _social2023 = 0, _human2023 = 0, _metodical2023 = 0, _reference2023 = 0, _art2023 = 0, _print2023 = 0, _electr2023 = 0, _period2023 = 0;
            double _totalCost2023 = 0;
            var Items2023 = DataBase.Base.Receipts.Where(x => x.Date >= startDate2023 && x.Date <= endDate2023);
            foreach (var item in Items2023)
            {
                _totalCount2023 = totalCountQ1 + _totCount23Q2 + _totCount23Q3 + _totCount23Q4;
                _totalCost2023 = totalCostQ1 + _totCost23Q2 + _totCost23Q3 + _totCost23Q4;
                _natural2023 = naturalQ1 + _nat23Q2 + _nat23Q3 + _nat23Q4;
                _social2023 = socialQ1 + _soc23Q2 + _soc23Q3 + _soc23Q4;
                _human2023 = humanQ1 + _hum23Q2 + _hum23Q3 + _hum23Q4;
                _metodical2023 = metodicalQ1 + _met23Q2 + _met23Q3 + _met23Q4;
                _reference2023 = referenceQ1 + _ref23Q2 + _ref23Q3 + _ref23Q4;
                _art2023 = artQ1 + _arts23Q2 + _arts23Q3 + _arts23Q4;
                _print2023 = printQ1 + _prt23Q2 + _prt23Q3 + _prt23Q4;
                _electr2023 = electrQ1 + _el23Q2 + _el23Q3 + _el23Q4;
                _period2023 = periodQ1 + _per23Q2 + _per23Q3 + _per23Q4;
            }
            string titleDis2023 = "Выбыло за " + year23 + " г.";
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
            string _titl24Q2 = "Поступило за 2 кв. " + year23 + " г.";
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
            string _titl24Q4 = "Поступило за 4 кв. " + _year24 + " г.";
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
            int _count25 = _count24Q4 + _totCount24Q4 - totCount24Q4, _natural25 = _natural24Q4 + _nat24Q4 - nat24Q4, _social25 = _social24Q4 + _soc24Q4 - soc24Q4, _human25 = _human24Q4 + _hum24Q4 - hum24Q4, _metodical25 = _metodical24Q4 + _met24Q4 - met24Q4, _reference25 = _reference24Q4 + _ref24Q4 - refs24Q4, _art25 = _art24Q4 + _arts24Q4 - art24Q4, _print25 = _print24Q4 + _prt24Q4 - prt24Q4, _electr25 = _electr24Q4 + _el24Q4 - el24Q4, _period25 = _period24Q4 + _per24Q4 - per24Q4;
            double _cost25 = 0;

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
            //2 кв.
            DataList.Add(new ResultsTwo() { FundMomentTwo = _titl23Q2, TotalCountTwo = _totCount23Q2, TotalCostTwo = _totCost23Q2, NaturalSocialTwo = _nat23Q2, SocialTwo = _soc23Q2, HumanitarianTwo = _hum23Q2, MetodicalTwo = _met23Q2, ReferenceTwo = _ref23Q2, ArtTwo = _arts23Q2, PrentedTwo = _prt23Q2, ElectronicTwo = _el23Q2, PeriodichTwo = _per23Q2, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = title23Q2, TotalCountTwo = totCount23Q2, TotalCostTwo = cost23Q2, NaturalSocialTwo = nat23Q2, SocialTwo = soc23Q2, HumanitarianTwo = hum23Q2, MetodicalTwo = met23Q2, ReferenceTwo = refs23Q2, ArtTwo = art23Q2, PrentedTwo = prt23Q2, ElectronicTwo = el23Q2, PeriodichTwo = per23Q2, NotesTwo = "" });
            //3 кв.
            DataList.Add(new ResultsTwo() { FundMomentTwo = _title23Q3, TotalCountTwo = _count23Q3, TotalCostTwo = _cost23Q3, NaturalSocialTwo = _natural23Q3, SocialTwo = _social23Q3, HumanitarianTwo = _human23Q3, MetodicalTwo = _metodical23Q3, ReferenceTwo = _reference23Q3, ArtTwo = _art23Q3, PrentedTwo = _print23Q3, ElectronicTwo = _electr23Q3, PeriodichTwo = _period23Q3, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = _titl23Q3, TotalCountTwo = _totCount23Q3, TotalCostTwo = _totCost23Q3, NaturalSocialTwo = _nat23Q3, SocialTwo = _soc23Q3, HumanitarianTwo = _hum23Q3, MetodicalTwo = _met23Q3, ReferenceTwo = _ref23Q3, ArtTwo = _arts23Q3, PrentedTwo = _prt23Q3, ElectronicTwo = _el23Q3, PeriodichTwo = _per23Q3, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = title23Q3, TotalCountTwo = totCount23Q3, TotalCostTwo = cost23Q3, NaturalSocialTwo = nat23Q3, SocialTwo = soc23Q3, HumanitarianTwo = hum23Q3, MetodicalTwo = met23Q3, ReferenceTwo = refs23Q3, ArtTwo = art23Q3, PrentedTwo = prt23Q3, ElectronicTwo = el23Q3, PeriodichTwo = per23Q3, NotesTwo = "" });


            //4 кв.
            DataList.Add(new ResultsTwo() { FundMomentTwo = _title23Q4, TotalCountTwo = _count23Q4, TotalCostTwo = _cost23Q4, NaturalSocialTwo = _natural23Q4, SocialTwo = _social23Q4, HumanitarianTwo = _human23Q4, MetodicalTwo = _metodical23Q4, ReferenceTwo = _reference23Q4, ArtTwo = _art23Q4, PrentedTwo = _print23Q4, ElectronicTwo = _electr23Q4, PeriodichTwo = _period23Q4, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = _titl23Q4, TotalCountTwo = _totCount23Q4, TotalCostTwo = _totCost23Q4, NaturalSocialTwo = _nat23Q4, SocialTwo = _soc23Q4, HumanitarianTwo = _hum23Q4, MetodicalTwo = _met23Q4, ReferenceTwo = _ref23Q4, ArtTwo = _arts23Q4, PrentedTwo = _prt23Q4, ElectronicTwo = _el23Q4, PeriodichTwo = _per23Q4, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = title23Q4, TotalCountTwo = totCount23Q4, TotalCostTwo = cost23Q4, NaturalSocialTwo = nat23Q4, SocialTwo = soc23Q4, HumanitarianTwo = hum23Q4, MetodicalTwo = met23Q4, ReferenceTwo = refs23Q4, ArtTwo = art23Q4, PrentedTwo = prt23Q4, ElectronicTwo = el23Q4, PeriodichTwo = per23Q4, NotesTwo = "" });
            //Итоги
            DataList.Add(new ResultsTwo() { FundMomentTwo = title2023, TotalCountTwo = _totalCount2023, TotalCostTwo = _totalCost2023, NaturalSocialTwo = _natural2023, SocialTwo = _social2023, HumanitarianTwo = _human2023, MetodicalTwo = _metodical2023, ReferenceTwo = _reference2023, ArtTwo = _art2023, PrentedTwo = _print2023, ElectronicTwo = _electr2023, PeriodichTwo = _period2023, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = titleDis2023, TotalCountTwo = totCount2023, TotalCostTwo = cost2023, NaturalSocialTwo = nat2023, SocialTwo = soc2023, HumanitarianTwo = hum2023, MetodicalTwo = met2023, ReferenceTwo = refs2023, ArtTwo = art2023, PrentedTwo = prt2023, ElectronicTwo = el2023, PeriodichTwo = per2023, NotesTwo = "" });
            //2024
            DataList.Add(new ResultsTwo() { FundMomentTwo = _title24, TotalCountTwo = _count24, TotalCostTwo = _cost24, NaturalSocialTwo = _natural24, SocialTwo = _social24, HumanitarianTwo = _human24, MetodicalTwo = _metodical24, ReferenceTwo = _reference24, ArtTwo = _art24, PrentedTwo = _print24, ElectronicTwo = _electr24, PeriodichTwo = _period24, NotesTwo = "" });
            //1 кв.
            DataList.Add(new ResultsTwo() { FundMomentTwo = _titl24, TotalCountTwo = _totCount24, TotalCostTwo = _totCost24, NaturalSocialTwo = _nat24, SocialTwo = _soc24, HumanitarianTwo = _hum24, MetodicalTwo = _met24, ReferenceTwo = _ref24, ArtTwo = _arts24, PrentedTwo = _prt24, ElectronicTwo = _el24, PeriodichTwo = _per24, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = title24, TotalCountTwo = totCount24, TotalCostTwo = cost24, NaturalSocialTwo = nat24, SocialTwo = soc24, HumanitarianTwo = hum24, MetodicalTwo = met24, ReferenceTwo = refs24, ArtTwo = art24, PrentedTwo = prt24, ElectronicTwo = el24, PeriodichTwo = per24, NotesTwo = "" });
            //2 кв.
            DataList.Add(new ResultsTwo() { FundMomentTwo = _title24Q2, TotalCountTwo = _count24Q2, TotalCostTwo = _cost24Q2, NaturalSocialTwo = _natural24Q2, SocialTwo = _social24Q2, HumanitarianTwo = _human24Q2, MetodicalTwo = _metodical24Q2, ReferenceTwo = _reference24Q2, ArtTwo = _art24Q2, PrentedTwo = _print24Q2, ElectronicTwo = _electr24Q2, PeriodichTwo = _period24Q2, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = _titl24Q2, TotalCountTwo = _totCount24Q2, TotalCostTwo = _totCost24Q2, NaturalSocialTwo = _nat24Q2, SocialTwo = _soc24Q2, HumanitarianTwo = _hum24Q2, MetodicalTwo = _met24Q2, ReferenceTwo = _ref24Q2, ArtTwo = _arts24Q2, PrentedTwo = _prt24Q2, ElectronicTwo = _el24Q2, PeriodichTwo = _per24Q2, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = title24Q2, TotalCountTwo = totCount24Q2, TotalCostTwo = cost24Q2, NaturalSocialTwo = nat24Q2, SocialTwo = soc24Q2, HumanitarianTwo = hum24Q2, MetodicalTwo = met24Q2, ReferenceTwo = refs24Q2, ArtTwo = art24Q2, PrentedTwo = prt24Q2, ElectronicTwo = el24Q2, PeriodichTwo = per24Q2, NotesTwo = "" });
            //3 кв.
            DataList.Add(new ResultsTwo() { FundMomentTwo = _title24Q3, TotalCountTwo = _count24Q3, TotalCostTwo = _cost24Q3, NaturalSocialTwo = _natural24Q3, SocialTwo = _social24Q3, HumanitarianTwo = _human24Q3, MetodicalTwo = _metodical24Q3, ReferenceTwo = _reference24Q3, ArtTwo = _art24Q3, PrentedTwo = _print24Q3, ElectronicTwo = _electr24Q3, PeriodichTwo = _period24Q3, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = _titl24Q3, TotalCountTwo = _totCount24Q3, TotalCostTwo = _totCost24Q3, NaturalSocialTwo = _nat24Q3, SocialTwo = _soc24Q3, HumanitarianTwo = _hum24Q3, MetodicalTwo = _met24Q3, ReferenceTwo = _ref24Q3, ArtTwo = _arts24Q3, PrentedTwo = _prt24Q3, ElectronicTwo = _el24Q3, PeriodichTwo = _per24Q3, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = title24Q3, TotalCountTwo = totCount24Q3, TotalCostTwo = cost24Q3, NaturalSocialTwo = nat24Q3, SocialTwo = soc24Q3, HumanitarianTwo = hum24Q3, MetodicalTwo = met24Q3, ReferenceTwo = refs24Q3, ArtTwo = art24Q3, PrentedTwo = prt24Q3, ElectronicTwo = el24Q3, PeriodichTwo = per24Q3, NotesTwo = "" });
            //4 кв.
            DataList.Add(new ResultsTwo() { FundMomentTwo = _title24Q4, TotalCountTwo = _count24Q4, TotalCostTwo = _cost24Q4, NaturalSocialTwo = _natural24Q4, SocialTwo = _social24Q4, HumanitarianTwo = _human24Q4, MetodicalTwo = _metodical24Q4, ReferenceTwo = _reference24Q4, ArtTwo = _art24Q4, PrentedTwo = _print24Q4, ElectronicTwo = _electr24Q4, PeriodichTwo = _period24Q4, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = _titl24Q4, TotalCountTwo = _totCount24Q4, TotalCostTwo = _totCost24Q4, NaturalSocialTwo = _nat24Q4, SocialTwo = _soc24Q4, HumanitarianTwo = _hum24Q4, MetodicalTwo = _met24Q4, ReferenceTwo = _ref24Q4, ArtTwo = _arts24Q4 = 0, PrentedTwo = _prt24Q4, ElectronicTwo = _el24Q4, PeriodichTwo = _per24Q4, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = title24Q4, TotalCountTwo = totCount24Q4, TotalCostTwo = cost24Q4, NaturalSocialTwo = nat24Q4, SocialTwo = soc24Q4, HumanitarianTwo = hum24Q4, MetodicalTwo = met24Q4, ReferenceTwo = refs24Q4, ArtTwo = art24Q4, PrentedTwo = prt24Q4, ElectronicTwo = el24Q4, PeriodichTwo = per24Q4, NotesTwo = "" });                                                                                                                                                                
            //Итоги
            DataList.Add(new ResultsTwo() { FundMomentTwo = title2024, TotalCountTwo = _totalCount2024, TotalCostTwo = _totalCost2024, NaturalSocialTwo = _natural2024, SocialTwo = _social2024, HumanitarianTwo = _human2024, MetodicalTwo = _metodical2024, ReferenceTwo = _reference2024, ArtTwo = _art2024, PrentedTwo = _print2024, ElectronicTwo = _electr2024, PeriodichTwo = _period2024, NotesTwo = "" });
            DataList.Add(new ResultsTwo() { FundMomentTwo = titleDis2024, TotalCountTwo = totCount2024, TotalCostTwo = cost2024, NaturalSocialTwo = nat2024, SocialTwo = soc2024, HumanitarianTwo = hum2024, MetodicalTwo = met2024, ReferenceTwo = refs2024, ArtTwo = art2024, PrentedTwo = prt2024, ElectronicTwo = el2024, PeriodichTwo = per2024, NotesTwo = "" });
            //2025
            DataList.Add(new ResultsTwo() { FundMomentTwo = _title25, TotalCountTwo = _count25, TotalCostTwo = _cost25, NaturalSocialTwo = _natural25, SocialTwo = _social25, HumanitarianTwo = _human25, MetodicalTwo = _metodical25, ReferenceTwo = _reference25, ArtTwo = _art25, PrentedTwo = _print25, ElectronicTwo = _electr25, PeriodichTwo = _period25, NotesTwo = "" });


        }
    }
}
