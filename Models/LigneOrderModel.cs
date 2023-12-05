using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livrini.Models
{
    public class LigneOrder
    {
        [Key]
        public int IdLigneOrder { get; set; }
        public int Quantity { get; set; }

        // Clé étrangère pour IdDish
        [ForeignKey("Dish")]
        public int IdDish { get; set; }
        public virtual Dish Dish { get; set; }

        // Clé étrangère pour IdOrder
        [ForeignKey("Order")]
        public int IdOrder { get; set; }
        public virtual Order Order { get; set; }

        // Constructeur par défaut
        public LigneOrder()
        {

        }

        // Constructeur paramétré
        public LigneOrder(int idLigneOrder, int quantity, int idDish, int idOrder)
        {
            IdLigneOrder = idLigneOrder;
            Quantity = quantity;
            IdDish = idDish;
            IdOrder = idOrder;
        }
    }
}