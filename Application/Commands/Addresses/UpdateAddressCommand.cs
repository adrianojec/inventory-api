using Application.Commands.Addresses.Dtos;
using Application.Commands.Addresses.Interfaces;
using Application.Core;
using Application.Repositories.AddressRepositories;

namespace Application.Commands.Addresses
{
   public class UpdateAddressCommand : IUpdateAddressCommand
   {
      private readonly IAddressRepository _addressRepository;
      public UpdateAddressCommand(IAddressRepository addressRepository)
      {
         _addressRepository = addressRepository;
      }
      public async Task<Result<bool>> ExecuteCommand(UpdateAddressDto input)
      {
         var address = await _addressRepository.GetById(input.Id);

         if (address == null) return Result<bool>.Failure("No address found.");

         if (string.IsNullOrEmpty(input.Street)) return Result<bool>.Failure("Street is required.");
         if (input.ZipCode == 0) return Result<bool>.Failure("Zip code is invalid.");
         if (string.IsNullOrEmpty(input.City)) return Result<bool>.Failure("City is required.");

         address.Street = input.Street;
         address.ZipCode = input.ZipCode;
         address.City = input.City;

         await _addressRepository.Update(address);

         return Result<bool>.Success(true);
      }
   }
}