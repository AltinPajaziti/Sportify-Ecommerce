using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sportify.Datalayer.DTOs;

namespace sportify.Datalayer.Interfaces
{
    public interface IOrders
    {
        Task<List<OdersDto>> GetAllORders();
    }
}
