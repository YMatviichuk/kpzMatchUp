using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GameBin;
using UI.ViewModels;

namespace UI.Services
{
    class SaveManager
    {
        private static readonly string baseAddress = "http://localhost:8082/api/";

        public static async Task<List<Save>> GetSaveList(long userId)
        {
            using (var http = new HttpClient())
            {
                var result = await http.GetAsync(new Uri($"{baseAddress}/PlayerSaves"));
                if (result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadAsAsync<List<Save>>();
                }
                else
                {
                    return new List<Save>();
                }
            }
        }

        public static async Task<BoardMemento> LoadGame(long saveId)
        {
            using (var http = new HttpClient())
            {
                var result = await http.GetAsync(new Uri($"{baseAddress}/PlayerSaves/{saveId}"));
                if (result.IsSuccessStatusCode)
                {
                    var stream = await result.Content.ReadAsStreamAsync();
                    return BoardMemento.ReadFromStream(stream);
                }
                else
                {
                    return null;
                }
            }
        }

        public void SaveGame(long userId, BoardMemento board)
        {
            using (var http = new HttpClient())
            {
                //var serializedSave = board.SaveToDisk();
                //await http.PostAsync($"{baseAddress}/PlayerSaves", new HttpMessageContent
                //{
                //    HttpRequestMessage = { }
                //})
                //await http.GetAsync(new Uri($"{baseAddress}/PlayerSaves/{saveId}"));
                //if (result.IsSuccessStatusCode)
                //{
                //    var stream = await result.Content.ReadAsStreamAsync();
                //    return BoardMemento.ReadFromStream(stream);
                //}
                //else
                //{
                //    return null;
                //}
            }
        }
    }
}
