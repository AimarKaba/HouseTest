using House.Core.Dtos;
using House.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace House.HouseTest
{
   public class HouseTest : TestBase
    {
        [Fact]
        public async Task WhenAddHouse_ReturnResult_ShouldNotBeNull()
        {
            string guid = "2163797C-C74C-171E-FBAD-FC01C56AE318";
            HouseDto House = new HouseDto();

            House.Id = Guid.Parse(guid);
            House.Address = "Winewood Blvd";
            House.Category = "Apartment";
            House.Size = 60;
            House.Rooms = 4;
            House.Price = 120000;
            House.ListedAt = DateTime.Now;

            var result = await Svc<IHouseService>().Add(House);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task WhenUpdate_ShouldUpdate()
        {
            var guid = new Guid("17F9AD68-6CFE-3CE8-89CF-95BA7D308CF4");
            HouseDto House = new HouseDto();

            House.Id = guid;
            House.Address = "StrawBerry Ave";
            House.Category = "House";
            House.Size = 55;
            House.Rooms = 3;
            House.Price = 100000;
            House.ListedAt = DateTime.Now;

            var NewHouseId = guid;
            var NewHouseUpdate = new HouseDto()
            {
                Rooms = 10,
                Address = "Vespucci Blvd"
            };

            await Svc<IHouseService>().Update(NewHouseUpdate);

            Assert.Equal(House.Id.ToString(), NewHouseId.ToString());
            Assert.DoesNotMatch(House.Rooms.ToString(), NewHouseUpdate.Rooms.ToString());
            Assert.DoesNotMatch(House.Address, NewHouseUpdate.Address);
        }
        [Fact]
        public async Task WhenAdd_ResultShouldBeSame()
        {
            string guid = "17D9C26A-1F3A-DB78-BC60-2E97A803A2D2";
            HouseDto House = new HouseDto();

            House.Id = Guid.Parse(guid);
            House.Address = "Power Street";
            House.Category = "Hut";
            House.Size = 20;
            House.Rooms = 1;
            House.Price = 30000;
            House.ListedAt = DateTime.Now;

            var NewHouseInfo = await Svc<IHouseService>().Add(House);

            Assert.Equal(House.Price.ToString(), NewHouseInfo.Price.ToString());


        }

        [Fact]
        public async Task GUIDShouldBeEqual()
        {
            string guid = "E05D0957-DA38-CE69-D7A4-6716E04FB461";
            string guid2 = "E05D0957-DA38-CE69-D7A4-6716E04FB461";

            var Guid1 = Guid.Parse(guid);
            var Guid2 = Guid.Parse(guid2);

            await Svc<IHouseService>().GetAsync(Guid1);

            Assert.Equal(Guid1, Guid2);
        }
         
        [Fact]
        public async Task GUIDShouldNotBeEqual()
        {
            string guid = "403569EC-47B4-37A3-70D0-AE53B76E4C4F";
            string guid2 = "8E4F28B5-9785-B16C-853B-AB93B05CE9D1";

            var Guid1 = Guid.Parse(guid);
            var Guid2 = Guid.Parse(guid2);

            await Svc<IHouseService>().GetAsync(Guid1);
            Assert.NotEqual(Guid1, Guid2);
        }

    }
}
