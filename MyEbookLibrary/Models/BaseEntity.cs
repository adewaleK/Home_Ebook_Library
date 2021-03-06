using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Models
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
