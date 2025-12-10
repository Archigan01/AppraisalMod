using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AppraisalMod.Pets.Bruster
{
    public class BrusterProjectile : ModProjectile
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
            Projectile.width = 20;
            Projectile.hostile = false;
            DrawOriginOffsetY = -16;
            DrawOffsetX = -8;

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

            if (!player.dead && player.HasBuff(ModContent.BuffType<BrusterBuff>()))
            {
                Projectile.timeLeft = 2;
            }
        }
    }
}