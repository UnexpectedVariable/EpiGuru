using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;

namespace Assets.Scripts.Location
{
    internal class GeoRequester : MonoBehaviour
    {
        private GeoJSON _data = new();
        private HttpClient _httpClient;

        private void Start()
        {
            _httpClient = new HttpClient();
            GetAsync();
        }

        private async void GetAsync()
        {
            HttpRequestMessage request = new(HttpMethod.Get, "http://ip-api.com/json");
            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                _data = JsonConvert.DeserializeObject<GeoJSON>(await response.Content.ReadAsStringAsync());
                Debug.Log($"Location: {_data.country}");
            }
            else
            {
                throw new HttpRequestException($"Request failed with code {response.StatusCode}");
            }
        }
    }
}
