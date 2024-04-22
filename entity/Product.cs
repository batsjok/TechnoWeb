
#nullable disable
using System;
using System.ComponentModel;

namespace TechnoWeb.Models
{
    public class Product
    {

        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Fiyat")]
        public double Price { get; set; }
        [DisplayName("Stok adeti")]
        public int Stock { get; set; }
        public string Image { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }




        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
    }
}
