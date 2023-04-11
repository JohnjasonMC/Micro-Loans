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
        public int Price { get; set; }

        [DisplayName("Gadget Image")]
        public string? GadgetImageURL { get; set; }
        [ValidateNever]
        public virtual UGadgetLoan UGadgetLoan { get; set; }
    }
}
