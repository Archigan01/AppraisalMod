using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using AppraisalMod.Items.Placeable;

namespace AppraisalMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class NickelChainmail : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}


		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 6, 0);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 3;
		}


		public override void UpdateEquip(Player player)
		{

		}

		
		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient<NickelOre>(25)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}