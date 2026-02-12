using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.ModLoader;
using AppraisalMod.NPCs;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AppraisalMod
{
	public class AppraisalMod : Mod
	{
        public override void Load()
        {
            On_Player.CollectTaxes += CollectTaxesWithoutMS;
        }

        public override void Unload()
        {
            On_Player.CollectTaxes -= CollectTaxesWithoutMS;
        }

        public void CollectTaxesWithoutMS(On_Player.orig_CollectTaxes orig, Player player)
        {
            int num; //= Item.buyPrice(0, 0, 0, 50);
            int num2 = Item.buyPrice(5, 0, 0, 0);

            if (Main.hardMode) num = Item.buyPrice(0, 0, 0, 75);
            else if (NPC.downedMoonlord) num = Item.buyPrice(0, 0, 1, 0);
            else num = Item.buyPrice(0, 0, 0, 50);

            if (Main.tenthAnniversaryWorld)
            {
                num2 *= 2;
                num *= 2;
            }
            if (!NPC.taxCollector)
            {
                return;
            }
            if (player.taxMoney >= num2)
            {
                return;
            }
            int num3 = 0;
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active && !Main.npc[i].homeless && !NPCID.Sets.IsTownPet[Main.npc[i].type] && NPC.TypeToDefaultHeadIndex(Main.npc[i].type) > 0 && Main.npc[i].type != ModContent.NPCType<MysticScholar>())
                {
                    num3++;
                }
            }
            player.taxMoney += num * num3;
            if (player.taxMoney > num2)
            {
                player.taxMoney = num2;
            }
        }
	}
}
