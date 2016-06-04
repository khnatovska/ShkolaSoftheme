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

namespace UserRegistrationForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterUser(object sender, RoutedEventArgs e)
        {
            if (ValidateInfo())
                validationResult.Text = "User registred successfully";
            else
                validationResult.Text = "Highlighted information is not valid";
            
        }

        private bool ValidateInfo()
        {
            if (ValidateName(firstName, firstNameError) & ValidateName(lastName, lastNameError)
                & ValidateBirthdate(birthDay, birthMonth, birthYear, birthdateError)
                & ValidateGender(genderError)
                & ValidateEmail(email, emailError)
                & ValidatePhoneNumber(phoneNumber, phoneError)
                && ValidateLength(additionalInfo.Text, 2000, required: false))
                return true;
            else
                return false;
        }

        private bool ValidateName(TextBox namebox, TextBlock errorbox)
        {
            if (!ValidateOnlyLetters(namebox.Text))
                {
                errorbox.Text = "only letters";
                namebox.Background = Brushes.PapayaWhip;
                return false;
                }
            else if (!ValidateLength(namebox.Text, 255))
            {
                errorbox.Text = "1 to 255 characters";
                namebox.Background = Brushes.PapayaWhip;
                return false;
            }
            else
            {
                errorbox.Text = string.Empty;
                namebox.Background = null;
                return true;
            }
                
        }

        private bool ValidateBirthdate(TextBox daybox, TextBox monthbox, TextBox yearbox, TextBlock errorbox)
        {
            if (!ValidateOnlyNumbers(new string [] {daybox.Text, monthbox.Text, yearbox.Text}))
            {
                errorbox.Text = "only numbers";
                daybox.Background = Brushes.PapayaWhip;
                monthbox.Background = Brushes.PapayaWhip;
                yearbox.Background = Brushes.PapayaWhip;
                return false;
            }
            else if ((!ValidateNumber(daybox.Text, 32)) || (!ValidateNumber(monthbox.Text, 13)) || (!ValidateYear(yearbox.Text)))
            {
                errorbox.Text = "max 31 days, 12 months, 1900 to current year";
                daybox.Background = Brushes.PapayaWhip;
                monthbox.Background = Brushes.PapayaWhip;
                yearbox.Background = Brushes.PapayaWhip;
                return false;
            }
            else
            {
                errorbox.Text = string.Empty;
                daybox.Background = null;
                monthbox.Background = null;
                yearbox.Background = null;
                return true;
            }
        }

        private bool ValidateEmail(TextBox emailbox, TextBlock errorbox)
        {
            if (!emailbox.Text.Contains("@"))
            {
                errorbox.Text = "invalid email";
                emailbox.Background = Brushes.PapayaWhip;
                return false;
            }
            else if (!ValidateLength(emailbox.Text, 255))
            {
                errorbox.Text = "max 255 characters";
                emailbox.Background = Brushes.PapayaWhip;
                return false;
            }
            else
            {
                errorbox.Text = string.Empty;
                emailbox.Background = null;
                return true;
            }
        }

        private bool ValidateGender(TextBlock errorbox)
        {
            if (maleRadio.IsChecked == true || femaleRadio.IsChecked == true)
            {
                errorbox.Text = string.Empty;
                return true;
            }                
            else
            {
                errorbox.Text = "select gender";
                return false;
            }
        }

        private bool ValidatePhoneNumber(TextBox phonebox, TextBlock errorbox)
        {
            if ((!ValidateOnlyNumbers(phonebox.Text)) || (!ValidateExactLength(phonebox.Text, 12)))
            {
                errorbox.Text = "12 digits";
                phonebox.Background = Brushes.PapayaWhip;
                return false;
            }
            else
            {
                errorbox.Text = string.Empty;
                phonebox.Background = null;
                return true;
            }
        }

        private bool ValidateAdditionalInfo(TextBox addInfo, TextBlock errorbox)
        {
            if (!ValidateLength(addInfo.Text, 2000))
            {
                errorbox.Text = "max 2000 characters";
                addInfo.Background = Brushes.PapayaWhip;
                return false;
            }
            else
            {
                errorbox.Text = string.Empty;
                addInfo.Background = null;
                return true;
            }
        }

        //Helper Validation Mathods

        private bool ValidateLength(string input, int maxLength, bool required = true)
        {
            var minLength = 1;
            if (!required)
                minLength = 0;
            if ((input.Length >= minLength) && (input.Length < maxLength))
                return true;
            else
                return false;
        }

        private bool ValidateExactLength(string input, int length)
        {
            if (input.Length == length)
                return true;
            else
                return false;
        }

        private bool ValidateOnlyLetters(string input)
        {
            if (input.All(Char.IsLetter))
                return true;
            else
                return false;
        }

        private bool ValidateOnlyNumbers(string input)
        {
            if (input.All(Char.IsNumber))
                return true;
            else
                return false;
        }

        private bool ValidateOnlyNumbers(string[] inputArr)
        {
            foreach (string input in inputArr)
            {
                if (!ValidateOnlyNumbers(input))
                    return false;
            }
            return true;
        }

        

        private bool ValidateNumber(string input, int maxValue, int minValue = 0)
        {

            var intInput = 0;
            int.TryParse(input, out intInput);
            if ((intInput > minValue) && (intInput < maxValue))
                return true;
            else
                return false;
        }

        private bool ValidateYear(string input, int minValue = 1900)
        {
            var intInput = 0;
            int.TryParse(input, out intInput);
            var currentYear = DateTime.Today.Year;
            if ((intInput > minValue) && (intInput < currentYear))
                return true;
            else
                return false;
        }

    }
}
