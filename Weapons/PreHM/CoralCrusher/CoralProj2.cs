using Microsoft.Xna.Framework;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using System;
using Terraria.ID;

namespace UnofficialCalamityWhips.Weapons.PreHM.CoralCrusher
{
	public class CoralProj2 : ModProjectile
	{
		bool firstTime = true;
		float distance = 50f;
		int frames = 4;

		int timer = 0;

		public override void SetStaticDefaults() {
			// Total count animation frames
			//Main.projFrames[Projectile.type] = 5;
		}
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.BoneGloveProj);
			Projectile.timeLeft = 360;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.penetrate = 7;
						Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
		}

		Vector2 target;

		public override bool PreAI() {
			// NPC k = Main.player[Projectile.owner].GetModPlayer<NewPlayerStats>().whipTarget;
			// if (k != null  && k.active) {
			// 	target = k.Center +  Vector2.Normalize(Projectile.velocity)*5;
			// }

			return true;

		}
		// Custom AI

		public override bool PreDraw(ref Color lightColor) {
			return true;
		}

		public override void AI() {

		}

		public override void Kill(int timeLeft) {
			for (int i = 0; i < Main.rand.Next(1, 5); i++) {
				Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.Coralstone, 0.0f, 0.0f, 0, new Color(), 1f);
			}	
		}

	}
}
