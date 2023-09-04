using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AppraisalMod.Pets.Nelly
{
    public class NellyProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 26;
            Main.projPet[Projectile.type] = true;

           
            ProjectileID.Sets.CharacterPreviewAnimations[Projectile.type] = ProjectileID.Sets.SimpleLoop(0, Main.projFrames[Projectile.type], 6)
                .WithOffset(-10, -20f)
                .WithSpriteDirection(-1);
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.BabyRedPanda);

            AIType = ProjectileID.BabyRedPanda;
        }

        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];

            player.zephyrfish = false;

            return true;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            // Keep the projectile from disappearing as long as the player isn't dead and has the pet buff.
            if (!player.dead && player.HasBuff(ModContent.BuffType<NellyBuff>()))
            {
                Projectile.timeLeft = 2;
            }
        }
    }
}