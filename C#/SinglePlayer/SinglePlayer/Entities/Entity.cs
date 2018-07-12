using SinglePlayer.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace SinglePlayer.Entities
{

    /// <summary>
    /// An Entity is a "thing" in the environment. It's a physical entity (see what I did there?)
    /// An entity is the root-class for a number of classes, such as Item and Entity, among others, but they will all 
    /// represent things which can be interacted with.
    /// </summary>
    class Entity
    {
        public string EntityID
        {
            get;
            private set;
        }

        public List<Component> Components
        {
            get;
            private set;
        }

        public List<IComponent> Interfaces
        {
            get;
            private set;
        }

        /// <summary>
        /// Default Constructor
        /// Generates Entity ID and sets up other Entity specific features
        /// </summary>
        public Entity()
        {
            this.EntityID = "entity" + Miscellaneous.GenerateID();
            this.Components = new List<Component>();
            this.Interfaces = new List<IComponent>();
        }

        private string GenerateID()
        {
            Guid id = Guid.NewGuid();
            return id.ToString("N");
        }
    }
}
