# Sizeable WebView 

Sizeable WebView is a fully featured Windows Phone 8.1 WebView control with the following additions:

  - Auto height setup according to the web view's content length.
  - An option to disable view interactions: zooming, scrolling, etc. 

### Installation
  - Clone (or download) the project.
  - Add the project (or just the .cs and .xaml files) to your existing solution.
  - Add a reference in your Windows Phone project.
  

### Usage

At the desirable page, add the following xaml (don't forget to add the namespace):

```sh
<components:SizeableWebView x:Name="contentAwareWebView" IsContentAware="True" InteractionsEnabled="False" />
```

**IsContentAware -** set to true in order to set the height of the control according to the HTML content's length. 
**InteractionsEnabled -** set to false in order to disable view interactions (zooming, scrolling etc). 
**WebView -** an access propery for the native WebView control.


Then, use the following function in order to navigate to your HTML content:

```sh
contentAwareWebView.NavigateToContent(yourHTMLContent);
```

Best for applications that consume content from RSS/WebService as HTML.


License
----

MIT


