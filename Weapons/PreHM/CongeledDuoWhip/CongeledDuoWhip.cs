using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace UnofficialCalamityWhips.Weapons.PreHM.CongeledDuoWhip
{

	public class CongeledDuoWhip: ModItem
	{
		bool alt = false;
		float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			//Tooltip.SetDefault("7 summon tag damage\nYour summons will focus struck enemies\nShoots two slimy whips in opposite directions");
		}

				// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}

		public override void SetDefaults() {
			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = (int)(16*damageMod);
			Item.knockBack = 8;

			Item.shoot = ModContent.ProjectileType<CongeledCrimsonProjectile>();
			Item.shootSpeed = 4;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.UseSound = SoundID.Item56;
			Item.autoReuse = true;
			//Item.channel = true; // This is used for the charging functionality. Remove it if your whip shouldn't be chargeable.
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.value= Item.sellPrice(gold:2, silver:40);
			Item.rare = ItemRarityID.LightRed;


		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("PurifiedGel").Type, 18);
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("BlightedGel").Type, 18);
				recipe.AddTile(UnofficialCalamityWhips.calamity.Find<ModTile>("StaticRefiner"));
				recipe.Register();
			}

		}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
		if (!alt) {
			//Item.channel = false;
			Vector2 normal = Vector2.Normalize(velocity);
			Vector2 perp1 = Vector2.Multiply(new Vector2(-normal.Y, normal.X), 2);
			Vector2 newVelocity = velocity + perp1;
			
			
			Projectile.NewProjectile(source,	 position, newVelocity, ModContent.ProjectileType<SludgeJudgeProj1>(), damage, knockback, player.whoAmI);
			return true;
		}
		//Item.channel = true;
		//Item.autoReuse = true;
		Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<CongeledCorruptProjectile>(), damage, knockback, player.whoAmI);
		return true; // return false to stop vanilla from calling Projectile.NewProjectile.
		}
	public override bool AltFunctionUse(Player player) {
		//alt = true;
		return true;
	}

		public override bool CanUseItem(Player player)
		{

			if (player.altFunctionUse == 2)//Sets what happens on right click(special ability)
			{
				Item.damage = (int)(25*damageMod);
				Item.shoot = ModContent.ProjectileType<CongeledCrimsonProjectile>();
				alt = true;
			}
			else {
				Item.damage = (int)(16*damageMod);
				Item.shoot = ModContent.ProjectileType<SludgeJudgeProj>();
				alt = false;
			}

			return true;
		}
	}

}
