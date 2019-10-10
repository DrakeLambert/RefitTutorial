using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Options;

namespace DrakeLambert.RefitTutorial.Gateway.ApiServices.WeatherApi
{
    public class WeatherApiAuthenticationHandler : DelegatingHandler
    {
        private readonly WeatherApiOptions _options;

        public WeatherApiAuthenticationHandler(IOptionsSnapshot<WeatherApiOptions> options)
        {
            _options = options.Value;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder(request.RequestUri);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            query["APPID"] = _options.AppId; // insert APPID query param with app id from settings

            uriBuilder.Query = query.ToString();

            request.RequestUri = uriBuilder.Uri; // modify request uri

            return base.SendAsync(request, cancellationToken);
        }
    }
}