using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace AppraisalMod.Items.Placeable
{
	public class NickelOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.NickelOre>();
			Item.width = 12;
			Item.height = 12;
			Item.value = 2500;
		}
	}
}