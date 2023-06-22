using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace UnofficialCalamityWhips
{
	public class UnofficialCalamityWhips : Mod
	{
		public static Mod calamity;

		public static string buffPath = "UnofficialCalamityWhips/DefaultDebuff";

		public override void Load() {
			if (ModLoader.HasMod("CalamityMod")) {
				calamity = ModLoader.GetMod("CalamityMod");
			}
			else {
				calamity = null;
			}
		}
		
	}
}