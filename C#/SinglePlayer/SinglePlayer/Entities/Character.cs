using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SinglePlayer.Entities.Interfaces;

namespace SinglePlayer.Entities
{
    /// <summary>
    /// <para>Character is any anthropomorphic entity.</para>
    /// 
    /// <para>This category includes Player and NonPlayer characters, but does not include items nor 
    /// scenery (which are just items that cannot be moved/move)</para>
    /// </summary>
    class Character : Entity
    {
        private List<Item> Equipment;
        public Character()
        {
        }
    }
}
