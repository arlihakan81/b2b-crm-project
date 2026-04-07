namespace CRM.Application.Requests.Contacts
{
    public class CreateContactRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Title { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public Guid AccountId { get; set; }
        public bool IsPrimary { get; set; }
    }

    public class UpdateContactRequest : CreateContactRequest { }

}
