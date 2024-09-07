using GoodReads.Core.DTOs;
using GoodReads.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Infrastructure.Services
{
    internal class BookService : IBookService
    {
        private readonly string _baseUri = "http://viacep.com.br/ws/{0}/json";
        public async Task<BookDto?> SearchBookByISBN(string ISBN)
        {
            HttpClient httpClient = new HttpClient();
            var url = string.Format(_baseUri, ISBN);
            httpClient.BaseAddress = new Uri(url);

            HttpResponseMessage response = httpClient.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                BookDto parseObject = response.Content.ReadFromJsonAsync<BookDto>().Result;
                return parseObject;
            }

            return null;
        }
    }
}
