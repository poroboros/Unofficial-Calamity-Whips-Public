using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace UnofficialCalamityWhips.Accessories.GloveCraftingTree.BuffsDebuffs
{
	public class BitterCold : ModBuff
	{

		public override string Texture => UnofficialCalamityWhips.buffPath;
		public override void SetStaticDefaults() {
			//DisplayName.SetDefault("Pure Resonance");
			//Description.SetDefault("Increases melee and movement speed");
		}

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<BitterColdNPC>().hasBitter = true;
			//npc.stepSpeed *= .9f;
		}

	}

		public class BitterColdNPC : GlobalNPC
	{
		// This is required to store information on entities that isn't shared between them.
		public override bool InstancePerEntity => true;

		public bool hasBitter;
		public int index;
		bool firstTime = true;

		float speedDebuff = .9f;

		Color coldColor = Color.Teal;
		Color oldColor = Color.White;

		public override void ResetEffects(NPC npc) {
			if (hasBitter) {
				npc.color = oldColor;
			}
			hasBitter = false;
			firstTime = true;
		}
		

		public override void PostAI(NPC npc) {

		}
		public override void DrawEffects(NPC npc, ref Color drawColor) {

			if (!npc.boss && hasBitter) {
				if (firstTime) {
					//npc.velocity *= speedDebuff;
					oldColor = npc.color;
					firstTime = false;
				}
				if (hasBitter) {
					oldColor = npc.color;
					npc.color = coldColor;
				}
			}
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage) {
			if (hasBitter  && !npc.boss) {
				((Entity)npc).velocity = ((Entity)npc).velocity * speedDebuff;
			}	
		}

		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
			if (hasBitter && projectile.type == ProjectileID.FlinxMinion) {
				npc.AddBuff(BuffID.Frostburn, 240);
				knockback += 20;
			}
		}

		
	}
}

