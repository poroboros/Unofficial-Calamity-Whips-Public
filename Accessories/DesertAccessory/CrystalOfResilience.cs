
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace UnofficialCalamityWhips.Accessories.DesertAccessory
{
	public class CrystalOfResilience : ModItem
	{
		public override void SetStaticDefaults() {

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
			Item.rare = ItemRarityID.LightPurple;
			Item.value = Item.sellPrice(gold:7, silver:20);
			//Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<BoulderItemPlayer>().hasCrystal = true;
			player.GetModPlayer<ResilientSlagPlayer>().hasCrystal = true;


			if (player.ZoneDirtLayerHeight || player.ZoneUnderworldHeight || player.ZoneRockLayerHeight){
				player.endurance +=.05f;
				player.statDefense += 10;
				player.pickSpeed += .2f;
			}
		}

		public override void AddRecipes() {
				Recipe recipe = CreateRecipe();
				if (UnofficialCalamityWhips.calamity != null) {
					recipe.AddIngredient(ModContent.ItemType<CrystalLodestone>(), 1);
					recipe.AddIngredient(ModContent.ItemType<FossilizedAmber>(), 1);
					recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("ArchaicPowder"), 1);
					recipe.AddTile(TileID.TinkerersWorkbench);
				}
				recipe.Register();

		}
	}
	
}