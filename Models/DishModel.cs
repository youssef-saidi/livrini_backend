using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livrini.Models
{
    public class Dish
    {
        // Attributs
        [Key]
        public int IdDish { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ImagePath { get; set; }

        // Clé étrangère pour IdCategory
        [ForeignKey("Category")]
        public int IdCategory { get; set; }
        public virtual Category Category { get; set; }

        // Clé étrangère pour IdRestaurant
        [ForeignKey("Restaurant")]
        public int IdRestaurant { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        // Constructeur par défaut
        public Dish()
        {

        }

        // Constructeur paramétré
        public Dish(int idDish, string title, string description, float price, string imagePath, int idCategory, int idRestaurant)
        {
            IdDish = idDish;
            Title = title;
            Description = description;
            Price = price;
            ImagePath = imagePath;
            IdCategory = idCategory;
            IdRestaurant = idRestaurant;
        }
    }
}