using Proyecto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Core.Interfaces
{
   public interface IPeopleApiServices
    {

        Task<dynamic> Get();
        Task<dynamic> GetId(int id);
    }
}
