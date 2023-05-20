using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows;
using System.Net.NetworkInformation;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace KSU
{
    public class ClassResultsOne
    {
        public List<Results> DataList { get; }
        /// <summary>
        /// Для подсчетов итогов по 1 корпусу
        /// </summary>
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
            //Поступление 2019
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
            //Поступление 2020
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
            //Выбытие 2020
            int totalCountDis20 = 0, naturalDis20 = 0, socialDis20 = 0, humanDis20 = 0, metodicalDis20 = 0, referenceDis20 = 0, artDis20 = 0, printDis20 = 0, electrDis20 = 0, periodDis20 = 0;
            double totalCostDis20 = 0; //Общая стоимость
            var itemss20 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= startDate20 && x.Date <= endDate20);
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
            //Состоит на 2021
            int _countBeginingYear21 = 0, _costYear21 = 0, _naturalYear21 = 0, _socialYear21 = 0, _humanYear21 = 0, _metodicalYear21 = 0, _referenceYear21 = 0, _artYear21 = 0, _printYear21 = 0, _electrYear21 = 0, _periodYear21 = 0;
            //Подсчеты сколько состоит на начало 2021 года
            _countBeginingYear21 = _countBeginingYear20 + totalCount20 - totalCountDis20;
            _naturalYear21 = _naturalYear20 + natural20 - naturalDis20;
            _socialYear21 = _socialYear20 + social20 - socialDis20;
            _referenceYear21 = _referenceYear20 + reference20 - referenceDis20;
            _humanYear21 = _humanYear20 + human20 - humanDis20;
            _metodicalYear21 = _metodicalYear20 + metodical20 - metodicalDis20;
            _artYear21 = _artYear20 + art20 - artDis20;
            _printYear21 = _printYear20 + print20 - printDis20;
            _electrYear21 = _electrYear20 + electr20 - electrDis20;
            _periodYear21 = _periodYear20 + period20 - periodDis20;
            int year21 = 2021;
            // Диапазон первого квартала
            DateTime January = new DateTime(year21, 1, 1);
            DateTime March = new DateTime(year21, 3, 31);
            // Диапазон второго квартала
            DateTime April = new DateTime(year21, 4, 1);
            DateTime June = new DateTime(year21, 6, 30);
            // Диапазон третьего квартала
            DateTime July = new DateTime(year21, 7, 1);
            DateTime September = new DateTime(year21, 9, 30);
            // Диапазон четвертого квартала
            DateTime October = new DateTime(year21, 10, 1);
            DateTime December = new DateTime(year21, 12, 31);
            // Рассчитываем Выбытие 2021 год за первый квартал
            int totalCountDis21K1 = 0, naturalDis21K1 = 0, socialDis21K1 = 0, humanDis21K1 = 0, metodicalDis21K1 = 0, referenceDis21K1 = 0, artDis21K1 = 0, printDis21K1 = 0, electrDis21K1 = 0, periodDis21K1 = 0; //Общее количество
            double totalCostDis21K1 = 0;
            var itemss21K1 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= January && x.Date <= March);
            foreach (var item in itemss21K1)
            {
                totalCountDis21K1 += item.TotalNumber;
                totalCostDis21K1 += item.Cost;
            }
            foreach (var item in itemss21K1) //По содержанию
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { naturalDis21K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки                    
                    { socialDis21K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки                    
                    { humanDis21K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodicalDis21K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература                    
                    { referenceDis21K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { artDis21K1 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in itemss21K1) // По виду
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатные
                    { printDis21K1 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронные
                    { electrDis21K1 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree) //Периодические издания
                    { periodDis21K1 += (int)itemView.Counts; }
                }
            }
            int _countBeginingYear21K2 = 0, _costYear21K2 = 0, _naturalYear21K2 = 0, _socialYear21K2 = 0, _humanYear21K2 = 0, _metodicalYear21K2 = 0, _referenceYear21K2 = 0, _artYear21K2 = 0, _printYear21K2 = 0, _electrYear21K2 = 0, _periodYear21K2 = 0;
            //Подсчеты сколько состоит на начало 2021 года
            _countBeginingYear21K2 = _countBeginingYear21 - totalCountDis21K1;
            _naturalYear21K2 = _naturalYear21 - naturalDis21K1;
            _socialYear21K2 = _socialYear21 - socialDis21K1;
            _referenceYear21K2 = _referenceYear21 - referenceDis21K1;
            _humanYear21K2 = _humanYear21 - humanDis21K1;
            _metodicalYear21K2 = _metodicalYear21  - metodicalDis21K1;
            _artYear21K2 = _artYear21 - artDis21K1;
            _printYear21K2 = _printYear21  - printDis21K1;
            _electrYear21K2 = _electrYear21  - electrDis21K1;
            _periodYear21K2 = _periodYear21  - periodDis21K1;
            //Поступило за 2 кв.2021
            var items2021Q2 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= April && x.Date <= June);
            double totalCostQ2 = 0;
            int totalCountQ2 = 0, naturalQ2 = 0, socialQ2 = 0, humanQ2 = 0, metodicalQ2 = 0, referenceQ2 = 0, artQ2 = 0, printQ2 = 0, electrQ2 = 0, periodQ2 = 0;
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
            //Состоит на 3 кв.2021 и на 4 кв.2021
            int _countBeginingYear21K3 = 0, _costYear21K3 = 0, _naturalYear21K3 = 0, _socialYear21K3 = 0, _humanYear21K3 = 0, _metodicalYear21K3 = 0, _referenceYear21K3 = 0, _artYear21K3 = 0, _printYear21K3 = 0, _electrYear21K3 = 0, _periodYear21K3 = 0;
            //Подсчеты сколько состоит на начало 2021 года
            _countBeginingYear21K3 = _countBeginingYear21K2 + totalCountQ2;
            _naturalYear21K3 = _naturalYear21K2 + naturalQ2;
            _socialYear21K3 = _socialYear21K2 + socialQ2;
            _referenceYear21K3 = _referenceYear21K2 + referenceQ2;
            _humanYear21K3 = _humanYear21K2 + humanQ2;
            _metodicalYear21K3 = _metodicalYear21K2 + metodicalQ2;
            _artYear21K3 = _artYear21K2 + artQ2;
            _printYear21K3 = _printYear21K2 + printQ2;
            _electrYear21K3 = _electrYear21K2 + electrQ2;
            _periodYear21K3 = _periodYear21K2 + periodQ2;
            //Поступление 4 кв.
            var items2021Q4 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= October && x.Date <= December);
            double totalCostQ4 = 0;
            int totalCountQ4 = 0, naturalQ4 = 0, socialQ4 = 0, humanQ4 = 0, metodicalQ4 = 0, referenceQ4 = 0, artQ4 = 0, printQ4 = 0, electrQ4 = 0, periodQ4 = 0;
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
            //Выбытие 4 кв.
            int totalCountDis21K4 = 0, naturalDis21K4 = 0, socialDis21K4 = 0, humanDis21K4 = 0, metodicalDis21K4 = 0, referenceDis21K4 = 0, artDis21K4 = 0, printDis21K4 = 0, electrDis21K4 = 0, periodDis21K4 = 0; //Общее количество
            double totalCostDis21K4 = 0;
            var itemss21K4 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= October && x.Date <= December);
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
            DateTime startDate2021 = new DateTime(year20, 1, 1);
            DateTime endDate2021 = new DateTime(year20, 12, 31);
            var Items2021 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= startDate2021 && x.Date <= endDate2021);
            int totalCount2021 = 0, natural2021 = 0, social2021 = 0, human2021 = 0, metodical2021 = 0, reference2021 = 0, art2021 = 0, print2021 = 0, electr2021 = 0, period2021 = 0;
            double totalCost2021 = 0;
            foreach (var item in Items2021)
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
            var itemss2021 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= startDate2021 && x.Date <= endDate2021);
            foreach (var item in itemss2021)
            {
                totalCountDis2021 = totalCountDis21K1 + totalCountDis21K4;
                totalCostDis2021 = totalCostDis21K1 + totalCostDis21K4;
                naturalDis2021 = naturalDis21K1 + naturalDis21K4;
                socialDis2021 = socialDis21K1 + socialDis21K4;
                humanDis2021 = humanDis21K1 + humanDis21K4;
                metodicalDis2021 = metodicalDis21K1 + metodicalDis21K4;
                referenceDis2021 = referenceDis21K1 + referenceDis21K4;
                artDis2021 = artDis21K1 + artDis21K4;
                printDis2021 = printDis21K1 + printDis21K4;
                electrDis2021 = electrDis21K1 + electrDis21K4;
                periodDis2021 = periodDis21K1 + periodDis21K4;
            }
            //Состоит на 2022
            int _countBeginingYear22 = 0, _costYear22 = 0, _naturalYear22 = 0, _socialYear22 = 0, _humanYear22 = 0, _metodicalYear22 = 0, _referenceYear22 = 0, _artYear22 = 0, _printYear22 = 0, _electrYear22 = 0, _periodYear22 = 0;
            //Подсчеты сколько состоит на начало 2021 года
            _countBeginingYear22 = _countBeginingYear21K3 + totalCountQ4 - totalCountDis21K4;
            _naturalYear22 = _naturalYear21K3 + naturalQ4 - naturalDis21K4;
            _socialYear22 = _socialYear21K3 + socialQ4 - socialDis21K4;
            _referenceYear22 = _referenceYear21K3 + referenceQ4 - referenceDis21K4;
            _humanYear22 = _humanYear21K3 + humanQ4 - humanDis21K4;
            _metodicalYear22 = _metodicalYear21K3 + metodicalQ4 - metodicalDis21K4;
            _artYear22 = _artYear21K3 + artQ4 - artDis21K4;
            _printYear22 = _printYear21K3 + printQ4 - printDis21K4;
            _electrYear22 = _electrYear21K3 + electrQ4 - electrDis21K4;
            _periodYear22 = _periodYear21K3 + periodQ4 - periodDis21K4;
            //Выбыло 2022
            int year22 = 2022;
            // Диапазон первого квартала
            DateTime Januarys = new DateTime(year22, 1, 1);
            DateTime Marchs = new DateTime(year22, 3, 31);
            // Диапазон второго квартала
            DateTime Aprils = new DateTime(year22, 4, 1);
            DateTime Junes = new DateTime(year22, 6, 30);
            int totalCountDis22K1 = 0, naturalDis22K1 = 0, socialDis22K1 = 0, humanDis22K1 = 0, metodicalDis22K1 = 0, referenceDis22K1 = 0, artDis22K1 = 0, printDis22K1 = 0, electrDis22K1 = 0, periodDis22K1 = 0;
            double totalCostDis22K1 = 0;
            var itemss22K1 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= Januarys && x.Date <= Marchs);
            foreach (var item in itemss22K1)
            {
                totalCountDis22K1 += item.TotalNumber;
                totalCostDis22K1 += item.Cost;
            }
            foreach (var item in itemss22K1) //По содержанию
            {
                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemContent in contentsDisposals)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { naturalDis22K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки                    
                    { socialDis22K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки                    
                    { humanDis22K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodicalDis22K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература                    
                    { referenceDis22K1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { artDis22K1 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in itemss22K1) // По виду
            {
                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
                foreach (var itemView in viewsDisposals)
                {
                    if (itemView.IdViews == viewId) //Печатные
                    { printDis22K1 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронные
                    { electrDis22K1 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree) //Периодические издания
                    { periodDis22K1 += (int)itemView.Counts; }
                }
            }
            //Состоит на 2 кв.
            int _countBeginingYear22K2 = 0, _costYear22K2 = 0, _naturalYear22K2 = 0, _socialYear22K2 = 0, _humanYear22K2 = 0, _metodicalYear22K2 = 0, _referenceYear22K2 = 0, _artYear22K2 = 0, _printYear22K2 = 0, _electrYear22K2 = 0, _periodYear22K2 = 0;
            //Подсчеты сколько состоит на 2 кв. 2022 года
            _countBeginingYear22K2 = _countBeginingYear22 - totalCountDis22K1;
            _naturalYear22K2 = _naturalYear22 - naturalDis22K1;
            _socialYear22K2 = _socialYear22 - socialDis22K1;
            _referenceYear22K2 = _referenceYear22 - referenceDis22K1;
            _humanYear22K2 = _humanYear22 - humanDis22K1;
            _metodicalYear22K2 = _metodicalYear22 - metodicalDis22K1;
            _artYear22K2 = _artYear22 - artDis22K1;
            _printYear22K2 = _printYear22 - printDis22K1;
            _electrYear22K2 = _electrYear22 - electrDis22K1;
            _periodYear22K2 = _periodYear22 - periodDis22K1;
            //Поступление 2 кв.
            var items2022Q2 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= Aprils && x.Date <= Junes);
            int totalCountQ22 = 0, naturalQ22 = 0, socialQ22 = 0, humanQ22 = 0, metodicalQ22 = 0, referenceQ22 = 0, artQ22 = 0, printQ22 = 0, electrQ22 = 0, periodQ22 = 0;
            double totalCostQ22 = 0;
            foreach (var item in items2022Q2) { totalCountQ22 += item.TotalInstances; totalCostQ22 += item.Cost; }
            foreach (var item in items2022Q2) //По содержанию
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { naturalQ22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { socialQ22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { humanQ22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodicalQ22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { referenceQ22 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { artQ22 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in items2022Q2) //По виду
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { printQ22 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { electrQ22 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { periodQ22 += (int)itemView.Counts; }
                }
            }
            //Состоит на 2023
            int _countBeginingYear23 = 0, _costYear23 = 0, _naturalYear23 = 0, _socialYear23 = 0, _humanYear23 = 0, _metodicalYear23 = 0, _referenceYear23 = 0, _artYear23 = 0, _printYear23 = 0, _electrYear23 = 0, _periodYear23 = 0;
            //Подсчеты сколько состоит на 2 кв. 2022 года
            _countBeginingYear23 = _countBeginingYear22K2 + totalCountQ22;
            _naturalYear23 = _naturalYear22K2 + naturalQ22;
            _socialYear23 = _socialYear22K2 + socialQ22;
            _referenceYear23 = _referenceYear22K2 + referenceQ22;
            _humanYear23 = _humanYear22K2 + humanQ22;
            _metodicalYear23 = _metodicalYear22K2 + metodicalQ22;
            _artYear23 = _artYear22K2 + artQ22;
            _printYear23 = _printYear22K2 + printQ22;
            _electrYear23 = _electrYear22K2 + electrQ22;
            _periodYear23 = _periodYear22K2 + periodQ22;
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
            // Рассчитываем Поступление 2023 год за 1 квартал
            var items2023Q1 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= Jans && x.Date <= Mars);
            int totalCount23Q1 = 0, natural23Q1 = 0, social23Q1 = 0, human23Q1 = 0, metodical23Q1 = 0, reference23Q1 = 0, art23Q1 = 0, print23Q1 = 0, electr23Q1 = 0, period23Q1 = 0;
            double totalCost23Q1 = 0;
            foreach (var item in items2023Q1) { totalCount23Q1 += item.TotalInstances; totalCost23Q1 += item.Cost; }
            foreach (var item in items2023Q1) //По содержанию
            {
                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemContent in contentsReceipts)
                {
                    if (itemContent.IdContents == contentId) // естественные науки
                    { natural23Q1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdTwo) // технические науки
                    { social23Q1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
                    { human23Q1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFour) //Методическая литература
                    { metodical23Q1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdFive) //Справочная литература
                    { reference23Q1 += (int)itemContent.Counts; }
                    if (itemContent.IdContents == contentIdSix) //Художественная литература
                    { art23Q1 += (int)itemContent.Counts; }
                }
            }
            foreach (var item in items2023Q1) //По виду
            {
                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
                foreach (var itemView in viewsReceipts)
                {
                    if (itemView.IdViews == viewId) //Печатный
                    { print23Q1 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdTwo) //Электронный
                    { electr23Q1 += (int)itemView.Counts; }
                    if (itemView.IdViews == viewIdThree)//Периодические издания
                    { period23Q1 += (int)itemView.Counts; }
                }
            }
            //Состоит 2 кв. 2023
            int _countBeginingYear23Q2 = 0, _costYear23Q2 = 0, _naturalYear23Q2 = 0, _socialYear23Q2 = 0, _humanYear23Q2 = 0, _metodicalYear23Q2 = 0, _referenceYear23Q2 = 0, _artYear23Q2 = 0, _printYear23Q2 = 0, _electrYear23Q2 = 0, _periodYear23Q2 = 0;
            //Подсчеты сколько состоит на 2 кв. 2022 года
            _countBeginingYear23Q2 = _countBeginingYear23 + totalCount23Q1;
            _naturalYear23Q2 = _naturalYear23 + natural23Q1;
            _socialYear23Q2 = _socialYear23 + social23Q1;
            _referenceYear23Q2 = _referenceYear23 + reference23Q1;
            _humanYear23Q2 = _humanYear23 + human23Q1;
            _metodicalYear23Q2 = _metodicalYear23 + metodical23Q1;
            _artYear23Q2 = _artYear23 + art23Q1;
            _printYear23Q2 = _printYear23 + print23Q1;
            _electrYear23Q2 = _electrYear23 + electr23Q1;
            _periodYear23Q2 = _periodYear23 + period23Q1;
            //Поступление 2 кв. 2023

            //Выбытие 2 кв. 2023

            //Состоит на 3 кв. 2023

            //Поступление 3 кв. 2023

            //Выбытие 3 кв. 2023

            //Состоит на 4 кв. 2023

            //Поступление 4 кв. 2023

            //Выбытие 4 кв. 2023

            //Итого поступило

            //Выбыло

            //Состоит 01.01.2024

            

            


            // В конструкторе заполняем список данных
            DataList = new List<Results>();           
            DataList.Add(new Results() { FundMomentOne = "Состоит на 01.01.2018 г.", TotalCountOne = 42655, TotalCostOne = 0, NaturalSocialOne = 6281, SocialOne = 3304, HumanitarianOne = 26145, MetodicalOne = 21, ReferenceOne = 218, ArtOne = 6686, PrentedOne = 42655, ElectronicOne = 0, PeriodichOne = 0, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Поступило за 2018 г.", TotalCountOne = totalCount, TotalCostOne = totalCost, NaturalSocialOne = natural, SocialOne = social, HumanitarianOne = human, MetodicalOne = metodical, ReferenceOne = reference, ArtOne = art, PrentedOne = print, ElectronicOne = electr, PeriodichOne = period, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Состоит на 01.01.2019 г.", TotalCountOne = _countBeginingYear19, TotalCostOne = _costYear19, NaturalSocialOne = _naturalYear19, SocialOne = _socialYear19, HumanitarianOne = _humanYear19, MetodicalOne = _metodicalYear19, ReferenceOne = _referenceYear19, ArtOne = _artYear19, PrentedOne = _printYear19, ElectronicOne = _electrYear19, PeriodichOne = _periodYear19, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Поступило за 2019 г.", TotalCountOne = totalCount19, TotalCostOne = totalCost19, NaturalSocialOne = natural19, SocialOne = social19, HumanitarianOne = human19, MetodicalOne = metodical19, ReferenceOne = reference19, ArtOne = art19, PrentedOne = print19, ElectronicOne = _electrYear19, PeriodichOne = period19, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Выбыло за 2019 г.", TotalCountOne = totalCountDis, TotalCostOne = totalCostDis, NaturalSocialOne = naturalDis, SocialOne = socialDis, HumanitarianOne = humanDis, MetodicalOne = metodicalDis, ReferenceOne = referenceDis, ArtOne = artDis, PrentedOne = printDis, ElectronicOne = electrDis, PeriodichOne = periodDis, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Состоит на 01.01.2020 г.", TotalCountOne = _countBeginingYear20, TotalCostOne = _costYear20, NaturalSocialOne = _naturalYear20, SocialOne = _socialYear20, HumanitarianOne = _humanYear20, MetodicalOne = _metodicalYear20, ReferenceOne = _referenceYear20, ArtOne = _artYear20, PrentedOne = _printYear20, ElectronicOne = _electrYear20, PeriodichOne = _periodYear20, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Поступило за 2020 г.", TotalCountOne = totalCount20, TotalCostOne = totalCost20, NaturalSocialOne = natural20, SocialOne = social20, HumanitarianOne = human20, MetodicalOne = metodical20, ReferenceOne = reference20, ArtOne = art20, PrentedOne = print20, ElectronicOne = _electrYear20, PeriodichOne = period20, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Выбыло за 2020 г.", TotalCountOne = totalCountDis20, TotalCostOne = totalCostDis20, NaturalSocialOne = naturalDis20, SocialOne = socialDis20, HumanitarianOne = humanDis20, MetodicalOne = metodicalDis20, ReferenceOne = referenceDis20, ArtOne = artDis20, PrentedOne = printDis20, ElectronicOne = electrDis20, PeriodichOne = periodDis20, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Состоит на 01.01.2021 г.", TotalCountOne = _countBeginingYear21, TotalCostOne = _costYear21, NaturalSocialOne = _naturalYear21, SocialOne = _socialYear21, HumanitarianOne = _humanYear21, MetodicalOne = _metodicalYear21, ReferenceOne = _referenceYear21, ArtOne = _artYear21, PrentedOne = _printYear21, ElectronicOne = _electrYear21, PeriodichOne = _periodYear21, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Выбыло за 1 кв. 2021 г.", TotalCountOne = totalCountDis21K1, TotalCostOne = totalCostDis21K1, NaturalSocialOne = naturalDis21K1, SocialOne = socialDis21K1, HumanitarianOne = humanDis21K1, MetodicalOne = metodicalDis21K1, ReferenceOne = referenceDis21K1, ArtOne = artDis21K1, PrentedOne = printDis21K1, ElectronicOne = electrDis21K1, PeriodichOne = periodDis21K1, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Состоит на 2 кв. 2021 г.", TotalCountOne = _countBeginingYear21K2, TotalCostOne = _costYear21K2, NaturalSocialOne = _naturalYear21K2, SocialOne = _socialYear21K2, HumanitarianOne = _humanYear21K2, MetodicalOne = _metodicalYear21K2, ReferenceOne = _referenceYear21K2, ArtOne = _artYear21K2, PrentedOne = _printYear21K2, ElectronicOne = _electrYear21K2, PeriodichOne = _periodYear21K2, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Поступило за 2 кв. 2021 г.", TotalCountOne = totalCountQ2, TotalCostOne = totalCostQ2, NaturalSocialOne = naturalQ2, SocialOne = socialQ2, HumanitarianOne = humanQ2, MetodicalOne = metodicalQ2, ReferenceOne = referenceQ2, ArtOne = artQ2, PrentedOne = printQ2, ElectronicOne = electrQ2, PeriodichOne = periodQ2, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Состоит на 3 кв. 2021 г.", TotalCountOne = _countBeginingYear21K3, TotalCostOne = _costYear21K3, NaturalSocialOne = _naturalYear21K3, SocialOne = _socialYear21K3, HumanitarianOne = _humanYear21K3, MetodicalOne = _metodicalYear21K3, ReferenceOne = _referenceYear21K3, ArtOne = _artYear21K3, PrentedOne = _printYear21K3, ElectronicOne = _electrYear21K3, PeriodichOne = _periodYear21K3, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Состоит на 4 кв. 2021 г.", TotalCountOne = _countBeginingYear21K3, TotalCostOne = _costYear21K3, NaturalSocialOne = _naturalYear21K3, SocialOne = _socialYear21K3, HumanitarianOne = _humanYear21K3, MetodicalOne = _metodicalYear21K3, ReferenceOne = _referenceYear21K3, ArtOne = _artYear21K3, PrentedOne = _printYear21K3, ElectronicOne = _electrYear21K3, PeriodichOne = _periodYear21K3, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Поступило за 4 кв. 2021 г.", TotalCountOne = totalCountQ4, TotalCostOne = totalCostQ4, NaturalSocialOne = naturalQ4, SocialOne = socialQ4, HumanitarianOne = humanQ4, MetodicalOne = metodicalQ4, ReferenceOne = referenceQ4, ArtOne = artQ4, PrentedOne = printQ4, ElectronicOne = electrQ4, PeriodichOne = periodQ4, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Выбыло за 4 кв. 2021 г.", TotalCountOne = totalCountDis21K4, TotalCostOne = totalCostDis21K4, NaturalSocialOne = naturalDis21K4, SocialOne = socialDis21K4, HumanitarianOne = humanDis21K4, MetodicalOne = metodicalDis21K4, ReferenceOne = referenceDis21K4, ArtOne = artDis22K1, PrentedOne = printDis21K4, ElectronicOne = electrDis22K1, PeriodichOne = periodDis21K4, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Итого поступило за год", TotalCountOne = totalCount2021, TotalCostOne = totalCost2021, NaturalSocialOne = natural2021, SocialOne = social2021, HumanitarianOne = human2021, MetodicalOne = metodical2021, ReferenceOne = reference2021, ArtOne = art2021, PrentedOne = print2021, ElectronicOne = electr2021, PeriodichOne = period2021, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Выбыло", TotalCountOne = totalCountDis2021, TotalCostOne = totalCostDis2021, NaturalSocialOne = naturalDis2021, SocialOne = socialDis2021, HumanitarianOne = humanDis2021, MetodicalOne = metodicalDis2021, ReferenceOne = referenceDis2021, ArtOne = artDis2021, PrentedOne = printDis2021, ElectronicOne = electrDis2021, PeriodichOne = periodDis2021, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Состоит на 01.01.2022 г.", TotalCountOne = _countBeginingYear22, TotalCostOne = _costYear22, NaturalSocialOne = _naturalYear22, SocialOne = _socialYear22, HumanitarianOne = _humanYear22, MetodicalOne = _metodicalYear22, ReferenceOne = _referenceYear22, ArtOne = _artYear22, PrentedOne = _printYear22, ElectronicOne = _electrYear22, PeriodichOne = _periodYear22, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Выбыло за 1 кв. 2021 г.", TotalCountOne = totalCountDis22K1, TotalCostOne = totalCostDis22K1, NaturalSocialOne = naturalDis22K1, SocialOne = socialDis22K1, HumanitarianOne = humanDis22K1, MetodicalOne = metodicalDis22K1, ReferenceOne = referenceDis22K1, ArtOne = artDis22K1, PrentedOne = printDis22K1, ElectronicOne = electrDis22K1, PeriodichOne = periodDis22K1, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Состоит на 2 кв. 2022 г.", TotalCountOne = _countBeginingYear22K2, TotalCostOne = _costYear22K2, NaturalSocialOne = _naturalYear22K2, SocialOne = _socialYear22K2, HumanitarianOne = _humanYear22K2, MetodicalOne = _metodicalYear22K2, ReferenceOne = _referenceYear22K2, ArtOne = _artYear22K2, PrentedOne = _printYear22K2, ElectronicOne = _electrYear22K2, PeriodichOne = _periodYear22K2, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Поступило за 2 кв. 2022 г.", TotalCountOne = totalCountQ22, TotalCostOne = totalCostQ22, NaturalSocialOne = naturalQ22, SocialOne = socialQ22, HumanitarianOne = humanQ22, MetodicalOne = metodicalQ22, ReferenceOne = referenceQ22, ArtOne = artQ22, PrentedOne = printQ22, ElectronicOne = electrQ22, PeriodichOne = periodQ22, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Состоит на 01.01.2023 г.", TotalCountOne = _countBeginingYear23, TotalCostOne = _costYear23, NaturalSocialOne = _naturalYear23, SocialOne = _socialYear23, HumanitarianOne = _humanYear23, MetodicalOne = _metodicalYear23, ReferenceOne = _referenceYear23, ArtOne = _artYear23, PrentedOne = _printYear23, ElectronicOne = _electrYear23, PeriodichOne = _periodYear23, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Поступило за 1 кв. 2023 г.", TotalCountOne = totalCount23Q1, TotalCostOne = totalCost23Q1, NaturalSocialOne = natural23Q1, SocialOne = social23Q1, HumanitarianOne = human23Q1, MetodicalOne = metodical23Q1, ReferenceOne = reference23Q1, ArtOne = art23Q1, PrentedOne = print23Q1, ElectronicOne = electr23Q1, PeriodichOne = period23Q1, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = "Состоит на 2 кв. 2023 г.", TotalCountOne = _countBeginingYear23Q2, TotalCostOne = _costYear23Q2, NaturalSocialOne = _naturalYear23Q2, SocialOne = _socialYear23Q2, HumanitarianOne = _humanYear23Q2, MetodicalOne = _metodicalYear23Q2, ReferenceOne = _referenceYear23Q2, ArtOne = _artYear23Q2, PrentedOne = _printYear23Q2, ElectronicOne = _electrYear23Q2, PeriodichOne = _periodYear23Q2, NotesOne = "" });
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
