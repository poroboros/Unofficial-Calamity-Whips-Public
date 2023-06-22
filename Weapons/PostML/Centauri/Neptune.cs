using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnofficialCalamityWhips.Weapons.PostML.Centauri {
    internal class Neptune : ModProjectile{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Typhoon");
		}

		public override void SetDefaults()
		{
			// This method right here is the backbone of what we're doing here; by using this method, we copy all of
			// the Meowmere Projectile's SetDefault stats (such as projectile.friendly and projectile.penetrate) on to our projectile,
			// so we don't have to go into the source and copy the stats ourselves. It saves a lot of time and looks much cleaner;
			// if you're going to copy the stats of a projectile, use CloneDefaults().

			Projectile.CloneDefaults(ProjectileID.Typhoon);

			// To further the Cloning process, we can also copy the ai of any given projectile using AIType, since we want
			// the projectile to essentially behave the same way as the vanilla projectile.
			AIType = ProjectileID.Typhoon;
			Projectile.DamageType = DamageClass.Summon;

			// After CloneDefaults has been called, we can now modify the stats to our wishes, or keep them as they are.
			// For the sake of example, lets make our projectile penetrate enemies a few more times than the vanilla projectile.
			// This can be done by modifying projectile.penetrate
			Projectile.penetrate += 3;
		}

		// While there are several different ways to change how our projectile could behave differently, lets make it so
		// when our projectile finally dies, it will explode into 4 regular Meowmere projectiles.
		/*public override void Kill(int timeLeft)
		{
			Vector2 launchVelocity = new Vector2(-4, 0); // Create a velocity moving the left.
			for (int i = 0; i < 4; i++) {
				// Every iteration, rotate the newly spawned projectile by the equivalent 1/4th of a circle (MathHelper.PiOver4)
				// (Remember that all rotation in Terraria is based on Radians, NOT Degrees!)
				launchVelocity = launchVelocity.RotatedBy(MathHelper.PiOver4);

				// Spawn a new projectile with the newly rotated velocity, belonging to the original projectile owner. The new projectile will inherit the spawning source of this projectile.
				Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ProjectileID.Meowmere, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
			}
		}*/

		// Now, using CloneDefaults() and aiType doesn't copy EVERY aspect of the projectile. In Vanilla, several other methods
		// are used to generate different effects that aren't included in AI. For the case of the Meowmete projectile, since the
		// richochet sound is not included in the AI, we must add it ourselves:		
	}
}
