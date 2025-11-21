using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using System.Collections.Generic;
using ReLogic.Content;
using AppraisalMod.Items;

namespace AppraisalMod.NPCs
{
	[AutoloadHead]
	public class MysticScholar : ModNPC
	{
		public int NumberOfTimesTalkedTo = 0;
		public const string ShopName = "Wares";

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 26;

            NPCID.Sets.ExtraFramesCount[Type] = 0;
            NPCID.Sets.AttackFrameCount[Type] = 0;
			NPCID.Sets.DangerDetectRange[Type] = 700;
			NPCID.Sets.AttackType[Type] = 2;
			NPCID.Sets.AttackTime[Type] = 30;
			NPCID.Sets.AttackAverageChance[Type] = 30;
			NPCID.Sets.MagicAuraColor[Type] = Color.Purple;


			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new();

			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);


			NPC.Happiness
				.SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
				.SetBiomeAffection<JungleBiome>(AffectionLevel.Love)
				.SetBiomeAffection<HallowBiome>(AffectionLevel.Hate)
				.SetNPCAffection(NPCID.WitchDoctor, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Guide, AffectionLevel.Like)
				.SetNPCAffection(NPCID.Nurse, AffectionLevel.Dislike)
				.SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Hate)
			;
		}

		public override void SetDefaults()
		{
			NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = NPCAIStyleID.Passive;
			NPC.damage = 10;
			NPC.defense = 500;
			NPC.lifeMax = 10000;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0f;

			AnimationType = NPCID.Guide;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange([
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("It is unclear how or when the Mystic Scholar got here, but they have interesting stories to tell."),
			]);
		}


		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			if (NPCID.Sets.NPCBestiaryDrawOffset.TryGetValue(Type, out NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers))
			{
				NPCID.Sets.NPCBestiaryDrawOffset.Remove(Type);
				NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
			}

			return true;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			int num = NPC.life > 0 ? 5 : 100;

			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Smoke);
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs)
		{
			return true;
		}


		public override ITownNPCProfile TownNPCProfile()
		{
			return new MysticScholarProfile();
		}

		public override List<string> SetNPCNameList()
		{
			return [
				"Henroop Pastabake",
				"Elton Jim",
				"J. F. Kidney",
				"Dilly Dally Pardon",
				"<generic name>",
				"Nicola Ohm",
				"Phil Battery",
				"Old Fart",
				"Humbert Stinkledink",
				"James 'The Anaconda' Frodo"
			];
		}

		public override void FindFrame(int frameHeight)
		{
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat()
		{
			WeightedRandom<string> chat = new();

			if (NumberOfTimesTalkedTo == 0)
			{
				chat.Add(Language.GetTextValue("Mods.AppraisalMod.Dialogue.MysticScholar.FirstTimeDialogue"), 100000);
			}

			NumberOfTimesTalkedTo++;

			chat.Add(Language.GetTextValue("Mods.AppraisalMod.Dialogue.MysticScholar.StandardDialogue1"));
			chat.Add(Language.GetTextValue("Mods.AppraisalMod.Dialogue.MysticScholar.StandardDialogue2"));
			chat.Add(Language.GetTextValue("Mods.AppraisalMod.Dialogue.MysticScholar.StandardDialogue3"));
			chat.Add(Language.GetTextValue("Mods.AppraisalMod.Dialogue.MysticScholar.StandardDialogue4"));
			chat.Add(Language.GetTextValue("Mods.AppraisalMod.Dialogue.MysticScholar.StandardDialogue5"));
			chat.Add(Language.GetTextValue("Mods.AppraisalMod.Dialogue.MysticScholar.StandardDialogue6"));
			chat.Add(Language.GetTextValue("Mods.AppraisalMod.Dialogue.MysticScholar.StandardDialogue7"));
			chat.Add(Language.GetTextValue("Mods.AppraisalMod.Dialogue.MysticScholar.StandardDialogue8"));

			// Dialogues for when different NPCs are alive
			if (NPC.FindFirstNPC(NPCID.Guide) is not -1)
			{
                chat.Add(Language.GetTextValue("Mods.AppraisalMod.Dialogue.MysticScholar.TownNPCSpecific.Guide"));
            }
			if (NPC.FindFirstNPC(NPCID.WitchDoctor) is not -1)
			{
				chat.Add(Language.GetTextValue("Mods.AppraisalMod.Dialogue.MysticScholar.TownNPCSpecific.WitchDoctor"));
			}
            if (NPC.FindFirstNPC(NPCID.Stylist) is not -1)
            {
                chat.Add(Language.GetTextValue("Mods.AppraisalMod.Dialogue.MysticScholar.TownNPCSpecific.Stylist"));
            }
            if (NPC.FindFirstNPC(NPCID.TaxCollector) is not -1)
            {
                chat.Add(Language.GetTextValue("Mods.AppraisalMod.Dialogue.MysticScholar.TownNPCSpecific.TaxCollector"));
            }
            if (NPC.FindFirstNPC(NPCID.PartyGirl) is not -1)
            {
                chat.Add(Language.GetTextValue("Mods.AppraisalMod.Dialogue.MysticScholar.TownNPCSpecific.PartyGirl"));
            }
            if (NPC.FindFirstNPC(NPCID.Princess) is not -1)
            {
                chat.Add(Language.GetTextValue("Mods.AppraisalMod.Dialogue.MysticScholar.TownNPCSpecific.Princess"));
            }

            return chat;
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{ 
			button = Language.GetTextValue("Mods.AppraisalMod.NPCs.MysticScholar.Button1");
			button2 = Language.GetTextValue("Mods.AppraisalMod.NPCs.MysticScholar.Button2");
		}

		public override void OnChatButtonClicked(bool firstButton, ref string shop)
		{
			if (firstButton)
			{
				shop = ShopName;
			}
			else
            {
				Main.npcChatText = GetChat();
            }
		}

        // Not completely finished, but below is what the NPC will sell

        public override void AddShops()
        {
            var shop = new NPCShop(Type, ShopName)
                .Add<Reality>()
                .Add<Shadow>();

			shop.Register();
        }

        /*public override void ModifyNPCLoot(NPCLoot npcLoot)
		{

		}*/

		public override bool CanGoToStatue(bool toKingStatue) => false;

		public override bool UsesPartyHat() => false;

		public override bool ModifyDeathMessage(ref NetworkText customText, ref Color color)
		{
			customText = NetworkText.FromKey("Mods.AppraisalMod.NPCs.MysticScholar.DeathMessage");
			color = Color.Purple;
			return true;
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ProjectileID.NebulaArcanum;
			attackDelay = 1;
		}

        public override void TownNPCAttackMagic(ref float auraLightMultiplier)
        {
			auraLightMultiplier = 4f;
        }
    }

	public class MysticScholarProfile : ITownNPCProfile
	{
		public int RollVariation() => 0;
		public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

		public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
		{
			if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
				return ModContent.Request<Texture2D>("AppraisalMod/NPCs/MysticScholar");

			if (npc.altTexture == 1)
				return ModContent.Request<Texture2D>("AppraisalMod/NPCs/MysticScholar");

			return ModContent.Request<Texture2D>("AppraisalMod/NPCs/MysticScholar");
		}

		public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("AppraisalMod/NPCs/MysticScholar_Head");
	}
}