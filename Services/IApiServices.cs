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
            Task<MusicData> GetMusicData(string Artist, string Title);
        }
    }
}
