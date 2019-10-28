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
using static Mathx.Mathx;

namespace StatGUI
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

        private void CalcButton_Click(object sender, RoutedEventArgs e)
        {
            int VarFlag = 0;
            int[] sample = new int[GetHeightArray()];
            double average;
            int moda;
            double[] otherResults = new double[otherResult];
            if (RadX.IsChecked == true)
                VarFlag = 1;
            if (RadY.IsChecked == true)
                VarFlag = 2;
            if (RadZ.IsChecked == true)
                VarFlag = 3;
            sample = ChooseVar(TableR, VarFlag);
            average = Average(sample);
            moda = GetModa(sample);
            otherResults = GetVariation(sample, average);
            TextBox1.Text = $"Average = {average}\nModa = {moda}\nMedian = {otherResults[0]}\nRange of variation = {otherResults[1]}\nDispersion = {otherResults[2]}\nStandart deviation = {otherResults[3]}\nAvereage linear deviation = {otherResults[4]}\nOscillation coefficient = {otherResults[5]}\nVariation coefficient = {otherResults[6]}";
        }
    }
}
