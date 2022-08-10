using AppraisalMod.Items;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace AppraisalMod
{
    public class AppraisalPlayer : ModPlayer
    {
        public bool ZoneExample;

		public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
		{
			return new[] {
				new Item(ModContent.ItemType<StarterBag>())
			};
		}
	}
}