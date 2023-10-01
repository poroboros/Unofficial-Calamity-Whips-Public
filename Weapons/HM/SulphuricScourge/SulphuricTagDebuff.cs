using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using UnofficialCalamityWhips.Globals;

namespace UnofficialCalamityWhips.Weapons.HM.SulphuricScourge
{
	public class SulphuricTagDebuff : ModBuff
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
			npc.GetGlobalNPC<GlobalTagDebuffs>().sulphuricIndex = buffIndex;
		}
	}
	
}
