using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project2.Models
{
    [Table("Product")]
    public class Product
    {

        //ya Emyyy Hellooo wa74tiiny

        [Key]
        [Column("id")]
        public int Id { get; set; }

        
        [Column("name")]
        public string Name { get; set; }


        [Column("price")]
        public float Price { get; set; }


        [Column("image")]
        [StringLength(100)]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }


        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }


        [Column("category_id")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }


    }
}