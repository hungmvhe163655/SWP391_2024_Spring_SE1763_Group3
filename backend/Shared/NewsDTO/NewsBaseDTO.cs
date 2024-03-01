using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.NewsDTO
{
    public abstract record NewsBaseDTO
    {
        [Required(ErrorMessage = "Create Date is required")]
        public DateTime CreateDate { get; init; }

        public DateTime UpdateDate { get; init; }

        [MaxLength(255, ErrorMessage = "Maximum length for the Title is 255 characters.")]
        public string Title { get; init; }

        [MaxLength(1000, ErrorMessage = "Maximum length for the Description is 1000 characters.")]
        public string Description { get; init; }

        public string HomeManagerId { get; init; }
    }
}
