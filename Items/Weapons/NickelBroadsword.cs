using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using AppraisalMod.Items.Placeable;

namespace AppraisalMod.Items.Weapons
{
	public class NickelBroadsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Melee;
			Item.damage = 14;
			Item.knockBack = 6;
			Item.crit = 5;
			Item.value = Item.buyPrice(silver: 6);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{

		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
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