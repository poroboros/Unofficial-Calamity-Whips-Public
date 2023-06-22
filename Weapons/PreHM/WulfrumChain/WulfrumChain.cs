using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace UnofficialCalamityWhips.Weapons.PreHM.WulfrumChain
{
	public class WulfrumChain : ModItem
	{

		float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			//Tooltip.SetDefault("Your summons will focus struck enemies\nFlimsy, but it will have to do");
		}

		public override void SetDefaults() {
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			Item.DefaultToWhip(ModContent.ProjectileType<WulfrumChainProjectile>(), (int)(9 * damageMod), 2, 4); 
			//Item.autoReuse = true;

			//Item.shootSpeed = 4;
			Item.value = Item.sellPrice(silver:20);
			Item.rare = ItemRarityID.Blue;


		}

				// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("WulfrumShard").Type, 8);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
		}
	}
}
