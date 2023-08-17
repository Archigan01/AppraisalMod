using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using AppraisalMod.Items.Placeable;

namespace AppraisalMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class NickelPlate : ModItem
	{


		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(silver: 15);
			Item.rare = ItemRarityID.Green;
			Item.defense = 4;
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