using System.ComponentModel.DataAnnotations;

namespace AddressBook.Data.Models
{
    public class Address
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "First Name should be a maximum of 50 characters")]
        
        public string Name { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "First Name should be a maximum of 50 characters")]

        public string LastName { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "First Name should be a maximum of 50 characters")]

        public string Town { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "First Name should be a maximum of 50 characters")]

        public string Street { get; set; }
        [Required]

        public int HouseNumber { get; set; }
    }
}
