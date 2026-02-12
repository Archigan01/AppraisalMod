using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using AppraisalMod.Items.Placeable;
using AppraisalMod.Projectiles;

namespace AppraisalMod.Items.Weapons
{
    public class AzureDagger : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.knockBack = 4.5f;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.width = 37;
            Item.height = 37;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.scale = 0.86f;

            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 25, 0);

            Item.shoot = ModContent.ProjectileType<AzureDaggerProjectile>();
            Item.shootSpeed = 2.1f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddRecipeGroup(RecipeGroupID.IronBar, 2)
                .AddIngredient(ItemID.Sapphire, 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
