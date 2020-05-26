using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    [Table("Cart")]
    public class Cart
    {

        [Key]
        [ForeignKey("Product")]
        [Column("product_id")]
        public int ProductId { get; set; }


        [Column("added_at")]
        public DateTime Added_At { get; set; }

        public virtual Product Product { get; set; }
    }
}