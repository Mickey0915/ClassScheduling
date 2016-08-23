using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using Windows.UI;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace ClassScheduler
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public object Current { get; private set; }

        public MainPage()
        {
            this.InitializeComponent();
           
            MyFrame.Navigate(typeof(Schedule));

           
        }

     

        private class IconSelection
        {
           ///Hopefully I can find the way to shorten the else-if parts.
        }

        private void MyListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ScheduleIcon.IsSelected)
            {
                MyFrame.Navigate(typeof(Schedule));
            }

            else if (ShareIcon.IsSelected)
            {
                MyFrame.Navigate(typeof(Share));
            }
        }

        private void HamburgerMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
            
        }

        // ページ表示時
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // [戻る]ボタンを表示するかどうかを設定する
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                Frame.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;

            //［戻る］ボタンが押されたときのイベントを結び付ける
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView()
              .BackRequested += Page_BackRequested;
        }


        // [戻る]ボタンを押したときの処理
        private void Page_BackRequested(object sender,
                      Windows.UI.Core.BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }
       

        // ページを離れる場合の処理
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);

            // ［戻る］ボタンのイベントハンドラーを解除
            SystemNavigationManager.GetForCurrentView()
              .BackRequested -= Page_BackRequested;
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
        
       /// private void HamburgerListbox_Tapped(object sender, TappedRoutedEventArgs e)
        ///{
           /// MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        ///}
    }
}
