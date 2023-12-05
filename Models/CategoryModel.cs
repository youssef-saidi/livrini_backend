using System.ComponentModel.DataAnnotations;

namespace Livrini.Models
{
    public class Category
    {
        // Attributs
        [Key]
        public int IdCategory { get; set; }
        public string Type { get; set; }

        // Constructeur par défaut
        public Category()
        {

        }

        // Constructeur paramétré
        public Category(int idCategory, string type)
        {
            IdCategory = idCategory;
            Type = type;
        }
    }
}
