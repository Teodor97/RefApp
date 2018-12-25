using RefApp.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RefApp.Data.Models
{
    public class Order:BaseModel<int>
    {
        public Order()
        {
            this.Lines = new HashSet<CartLine>();
        }
        public virtual ICollection<CartLine> Lines { get; set; }

        public bool IsShipped { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state name")]
        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
