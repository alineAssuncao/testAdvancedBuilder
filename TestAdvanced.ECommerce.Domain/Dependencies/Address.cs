public class Address
{
    public Address(string street, string city, string state, string zipCode, int number)
    {
        Street = Guard.Agaist.NullOrWhiteSpace(street);
        City = Guard.Agaist.NullOrWhiteSpace(city);
        Guard.Agaist.NullOrWhiteSpace(state);
        State = Guard.Agaist.LengthOutOfRange(state, 2, 2);
        Guard.Agaist.NullOrWhiteSpace(zipCode);
        ZipCode = Guard.Agaist.InvalidFormat(zipCode, nameof(zipCode), pattern: @"^\d{5}(-\d{3})?$");
        Number = Guard.Agaist.NegativeOrZero(number);
    }

    public string Street { get; }
    public string City { get; } 
    public string State { get; }
    public string ZipCode { get; }
    public int Number { get; }
    
}