using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Collections.Generic;
namespace serverside.Core.Models
{
   public class User
        {
            public int Id { get; set; }
            public string NamaDepan { get; set; }
            public string NamaBelakang { get; set; }

            public string Username { get; set; }
            [JsonIgnore]
            public string PasswordHash { get; set; }
            [ForeignKey("Role")]
            public int RoleId { get; set; }
            public Role Role { get; set; }

            [JsonIgnore]
            public List<RefreshToken> RefreshTokens { get; set; }

        public string GetFullName()
        {
            return string.Concat(NamaDepan," ", NamaBelakang);
        }
    }
    public enum Role
    {
        Admin,
        Koordinator
    } 
}
