using System;
using System.Threading.Tasks;
using MusixMatchApiService.Models;
using Refit;

namespace MusixMatchApiService.Services
{
    public class IApiServices
    {
        public interface IApiService
        {
            [Get("/ws/1.1/matcher.lyrics.get?apikey=aa2ae8cce618bff1f84b172ea0c75787&format=json&q_track={Title}&q_artist={Artist}")]
            Task<MusicData> GetMusicData(string Artist, string Title);
        }
    }
}
