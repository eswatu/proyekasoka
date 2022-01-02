using System.Text.Json.Serialization;
using serverside.Core.Models;

namespace serverside.Data.Resource
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string NamaDepan { get; set; }
        public string NamaBelakang { get; set; }
        public string Username { get; set; }
        public int Role { get; set; }
        public string JwtToken { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }

        public AuthenticateResponse(User user, string jwtToken, string refreshToken)
        {
            Id = user.Id;
            NamaDepan = user.NamaDepan;
            NamaBelakang = user.NamaBelakang;
            Username = user.Username;
            JwtToken = jwtToken;
            Role = ((int)user.Role);
            RefreshToken = refreshToken;
        }
    }
}