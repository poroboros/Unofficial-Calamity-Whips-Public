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

namespace UnofficialCalamityWhips.Weapons.PreHM.CoralCrusher{
    internal class CoralCrusherItem : ModItem{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Coral Crusher");
			//Tooltip.SetDefault("Minions summon Coral\n6 summon tag damage\nYour summons will target struck enemies");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			//Item.DefaultToWhip(ModContent.ProjectileType<ExampleWhipProjectile>(), 220, 2, 4);
			float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;

			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = (int)(13*damageMod);

			Item.knockBack = 1;
			Item.rare = ItemRarityID.Green;


			Item.shoot = ModContent.ProjectileType<CoralCrusherProj>();

			Item.shootSpeed = 5;

			Item.value = Item.buyPrice(gold:2);

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.UseSound = SoundID.Item152;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
		}

		public override bool MeleePrefix() {
			return true;
		}
	}
}
