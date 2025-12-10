using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AppraisalMod.Pets.Nelly
{
    public class NellyBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            bool unused = false;
            player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref unused, ModContent.ProjectileType<NellyProjectile>());
        }
    }
}