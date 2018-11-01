using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfMyWindowUI
{
    public partial class WindowBase : Window
    {

        public WindowBase()
        {
            
            string themeName = ConfigManage.CurrentTheme;//样式所在的文件夹

            App.Current.Resources.MergedDictionaries.Add(Application.LoadComponent(new Uri(string.Format("../Theme/{0}/WindowBaseStyle.xaml", themeName), UriKind.Relative)) as ResourceDictionary);
            this.Loaded += delegate
            {
                InitializeEvent();
            };
        }
        private void InitializeEvent()
        {
            ControlTemplate baseWindowTemplate = (ControlTemplate)App.Current.Resources["BaseWindowControlTemplate"];

            Border borderTitle = (Border)baseWindowTemplate.FindName("borderTitle", this);
            Button closeBtn = (Button)baseWindowTemplate.FindName("btnClose", this);
            Button minBtn = (Button)baseWindowTemplate.FindName("btnMin", this);
            //YesButton = (Button)baseWindowTemplate.FindName("btnYes", this);
            //NoButton = (Button)baseWindowTemplate.FindName("btnNo", this);

            minBtn.Click += delegate
            {
                this.WindowState = WindowState.Minimized;
            };

            closeBtn.Click += delegate
            {
                this.Close();
            };

            borderTitle.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };
        }
    }
}
