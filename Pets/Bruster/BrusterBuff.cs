using Terraria;
using Terraria.ModLoader;

namespace AppraisalMod.Pets.Bruster
{
    public class BrusterBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            bool unused = false;

            if (Main.hardMode == false && NPC.downedMoonlord == false)
            {
                player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref unused, ModContent.ProjectileType<BrusterProjectile>());
            }
            else if (Main.hardMode == true && NPC.downedMoonlord == false)
            {
                player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref unused, ModContent.ProjectileType<BrusterProjectileHM>());
            }
            else if (Main.hardMode == true && NPC.downedMoonlord == true)
            {
                player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref unused, ModContent.ProjectileType<BrusterProjectileML>());
            }
        }
    }
}