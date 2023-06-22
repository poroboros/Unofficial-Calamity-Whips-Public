using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using UnofficialCalamityWhips.Globals;

namespace UnofficialCalamityWhips.Weapons.PreHM.CoralCrusher {
	public class CoralCrusherDebuff : ModBuff {

		public override string Texture => UnofficialCalamityWhips.buffPath;
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = true;
            BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
            Main.buffNoSave[Type] = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
npc.GetGlobalNPC<GlobalTagDebuffs>().activeTag = Type;
			npc.GetGlobalNPC<GlobalTagDebuffs>().coralIndex = buffIndex;

		}
	}
}
