namespace Organisation.Models
{
    public class CompanyViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public DateTime Establish { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
