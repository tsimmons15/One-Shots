using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePlayer.Entities
{
    /// <summary>
    /// <para>Items are physical objects that are used for a purpose, and usually are non-sentient. Think a key, rock
    /// or other such objects.</para>
    /// 
    /// <para>Another group of Items is Scenery, which is just an Item without an ability to moved/move, so it lacks an IMobile</para>
    /// </summary>
    class Item : Entity
    {
        /// <summary>
        /// <para>The natural-language name of an item, not the ID of the item</para>
        /// <para>Usually seen via the --info here-- user command</para>
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// <para>The natural-language description of an item that will be seen when they
        /// use the --look-- user command.</para>
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Default Constructor
        /// Sets up any default Item specifics
        /// </summary>
        public Item()
        {
            
        }
    }
}
