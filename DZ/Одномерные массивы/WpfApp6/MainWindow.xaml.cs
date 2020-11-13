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

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static bool CheckForInt(String Num)
        {
            return Num.All(x => Int32.TryParse(x.ToString(), out Int32 result) && (x>0));
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Bt1_Click(object sender, RoutedEventArgs e)
        {
            Random x = new Random();
            Random y = new Random();
            if (CheckForInt(Tb1.Text)) 
            {
                double[] a = new double[Convert.ToInt32(Tb1.Text)];
                double[] c = new double[Convert.ToInt32(Tb1.Text)];
                for (int i = 0; i< a.Length; i++) 
                {
                    a[i] = y.Next(-100,100)+x.NextDouble();
                }
                int k = 0;
                int h = 0;
                for(int i = 0; i< a.Length; i++) 
                {
                    if(a[i] != 0) 
                    {
                        c[k] = a[i];
                        k++;
                    }
                    else 
                    {
                        c[c.Length - h-1] = a[i];
                        h++;
                    }
                    
                }
                string str = "";
                foreach (double elem in c) 
                {
                    str = str + Convert.ToString(elem)+"; ";
                }
                str=str.Remove(str.Length - 2);
                Tb2.Text = str;
                double Max = 0;
                for(int i = 0; i < a.Length; i++) 
                {
                    if (Math.Abs(a[i]) > Max) 
                    {
                        Max = a[i];
                    }
                }
                Tb3.Text = Convert.ToString(Max);
                int n = 0;
                int[] b = new int[2];
                for(int i = 0; i< a.Length; i++) 
                {
                    if (n == 2) { break; }
                    if (a[i] > 0) 
                    {
                        b[n] = i;
                        n++;
                    }                  
                }
                if (b.Length == 2)
                {
                    double sum = 0;
                    for (int i = b[0]+1; i < b[1]; i++)
                    {
                        sum += a[i];
                    }
                    Tb4.Text = Convert.ToString(sum);
                }
                else 
                {
                    MessageBox.Show("Нету 2ух положительных элементов");
                    Tb4.Text = "Нет 2ух";
                }
            }
            else 
            {
                MessageBox.Show("Вы ввели не целое положительне число!");
            }
            
        }

    }
}
