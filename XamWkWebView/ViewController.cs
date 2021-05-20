using Foundation;
using System;
using System.IO;
using System.Text;
using UIKit;
using WebKit;

namespace XamWkWebView
{
    public partial class ViewController : UIViewController
    {
        WKWebView wKWebView;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            wKWebView = new WKWebView(View.Frame, new WKWebViewConfiguration());
            View.AddSubview(wKWebView);

            var bundle = NSBundle.MainBundle;
            var path = bundle.PathForResource("map", "html");
            var html = string.Empty;
            try
            {
                html = File.ReadAllText(path, Encoding.UTF8);
            }
            catch
            {
                //ERROR
            }
            wKWebView.LoadHtmlString(html, null);
            wKWebView.AllowsBackForwardNavigationGestures = true;
        }

        public override void LoadView()
        {
            base.LoadView();

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}