using FlaUI.Core.AutomationElements;
using FlaUICalculatorTesting.Models;
using System;
using System.Collections.Generic;

namespace FlaUICalculatorTesting.Helper
{
    /// <summary>
    /// This class is responsible for formatting the input for the calculator in terms of buttons.
    /// </summary>
    public class InputFormatter
    {
        private readonly ICalculatorElements _calculator;
        private readonly Dictionary<string, Button> _calculatorButtons;

        /// <summary>
        /// Constructor for InputFormatter accepting an ICalculator instance for extracting button data.
        /// </summary>
        /// <param name="calculator">Calculator instance</param>
        public InputFormatter(ICalculatorElements calculator)
        {
            _calculator = calculator;
            _calculatorButtons = new Dictionary<string, Button>
            {
                { "*", _calculator.ButtonMultiply },
                { "/", _calculator.ButtonDivide },
                { "=", _calculator.ButtonEquals },
                { "1", _calculator.Button1},
                { "2", _calculator.Button2},
                { "3", _calculator.Button3},
                { "4", _calculator.Button4},
                { "5", _calculator.Button5},
                { "6", _calculator.Button6},
                { "7", _calculator.Button7},
                { "8", _calculator.Button8},
                { "9", _calculator.Button9},
                { "0", _calculator.Button0},
                {"+", _calculator.ButtonPlus },
                { "-", _calculator.ButtonMinus },
                {".", _calculator.ButtonDecimal },
                {"CLR", _calculator.ButtonClear }
            };
        }

        /// <summary>
        /// Gets the button for a specific operator.
        /// </summary>
        /// <param name="operator">Operator</param>
        /// <returns>Returns the button corresponding to the operator</returns>
        /// <exception cref="ArgumentException">Throws if the operator is not supported</exception>
        public Button GetOperatorButton(string @operator)
        {
            if (_calculatorButtons.ContainsKey(@operator))
            {
                return _calculatorButtons[@operator];
            }
            else
            {
                throw new ArgumentException($"Operator {@operator} is not supported.");
            }
        }

        /// <summary>
        /// Gets the button for a specific number.
        /// </summary>
        /// <param name="operand">Operand</param>
        /// <returns>Returns the list of buttons corresponding to the number</returns>
        public List<Button> GetNumberButton(double operand)
        {
            List<Button> numberButtonsList = new List<Button>();
            string operandString = operand.ToString();
            for (int i = 0; i < operandString.Length; i++)
            {
                char c = operandString[i];
                if (c == '.')
                {
                    numberButtonsList.Add(_calculator.ButtonDecimal);
                }
                else if (char.IsDigit(c))
                {

                    numberButtonsList.Add(_calculatorButtons[Char.ToString(c)]);
                }
            }
            if(operand < 0)
            {
                numberButtonsList.Add(_calculator.ButtonNegate);
            }
            return numberButtonsList;
        }
    }
}
