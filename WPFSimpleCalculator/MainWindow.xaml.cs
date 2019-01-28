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

namespace WPFSimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Help HelpWindow { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            CleanInputs();
            if (CheckValid())
            {
                return;
            }

            double result;
            result = int.Parse(tb_Weight.Text) / 2;
            if (cb_Unit.SelectedIndex == 1)
            {
                result = Math.Round(result * 0.0295735, 2);
            }
            tb_Result.Text = result.ToString();
        }

        private bool CheckValid()
        {
            bool isFlagged = false;
            //check gender
            if (rb_GenderFemale.IsChecked == false && rb_GenderMale.IsChecked == false)
            {
                g_Gender.Background = Brushes.Red;
                isFlagged = true;
            }

            if (!int.TryParse(tb_Weight.Text, out int n))
            {
                tb_Weight.Background = Brushes.Red;
                isFlagged = true;
            }
            
            return isFlagged;
        }

        private void CleanInputs()
        {
            g_Gender.Background = Brushes.White;
            tb_Weight.Background = Brushes.White;
        }

        private void ClearFields(object sender, RoutedEventArgs e)
        {
            CleanInputs();
            rb_GenderFemale.IsChecked = false;
            rb_GenderMale.IsChecked = false;
            tb_Weight.Text = "";
            cb_Unit.SelectedIndex = 0;
            tb_Result.Text = "";
        }

        private void OpenHelp(object sender, RoutedEventArgs e)
        {
            if (HelpWindow != null)
            {
                HelpWindow.Close();
            }
            HelpWindow = new Help();
            HelpWindow.Show();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
