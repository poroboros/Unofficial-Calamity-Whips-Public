using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using UnofficialCalamityWhips.Weapons.HM;

namespace UnofficialCalamityWhips.Weapons.HM.StarScraper{
    public class RightousDawn : ModItem{

		float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Star Scraper");
			//Tooltip.SetDefault("Minions summon stars from the heavens\n25 summon tag damage\nYour summons will target struck enemies");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			Item.DefaultToWhip(ModContent.ProjectileType<StarScraperProj>(), (int)(165*damageMod), 5, 6); 
			//Item.useTime = Item.useTime;
			Item.autoReuse = true;

			//Item.shootSpeed = 4;
			
			Item.value = Item.sellPrice(gold:20);	
			Item.rare = ItemRarityID.Red;

			//Item.channel = true;
		}


		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(ItemID.FragmentStardust, 18);
				//recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("MeldConstruct").Type, 3);
				//recipe.AddIngredient(ModContent.ItemType<BrimstoneLash.BrimstoneLash>());
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
		}

				// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}
	}
}
