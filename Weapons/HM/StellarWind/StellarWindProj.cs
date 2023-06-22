using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using UnofficialCalamityWhips.Weapons.HM.PrismBreak;

namespace UnofficialCalamityWhips.Weapons.HM.StellarWind {
    internal class StellarWindProj : WhipBase
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
            fishingLineColor = new Color(209, 83, 61);
            segmentRotation = -MathF.PI / 2;
            tagDebuff = ModContent.BuffType<StellarWindDebuff>();
        }
    }
}
