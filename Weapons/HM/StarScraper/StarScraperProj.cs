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

namespace UnofficialCalamityWhips.Weapons.HM.StarScraper {
    internal class StarScraperProj : WhipBase
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
            Projectile.WhipSettings.RangeMultiplier = 1.2f;
            fishingLineColor = Color.Yellow;
            segmentRotation = -MathF.PI / 2;
            dustAmount = 2;
            swingDust = DustID.YellowStarDust;
            tagDebuff = ModContent.BuffType<StarScraperDebuff>();
        }

        /*
         Dust.NewDust(pointsForCollision[pointsForCollision.Count - 1], Projectile.width, Projectile.height, DustID.IceTorch, 0.0f, 0.0f, 0, new Color(), 1f);
		 Dust.NewDust(pointsForCollision[pointsForCollision.Count - 1], Projectile.width, Projectile.height, DustID.OrangeTorch, 0.0f, 0.0f, 0, new Color(), 1f);
         */
        
    }
}
