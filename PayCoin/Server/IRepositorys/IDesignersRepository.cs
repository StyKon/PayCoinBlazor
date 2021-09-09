using Microsoft.AspNetCore.Mvc;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.IRepositorys
{
    public interface IDesignersRepository
    {
        Task<ActionResult<IEnumerable<Designer>>> GetDesigner();
        Task<ActionResult<Designer>> GetDesigner(long id);
        Task<ActionResult<Designer>> PutDesigner(long id, Designer designer);
        Task<ActionResult<Designer>> PostDesigner(Designer designer);
        Task<ActionResult<Designer>> DeleteDesigner(long id);
        bool DesignerExists(long id);
    }
}
