using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnofficialCalamityWhips.Weapons.PreHM.SkySplitter {
    internal class SkySplitterItem : ModItem{

		float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;
		 
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Aerialash");
			//Tooltip.SetDefault("'Its strangly light'\n5 summon tag damage\nYour summons will target struck enemies");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			//Item.DefaultToWhip(ModContent.ProjectileType<ExampleWhipProjectile>(), 220, 2, 4);

			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = (int)(19 * damageMod);

			Item.knockBack = 2;
			Item.rare = ItemRarityID.Orange;

			Item.shoot = ModContent.ProjectileType<SkySplitterProj>();
			Item.shootSpeed = 6;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.UseSound = SoundID.Item152;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(silver:80);


		}

				// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			if (UnofficialCalamityWhips.calamity == null)
				return;
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("AerialiteBar").Type, 6);
			recipe.AddTile(TileID.SkyMill);
			recipe.AddIngredient(ItemID.SunplateBlock, 3);
			//recipe.AddIngredient(ItemID.Cloud, 3);
			recipe.Register();
		}
	}
}
