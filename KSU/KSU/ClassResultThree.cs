using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KSU.ClassResultTwo;

namespace KSU
{
    public class ClassResultThree
    {
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
            // Рассчитываем Поступление за 2018 год 
            var _item = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= _startDate && x.Date <= _endDate);
            string _title = "Поступило за 2018 г.";
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
            DateTime _startDate19 = new DateTime(_year, 1, 1);
            DateTime _endDate19 = new DateTime(_year, 12, 31);
            string BeginningOfTheYear19 = "Состоит на 01.01.2019 г.";
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
            // Рассчитываем Поступление за 2018 год 
            var _item19 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 3 && x.Date >= _startDate && x.Date <= _endDate);
            string _title19 = "Поступило за 2019 г.";
            int _totalCount19 = 0, _natural19 = 0, _social19 = 0, _human19 = 0, _metodical19 = 0, _reference19 = 0, _art19 = 0, _print19 = 0, _electr19 = 0, _period19 = 0;
            double _totalCost19 = 0;
            foreach (var item in _item) { _totalCount19 += item.TotalInstances; _totalCost19 += item.Cost; }
            foreach (var item in _item) //По содержанию
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
            foreach (var item in _item) //По виду
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
            string DisYear2019 = "Выбыло за 2019 г.";
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
            int _year20 = 2020;
            DateTime _startDate20 = new DateTime(_year20, 1, 1);
            DateTime _endDate20 = new DateTime(_year20, 12, 31);
            string BeginningOfTheYear20 = "Состоит на 01.01.2020 г.";
            int _countBeginingYear20 = 0, _costYear20 = 0, _naturalYear20 = 0, _socialYear20 = 0, _humanYear20 = 0, _metodicalYear20 = 0, _referenceYear20 = 0, _artYear20 = 0, _printYear20 = 0, _electrYear20 = 0, _periodYear20 = 0;
            //Подсчеты сколько состоит на начало 2020 года
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
            string _title20 = "Поступило за 2020 г.";
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
            string DisYear2020 = "Выбыло за 2020 г.";
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

            DataList = new List<ResultsThree>();
            //DataList.Add(new ResultsThree() { FundMomentThree = "Состоит на 01.01.2018 г.", TotalCountThree = 42730, TotalCostThree = 0, NaturalSocialThree = 3132, SocialThree = 1525, HumanitarianThree = 29791, MetodicalThree = 10, ReferenceThree = 115, ArtThree = 4663, PrentedThree = 17764, ElectronicThree = 0, PeriodichThree = 0, NotesThree = "" });
        }
    }   
}
