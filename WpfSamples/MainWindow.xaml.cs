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

namespace WpfSamples
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initial();
        }
        void Initial()
        {
            var classes = new List<Class>
            {
                new Class{Id=1,Name="王者学院", Student=new List<Student>
                {
                     new Student{Id=3,Name="小王"},
                     new Student{Id=4,Name="小李"},
                     new Student{Id=5,Name="小黑"},
                     new Student{Id=6,Name="小刘"},
                } },
                new Class{Id=2,Name="终极一般", Student=new List<Student>
                {
                     new Student{Id=3,Name="小王"},
                     new Student{Id=4,Name="小李"},
                     new Student{Id=5,Name="小黑"},
                     new Student{Id=6,Name="小刘"},
                }
                }
            };

            lbx.ItemsSource = classes;
        }
    }
}
