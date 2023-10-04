using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {

        }
        public override string Execute(Player p, string[] text)
        {
            IHaveInventory container;
            string itemId;
            string error = "Error in the input.";
            if (text[0].ToLower() != "look")
                return error;

            switch (text.Length)
            {
                case 3:
                    if (text[1].ToLower() != "at")
                        return "What do you want to look at?";
                    container = p; // Use the Player object as the container
                    itemId = text[2];
                    break;

                case 5:
                    container = FetchContainer(p, text[4]);
                    if (container == null)
                        return $"Couldn't find the {text[4]}.";
                    itemId = text[2];
                    break;

                default:
                    return $"I don't know how to look like that.";
            }

            string itemDescription = LookAtIn(itemId, container);
            if (itemDescription == null)
                return $"Couldn't find the {itemId} in the {container.Name}.";

            return itemDescription;
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject item = container.Locate(thingId);
            if (item != null)
            {
                return $"{item.FullDescription}";
            }

            return $"Couldn't find {thingId}.";
        }

    }
}
