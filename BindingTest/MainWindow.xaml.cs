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

namespace BindingTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Student stu;
        public MainWindow()
        {
            InitializeComponent();
            stu = new Student();
            Binding binding = new Binding();
            binding.Source = stu;
            // 设置binding的访问路径
            binding.Path = new PropertyPath("Name"); 

            // 数据源与目标连接 
            BindingOperations.SetBinding(this.txt, TextBox.TextProperty, binding);
            // 等价于 
            //this.txtbox1.SetBinding(TextBox.TextProperty, new Binding("Value") { ElementName = "slider" });

            /*
             *  注意 当Binding的path 是string int等基本类型时 可以省略后面 也可以用 . 代替  xaml中 可以省略 .
             * 
             * 为Binding制定源的几种方法
             * (1) CLR普通单个对象 实现 INotifyPropertyChanged 接口 在 set中激发 PropertyChanged时间通知Binding数据更新
             * (2) 对于集合类型 派生自ItemsControl 的控件 可以使用其ItemSource属性 进行Binding
             * (3) ADO.Net 数据对象 制定 Source (DateTable ,DataVIew 等)
             * (4) XML
             * (5) 依赖对象 制定Source (可以形成Binding链)
             * (6) 容器的DataContext 制定源 可以先进行属性绑定 只给Path 而不设置Source (可以进行树形查找数据源)
             * (7) 使用ElementName 制定Source (Xaml) 无法访问对象 只能通过Name属性找对象
             * (8) 通过Binding的RelativeSource属性相对制定Source
             * (9) ObjectDataProvider 对象制定Source
             * (10) 把Linq检索到的数据对象作为Binding的源
             * 
            */
            
        }
        /*
         如果集合元素属性还是一个集合 可以将子集合中的元素多级 斜线 语法 见 t.png

             */
public void test()
        {
            List<Student> stu = new List<Student> { };
            this.txtbox1.SetBinding(TextBox.TextProperty, new Binding("/Name") { Source = "子集对象" });
            this.txtbox1.SetBinding(TextBox.TextProperty, new Binding("/stu.Name") { Source = "子集对象" });
            this.txtbox1.SetBinding(TextBox.TextProperty, new Binding("/Name") { Source = "子集对象" });

        }
        /*
         * FrameworkElement 元素封装了SetBinding方法 结果也为Binding
         */
         public BindingExpressionBase SetBinding(DependencyProperty dp,BindingBase binding)
        {
            return BindingOperations.SetBinding(this, dp, binding);
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.stu.Name += "-Name";
        }
    }
}
