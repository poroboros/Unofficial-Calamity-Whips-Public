using Microsoft.Xna.Framework;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using System;
using Terraria.ID;

namespace UnofficialCalamityWhips.Accessories.DesertAccessory
{
	public class BoulderProj2 : ModProjectile
	{

		public override void SetStaticDefaults() {
			// Total count animation frames
			//Main.projFrames[Projectile.type] = 5;
		}
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Bullet);
			Projectile.DamageType = DamageClass.Summon;
			Projectile.scale = .8f;
			Projectile.timeLeft = 240;
			Projectile.penetrate = 5;
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
			Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.Mud, 0.0f, 0.0f, 0, new Color(), 1f);
		}

	}
}
