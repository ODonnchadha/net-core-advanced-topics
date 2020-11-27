using Advanced.ExceptionHandling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;

namespace NUnitTest.ExceptionHandling
{
    public class ExceptionHandlingShould
    {
        private Calculator calculator;

        [SetUp()]
        public void Setup()
        {
            this.calculator = new Calculator { };
        }

        [Test(), ExpectedException(typeof(System.DivideByZeroException))]
        public void Test()
        {
            Action a = () => calculator.Divide(5, 0);
        }
    }
}
