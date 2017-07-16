using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowDataInChart
{
   public interface IClientRepository
    {
         List<Client> GetAllClientFromDb();
        Client GetClientById(int id);
    }
}
