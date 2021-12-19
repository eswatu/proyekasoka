using serverside.Core.Models;

namespace serverside.Data.DTO
{
       public class UserDTO
        {
            public int Id { get; set; }
            public string NamaDepan { get; set; }
            public string NamaBelakang { get; set; }
            public Role Role { get; set; }

        }
}