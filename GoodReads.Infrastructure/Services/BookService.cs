using GoodReads.Core.DTOs;
using GoodReads.Core.Services;
using System.Text.Json.Nodes;

namespace GoodReads.Infrastructure.Services
{
    internal class BookService : IBookService
    {
        private readonly string _baseUri = "http://openlibrary.org/api/books?bibkeys=ISBN:{0}&jscmd=details&format=json";
        public async Task<BookDto?> SearchBookByISBN(string ISBN)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var url = string.Format(_baseUri, ISBN);

                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {

                    var dto = new BookDto();

                    string responseData = await response.Content.ReadAsStringAsync();
                    JsonObject json = JsonNode.Parse(responseData).AsObject();

                    string isbnObject = $"ISBN:{ISBN}";
                    var bookDetails = json[isbnObject]?["details"];
                    var authors = bookDetails?["authors"]?.AsArray();

                    if(authors != null)
                    {
                        var author = authors[0]?["name"].ToString();
                        dto.Author = author;
                    }

                    return dto;

                }
            }

            return null;
        }
    }
}
