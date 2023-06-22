
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace UnofficialCalamityWhips.Accessories.DesertAccessory
{
	public class CrystalLodestone : ModItem
	{
		public override void SetStaticDefaults() {

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			//Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 13));
		}

		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(gold:4, silver:80);
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<BoulderItemPlayer>().hasCrystal = true;
		}

		public override void AddRecipes() {
			if (UnofficialCalamityWhips.calamity != null) {
			}

		}
	}

	public class BoulderItemPlayer : ModPlayer {
		public bool hasCrystal;

		int cooldown = 200;
		int timer = 0;
		bool startCount = false;

		public override void ResetEffects() {
			hasCrystal = false;
		}

		public override void PreUpdate() {
			if (startCount) {
				timer--;
				if (timer <= 0) {
					startCount = false;
				}
			}
		}

		public override bool Shoot(Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {

			if (hasCrystal && item.DamageType == DamageClass.SummonMeleeSpeed && !startCount) {
				int boulderDam = item.damage;
				boulderDam = boulderDam < 200 ? boulderDam : 200;
				Projectile.NewProjectile(source, Player.position, Vector2.Normalize(velocity)*8, ModContent.ProjectileType<BoulderProj>(), boulderDam, 0, Player.whoAmI);
				timer = cooldown;
				startCount = true;
			}
			return true;
		}
	}

	
}