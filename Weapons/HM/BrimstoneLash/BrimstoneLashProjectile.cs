using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;

namespace UnofficialCalamityWhips.Weapons.HM.BrimstoneLash
{
	public class BrimstoneLashProjectile : WhipBase
	{
		public override void SetStaticDefaults() {
			// This makes the projectile use whip collision detection and allows flasks to be applied to it.
			ProjectileID.Sets.IsAWhip[Type] = true;
		}

		public override void SetWhipStats()
		{
            Projectile.localNPCHitCooldown = -1;
            Projectile.WhipSettings.Segments = 20;
            Projectile.WhipSettings.RangeMultiplier = .8f;
			fishingLineColor = Color.Maroon;
			segmentRotation = -MathF.PI / 2;
			tagDebuff = ModContent.BuffType<BrimstoneTagDebuff>();
        }

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            if (UnofficialCalamityWhips.calamity != null)
            {
                target.AddBuff(UnofficialCalamityWhips.calamity.Find<ModBuff>("BrimstoneFlames").Type, 240);
            }
            WhipOnHit(target);
		}

	}
}
