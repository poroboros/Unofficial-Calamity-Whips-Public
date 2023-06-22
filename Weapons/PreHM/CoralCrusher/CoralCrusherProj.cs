using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UnofficialCalamityWhips.Weapons.HM.DaedalusWhip;

namespace UnofficialCalamityWhips.Weapons.PreHM.CoralCrusher {
    
    internal class CoralCrusherProj : WhipBase
    {
        public override void SetStaticDefaults()
        {
            // This makes the projectile use whip collision detection and allows flasks to be applied to it.
            ProjectileID.Sets.IsAWhip[Type] = true;
        }
        public override void SetWhipStats()
        {
            Projectile.localNPCHitCooldown = -1;
            Projectile.WhipSettings.Segments = 12;
            Projectile.WhipSettings.RangeMultiplier = .7f;
            fishingLineColor = Color.DarkSlateBlue;
            segmentRotation = -MathF.PI / 2;
            dustAmount = 1;
            swingDust = DustID.Coralstone;
            tagDebuff = ModContent.BuffType<CoralCrusherDebuff>();
        }
    }
}
