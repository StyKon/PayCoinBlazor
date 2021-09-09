using Microsoft.AspNetCore.Mvc;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.IRepositorys
{
    public interface IDeliveriesRepository
    {
        Task<ActionResult<IEnumerable<Delivery>>> GetDelivery();
        Task<ActionResult<Delivery>> GetDelivery(long id);
        Task<ActionResult<Delivery>> PutDelivery(long id, Delivery delivery);
        Task<ActionResult<Delivery>> PostDelivery(Delivery delivery);
        Task<ActionResult<Delivery>> DeleteDelivery(long id);
        bool DeliveryExists(long id);
    }
}
