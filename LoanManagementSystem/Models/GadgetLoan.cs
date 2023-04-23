using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LoanManagementSystem.Models
{
    public class GadgetLoan
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Gadget Name")]
        [DisplayName("Gadget Name")]
        public string GadgetName { get; set; }

        [Required(ErrorMessage = "Enter Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter Price")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a positive number.")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Enter Gadget Image URL")]

        [DisplayName("Gadget Image")]
        public string? GadgetImageURL { get; set; }
        [ValidateNever]
        public virtual UGadgetLoan UGadgetLoan { get; set; }

        public GadgetLoan() { }
        public GadgetLoan(int id, string gadgetName, string description, int price, string? gadgetImageURL)
        {
            Id = id;
            GadgetName = gadgetName;
            Description = description;
            Price = price;
            GadgetImageURL = gadgetImageURL;
        }
    }
}
