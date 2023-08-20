using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;
using UnofficialCalamityWhips.Weapons.PostML.ResonateStriker;

namespace UnofficialCalamityWhips.Weapons.PostML.RighteousDawn
{
	internal class RighteousDawnProjectile : WhipBase
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

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (UnofficialCalamityWhips.calamity != null)
            {
                target.AddBuff(UnofficialCalamityWhips.calamity.Find<ModBuff>("HolyFlames").Type, 240);
            }
            WhipOnHit(target);
        }
        public override void SetWhipStats()
        {
            Projectile.localNPCHitCooldown = -1;
            Projectile.WhipSettings.Segments = 20;
            Projectile.WhipSettings.RangeMultiplier = .85f;
            fishingLineColor = Color.SkyBlue;
            segmentRotation = -MathF.PI / 2;
            dustAmount = 1;
            swingDust = DustID.FireworkFountain_Blue;
            tagDebuff = ModContent.BuffType<RighteousTagDebuff>();
        }
    }
}
