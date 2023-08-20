using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnofficialCalamityWhips.Weapons.HM.DaedalusWhip {
    internal class IceShard : ModProjectile{
		public override void SetStaticDefaults()
		{

		}

		public override void SetDefaults()
		{			
			Projectile.CloneDefaults(ProjectileID.Blizzard);

			//Projectile.scale = .7f;
			AIType = ProjectileID.Blizzard;
			Projectile.DamageType = DamageClass.Summon;

		
			Projectile.timeLeft = 240;
			Projectile.penetrate = -1;
						Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            //Projectile.spriteDirection = -1;
			

        }

		public override void AI()
		{
            Projectile.rotation = Projectile.velocity.ToRotation()-MathHelper.PiOver2;
		}


		/*public override void Kill(int timeLeft)
		{
			Vector2 launchVelocity = new Vector2(-4, 0); 
			for (int i = 0; i < 8; i++) {
			
				launchVelocity = launchVelocity.RotatedBy(MathHelper.PiOver4);

				
				int proj = Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ProjectileID.Blizzard, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
				Main.projectile[proj].DamageType = DamageClass.Summon;
			}
		}*/
	
	}
}
