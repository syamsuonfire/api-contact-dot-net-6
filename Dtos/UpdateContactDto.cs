namespace ContactsApi.Dtos
{
    public class UpdateContactDto
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public long Phone { get; set; }
        public string? Address { get; set; }
    }
}