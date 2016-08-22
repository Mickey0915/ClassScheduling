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
using Windows.UI.Core; // 忘れずに！



// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace ClassScheduler
{

    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class Share : Page
    {
        public Share()
        {
            this.InitializeComponent();
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
    }

}
