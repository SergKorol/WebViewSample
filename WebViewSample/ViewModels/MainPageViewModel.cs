using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using WebViewSample.Models;

namespace WebViewSample.ViewModels;

[ObservableObject]
public partial class MainPageViewModel
{
    public ICommand SelectionChangedCommand
    {
        get => new Command(async () => await GoToWebsiteDetails());
    }

    private ObservableCollection<WebSiteModel> _websiteList;

    public ObservableCollection<WebSiteModel> WebsiteList
    {
        get => _websiteList;
        set
        {
            _websiteList = value;
            OnPropertyChanged();
        }
    }

    private WebSiteModel _selectedWebsite;

    public WebSiteModel SelectedWebsite
    {
        get => _selectedWebsite;
        set => SetProperty(ref _selectedWebsite, value);
    }


    private async Task GoToWebsiteDetails()
    {
        if (SelectedWebsite == null)
        {
            return;
        }

        await Application.Current!.MainPage!.Navigation.PushModalAsync(new WebViewPage(SelectedWebsite));
        SelectedWebsite = null;
    }

    public MainPageViewModel()
    {
        WebsiteList = GetDataForList();
    }

    private ObservableCollection<WebSiteModel> GetDataForList()
    {
        return new ObservableCollection<WebSiteModel>
        {
            new()
            {
                Title = "Facebook",
                Description =
                    "Facebook is an online social media and social networking service owned by American technology giant Meta Platforms. ",
                Url = new Uri("https://facebook.com/")
            },
            new()
            {
                Title = "Amazon",
                Description =
                    "Amazon.com, Inc.[1] (/ˈæməzɒn/ AM-ə-zon UK also /ˈæməzən/ AM-ə-zən) is an American multinational technology company focusing on e-commerce, cloud computing, online advertising, digital streaming, and artificial intelligence.",
                Url = new Uri("https://www.amazon.com/")
            },
            new()
            {
                Title = "Apple Inc",
                Description =
                    "Apple Inc. is an American multinational technology company headquartered in Cupertino, California. Apple is the world's largest technology company by revenue, with US$394.3 billion in 2022 revenue.[6] Apple Inc. is an American multinational technology company headquartered in Cupertino, California. Apple is the world's largest technology company by revenue, with US$394.3 billion in 2022 revenue.[6] ",
                Url = new Uri("https://www.apple.com/")
            },
            new()
            {
                Title = "Netflix",
                Description =
                    "Netflix is an American subscription video on-demand over-the-top streaming television service owned and operated by Netflix, Inc., a company based in Los Gatos, California. ",
                Url = new Uri("https://www.netflix.com/")
            },
            new()
            {
                Title = "Google LLC",
                Description =
                    "Google LLC (/ˈɡuːɡəl/ (listen)) is an American multinational technology company focusing on artificial intelligence,[9] online advertising, search engine technology, cloud computing, computer software, quantum computing, e-commerce, and consumer electronics.",
                Url = new Uri("https://www.google.com/")
            },
        };
    }
}