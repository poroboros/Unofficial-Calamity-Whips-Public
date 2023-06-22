using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;
using UnofficialCalamityWhips.Weapons.HM.DaedalusWhip;

namespace UnofficialCalamityWhips.Weapons.HM.SandstoneReigns
{
    internal class SandstoneReignsProjectile : WhipBase
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
            Projectile.WhipSettings.RangeMultiplier = 1f;
            fishingLineColor = new Color(209, 83, 61);
            segmentRotation = -MathF.PI / 2;
            dustAmount = 2;
            swingDust = DustID.Sand;
            tagDebuff = ModContent.BuffType<SandstoneTagDebuff>();
        }

    }
}
