using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UnofficialCalamityWhips.Weapons.HM.PrismBreak;

namespace UnofficialCalamityWhips.Weapons.HM.SirensSerenity {
    internal class SirensSerenityProj : WhipBase
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
            Projectile.WhipSettings.Segments = 10;
            Projectile.WhipSettings.RangeMultiplier = 1f;
            fishingLineColor = Color.SeaGreen;
            segmentRotation = -MathF.PI / 2;
            dustAmount = 3;
            swingDust = DustID.Water;
            tagDebuff = ModContent.BuffType<SirensSerenityDebuff>();
        }
    }
}
