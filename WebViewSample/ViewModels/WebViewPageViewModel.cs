using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using WebViewSample.Models;

namespace WebViewSample.ViewModels;

[ObservableObject]
public partial class WebViewPageViewModel
{
       
    private WebSiteModel _selected;
    public WebSiteModel Selected
    {
        get => _selected;
        set => SetProperty(ref _selected, value);
    }

    
    public WebViewPageViewModel(WebSiteModel selected)
    {
        _selected = selected;        
    }
}