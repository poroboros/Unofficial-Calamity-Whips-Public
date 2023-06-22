using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using UnofficialCalamityWhips.Weapons.PreHM.StaticScourge;

namespace UnofficialCalamityWhips.Weapons.HM.SulphuricScourge
{
	public class SulphuricScourge : ModItem
	{
		float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			//Tooltip.SetDefault("Your minions will release toxic clouds into the air");
		}

		public override void SetDefaults() {
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			Item.DefaultToWhip(ModContent.ProjectileType<SulphuricScourgeProjectile>(), (int)(55*damageMod), 4, 8); 
			//Item.useTime = Item.useTime;
			Item.autoReuse = true;

			//Item.shootSpeed = 4;
			Item.value = Item.sellPrice(gold:7, silver:20);
			Item.rare = ItemRarityID.Pink;


		}

				// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("CorrodedFossil").Type, 15);
				recipe.AddIngredient(ModContent.ItemType<StaticScourge>());
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}

		}
	}
}
