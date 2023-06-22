using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnofficialCalamityWhips.Weapons.PreHM.FungalFlail {
    internal class FungalFlailItem : ModItem{
		
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Fungal Flail");
			//Tooltip.SetDefault("Not edible\n8 summon tag damage\nYour summons will target struck enemies");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			//Item.DefaultToWhip(ModContent.ProjectileType<ExampleWhipProjectile>(), 220, 2, 4);
			float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;
			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = (int)(22*damageMod);

			Item.knockBack = 2;
			Item.rare = ItemRarityID.Green;

			Item.shoot = ModContent.ProjectileType<FungalFlailProj>();
			Item.shootSpeed = 5;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 30;
			Item.useAnimation = 30;
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

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(0));
			Vector2 newVelocity2 = velocity.RotatedByRandom(MathHelper.ToRadians(5));
			newVelocity2 *= 20f;
			Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<FungalFlailProj>(), damage, knockback, player.whoAmI);
			
			return false;
        }

		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("FungalClump"), 1);
				recipe.AddIngredient(ItemID.GlowingMushroom, 10);
				recipe.AddIngredient(ItemID.MushroomGrassSeeds, 5);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
		}

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.

    }
}
