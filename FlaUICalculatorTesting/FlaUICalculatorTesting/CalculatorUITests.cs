using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlaUICalculatorTesting
{
    [TestClass]
    public class CalculatorUITests
    {
        private static CalculatorTester _calculatorTester;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _calculatorTester = new CalculatorTester();
            _calculatorTester.StartCalculator();
        }

        [ClassCleanup]
        public static void TestCleanup()
        {
            _calculatorTester?.CloseCalculator();
        }

        [TestMethod]
        public void TestAdditionOfTwoNumbers()
        {
            int sum = (int)_calculatorTester.Add(2, 3).Add(5).Result();

            Assert.AreEqual(10, sum, "The addition result is incorrect.");
        }

        [TestMethod]
        public void TestSubtractionOfTwoNumbers()
        {
            int result = (int)_calculatorTester.Subtract(5, 3).Result();

            Assert.AreEqual(2, result, "The subtraction result is incorrect.");
        }

        [TestMethod]
        public void TestMultiplicationOfTwoNumbers()
        {
            int product = (int)_calculatorTester.Multiply(3,7).Result();

            Assert.AreEqual(21, product, "The multiplication result is incorrect.");
        }

        [TestMethod]
        public void TestDivisionOfTwoNumbers()
        {
            double divideResult = _calculatorTester.Divide(20,4).Result();

            Assert.AreEqual((double)5, divideResult, "The division result is incorrect.");
        }

        [TestMethod]
        public void TestAdditionWithNegativeNumber()
        {
            double result = _calculatorTester.Add(5, -3).Result();
            Assert.AreEqual(2, result, "The addition with negative number result is incorrect.");
        }

        [TestMethod]
        public void TestSubtractionWithNegativeNumber()
        {
            double result = _calculatorTester.Subtract(5, -3).Result();
            Assert.AreEqual(8, result, "The subtraction with negative number result is incorrect.");
        }

        [TestMethod]
        public void TestMultiplicationWithNegativeNumber()
        {
            double result = _calculatorTester.Multiply(5, -3).Result();
            Assert.AreEqual(-15, result, "The multiplication with negative number result is incorrect.");
        }

        [TestMethod]
        public void TestDivisionWithNegativeNumber()
        {
            double result = _calculatorTester.Divide(5, -2).Result();
            Assert.AreEqual(-2.5, result, "The division with negative number result is incorrect.");
        }

        [TestMethod]
        public void TestComplexCalculation()
        {
            double result = _calculatorTester
                .Add(5, 3)
                .Subtract(2)
                .Multiply(4)
                .Divide(2)
                .Result();
            Assert.AreEqual(12, result, "The complex calculation result is incorrect.");
        }
    }
}
