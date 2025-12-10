using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace AppraisalMod.Items.Placeable
{
    public class NickelBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 25;
            ItemID.Sets.SortingPriorityMaterials[Type] = 40;

            ItemTrader.ChlorophyteExtractinator.AddOption_OneWay(Type, 5, ItemID.ChlorophyteBar, 2);
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.NickelBar>());
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 15, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<NickelOre>(3)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}