using AppraisalMod.Items.Placeable;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace AppraisalMod.Items.Weapons
{
	public class NickelShortsword : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.knockBack = 5f;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.useAnimation = 12;
			Item.useTime = 9;
			Item.width = 32;
			Item.height = 32;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.autoReuse = false;
			Item.noUseGraphic = false;
			Item.noMelee = false;

			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(0, 0, 5, 0);
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("Wood", 3)
				.AddIngredient<NickelOre>(6)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}