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
            if (Main.hardMode == false && NPC.downedMoonlord == false)
            {
                Item.shoot = ModContent.ProjectileType<BrusterProjectile>();
            }
            else if (Main.hardMode == true && NPC.downedMoonlord == false)
            {
                Item.shoot = ModContent.ProjectileType<BrusterProjectileHM>();
            }
            else if (Main.hardMode == true && NPC.downedMoonlord == true)
            {
                Item.shoot = ModContent.ProjectileType<BrusterProjectileML>();
            }
                
            Item.buffType = ModContent.BuffType<BrusterBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Shadow>(5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}