using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.Localization;
using UnofficialCalamityWhips.Rarities;
//using CalamityWhips.Hm.FeralVineLash;

namespace UnofficialCalamityWhips.Weapons.PostML.BlossomsBlessing {
    internal class BlossomsBlessingItem : ModItem{
		 
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Blossoms Blessing");
			//Tooltip.SetDefault("Give you The Blossoms Blessing Buff\n25% chance to shoot a spore\n36 summon tag damage\nYour summons will target struck enemies");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			//Item.DefaultToWhip(ModContent.ProjectileType<ExampleWhipProjectile>(), 220, 2, 4);

			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = (int)(250 * damageMod);

			Item.knockBack = 1;
			Item.rare = UnofficialCalamityWhips.calamity.Find<ModRarity>("Turquoise").Type;
			Item.sellPrice(gold:24);

			Item.shoot = ModContent.ProjectileType<BlossomsBlessingProj>();
			
			
			Item.shootSpeed = 12;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 34;
			Item.useAnimation = 34;
			Item.UseSound = SoundID.Item152;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;

			Item.value = Item.sellPrice(gold:24);
		}
        public override bool? UseItem(Player player)
        {
			player.AddBuff(ModContent.BuffType<BlossomsBlessingBuff>(), 240);
            return base.UseItem(player);
        }

		public override bool MeleePrefix() {
			return true;
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(0));
			Vector2 newVelocity2 = velocity.RotatedByRandom(MathHelper.ToRadians(0));
			newVelocity *= 2f;			
			Projectile.NewProjectileDirect(source, position, newVelocity2, ModContent.ProjectileType<BlossomsBlessingProj>(), damage, knockback, player.whoAmI);
			if (Main.rand.NextBool(4)) {
				if (Main.rand.NextBool(2)) {
					Projectile.NewProjectileDirect(source, position, newVelocity, ProjectileID.SporeTrap2, damage, knockback, player.whoAmI);
				} else {
					Projectile.NewProjectileDirect(source, position, newVelocity, ProjectileID.SporeTrap, damage, knockback, player.whoAmI);
				}
			}
			return false;
        }



        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
		{
			//Mod CalamityMod = UnofficialCalamityWhips.calamity;
			if (UnofficialCalamityWhips.calamity == null)
				return;
			Recipe recipe = CreateRecipe(1);
			//recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("LifeAlloy").Type, 10);
			recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("UelibloomBar").Type, 6);
			recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("PerennialBar").Type, 5);
			
			
				recipe.AddIngredient(ItemID.ThornWhip);
				//recipe.AddIngredient(ItemID.LifeFruit, 5);
				recipe.AddTile(TileID.LunarCraftingStation);				
				

			

			recipe.Register();
		}
	}
}
