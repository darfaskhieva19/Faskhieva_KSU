﻿//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Controls;
//using static OfficeOpenXml.ExcelErrorValue;
//using System.Xml.Linq;
//using System.Collections.ObjectModel;

//namespace KSU
//{
//    public class Results
//    {
//        public int Id { get; set; }
//        public string FundMomentOne { get; set; }
//        public int TotalCountOne { get; set; }
//        public double TotalCostOne { get; set; }
//        public int NaturalSocialOne { get; set; }
//        public int SocialOne { get; set; }
//        public int HumanitarianOne { get; set; }
//        public int MetodicalOne { get; set; }
//        public int ReferenceOne { get; set; }
//        public int ArtOne { get; set; }
//        public int PrentedOne { get; set; }
//        public int ElectronicOne { get; set; }
//        public int PeriodichOne { get; set; }
//        public string NotesOne { get; set; }



//        public void Calc()
//        {
            

//            //Состоит на начало 2019 года
//            string BeginningOfTheYear19 = "Состоит на 01.01.2019 г.";
//            int _countBeginingYear19 = 0, _costYear19 = 0, _naturalYear19 = 0, _socialYear19 = 0, _humanYear19 = 0, _metodicalYear19 = 0, _referenceYear19 = 0, _artYear19 = 0, _printYear19 = 0, _electrYear19 = 0, _periodYear19 = 0;
//            //Подсчеты сколько состоит на начало 2019 года
//            _countBeginingYear19 = _countBegining + totalCount; //Состоит на предыдущий год + Поступление - Выбытие
//            _naturalYear19 = _natural + natural;
//            _socialYear19 = _social + social;
//            _referenceYear19 = _reference + reference;
//            _humanYear19 = _human + human;
//            _metodicalYear19 = _metodical + metodical;
//            _artYear19 = _art + art;
//            _printYear19 = _print + print;
//            _electrYear19 = _electr + electr;
//            _periodYear19 = _period + period;

//            //Поступление 2019 год
//            int year19 = 2019;
//            DateTime startDate19 = new DateTime(year19, 1, 1);
//            DateTime endDate19 = new DateTime(year19, 12, 31);
//            string Year2019 = "Поступило за 2019 г.";
//            int totalCount19 = 0; //Общее количество
//            double totalCost19 = 0; //Общая стоимость
//            int natural19 = 0; //Естественные науки
//            int social19 = 0; //Технические науки
//            int human19 = 0; //Гуманитарные науки
//            int metodical19 = 0; //Методическая литература
//            int reference19 = 0; //Справочная литература
//            int art19 = 0; //Художественная литература
//            int print19 = 0; //Печатный вид
//            int electr19 = 0; //Электронный вид
//            int period19 = 0; //Периодические издания
//            var items19 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= startDate19 && x.Date <= endDate19);
//            foreach (var item in items19)
//            {
//                totalCount19 += item.TotalInstances;
//                totalCost19 += item.Cost;
//            }
//            foreach (var item in items19)
//            {
//                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
//                foreach (var itemContent in contentsReceipts)
//                {
//                    if (itemContent.IdContents == contentId) // естественные науки
//                    {
//                        natural19 += (int)itemContent.Counts;
//                    }
//                    if (itemContent.IdContents == contentIdTwo) // технические науки
//                    {
//                        social19 += (int)itemContent.Counts;
//                    }
//                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
//                    {
//                        human19 += (int)itemContent.Counts;
//                    }
//                    if (itemContent.IdContents == contentIdFour) //Методическая литература
//                    {
//                        metodical19 += (int)itemContent.Counts;
//                    }
//                    if (itemContent.IdContents == contentIdFive) //Справочная литература
//                    {
//                        reference19 += (int)itemContent.Counts;
//                    }
//                    if (itemContent.IdContents == contentIdSix) //Художественная литература
//                    {
//                        art19 += (int)itemContent.Counts;
//                    }
//                }
//            }
//            foreach (var item in items19)
//            {
//                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
//                foreach (var itemView in viewsReceipts)
//                {
//                    if (itemView.IdViews == viewId)
//                    {
//                        print19 += (int)itemView.Counts; //Печатные
//                    }
//                    if (itemView.IdViews == viewIdTwo)
//                    {
//                        electr19 += (int)itemView.Counts; //Электронные
//                    }
//                    if (itemView.IdViews == viewIdThree)
//                    {
//                        period19 += (int)itemView.Counts; //Периодические издания
//                    }
//                }
//            }

//            //Выбытие 2019 год
//            string DisYear2019 = "Выбыло за 2019 г.";
//            int totalCountDis = 0; //Общее количество
//            double totalCostDis = 0; //Общая стоимость
//            int naturalDis = 0; //Естественные науки
//            int socialDis = 0; //Технические науки
//            int humanDis = 0; //Гуманитарные науки
//            int metodicalDis = 0; //Методическая литература
//            int referenceDis = 0; //Справочная литература
//            int artDis = 0; //Художественная литература
//            int printDis = 0; //Печатный вид
//            int electrDis = 0; //Электронный вид
//            int periodDis = 0; //Периодические издания
//            var itemss = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= startDate19 && x.Date <= endDate19);
//            foreach (var item in itemss)
//            {
//                totalCountDis += item.TotalNumber;
//                totalCostDis += item.Cost;
//            }
//            foreach (var item in itemss)
//            {
//                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
//                foreach (var itemContent in contentsDisposals)
//                {
//                    if (itemContent.IdContents == contentId) // естественные науки
//                    {
//                        naturalDis += (int)itemContent.Counts;
//                    }
//                    if (itemContent.IdContents == contentIdTwo) // технические науки
//                    {
//                        socialDis += (int)itemContent.Counts;
//                    }
//                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
//                    {
//                        humanDis += (int)itemContent.Counts;
//                    }
//                    if (itemContent.IdContents == contentIdFour) //Методическая литература
//                    {
//                        metodicalDis += (int)itemContent.Counts;
//                    }
//                    if (itemContent.IdContents == contentIdFive) //Справочная литература
//                    {
//                        referenceDis += (int)itemContent.Counts;
//                    }
//                    if (itemContent.IdContents == contentIdSix) //Художественная литература
//                    {
//                        artDis += (int)itemContent.Counts;
//                    }
//                }
//            }
//            foreach (var item in itemss)
//            {
//                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
//                foreach (var itemView in viewsDisposals)
//                {
//                    if (itemView.IdViews == viewId)
//                    {
//                        printDis += (int)itemView.Counts; //Печатные
//                    }
//                    if (itemView.IdViews == viewIdTwo)
//                    {
//                        electrDis += (int)itemView.Counts; //Электронные
//                    }
//                    if (itemView.IdViews == viewIdThree)
//                    {
//                        periodDis += (int)itemView.Counts; //Периодические издания
//                    }
//                }
//            }

//            //Состоит на начало 2020 года
//            string BeginningOfTheYear20 = "Состоит на 01.01.2020 г.";
//            int _countBeginingYear20 = 0, _costYear20 = 0, _naturalYear20 = 0, _socialYear20 = 0, _humanYear20 = 0, _metodicalYear20 = 0, _referenceYear20 = 0, _artYear20 = 0, _printYear20 = 0, _electrYear20 = 0, _periodYear20 = 0;
//            //Подсчеты сколько состоит на начало 2020 года
//            _countBeginingYear20 = _countBeginingYear19 + totalCount19 - totalCountDis;
//            _naturalYear20 = _naturalYear19 + natural19 - naturalDis;
//            _socialYear20 = _socialYear19 + social19 - socialDis;
//            _referenceYear20 = _referenceYear19 + reference19 - referenceDis;
//            _humanYear20 = _humanYear19 + human19 - humanDis;
//            _metodicalYear20 = _metodicalYear19 + metodical19 - metodicalDis;
//            _artYear20 = _artYear19 + art19 - artDis;
//            _printYear20 = _printYear19 + print19 - printDis;
//            _electrYear20 = _electrYear19 + electr19 - electrDis;
//            _periodYear20 = _periodYear19 + period19 - periodDis;

//            //Поступление 2020 год
//            int year20 = 2020;
//            DateTime startDate20 = new DateTime(year20, 1, 1);
//            DateTime endDate20 = new DateTime(year20, 12, 31);
//            string Year2020 = "Поступило за 2020 г.";
//            int totalCount20 = 0; //Общее количество
//            double totalCost20 = 0; //Общая стоимость
//            int natural20 = 0; //Естественные науки
//            int social20 = 0; //Технические науки
//            int human20 = 0; //Гуманитарные науки
//            int metodical20 = 0; //Методическая литература
//            int reference20 = 0; //Справочная литература
//            int art20 = 0; //Художественная литература
//            int print20 = 0; //Печатный вид
//            int electr20 = 0; //Электронный вид
//            int period20 = 0; //Периодические издания
//            var items20 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= startDate20 && x.Date <= endDate20);
//            foreach (var item in items20)
//            {
//                totalCount20 += item.TotalInstances;
//                totalCost20 += item.Cost;
//            }
//            foreach (var item in items20)
//            {
//                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
//                foreach (var itemContent in contentsReceipts)
//                {
//                    if (itemContent.IdContents == contentId) // естественные науки
//                    {
//                        natural20 += (int)itemContent.Counts;
//                    }
//                    if (itemContent.IdContents == contentIdTwo) // технические науки
//                    {
//                        social20 += (int)itemContent.Counts;
//                    }
//                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
//                    {
//                        human20 += (int)itemContent.Counts;
//                    }
//                    if (itemContent.IdContents == contentIdFour) //Методическая литература
//                    {
//                        metodical20 += (int)itemContent.Counts;
//                    }
//                    if (itemContent.IdContents == contentIdFive) //Справочная литература
//                    {
//                        reference20 += (int)itemContent.Counts;
//                    }
//                    if (itemContent.IdContents == contentIdSix) //Художественная литература
//                    {
//                        art20 += (int)itemContent.Counts;
//                    }
//                }
//            }
//            foreach (var item in items20)
//            {
//                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
//                foreach (var itemView in viewsReceipts)
//                {
//                    if (itemView.IdViews == viewId)
//                    {
//                        print20 += (int)itemView.Counts; //Печатные
//                    }
//                    if (itemView.IdViews == viewIdTwo)
//                    {
//                        electr20 += (int)itemView.Counts; //Электронные
//                    }
//                    if (itemView.IdViews == viewIdThree)
//                    {
//                        period20 += (int)itemView.Counts; //Периодические издания
//                    }
//                }
//            }

//            //Выбытие 2020 год
//            string DisYear2020 = "Выбыло за 2020 г.";
//            int totalCountDis20 = 0, naturalDis20 = 0, socialDis20 = 0, humanDis20 = 0, metodicalDis20 = 0, referenceDis20 = 0, artDis20 = 0, printDis20 = 0, electrDis20 = 0, periodDis20 = 0;
//            double totalCostDis20 = 0; //Общая стоимость
//            var itemss20 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= startDate20 && x.Date <= endDate20);
//            foreach (var item in itemss20)
//            {
//                totalCountDis20 += item.TotalNumber;
//                totalCostDis20 += item.Cost;
//            }
//            foreach (var item in itemss20)
//            {
//                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
//                foreach (var itemContent in contentsDisposals)
//                {
//                    if (itemContent.IdContents == contentId) // естественные науки
//                    { naturalDis20 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdTwo) // технические науки
//                    { socialDis20 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
//                    { humanDis20 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFour) //Методическая литература
//                    { metodicalDis20 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFive) //Справочная литература
//                    { referenceDis20 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdSix) //Художественная литература
//                    { artDis20 += (int)itemContent.Counts; }
//                }
//            }
//            foreach (var item in itemss20)
//            {
//                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
//                foreach (var itemView in viewsDisposals)
//                {
//                    if (itemView.IdViews == viewId) //Печатные
//                    { printDis20 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdTwo) //Электронные
//                    { electrDis20 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdThree)//Периодические издания
//                    { periodDis20 += (int)itemView.Counts; }
//                }
//            }

//            //Состоит на начало 2021 года
//            string BeginningOfTheYear21 = "Состоит на 01.01.2021 г.";
//            int _countBeginingYear21 = 0, _costYear21 = 0, _naturalYear21 = 0, _socialYear21 = 0, _humanYear21 = 0, _metodicalYear21 = 0, _referenceYear21 = 0, _artYear21 = 0, _printYear21 = 0, _electrYear21 = 0, _periodYear21 = 0;
//            //Подсчеты сколько состоит на начало 2021 года
//            _countBeginingYear21 = _countBeginingYear20 + totalCount20 - totalCountDis20;
//            _naturalYear21 = _naturalYear20 + natural20 - naturalDis20;
//            _socialYear21 = _socialYear20 + social20 - socialDis20;
//            _referenceYear21 = _referenceYear20 + reference20 - referenceDis20;
//            _humanYear21 = _humanYear20 + human20 - humanDis20;
//            _metodicalYear21 = _metodicalYear20 + metodical20 - metodicalDis20;
//            _artYear21 = _artYear20 + art20 - artDis20;
//            _printYear21 = _printYear20 + print20 - printDis20;
//            _electrYear21 = _electrYear20 + electr20 - electrDis20;
//            _periodYear21 = _periodYear20 + period20 - periodDis20;

//            int year21 = 2021;
//            // Диапазон первого квартала
//            DateTime January = new DateTime(year21, 1, 1);
//            DateTime March = new DateTime(year21, 3, 31);
//            // Диапазон второго квартала
//            DateTime April = new DateTime(year21, 4, 1);
//            DateTime June = new DateTime(year21, 6, 30);
//            // Диапазон третьего квартала
//            DateTime July = new DateTime(year21, 7, 1);
//            DateTime September = new DateTime(year21, 9, 30);
//            // Диапазон четвертого квартала
//            DateTime October = new DateTime(year21, 10, 1);
//            DateTime December = new DateTime(year21, 12, 31);

//            // Рассчитываем Поступление 2021 год за первый квартал
//            var items2021Q1 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= January && x.Date <= March);
//            string Q1Title = "Поступило за 1 квартал " + year21 + " г.";
//            int totalCountQ1 = 0; //Общее количество
//            double totalCostQ1 = 0; //Общая стоимость
//            int naturalQ1 = 0; //Естественные науки
//            int socialQ1 = 0; //Технические науки
//            int humanQ1 = 0; //Гуманитарные науки
//            int metodicalQ1 = 0; //Методическая литература
//            int referenceQ1 = 0; //Справочная литература
//            int artQ1 = 0; //Художественная литература
//            int printQ1 = 0; //Печатный вид
//            int electrQ1 = 0; //Электронный вид
//            int periodQ1 = 0; //Периодические издания
//            foreach (var item in items2021Q1) { totalCountQ1 += item.TotalInstances; totalCostQ1 += item.Cost; }
//            foreach (var item in items2021Q1) //По содержанию
//            {
//                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
//                foreach (var itemContent in contentsReceipts)
//                {
//                    if (itemContent.IdContents == contentId) // естественные науки
//                    { naturalQ1 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdTwo) // технические науки
//                    { socialQ1 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
//                    { humanQ1 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFour) //Методическая литература
//                    { metodicalQ1 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFive) //Справочная литература
//                    { referenceQ1 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdSix) //Художественная литература
//                    { artQ1 += (int)itemContent.Counts; }
//                }
//            }
//            foreach (var item in items2021Q1) //По виду
//            {
//                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
//                foreach (var itemView in viewsReceipts)
//                {
//                    if (itemView.IdViews == viewId) //Печатный
//                    { printQ1 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdTwo) //Электронный
//                    { electrQ1 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdThree)//Периодические издания
//                    { periodQ1 += (int)itemView.Counts; }
//                }
//            }

//            // Рассчитываем Выбытие за первый квартал
//            string DisYear2021K1 = "Выбыло за 1 кв. 2021 г.";
//            int totalCountDis21K1 = 0; //Общее количество
//            double totalCostDis21K1 = 0; //Общая стоимость
//            int naturalDis21K1 = 0; //Естественные науки
//            int socialDis21K1 = 0; //Технические науки
//            int humanDis21K1 = 0; //Гуманитарные науки
//            int metodicalDis21K1 = 0; //Методическая литература
//            int referenceDis21K1 = 0; //Справочная литература
//            int artDis21K1 = 0; //Художественная литература
//            int printDis21K1 = 0; //Печатный вид
//            int electrDis21K1 = 0; //Электронный вид
//            int periodDis21K1 = 0; //Периодические издания
//            var itemss21K1 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= January && x.Date <= March);
//            foreach (var item in itemss21K1)
//            {
//                totalCountDis21K1 += item.TotalNumber;
//                totalCostDis21K1 += item.Cost;
//            }
//            foreach (var item in itemss21K1) //По содержанию
//            {
//                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
//                foreach (var itemContent in contentsDisposals)
//                {
//                    if (itemContent.IdContents == contentId) // естественные науки
//                    { naturalDis21K1 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdTwo) // технические науки                    
//                    { socialDis21K1 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки                    
//                    { humanDis21K1 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFour) //Методическая литература
//                    { metodicalDis21K1 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFive) //Справочная литература                    
//                    { referenceDis21K1 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdSix) //Художественная литература
//                    { artDis21K1 += (int)itemContent.Counts; }
//                }
//            }
//            foreach (var item in itemss21K1) // По виду
//            {
//                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
//                foreach (var itemView in viewsDisposals)
//                {
//                    if (itemView.IdViews == viewId) //Печатные
//                    { printDis21K1 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdTwo) //Электронные
//                    { electrDis21K1 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdThree) //Периодические издания
//                    { periodDis21K1 += (int)itemView.Counts; }
//                }
//            }

//            //Состоит на начало 2021 года 2 квартал
//            string BeginningOfTheYear21K2 = "Состоит на 2 кв. 2021 г.";
//            int _countBeginingYear21K2 = 0, _costYear21K2 = 0, _naturalYear21K2 = 0, _socialYear21K2 = 0, _humanYear21K2 = 0, _metodicalYear21K2 = 0, _referenceYear21K2 = 0, _artYear21K2 = 0, _printYear21K2 = 0, _electrYear21K2 = 0, _periodYear21K2 = 0;
//            //Подсчеты сколько состоит на начало 2021 года
//            _countBeginingYear21K2 = _countBeginingYear21 + totalCountQ1 - totalCountDis21K1;
//            _naturalYear21K2 = _naturalYear21 + naturalQ1 - naturalDis21K1;
//            _socialYear21K2 = _socialYear21 + socialQ1 - socialDis21K1;
//            _referenceYear21K2 = _referenceYear21 + referenceQ1 - referenceDis21K1;
//            _humanYear21K2 = _humanYear21 + humanQ1 - humanDis21K1;
//            _metodicalYear21K2 = _metodicalYear21 + metodicalQ1 - metodicalDis21K1;
//            _artYear21K2 = _artYear21 + artQ1 - artDis21K1;
//            _printYear21K2 = _printYear21 + printQ1 - printDis21K1;
//            _electrYear21K2 = _electrYear21 + electrQ1 - electrDis21K1;
//            _periodYear21K2 = _periodYear21 + periodQ1 - periodDis21K1;

//            // Рассчитываем Поступление 2021 год за первый квартал
//            var items2021Q2 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= April && x.Date <= June);
//            string Q2Title = "Поступило за 2 квартал " + year21 + " г.";
//            int totalCountQ2 = 0; //Общее количество
//            double totalCostQ2 = 0; //Общая стоимость
//            int naturalQ2 = 0; //Естественные науки
//            int socialQ2 = 0; //Технические науки
//            int humanQ2 = 0; //Гуманитарные науки
//            int metodicalQ2 = 0; //Методическая литература
//            int referenceQ2 = 0; //Справочная литература
//            int artQ2 = 0; //Художественная литература
//            int printQ2 = 0; //Печатный вид
//            int electrQ2 = 0; //Электронный вид
//            int periodQ2 = 0; //Периодические издания
//            foreach (var item in items2021Q2) { totalCountQ2 += item.TotalInstances; totalCostQ2 += item.Cost; }
//            foreach (var item in items2021Q2) //По содержанию
//            {
//                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
//                foreach (var itemContent in contentsReceipts)
//                {
//                    if (itemContent.IdContents == contentId) // естественные науки
//                    { naturalQ2 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdTwo) // технические науки
//                    { socialQ2 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
//                    { humanQ2 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFour) //Методическая литература
//                    { metodicalQ2 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFive) //Справочная литература
//                    { referenceQ2 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdSix) //Художественная литература
//                    { artQ2 += (int)itemContent.Counts; }
//                }
//            }
//            foreach (var item in items2021Q2) //По виду
//            {
//                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
//                foreach (var itemView in viewsReceipts)
//                {
//                    if (itemView.IdViews == viewId) //Печатный
//                    { printQ2 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdTwo) //Электронный
//                    { electrQ2 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdThree)//Периодические издания
//                    { periodQ2 += (int)itemView.Counts; }
//                }
//            }

//            // Рассчитываем Выбытие за первый квартал
//            string DisYear2021K2 = "Выбыло за 2 кв. 2021 г.";
//            int totalCountDis21K2 = 0; //Общее количество
//            double totalCostDis21K2 = 0; //Общая стоимость
//            int naturalDis21K2 = 0; //Естественные науки
//            int socialDis21K2 = 0; //Технические науки
//            int humanDis21K2 = 0; //Гуманитарные науки
//            int metodicalDis21K2 = 0; //Методическая литература
//            int referenceDis21K2 = 0; //Справочная литература
//            int artDis21K2 = 0; //Художественная литература
//            int printDis21K2 = 0; //Печатный вид
//            int electrDis21K2 = 0; //Электронный вид
//            int periodDis21K2 = 0; //Периодические издания
//            var itemss21K2 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= April && x.Date <= June);
//            foreach (var item in itemss21K2)
//            {
//                totalCountDis21K2 += item.TotalNumber;
//                totalCostDis21K2 += item.Cost;
//            }
//            foreach (var item in itemss21K2) //По содержанию
//            {
//                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
//                foreach (var itemContent in contentsDisposals)
//                {
//                    if (itemContent.IdContents == contentId) // естественные науки
//                    { naturalDis21K2 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdTwo) // технические науки                    
//                    { socialDis21K2 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки                    
//                    { humanDis21K2 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFour) //Методическая литература
//                    { metodicalDis21K2 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFive) //Справочная литература                    
//                    { referenceDis21K2 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdSix) //Художественная литература
//                    { artDis21K2 += (int)itemContent.Counts; }
//                }
//            }
//            foreach (var item in itemss21K2) // По виду
//            {
//                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
//                foreach (var itemView in viewsDisposals)
//                {
//                    if (itemView.IdViews == viewId) //Печатные
//                    { printDis21K2 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdTwo) //Электронные
//                    { electrDis21K2 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdThree) //Периодические издания
//                    { periodDis21K2 += (int)itemView.Counts; }
//                }
//            }

//            ////3 квартал
//            ////Состоит на начало 2021 года 
//            string BeginningOfTheYear21K3 = "Состоит на 3 кв. 2021 г.";
//            int _countBeginingYear21K3 = 0, _costYear21K3 = 0, _naturalYear21K3 = 0, _socialYear21K3 = 0, _humanYear21K3 = 0, _metodicalYear21K3 = 0, _referenceYear21K3 = 0, _artYear21K3 = 0, _printYear21K3 = 0, _electrYear21K3 = 0, _periodYear21K3 = 0;
//            //Подсчеты сколько состоит на начало 2021 года
//            _countBeginingYear21K3 = _countBeginingYear21K2 + totalCountQ2 - totalCountDis21K2;
//            _naturalYear21K3 = _naturalYear21K2 + naturalQ2 - naturalDis21K2;
//            _socialYear21K3 = _socialYear21K2 + socialQ2 - socialDis21K2;
//            _referenceYear21K3 = _referenceYear21K2 + referenceQ2 - referenceDis21K2;
//            _humanYear21K3 = _humanYear21K2 + humanQ2 - humanDis21K2;
//            _metodicalYear21K3 = _metodicalYear21K2 + metodicalQ2 - metodicalDis21K2;
//            _artYear21K3 = _artYear21K2 + artQ2 - artDis21K2;
//            _printYear21K3 = _printYear21K2 + printQ2 - printDis21K2;
//            _electrYear21K3 = _electrYear21K2 + electrQ2 - electrDis21K2;
//            _periodYear21K3 = _periodYear21K2 + periodQ2 - periodDis21K2;

//            // Рассчитываем Поступление 2021 год за первый квартал
//            var items2021Q3 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= July && x.Date <= September);
//            string Q3Title = "Поступило за 3 квартал " + year21 + " г.";
//            int totalCountQ3 = 0; //Общее количество
//            double totalCostQ3 = 0; //Общая стоимость
//            int naturalQ3 = 0; //Естественные науки
//            int socialQ3 = 0; //Технические науки
//            int humanQ3 = 0; //Гуманитарные науки
//            int metodicalQ3 = 0; //Методическая литература
//            int referenceQ3 = 0; //Справочная литература
//            int artQ3 = 0; //Художественная литература
//            int printQ3 = 0; //Печатный вид
//            int electrQ3 = 0; //Электронный вид
//            int periodQ3 = 0; //Периодические издания
//            foreach (var item in items2021Q3) { totalCountQ3 += item.TotalInstances; totalCostQ3 += item.Cost; }
//            foreach (var item in items2021Q3) //По содержанию
//            {
//                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
//                foreach (var itemContent in contentsReceipts)
//                {
//                    if (itemContent.IdContents == contentId) // естественные науки
//                    { naturalQ3 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdTwo) // технические науки
//                    { socialQ3 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
//                    { humanQ3 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFour) //Методическая литература
//                    { metodicalQ3 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFive) //Справочная литература
//                    { referenceQ3 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdSix) //Художественная литература
//                    { artQ3 += (int)itemContent.Counts; }
//                }
//            }
//            foreach (var item in items2021Q3) //По виду
//            {
//                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
//                foreach (var itemView in viewsReceipts)
//                {
//                    if (itemView.IdViews == viewId) //Печатный
//                    { printQ3 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdTwo) //Электронный
//                    { electrQ3 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdThree)//Периодические издания
//                    { periodQ3 += (int)itemView.Counts; }
//                }
//            }

//            // Рассчитываем Выбытие за первый квартал
//            string DisYear2021K3 = "Выбыло за 3 кв. 2021 г.";
//            int totalCountDis21K3 = 0; //Общее количество
//            double totalCostDis21K3 = 0; //Общая стоимость
//            int naturalDis21K3 = 0; //Естественные науки
//            int socialDis21K3 = 0; //Технические науки
//            int humanDis21K3 = 0; //Гуманитарные науки
//            int metodicalDis21K3 = 0; //Методическая литература
//            int referenceDis21K3 = 0; //Справочная литература
//            int artDis21K3 = 0; //Художественная литература
//            int printDis21K3 = 0; //Печатный вид
//            int electrDis21K3 = 0; //Электронный вид
//            int periodDis21K3 = 0; //Периодические издания
//            var itemss21K3 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= July && x.Date <= September);
//            foreach (var item in itemss21K3)
//            {
//                totalCountDis21K3 += item.TotalNumber;
//                totalCostDis21K3 += item.Cost;
//            }
//            foreach (var item in itemss21K3) //По содержанию
//            {
//                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
//                foreach (var itemContent in contentsDisposals)
//                {
//                    if (itemContent.IdContents == contentId) // естественные науки
//                    { naturalDis21K3 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdTwo) // технические науки                    
//                    { socialDis21K3 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки                    
//                    { humanDis21K3 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFour) //Методическая литература
//                    { metodicalDis21K3 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFive) //Справочная литература                    
//                    { referenceDis21K3 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdSix) //Художественная литература
//                    { artDis21K3 += (int)itemContent.Counts; }
//                }
//            }
//            foreach (var item in itemss21K3) // По виду
//            {
//                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
//                foreach (var itemView in viewsDisposals)
//                {
//                    if (itemView.IdViews == viewId) //Печатные
//                    { printDis21K3 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdTwo) //Электронные
//                    { electrDis21K3 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdThree) //Периодические издания
//                    { periodDis21K3 += (int)itemView.Counts; }
//                }
//            }

//            //4 квартал
//            //Состоит на начало 2021 года 
//            string BeginningOfTheYear21K4 = "Состоит на 4 кв. 2021 г.";
//            int _countBeginingYear21K4 = 0, _costYear21K4 = 0, _naturalYear21K4 = 0, _socialYear21K4 = 0, _humanYear21K4 = 0, _metodicalYear21K4 = 0, _referenceYear21K4 = 0, _artYear21K4 = 0, _printYear21K4 = 0, _electrYear21K4 = 0, _periodYear21K4 = 0;
//            //Подсчеты сколько состоит на начало 2021 года
//            _countBeginingYear21K4 = _countBeginingYear21K3 + totalCountQ3 - totalCountDis21K3;
//            _naturalYear21K4 = _naturalYear21K3 + naturalQ3 - naturalDis21K3;
//            _socialYear21K4 = _socialYear21K3 + socialQ3 - socialDis21K3;
//            _referenceYear21K4 = _referenceYear21K3 + referenceQ3 - referenceDis21K3;
//            _humanYear21K4 = _humanYear21K3 + humanQ3 - humanDis21K3;
//            _metodicalYear21K4 = _metodicalYear21K3 + metodicalQ3 - metodicalDis21K3;
//            _artYear21K4 = _artYear21K3 + artQ3 - artDis21K3;
//            _printYear21K4 = _printYear21K3 + printQ3 - printDis21K3;
//            _electrYear21K4 = _electrYear21K3 + electrQ3 - electrDis21K3;
//            _periodYear21K4 = _periodYear21K3 + periodQ3 - periodDis21K3;

//            // Рассчитываем Поступление 2021 год за первый квартал
//            var items2021Q4 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= October && x.Date <= December);
//            string Q4Title = "Поступило за 4 квартал " + year21 + " г.";
//            int totalCountQ4 = 0; //Общее количество
//            double totalCostQ4 = 0; //Общая стоимость
//            int naturalQ4 = 0; //Естественные науки
//            int socialQ4 = 0; //Технические науки
//            int humanQ4 = 0; //Гуманитарные науки
//            int metodicalQ4 = 0; //Методическая литература
//            int referenceQ4 = 0; //Справочная литература
//            int artQ4 = 0; //Художественная литература
//            int printQ4 = 0; //Печатный вид
//            int electrQ4 = 0; //Электронный вид
//            int periodQ4 = 0; //Периодические издания
//            foreach (var item in items2021Q4) { totalCountQ4 += item.TotalInstances; totalCostQ4 += item.Cost; }
//            foreach (var item in items2021Q4) //По содержанию
//            {
//                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
//                foreach (var itemContent in contentsReceipts)
//                {
//                    if (itemContent.IdContents == contentId) // естественные науки
//                    { naturalQ4 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdTwo) // технические науки
//                    { socialQ4 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
//                    { humanQ4 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFour) //Методическая литература
//                    { metodicalQ4 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFive) //Справочная литература
//                    { referenceQ4 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdSix) //Художественная литература
//                    { artQ4 += (int)itemContent.Counts; }
//                }
//            }
//            foreach (var item in items2021Q4) //По виду
//            {
//                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
//                foreach (var itemView in viewsReceipts)
//                {
//                    if (itemView.IdViews == viewId) //Печатный
//                    { printQ4 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdTwo) //Электронный
//                    { electrQ4 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdThree)//Периодические издания
//                    { periodQ4 += (int)itemView.Counts; }
//                }
//            }

//            // Рассчитываем Выбытие за четвертый квартал
//            string DisYear2021K4 = "Выбыло за 4 кв. 2021 г.";
//            int totalCountDis21K4 = 0; //Общее количество
//            double totalCostDis21K4 = 0; //Общая стоимость
//            int naturalDis21K4 = 0; //Естественные науки
//            int socialDis21K4 = 0; //Технические науки
//            int humanDis21K4 = 0; //Гуманитарные науки
//            int metodicalDis21K4 = 0; //Методическая литература
//            int referenceDis21K4 = 0; //Справочная литература
//            int artDis21K4 = 0; //Художественная литература
//            int printDis21K4 = 0; //Печатный вид
//            int electrDis21K4 = 0; //Электронный вид
//            int periodDis21K4 = 0; //Периодические издания
//            var itemss21K4 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= October && x.Date <= December);
//            foreach (var item in itemss21K4)
//            {
//                totalCountDis21K4 += item.TotalNumber;
//                totalCostDis21K4 += item.Cost;
//            }
//            foreach (var item in itemss21K4) //По содержанию
//            {
//                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
//                foreach (var itemContent in contentsDisposals)
//                {
//                    if (itemContent.IdContents == contentId) // естественные науки
//                    { naturalDis21K4 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdTwo) // технические науки                    
//                    { socialDis21K4 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки                    
//                    { humanDis21K4 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFour) //Методическая литература
//                    { metodicalDis21K4 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFive) //Справочная литература                    
//                    { referenceDis21K4 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdSix) //Художественная литература
//                    { artDis21K4 += (int)itemContent.Counts; }
//                }
//            }
//            foreach (var item in itemss21K4) // По виду
//            {
//                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
//                foreach (var itemView in viewsDisposals)
//                {
//                    if (itemView.IdViews == viewId) //Печатные
//                    { printDis21K4 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdTwo) //Электронные
//                    { electrDis21K4 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdThree) //Периодические издания
//                    { periodDis21K4 += (int)itemView.Counts; }
//                }
//            }
//            DateTime startDate2021 = new DateTime(year20, 1, 1);
//            DateTime endDate2021 = new DateTime(year20, 12, 31);
//            // Рассчитываем Поступление за 2021 год
//            var Items2021 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= startDate2021 && x.Date <= endDate2021);
//            string Title2021 = "Итого поступило за год ";
//            int totalCount2021 = 0, natural2021 = 0, social2021 = 0, human2021 = 0, metodical2021 = 0, reference2021 = 0, art2021 = 0, print2021 = 0, electr2021 = 0, period2021 = 0;
//            double totalCost2021 = 0;
//            foreach (var item in Items2021)
//            {
//                totalCount2021 = totalCountQ1 + totalCountQ2 + totalCountQ3 + totalCountQ4;
//                totalCost2021 = totalCostQ1 + totalCostQ2 + totalCostQ3 + totalCostQ4;
//                natural2021 = naturalQ1 + naturalQ2 + naturalQ3 + naturalQ4;
//                social2021 = socialQ1 + socialQ2 + socialQ3 + socialQ4;
//                human2021 = humanQ1 + humanQ2 + humanQ3 + humanQ4;
//                metodical2021 = metodicalQ1 + metodicalQ2 + metodicalQ3 + metodicalQ4;
//                reference2021 = referenceQ1 + referenceQ2 + referenceQ3 + referenceQ4;
//                art2021 = artQ1 + artQ2 + artQ3 + artQ4;
//                print2021 = printQ1 + printQ2 + printQ3 + printQ4;
//                electr2021 = electrQ1 + electrQ2 + electrQ3 + electrQ4;
//                period2021 = periodQ1 + periodQ2 + periodQ3 + periodQ4;
//            }

//            // Рассчитываем Выбытие 
//            string DisYear2021 = "Выбыло";
//            int totalCountDis2021 = 0, naturalDis2021 = 0, socialDis2021 = 0, humanDis2021 = 0, metodicalDis2021 = 0, referenceDis2021 = 0, artDis2021 = 0, printDis2021 = 0, electrDis2021 = 0, periodDis2021 = 0;
//            double totalCostDis2021 = 0; //Общая стоимость
//            var itemss2021 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= startDate2021 && x.Date <= endDate2021);
//            foreach (var item in itemss2021)
//            {
//                totalCountDis2021 = totalCountDis21K1 + totalCountDis21K2 + totalCountDis21K3 + totalCountDis21K4;
//                totalCostDis2021 = totalCostDis21K1 + totalCostDis21K2 + totalCostDis21K3 + totalCostDis21K4;
//                naturalDis2021 = naturalDis21K1 + naturalDis21K2 + naturalDis21K3 + naturalDis21K4;
//                socialDis2021 = socialDis21K1 + socialDis21K2 + socialDis21K3 + socialDis21K4;
//                humanDis2021 = humanDis21K1 + humanDis21K2 + humanDis21K3 + humanDis21K4;
//                metodicalDis2021 = metodicalDis21K1 + metodicalDis21K2 + metodicalDis21K3 + metodicalDis21K4;
//                referenceDis2021 = referenceDis21K1 + referenceDis21K2 + referenceDis21K3 + referenceDis21K4;
//                artDis2021 = artDis21K1 + artDis21K2 + artDis21K3 + artDis21K4;
//                printDis2021 = printDis21K1 + printDis21K2 + printDis21K3 + printDis21K4;
//                electrDis2021 = electrDis21K1 + electrDis21K2 + electrDis21K3 + electrDis21K4;
//                periodDis2021 = periodDis21K1 + periodDis21K2 + periodDis21K3 + periodDis21K4;
//            }

//            string BeginningOfTheYear22 = "Состоит на 01.01.2022 г.";
//            int _countBeginingYear22 = 0, _costYear22 = 0, _naturalYear22 = 0, _socialYear22 = 0, _humanYear22 = 0, _metodicalYear22 = 0, _referenceYear22 = 0, _artYear22 = 0, _printYear22 = 0, _electrYear22 = 0, _periodYear22 = 0;
//            //Подсчеты сколько состоит на начало 2021 года
//            _countBeginingYear22 = _countBeginingYear21K3 + totalCountQ4 - totalCountDis21K4;
//            _naturalYear22 = _naturalYear21K4 + naturalQ4 - naturalDis21K4;
//            _socialYear22 = _socialYear21K4 + socialQ4 - socialDis21K4;
//            _referenceYear22 = _referenceYear21K4 + referenceQ4 - referenceDis21K4;
//            _humanYear22 = _humanYear21K4 + humanQ4 - humanDis21K4;
//            _metodicalYear22 = _metodicalYear21K4 + metodicalQ4 - metodicalDis21K4;
//            _artYear22 = _artYear21K4 + artQ4 - artDis21K4;
//            _printYear22 = _printYear21K4 + printQ4 - printDis21K4;
//            _electrYear22 = _electrYear21K4 + electrQ4 - electrDis21K4;
//            _periodYear22 = _periodYear21K4 + periodQ4 - periodDis21K4;

//            int year22 = 2022;
//            // Диапазон первого квартала
//            DateTime Januarys = new DateTime(year22, 1, 1);
//            DateTime Marchs = new DateTime(year22, 3, 31);
//            // Диапазон второго квартала
//            DateTime Aprils = new DateTime(year22, 4, 1);
//            DateTime Junes = new DateTime(year22, 6, 30);
//            // Диапазон третьего квартала
//            DateTime Julys = new DateTime(year22, 7, 1);
//            DateTime Septembers = new DateTime(year22, 9, 30);
//            // Диапазон четвертого квартала
//            DateTime Octobers = new DateTime(year22, 10, 1);
//            DateTime Decembers = new DateTime(year22, 12, 31);
//            // Рассчитываем Выбытие 1 кв. 2022 год
//            string DisYear2022K1 = "Выбыло за 1 кв. 2022 г.";
//            int totalCountDis22K1 = 0, naturalDis22K1 = 0, socialDis22K1 = 0, humanDis22K1 = 0, metodicalDis22K1 = 0, referenceDis22K1 = 0, artDis22K1 = 0, printDis22K1 = 0, electrDis22K1 = 0, periodDis22K1 = 0;
//            double totalCostDis22K1 = 0;
//            var itemss22K1 = DataBase.Base.Disposals.Where(x => x.IdEnclosures == 1 && x.Date >= Januarys && x.Date <= Marchs);
//            foreach (var item in itemss22K1)
//            {
//                totalCountDis22K1 += item.TotalNumber;
//                totalCostDis22K1 += item.Cost;
//            }
//            foreach (var item in itemss22K1) //По содержанию
//            {
//                var contentsDisposals = DataBase.Base.ContentsDisposals.Where(x => x.IdDisposals == item.Id);
//                foreach (var itemContent in contentsDisposals)
//                {
//                    if (itemContent.IdContents == contentId) // естественные науки
//                    { naturalDis22K1 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdTwo) // технические науки                    
//                    { socialDis22K1 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки                    
//                    { humanDis22K1 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFour) //Методическая литература
//                    { metodicalDis22K1 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFive) //Справочная литература                    
//                    { referenceDis22K1 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdSix) //Художественная литература
//                    { artDis22K1 += (int)itemContent.Counts; }
//                }
//            }
//            foreach (var item in itemss22K1) // По виду
//            {
//                var viewsDisposals = DataBase.Base.ViewsDisposals.Where(x => x.IdDisposals == item.Id);
//                foreach (var itemView in viewsDisposals)
//                {
//                    if (itemView.IdViews == viewId) //Печатные
//                    { printDis22K1 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdTwo) //Электронные
//                    { electrDis22K1 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdThree) //Периодические издания
//                    { periodDis22K1 += (int)itemView.Counts; }
//                }
//            }

//            string BeginningOfTheYear22K2 = "Состоит на 2 кв. 2022 г.";
//            int _countBeginingYear22K2 = 0, _costYear22K2 = 0, _naturalYear22K2 = 0, _socialYear22K2 = 0, _humanYear22K2 = 0, _metodicalYear22K2 = 0, _referenceYear22K2 = 0, _artYear22K2 = 0, _printYear22K2 = 0, _electrYear22K2 = 0, _periodYear22K2 = 0;
//            //Подсчеты сколько состоит на 2 кв. 2022 года
//            _countBeginingYear22K2 = _countBeginingYear22 - totalCountDis22K1;
//            _naturalYear22K2 = _naturalYear22 - naturalDis22K1;
//            _socialYear22K2 = _socialYear22 - socialDis22K1;
//            _referenceYear22K2 = _referenceYear22 - referenceDis22K1;
//            _humanYear22K2 = _humanYear22 - humanDis22K1;
//            _metodicalYear22K2 = _metodicalYear22 - metodicalDis22K1;
//            _artYear22K2 = _artYear22 - artDis22K1;
//            _printYear22K2 = _printYear22 - printDis22K1;
//            _electrYear22K2 = _electrYear22 - electrDis22K1;
//            _periodYear22K2 = _periodYear22 - periodDis22K1;

//            // Рассчитываем Поступление 2022 год за 2 квартал
//            var items2022Q2 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= Aprils && x.Date <= Junes);
//            string Title22 = "Поступило за 2 квартал " + year22 + " г.";
//            int totalCountQ22 = 0; //Общее количество
//            double totalCostQ22 = 0; //Общая стоимость
//            int naturalQ22 = 0; //Естественные науки
//            int socialQ22 = 0; //Технические науки
//            int humanQ22 = 0; //Гуманитарные науки
//            int metodicalQ22 = 0; //Методическая литература
//            int referenceQ22 = 0; //Справочная литература
//            int artQ22 = 0; //Художественная литература
//            int printQ22 = 0; //Печатный вид
//            int electrQ22 = 0; //Электронный вид
//            int periodQ22 = 0; //Периодические издания
//            foreach (var item in items2022Q2) { totalCountQ22 += item.TotalInstances; totalCostQ22 += item.Cost; }
//            foreach (var item in items2022Q2) //По содержанию
//            {
//                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
//                foreach (var itemContent in contentsReceipts)
//                {
//                    if (itemContent.IdContents == contentId) // естественные науки
//                    { naturalQ22 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdTwo) // технические науки
//                    { socialQ22 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
//                    { humanQ22 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFour) //Методическая литература
//                    { metodicalQ22 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFive) //Справочная литература
//                    { referenceQ22 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdSix) //Художественная литература
//                    { artQ22 += (int)itemContent.Counts; }
//                }
//            }
//            foreach (var item in items2022Q2) //По виду
//            {
//                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
//                foreach (var itemView in viewsReceipts)
//                {
//                    if (itemView.IdViews == viewId) //Печатный
//                    { printQ22 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdTwo) //Электронный
//                    { electrQ22 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdThree)//Периодические издания
//                    { periodQ22 += (int)itemView.Counts; }
//                }
//            }

//            string BeginningOfTheYear23 = "Состоит на 01.01.2023 г.";
//            int _countBeginingYear23 = 0, _costYear23 = 0, _naturalYear23 = 0, _socialYear23 = 0, _humanYear23 = 0, _metodicalYear23 = 0, _referenceYear23 = 0, _artYear23 = 0, _printYear23 = 0, _electrYear23 = 0, _periodYear23 = 0;
//            //Подсчеты сколько состоит на 2 кв. 2022 года
//            _countBeginingYear23 = _countBeginingYear22K2 + totalCountQ22;
//            _naturalYear23 = _naturalYear22K2 + naturalQ22;
//            _socialYear23 = _socialYear22K2 + socialQ22;
//            _referenceYear23 = _referenceYear22K2 + referenceQ22;
//            _humanYear23 = _humanYear22K2 + humanQ22;
//            _metodicalYear23 = _metodicalYear22K2 + metodicalQ22;
//            _artYear23 = _artYear22K2 + artQ22;
//            _printYear23 = _printYear22K2 + printQ22;
//            _electrYear23 = _electrYear22K2 + electrQ22;
//            _periodYear23 = _periodYear22K2 + periodQ22;

//            int year23 = 2023;
//            // Диапазон первого квартала
//            DateTime Jans = new DateTime(year23, 1, 1);
//            DateTime Mars = new DateTime(year23, 3, 31);
//            // Диапазон второго квартала
//            DateTime Aprs = new DateTime(year23, 4, 1);
//            DateTime Juns = new DateTime(year23, 6, 30);
//            // Диапазон третьего квартала
//            DateTime Juls = new DateTime(year23, 7, 1);
//            DateTime Seps = new DateTime(year23, 9, 30);
//            // Диапазон четвертого квартала
//            DateTime Octs = new DateTime(year23, 10, 1);
//            DateTime Decs = new DateTime(year23, 12, 31);
//            // Рассчитываем Поступление 2023 год за 1 квартал
//            var items2023Q1 = DataBase.Base.Receipts.Where(x => x.IdEnclosures == 1 && x.Date >= Jans && x.Date <= Mars);
//            string Title23 = "Поступило за 1 квартал " + year22 + " г.";
//            int totalCountQ23 = 0, naturalQ23 = 0, socialQ23 = 0, humanQ23 = 0, metodicalQ23 = 0, referenceQ23 = 0, artQ23 = 0, printQ23 = 0, electrQ23 = 0, periodQ23 = 0;
//            double totalCostQ23 = 0;
//            foreach (var item in items2023Q1) { totalCountQ23 += item.TotalInstances; totalCostQ23 += item.Cost; }
//            foreach (var item in items2023Q1) //По содержанию
//            {
//                var contentsReceipts = DataBase.Base.ContentsReceipts.Where(x => x.IdReceipts == item.Id);
//                foreach (var itemContent in contentsReceipts)
//                {
//                    if (itemContent.IdContents == contentId) // естественные науки
//                    { naturalQ23 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdTwo) // технические науки
//                    { socialQ23 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdThree) //Гуманитарные науки
//                    { humanQ23 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFour) //Методическая литература
//                    { metodicalQ23 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdFive) //Справочная литература
//                    { referenceQ23 += (int)itemContent.Counts; }
//                    if (itemContent.IdContents == contentIdSix) //Художественная литература
//                    { artQ23 += (int)itemContent.Counts; }
//                }
//            }
//            foreach (var item in items2023Q1) //По виду
//            {
//                var viewsReceipts = DataBase.Base.ViewsReceipts.Where(x => x.IdReceipts == item.Id);
//                foreach (var itemView in viewsReceipts)
//                {
//                    if (itemView.IdViews == viewId) //Печатный
//                    { printQ23 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdTwo) //Электронный
//                    { electrQ23 += (int)itemView.Counts; }
//                    if (itemView.IdViews == viewIdThree)//Периодические издания
//                    { periodQ23 += (int)itemView.Counts; }
//                }
//            }


//            List<Results> results = new List<Results>()
//            {
//                new Results() { Id = 1, FundMomentOne = BeginningOfTheYear, TotalCountOne = _countBegining, TotalCostOne = _cost, NaturalSocialOne = _natural, SocialOne = _social, HumanitarianOne = _human, MetodicalOne = _metodical, ReferenceOne = _reference, ArtOne = _art, PrentedOne = _print, ElectronicOne = _electr, PeriodichOne = _period, NotesOne = "" }, 
//                new Results() { Id = 2, FundMomentOne = Year2018, TotalCountOne = totalCount, TotalCostOne = totalCost, NaturalSocialOne = natural, SocialOne = _social, HumanitarianOne = human, MetodicalOne = metodical, ReferenceOne = reference, ArtOne = art, PrentedOne = print, ElectronicOne = electr, PeriodichOne = period, NotesOne = "" },
//                new Results() { Id = 3, FundMomentOne = BeginningOfTheYear19, TotalCountOne = _countBeginingYear19, TotalCostOne = _costYear19, NaturalSocialOne = _naturalYear19, SocialOne = _socialYear19, HumanitarianOne = _humanYear19, MetodicalOne = _metodicalYear19, ReferenceOne = _referenceYear19, ArtOne = _artYear19, PrentedOne = _printYear19, ElectronicOne = _electrYear19, PeriodichOne = _periodYear19, NotesOne = "" }
//            };
//        }

//        //    tbR19.Text = Year2019 + " - " + totalCount19 + " " + totalCost19 + " " + natural19 + " " + social19 + " " + human19 + " " + metodical19 + " " + reference19 + " " + art19 + " " + print19 + " " + electr19 + " " + period19;           
//        //    tbD19.Text = DisYear2019 + " - " + totalCountDis + " " + totalCostDis + " " + naturalDis + " " + socialDis + " " + humanDis + " " + metodicalDis + " " + referenceDis + " " + artDis + " " + printDis + " " + electrDis + " " + periodDis;

//        //    tbB20.Text = BeginningOfTheYear20 + " - " + _countBeginingYear20 + " " + _costYear20 + " " + _naturalYear20 + " " + _socialYear20 + " " + _humanYear20 + " " + _metodicalYear20 + " " + _referenceYear20 + " " + _artYear20 + " " + _printYear20 + " " + _electrYear20 + " " + _periodYear20; //на начало года 
//        //    tbR20.Text = Year2020 + " - " + totalCount20 + " " + totalCost20 + " " + natural20 + " " + social20 + " " + human20 + " " + metodical20 + " " + reference20 + " " + art20 + " " + print20 + " " + electr20 + " " + period20;
//        //    tbD20.Text = DisYear2020 + " - " + totalCountDis20 + " " + totalCostDis20 + " " + naturalDis20 + " " + socialDis20 + " " + humanDis20 + " " + metodicalDis20 + " " + referenceDis20 + " " + artDis20 + " " + printDis20 + " " + electrDis20 + " " + periodDis20;

//        //    tbB21.Text = BeginningOfTheYear21 + " - " + _countBeginingYear21 + " " + _costYear21 + " " + _naturalYear21 + " " + _socialYear21 + " " + _humanYear21 + " " + _metodicalYear21 + " " + _referenceYear21 + " " + _artYear21 + " " + _printYear21 + " " + _electrYear21 + " " + _periodYear21; //на начало года 
//        //    //tbR1K21.Text = Year2021K1 + " - " + totalCount21K1 + " " + totalCost21K1 + " " + natural21K1 + " " + social21K1 + " " + human21K1 + " " + metodical21K1 + " " + reference21K1 + " " + art21K1 + " " + print21K1 + " " + electr21K1 + " " + period21K1;
//        //    tbD1K21.Text = DisYear2021K1 + " - " + totalCountDis21K1 + " " + totalCostDis21K1 + " " + naturalDis21K1 + " " + socialDis21K1 + " " + humanDis21K1 + " " + metodicalDis21K1 + " " + referenceDis21K1 + " " + artDis21K1 + " " + printDis21K1 + " " + electrDis21K1 + " " + periodDis21K1;

//        //    tbB21K2.Text = BeginningOfTheYear21K2 + " - " + _countBeginingYear21K2 + " " + _costYear21K2 + " " + _naturalYear21K2 + " " + _socialYear21K2 + " " + _humanYear21K2 + " " + _metodicalYear21K2 + " " + _referenceYear21K2 + " " + _artYear21K2 + " " + _printYear21K2 + " " + _electrYear21K2 + " " + _periodYear21K2; //на начало года 
//        //    tbR2K21.Text = Q2Title + " - " + totalCountQ2 + " " + totalCostQ2 + " " + naturalQ2 + " " + socialQ2 + " " + humanQ2 + " " + metodicalQ2 + " " + referenceQ2 + " " + artQ2 + " " + printQ2 + " " + electrQ2 + " " + periodQ2;

//        //    tbB21K3.Text = BeginningOfTheYear21K3 + " - " + _countBeginingYear21K3 + " " + _costYear21K3 + " " + _naturalYear21K3 + " " + _socialYear21K3 + " " + _humanYear21K3 + " " + _metodicalYear21K3 + " " + _referenceYear21K3 + " " + _artYear21K3 + " " + _printYear21K3 + " " + _electrYear21K3 + " " + _periodYear21K3; //на начало года 
//        //    tbR3K21.Text = Q3Title + " - " + totalCountQ3 + " " + totalCostQ3 + " " + naturalQ3 + " " + socialQ3 + " " + humanQ3 + " " + metodicalQ3 + " " + referenceQ3 + " " + artQ3 + " " + printQ3 + " " + electrQ3 + " " + periodQ3;
//        //    tbD3K21.Text = DisYear2021K3 + " - " + totalCountDis21K3 + " " + totalCostDis21K3 + " " + naturalDis21K3 + " " + socialDis21K3 + " " + humanDis21K3 + " " + metodicalDis21K3 + " " + referenceDis21K3 + " " + artDis21K3 + " " + printDis21K3 + " " + electrDis21K3 + " " + periodDis21K3;

//        //    tbB21K4.Text = BeginningOfTheYear21K4 + " - " + _countBeginingYear21K4 + " " + _costYear21K4 + " " + _naturalYear21K4 + " " + _socialYear21K4 + " " + _humanYear21K4 + " " + _metodicalYear21K4 + " " + _referenceYear21K4 + " " + _artYear21K4 + " " + _printYear21K4 + " " + _electrYear21K4 + " " + _periodYear21K4; //на начало года 
//        //    tbR4K21.Text = Q4Title + " - " + totalCountQ4 + " " + totalCostQ4 + " " + naturalQ4 + " " + socialQ4 + " " + humanQ4 + " " + metodicalQ4 + " " + referenceQ4 + " " + artQ4 + " " + printQ4 + " " + electrQ4 + " " + periodQ4;
//        //    tbD4K21.Text = DisYear2021K4 + " - " + totalCountDis21K4 + " " + totalCostDis21K4 + " " + naturalDis21K4 + " " + socialDis21K4 + " " + humanDis21K4 + " " + metodicalDis21K4 + " " + referenceDis21K4 + " " + artDis21K4 + " " + printDis21K4 + " " + electrDis21K4 + " " + periodDis21K4;
//        //    tbReceipts21.Text = Title2021 + " - " + totalCount2021 + " " + totalCost2021 + " " + natural2021 + " " + social2021 + " " + human2021 + " " + metodical2021 + " " + reference2021 + " " + art2021 + " " + print2021 + " " + electr2021 + " " + period2021;
//        //    tbDisposals21.Text = DisYear2021 + " - " + totalCountDis2021 + " " + totalCostDis2021 + " " + naturalDis2021 + " " + socialDis2021 + " " + humanDis2021 + " " + metodicalDis2021 + " " + referenceDis2021 + " " + artDis2021 + " " + printDis2021 + " " + electrDis2021 + " " + periodDis2021;

//        //    //tbDisposalsResult.Text = DisposalsResult + " - " + totalCountResult + " " + totalCostResult + " " + naturalResult + " " + socialResult + " " + humanResult + " " + metResult + " " + referResult + " " + artResult + " " + printResult + " " + electrResult + " " + periodResult;

//        //    tbB1K22.Text = BeginningOfTheYear22 + " - " + _countBeginingYear22 + " " + _costYear22 + " " + _naturalYear22 + " " + _socialYear22 + " " + _humanYear22 + " " + _metodicalYear22 + " " + _referenceYear22 + " " + _artYear22 + " " + _printYear22 + " " + _electrYear22 + " " + _periodYear22; //на начало года 
//        //    tbD1K22.Text = DisYear2022K1 + " - " + totalCountDis22K1 + " " + totalCostDis22K1 + " " + naturalDis22K1 + " " + socialDis22K1 + " " + humanDis22K1 + " " + metodicalDis22K1 + " " + referenceDis22K1 + " " + artDis22K1 + " " + printDis22K1 + " " + electrDis22K1 + " " + periodDis22K1;
//        //    tbB2K22.Text = BeginningOfTheYear22K2 + " - " + _countBeginingYear22K2 + " " + _costYear22K2 + " " + _naturalYear22K2 + " " + _socialYear22K2 + " " + _humanYear22K2 + " " + _metodicalYear22K2 + " " + _referenceYear22K2 + " " + _artYear22K2 + " " + _printYear22K2 + " " + _electrYear22K2 + " " + _periodYear22K2; //на начало года 
//        //    tbR2K22.Text = Title22 + " - " + totalCountQ22 + " " + totalCostQ22 + " " + naturalQ22 + " " + socialQ22 + " " + humanQ22 + " " + metodicalQ22 + " " + referenceQ22 + " " + artQ22 + " " + printQ22 + " " + electrQ22 + " " + periodQ22;

//        //    tbB23.Text = BeginningOfTheYear23 + " - " + _countBeginingYear23 + " " + _costYear23 + " " + _naturalYear23 + " " + _socialYear23 + " " + _humanYear23 + " " + _metodicalYear23 + " " + _referenceYear23 + " " + _artYear23 + " " + _printYear23 + " " + _electrYear23 + " " + _periodYear23; //на начало года 
//        //    tbR1K23.Text = Title23 + " - " + totalCountQ23 + " " + totalCostQ23 + " " + naturalQ23 + " " + socialQ23 + " " + humanQ23 + " " + metodicalQ23 + " " + referenceQ23 + " " + artQ23 + " " + printQ23 + " " + electrQ23 + " " + periodQ23;



//    }
//}
