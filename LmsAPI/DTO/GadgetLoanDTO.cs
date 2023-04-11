namespace LmsAPI.DTO
{
    public class GadgetLoanDTO
    {
        //public int Id { get; set; }
        public string GadgetName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string GadgetImageURL { get; set; }

        public GadgetLoanDTO() { }
        public GadgetLoanDTO(string gadgetName, string description, int price, string gadgetImageURL)
        {
            //Id = id;
            GadgetName = gadgetName;
            Description = description;
            Price = price;
            GadgetImageURL = gadgetImageURL;
        }
    }
}
