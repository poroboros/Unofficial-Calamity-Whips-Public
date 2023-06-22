using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UnofficialCalamityWhips.Weapons.HM.DaedalusWhip;

namespace UnofficialCalamityWhips.Weapons.PreHM.SkySplitter {
    
    internal class SkySplitterProj : WhipBase
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
            fishingLineColor = Color.Yellow;
            segmentRotation = -MathF.PI / 2;
            dustAmount = 1;
            swingDust = DustID.MagicMirror;
            tagDebuff = ModContent.BuffType<SkySplitterDebuff>();
        }
    }
}

