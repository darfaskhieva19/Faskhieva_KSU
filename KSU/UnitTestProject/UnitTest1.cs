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


    }
}
