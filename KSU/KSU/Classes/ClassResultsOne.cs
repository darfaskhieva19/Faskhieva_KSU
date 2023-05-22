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
using System.Windows.Documents;
using static KSU.ClassTotalResults;

namespace KSU
{
    public class ClassResultsOne
    {
        public List<Results> DataList { get; }

        /// <summary>
        /// Проверяем наличие данных в других таблицах
        /// </summary>
        /// <returns></returns>
        //private bool AreOtherTablesPopulated()
        //{            
        //    if (dgReceipt.Items.Count > 0 && dgDisposals.Items.Count > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

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
            int _count23Q3 = _countBeginingYear23Q2 + _totCount23Q2 - totCount23Q2, _natural23Q3 = _naturalYear23Q2 + _nat23Q2 - nat23Q2, _social23Q3 = _socialYear23Q2 + _soc23Q2 - soc23Q2, _human23Q3 = _humanYear23Q2 + _hum23Q2 - hum23Q2, _metodical23Q3 = _metodicalYear23Q2 + _met23Q2 - met23Q2, _reference23Q3 = _metodicalYear23Q2 + _ref23Q2 - refs23Q2, _art23Q3 = _artYear23Q2 + _arts23Q2 - art23Q2, _print23Q3 = _printYear23Q2 + _prt23Q2 - prt23Q2, _electr23Q3 = _electrYear23Q2 + _el23Q2 - el23Q2, _period23Q3 = _periodYear23Q2 + _per23Q2 - per23Q2;
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
                _totalCount2023 = totalCount23Q1 + _totCount23Q2 + _totCount23Q3 + _totCount23Q4;
                _totalCost2023 = totalCost23Q1 + _totCost23Q2 + _totCost23Q3 + _totCost23Q4;
                _natural2023 = natural23Q1 + _nat23Q2 + _nat23Q3 + _nat23Q4;
                _social2023 = social23Q1 + _soc23Q2 + _soc23Q3 + _soc23Q4;
                _human2023 = human23Q1 + _hum23Q2 + _hum23Q3 + _hum23Q4;
                _metodical2023 = metodical23Q1 + _met23Q2 + _met23Q3 + _met23Q4;
                _reference2023 = reference23Q1 + _ref23Q2 + _ref23Q3 + _ref23Q4;
                _art2023 = art23Q1 + _arts23Q2 + _arts23Q3 + _arts23Q4;
                _print2023 = print23Q1 + _prt23Q2 + _prt23Q3 + _prt23Q4;
                _electr2023 = electr23Q1 + _el23Q2 + _el23Q3 + _el23Q4;
                _period2023 = period23Q1 + _per23Q2 + _per23Q3 + _per23Q4;
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
            string _titl24Q4 = "Поступило за 4 кв. " + year23 + " г.";
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

            //2 кв.
            DataList.Add(new Results() { FundMomentOne = _titl23Q2, TotalCountOne = _totCount23Q2, TotalCostOne = _totCost23Q2, NaturalSocialOne = _nat23Q2, SocialOne = _soc23Q2, HumanitarianOne = _hum23Q2, MetodicalOne = _met23Q2, ReferenceOne = _ref23Q2, ArtOne = _arts23Q2, PrentedOne = _prt23Q2, ElectronicOne = _el23Q2, PeriodichOne = _per23Q2, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = title23Q2, TotalCountOne = totCount23Q2, TotalCostOne = cost23Q2, NaturalSocialOne = nat23Q2, SocialOne = soc23Q2, HumanitarianOne = hum23Q2, MetodicalOne = met23Q2, ReferenceOne = refs23Q2, ArtOne = art23Q2, PrentedOne = prt23Q2, ElectronicOne = el23Q2, PeriodichOne = per23Q2, NotesOne = "" });
            //3 кв.
            DataList.Add(new Results() { FundMomentOne = _title23Q3, TotalCountOne = _count23Q3, TotalCostOne = _cost23Q3, NaturalSocialOne = _natural23Q3, SocialOne = _social23Q3, HumanitarianOne = _human23Q3, MetodicalOne = _metodical23Q3, ReferenceOne = _reference23Q3, ArtOne = _art23Q3, PrentedOne = _print23Q3, ElectronicOne = _electr23Q3, PeriodichOne = _period23Q3, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = _titl23Q3, TotalCountOne = _totCount23Q3, TotalCostOne = _totCost23Q3, NaturalSocialOne = _nat23Q3, SocialOne = _soc23Q3, HumanitarianOne = _hum23Q3, MetodicalOne = _met23Q3, ReferenceOne = _ref23Q3, ArtOne = _arts23Q3, PrentedOne = _prt23Q3, ElectronicOne = _el23Q3, PeriodichOne = _per23Q3, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = title23Q3, TotalCountOne = totCount23Q3, TotalCostOne = cost23Q3, NaturalSocialOne = nat23Q3, SocialOne = soc23Q3, HumanitarianOne = hum23Q3, MetodicalOne = met23Q3, ReferenceOne = refs23Q3, ArtOne = art23Q3, PrentedOne = prt23Q3, ElectronicOne = el23Q3, PeriodichOne = per23Q3, NotesOne = "" });
            //4 кв.
            DataList.Add(new Results() { FundMomentOne = _title23Q4, TotalCountOne = _count23Q4, TotalCostOne = _cost23Q4, NaturalSocialOne = _natural23Q4, SocialOne = _social23Q4, HumanitarianOne = _human23Q4, MetodicalOne = _metodical23Q4, ReferenceOne = _reference23Q4, ArtOne = _art23Q4, PrentedOne = _print23Q4, ElectronicOne = _electr23Q4, PeriodichOne = _period23Q4, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = _titl23Q4, TotalCountOne = _totCount23Q4, TotalCostOne = _totCost23Q4, NaturalSocialOne = _nat23Q4, SocialOne = _soc23Q4, HumanitarianOne = _hum23Q4, MetodicalOne = _met23Q4, ReferenceOne = _ref23Q4, ArtOne = _arts23Q4, PrentedOne = _prt23Q4, ElectronicOne = _el23Q4, PeriodichOne = _per23Q4, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = title23Q4, TotalCountOne = totCount23Q4, TotalCostOne = cost23Q4, NaturalSocialOne = nat23Q4, SocialOne = soc23Q4, HumanitarianOne = hum23Q4, MetodicalOne = met23Q4, ReferenceOne = refs23Q4, ArtOne = art23Q4, PrentedOne = prt23Q4, ElectronicOne = el23Q4, PeriodichOne = per23Q4, NotesOne = "" });
            //Итоги
            DataList.Add(new Results() { FundMomentOne = title2023, TotalCountOne = _totalCount2023, TotalCostOne = _totalCost2023, NaturalSocialOne = _natural2023, SocialOne = _social2023, HumanitarianOne = _human2023, MetodicalOne = _metodical2023, ReferenceOne = _reference2023, ArtOne = _art2023, PrentedOne = _print2023, ElectronicOne = _electr2023, PeriodichOne = _period2023, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = titleDis2023, TotalCountOne = totCount2023, TotalCostOne = cost2023, NaturalSocialOne = nat2023, SocialOne = soc2023, HumanitarianOne = hum2023, MetodicalOne = met2023, ReferenceOne = refs2023, ArtOne = art2023, PrentedOne = prt2023, ElectronicOne = el2023, PeriodichOne = per2023, NotesOne = "" });
            //2024
            DataList.Add(new Results() { FundMomentOne = _title24, TotalCountOne = _count24, TotalCostOne = _cost24, NaturalSocialOne = _natural24, SocialOne = _social24, HumanitarianOne = _human24, MetodicalOne = _metodical24, ReferenceOne = _reference24, ArtOne = _art24, PrentedOne = _print24, ElectronicOne = _electr24, PeriodichOne = _period24, NotesOne = "" });
            //1 кв.
            DataList.Add(new Results() { FundMomentOne = _titl24, TotalCountOne = _totCount24, TotalCostOne = _totCost24, NaturalSocialOne = _nat24, SocialOne = _soc24, HumanitarianOne = _hum24, MetodicalOne = _met24, ReferenceOne = _ref24, ArtOne = _art24, PrentedOne = _prt24, ElectronicOne = _el24, PeriodichOne = _per24, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = title24, TotalCountOne = totCount24, TotalCostOne = cost24, NaturalSocialOne = nat24, SocialOne = soc24, HumanitarianOne = hum24, MetodicalOne = met24, ReferenceOne = refs24, ArtOne = art24, PrentedOne = prt24, ElectronicOne = el24, PeriodichOne = per24, NotesOne = "" });
            //2 кв.
            DataList.Add(new Results() { FundMomentOne = _title24Q2, TotalCountOne = _count24Q2, TotalCostOne = _cost24Q2, NaturalSocialOne = _natural24Q2, SocialOne = _social24Q2, HumanitarianOne = _human24Q2, MetodicalOne = _metodical24Q2, ReferenceOne = _reference24Q2, ArtOne = _art24Q2, PrentedOne = _print24Q2, ElectronicOne = _electr24Q2, PeriodichOne = _period24Q2, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = _titl24Q2, TotalCountOne = _totCount24Q2, TotalCostOne = _totCost24Q2, NaturalSocialOne = _nat24Q2, SocialOne = _soc24Q2, HumanitarianOne = _hum24Q2, MetodicalOne = _met24Q2, ReferenceOne = _ref24Q2, ArtOne = _arts24Q2, PrentedOne = _prt24Q2, ElectronicOne = _el24Q2, PeriodichOne = _per24Q2, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = title24Q2, TotalCountOne = totCount24Q2, TotalCostOne = cost24Q2, NaturalSocialOne = nat24Q2, SocialOne = soc24Q2, HumanitarianOne = hum24Q2, MetodicalOne = met24Q2, ReferenceOne = refs24Q2, ArtOne = art24Q2, PrentedOne = prt24Q2, ElectronicOne = el24Q2, PeriodichOne = per24Q2, NotesOne = "" });
            //3 кв.
            DataList.Add(new Results() { FundMomentOne = _title24Q3, TotalCountOne = _count24Q3, TotalCostOne = _cost24Q3, NaturalSocialOne = _natural24Q3, SocialOne = _social24Q3, HumanitarianOne = _human24Q3, MetodicalOne = _metodical24Q3, ReferenceOne = _reference24Q3, ArtOne = _art24Q3, PrentedOne = _print24Q3, ElectronicOne = _electr24Q3, PeriodichOne = _period24Q3, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = _titl24Q3, TotalCountOne = _totCount24Q3, TotalCostOne = _totCost24Q3, NaturalSocialOne = _nat24Q3, SocialOne = _soc24Q3, HumanitarianOne = _hum24Q3, MetodicalOne = _met24Q3, ReferenceOne = _ref24Q3, ArtOne = _arts24Q3, PrentedOne = _prt24Q3, ElectronicOne = _el24Q3, PeriodichOne = _per24Q3, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = title24Q3, TotalCountOne = totCount24Q3, TotalCostOne = cost24Q3, NaturalSocialOne = nat24Q3, SocialOne = soc24Q3, HumanitarianOne = hum24Q3, MetodicalOne = met24Q3, ReferenceOne = refs24Q3, ArtOne = art24Q3, PrentedOne = prt24Q3, ElectronicOne = el24Q3, PeriodichOne = per24Q3, NotesOne = "" });
            //4 кв.
            DataList.Add(new Results() { FundMomentOne = _title24Q4, TotalCountOne = _count24Q4, TotalCostOne = _cost24Q4, NaturalSocialOne = _natural24Q4, SocialOne = _social24Q4, HumanitarianOne = _human24Q4, MetodicalOne = _metodical24Q4, ReferenceOne = _reference24Q4, ArtOne = _art24Q4, PrentedOne = _print24Q4, ElectronicOne = _electr24Q4, PeriodichOne = _period24Q4, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = _titl24Q4, TotalCountOne = _totCount24Q4, TotalCostOne = _totCost24Q4, NaturalSocialOne = _nat24Q4, SocialOne = _soc24Q4, HumanitarianOne = _hum24Q4, MetodicalOne = _met24Q4, ReferenceOne = _ref24Q4, ArtOne = _arts24Q4, PrentedOne = _prt24Q4, ElectronicOne = _el24Q4, PeriodichOne = _per24Q4, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = title24Q4, TotalCountOne = totCount24Q4, TotalCostOne = cost24Q4, NaturalSocialOne = nat24Q4, SocialOne = soc24Q4, HumanitarianOne = hum24Q4, MetodicalOne = met24Q4, ReferenceOne = refs24Q4, ArtOne = art24Q4, PrentedOne = prt24Q4, ElectronicOne = el24Q4, PeriodichOne = per24Q4, NotesOne = "" });
            //Итоги
            DataList.Add(new Results() { FundMomentOne = title2024, TotalCountOne = _totalCount2024, TotalCostOne = _totalCost2024, NaturalSocialOne = _natural2024, SocialOne = _social2024, HumanitarianOne = _human2024, MetodicalOne = _metodical2024, ReferenceOne = _reference2024, ArtOne = _art2024, PrentedOne = _print2024, ElectronicOne = _electr2024, PeriodichOne = _period2024, NotesOne = "" });
            DataList.Add(new Results() { FundMomentOne = titleDis2024, TotalCountOne = totCount2024, TotalCostOne = cost2024, NaturalSocialOne = nat2024, SocialOne = soc2024, HumanitarianOne = hum2024, MetodicalOne = met2024, ReferenceOne = refs2024, ArtOne = art2024, PrentedOne = prt2024, ElectronicOne = el2024, PeriodichOne = per2024, NotesOne = "" });
            //2025
            DataList.Add(new Results() { FundMomentOne = _title25, TotalCountOne = _count25, TotalCostOne = _cost25, NaturalSocialOne = _natural25, SocialOne = _social25, HumanitarianOne = _human25, MetodicalOne = _metodical25, ReferenceOne = _reference25, ArtOne = _art25, PrentedOne = _print25, ElectronicOne = _electr25, PeriodichOne = _period25, NotesOne = "" });
            //1 кв.


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
