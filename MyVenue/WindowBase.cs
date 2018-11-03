using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyVenue
{
    public class WindowBase:Window
    {
        /// <summary>
        /// 标题的显示位置 默认左边
        /// </summary>
        public TitlePosition TitleAlign { get; set; }

        public WindowBase()
        {

            string themeName = "Black";
            App.Current.Resources.MergedDictionaries.Add(Application.LoadComponent(new Uri(string.Format("../Theme/{0}/WindowStyle.xaml", themeName), UriKind.Relative)) as ResourceDictionary);

            //设置基窗体的样式
            this.Style = (Style)App.Current.Resources["BaseWindowStyle"];
            this.Loaded += delegate
            {
                InitEvent();
                this.DataContext = new BaseWindowModel { Title = "my title" };
                
            };
        }
        public void InitEvent()
        {
            ControlTemplate baseWindowTemplate = (ControlTemplate)App.Current.Resources["baseWinTpl"];
            Border borderTitle = (Border)baseWindowTemplate.FindName("borderTitle", this);
            Button closeBtn = (Button)baseWindowTemplate.FindName("btnClose", this);
            Button minBtn = (Button)baseWindowTemplate.FindName("btnMin", this);
            Button maxBtn = (Button)baseWindowTemplate.FindName("btnMax", this);
            //TextBlock title = (TextBlock)baseWindowTemplate.FindName("Title", this);
            
            borderTitle.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };
            closeBtn.Click += delegate
            {
                this.Close();
            };
            minBtn.Click += delegate
            {
                this.WindowState = WindowState.Minimized;
            };
            maxBtn.Click += delegate
            {
                this.WindowState = WindowState.Maximized;
            };


        }
        private bool _allowSizeToContent = false;
        /// <summary>
        /// 自定义属性，用于标记该窗体是否允许按内容适应，设此属性是为了解决最大化按钮当SizeToContent属性为WidthAndHeight时不能最大化，从而最大、最小化必须变更SizeToContent的值的问题
        /// </summary>
        public bool AllowSizeToContent
        {
            get
            {
                return _allowSizeToContent;
            }
            set
            {
                this.SizeToContent = (value ? SizeToContent.WidthAndHeight : SizeToContent.Manual);
                _allowSizeToContent = value;
            }
        }
    }
    public enum TitlePosition
    {
        Left=0,
        Center=1
    }
    class BaseWindowModel
    {
        public string Title { get; set; }
        public TitlePosition TitleAlign { get; set; } = TitlePosition.Center;
       
        #region title 显示位置
        public int TitleColumn
        {
            get
            {
                if (TitleAlign == TitlePosition.Center)
                    return 1;
                else
                    return 0;
            }
        }
        public HorizontalAlignment TitleHorizontalAlignment
        {
            get
            {
                if (TitleAlign == TitlePosition.Center)
                {
                    return HorizontalAlignment.Center;
                }
                else
                    return HorizontalAlignment.Left;
            } 
        }
        #endregion
    }
}
