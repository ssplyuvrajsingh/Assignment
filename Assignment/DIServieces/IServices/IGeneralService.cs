using Assignment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment.DIServieces.IServices
{
    public interface IGeneralService
    {
        string GetISO8601Format();
        Task<List<MinimaModel>> ReadMinima();
    }
}
