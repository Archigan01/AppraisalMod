using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using AppraisalMod.Items.Placeable;

namespace AppraisalMod.Items.Tools
{
	public class NickelAxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 15;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.5f;
			Item.value = 540;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

			Item.axe = 11;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{

		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("Wood", 3)
				.AddIngredient<NickelOre>(8)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}