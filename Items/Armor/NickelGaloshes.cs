using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using AppraisalMod.Items.Placeable;

namespace ApraisalMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class NickelGaloshes : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}


		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(silver: 12);
			Item.rare = ItemRarityID.Green;
			Item.defense = 3;
		}


		public override void UpdateEquip(Player player)
		{
		}


		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<NickelOre>(20)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}