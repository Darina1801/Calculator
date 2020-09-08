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
		string leftOperand = "";
		string operation = "";
		string rightOperand = "";

		public MainWindow()
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
					((Button)uiElement).Click += Button_Click;
				}
			}
		}

		private void Button_Click(object sender, RoutedEventArgs routedEventArgs)
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
