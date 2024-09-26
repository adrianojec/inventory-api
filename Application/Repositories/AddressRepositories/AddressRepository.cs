using Application.Context;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.AddressRepositories
{
   public class AddressRepository : IAddressRepository
   {
      private readonly IDataContext _context;
      public AddressRepository(IDataContext context)
      {
         _context = context;
      }

      public async Task Add(Address input)
      {
         _context.Addresses.Add(input);
         await _context.SaveChangesAsync();
      }

      public async Task<List<Address>> GetAll()
      {
         return await _context.Addresses.ToListAsync();
      }

      public async Task<Address> GetById(Guid id)
      {
         var address = await _context.Addresses.FirstOrDefaultAsync(address => address.Id == id);

         return address;
      }

      public async Task Update(Address input)
      {
         var address = await GetById(input.Id);
         address = input;
         await _context.SaveChangesAsync();
      }

      public Task Delete(Guid id)
      {
         throw new NotImplementedException();
      }
   }
}