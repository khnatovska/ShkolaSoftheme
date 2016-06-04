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

namespace Zodiac_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<int, SignPair> SignsDict;

        public MainWindow()
        {
            InitializeComponent();
            SetMaxDate();
            SignsDict = ConstructSignsDict();
        }

        private void SetMaxDate()
        {
            BirthdatePicker.DisplayDateEnd = DateTime.Today;
        }

        static Dictionary<int, SignPair> ConstructSignsDict()
        {
            var signs = new Dictionary<int, SignPair> {
            { 1, new SignPair("Capricorn", "Aquarius", 19) },
            { 2, new SignPair("Aquarius", "Pisces", 18) },
            { 3, new SignPair("Pisces", "Aries", 20) },
            { 4, new SignPair("Aries", "Taurus", 19) },
            { 5, new SignPair("Taurus", "Gemini", 20) },
            { 6, new SignPair("Gemini", "Cancer", 20) },
            { 7, new SignPair("Cancer", "Leo", 22) },
            { 8, new SignPair("Leo", "Virgo", 22) },
            { 9, new SignPair("Virgo", "Libra", 22) },
            { 10, new SignPair("Libra", "Scorpio", 22) },
            { 11, new SignPair("Scorpio", "Sagittarius", 21) },
            { 12, new SignPair("Sagittarius", "Capriconr", 21) },
            };
            return signs;

        }

        private void DetermineSignAndAge(object sender, RoutedEventArgs e)
        {
            if (BirthdatePicker.SelectedDate == null) 
                return;
            else
            {
                var birthdate = BirthdatePicker.SelectedDate ?? new DateTime();
                var age = DetermineAge(birthdate);
                var sign = DetermineZodiacSign(birthdate, SignsDict);
                Age.Text = age.ToString();
                Sign.Text = sign.ToString();
                //PrepareImage();
                SignImage.Source = new BitmapImage(new Uri(@".\img\leo.png", UriKind.Relative));
             }
        }

        static int DetermineAge(DateTime birthdate)
        {
            var age = DateTime.Today.Year - birthdate.Year;
            var months = DateTime.Today.Month - birthdate.Month;
            if (months == 0)
            {
                var days = DateTime.Today.Day - birthdate.Day;
                if (days < 0)
                {
                    return age -= 1;
                }
            }
            else if (months < 0)
            {
                return age -= 1;
            }

            return age;
        }

        static string DetermineZodiacSign(DateTime birthdate, Dictionary<int, SignPair> signsDict)
        {
            string zodiacSign;
            var signsPair = signsDict[birthdate.Month];
            zodiacSign = birthdate.Day <= signsPair.lastDayOfFirstSign ? signsPair.firstSign : signsPair.secondSign;
            return zodiacSign;
        }

        private void PrepareImage()
        {
            SignImage.Source = new BitmapImage(new Uri(@".\img\leo.png", UriKind.Relative));
            
            //SignImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/Zodiac WPF;component/leo.png", UriKind.Relative));
        }
    }
}
