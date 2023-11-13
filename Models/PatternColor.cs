using System.ComponentModel.DataAnnotations;

namespace D424.Models
#nullable disable
{
    public class PatternColor
    {
        private int _patternID;
        private int _flossID;

        [Key]
        public int PatternID
        {
            get => _patternID;
            set => _patternID = value;
        }
        [Key]
        public int FlossID
        {
            get => _flossID;
            set => _flossID = value;
        }

        public PatternColor(int patternID, int flossID)
        {
            PatternID = patternID;
            FlossID = flossID;
        }
    }
}
