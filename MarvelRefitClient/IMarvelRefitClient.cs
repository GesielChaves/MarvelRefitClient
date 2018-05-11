using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarvelRefitClient
{
    public interface IMarvelRefitClient
    {
        [Get("/v1/public/characters")]
        Task<HttpResponseMessage> GetCharacters([AliasAs("apikey")]string publicKey, string hash, string ts, int limit = 20, string orderBy = "name");
    }
}
