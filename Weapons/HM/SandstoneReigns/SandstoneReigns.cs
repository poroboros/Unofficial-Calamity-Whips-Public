using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnofficialCalamityWhips.Weapons.HM.SandstoneReigns
{
	public class SandstoneReigns : ModItem
	{
		float damageMod = ModContent.GetInstance<UnofficialCalamityWhipsConfig>().WhipDamageModifier;
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			//Tooltip.SetDefault("Your minions will summon a charging sandstone soldier to tag team.\n'Let them know what you have seen today'");
		
			//Try to avoid setting name or tooltip in the code, but instead in the translation file
			//This makes it easier for other people to translate
		}	

		public override void SetDefaults() {
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			Item.DefaultToWhip(ModContent.ProjectileType<SandstoneReignsProjectile>(), (int)(100*damageMod), 3, 8); 
			//Item.useTime = Item.useTime;
			Item.autoReuse = true;

			//I will explain more indepth item fields in a different item file

			//Item.shootSpeed = 4;
			Item.value = Item.sellPrice(gold:12); //Make sure to use sell price corresponding to calamity rarity on the wiki	
			Item.rare = ItemRarityID.Lime;


		}

		// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) { //This checks to make sure calamity is loaded
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(UnofficialCalamityWhips.calamity.Find<ModItem>("GrandScale").Type);
				//calamity.Find lets you get a calamity item by Internal Name (Use helpful hotkeys to find them)
				//This will throw an error if the item doesn't exist or the name is wrong
				//You can use try find if don't want errors, but the errors make it easier to fix IMO


				//recipe.AddIngredient(ItemID.Emerald, 8); //These are vanilla materials
				recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
				recipe.AddIngredient(ItemID.BoneWhip);
				//recipe.AddIngredient(ItemID.Sandstone, 50);

				recipe.AddTile(TileID.MythrilAnvil); //Sets the crafting station

				recipe.Register(); //Saves recipes

			}
		}
	}
}
