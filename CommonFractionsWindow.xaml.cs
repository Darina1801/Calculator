using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
	/// <summary>
	/// Interaction logic for CommonFractionsWindow.xaml
	/// </summary>
	public partial class CommonFractionsWindow : Window
	{
		string leftOperand = "";
		string operation = "";
		string rightOperand = "";
		MainWindow mainWindow;

		public CommonFractionsWindow()
		{
			InitializeComponent();
			ButtonsHandler();
		}

		private void ButtonsHandler()
		{
			foreach (UIElement uiElement in LayoutRoot.Children)
			{
				if (uiElement is Button)
				{
					((Button)uiElement).Click += ButtonClick;
				}
			}
		}

		private void ButtonClick(object sender, RoutedEventArgs routedEventArgs)
		{
			string calcInput = (string)((Button)routedEventArgs.OriginalSource).Content;
			textBlock.Text += calcInput;
			double num;
			bool calcInputNum = Double.TryParse(calcInput, out num);
			if (calcInputNum == true)
			{
				if (operation == "")
				{
					leftOperand += calcInput;
				}
				else rightOperand += calcInput;
			}
			else
			{
				if (calcInput == "=")
				{
					if (operation == "/" && rightOperand == "0")
					{
						textBlock.Text = "";
						textBlock.Text += "You can't divide by 0";
					}
					else
					{
						UpdateRightOperand();
						textBlock.Text += rightOperand;
						operation = "";
					}
				}
				else if (calcInput == "CLEAR")
				{
					leftOperand = "";
					rightOperand = "";
					operation = "";
					textBlock.Text = "";
				}
				else
				{
					if (rightOperand != "")
					{
						UpdateRightOperand();
						leftOperand = rightOperand;
						rightOperand = "";
					}
					operation = calcInput;
				}
			}
		}

		private void SwitchToCommonCalculator(object sender, RoutedEventArgs routedEventArgs)
		{
			mainWindow = new MainWindow();
			mainWindow.Show();
			this.Close();
		}

		private void UpdateRightOperand()
		{
			double num1 = Int32.Parse(leftOperand);
			double num2 = Int32.Parse(rightOperand);

			switch (operation)
			{
				case "+":
					rightOperand = (num1 + num2).ToString();
					break;
				case "-":
					rightOperand = (num1 - num2).ToString();
					break;
				case "*":
					rightOperand = (num1 * num2).ToString();
					break;
				case "/":
					rightOperand = (num1 / num2).ToString();
					break;
			}
		}
	}
}