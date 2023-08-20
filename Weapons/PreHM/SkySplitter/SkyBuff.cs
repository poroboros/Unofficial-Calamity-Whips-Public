using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnofficialCalamityWhips.Weapons.PreHM.SkySplitter {
    internal class SkyBuff : ModBuff{
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
        }
        public int rand = 1;
        bool flightbuff = true;

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<SkyBuffPlayer>().skyBuff = true;          
           
        }    
              
    }

    public class SkyBuffPlayer : ModPlayer{

        public bool skyBuff;
        public int bonus = 18;

        public override void ResetEffects() {
		skyBuff = false;
        bonus = 18;
	    }

        	public override void  DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
                if (skyBuff) {
                    if (Main.rand.Next(4) < 2) {
                        int dust = Dust.NewDust(Player.position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, DustID.Firework_Blue, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), .7f);
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].velocity *= 1.8f;
                        Main.dust[dust].velocity.Y -= 0.5f;
                        if (Main.rand.NextBool(4)) {
                            Main.dust[dust].noGravity = false;
                            Main.dust[dust].scale *= 0.5f;
                        }
                    }
                }
            }
		//Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
		

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (skyBuff && proj.DamageType == DamageClass.SummonMeleeSpeed) {
                if(Main.rand.NextBool(2)) {
                    Player player = Main.player[proj.owner];
                    player.wingTime += bonus;
                    bonus--;
                }
            }

        }
    }
}
