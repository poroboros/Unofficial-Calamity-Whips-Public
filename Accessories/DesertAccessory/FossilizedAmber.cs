
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace UnofficialCalamityWhips.Accessories.DesertAccessory
{
	public class FossilizedAmber : ModItem
	{
		public override void SetStaticDefaults() {

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver:40);
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ResilientSlagPlayer>().hasCrystal = true;
		}

		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
			}

		}
	}

	public class ResilientSlagPlayer : ModPlayer {
		public bool hasCrystal;

		public override void ResetEffects() {
			hasCrystal = false;
		}

		public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
		{
            if (hasCrystal && proj.DamageType == DamageClass.SummonMeleeSpeed)
            {
                //Main.NewText(proj.DamageType.ToString(), 150, 250, 150);
                Main.player[proj.owner].AddBuff(ModContent.BuffType<StonesEndurance>(), 240);
            }
        }

	}


	
}