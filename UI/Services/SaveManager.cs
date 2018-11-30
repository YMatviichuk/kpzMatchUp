using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GameBin;
using Newtonsoft.Json;
using UI.ViewModels;

namespace UI.Services
{
    public class SaveModel
    {
        public string Save { get; set; }
        public string SaveName { get; set; }
        public int PlayerId { get; set; }
    }

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
                    var stream = await result.Content.ReadAsStringAsync();

                    stream = (string)JsonConvert.DeserializeObject(stream);

                    return BoardMemento.ReadFromStream(stream);
                }
                else
                {
                    return null;
                }
            }
        }

        public static async void SaveGame(long userId, BoardMemento board, string saveName)
        {
            using (var http = new HttpClient())
            {
                object obj = new SaveModel
                {
                    Save = board.SaveToDisk(),
                    SaveName = saveName,
                    PlayerId = 1
                };

                await http.PostAsync($"{baseAddress}/PlayerSaves", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
            }
        }
    }
}
