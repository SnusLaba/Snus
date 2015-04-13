using SnusData.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_lb2.Model
{
    public class ClientViewModel
    {
        public static Func<Users, ClientViewModel> Converter = x => new ClientViewModel
        {
            Id = x.Id,
            FirstName = x.FirstName,
            SecondName = x.SecondName,
            Age = x.Age,
            Role = x.Role!=null ? x.Role.Name : "<-none Role->",
            Sex = x.Sex,
            Email = x.Email,
            Password = x.Password,
            Location = x.Location != null ? string.Format("City: {0}, Country {1}, Address: {2}, Telephone: {3}",
                            x.Location.Country.City.Name, x.Location.Country, x.Location.Address, x.Location.Telephone) : "<-none Location->"
        };
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int? Age { get; set; }
        public string Role { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
    }
}
