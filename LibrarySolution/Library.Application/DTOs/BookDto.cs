using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs
{
    public record BookDto
    (
        int Id,

        string Title,

        string? Author,

        DateTime? PublishedOn,

        List<int> CategoryIds

    );


    public record CreatedBookDto
        (
       
            string Title,

            string? Author,

            DateTime? PublishedOn,

            List<int> CategoryIds

        
        );


    public record UpdatedBookDto
        (
        int Id,
        
        string Title,

        string? Author,

        DateTime? PublishedOn,

        List<int> CategoryIds
        
        );


   
}
