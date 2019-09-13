using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MusixMatchApiService.Models;
using MusixMatchApiService.Services;
using MusixMatchApiService.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using static MusixMatchApiService.Models.MusicData;
using static MusixMatchApiService.Services.IApiServices;

namespace MusixMatchApiService.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        public SearchModel search {get;set;}
        public ICommand GetLyricsCommand { get; set; }
        IApiService apiService = new ApiServices();
        public MusicData lyrics { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public SearchViewModel()
        {
            search = new SearchModel();
            GetLyricsCommand = new Command(async () =>
            {
                await GetMusicData(search.Artist, search.Title);

            });
        }
        async Task GetMusicData(string Artist, string Title)
        {
            try
            {
                lyrics = new MusicData();
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {

                    var rate = await apiService.GetMusicData(Artist, Title);

                    if (rate != null)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new LyricsPage(rate.message.body.lyrics.lyrics_body));
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "You don't have internet connection", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Unable to connect to the server", "Ok");
            }
        }
    }
}
