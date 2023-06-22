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
    internal class BuffOrb : ModItem{
        public override void SetStaticDefaults()
        {
            
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.width = 20;
            Item.height = 18;
            //ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            //Item.life
            Item.color = Color.Green;
        }
        public override bool OnPickup(Player player)
        {
            
           
            player.AddBuff(ModContent.BuffType<HealingMelody>(), 240);
                 
                      
            return false;
        }
      
    }
}
