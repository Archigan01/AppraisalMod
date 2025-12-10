using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using AppraisalMod.Items.Placeable;
using AppraisalMod.Items.Armor;

namespace AppraisalMod.Items.Armor.Nickel
{
	[AutoloadEquip(EquipType.Head)]
	public class NickelHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
		}


		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 3, 50);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 2;
		}


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<NickelChainmail>() && legs.type == ModContent.ItemType<NickelGreaves>();
		}

		
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases defense by 4";
			player.statDefense += 4;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<NickelBar>(12)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}