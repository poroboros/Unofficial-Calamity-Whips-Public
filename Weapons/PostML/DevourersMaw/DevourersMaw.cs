using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using UnofficialCalamityWhips.Rarities;

namespace UnofficialCalamityWhips.Weapons.PostML.DevourersMaw
{
	public class DevourersMaw : ModItem
	{
		float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			//Tooltip.SetDefault("20 summon tag damage\nYour summons will focus struck enemies\nInfuses you with pure resonance on each hit, increasing your movement and melee speed");
		}

		public override void SetDefaults() {
			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = (int)(500*damageMod);
			Item.knockBack = 4;

			Item.shoot = ModContent.ProjectileType<DevourersMawProjectile>();
			Item.shootSpeed = 8;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item152;
			//Item.channel = true; // This is used for the charging functionality. Remove it if your whip shouldn't be chargeable.
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.value = Item.sellPrice(gold:28);

			//Suggestion Rarity
			Item.rare = ModContent.RarityType<SkyBlue>();
			//Calamity Rarity
			//UnofficialCalamityWhips.calamity.Find<ModRarity>("DarkBlue").Type;

		}

				// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}
		

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("CosmiliteBar").Type, 8);
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("NightmareFuel").Type, 15);
				recipe.AddIngredient(ModContent.ItemType<RighteousDawn.RighteousDawnTwo>());
				recipe.AddIngredient(ItemID.ScytheWhip);
				recipe.AddTile(UnofficialCalamityWhips.calamity.Find<ModTile>("CosmicAnvil"));
				recipe.Register();
			}
		}
	}
}
