using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePlayer.Entities
{
    class Entity
    {
        public string EntityID
        {
            get;
        }

        /// <summary>
        /// Default Constructor
        /// Generates Entity ID and sets up other Entity specific features
        /// </summary>
        public Entity()
        {
            this.EntityID = GenerateID();
        }

        private string GenerateID()
        {
            Guid id = Guid.NewGuid();
            return id.ToString("N");
        }
    }
}
