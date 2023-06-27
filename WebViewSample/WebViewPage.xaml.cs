using WebViewSample.Models;
using WebViewSample.ViewModels;
using Application = Microsoft.Maui.Controls.Application;

namespace WebViewSample;

public partial class WebViewPage : ContentPage
{
    public WebViewPage(WebSiteModel selectedSite)
    {
        InitializeComponent();
        BindingContext = new WebViewPageViewModel(selectedSite);
    }


    private void OnSwiped(object sender, SwipedEventArgs e)
    {
        if (e.Direction == SwipeDirection.Right)
        {
            Application.Current!.MainPage!.Navigation.PopAsync();
        }
    }
    
}