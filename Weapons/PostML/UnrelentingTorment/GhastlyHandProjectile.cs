using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;
using Terraria.ID;

namespace UnofficialCalamityWhips.Weapons.PostML.UnrelentingTorment
{
	public class GhastlyHandProjectile : ModProjectile
	{
		NPC k;
		float projSpeed = 15f;
		public override void SetDefaults() {
			Projectile.width = 24; // The width of projectile hitbox
			Projectile.height = 18; // The height of projectile hitbox
			Main.projFrames[Projectile.type] = 4;
			Projectile.aiStyle = 0; // The ai style of the projectile (0 means custom AI). For more please reference the source code of Terraria
			Projectile.DamageType = DamageClass.Summon; // What type of damage does this projectile affect?
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			//Projectile.light = 1f; // How much light emit around the projectile
			Projectile.tileCollide = false; // Can the projectile collide with tiles?
			Projectile.scale = 1.5f;
			Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
						Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
		}

		public override bool PreAI() {
			k = Main.player[Projectile.owner].GetModPlayer<NewPlayerStats>().whipTarget;
			return true;
		}
		// Custom AI
		public override void AI() {

			if (++Projectile.frameCounter >= 5) {
				Projectile.frameCounter = 0;

				// Or more compactly Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
				if (++Projectile.frame >= Main.projFrames[Projectile.type]) {
					Projectile.frame = 0;
				}
			}
			projSpeed += .08f; // The speed at which the projectile moves towards the target

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

			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.SpectreStaff ,0, 0, 25, Color.Magenta, .7f);
			Main.dust[dust].velocity /= 2f;
		}

		public override void Kill(int timeLeft) {
			// This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 15, Projectile.velocity.X * 0.25f * Main.rand.Next(-3, 0), Projectile.velocity.Y * 0.25f * Main.rand.Next(-3, 0), 25, default(Color), .7f);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 15, Projectile.velocity.X * 0.25f * Main.rand.Next(0, 3), Projectile.velocity.Y * 0.25f * Main.rand.Next(0, 3), 25, default(Color), .7f);
			//Main.player[Projectile.owner].GetModPlayer<NewPlayerStats>().handCooldown = false;
		}

	}
}
