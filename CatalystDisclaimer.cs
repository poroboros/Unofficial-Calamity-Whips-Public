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
                Main.NewText("DISCLAIMER: Unofficial Calamity Whips has concluded development and has been merged with Catalyst, for higher quality and more exciting whips, wait for the next Catalyst update!", Color.PowderBlue);
                runOnce = false;
            }
        }
    }
}