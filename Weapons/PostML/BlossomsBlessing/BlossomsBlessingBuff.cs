using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnofficialCalamityWhips.Weapons.PostML.BlossomsBlessing {
    internal class BlossomsBlessingBuff : ModBuff{

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            //DisplayName.SetDefault("Blossom's Blessing");
            //Description.SetDefault("Increases defense, life regen and movespeed");
            Main.buffNoTimeDisplay[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen *= 5;
            player.statDefense += 15;
            player.moveSpeed *= 2;
        }
        
    }
}
