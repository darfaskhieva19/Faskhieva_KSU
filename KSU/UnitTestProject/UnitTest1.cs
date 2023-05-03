using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using KSU;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;
using System.Diagnostics.Eventing.Reader;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ChekData_Correctly() // Проверка на заполененные поля
        {
            string a = "Алфавит-центр";
            bool except = true;
            bool actual = WindowAddPlace.checkDataPlace(a);
            Assert.AreEqual(except, actual);
        }

        [TestMethod]
        public void ChekData_NoCorrectly() // Проверка на заполененные поля
        {
            string a = "";
            bool except = false;
            bool actual = WindowAddPlace.checkDataPlace(a);
            Assert.AreEqual(except, actual);
        }

        [TestMethod]
        public void IsCheckData_TypeOfSourceOfReceipts_ResultCorrectly() // Проверка на тип сохранения данных
        {
            string source = "Скрепка";
            bool actual = WindowAddSourceOfReceipts.checkData(source);
            Assert.IsInstanceOfType(actual, typeof(bool));
        }

        [TestMethod]
        public void IsCheckSourceOfReceipts_TypeToStringOfEmail_ResultNoCorrectly()
        {
            string source = "Скрепка";
            bool actual = WindowAddSourceOfReceipts.checkData(source);
            Assert.IsNotInstanceOfType(actual, typeof(string));
        }

        [TestMethod]
        public void IsNotNullDataReceipts_Result()
        {
            string a = "";
            string b = "";
            string c = "";
            string d = "";
            string e = "";
            string h = "";
            string j = "";
            string k = "";
            string l = "";
            bool actual = WindowReceiptsOne.CheckData(a,b,c,d,e,h,j,k,l);
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void IsTrueDataReceipts_Result()
        {
            string a = "21.03.2023";
            string b = "2";
            string c = "Офисмаг";
            string d = "бюджет";
            string e = "0000-023500";
            string h = "15.03.2023";
            string j = "25";
            string k = "25";
            string l = "15550";
            bool actual = WindowReceiptsOne.CheckData(a, b, c, d, e, h, j, k, l);
            Assert.IsTrue(actual);
        }


    }
}
