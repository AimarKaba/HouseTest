using House.Core.Domain;
using House.Core.Dtos;
using House.Core.ServiceInterface;
using House.Data;
using House.Models;
using House.Models.House;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace House.Controllers
{
    public class HouseController : Controller
    {
        private readonly HouseDbContext _context;
        private readonly IHouseService _HouseService;

        public HouseController
            (
            HouseDbContext context,
            IHouseService HouseService
            )
        {
            _context = context;
            _HouseService = HouseService;
        }

        //ListItem
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Home
                .OrderByDescending(y => y.ListedAt)
                .Select(x => new HouseListItem
                {
                    Id = x.Id,
                    Category = x.Category,
                    Address = x.Address,
                    Size = x.Size,
                    Rooms = x.Rooms,
                    Price = x.Price,
                    ListedAt = x.ListedAt
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            HouseViewModel model = new HouseViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseViewModel model)
        {
            var dto = new HouseDto()
            {
                Id = model.Id,
                Category = model.Category,
                Address = model.Address,
                Size = model.Size,
                Rooms = model.Rooms,
                Price = model.Price,
                ListedAt = model.ListedAt,
               
            };

            var result = await _HouseService.Add(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var home = await _HouseService.Delete(id);
            if (home == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var home = await _HouseService.GetAsync(id);

            if (home == null)
            {
                return NotFound();
            }


            var model = new HouseViewModel();

            model.Id = home.Id;
            model.Category = home.Category;
            model.Address = home.Address;
            model.Size = home.Size;
            model.Rooms = home.Rooms;
            model.Price = home.Price;
            model.ListedAt = home.ListedAt;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HouseViewModel model)
        {
            var dto = new HouseDto()
            {
                Id = model.Id,
                Category = model.Category,
                Address = model.Address,
                Size = model.Size,
                Rooms = model.Rooms,
                Price = model.Price,
                ListedAt = model.ListedAt,
                
            };

            var result = await _HouseService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);
        }
    }
}