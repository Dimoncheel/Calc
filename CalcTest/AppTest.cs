using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcProject.App;
using System;
namespace CalcTest
{
    [TestClass]
    public class AppTest
    {
        private Resources Resources = new Resources();

        public AppTest()
        {
            RomanNumber.Resources = Resources;
        }

        [TestMethod]
        public void TestCalc()
        {
            CalcProject.App.Calc calc = new(Resources);
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
                () => RomanNumber.Parse("XNN")).Message.StartsWith(Resources.InvalidDigitMessage('\0')[..12]));

            Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
               () => RomanNumber.Parse("XN")).Message.StartsWith(Resources.InvalidDigitMessage('\0')[..12]));
        }

        [TestMethod]
        public void TestRomanParseZero()
        {
            Assert.AreEqual(0, RomanNumber.Parse("N"));
        }

            [TestMethod]
        public void TestRomanParseEmpty()
        {
            Assert.AreEqual(Assert.ThrowsException<ArgumentException>(
                () => RomanNumber.Parse("")).Message, Resources.EmptyStringMessage());
        }

        [TestMethod]
        public void TestRomanParseNull()
        {
            Assert.AreEqual(Assert.ThrowsException<ArgumentException>(
                () => RomanNumber.Parse(null)).Message, Resources.EmptyStringMessage());
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

    [TestClass]
    public class OperationsTest
    {
        private Resources Resources = new Resources();

        public OperationsTest()
        {
            RomanNumber.Resources = Resources;
        }
        [TestMethod]
        public void AddTest()
        {
            RomanNumber rn2 = new(2);
            RomanNumber rn3 = new(3);
            RomanNumber rn5 = new(5);
            Assert.AreEqual(5, rn2.Add(rn3).Val);
            Assert.AreEqual("V", rn2.Add(rn3).ToString());
            Assert.AreEqual(rn5.Val, rn2.Add(rn3).Val);
            Assert.AreEqual(new RomanNumber(-5).Val,new RomanNumber(-3).Add(new RomanNumber(-2)).Val);
            Assert.AreEqual(0,new RomanNumber(3).Add(new RomanNumber(-3)).Val);
            Assert.AreEqual(4,rn2.Add(rn2).Val);
            Assert.AreEqual(4,rn2.Add(new RomanNumber(2)).Val);
            Assert.ThrowsException<ArgumentNullException>(
               () =>new RomanNumber(10).Add((RomanNumber)null!)).Message.StartsWith("Digit was null");
            Assert.AreEqual(6, rn2.Add(4).Val);
            Assert.AreEqual(5, rn2.Add(3).Val);
            Assert.AreEqual(4, rn2.Add(2).Val);
        }
        [TestMethod]
        public void AddStringTest()
        {
            RomanNumber n2 = new(2);
            RomanNumber n3 = new(3);
            RomanNumber n5 = new(5);
            RomanNumber n5_1 = new(5);
            RomanNumber n0 = new(0);
            Assert.AreEqual(n3.Val, n2.Add("I").Val);
            Assert.AreEqual(n3.Val, n5.Add("-II").Val);
            Assert.AreEqual(n5.Val, n2.Add("III").Val);
            Assert.AreEqual(n5_1.Val, n5.Add("N").Val);
            Assert.AreEqual(n5_1.Val, n0.Add("V").Val);
            var test = Assert.ThrowsException<ArgumentNullException>(
                 () => n2.Add((string)null)
             ).Message;
            Assert.IsTrue(test.Contains(Resources.ArgumentNullMessage()));
        }
        [TestMethod]
        public void AddStaticTest()
        {
            Assert.AreEqual(10, RomanNumber.Add("V", "V").Val);
            Assert.AreEqual(10, RomanNumber.Add(5, 5).Val);
            Assert.AreEqual(10, RomanNumber.Add("V", 5).Val);
            Assert.AreEqual(10, RomanNumber.Add(new RomanNumber(5), "V").Val);
            Assert.AreEqual(10, RomanNumber.Add(new RomanNumber(5), 5).Val);
            Assert.AreEqual(10, RomanNumber.Add(new RomanNumber(5), new RomanNumber(5)).Val);
        }

        [TestMethod]
        public void AddObjecTest()
        {
            Assert.AreEqual(10, RomanNumber.Add("V", "V").Val);
            Assert.AreEqual(10, RomanNumber.Add(5, 5).Val);
            Assert.AreEqual(10, RomanNumber.Add("V", 5).Val);
            Assert.AreEqual(10, RomanNumber.Add(new RomanNumber(5), "V").Val);
            Assert.AreEqual(10, RomanNumber.Add(new RomanNumber(5), 5).Val);
            Assert.AreEqual(10, RomanNumber.Add(new RomanNumber(5), new RomanNumber(5)).Val);
        }
    }

}