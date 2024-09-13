using GoodReads.Core.DTOs;
using GoodReads.Core.Services;
using System.Text.Json.Nodes;

namespace GoodReads.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly string _baseUri = "http://openlibrary.org/api/books?bibkeys=ISBN:{0}&jscmd=details&format=json";

        public async Task<byte[]?> GetBookThumbnailImage(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                // Fazendo o download da imagem
                HttpResponseMessage response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode) { return null; }

                // Lendo o conteúdo como um array de bytes
                byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();
                return imageBytes;
            }
        }


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

                    dto.ISBN = ISBN;
                    var title = bookDetails?["title"]?.ToString();
                    dto.Title = title != null ? title : "";

                    var authors = bookDetails?["authors"]?.AsArray();
                    if (authors != null)
                    {
                        // Fix: Concatenar caso seja mais de um autor
                        var author = authors[0]?["name"].ToString();
                        dto.Author = author;
                    }

                    var publishers = bookDetails?["publishers"]?.AsArray();
                    if (publishers != null)
                    {
                        var publisher = publishers[0]?.ToString();
                        dto.Publisher = publisher != null ? publisher : "";
                    }

                    var publishDate = bookDetails?["publish_date"]?.ToString();
                    if (publishDate != null)
                    {
                        string[] dateSepareted = publishDate.Split('-');
                        dto.YearOfPublish = int.Parse(dateSepareted[0]);
                    }

                    var qtPages = bookDetails?["number_of_pages"];
                    dto.QuantityOfPages = qtPages != null ? (int)qtPages : 0;

                    var thumbnailUrl = bookDetails?["thumbnail_url"]?.ToString();
                    dto.ThumbnailUrl = thumbnailUrl != null ? thumbnailUrl : "";

                    return dto;
                }
            }

            return null;
        }
    }
}
