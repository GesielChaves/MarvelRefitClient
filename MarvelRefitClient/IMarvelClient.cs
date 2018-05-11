using System.Net.Http;
using System.Threading.Tasks;

namespace MarvelRefitClient
{
    public interface IMarvelClient
    {
        Task<HttpResponseMessage> GetCharacters(int limit = 20, string orderBy = "name");
    }
}