using Microsoft.Xna.Framework;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using System;
using Terraria.ID;

namespace UnofficialCalamityWhips.Accessories.DesertAccessory
{
	public class BoulderProj : ModProjectile
	{

		public override void SetStaticDefaults() {
			// Total count animation frames
			//Main.projFrames[Projectile.type] = 5;
		}
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.BoulderStaffOfEarth);
			Projectile.DamageType = DamageClass.Summon;
			Projectile.timeLeft = 120;
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
			Vector2 launchVelocity = new Vector2(-10, 0); 
			for (int i = 0; i < 8; i++) {
			
				launchVelocity = launchVelocity.RotatedBy(MathHelper.PiOver4);

				int randProj = Main.rand.Next(0, 2);
				int proj = 0;

				if (Main.rand.NextBool(3)) {

				}
				else {
					switch(randProj){
						case 0:
							proj = Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<BoulderProj1>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
						break;
						case 1:
							proj = Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<BoulderProj2>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
						break;
						/*default:
							proj = Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<BoulderProj3>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
						break;*/

					}
				}
				Main.projectile[proj].DamageType = DamageClass.Summon;
			}
		
		}

	}
}
