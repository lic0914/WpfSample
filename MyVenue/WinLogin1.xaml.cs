using MartialArtVenues.bll;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace MartialArtVenues.window
{
    /// <summary>
    /// WinLogin1.xaml 的交互逻辑
    /// </summary>
    public partial class WinLogin1 : Window
    {
        public WinLogin1()
        {
            InitializeComponent();

#if DEBUG //调试情况下 
            tb_UserName.Text = "15830175608";
            tb_password.Password = "yao123456";
            
#endif
        }



        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            var Name = tb_UserName.Text.ToString();
            IntPtr p = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(this.tb_password.SecurePassword);

            // 使用.NET内部算法把IntPtr指向处的字符集合转换成字符串  
            string password = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(p);
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(password))
            {
                var info = new LoginDal().Get(Name, password);
                // var info = HttpClientHelp.dooGet<ApiRetMsg<APIUserBaseModel>>(ApiUrl.GetLogin);
                if (info.Status != 1)
                {
                    var user = new GetUserInfo(info.Data.ID, info.Data.VenueId, info.Data.Token, info.Data.AccountName);

                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show(info.ErrorMsg);
                }
            }
        }



        #region 界面基础功能
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //拖动
            this.DragMove();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void mniButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        #endregion

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btn_Login_Click(sender, e);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink link = sender as Hyperlink;
            // 激活的是当前默认的浏览器
            Process.Start(new ProcessStartInfo(link.NavigateUri.AbsoluteUri));
        }
    }
}
