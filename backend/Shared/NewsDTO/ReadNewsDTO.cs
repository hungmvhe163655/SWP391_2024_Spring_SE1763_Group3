using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.NewsDTO
{
    public record ReadNewsDTO
    (
         Guid Id ,
    //     DateTime CreatedAt ,
     //    DateTime? UpdatedAt,
        
         string Title , 

         string Description

    );
}
