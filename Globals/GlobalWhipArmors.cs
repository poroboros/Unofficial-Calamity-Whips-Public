using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Collections.Generic;

namespace UnofficialCalamityWhips.Globals
{
	// This file shows a very simple example of a GlobalItem class. GlobalItem hooks are called on all items in the game and are suitable for sweeping changes like
	// adding additional data to all items in the game. Here we simply adjust the damage of the Copper Shortsword item, as it is simple to understand.
	// See other GlobalItem classes in ExampleMod to see other ways that GlobalItem can be used.
	public class GlobalWhipArmors : GlobalItem
	{

        public override bool InstancePerEntity => true;
		// Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
		public override bool AppliesToEntity(Item item, bool lateInstatiation) {

            //TODO REMOVE THIS ONCE ADDED

            if (UnofficialCalamityWhips.calamity == null || !ModContent.GetInstance<UnofficialCalamityWhipsConfig>().AddArmorStats) {
                return false;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("DaedalusHeadSummon").Type) {
                return true;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("PlaguebringerVisor").Type) {
               return true;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("AstralHelm").Type) {
                return true;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("TarragonHeadSummon").Type) {
                return true;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("OmegaBlueHelmet").Type) {
                return true;
            }   
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("BloodflareHeadSummon").Type) {
                return true;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("SilvaHeadSummon").Type) {
                return true;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("AuricTeslaSpaceHelmet").Type) {
                return true;
            }
            return false;
		}


		public override void UpdateEquip(Item item, Player player) {
            if (UnofficialCalamityWhips.calamity == null || !ModContent.GetInstance<UnofficialCalamityWhipsConfig>().AddArmorStats) {
                return;
            }
            float whiprange = 0;
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("DaedalusHeadSummon").Type) {
                whiprange =.1f;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("PlaguebringerVisor").Type) {
               whiprange =.1f;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("AstralHelm").Type) {
                 whiprange =.15f;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("TarragonHeadSummon").Type) {
                 whiprange =.15f;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("OmegaBlueHelmet").Type) {
                 whiprange =.2f;
            }   
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("BloodflareHeadSummon").Type) {
                 whiprange =.2f;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("SilvaHeadSummon").Type) {
                 whiprange =.2f;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("AuricTeslaSpaceHelmet").Type) {
                 whiprange =.25f;
            }
            player.whipRangeMultiplier += whiprange;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {

            if (UnofficialCalamityWhips.calamity == null || !ModContent.GetInstance<UnofficialCalamityWhipsConfig>().AddArmorStats) {
                return;
            }
            float whiprange = 0;
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("DaedalusHeadSummon").Type) {
                whiprange =.1f;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("PlaguebringerVisor").Type) {
               whiprange =.1f;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("AstralHelm").Type) {
                 whiprange =.15f;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("TarragonHeadSummon").Type) {
                 whiprange =.15f;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("OmegaBlueHelmet").Type) {
                 whiprange =.2f;
            }   
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("BloodflareHeadSummon").Type) {
                 whiprange =.2f;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("SilvaHeadSummon").Type) {
                 whiprange =.2f;
            }
            if (item.type == UnofficialCalamityWhips.calamity.Find<ModItem>("AuricTeslaSpaceHelmet").Type) {
                 whiprange =.25f;
            }
            tooltips.Add(new TooltipLine(Mod, "whipRangeMod", (int)(whiprange*100) + "% increased whip range"));
        }
	}
}