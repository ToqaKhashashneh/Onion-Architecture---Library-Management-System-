using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Library.Infrastructure.Data
{
    public class BooksSpReader: IBooksSpReader
    {
        private readonly string _connectionString;

        public BooksSpReader(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Default")!;
        }
        public async Task<List<(int BookId, string Title, string? Author, DateTime? PublishedOn, List<string> Categories)>>
          ReadAllWithCategoriesAsync()
        {
            var result = new List<(int, string, string?, DateTime?, List<string>)>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("GetAllBooksWithCategories", conn); // اسم SP
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int bookId = reader.GetInt32(0);
                string title = reader.GetString(1);
                string? author = reader.IsDBNull(2) ? null : reader.GetString(2);
                DateTime? publishedOn = reader.IsDBNull(3) ? null : reader.GetDateTime(3);
                string categories = reader.IsDBNull(4) ? "" : reader.GetString(4);

                var categoryList = new List<string>(categories.Split(',', StringSplitOptions.RemoveEmptyEntries));
                result.Add((bookId, title, author, publishedOn, categoryList));
            }

            return result;
        }
    }
}
