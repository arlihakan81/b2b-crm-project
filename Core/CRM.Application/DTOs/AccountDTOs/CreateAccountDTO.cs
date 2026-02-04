namespace CRM.Application.DTOs.AccountDTOs
{
    public class CreateAccountDTO
    {
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? Industry { get; set; }
        public int? NumberOfEmployees { get; set; }
        public decimal? AnnualRevenue { get; set; }
        public string? Description { get; set; }
        public string? BillingAddress { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }


    }

    public class UpdateAccountDTO : CreateAccountDTO
    {
    }

}
