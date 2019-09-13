using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MusixMatchApiService.Models;
using Newtonsoft.Json;
using static MusixMatchApiService.Services.IApiServices;

namespace MusixMatchApiService.Services
{
    public class ApiServices : IApiService
    {
        public string ApiKey = "aa2ae8cce618bff1f84b172ea0c75787";
        public async Task<MusicData> GetMusicData(string Artist, string Title)
        {
            MusicData ReturnedMusicData = new MusicData();
            try
            {
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync($"http://api.musixmatch.com/ws/1.1/matcher.lyrics.get?apikey={ApiKey}&format=json&q_track={Title}&q_artist={Artist}");
                
                ReturnedMusicData = JsonConvert.DeserializeObject<MusicData>(response);

                if (ReturnedMusicData.message.Body == null)
                {
                    ReturnedMusicData.message.Body.Lyrics.Lyrics_body = "Could not get the Lyrics of the song";
                }
            

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ReturnedMusicData;
        }
    }
}
