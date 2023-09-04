using AppraisalMod.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AppraisalMod.Pets.Bruster
{
    public class BrusterItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.shoot = ModContent.ProjectileType<BrusterProjectile>();
            Item.buffType = ModContent.BuffType<BrusterBuff>();
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
                .AddIngredient<Shadow>()
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}