using Application.Commands.Addresses.Dtos;
using Application.Core;

namespace Application.Commands.Addresses.Interfaces
{
   public interface IUpdateAddressCommand
   {
      Task<Result<bool>> ExecuteCommand(UpdateAddressDto input);
   }
}