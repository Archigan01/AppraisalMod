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
			Item.damage = 12;
			Item.knockBack = 6;
			Item.crit = 1;
			Item.value = Item.sellPrice(0, 0, 2, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
		}

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