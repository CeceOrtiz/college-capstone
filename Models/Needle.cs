namespace D424.Models
#nullable disable
{
    public class Needle : Supply
    {
        private int _needleSize;

        public int NeedleSize
        {
            get => _needleSize;
            set => _needleSize = value;
        }

        public Needle(int supplyID, string itemName, string itemType, int quantity, string brand, string storage, int userID, int needleSize)
            : base(supplyID, itemName, itemType, quantity, brand, storage, userID)
        {
            NeedleSize = needleSize;
        }
    }
}
