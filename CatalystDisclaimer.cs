using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace UnofficialCalamityWhips
{
    public class CatalystDisclaimer : ModPlayer
    {

        bool runOnce = true;


        public override void OnEnterWorld()
        {
            if (ModContent.GetInstance<UnofficialCalamityWhipsConfig>().CatalystDisclaimer && runOnce) {
                Main.NewText("DISCLAIMER: Unofficial Calamity Whips has concluded development and has been merged with Catalyst! Currently, Catalyst is still being ported, so for high quality whips, check out Catalyst in 1.4.3!", Color.PowderBlue);
                runOnce = false;
            }
        }
    }
}