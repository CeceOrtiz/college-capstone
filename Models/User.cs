using D424.Validation;
using System.ComponentModel.DataAnnotations;

namespace D424.Models
#nullable disable
{
    public class User
    {
        private int _userID;
        private string _userEmail;
        private string _hashedPw;
        private string _username;

        [Key]
        public int UserID
        {
            get => _userID;
            set => _userID = value;
        }
        [Required(ErrorMessage ="Email is required.")]
        [UniqueEmail]
        public string UserEmail
        {
            get => _userEmail;
            set => _userEmail = value;
        }
        [Required(ErrorMessage = "Password is required.")]
        public string HashedPw
        {
            get => _hashedPw;
            set => _hashedPw = value;
        }
        [Required(ErrorMessage = "Username is required.")]
        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public User()
        {

        }

        public User(string email, string hashedPw, string username)
        {
            UserEmail = email;
            HashedPw = hashedPw;
            Username = username;
        }
    }
}
