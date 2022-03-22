using System.ComponentModel.DataAnnotations;

namespace React_WebAPI.Models
{
    public class Contact
    {
        [Key]
        public int id { get; set; }
        public string Name
        {
            get;
            set;
        }

       
        [DataType(DataType.PhoneNumber), StringLength(10)]
        public string Mobile { get; set; }
        public string City { get; set; }

        [DataType(DataType.PostalCode), StringLength(6)]
        public string PinCode { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        public string Date { get; set; } = DateTime.UtcNow.ToString();
    }
}

