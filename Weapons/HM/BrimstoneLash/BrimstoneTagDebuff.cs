using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using UnofficialCalamityWhips.Globals;

namespace UnofficialCalamityWhips.Weapons.HM.BrimstoneLash
{
	public class BrimstoneTagDebuff : ModBuff
	{

		public override string Texture => UnofficialCalamityWhips.buffPath;
		public override void SetStaticDefaults() {
			// This allows the debuff to be inflicted on NPCs that would otherwise be immune to all debuffs.
			// Other mods may check it for different purposes.
					Main.debuff[Type] = true;
            BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
            Main.buffNoSave[Type] = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
npc.GetGlobalNPC<GlobalTagDebuffs>().activeTag = Type;
			npc.GetGlobalNPC<GlobalTagDebuffs>().brimstoneIndex = buffIndex;
		}
	}
}
