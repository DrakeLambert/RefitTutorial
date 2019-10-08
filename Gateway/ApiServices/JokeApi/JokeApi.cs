using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DrakeLambert.RefitTutorial.Gateway.ApiServices.JokeApi
{
    public class JokeApi : IJokeApi
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public JokeApi(HttpClient client)
        {
            _client = client;
        }

        public async Task<JokeDto> GetRandomJokeAsync()
        {
            var response = await _client.GetAsync("/jokeapi/category/Programming?blacklistFlags=nsfw");
            var joke = await JsonSerializer.DeserializeAsync<JokeDto>(await response.Content.ReadAsStreamAsync(), _serializerOptions);
            return joke;
        }
    }
}
