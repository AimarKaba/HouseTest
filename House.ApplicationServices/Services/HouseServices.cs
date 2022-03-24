using House.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace House.ApplicationServices.Services
{
    public class HouseServices
    {
        private readonly HouseDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HouseServices
            (
            HouseDbContext context,
            IWebHostEnvironment env
            )
        {
            _context = context;
            _env = env;
        }
    }
}
