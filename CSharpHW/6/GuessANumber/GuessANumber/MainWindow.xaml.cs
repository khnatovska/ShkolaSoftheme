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

namespace GuessANumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int RandomNumber { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Run();
        }

        public void Run()
        {
            RandomNumber = GenerateNumber();
            
        }

        public int GenerateNumber()
        {
            return new Random().Next(1, 11);
        }

        private void GuessNumber(object sender, RoutedEventArgs e)
        {
            try
            {
                if (guessBox.Text.Length <= 0)
                {
                    throw new InvalidOperationException("Number not entered");
                }
                var guess = int.Parse(guessBox.Text);
                if (RandomNumber == guess)
                {
                    result.Text = "Success!";
                }
                else if ((guess < 1) || (guess > 10))
                {
                    throw new InvalidOperationException("Number must be between 1 and 10");
                }
                else
                {
                    result.Text = "Number was " + RandomNumber.ToString();
                }
            }
            catch (InvalidOperationException ex)
            {
                result.Text = ex.Message;
            }
            catch (FormatException ex)
            {
                result.Text = ex.Message;
            }
            catch (Exception ex)
            {
                result.Text = ex.Message;
            }
            Run();
        }
        
    }
}
