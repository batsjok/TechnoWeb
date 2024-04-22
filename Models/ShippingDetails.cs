#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoWeb.Models
{
    public class ShippingDetails
    {
        [Required(ErrorMessage ="İsim Giriniz")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Lütfen Adres Başlığı giriniz !")]
        public string AdresBasligi { get; set; }
        [Required(ErrorMessage = "Lütfen Adres giriniz !")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Lütfen Şehir giriniz !")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Lütfen Mahalle giriniz !")]
        public string Mahalle { get; set; }
        
        public string PostaKodu { get; set; }
    }
}