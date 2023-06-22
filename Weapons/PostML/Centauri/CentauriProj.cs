
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UnofficialCalamityWhips.Weapons.PostML.BlossomsBlessing;

namespace UnofficialCalamityWhips.Weapons.PostML.Centauri {

    internal class CentauriProj : WhipBase
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
            fishingLineColor = Color.Lavender;
            segmentRotation = -MathF.PI / 2;
            tagDebuff = ModContent.BuffType<CentauriDebuff>();
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (ModContent.TryFind("CalamityMod/Electrified", out ModBuff buff))
            {
                target.AddBuff(buff.Type, 240);
            }
            WhipOnHit(target);
        }
    }
}
