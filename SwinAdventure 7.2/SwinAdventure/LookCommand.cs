using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() :
            base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            string _itemID;
            if (text[0] != "look")
            { return "Error in look input"; }

            if (text[1] != "at")
            { return "What do you want to look at?"; }

            if (text.Length == 5 && text[3] != "in")
            {
                return "What do you want to look in?";
            }

            string output;
            if (text.Length == 1)
            {
                _itemID = "location"; 
            }
            if (text[2] == "location")
            {
                return p.Location.FullDescription;
            }
            if (text.Length == 3)
            {
                output = LookAtIn(text[2], p as IHaveInventory);
                if (output == null)
                {
                    return "I cannot find the " + text[2];
                }
                else
                {
                    return output;
                }
            }

            else if (text.Length == 5)
            {
                IHaveInventory container = FetchContainer(p, text[4]);
                if (container != null)
                {
                    output = LookAtIn(text[2], container);
                    if (output == null)
                    {
                        return "I cannot find the " + text[2] + " in the" + text[4];
                    }
                    else
                    {
                        return output;
                    }
                }
                else
                {
                    return "I cannot find the " + text[4];
                }
            }

            else
            {
                return "I don't know how to look like that";
            }
        }

        private IHaveInventory FetchContainer(Player p, string containerID)
        {
            return p.Locate(containerID) as IHaveInventory;
        }

        private string LookAtIn(string thingID, IHaveInventory container)
        {
            if (container.Locate(thingID) != null)
            { return container.Locate(thingID).FullDescription; }
            else
            {
                return "I can't find the " + thingID;
            }
        }
    }
}