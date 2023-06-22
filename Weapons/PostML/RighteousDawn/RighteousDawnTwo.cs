using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using UnofficialCalamityWhips.Rarities;
using UnofficialCalamityWhips.Weapons.HM.BrimstoneLash;

namespace UnofficialCalamityWhips.Weapons.PostML.RighteousDawn
{
	public class RighteousDawnTwo : ModItem
	{
		float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			//DisplayName.SetDefault("Lash of Languish");
			//Tooltip.SetDefault("Inflicts Holy Flames\n If you are nearby your target, your minions will embue you with resistance\n'A true king leads their troops into battle'");
		}

		public override void SetDefaults() {
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			Item.DefaultToWhip(ModContent.ProjectileType<RighteousDawnProjectile>(), (int)(380	*damageMod), 6, 14); 
			Item.useTime =25;
			Item.useAnimation =25;
			//Item.useTime = Item.useTime;
			Item.autoReuse = true;

			//Item.shootSpeed = 4;
			
			Item.value = Item.sellPrice(gold:24);	
			Item.rare = Item.rare = UnofficialCalamityWhips.calamity.Find<ModRarity>("Turquoise").Type;


		}

				// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("DivineGeode"), 8);
				recipe.AddIngredient(ItemID.FragmentSolar, 8);
				//recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("AstralBar").Type, 5);
				recipe.AddIngredient(ModContent.ItemType<BrimstoneLash>());
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
		}
	}
}
