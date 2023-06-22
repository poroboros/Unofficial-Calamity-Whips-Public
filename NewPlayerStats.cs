
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace UnofficialCalamityWhips
{
	public class NewPlayerStats : ModPlayer
	{
        public NPC whipTarget;
		public int leafCount = 0;

		public int healingOrbCount;

		public bool hasHeadpat;

		public int fungalCooldown = 0;
		public int sandstoneSoldier = 0;
		public int handCooldown = 0;
		public int righteousCooldown = 0;
		public int prismCooldown = 0;
		public int sulphuricCooldown = 0;
		public int brimstoneCooldown = 0;
		public int daedalusCooldown = 0;
		public int staticCooldown = 0;
		public int sirenCooldown = 0;

		public override void UpdateBadLifeRegen() {
			fungalCooldown = fungalCooldown > 0 ? fungalCooldown - 1 : 0;
			handCooldown = handCooldown > 0 ? handCooldown - 1 : 0;
			sandstoneSoldier = sandstoneSoldier > 0 ? sandstoneSoldier - 1 : 0;
            righteousCooldown = righteousCooldown > 0 ? righteousCooldown - 1 : 0;
            prismCooldown = prismCooldown > 0 ? prismCooldown - 1 : 0;
            sulphuricCooldown = sulphuricCooldown > 0 ? sulphuricCooldown - 1 : 0;
            brimstoneCooldown = brimstoneCooldown > 0 ? brimstoneCooldown - 1 : 0;
            daedalusCooldown = daedalusCooldown > 0 ? daedalusCooldown - 1 : 0;
            staticCooldown = staticCooldown > 0 ? staticCooldown - 1 : 0;
			sirenCooldown = sirenCooldown > -5 ? sirenCooldown - 1 : -5;
            //Main.NewText(handCooldown);
        }

		
		public override void ResetEffects() {
			hasHeadpat = false;
		}
		
	}
}