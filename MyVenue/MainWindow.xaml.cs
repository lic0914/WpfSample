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

namespace MyVenue
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public int TitleWidth { get; set; } = 250;
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += delegate
            {
               
               // Border borderTitle = this.Template.FindName("borderTitle", this) as Border;


                borderTitle.MouseMove += delegate (object sender, MouseEventArgs e)
                {
                    if (e.LeftButton == MouseButtonState.Pressed)
                    {
                        this.DragMove();
                    }
                };
            };
        }
    }
}
