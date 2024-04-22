#nullable disable
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace TechnoWeb.Models
{
    public class Category
    {

        public int Id { get; set; }

        [DisplayName("Kategori Adı")]
        [StringLength(maximumLength:20,ErrorMessage ="En fazla 20 karakter girebilirsiniz.")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        [StringLength(maximumLength:40,ErrorMessage ="En fazla 20 karakter girebilirsiniz.")]
        public string Description { get; set; }

        public List<Product> Products { get; set; }

        
    }
}
