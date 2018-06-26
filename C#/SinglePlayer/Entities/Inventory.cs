using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudServer.Entities
{
    class Inventory : IComponent
    {
        private bool ExternalAccessAllowed;
        List<Entity> inventory;
    }
}
