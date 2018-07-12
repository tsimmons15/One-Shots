using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePlayer.Entities.Interfaces
{
    class Component
    {
        public string ComponentID
        {
            get;
        }

        public bool Enabled
        {
            get;
            set;
        }
        /// <summary>
        /// Default Constructor
        /// Generates Component ID and sets up other Component specific features
        /// </summary>
        public Component()
        {
            this.ComponentID = "component" + Miscellaneous.GenerateID();
        }
    }
}
