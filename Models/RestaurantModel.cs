using System.ComponentModel.DataAnnotations;

namespace Livrini.Models
{
    public class Restaurant
    {
        // Attributs
        [Key]
        public int IdRestaurant { get; set; }
        public string Title { get; set; }
        public string Rate { get; set; }
        public string DeliveryTime { get; set; }
        public string DeliveryPrice { get; set; }
        public string ImagePath { get; set; }
        public string PositionLongitude { get; set; }
        public string PositionLatitude { get; set; }
        public string PlaceName { get; set; }

        // Constructeur par défaut
        public Restaurant()
        {

        }

        // Constructeur paramétré
        public Restaurant(int idRestaurant, string title, string rate, string deliveryTime, string deliveryPrice,
                          string imagePath, string positionLongitude, string positionLatitude, string placeName)
        {
            IdRestaurant = idRestaurant;
            Title = title;
            Rate = rate;
            DeliveryTime = deliveryTime;
            DeliveryPrice = deliveryPrice;
            ImagePath = imagePath;
            PositionLongitude = positionLongitude;
            PositionLatitude = positionLatitude;
            PlaceName = placeName;
        }
    }
}