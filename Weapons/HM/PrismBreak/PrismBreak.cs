using UnofficialCalamityWhips.Rarities;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace UnofficialCalamityWhips.Weapons.HM.PrismBreak
{
	public class PrismBreak: ModItem
	{
		float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			//Tooltip.SetDefault("7 summon tag damage\nYour summons will focus struck enemies\nShoots two slimy whips in opposite directions");
		}

		public override void SetDefaults() {
			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = (int)(50*damageMod);
			Item.knockBack = 2;

			Item.shoot = ModContent.ProjectileType<PrismBreakProjectile>();
			Item.shootSpeed = 10;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.UseSound = SoundID.Item152;
			//Item.channel = true; // This is used for the charging functionality. Remove it if your whip shouldn't be chargeable.
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.value= Item.sellPrice(gold:7, silver:20);
			Item.rare = ModContent.RarityType<SkyBlue>();


		}

				// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("Navystone").Type, 10);
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("SeaPrism").Type, 15);
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("MolluskHusk").Type, 5);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}

		}
		}
}
