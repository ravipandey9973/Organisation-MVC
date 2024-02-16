namespace Organisation.Models.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Department { get; set; }=string.Empty;    
        public DateTime Establish { get; set; }
        public string Address { get; set; }=string.Empty;

        public string DateOfFormatted
        {
            get { return Establish.ToString("dd-MM-yyyy"); }
        }
    }
   
}
