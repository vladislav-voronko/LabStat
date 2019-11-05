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
using StatGUI.ViewModels;
using static Mathx.Mathx;


namespace StatGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new MainWindowViewModel();
            DataContext = mainViewModel;
        }

        private void CalcButton_Click(object sender, RoutedEventArgs e)
        {
            int varFlag = 0;
            int[] sample = new int[GetHeightArray()];
            double average;
            int moda;
            if (RadX.IsChecked == true)
                varFlag = 1;
            if (RadY.IsChecked == true)
                varFlag = 2;
            if (RadZ.IsChecked == true)
                varFlag = 3;
            sample = GetColumn(tableR, varFlag);
            average = GetAverage(sample);
            moda = GetModa(sample);
            var otherResults = GetVariation(sample, average);
            TextBox1.Text = $"Average = {average}\nModa = {moda}\nMedian = {otherResults.Median}\nRange of variation = {otherResults.RangeVariation}\nDispersion = {otherResults.Dispersion}\nStandart deviation = {otherResults.StandartDeviation}\nAvereage linear deviation = {otherResults.AverageLinearDeviation}\nOscillation coefficient = {otherResults.CoefficientOscillation}\nVariation coefficient = {otherResults.CoefficientOscillation}";
            TextBox1.IsReadOnly = true;
        }
    }
}
