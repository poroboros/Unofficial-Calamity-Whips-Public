using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;
using UnofficialCalamityWhips.Weapons.HM.PrismBreak;

namespace UnofficialCalamityWhips.Weapons.PreHM.WulfrumChain
{
	internal class WulfrumChainProjectile : WhipBase
	{
        public override void SetStaticDefaults()
        {
            // This makes the projectile use whip collision detection and allows flasks to be applied to it.
            ProjectileID.Sets.IsAWhip[Type] = true;
        }

        public override void SetWhipStats()
        {
            Projectile.localNPCHitCooldown = -1;
            Projectile.WhipSettings.Segments = 10;
            Projectile.WhipSettings.RangeMultiplier = 1f;
            fishingLineColor = Color.Gray;
            segmentRotation = -MathF.PI / 2;
            swingDust = DustID.Electric;
            dustAmount = 1;
            tagDebuff = null;
        }
    }
}
