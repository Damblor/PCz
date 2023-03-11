using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab__7
{
    public enum Operands
    {
        ADDITION,
        SUBTRACTION,
        DIVISION,
        MULTIPLICATION,
        POWER,
        NULL // Represents no operation (used to reset the status)
    }

    public enum Errors
    {
        OVERFLOW,
        INVALID_INPUT,
        NaN
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int defaultFontSize = 48;
        bool operationCheck, functionCheck, clearNext, isResult, isOldText;
        string previousText;

        Operands currentOperation = Operands.NULL;

        static string OVERFLOW = "Overflow";
        static string INVALID_INPUT = "Invalid input";
        static string NOT_A_NUMBER = "NaN";
        string[] errors = { OVERFLOW, INVALID_INPUT, NOT_A_NUMBER };
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowText(string text, bool clear = true)
        {
            try
            {
                if (double.Parse(text) == 0)
                    text = "0";
            }
            catch (Exception)
            {
                ShowError(INVALID_INPUT);
                return;
            }

            if (text.Length > 30)
                return;
            if (text.Length > 12)
                resultTextField.FontSize = 25;
            if (text.Length > 24)
                resultTextField.FontSize = 20;

            clearNext = clear;
            resultTextField.Text = text;
        }

        private void ShowError(string text)
        {
            resultTextField.Text = text;
            previousText = null;
            operationCheck = false;
            clearNext = true;
            UpdateEquationBox("");
            currentOperation = Operands.NULL;
            ResetFontSize();
        }

        private void UpdateEquationBox(string equation, bool append = false)
        {
            equation = Regex.Replace(equation, @"(\d+)\.\s", "$1 ");

            if (equation.Length > 10)
                equalitionTextField.FontSize = 18;

            if (!append)
                equalitionTextField.Text = equation;
            else
                equalitionTextField.Text += equation;
        }

        private double GetNumber()
        {
            double number = double.Parse(resultTextField.Text);
            return number;
        }

        private void ResetFontSize()
        {
            resultTextField.FontSize = defaultFontSize;
        }

        private void CalculateResult()
        {
            if (currentOperation == Operands.NULL)
                return;

            double a = double.Parse(previousText);
            double b = double.Parse(resultTextField.Text);
            double result;

            switch (currentOperation)
            {
                case Operands.DIVISION:
                    result = a / b;
                    break;
                case Operands.MULTIPLICATION:
                    result = a * b;
                    break;
                case Operands.ADDITION:
                    result = a + b;
                    break;
                case Operands.SUBTRACTION:
                    result = a - b;
                    break;
                case Operands.POWER:
                    result = Math.Pow(a, b);
                    break;
                default:
                    return;
            }

            if (errors.Contains(resultTextField.Text))
                return;

            operationCheck = false;
            previousText = null;
            string equation;
            if (!functionCheck)
                equation = equalitionTextField.Text + b.ToString();
            else
            {
                equation = equalitionTextField.Text;
                functionCheck = false;
            }
            UpdateEquationBox(equation);
            ShowText(result.ToString());
            currentOperation = Operands.NULL;
            isResult = true;
        }

        private void NumberClick(object sender, RoutedEventArgs e)
        {
            isResult = false;
            Button button = (Button)sender;

            if (resultTextField.Text == "0" || errors.Contains(resultTextField.Text))
                resultTextField.Clear();

            string text;

            if (clearNext)
            {
                ResetFontSize();
                text = button.Content.ToString();
                isOldText = false;
            }
            else
                text = resultTextField.Text + button.Content.ToString();

            if (!operationCheck && equalitionTextField.Text != "")
                UpdateEquationBox("");
            ShowText(text, false);
        }

        private void Function(object sender, RoutedEventArgs e)
        {
            if (errors.Contains(resultTextField.Text))
                return;

            Button button = (Button)sender;
            string buttonText = button.Content.ToString();
            double number = GetNumber();
            string equation = "";
            string result = "";

            switch (buttonText)
            {
                case "log":
                    equation = "log(" + number + ")";
                    result = Math.Log10(number).ToString();
                    break;

                case "√":
                    equation = "√(" + number + ")";
                    result = Math.Sqrt(number).ToString();
                    break;

                case "+/-":
                    equation = "neg(" + number + ")";
                    result = decimal.Negate((decimal)number).ToString();
                    break;
            }

            if (operationCheck)
            {
                equation = equalitionTextField.Text + equation;
                functionCheck = true;
            }

            UpdateEquationBox(equation);
            ShowText(result);
        }

        private void TrigFunction(object sender, RoutedEventArgs e)
        {
            if (errors.Contains(resultTextField.Text))
                return;

            Button button = (Button)sender;
            string buttonText = button.Content.ToString();
            string equation = "";
            double result = 0;
            double number = GetNumber();

            var angle = number * (Math.PI / 180);
            switch (buttonText)
            {
                case "sin":
                    equation = "sin(" + number + ")";
                    result = Math.Sin(angle);
                    break;

                case "cos":
                    equation = "cos(" + number + ")";
                    result = Math.Cos(angle);
                    break;

                case "tan":
                    equation = "tan(" + number + ")";
                    result = Math.Tan(angle);
                    break;

                case "cotan":
                    equation = "1/tan(" + number + ")";
                    result = 1 / Math.Tan(angle);
                    break;
            }

            if (operationCheck)
            {
                equation = equalitionTextField.Text + equation;
                functionCheck = true;
            }

            result = Math.Round(result, 15);
            UpdateEquationBox(equation);
            ShowText(result.ToString());

        }

        private void DoubleOperandFunction(object sender, RoutedEventArgs e)
        {
            if (errors.Contains(resultTextField.Text))
                return;

            if (operationCheck && !isOldText)
                CalculateResult();

            Button button = (Button)sender;

            operationCheck = true;
            previousText = resultTextField.Text;
            string buttonText = button.Content.ToString();
            switch (buttonText)
            {
                case "÷":
                    currentOperation = Operands.DIVISION;
                    break;
                case "×":
                    currentOperation = Operands.MULTIPLICATION;
                    break;
                case "-":
                    currentOperation = Operands.SUBTRACTION;
                    break;
                case "+":
                    currentOperation = Operands.ADDITION;
                    break;
                case "xʸ":
                    currentOperation = Operands.POWER;
                    buttonText = "^";
                    break;
            }
            string equation = previousText + " " + buttonText + " ";

            UpdateEquationBox(equation);
            ResetFontSize();
            ShowText(resultTextField.Text);
            isOldText = true;
        }

        private void Decimal_button_Click(object sender, RoutedEventArgs e)
        {
            if (!resultTextField.Text.Contains(","))
            {
                string text = resultTextField.Text += ",";
                ShowText(text, false);
            }
        }

        private void Pi_button_Click(object sender, RoutedEventArgs e)
        {
            if (!operationCheck)
                UpdateEquationBox("");
            ShowText(Math.PI.ToString());
            isResult = true;
        }

        private void Clear_button_Click(object sender, RoutedEventArgs e)
        {
            resultTextField.Text = "0";
            operationCheck = false;
            previousText = null;
            UpdateEquationBox("");
            ResetFontSize();
        }

        private void Equals_button_Click(object sender, RoutedEventArgs e)
        {
            CalculateResult();
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            if (isResult)
                return;

            string text;

            if (resultTextField.Text.Length == 1)
                text = "0";
            else
                text = resultTextField.Text.Substring(0, resultTextField.Text.Length - 1);

            ShowText(text, false);

        }
    }
}
