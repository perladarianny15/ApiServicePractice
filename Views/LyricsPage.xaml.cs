using System;
using System.Collections.Generic;
using System.ComponentModel;
using MusixMatchApiService.Models;
using MusixMatchApiService.ViewModels;
using Xamarin.Forms;
using static MusixMatchApiService.Models.MusicData;
using System.Windows.Input;

namespace MusixMatchApiService.Views
{
    public partial class LyricsPage : ContentPage
    {
        public LyricsPage(string Lyrics)
        {

            InitializeComponent();
            BindingContext = new LyricsViewModel(Lyrics);
        }
    }
}
