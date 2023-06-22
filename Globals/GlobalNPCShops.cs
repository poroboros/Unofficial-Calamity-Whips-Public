using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using UnofficialCalamityWhips.Accessories.GloveCraftingTree;
using UnofficialCalamityWhips.Weapons.PreHM.CoralCrusher;
using System.Linq;

namespace UnofficialCalamityWhips.Globals
{
	// This file shows numerous examples of what you can do with the extensive NPC Loot lootable system. 
	// Despite this file being GlobalNPC, everything here can be used with a ModNPC as well! See examples of this in the Content/NPCs folder.
	public class GlobalNPCShops : GlobalNPC
	{

		public override void SetupShop(int type, Chest shop, ref int nextSlot) { //edit npc shops

			if (UnofficialCalamityWhips.calamity != null) {
			// 	if (UnofficialCalamityWhips.calamity.TryFind<ModNPC>("THIEF", out ModNPC npc)) {
			// 		if (type==npc.Type) {
			// 		shop.item[nextSlot].SetDefaults(ModContent.ItemType<WornGrip>());
			// 		//shop.item[nextSlot].shopCustomPrice = Item.sellPrice(copper: 40);
			// 		nextSlot++;
			// 		}
			// 	}
				if (UnofficialCalamityWhips.calamity.TryFind<ModNPC>("SEAHOE", out ModNPC npc)) {
					if (type==npc.Type) {
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<CoralCrusherItem>());
					//shop.item[nextSlot].shopCustomPrice = Item.sellPrice(copper: 40);
					nextSlot++;
					}
				}
			}


		}
	}


}
