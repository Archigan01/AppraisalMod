using AppraisalMod.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AppraisalMod.Pets.Nelly
{
    public class NellyItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.shoot = ModContent.ProjectileType<NellyProjectile>();
            Item.buffType = ModContent.BuffType<NellyBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600);
            }
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Reality>()
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}