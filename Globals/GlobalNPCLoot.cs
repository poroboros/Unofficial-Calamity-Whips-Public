using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnofficialCalamityWhips.Globals
{
	// This file shows numerous examples of what you can do with the extensive NPC Loot lootable system. 
	// Despite this file being GlobalNPC, everything here can be used with a ModNPC as well! See examples of this in the Content/NPCs folder.
	public class GlobalNPCLoot : GlobalNPC
	{
		//ModifyNPCLoot uses a unique system called the ItemDropDatabase, which has many different rules for many different drop use cases.
		//Here we go through all of them, and how they can be used.
		//There are tons of other examples in vanilla! In a decompiled vanilla build, GameContent/ItemDropRules/ItemDropDatabase adds item drops to every single vanilla NPC, which can be a good resource.

		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
			if (UnofficialCalamityWhips.calamity !=null) {
				if (UnofficialCalamityWhips.calamity.TryFind<ModNPC>("Horse", out ModNPC found) && found.Type == npc.type) { 
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Accessories.DesertAccessory.CrystalLodestone>(), 4));

				}	
				if (UnofficialCalamityWhips.calamity.TryFind<ModNPC>("CrawlerAmber", out found) && found.Type == npc.type) { 
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Accessories.DesertAccessory.FossilizedAmber>(), 5));

				}
				if (UnofficialCalamityWhips.calamity.TryFind<ModNPC>("Anahita", out found) && found.Type == npc.type) { 
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Weapons.HM.SirensSerenity.SirensSerenityItem>(), 2));

				}
			}
		}
	}


}
