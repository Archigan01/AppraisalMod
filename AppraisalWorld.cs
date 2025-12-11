using AppraisalMod.Common;
using AppraisalMod.NPCs;
using AppraisalMod.Pets.Bruster;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Terraria;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;


namespace AppraisalMod
{
    public class AppraisalWorld : ModSystem
    {
        // Mystic Scholar Chat Trackers
        public int MSCT = 0;

        private bool EoCFlag = false;
        private bool Boss2Flag = false;
        private bool SkeleFlag = false;
        private bool WoFFlag = false;
        private bool MLFlag = false;
        public override void PostWorldGen()
        {
            int num = NPC.NewNPC(null, (Main.spawnTileX + 5) * 16, Main.spawnTileY * 16, ModContent.NPCType<MysticScholar>());
            Main.npc[num].homeTileX = Main.spawnTileX + 5;
            Main.npc[num].homeTileY = Main.spawnTileY;
            Main.npc[num].direction = 1;
            Main.npc[num].homeless = true;
        }

        public override void PostUpdateWorld()
        {
            if (NPC.downedBoss1 && !EoCFlag)
            {
                EoCFlag = true;
                MSCT++;
                ChatHelper.BroadcastChatMessageAs(byte.MaxValue, NetworkText.FromKey("Mods.AppraisalMod.Chats.DownedBossChat"), Color.Purple);
            }

            if (NPC.downedBoss2 && !Boss2Flag)
            {
                Boss2Flag = true;
                MSCT++;
                ChatHelper.BroadcastChatMessageAs(byte.MaxValue, NetworkText.FromKey("Mods.AppraisalMod.Chats.DownedBossChat"), Color.Purple);
            }

            if (NPC.downedBoss3 && !SkeleFlag)
            {
                SkeleFlag = true;
                MSCT++;
                ChatHelper.BroadcastChatMessageAs(byte.MaxValue, NetworkText.FromKey("Mods.AppraisalMod.Chats.DownedBossChat"), Color.Purple);
            }

            if (Main.hardMode && !WoFFlag)
            {
                WoFFlag = true;
                MSCT++;
                ChatHelper.BroadcastChatMessageAs(byte.MaxValue, NetworkText.FromKey("Mods.AppraisalMod.Chats.DownedBossChat"), Color.Purple);
                RefreshAllPetsHM();
            }

            if (NPC.downedMoonlord && !MLFlag)
            {
                MLFlag = true;
                MSCT++;
                ChatHelper.BroadcastChatMessageAs(byte.MaxValue, NetworkText.FromKey("Mods.AppraisalMod.Chats.DownedBossChat"), Color.Purple);
                RefreshAllPetsML();
            }
        }

        // Saving the above public values
        public override void OnWorldLoad()
        {
            MSCT = 0;
        }

        public override void OnWorldUnload()
        {
            MSCT = 0;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag["MSCT"] = MSCT;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            MSCT = tag.GetInt("MSCT");
        }

        // Refresh pets at each major stage
        private static void RefreshAllPetsHM()
        {
            foreach (Player player in Main.player)
            {
                if (player is null || !player.active)
                    continue;

                if (player.HasBuff(ModContent.BuffType<BrusterBuff>()))
                {
                    foreach (Projectile proj in Main.projectile)
                    {
                        if (proj.active && proj.owner == player.whoAmI && proj.type == ModContent.ProjectileType<BrusterProjectile>())
                        {
                            proj.Kill();
                        }
                    }

                    Projectile.NewProjectile(
                        player.GetSource_Buff(0),
                        player.Center,
                        Vector2.Zero,
                        ModContent.ProjectileType<BrusterProjectileHM>(),
                        0, 0f, player.whoAmI
                    );
                }
            }
        }

        private static void RefreshAllPetsML()
        {
            foreach (Player player in Main.player)
            {
                if (player is null || !player.active)
                    continue;

                if (player.HasBuff(ModContent.BuffType<BrusterBuff>()))
                {
                    foreach (Projectile proj in Main.projectile)
                    {
                        if (proj.active && proj.owner == player.whoAmI && proj.type == ModContent.ProjectileType<BrusterProjectileHM>())
                        {
                            proj.Kill();
                        }
                    }

                    Projectile.NewProjectile(
                        player.GetSource_Buff(0),
                        player.Center,
                        Vector2.Zero,
                        ModContent.ProjectileType<BrusterProjectileML>(),
                        0, 0f, player.whoAmI
                    );
                }
            }
        }
    }
}