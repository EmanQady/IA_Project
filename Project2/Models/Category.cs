using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{

    [Table("Category")]
    public class Category
    {
        [Key]
        [Column("id")]
        public int CategoryId { get; set; }


        [StringLength(50)]
        [Column("name")]
        public string Name { get; set; }

        
        [Column("number_of_products")]
        public int NumberOfProducts { get; set; }

        public virtual ICollection<Product> Product { get; set; }


    }
}