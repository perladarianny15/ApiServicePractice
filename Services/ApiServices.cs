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
        public async Task<MusicData> GetMusicData(string Artist, string Title)
        {
            string result;
            MusicData ReturnedMusicData = new MusicData();
            try
            {
                using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
                {
                    client.BaseAddress = new Uri("http://api.musixmatch.com/ws/1.1/");
                    client.DefaultRequestHeaders.Accept.Clear();

                    HttpResponseMessage response = client.GetAsync($"matcher.lyrics.get?apikey=aa2ae8cce618bff1f84b172ea0c75787&format=json&q_track={Title}&q_artist={Artist}").Result;
                    
                    result = response.Content.ReadAsStringAsync().Result;
                    
                    ReturnedMusicData = JsonConvert.DeserializeObject<MusicData>(result);

                    if (ReturnedMusicData.message == null)
                    {
                        ReturnedMusicData.message.body.lyrics.lyrics_body = "Could not get the Lyrics of the song";
                    }
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
