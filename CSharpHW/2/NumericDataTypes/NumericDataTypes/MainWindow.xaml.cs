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

namespace NumericDataTypes
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

        private void NumericTypeSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (numericType.SelectedItem as ListBoxItem);
            switch (selectedItem.Content.ToString())
            {
                case "byte":
                    ShowByteValues();
                    break;
                case "sbyte":
                    ShowSByteValues();
                    break;
                case "short":
                    ShowShortValues();
                    break;
                case "ushort":
                    ShowUShortValues();
                    break;
                case "int":
                    ShowIntValues();
                    break;
                case "uint":
                    ShowUIntValues();
                    break;
                case "long":
                    ShowLongValues();
                    break;
                case "ulong":
                    ShowULongValues();
                    break;
                case "float":
                    ShowFloatValues();
                    break;
                case "double":
                    ShowDoubleValues();
                    break;
                case "decimal":
                    ShowDecimalValues();
                    break;
            }
        }

        private void ShowDecimalValues()
        {
            decimal decimalValue = default(decimal);
            defaultValue.Text = decimalValue.ToString();
            minValue.Text = decimal.MinValue.ToString();
            maxValue.Text = decimal.MaxValue.ToString();
        }

        private void ShowDoubleValues()
        {
            double doubleValue = default(double);
            defaultValue.Text = doubleValue.ToString();
            minValue.Text = double.MinValue.ToString();
            maxValue.Text = decimal.MaxValue.ToString();
        }

        private void ShowFloatValues()
        {
            float floatValue = default(float);
            defaultValue.Text = floatValue.ToString();
            minValue.Text = float.MinValue.ToString();
            maxValue.Text = float.MaxValue.ToString();
        }

        private void ShowULongValues()
        {
            ulong uLongValue = default(ulong);
            defaultValue.Text = uLongValue.ToString();
            minValue.Text = ulong.MinValue.ToString();
            maxValue.Text = ulong.MaxValue.ToString();
        }

        private void ShowLongValues()
        {
            long longValue = default(long);
            defaultValue.Text = longValue.ToString();
            minValue.Text = long.MinValue.ToString();
            maxValue.Text = long.MaxValue.ToString();
        }

        private void ShowUIntValues()
        {
            uint uIntValue = default(uint);
            defaultValue.Text = uIntValue.ToString();
            minValue.Text = uint.MinValue.ToString();
            maxValue.Text = uint.MaxValue.ToString();
        }

        private void ShowIntValues()
        {
            int intValue = default(int);
            defaultValue.Text = intValue.ToString();
            minValue.Text = int.MinValue.ToString();
            maxValue.Text = int.MaxValue.ToString();
        }

        private void ShowUShortValues()
        {
            ushort uShortValue = default(ushort);
            defaultValue.Text = uShortValue.ToString();
            minValue.Text = ushort.MinValue.ToString();
            maxValue.Text = ushort.MaxValue.ToString();
        }

        private void ShowShortValues()
        {
            short shortValue = default(short);
            defaultValue.Text = shortValue.ToString();
            minValue.Text = short.MinValue.ToString();
            maxValue.Text = short.MaxValue.ToString();
        }

        private void ShowSByteValues()
        {
            sbyte sByteValue = default(sbyte);
            defaultValue.Text = sByteValue.ToString();
            minValue.Text = sbyte.MinValue.ToString();
            maxValue.Text = sbyte.MaxValue.ToString();
        }

        private void ShowByteValues()
        {
            byte byteValue = default(byte);
            defaultValue.Text = byteValue.ToString();
            minValue.Text = byte.MinValue.ToString();
            maxValue.Text = byte.MaxValue.ToString();
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
