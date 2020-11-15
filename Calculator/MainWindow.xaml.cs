using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        selectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();

            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalButton.Click += EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case selectedOperator.Addition:
                        result = simpleMath.Add(lastNumber, newNumber);
                        break;
                    case selectedOperator.Sustraction:
                        result = simpleMath.Sustract(lastNumber, newNumber);
                        break;
                    case selectedOperator.Multiplication:
                        result = simpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case selectedOperator.Division:
                        result = simpleMath.Divide(lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();

            }

        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = tempNumber / 100;

                if(lastNumber != 0)
                {
                    tempNumber *= lastNumber;
                }

                resultLabel.Content = tempNumber.ToString();

            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();

            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }

        private void operationButton_click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == multiplicationButton)
                selectedOperator = selectedOperator.Multiplication;
            if (sender == divisionButton)
                selectedOperator = selectedOperator.Division;
            if (sender == additionButton)
                selectedOperator = selectedOperator.Addition;
            if (sender == sustractionButton)
                selectedOperator = selectedOperator.Sustraction;
        }

        private void pointButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {
                //do nothing
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == zeroButton)
                selectedValue = 0;
            if (sender == oneButton)
                selectedValue = 1;
            if (sender == twoButton)
                selectedValue = 2;
            if (sender == threeButton)
                selectedValue = 3;
            if (sender == fourButton)
                selectedValue = 4;
            if (sender == fiveButton)
                selectedValue = 5;
            if (sender == sixButton)
                selectedValue = 6;
            if (sender == sevenButton)
                selectedValue = 7;
            if (sender == eightButton)
                selectedValue = 8;
            if (sender == nineButton)
                selectedValue = 9;

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
    }

    public enum selectedOperator
    {
        Addition,
        Sustraction,
        Multiplication,
        Division
    }

    public class simpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Sustract(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Divide(double n1, double n2)
        {
            if(n2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            return n1 / n2;
        }
    }
}
