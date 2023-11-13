using System.ComponentModel.DataAnnotations;

namespace D424.Models
#nullable disable
{
    public class Supply
    {
        private int _supplyID;
        private string _itemName;
        private string _itemType;
        private int _quantity;
        private string _brand;
        private string _storage;
        private int _userID;

        [Key]
        public int SupplyID
        {
            get => _supplyID;
            set => _supplyID = value;
        }
        public string ItemName
        {
            get => _itemName;
            set => _itemName = value;
        }
        public string ItemType
        {
            get => _itemType;
            set => _itemType = value;
        }
        public int Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }
        public string Brand
        {
            get => _brand;
            set => _brand = value;
        }
        public string Storage
        {
            get => _storage;
            set => _storage = value;
        }
        public int UserID
        {
            get => _userID;
            set => _userID = value;
        }

        public Supply(int supplyID, string itemName, string itemType, int quantity, string brand, string storage, int userID)
        {
            SupplyID = supplyID;
            ItemName = itemName;
            ItemType = itemType;
            Quantity = quantity;
            Brand = brand;
            Storage = storage;
            UserID = userID;
        }
    }
}
