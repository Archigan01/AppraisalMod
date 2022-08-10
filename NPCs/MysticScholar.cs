using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using System.Collections.Generic;
using ReLogic.Content;
using Terraria.ModLoader.IO;
using AppraisalMod.Items;

namespace AppraisalMod.NPCs
{
	[AutoloadHead]
	public class MysticScholar : ModNPC
	{
		public int NumberOfTimesTalkedTo = 0;

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 26;

			NPCID.Sets.ExtraFramesCount[Type] = 9;
			NPCID.Sets.AttackFrameCount[Type] = 4;
			NPCID.Sets.DangerDetectRange[Type] = 700;
			NPCID.Sets.AttackType[Type] = 3;
			NPCID.Sets.AttackTime[Type] = 90;
			NPCID.Sets.AttackAverageChance[Type] = 30;
			NPCID.Sets.HatOffsetY[Type] = 4;

			
			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Velocity = 1f,
				Direction = -1
			};

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
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 500;
			NPC.lifeMax = 10000;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 10f;

			AnimationType = NPCID.Guide;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("It is unclear how or when the Mystic Scholar got here, but they have interesting stories to tell."),
			});
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

		public override void HitEffect(int hitDirection, double damage)
		{
			int num = NPC.life > 0 ? 1 : 5;

			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Smoke);
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			return true;
		}


		public override ITownNPCProfile TownNPCProfile()
		{
			return new ExamplePersonProfile();
		}

		public override List<string> SetNPCNameList()
		{
			return new List<string>() {
				"Henroop Pastabake",
				"Elton Jim",
				"J.F.Kidney",
				"Dilly Dally Pardon",
				"<generic name>",
				"Nicola Ohm",
				"Phil Battery"
			};
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
			WeightedRandom<string> chat = new WeightedRandom<string>();

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

			return chat; // chat is implicitly cast to a string.
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{ // What the chat buttons are when you open up the chat UI
			button = "Shop";
			button2 = "Talk to the Scholar";
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
			else
            {
				Main.npcChatText = GetChat();
            }
		}

        // Not completely finished, but below is what the NPC will sell

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Reality>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Shadow>());
        }

        /*public override void ModifyNPCLoot(NPCLoot npcLoot)
		{

		}*/

		public override bool CanGoToStatue(bool toKingStatue) => false;

		/*public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		// todo: implement
		// public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
		// 	projType = ProjectileType<SparklingBall>();
		// 	attackDelay = 1;
		// }

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
        }*/
    }

	public class ExamplePersonProfile : ITownNPCProfile
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