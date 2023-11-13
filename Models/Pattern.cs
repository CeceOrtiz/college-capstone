using System.ComponentModel.DataAnnotations;

namespace D424.Models
#nullable disable
{
    public class Pattern
    {
        private int _patternID;
        private string _name;
        private string _dimensions;
        private string _createdBy;
        private string _source;
        private string _location;
        private string _status;
        private int _userID;

        [Key]
        public int PatternID
        {
            get => _patternID;
            set => _patternID = value;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Dimensions
        {
            get => _dimensions;
            set => _dimensions = value;
        }
        public string CreatedBy
        {
            get => _createdBy;
            set => _createdBy = value;
        }
        public string Source
        {
            get => _source;
            set => _source = value;
        }
        public string Location
        {
            get => _location;
            set => _location = value;
        }
        public string Status
        {
            get => _status;
            set => _status = value;
        }
        public int UserID
        {
            get => _userID;
            set => _userID = value;
        }
        public Pattern(int patternID, string name, string dimensions, string createdBy, string source, string location, string status,
            int userID)
        {
            PatternID = patternID;
            Name = name;
            Dimensions = dimensions;
            CreatedBy = createdBy;
            Source = source;
            Location = location;
            Status = status;
            UserID = userID;
        }
    }
}
