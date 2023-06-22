using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace UnofficialCalamityWhips.Accessories.GloveCraftingTree.BuffsDebuffs
{
	public class Alacrity : ModBuff
	{
		public override void SetStaticDefaults() {
			//DisplayName.SetDefault("Pure Resonance");
			//Description.SetDefault("Increases melee and movement speed");
		}

		public override void Update(Player player, ref int buffIndex) {
			player.moveSpeed += .10f;
		}

	}
}

