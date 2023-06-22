using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnofficialCalamityWhips.Weapons.PreHM.StaticScourge
{
	public class StaticScourge : ModItem
	{

		float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			//Tooltip.SetDefault("A short range, lightning fast whip\nInfuses enemies with static electricity, which your minions can discharge to release sparks");
		}

		public override void SetDefaults() {
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			Item.DefaultToWhip(ModContent.ProjectileType<StaticScourgeProjectile>(), (int)(9 * damageMod), 2, 25); 
			Item.useTime = Item.useTime/2;
			Item.useAnimation = Item.useAnimation/2;
			Item.autoReuse = true;

			//Item.shootSpeed = 4;
			Item.value = Item.sellPrice(silver:40);
			Item.rare = ItemRarityID.Green;


		}

				// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("SeaRemains").Type, 6);
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("StormlionMandible").Type, 2);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
		}
	}
}
