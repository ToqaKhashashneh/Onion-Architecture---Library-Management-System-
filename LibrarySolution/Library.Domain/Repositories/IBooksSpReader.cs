using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Repositories
{
    public interface IBooksSpReader
    {

        Task<List<(int BookId, string Title, string? Author, DateTime? PublishedOn, List<string> Categories)>>
            ReadAllWithCategoriesAsync();
    }
}
