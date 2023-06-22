using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace UnofficialCalamityWhips.Weapons.PostML.DevourersMaw
{
	public class DevourersHunger : ModBuff
	{

		//public override string Texture => "UnofficialCalamityWhips/Buffs/DefaultDebuff";
		public override void SetStaticDefaults() {
			//DisplayName.SetDefault("Rightous Blessing");
			//Description.SetDefault("Increases defense by 20 and increases life regeneration");
		}

		public override void Update(Player player, ref int buffIndex) {
			//player.moveSpeed += 1.33f;
			player.GetModPlayer<DevourersHungerPlayer>().dHunger = true;
			DevourersHungerPlayer dStats = player.GetModPlayer<DevourersHungerPlayer>();
			int stacks = dStats.hungerStacks > 30 ? 30 : dStats.hungerStacks;
			player.statDefense += (stacks*2);
			player.GetDamage<SummonDamageClass>() += (float)(stacks / 135);
			//player.GetAttackSpeed<MeleeDamageClass>() += (float)((stacks / 3));
			//player.statDefense += 30;
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

public class DevourersHungerPlayer: ModPlayer 
{
	public bool dHunger = false;

	public int hungerStacks = 0;

	public override void ResetEffects() {
		dHunger = false;
	}

	public int timer = 60;

	public override void PreUpdate() {
		timer--;
		if (timer <= 0) {
			hungerStacks--;
			if (hungerStacks < 0) {
				hungerStacks = 0;
			}
			timer = 60;
		}

	}

	public override void  DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
	if (dHunger) {
		int dustDivide = 6;
		if (hungerStacks > 5) {
			dustDivide = 4;
		}
		if (hungerStacks > 15) {
			dustDivide = 2;
		}
		if (hungerStacks > 25) {
			dustDivide = 1;
		}

		int dustType1 = UnofficialCalamityWhips.UnofficialCalamityWhips.calamity.Find<ModDust>("CeaselessDust").Type;
		int dustType2 = UnofficialCalamityWhips.UnofficialCalamityWhips.calamity.Find<ModDust>("AstralEnemy").Type;

		if (Main.rand.NextBool(dustDivide)) {
			int dust = Dust.NewDust(Player.position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, dustType1, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), .7f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 1.8f;
			Main.dust[dust].velocity.Y -= 0.5f;
			if (Main.rand.NextBool(4)) {
				Main.dust[dust].noGravity = false;
				Main.dust[dust].scale *= 0.5f;
			}
		}
		if (Main.rand.NextBool(dustDivide)) {
			int dust = Dust.NewDust(Player.position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, dustType2, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), .7f);
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
		if (hungerStacks > 5) {
			//Player.statDefense += 5;
		}
	}

}
