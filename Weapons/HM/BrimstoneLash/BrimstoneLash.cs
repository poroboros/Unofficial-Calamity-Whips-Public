using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnofficialCalamityWhips.Weapons.HM.BrimstoneLash
{
	public class BrimstoneLash : ModItem
	{
		float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("Lash of Languish");
			//Tooltip.SetDefault("Inflicts Brimstone Flame\n Your minions will release a brimstone explosion on hit.\n'Languish in the flames of Gehenna'");
		}

		public override void SetDefaults() {
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			Item.DefaultToWhip(ModContent.ProjectileType<BrimstoneLashProjectile>(), (int)(92*damageMod), 3, 10); 
			//Item.useTime = Item.useTime;
			Item.autoReuse = true;

			//Item.shootSpeed = 4;
			
			Item.value = Item.sellPrice(gold:12);	
			Item.rare = ItemRarityID.Lime;


		}

				// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("UnholyCore").Type, 4);
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("AshesofCalamity").Type, 4);
				recipe.AddIngredient(ItemID.FireWhip);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
		}
	}
}
