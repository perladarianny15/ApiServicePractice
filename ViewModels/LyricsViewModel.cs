using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MusixMatchApiService.Models;
using Xamarin.Forms;
using static MusixMatchApiService.Models.MusicData;

namespace MusixMatchApiService.ViewModels
{
    public class LyricsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Result { get; set; }

        public LyricsViewModel(string Lyrics)
        {
            Result = Lyrics;
        }
    }
}
