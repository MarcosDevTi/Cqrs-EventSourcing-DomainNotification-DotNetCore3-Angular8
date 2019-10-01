namespace Arch.Domain.Entities.ValueObjects
{
    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string AsString => $"{FirstName} {LastName}";
    }
}