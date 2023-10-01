using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using UnofficialCalamityWhips.Globals;

namespace UnofficialCalamityWhips.Weapons.PostML.UnrelentingTorment
{
	public class TormentTagDebuff : ModBuff
	{

		public override string Texture => UnofficialCalamityWhips.buffPath;
		public override void SetStaticDefaults() {
			// This allows the debuff to be inflicted on NPCs that would otherwise be immune to all debuffs.
			// Other mods may check it for different purposes.
			Main.debuff[Type] = true;
            BuffID.Sets.IsATagBuff[Type] = true;
            Main.buffNoSave[Type] = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
npc.GetGlobalNPC<GlobalTagDebuffs>().activeTag = Type;
			npc.GetGlobalNPC<GlobalTagDebuffs>().tormentIndex = buffIndex;
		}
	}
}
