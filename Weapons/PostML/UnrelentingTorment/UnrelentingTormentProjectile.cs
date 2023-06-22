using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using UnofficialCalamityWhips.Globals;
using System;
using UnofficialCalamityWhips.Weapons.PostML.BlossomsBlessing;

namespace UnofficialCalamityWhips.Weapons.PostML.UnrelentingTorment
{
	public class UnrelentingTormentProjectile : WhipBase
	{
        public override void SetStaticDefaults()
        {
            // This makes the projectile use whip collision detection and allows flasks to be applied to it.
            ProjectileID.Sets.IsAWhip[Type] = true;
        }
        public override void SetWhipStats()
        {
            Projectile.localNPCHitCooldown = -1;
            Projectile.WhipSettings.Segments = 20;
            Projectile.WhipSettings.RangeMultiplier = 1.6f;
            fishingLineColor = Color.Gray;
            segmentRotation = -MathF.PI / 2;
            dustAmount = 1;
            swingDust = DustID.SpectreStaff;
            tagDebuff = ModContent.BuffType<TormentTagDebuff>();
        }
    }
}
