using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using AppraisalMod.Items.Placeable;

namespace AppraisalMod.Items.Armor.Nickel
{
	[AutoloadEquip(EquipType.Legs)]
	public class NickelGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}


		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 4, 50);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 2;
		}


		public override void UpdateEquip(Player player)
		{
		}


		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<NickelBar>(16)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}