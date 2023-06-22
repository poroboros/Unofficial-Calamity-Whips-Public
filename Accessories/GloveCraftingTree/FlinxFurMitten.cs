
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using UnofficialCalamityWhips.Accessories.GloveCraftingTree.BuffsDebuffs;

namespace UnofficialCalamityWhips.Accessories.GloveCraftingTree
{

	[AutoloadEquip(EquipType.HandsOn)]
	public class FlinxFurMitten : ModItem
	{
		public override void SetStaticDefaults() {

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			//Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(25, 4));
		}

		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(silver:80);
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.whipRangeMultiplier += .08f;
			player.autoReuseGlove = true;
			player.GetAttackSpeed<MeleeDamageClass>() += .12f;
			player.GetModPlayer<FlinxFurPlayer>().hasGlove = true;
		}

		public override void AddRecipes() {
			// if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(ModContent.ItemType<SlimySling>());
				recipe.AddIngredient(ItemID.FlinxFur, 5);
				recipe.AddIngredient(ItemID.FeralClaws);
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.Register();
			// }

		}
	}

		public class FlinxFurPlayer : ModPlayer {
		public bool hasGlove;

		bool startCount = false;
		int timer = 0;

		public override void ResetEffects() {
			hasGlove = false;
		}


		/*public override void PreUpdate() {
			if (startCount) {
				timer--;
				if (timer <= 0) {
					startCount = false;
				}
			}
		}*/

		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
			if (hasGlove&& proj.DamageType == DamageClass.SummonMeleeSpeed && !target.buffImmune[BuffID.Confused]) {
				if (UnofficialCalamityWhips.calamity != null)
				target.AddBuff(ModContent.BuffType<BitterCold>(), 240);
				//Item.NewItem(target.GetSource_DropAsItem(), target.position, Vector2.Zero, ItemID.Heart);
			}
		}
	}

	
}