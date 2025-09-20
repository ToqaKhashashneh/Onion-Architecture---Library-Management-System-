using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs
{
    public record CategoryDto
    (
        int Id,
        
        string Name
        
    );

    public record CreatedCategoryDto
    (
        string Name   
    );

    public record UpdatedCategoryDto
    (
        int Id, 
        string Name
    );
    
}
