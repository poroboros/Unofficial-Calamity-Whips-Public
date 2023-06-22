
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace UnofficialCalamityWhips.Accessories.GloveCraftingTree
{
	public class SlimySling : ModItem
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
			player.whipRangeMultiplier += .08f;
		}

		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(ItemID.Leather, 5);
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("BlightedGel").Type, 10);
				recipe.AddTile(TileID.Solidifier);
				recipe.Register();
			}

		}
	}

	
}