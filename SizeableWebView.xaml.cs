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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Sample.View.Components
{
    public sealed partial class SizeableWebView : UserControl
    {
        public SizeableWebView()
        {
            this.InitializeComponent();
            this.WebView = webView;

            webView.NavigationCompleted += webView_NavigationCompleted;
        }


        public void NavigateToContent(string htmlContent)
        {
            var htmlScript = "<script type=\"text/javascript\">"
                               + "function getHeight()  {"
                               + "return document.getElementById(\"wrapper\").offsetHeight.toString(); }; </script>";


            var htmlConcat = string.Format("<html><head></head>" +
                                            "<body  style=\"margin:0;padding:0;font-size: 100%\" " +
                                            ">" +
                                            "<div id=\"wrapper\" style=\"width:100%;" +
                                            "\">{0}</div></body>{1}</html>", htmlContent, htmlScript);

            webView.NavigationCompleted += webView_NavigationCompleted;
            webView.NavigateToString(htmlConcat);
        }

        async void webView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            if (IsContentAware)
            {
                string contentHeight = await webView.InvokeScriptAsync("getHeight", null);
                webView.Height = int.Parse(contentHeight) / 2.8;
            }
        }



        #region Properties

        public WebView WebView
        {
            get { return (WebView)GetValue(WebViewProperty); }
            set { SetValue(WebViewProperty, value); }
        }


        // Using a DependencyProperty as the backing store for WebView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WebViewProperty =
            DependencyProperty.Register("WebView", typeof(WebView), typeof(SizeableWebView), new PropertyMetadata(null));

        public bool IsContentAware
        {
            get { return (bool)GetValue(IsContentAwareProperty); }
            set { SetValue(IsContentAwareProperty, value); }
        }

        public static readonly DependencyProperty IsContentAwareProperty =
            DependencyProperty.Register("IsContentAware", typeof(bool), typeof(SizeableWebView), new PropertyMetadata(false));

        public bool InteractionsEnabled
        {
            get { return (bool)GetValue(InteractionsEnabledProperty); }
            set
            {
                SetValue(InteractionsEnabledProperty, value);

                grid.Visibility = value ? Visibility.Collapsed : Visibility.Visible;

            }
        }

        public static readonly DependencyProperty InteractionsEnabledProperty =
            DependencyProperty.Register("InteractionsEnabled", typeof(bool), typeof(SizeableWebView), new PropertyMetadata(false));

        #endregion


    }
}
