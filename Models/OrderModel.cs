using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livrini.Models
{
    public class Order
    {
        [Key]
        public int IdOrder { get; set; }
        public float TotalPrice { get; set; }
        public bool State { get; set; }

        // Clé étrangère pour IdUser
        [ForeignKey("User")]
        public int IdUser { get; set; }
        public virtual User User { get; set; }

        // Constructeur par défaut
        public Order()
        {

        }

        // Constructeur paramétré
        public Order(int idOrder, float totalPrice, bool state, int idUser)
        {
            IdOrder = idOrder;
            TotalPrice = totalPrice;
            State = state;
            IdUser = idUser;
        }

    }
}
