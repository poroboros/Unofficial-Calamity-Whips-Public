
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using UnofficialCalamityWhips.Accessories.GloveCraftingTree.BuffsDebuffs;

namespace UnofficialCalamityWhips.Accessories.GloveCraftingTree
{
	public class RingOfAlacrity : ModItem
	{
		public override void SetStaticDefaults() {

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.buyPrice(gold:15);
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<RingSpeedPlayer>().hasSpeed = true;
		}

		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("AerialiteBar").Type, 5);
				recipe.AddIngredient(ItemID.Bone, 50);
				//recipe.AddIngredient(ModContent.ItemType<WornGrip>());
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}

		}
	}

	public class RingSpeedPlayer : ModPlayer {
		public bool hasSpeed;

		public override void ResetEffects() {
			hasSpeed = false;
		}

		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (hasSpeed && proj.DamageType == DamageClass.SummonMeleeSpeed) { 
				//Main.NewText(proj.DamageType.ToString(), 150, 250, 150);
				Main.player[proj.owner].AddBuff(ModContent.BuffType<Alacrity>(), 240);
				//target.AddBuff(ModContent.BuffType<LodestoneTagDebuff>(), 240);
			}
		}
	}

	
}