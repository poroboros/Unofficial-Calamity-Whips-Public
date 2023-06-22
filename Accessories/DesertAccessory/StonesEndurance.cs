using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace UnofficialCalamityWhips.Accessories.DesertAccessory
{
	public class StonesEndurance : ModBuff
	{
		public override void SetStaticDefaults() {
			//DisplayName.SetDefault("Pure Resonance");
			//Description.SetDefault("Increases melee and movement speed");
		}

		public override void Update(Player player, ref int buffIndex) {
			player.statDefense += 8;
			player.GetModPlayer<StonesEndurancePlayer>().stonesEndurance = true;
		}

	}
}

public class StonesEndurancePlayer: ModPlayer 
{
	public bool stonesEndurance = false;

	public override void ResetEffects() {
		stonesEndurance = false;
	}

	/*public override void  DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
	if (pureResonance) {
		if (Main.rand.Next(4) < 3) {
			int dust = Dust.NewDust(Player.position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, DustID.Firework_Red, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), .7f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 1.8f;
			Main.dust[dust].velocity.Y -= 0.5f;
			if (Main.rand.NextBool(4)) {
				Main.dust[dust].noGravity = false;
				Main.dust[dust].scale *= 0.5f;
			}
		}
		//Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
	}*/
}

