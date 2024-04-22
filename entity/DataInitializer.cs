using System;
using System.Collections.Generic;
using System.Linq;
using TechnoWeb.Models;

namespace TechnoWeb.entity
{
    public class DataInitializer
    {
        private readonly DataContext _context;

        public DataInitializer(DataContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            if (!_context.Categories.Any())
            {
                // Kategoriler henüz eklenmemiş, ekleme işlemlerini gerçekleştir
                List<Category> categories = new List<Category>()
                {
                    new Category() {Id=1, Name = "Macbook", Description = "Macbook Çeşitleri" },
                    new Category() {Id=2, Name = "Iphone", Description = "Iphone Çeşitleri" },
                    new Category() {Id=3, Name = "Ipad", Description = "Ipad Çeşitleri" },
                    new Category() {Id=4, Name = "Airpods", Description = "Airpods Çeşitleri" },
                    new Category() {Id=5, Name = "Mac", Description = "Mac Çeşitleri" },
                    new Category() {Id=1002, Name = "Watch", Description = "Watch Çeşitleri" },
                    new Category() {Id=2002, Name = "Aksesuar", Description = "Apple Aksesuar Çeşitleri" }
                };

                _context.Categories.AddRange(categories);
            }

            if (!_context.Products.Any())
            {
                // Ürünler henüz eklenmemiş, ekleme işlemlerini gerçekleştir
                List<Product> products = new List<Product>()
                {
                    new Product() { Name = "Macbook Pro M2", Description = "MacBook Pro, 22 saate kadar pil ömrü sunuyor. Bu bir Mac’te şimdiye kadar sunulan en uzun pil ömrü.", Stock = 100, Price = 70000, CategoryId = 1, IsApproved = true, IsHome = true, Image = "" },
                    new Product() { Name = "Macbook Air M1", Description = "Süper hafif ve inanılmaz ince MacBook Air hayatınızın her anında yanınızda olacak şekilde ve gezegenimiz düşünülerek tasarlandı.", Stock = 200, Price = 50000, CategoryId = 1, IsApproved = true, Image="https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/macbook-air-space-gray-select-201810?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1664472289661" },
                    new Product() { Name = "Iphone 15 Pro", Description = "Tamamen yeni bir iPhone çip sınıfı olan A17 Pro, şimdiye kadarki en iyi grafik performansımızı sunuyor.", Stock = 10000, Price = 30000, CategoryId = 2, IsApproved = true, IsHome = true, Image="" },
                    new Product() { Name = "Ipad Pro", Description = "M2 çip. Apple çipin yeni nesli M2 çip, yüzde 15’e kadar daha hızlı performans sunan 8 çekirdekli CPU’ya ve yüzde 35’e kadar dahahızlı grafik performansı sunan 10 çekirdekli GPU’ya sahip.", Stock = 100, Price = 25000, CategoryId = 3, IsApproved = true, IsHome = true, Image="" },
                    new Product() { Name = "Iphone 14 Pro Max", Description = "Her zamankinden daha gelişmiş 48 MP Ana kamera detaylar ve renkler konusunda yeni bir seviyede süper yüksek çözünürlüklü fotoğraflar çekiyor.", Stock = 100, Price = 67000, CategoryId = 2, IsApproved = true, Image="" },
                    new Product() { Name = "IMac", Description = "iMac, geniş 24 inç Retina ekranı sayesinde büyüleyici bir filmve oyun deneyimi, multitasking işlemleri ve daha pek çok şey için size inanılmaz bir tuval sağlıyor.", Stock = 100, Price = 70000, CategoryId = 5, IsApproved = true, Image="" },
                    new Product() { Name = "Apple Watch Ultra", Description = "Apple Watch Ultra 2, eşsiz bir performans için tasarlandı. Hafif ve sağlam titanyum kasa aşınmaya karşı dayanıklı.", Stock = 100, Price = 70000, CategoryId = 1002, IsApproved = true, Image="" },
                    new Product() { Name = "Apple Watch SE", Description = "Bağlantıda kalmanın kolay yolları. Motivasyon sağlayan fitness ölçümleri. Yenilikçi sağlık ve güvenlik özellikleri.", Stock = 100, Price = 70000, CategoryId = 1002, IsApproved = true, Image="" },
                    new Product() { Name = "AirPods Max", Description = "Kulak çevresi kulaklık kavramı baştan aşağı yeniden düşünüldü. Kulaklık yastıklarından taç kısmına kadar, kafanıza kusursuzca oturarak optimum akustik yalıtımı yaratacak şekilde tasarlanan AirPods Max sizi olağanüstü bir ses deneyimine davet ediyor.", Stock = 100, Price = 70000, CategoryId = 4, IsApproved = true, Image="" }
                };

                _context.Products.AddRange(products);
            }

            _context.SaveChanges();
        }
    }
}
