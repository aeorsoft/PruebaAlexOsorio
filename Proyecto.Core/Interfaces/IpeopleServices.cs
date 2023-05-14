using Proyecto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Core.Interfaces
{
    public  interface IpeopleServices
    {
        Task<IEnumerable<Peoples>> GetPeople();
    }
}
