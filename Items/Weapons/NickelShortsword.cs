using AppraisalMod.Items.Placeable;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace AppraisalMod.Items.Weapons
{
	public class NickelShortsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 9;
			Item.knockBack = 4.5f;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.useAnimation = 10;
			Item.useTime = 10;
			Item.width = 32;
			Item.height = 32;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.autoReuse = false;
			Item.noUseGraphic = false;
			Item.noMelee = false;

			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 0, 1, 50);
		}

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