using Application.Commands.Addresses.Dtos;

namespace API.Controllers.Addresses.InputModels
{
   public class UpdateAddressInputModel
   {
      public string Street { get; set; } = string.Empty;
      public int ZipCode { get; set; }
      public string City { get; set; } = string.Empty;

      public UpdateAddressDto ToUpdateAddressDto(Guid id)
      {
         var address = new UpdateAddressDto
         {
            Id = id,
            Street = Street,
            ZipCode = ZipCode,
            City = City
         };

         return address;
      }
   }
}