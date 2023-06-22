using UnofficialCalamityWhips.Rarities;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace UnofficialCalamityWhips.Weapons.PostML.UnrelentingTorment
{
	public class UnrelentingTorment : ModItem
	{
		float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;

		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			//DisplayName.SetDefault("[c/03D603:Unrelenting Torment]");
			//Tooltip.SetDefault("Releases a torment of ghastly claws\nYour minions will call disembodied claws from beyond");
		}

		public override void SetDefaults() {
			Item.DefaultToWhip(ModContent.ProjectileType<UnrelentingTormentProjectile>(), (int)(200*damageMod), 4, 5); 
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold:28);
			/*ModRarity calamRare = null;
			if (UnofficialCalamityWhips.calamity != null) {
				UnofficialCalamityWhips.calamity.TryFind<ModRarity>("Turquoise", out calamRare);
			}
			if (calamRare != null) {
				Item.rare = calamRare.Type;
			}
			else {*/
				Item.rare = UnofficialCalamityWhips.calamity.Find<ModRarity>("PureGreen").Type;
			//}
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			
			for (int i = 0; i < 5; i++)
			{

				float calc = Main.rand.Next(-2, 3);
				Vector2 normal = Vector2.Normalize(velocity);
				Vector2 perp1 = Vector2.Multiply(new Vector2(-normal.Y, normal.X), calc);
				Projectile.NewProjectile(source, position, Vector2.Add(velocity, perp1), ModContent.ProjectileType<UnrelentingTormentProjectile>(), damage, knockback, player.whoAmI);
				//Projectile.NewProjectile(source, position, Vector2.Add(velocity, perp2), ModContent.ProjectileType<UnrelentingTormentProjectile>(), damage, knockback, player.whoAmI);
			}
			return false; // return false to stop vanilla from calling Projectile.NewProjectile.
		}

				// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("RuinousSoul").Type, 5);
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("Phantoplasm").Type, 5);
				recipe.AddIngredient(ItemID.Chain, 10);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
		}
	}
}
