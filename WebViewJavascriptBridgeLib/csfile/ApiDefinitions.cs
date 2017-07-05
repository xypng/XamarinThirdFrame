using Foundation;
using UIKit;

namespace WebViewJSBridge.iOS
{
	// typedef void (^WVJBResponseCallback)(id);
	delegate void WVJBResponseCallback (NSObject arg0);

	// typedef void (^WVJBHandler)(id, WVJBResponseCallback);
	delegate void WVJBHandler (NSObject arg0, WVJBResponseCallback arg1);

	// @interface WebViewJavascriptBridge : NSObject <UIWebViewDelegate>
	[BaseType (typeof(NSObject))]
	interface WebViewJavascriptBridge : IUIWebViewDelegate
	{
		// +(instancetype)bridgeForWebView:(UIWebView *)webView handler:(WVJBHandler)handler;
		[Static]
		[Export ("bridgeForWebView:handler:")]
		WebViewJavascriptBridge BridgeForWebView (UIWebView webView, WVJBHandler handler);

		// +(instancetype)bridgeForWebView:(UIWebView *)webView webViewDelegate:(NSObject<UIWebViewDelegate> *)webViewDelegate handler:(WVJBHandler)handler;
		[Static]
		[Export ("bridgeForWebView:webViewDelegate:handler:")]
		WebViewJavascriptBridge BridgeForWebView (UIWebView webView, UIWebViewDelegate webViewDelegate, WVJBHandler handler);

		// +(instancetype)bridgeForWebView:(UIWebView *)webView webViewDelegate:(NSObject<UIWebViewDelegate> *)webViewDelegate handler:(WVJBHandler)handler resourceBundle:(NSBundle *)bundle;
		[Static]
		[Export ("bridgeForWebView:webViewDelegate:handler:resourceBundle:")]
		WebViewJavascriptBridge BridgeForWebView (UIWebView webView, UIWebViewDelegate webViewDelegate, WVJBHandler handler, NSBundle bundle);

		// +(void)enableLogging;
		[Static]
		[Export ("enableLogging")]
		void EnableLogging ();

		// -(void)send:(id)message;
		[Export ("send:")]
		void Send (NSObject message);

		// -(void)send:(id)message responseCallback:(WVJBResponseCallback)responseCallback;
		[Export ("send:responseCallback:")]
		void Send (NSObject message, WVJBResponseCallback responseCallback);

		// -(void)registerHandler:(NSString *)handlerName handler:(WVJBHandler)handler;
		[Export ("registerHandler:handler:")]
		void RegisterHandler (string handlerName, WVJBHandler handler);

		// -(void)callHandler:(NSString *)handlerName;
		[Export ("callHandler:")]
		void CallHandler (string handlerName);

		// -(void)callHandler:(NSString *)handlerName data:(id)data;
		[Export ("callHandler:data:")]
		void CallHandler (string handlerName, NSObject data);

		// -(void)callHandler:(NSString *)handlerName data:(id)data responseCallback:(WVJBResponseCallback)responseCallback;
		[Export ("callHandler:data:responseCallback:")]
		void CallHandler (string handlerName, NSObject data, WVJBResponseCallback responseCallback);
	}
}
