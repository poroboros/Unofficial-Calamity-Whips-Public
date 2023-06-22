using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using UnofficialCalamityWhips.Weapons.PostML.ResonateStriker;
using UnofficialCalamityWhips.Weapons.PostML.RighteousDawn;
using UnofficialCalamityWhips.Weapons.PostML.UnrelentingTorment;
using UnofficialCalamityWhips.Rarities;

namespace UnofficialCalamityWhips.Weapons.PostML.Centauri {
	internal class Centauri : ModItem {
		 
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Centauri");
			//Tooltip.SetDefault("The Whip to rule them all\n100 summon tag damage\nCan and will hurl planets\nYour summons will target struck enemies");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			//Item.DefaultToWhip(ModContent.ProjectileType<ExampleWhipProjectile>(), 220, 2, 4);
			float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;

			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = (int)(2000*damageMod);

			Item.knockBack = 2;
			Item.rare = Item.rare = UnofficialCalamityWhips.calamity.Find<ModRarity>("HotPink").Type;

			Item.shoot = ModContent.ProjectileType<CentauriProj>();
			Item.shootSpeed = 12;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.UseSound = SoundID.Item152;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;

			Item.value = Item.sellPrice(gold:40);
			//Item.channel = true;


		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(0));
			Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<CentauriProj>(), damage, knockback, player.whoAmI);
			if (Main.rand.NextBool(2)) {
				Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<Mercury>(), 100, knockback, player.whoAmI);
			}
			if (Main.rand.NextBool(3)) {
				Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<Venus>(), 115, knockback, player.whoAmI);
			}
			if (Main.rand.NextBool(4)) {
				Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<Saturn>(), 200, knockback, player.whoAmI);
			}
			if (Main.rand.NextBool(8)) {
				Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<jupiter>(), 400, knockback, player.whoAmI);
			}
			if (Main.rand.NextBool(5)) {
				Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<Neptune>(), 150, knockback, player.whoAmI);
			}
			if (Main.rand.NextBool(6)) {
				Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<Uranus>(), 300, knockback, player.whoAmI);
			}
			return false;
		}

				// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}
		public override void AddRecipes()
		{
			if (UnofficialCalamityWhips.calamity == null)
				return;
			Recipe recipe = CreateRecipe(1);

			recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("LifeAlloy").Type, 5);
			recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("GalacticaSingularity").Type, 5);
			recipe.AddTile(UnofficialCalamityWhips.calamity.Find<ModTile>("DraedonsForge").Type);
			recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("ShadowspecBar").Type, 5);
			
				recipe.AddIngredient(ModContent.ItemType<ResonateStriker.ResonateStriker>(), 1);
				//recipe.AddIngredient(ModContent.ItemType<RighteousDawnTwo>(), 1);
				recipe.AddIngredient(ModContent.ItemType<DevourersMaw.DevourersMaw>(), 1);
			recipe.AddIngredient(ModContent.ItemType<UnrelentingTorment.UnrelentingTorment>(), 1);
			recipe.Register();
		}

	}
}