using House.Core.Domain;
using House.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace House.Core.ServiceInterface
{
    public interface IHouseService : IApplicationService
    {
        Task<Home> Add(HouseDto dto);

        Task<Home> Delete(Guid id);

        Task<Home> Update(HouseDto dto);

        Task<Home> GetAsync(Guid id);

    }
}
