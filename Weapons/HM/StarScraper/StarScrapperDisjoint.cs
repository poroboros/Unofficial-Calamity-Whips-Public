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
    internal class StarScrapperDisjoint : ModProjectile{
		public override void SetStaticDefaults()
		{

		}

		public override void SetDefaults()
		{			
			Projectile.CloneDefaults(ProjectileID.DeathSickle);

			Projectile.scale = .7f;
			AIType = ProjectileID.DeathSickle;

			Projectile.tileCollide = false;
		
			Projectile.timeLeft = 60;
			Projectile.penetrate += 2;
						Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;

			

		}

		public override void AI()
		{
			if (Main.rand.NextBool(3)) {
				for (int i = 0; i < 1; i++) {
					//int dust = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.YellowStarDust, 0.0f, 0.0f, 0, new Color(), .7f);
					//Main.dust[dust].noGravity = true;
					int dust = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.MagicMirror, 0.0f, 0.0f, 0, new Color(), .7f);
					Main.dust[dust].noGravity = true;
				}

			}
		}

		public override void Kill(int timeLeft)
		{
			Vector2 launchVelocity = new Vector2(-4, 0); 
			Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<StardustSquid>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
		}
	
	}
}
