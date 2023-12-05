using System.ComponentModel.DataAnnotations;

namespace Livrini.Models
{
    public class User
    {
        // Attributs
        [Key]
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string PositionLongitude { get; set; }
        public string PositionLatitude { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        [RegularExpression("^(admin|simpleUser)$", ErrorMessage = "Le rôle doit être 'admin' ou 'simpleUser'.")]
        public string Role { get; set; }

        // Constructeur par défaut
        public User()
        {

        }

        // Constructeur paramétré
        public User(int idUser, string name, string positionLongitude, string positionLatitude, string email, string password, string role)
        {
            IdUser = idUser;
            Name = name;
            PositionLongitude = positionLongitude;
            PositionLatitude = positionLatitude;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}