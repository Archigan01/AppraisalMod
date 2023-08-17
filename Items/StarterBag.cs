using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace AppraisalMod.Items
{
    public class StarterBag : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
        }

        public override bool CanRightClick() => true;

        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(null, ItemID.TinBar, 15);
            player.QuickSpawnItem(null, ItemID.MiningPotion, 3);
            player.QuickSpawnItem(null, ItemID.LesserHealingPotion, 10);
            player.QuickSpawnItem(null, ItemID.SpelunkerPotion, 3);
            player.QuickSpawnItem(null, ItemID.Glowstick, 15);
            player.QuickSpawnItem(null, ItemID.Torch, 20);

            int rnd = Main.rand.Next(1, 8);
            switch (rnd)
            {
                case 1:
                    player.QuickSpawnItem(null, ItemID.Amethyst, 10);
                    break;
                case 2:
                    player.QuickSpawnItem(null, ItemID.Topaz, 10);
                    break;
                case 3:
                    player.QuickSpawnItem(null, ItemID.Emerald, 10);
                    break;
                case 4:
                    player.QuickSpawnItem(null, ItemID.Sapphire, 10);
                    break;
                case 5:
                    player.QuickSpawnItem(null, ItemID.Ruby, 10);
                    break;
                case 6:
                    player.QuickSpawnItem(null, ItemID.Diamond, 10);
                    break;
                case 7:
                    player.QuickSpawnItem(null, ItemID.Amber, 10);
                    break;
            }
        }
    }
}