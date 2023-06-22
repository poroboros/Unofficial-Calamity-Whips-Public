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
using UnofficialCalamityWhips.Rarities;

namespace UnofficialCalamityWhips.Weapons.HM.SirensSerenity {
    internal class SirensSerenityItem : ModItem{

		float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Siren's Serenity");
			//Tooltip.SetDefault("The companionship between the Leviathan and Anahita inspires you and your minions\n18 summon tag damage\nYour summons will target struck enemies\nYour minions will occasionally drop orbs that will grant a buff when picked up\nItem idea provided by CharlieTheFatCat");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{



			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = (int)(89*damageMod);

			Item.knockBack = 3;
			Item.rare = ModContent.RarityType<SkyBlue>();


			Item.shoot = ModContent.ProjectileType<SirensSerenityProj>();

			Item.shootSpeed = 6;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.UseSound = SoundID.Item152;
			Item.noMelee = true;
			Item.value = Item.sellPrice(gold:9, silver:60);	
			Item.noUseGraphic = true;
			Item.autoReuse = true;
		}
		
	}
}
