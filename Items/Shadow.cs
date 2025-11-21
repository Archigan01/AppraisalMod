using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace AppraisalMod.Items
{
	public class Shadow : ModItem
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Soul of Shadows");
			//Tooltip.SetDefault("'A figment of the night sky.'");

			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;

			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 50;
		}

		public override void SetDefaults()
		{
			Item refItem = new Item();
			refItem.SetDefaults(ItemID.SoulofSight);
			Item.width = refItem.width;
			Item.height = refItem.height;
			Item.maxStack = 999;
			Item.value = 30000;
			Item.rare = ItemRarityID.Pink;
		}

		public override void PostUpdate()
		{
			Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);
		}
	}
}