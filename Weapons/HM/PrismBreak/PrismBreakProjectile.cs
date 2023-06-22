using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;

namespace UnofficialCalamityWhips.Weapons.HM.PrismBreak
{
    internal class PrismBreakProjectile : WhipBase
    {
        public override void SetStaticDefaults()
        {
            // This makes the projectile use whip collision detection and allows flasks to be applied to it.
            ProjectileID.Sets.IsAWhip[Type] = true;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            whipSegment2 = (Texture2D)ModContent.Request<Texture2D>(Texture + "_Segment2");
            SetWhipStats();
        }
        public override void SetWhipStats()
        {
            Projectile.localNPCHitCooldown = -1;
            Projectile.WhipSettings.Segments = 20;
            Projectile.WhipSettings.RangeMultiplier = .6f;
            fishingLineColor = Color.Aquamarine;
            segmentRotation = -MathF.PI / 2;
            swingDust = DustID.MagicMirror;
            dustAmount = 1;
            tagDebuff = ModContent.BuffType<PrismTagDebuff>();
        }
    }
}
