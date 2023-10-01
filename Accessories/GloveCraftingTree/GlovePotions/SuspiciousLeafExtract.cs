
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace UnofficialCalamityWhips.Accessories.GloveCraftingTree.GlovePotions
{
	public class SuspiciousLeafExtract : ModItem
	{
		public override void SetStaticDefaults() {

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.buyPrice(silver:80);
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			//player.whipRangeMultiplier += .08f;
			player.GetModPlayer<LeafPotionPlayer>().hasLeaf = true;
		}

		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("MurkyPaste").Type, 5);
				recipe.AddIngredient(ItemID.Moonglow, 3);
				//recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("BeetleJuice").Type, 2);
				recipe.AddIngredient(ItemID.Bottle);
				recipe.AddTile(TileID.AlchemyTable);
				recipe.Register();
			}

		}
	}

	public class LeafPotionPlayer : ModPlayer {
		public bool hasLeaf;

		bool startCount = false;
		int timer = 0;

		public override void ResetEffects() {
			hasLeaf = false;
		}


		public override void PreUpdate() {
			if (startCount) {
				timer--;
				if (timer <= 0) {
					startCount = false;
				}
			}
		}

		public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
			if (hasLeaf && timer == 0 && proj.DamageType == DamageClass.SummonMeleeSpeed) {
				//Main.NewText(proj.DamageType.ToString(), 150, 250, 150);
				timer = 120;
				startCount = true;

				NewPlayerStats stats = Main.player[proj.owner].GetModPlayer<NewPlayerStats>();
				if (stats.leafCount < 4) {
					Projectile.NewProjectile(Projectile.InheritSource(proj), Main.player[proj.owner].position, Microsoft.Xna.Framework.Vector2.Zero, ModContent.ProjectileType<OrbitLeaf>(), (int)(proj.damage*.75f), 0, proj.owner);
					stats.leafCount++;
				}
				

				//Item.NewItem(target.GetSource_DropAsItem(), target.position, Vector2.Zero, ItemID.Heart);
			}
		}
	}
}