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

namespace UnofficialCalamityWhips.Weapons.HM.DaedalusWhip {
	internal class DaedalusWhipItem : ModItem {
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Daedalus Whip");
			//Tooltip.SetDefault("cold\n11 summon tag damage\nYour summons will target struck enemies");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			

			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = 48;

			Item.knockBack = 1;
			Item.rare = ItemRarityID.Pink;


			Item.shoot = ModContent.ProjectileType<DaedalusWhipProj>();

			Item.shootSpeed = 6;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.UseSound = SoundID.Item152;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;

			Item.value =Item.sellPrice(gold:7, silver:20);
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
			recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("CryonicBar").Type, 12);
			recipe.AddTile(TileID.MythrilAnvil);

			recipe.Register();

	    }
}	}
