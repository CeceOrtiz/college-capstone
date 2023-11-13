namespace D424.Models
#nullable disable
{
    public class Fabric : Supply
    {
        private string _fabricType;
        private string _fabricCount;
        private string _fabricColor;

        public string FabricType
        {
            get => _fabricType;
            set => _fabricType = value;
        }
        public string FabricCount
        {
            get => _fabricCount;
            set => _fabricCount = value;
        }
        public string FabricColor
        {
            get => _fabricColor;
            set => _fabricColor = value;
        }

        public Fabric(int supplyID, string itemName, string itemType, int quantity, string brand, string storage, int userID,
            string fabricType, string fabricCount, string fabricColor) : base(supplyID, itemName, itemType, quantity, brand, storage, userID)
        {
            FabricType = fabricType;
            FabricCount = fabricCount;
            FabricColor = fabricColor;
        }
    }
}
