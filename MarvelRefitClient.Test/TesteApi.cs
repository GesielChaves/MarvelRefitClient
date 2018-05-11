using System.Threading.Tasks;
using NUnit.Framework;

namespace MarvelRefitClient.Test
{
    [TestFixture]
    public class TesteApi
    {
        [Test]
        public async Task TesteMarvelRefitClient()
        {
            IMarvelClient client = new MarvelClient("", "");

            var result = await client.GetCharacters();
            var readAsStringAsync = result.Content.ReadAsStringAsync();
            Assert.IsNotNull(readAsStringAsync);
        }
    }
}
