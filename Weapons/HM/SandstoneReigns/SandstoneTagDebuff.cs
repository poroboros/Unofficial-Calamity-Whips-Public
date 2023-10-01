using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using UnofficialCalamityWhips.Globals;

namespace UnofficialCalamityWhips.Weapons.HM.SandstoneReigns
{
	public class SandstoneTagDebuff : ModBuff
	{

		public override string Texture => UnofficialCalamityWhips.buffPath;
		public override void SetStaticDefaults() {
			Main.debuff[Type] = true;
            BuffID.Sets.IsATagBuff[Type] = true;
            Main.buffNoSave[Type] = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<GlobalTagDebuffs>().activeTag = Type;
			npc.GetGlobalNPC<GlobalTagDebuffs>().predatorIndex = buffIndex; //This is used so I can remove the tag later
		}
	}
}
