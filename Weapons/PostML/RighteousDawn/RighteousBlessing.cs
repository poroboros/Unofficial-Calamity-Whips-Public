using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace UnofficialCalamityWhips.Weapons.PostML.RighteousDawn
{
	public class RighteousBlessing : ModBuff
	{

		//public override string Texture => "UnofficialCalamityWhips/Buffs/DefaultDebuff";
		public override void SetStaticDefaults() {
			//DisplayName.SetDefault("Rightous Blessing");
			//Description.SetDefault("Increases defense by 20 and increases life regeneration");
		}

		public override void Update(Player player, ref int buffIndex) {
			player.statDefense += 25;
			//player.moveSpeed += 1.33f;
			player.GetModPlayer<RighteousBlessingPlayer>().rightousBlessing = true;
		}

		/*public override void DrawEffects(Player player, ref Color drawColor) {
			if (radiantMark) {
				if (Main.rand.Next(4) < 3) {
					int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 58, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.NextBool(4)) {
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
			}
		}*/
	}
}

public class RighteousBlessingPlayer: ModPlayer 
{
	public bool rightousBlessing = false;

	public override void ResetEffects() {
		rightousBlessing = false;
	}

	public override void  DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
	if (rightousBlessing) {
		if (Main.rand.Next(4) < 2) {
			int dust = Dust.NewDust(Player.position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, DustID.UltraBrightTorch, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), .7f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 1.8f;
			Main.dust[dust].velocity.Y -= 0.5f;
			if (Main.rand.NextBool(4)) {
				Main.dust[dust].noGravity = false;
				Main.dust[dust].scale *= 0.5f;
			}
		}
		if (Main.rand.Next(4) < 2) {
			int dust = Dust.NewDust(Player.position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, DustID.Firework_Yellow, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), .7f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 1.8f;
			Main.dust[dust].velocity.Y -= 0.5f;
			if (Main.rand.NextBool(4)) {
				Main.dust[dust].noGravity = false;
				Main.dust[dust].scale *= 0.5f;
			}
		}
		//Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
		}
	}

	public override void UpdateLifeRegen() {
		if (rightousBlessing) {
			Player.lifeRegen += 12;
		}
	}

}
