using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudServer.Entities
{
    class Entity
    {

        /// <summary>
        /// A listing of various commonly used components so you don't need to search through the list of components to check if common components are present
        /// </summary>
        public enum COMPONENT_MASK
        {
            /// <summary>
            /// An empty Entity, for all intents-and-purposes a null Entity.
            /// </summary>
            COMPONENT_EMPTY = 0,
            /// <summary>
            /// An Entity which contains items
            /// </summary>
            COMPONENT_INVENTORY = 1,
            /// <summary>
            /// An entity which can move around the map
            /// </summary>
            COMPONENT_MOBILE = 2,
            /// <summary>
            /// An entity which can be interacted with
            /// </summary>
            COMPONENT_INTERACTIVE = 4,
            /// <summary>
            /// An entity which exists 'physically' on the map
            /// </summary>
            COMPONENT_LOCATION = 8,
            /// <summary>
            /// An Entity which has city/order/etc... Affiliations
            /// Handles whether the Entity can interact with the various channels
            /// </summary>
            COMPONENT_AFFILIATIONS = 16,
            /// <summary>
            /// An entity which has a list of attributes associated with it
            /// Attributes include things like strength, agility, constitution, etc...
            /// </summary>
            COMPONENT_ATTRIBUTES = 32,
            /// <summary>
            /// An entity which has a list of 
            /// </summary>
            COMPONENT_COMBATANT = 64,
            /// <summary>
            /// An entity which casts arcane spells
            /// </summary>
            COMPONENT_ARCANE = 128,
            /// <summary>
            /// An entity which casts divine spells
            /// </summary>
            COMPONENT_DIVINE = 256
        }

        /// <summary>
        /// Unique reference for an entity
        /// </summary>
        long UniqueID { get; set; }

        /// <summary>
        /// The mask of common components this entity has available
        /// </summary>
        long ComponentMask { get; set; }

        /// <summary>
        /// The list of components the entity has available
        /// </summary>
        List<IComponent> Components { get; set; }

        /// <summary>
        /// Constructor for creating an entity based off a currently existing list of components of an entity
        /// </summary>
        /// <param name="initComponents">The list of components of the currently existing entity</param>
        public Entity(List<IComponent> initComponents)
        {
            this.Components = initComponents;
            for (int i = 0; i < initComponents.Count; i++)
            {
                /*...*/
            }

            GenerateUniqueID();
        }

        /// <summary>
        /// Constructor for creating an entity based off a currently existing entity
        /// </summary>
        /// <param name="initEntity">The entity from which to copy values</param>
        public Entity(Entity initEntity)
        {
            this.ComponentMask = initEntity.ComponentMask;
            this.Components = initEntity.Components;

            GenerateUniqueID();
        }

        /// <summary>
        /// Constructor for creating an entity based off a currently existing entity mask
        /// </summary>
        /// <param name="initMask"> The mask from which to build the entity </param>
        public Entity(long initMask)
        {
            int maskBits = (int)Math.Ceiling(Math.Log10(initMask));
            long mask = 1;

            this.Components = new List<IComponent>();

            for (int i = 0; i < maskBits; i++)
            {
                if ((mask & initMask) != 0)
                {
                    switch(mask)
                    {
                        case (long)COMPONENT_MASK.COMPONENT_MOBILE:
                            //this.Components.Add(new Mobile());
                            break;
                        case (long)COMPONENT_MASK.COMPONENT_LOCATION:

                            break;
                        case (long)COMPONENT_MASK.COMPONENT_INVENTORY:

                            break;
                        case (long)COMPONENT_MASK.COMPONENT_INTERACTIVE:

                            break;
                        case (long)COMPONENT_MASK.COMPONENT_DIVINE:

                            break;
                        case (long)COMPONENT_MASK.COMPONENT_COMBATANT:

                            break;
                        case (long)COMPONENT_MASK.COMPONENT_ATTRIBUTES:

                            break;
                        case (long)COMPONENT_MASK.COMPONENT_ARCANE:

                            break;
                    }
                }

                mask <<= 1;
            }
        }


        private void GenerateUniqueID()
        {
            this.UniqueID = 10101;
        }
    }
}
