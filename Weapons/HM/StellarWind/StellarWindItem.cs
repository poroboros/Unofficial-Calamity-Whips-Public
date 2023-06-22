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

namespace UnofficialCalamityWhips.Weapons.HM.StellarWind {
    internal class StellarWindItem : ModItem{

		float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Stellar Wind");
			//Tooltip.SetDefault("It floats away if you let go\n20% crit chance\nYour summons will target struck enemies");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

				// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}

		public override void SetDefaults()
		{
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			//Item.DefaultToWhip(ModContent.ProjectileType<ExampleWhipProjectile>(), 220, 2, 4);

			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = (int)(69 * damageMod);

			Item.knockBack = 2;
			Item.rare = ItemRarityID.Lime;

			Item.shoot = ModContent.ProjectileType<StellarWindProj>();
			Item.shootSpeed = 12;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.UseSound = SoundID.Item152;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;

			Item.value = Item.sellPrice(gold:12);
		}
		public override void AddRecipes()
		{
			if (UnofficialCalamityWhips.calamity == null)
				return;
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("AureusCell").Type, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("Stardust").Type, 15);
			recipe.Register();
		}
	}
}
