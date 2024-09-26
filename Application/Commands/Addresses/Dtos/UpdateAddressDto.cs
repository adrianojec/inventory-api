namespace Application.Commands.Addresses.Dtos
{
   public class UpdateAddressDto
   {
      public Guid Id { get; set; }
      public string Street { get; set; } = string.Empty;
      public int ZipCode { get; set; }
      public string City { get; set; } = string.Empty;
   }
}