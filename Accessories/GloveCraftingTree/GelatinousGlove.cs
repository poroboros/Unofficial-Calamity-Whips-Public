
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using UnofficialCalamityWhips.Accessories.GloveCraftingTree.GlovePotions;

namespace UnofficialCalamityWhips.Accessories.GloveCraftingTree
{
	public class GelatinousGlove : ModItem
	{
		public override void SetStaticDefaults() {

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.DefaultToAccessory();
			Item.width = 40;
			Item.height = 40;
			Item.rare = ItemRarityID.LightPurple;
			Item.value = Item.sellPrice(gold:7,silver:20);

		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.whipRangeMultiplier += .15f;
			player.autoReuseGlove = true;
			player.GetAttackSpeed<MeleeDamageClass>() += .12f;
			player.GetModPlayer<RingSpeedPlayer>().hasSpeed = true;
			player.GetModPlayer<FlinxFurPlayer>().hasGlove = true;
			//player.GetModPlayer<CryonicPotionPlayer>().hasCryonic = true;
			//player.GetModPlayer<SanguinePotionPlayer>().hasSanguine = true;
			//player.GetModPlayer<LeafPotionPlayer>().hasLeaf = true;
		}

		public override void AddRecipes() {
				Recipe recipe = CreateRecipe();
				if (UnofficialCalamityWhips.calamity != null) {
					recipe.AddIngredient(ModContent.ItemType<FlinxFurMitten>(), 1);
					recipe.AddIngredient(ModContent.ItemType<RingOfAlacrity>(), 1);
					//recipe.AddIngredient(ItemID.FeralClaws, 1);
					recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("PerennialBar"), 5);
					recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("CoreofSunlight"));
					recipe.AddTile(TileID.Anvils);
					recipe.Register();
				}

		}
	}
}