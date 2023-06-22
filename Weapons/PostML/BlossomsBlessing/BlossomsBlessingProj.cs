
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;




namespace UnofficialCalamityWhips.Weapons.PostML.BlossomsBlessing {

    internal class BlossomsBlessingProj : WhipBase
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
            Projectile.WhipSettings.RangeMultiplier = .7f;
            fishingLineColor = Color.Green;
            segmentRotation = -MathF.PI / 2;
            dustAmount = 1;
            swingDust = DustID.Plantera_Pink;
            tagDebuff = ModContent.BuffType<BlossomsBlessingDebuff>();
        }
    }
}
