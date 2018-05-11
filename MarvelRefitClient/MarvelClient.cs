using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace MarvelRefitClient
{
    public class MarvelClient : IMarvelClient
    {
        private readonly string _publicKey;
        private readonly string _secretKey;
        private readonly IMarvelRefitClient _client;
        private readonly MD5 _md5;
        private string _timeSpan => (DateTime.UtcNow.TimeOfDay).ToString();
        public string _hash
        {
            get
            {
                _md5.ComputeHash(Encoding.ASCII.GetBytes($"{_timeSpan}{_secretKey}{_publicKey}"));
                return _md5.Hash.Aggregate("", (s, @byte) => s + @byte.ToString("x2"));
            }
            private set => throw new NotImplementedException();
        }

        public MarvelClient(string publicKey, string secretKey)
        {
            _publicKey = publicKey;
            _secretKey = secretKey;
            _client = RestService.For<IMarvelRefitClient>("https://gateway.marvel.com:443");
            _md5 = MD5.Create();
        }

        public Task<HttpResponseMessage> GetCharacters(int limit = 20, string orderBy = "name")
            => _client.GetCharacters(_publicKey, _hash, _timeSpan);

        private static string CalculaMD5(string textoClaro)
        {
            var md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(textoClaro));
            return md5.Hash.Aggregate("", (s, @byte) => s + @byte.ToString("x2"));
        }
    }
}
