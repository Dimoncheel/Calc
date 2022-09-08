using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcProject.App;
using System;
namespace CalcTest
{
    [TestClass]
    public class AppTest
    {
        [TestMethod]
        public void TestCalc()
        {
            CalcProject.App.Calc calc = new();
            Assert.IsNotNull(calc);
        }
        //aaalllallaaaallaaaaa mira
        [TestMethod]
        public void TestRomanPArse()
        {
            //Assert.AreEqual(RomanNumber.Parse("II"), 2);
            //Assert.AreEqual(RomanNumber.Parse("IV"), 4);
            //Assert.AreEqual(RomanNumber.Parse("IX"), 9);
            //Assert.AreEqual(RomanNumber.Parse("XV"), 15);
            //Assert.AreEqual(RomanNumber.Parse("XX"), 20);
            //Assert.AreEqual(RomanNumber.Parse("XL"), 40);
            //Assert.AreEqual(RomanNumber.Parse("XC"), 90);
            //Assert.AreEqual(RomanNumber.Parse("CX"), 110);
            //Assert.AreEqual(RomanNumber.Parse("CD"), 400);
            //Assert.AreEqual(RomanNumber.Parse("CM"), 900);
            //Assert.AreEqual(RomanNumber.Parse("MM"), 2000);

            Assert.AreEqual(RomanNumber.Parse("I"), 1, "I == 1");
            Assert.AreEqual(RomanNumber.Parse("IV"), 4, "IV == 4");
            Assert.AreEqual(RomanNumber.Parse("XV"), 15);
            Assert.AreEqual(RomanNumber.Parse("XXX"), 30);
            Assert.AreEqual(RomanNumber.Parse("CM"), 900);
            Assert.AreEqual(RomanNumber.Parse("MCMXCIX"), 1999);
            Assert.AreEqual(RomanNumber.Parse("CD"), 400);
            Assert.AreEqual(RomanNumber.Parse("CDI"), 401);
            Assert.AreEqual(RomanNumber.Parse("LV"), 55);
            Assert.AreEqual(RomanNumber.Parse("XL"), 40);
        }
        [TestMethod]
        public void TestRomanParseException()
        {
            Assert.ThrowsException<ArgumentException>(
                () => RomanNumber.Parse("0"));
        }

        [TestMethod]
        public void TestRomanParseExceptN()
        {
            Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                () => RomanNumber.Parse("XN")).Message.StartsWith("Invalid digit"));
        }

        [TestMethod]
        public void TestRomanParseEmpty()
        {
            Assert.AreEqual(Assert.ThrowsException<ArgumentException>(
                () => RomanNumber.Parse("")).Message, "String is empty");
        }

        [TestMethod]
        public void TestRomanParseNull()
        {
            Assert.AreEqual(Assert.ThrowsException<ArgumentException>(
                () => RomanNumber.Parse(null)).Message, "String was null");
        }

        [TestMethod]
        public void TestRomanParseNegative()
        {
            Assert.AreEqual(RomanNumber.Parse("-IV"), -4);
            Assert.AreEqual(RomanNumber.Parse("-XL"), -40);
            Assert.AreEqual(RomanNumber.Parse("-CM"), -900);
        }

        [TestMethod]
        public void TestRomanToStringNegative()
        {
            RomanNumber number = new RomanNumber(-4);
            Assert.AreEqual("-IV", number.ToString());
            number.Val = -40;
            Assert.AreEqual("-XL", number.ToString());
            number.Val = -900;
            Assert.AreEqual("-CM", number.ToString());
        }
    }
}