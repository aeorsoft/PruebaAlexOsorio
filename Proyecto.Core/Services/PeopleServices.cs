using Proyecto.Core.Entities;
using Proyecto.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto.Core.Services
{
    public class PeopleServices : IpeopleServices
    {
        private readonly IPeopleRepository _peopleRepository;
        public PeopleServices(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        public async Task<IEnumerable<Peoples>> GetPeople()
        {
            var peoples = await _peopleRepository.GetPeople();
            return peoples;
        }
    }
}
