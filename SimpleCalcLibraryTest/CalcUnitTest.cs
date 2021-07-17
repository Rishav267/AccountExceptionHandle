using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalcLibraryTest
{
    [TestClass]
    public class CalcUnitTest
    {
        [TestMethod]
        //public void SumTest_ValidInput_ValidResult()    //method name include   feature_inputSenario_outputSenario
        //{
        //    //AAA
        //    //A- Arrange  --> means prepare the stage before testing, senario arrangement
        //    int a = 10;
        //    int b = 20;
        //    int expected = 10 + 20;

        //    SimpleCalcLibrary.Calculator target = new SimpleCalcLibrary.Calculator();

        //    // A - Act
        //    int actual = target.Sum(a, b);


        //    // A -  Assert
        //    Assert.AreEqual(expected, actual);

        //}

        //public void SumTest_NegativeInput_ValidResult()  
        //{
        //    int a = -10;
        //    int b = -20;
        //    int expected = -10 + -20;

        //    SimpleCalcLibrary.Calculator target = new SimpleCalcLibrary.Calculator();

        //    // A - Act
        //    int actual = target.Sum(a, b);


        //    // A -  Assert
        //    Assert.AreEqual(expected, actual);

        //}
        //public void Subtract_ValidInput_ValidOutput()
        //{
        //    int a = 10;
        //    int b = 20;
        //    int expect = 10-20;

        //    SimpleCalcLibrary.Calculator subres = new SimpleCalcLibrary.Calculator();

        //    int actual = subres.Subtract(a, b);

        //    Assert.AreEqual(expect, actual);
        //}

        //public void Subtract_NegativeInput_ValidOutput()
        //{
        //    int a = -10;
        //    int b = -20;
        //    int expect = -10 - -20;

        //    SimpleCalcLibrary.Calculator subres = new SimpleCalcLibrary.Calculator();

        //    int actual = subres.Subtract(a, b);

        //    Assert.AreEqual(expect, actual);
        //}

        public void Divide_ValidInput_ValidOutput()
        {
            int a = 10;
            int b = 3;
            double expect = (float) 10 / 3;

            SimpleCalcLibrary.Calculator div = new SimpleCalcLibrary.Calculator();

            double res = div.Divide(a, b);

            Assert.AreEqual(expect, res);
        }

        //public void IsPrime_ValidInput1_ValidOutput()
        //{
        //    int a = 1;
        //    //int b = 10;
        //    bool expect = true;

        //    SimpleCalcLibrary.Calculator div = new SimpleCalcLibrary.Calculator();

        //    bool res = div.IsPrime(a);

        //    Assert.AreEqual(expect, res);
        //}

        //public void IsPrime_ValidInput2_ValidOutput()
        //{
        //    int a = 10;
        //    //int b = 10;
        //    bool expect = false;

        //    SimpleCalcLibrary.Calculator div = new SimpleCalcLibrary.Calculator();

        //    bool res = div.IsPrime(a);

        //    Assert.AreEqual(expect, res);
        //}
    }
}
