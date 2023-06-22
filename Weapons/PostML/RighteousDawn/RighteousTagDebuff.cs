using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using UnofficialCalamityWhips.Globals;

namespace UnofficialCalamityWhips.Weapons.PostML.RighteousDawn
{
	public class RighteousTagDebuff : ModBuff
	{
		public override string Texture => UnofficialCalamityWhips.buffPath;
		public override void SetStaticDefaults() {
			Main.debuff[Type] = true;
            BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
            Main.buffNoSave[Type] = true;
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
npc.GetGlobalNPC<GlobalTagDebuffs>().activeTag = Type;
			npc.GetGlobalNPC<GlobalTagDebuffs>().righteousIndex = buffIndex;
		}
	}

}
