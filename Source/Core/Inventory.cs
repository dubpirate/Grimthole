using System.Collections.Generic;
using Grimthole.MacOS.Source.Items;

namespace Grimthole1.MacOS.Source.Core
{
    public class Inventory
    {
		public int Gold { get; set; }

		public List<Weapon> weapons;

        public Inventory()
        {
        }
    }
}
