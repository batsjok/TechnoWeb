#nullable disable
using System;

namespace TechnoWeb.Models
{
    public class CategoryModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }

        
    }
}
