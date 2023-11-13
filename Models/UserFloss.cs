using System.ComponentModel.DataAnnotations;

namespace D424.Models
#nullable disable
{
    public class UserFloss
    {
        private int _userID;
        private int _flossID;
        private int _quantity;
        private string _storage;

        [Key]
        public int UserID
        {
            get => _userID;
            set => _userID = value;
        }
        [Key]
        public int FlossID
        {
            get => _flossID;
            set => _flossID = value;
        }
        public int Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }
        public string Storage
        {
            get => _storage;
            set => _storage = value;
        }

        public UserFloss(int userID, int flossID, int quantity, string storage)
        {
            UserID = userID;
            FlossID = flossID;
            Quantity = quantity;
            Storage = storage;
        }
    }
}
