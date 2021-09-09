using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayCoin.Server.Models;

namespace PayCoin.Server.IRepositorys
{
    public interface IShippingsRepository
    {
        Task<ActionResult<IEnumerable<Shipping>>> GetShipping();
        Task<ActionResult<Shipping>> GetShipping(long id);
        Task<ActionResult<Shipping>> PutShipping(long id, Shipping shipping);
        Task<ActionResult<Shipping>> PostShipping(Shipping shipping);
        Task<ActionResult<Shipping>> DeleteShipping(long id);
        bool ShippingExists(long id);
    }
}
