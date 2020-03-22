namespace UszyjMaseczke.Domain
{
    public class Help
    {
        public int Id { get; set; }
        public HelpType HelpType { get; set; }
        public string Kind { get; set; }
        public int? Amount { get; set; }
    }
}