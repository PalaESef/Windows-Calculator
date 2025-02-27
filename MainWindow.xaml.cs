using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Windows_Calculator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private double firstNumber = 0;
    private string operation = "";
    private bool isNewEntry = true;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void Maximize_Click(object sender, RoutedEventArgs e)
    {
        if (this.WindowState == WindowState.Normal)
            this.WindowState = WindowState.Maximized;
        else
            this.WindowState = WindowState.Normal;
    }

    private void Minimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void Equals_Click(object sender, RoutedEventArgs e)
    {

        double secondNumber = double.Parse(Display.Text);
        double result = 0;

        switch (operation)
        {
            case "+":
                result = firstNumber + secondNumber;
                break;
            case "−":
                result = firstNumber - secondNumber;
                break;
            case "×":
                result = firstNumber * secondNumber;
                break;
            case "÷":
                if (secondNumber != 0)
                    result = firstNumber / secondNumber;
                else
                {
                    Display.Text = "Error";
                    return;
                }
                break;
        }

        Display.Text = result.ToString();
        isNewEntry = true;
    }

    private void Operator_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        if (button != null)
        {
            firstNumber = double.Parse(Display.Text);
            operation = button.Content.ToString();
            Display.Text = "0"; // Clear display for second number
        }
    }

    private void Number_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        if (button != null)
        {
            if (Display.Text == "0" || operation == "=")
                Display.Text = button.Content.ToString();
            else
                Display.Text += button.Content.ToString();
        }
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        Display.Text = "0";
        firstNumber = 0;
        operation = "";
        isNewEntry = true;
    }
}