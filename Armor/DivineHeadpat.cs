using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace UnofficialCalamityWhips.Armor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
	public class DivineHeadpat : ModItem
	{
		public override void SetStaticDefaults() {
			///Tooltip.SetDefault("This is a modded hood.");

            //ArmorIDs.Face.Sets.DrawInFaceFlowerLayer[Item.faceSlot] = true;
			
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 5));
		}

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Cyan; // The rarity of the item
			//Item.defense = 4; // The amount of defense the item will give when equipped
            Item.accessory = true;
			Item.vanity = true;
		}

		public override void UpdateVanity(Player player) {
			player.GetModPlayer<NewPlayerStats>().hasHeadpat = true;
		}



		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("CosmiliteBar").Type, 5);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
		}
	}
}