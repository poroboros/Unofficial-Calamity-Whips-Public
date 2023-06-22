using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnofficialCalamityWhips.Weapons.PostML.ResonateStriker
{
	public class ResonateStriker : ModItem
	{
		float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			//Tooltip.SetDefault("20 summon tag damage\nYour summons will focus struck enemies\nInfuses you with pure resonance on each hit, increasing your movement and melee speed");
		}

		public override void SetDefaults() {
			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = (int)(230*damageMod);
			Item.knockBack = 4;

			Item.shoot = ModContent.ProjectileType<ResonateStrikerProjectile>();
			Item.shootSpeed = 8;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item152;
			//Item.channel = true; // This is used for the charging functionality. Remove it if your whip shouldn't be chargeable.
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.value = Item.sellPrice(gold:22);
			Item.rare = ItemRarityID.Purple;
		}

				// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("EffulgentFeather").Type, 5);
				recipe.AddIngredient(ItemID.SwordWhip);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
		}
	}
}
