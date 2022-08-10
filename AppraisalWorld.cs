//using AppraisalMod.Content.Items;
using AppraisalMod.NPCs;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace AppraisalMod
{
    public class AppraisalWorld : ModSystem
    {
        public override void PostWorldGen()
        {
            int num = NPC.NewNPC(null, (Main.spawnTileX + 5) * 16, Main.spawnTileY * 16, ModContent.NPCType<MysticScholar>());
            Main.npc[num].homeTileX = Main.spawnTileX + 5;
            Main.npc[num].homeTileY = Main.spawnTileY;
            Main.npc[num].direction = 1;
            Main.npc[num].homeless = true;
        }
    }
}