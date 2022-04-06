using House.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using House.Core.Dtos;
using House.Core.Domain;
using Microsoft.EntityFrameworkCore;
using House.Core.ServiceInterface;

namespace House.ApplicationServices.Services
{
    public class HouseServices : IHouseService
    {
        private readonly HouseDbContext _context;

        public HouseServices
            (
            HouseDbContext context
            )
        {
            _context = context;
        }
        public async Task<Home> Add(HouseDto dto)
        {
            Home home = new Home();

            home.Id = Guid.NewGuid();
            home.Category = dto.Category;
            home.Address = dto.Address;
            home.Size = dto.Size;
            home.Rooms = dto.Rooms;
            home.Price = dto.Price;
            home.ListedAt = DateTime.Now;

            await _context.Home.AddAsync(home);
            await _context.SaveChangesAsync();

            return home;
        }


        public async Task<Home> Delete(Guid id)
        {
            var houseId = await _context.Home
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Home.Remove(houseId);
            await _context.SaveChangesAsync();

            return houseId;
        }


        public async Task<Home> Update(HouseDto dto)
        {
            Home home = new Home();

            home.Id = dto.Id;
            home.Category = dto.Category;
            home.Address = dto.Address;
            home.Size = dto.Size;
            home.Rooms = dto.Rooms;
            home.Price = dto.Price;
            home.ListedAt = DateTime.Now;

            _context.Home.Update(home);
            await _context.SaveChangesAsync();

            return home;
        }

        public async Task<Home> GetAsync(Guid id)
        {
            var result = await _context.Home
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
