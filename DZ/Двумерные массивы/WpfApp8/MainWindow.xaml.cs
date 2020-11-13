using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp8
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
        public DataTable makedt(string[,] input)
        {
            DataTable output = new DataTable();
            for (int i = 0; i < input.GetLength(1); i++)
            {
                output.Columns.Add(i.ToString());
            }
            for (int i = 0; i < input.GetLength(0); i++)
            {
                DataRow row = output.NewRow();
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    row[j.ToString()] = input[i, j];
                }
                output.Rows.Add(row);
            }
            return output;
        }
        public static String[,] v = new String[10,10];
        private void Bt1_Click(object sender, RoutedEventArgs e)
        {
            string[,] a = new string[10,10];
            Random x = new Random();
            for (int i = 0; i < 10; i++) 
            {
                for(int j = 0; j < 10; j++) 
                {
                    a[i, j] = Convert.ToString(x.Next(-10,10));
                }
            }
            v = a;
            Dg1.ItemsSource=makedt(v).DefaultView;
             
        }
         
        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            string[,] a = new string[10,10];
            double tmp;
            int col;
            int N = 10;
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    tmp = .0; col = 0;
                    if (i > 0)
                    {
                        tmp += Convert.ToDouble(v[i - 1,j]);
                        col++;
                        if (j > 0)
                        {
                            tmp += Convert.ToDouble(v[i - 1,j - 1]);
                            col++;
                        }
                        if (j < N - 1)
                        {
                            tmp += Convert.ToDouble(v[i - 1,j + 1]);
                            col++;
                        }
                    }
                    if (i < N - 1)
                    {
                        tmp += Convert.ToDouble(v[i + 1,j]);
                        col++;
                        if (j > 0)
                        {
                            tmp += Convert.ToDouble(v[i + 1,j - 1]);
                            col++;
                        }
                        if (j < N - 1)
                        {
                            tmp += Convert.ToDouble(v[i + 1,j + 1]);
                            col++;
                        }
                    }
                    if (j > 0)
                    {
                        tmp += Convert.ToDouble(v[i,j - 1]);
                        col++;
                    }
                    if (j < N - 1)
                    {
                        tmp += Convert.ToDouble(v[i,j + 1]);
                        col++;
                    }
                    a[i,j] = Convert.ToString(tmp / col);
                }
            Dg2.ItemsSource = makedt(a).DefaultView;
            double sum = 0;
            for(int i = 0; i<10; i++) 
            {
                for(int j = 0; j<=i; j++) 
                {
                    sum += Convert.ToDouble(a[i, j]);
                }
            }
            Tb1.Text = Convert.ToString(sum);
        }

        private void Dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
