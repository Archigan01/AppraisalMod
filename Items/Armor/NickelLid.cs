using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using AppraisalMod.Items.Placeable;
using AppraisalMod.Items.Armor;

namespace AppraisalMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class NickelLid : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(silver: 9);
			Item.rare = ItemRarityID.Green;
			Item.defense = 3;
		}


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<NickelPlate>() && legs.type == ModContent.ItemType<NickelGaloshes>();
		}

		
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases defense by 4";
			player.statDefense += 4;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<NickelOre>(15)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}