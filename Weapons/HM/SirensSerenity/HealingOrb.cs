using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnofficialCalamityWhips.Weapons.HM.SirensSerenity {
    internal class HealingOrb : ModItem{
        public override void SetStaticDefaults()
        {
            
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.width = 20;
            Item.height = 18;
            //ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
        public override bool OnPickup(Player player)
        {
            int heal = Math.Min(40, player.statLifeMax2 - player.statLife);
            player.statLife += heal;
            player.HealEffect(heal);
                 
                      
            return false;
        }
      
    }
}
