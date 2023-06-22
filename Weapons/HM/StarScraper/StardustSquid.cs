using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnofficialCalamityWhips.Weapons.HM.StarScraper {
    internal class StardustSquid : ModProjectile{

		public NPC k;

		bool cling = false;

		public float projSpeed = 10f;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stardust Squid");
		}

		public override void SetDefaults()
		{			
			//Projectile.CloneDefaults(ProjectileID.StardustCellMinion);


			Main.projFrames[Projectile.type] = 4;
			Projectile.scale = 1.2f;
			Projectile.DamageType = DamageClass.Summon;
			AIType = ProjectileID.StardustCellMinion;


			Projectile.tileCollide = false;
		
			Projectile.timeLeft = 120;
			Projectile.penetrate = -1;
						Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;

			

		}

			public override bool PreAI() {
				k = Main.player[Projectile.owner].GetModPlayer<NewPlayerStats>().whipTarget;
				return true;
			}

			public override void AI() {

			// If found, change the velocity of the projectile and turn it in the direction of the target
			// Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero

						// Trying to find NPC closest to the projectile
			Vector2 target = new Vector2 (Projectile.Center.X, 100000f);
			if (k == null || !k.active) {
				k = Main.player[Projectile.owner].GetModPlayer<NewPlayerStats>().whipTarget;
			}
			if (k != null  && k.active) {
				target = k.Center;
			}

			// If found, change the velocity of the projectile and turn it in the direction of the target
			// Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero
			if (!cling) {
				Projectile.velocity =  (target - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
				Projectile.spriteDirection = Projectile.direction;
				Vector2 rotVel;
				if (Projectile.velocity.X < 0) {
					rotVel = new Vector2(Math.Abs(Projectile.velocity.X),Projectile.velocity.Y*-1);
				}
				else {
					rotVel = new Vector2(Math.Abs(Projectile.velocity.X),Projectile.velocity.Y);
				}
				Projectile.rotation = rotVel.ToRotation();
			}
			else {
				Projectile.Center = target;
				//Main.NewText("cling");
				//Projectile.rotation = 0;
			}

			if (Vector2.Distance(Projectile.Center, target) < 5) {
				cling = true;
			}

			if (Main.rand.NextBool(4)) {
				int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.MagicMirror ,0, 0, 25, Color.Cyan, .7f);
				Main.dust[dust].velocity /= 2f;
			}
	
			if (++Projectile.frameCounter >= 5) {
					Projectile.frameCounter = 0;
					// Or more compactly Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
					if (++Projectile.frame >= Main.projFrames[Projectile.type]) {
						Projectile.frame = 0;
					}
				}
			}


		public override void Kill(int timeLeft)
		{
			//Vector2 launchVelocity = new Vector2(-4, 0); 
			//Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ProjectileID.StardustCellMinion, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
		}
	
	}
}
