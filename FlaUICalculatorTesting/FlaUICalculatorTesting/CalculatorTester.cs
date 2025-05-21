using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.UIA3;
using FlaUICalculatorTesting.Helper;
using FlaUICalculatorTesting.Models;
using System;
using System.Collections.Generic;

namespace FlaUICalculatorTesting
{
    /// <summary>
    /// This class is responsible for testing the calculator application.
    /// </summary>
    /// <remarks>
    /// This class provides methods to perform basic arithmetic operations using the calculator.
    /// </remarks>
    /// </summary>
    public class CalculatorTester
    {
        private ICalculatorElements _calculator;
        private UIA3Automation _automation;
        private Application _application;
        private AutomationElement _mainWindow;
        private double _currentResult;
        private InputFormatter _inputFormatter;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorTester"/> class. Starts the calculator application.
        /// </summary>
        /// <exception cref="Exception">Thrown when the calculator application is not running.</exception>
        public void StartCalculator()
        {
            _application = Application.LaunchStoreApp("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            _automation = new UIA3Automation();
            _application.WaitWhileBusy();
            if (_application == null)
            {
                throw new Exception("Calculator application is not running.");
            }
            _mainWindow = _application.GetMainWindow(_automation);
            _calculator = new Windows11CalculatorElements(_mainWindow);
            _inputFormatter = new InputFormatter(_calculator);
        }

        /// <summary>
        /// Performs an addition operation on the calculator.
        /// </summary>
        /// <param name="operand1">First Operand</param>
        /// <param name="operand2">Second Operand if any/param>
        /// <returns>Returns the current instance of CalculatorTester containing the result of the operation.</returns>
        public CalculatorTester Add(int operand1, int? operand2 = null)
        {
            return PerformOperation(operand1, operand2, _calculator.ButtonPlus);
        }

        /// <summary>
        /// Performs a subtraction operation on the calculator.
        /// </summary>
        /// <param name="operand1">Operand1</param>
        /// <param name="operand2">Operand2 if any</param>
        /// <returns>Returns the current instance of CalculatorTester containing the result of the operation.</returns>
        public CalculatorTester Subtract(int operand1, int? operand2 = null)
        {
            return PerformOperation(operand1, operand2, _calculator.ButtonMinus);
        }

        /// <summary>
        /// Performs a multiplication operation on the calculator.
        /// </summary>
        /// <param name="operand1">Operand1</param>
        /// <param name="operand2">Operand2 if any</param>
        /// <returns>Returns the current instance of CalculatorTester containing the result of the operation.</returns>
        public CalculatorTester Multiply(int operand1, int? operand2 = null)
        {
            return PerformOperation(operand1, operand2, _calculator.ButtonMultiply);
        }

        /// <summary>
        /// Performs a division operation on the calculator.
        /// </summary>
        /// <param name="operand1">Operand1</param>
        /// <param name="operand2">Operand2 if any</param>
        /// <returns>Returns the current instance of CalculatorTester containing the result of the operation.</returns>
        public CalculatorTester Divide(int operand1, int? operand2 = null)
        {
            return PerformOperation(operand1, operand2, _calculator.ButtonDivide);
        }


        /// <summary>
        /// Returns the result of the last operation performed on the calculator.
        /// </summary>
        /// <returns>Returns the result of the last operation.</returns>
        public double Result()
        {
            return _currentResult;
        }

        /// <summary>
        /// Closes the calculator application and disposes of the automation instance.
        /// </summary>
        public void CloseCalculator()
        {
            _application.Close();
            _automation.Dispose();
        }

        private CalculatorTester PerformOperation(int operand1, int? operand2, Button operatorButton)
        {
            if (operand2.HasValue)
            {
                Clear();
                EnterNumber(operand1);
                operatorButton.Click();
                EnterNumber(operand2.Value);
            }
            else
            {
                operatorButton.Click();
                EnterNumber(operand1);
            }
            _calculator.ButtonEquals.Click();
            _currentResult = ReadDisplay();
            return this;
        }

        private void EnterNumber(double number)
        {
            List<Button> listOfButtons = _inputFormatter.GetNumberButton(number);
            foreach (Button button in listOfButtons)
            {
                button.Click();
            }
        }

        private void Clear()
        {
            _calculator.ButtonClear.Click();
        }

        private double ReadDisplay()
        {
            // Assumes the display text is always a valid integer
            var text = _calculator.ResultText;
            double value;
            if (double.TryParse(text, out value))
                return value;
            throw new InvalidOperationException("Could not parse calculator display: " + text);
        }
    }
}