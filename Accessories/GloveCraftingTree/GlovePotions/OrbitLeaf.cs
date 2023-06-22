using Microsoft.Xna.Framework;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using System;
using Terraria.ID;

namespace UnofficialCalamityWhips.Accessories.GloveCraftingTree.GlovePotions
{
	public class OrbitLeaf : ModProjectile
	{
		bool firstTime = true;
		float distance = 200f;
		int frames = 4;

		int timer = 0;

		public override void SetStaticDefaults() {
			// Total count animation frames
			Main.projFrames[Projectile.type] = 5;
		}
		public override void SetDefaults() {
			Projectile.width = 74; // The width of projectile hitbox
			Projectile.height = 76; // The height of projectile hitbox	

			Projectile.aiStyle = 0; // The ai style of the projectile (0 means custom AI). For more please reference the source code of Terraria
			Projectile.DamageType = DamageClass.Summon; // What type of damage does this projectile affect?
			Projectile.friendly = true; //	 Can the projectile deal damage to enemies?
			Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			//Projectile.light = 1f; // How much light emit around the projectile
			Projectile.tileCollide = false; // Can the projectile collide with tiles?
			Projectile.scale = 1f;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 6000; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			Projectile.Opacity = .7f;
		}

		Vector2 target;

		public override bool PreAI() {
			// NPC k = Main.player[Projectile.owner].GetModPlayer<NewPlayerStats>().whipTarget;
			// if (k != null  && k.active) {
			// 	target = k.Center +  Vector2.Normalize(Projectile.velocity)*5;
			// }

			return true;

		}
		// Custom AI

		public override bool PreDraw(ref Color lightColor) {
			// SpriteEffects helps to flip texture horizontally and vertically
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (Projectile.spriteDirection == -1)
				spriteEffects = SpriteEffects.FlipHorizontally;

			// Getting texture of projectile
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);

			// Calculating frameHeight and current Y pos dependence of frame
			// If texture without animation frameHeight is always texture.Height and startY is always 0
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int startY = frameHeight * Projectile.frame;

			// Get this frame on texture
			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);

			// Alternatively, you can skip defining frameHeight and startY and use this:
			// Rectangle sourceRectangle = texture.Frame(1, Main.projFrames[Projectile.type], frameY: Projectile.frame);

			Vector2 origin = sourceRectangle.Size() / 2f;

			// If image isn't centered or symmetrical you can specify origin of the sprite
			// (0,0) for the upper-left corner
			float offsetX = 20f;
			origin.X = (float)(Projectile.spriteDirection == 1 ? sourceRectangle.Width - offsetX : offsetX);

			// If sprite is vertical
			// float offsetY = 20f;
			// origin.Y = (float)(Projectile.spriteDirection == 1 ? sourceRectangle.Height - offsetY : offsetY);


			// Applying lighting and draw current frame
			Color drawColor = Projectile.GetAlpha(lightColor);
			Main.EntitySpriteDraw(texture,
				Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
				sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);

			// It's important to return false, otherwise we also draw the original texture.
			return false;
		}

		public override void AI() {

			timer++;
			//Main.NewText(MathF.Cos((timer/MathF.PI)/frames)+"", 150, 250, 150);
			if (timer > 360*frames) {
				timer = 0;
			}
			
			// If found, change the velocity of the projectile and turn it in the direction of the target
			// Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero


	
			if (++Projectile.frameCounter >= 5) {
				Projectile.frameCounter = 0;
				// Or more compactly Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
				if (++Projectile.frame >= Main.projFrames[Projectile.type]) {
					Projectile.frame = 0;
				}
			}
			float angle = Projectile.AngleFrom(Projectile.velocity);
			Vector2 p1 = Main.player[Projectile.owner].Center;
			Projectile.Center = p1 + new Vector2(MathF.Cos((timer/MathF.PI)/frames), MathF.Sin((timer/MathF.PI)/frames))*distance;
			Projectile.rotation = (timer/MathF.PI)/frames;
			//Main.NewText(Projectile.rotation+"", 150, 250, 150);
		}

		public override void Kill(int timeLeft) {
			// This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
			// for (int i = 0; i < 8; i++)
			// {
			// 	int dust = Dust.NewDust(Projectile.position, 10, 10, DustID.SandstormInABottle ,Main.rand.Next(-5,5), Main.rand.Next(-5,5), 25, default(Color), 1f);
			// }
			Main.player[Projectile.owner].GetModPlayer<NewPlayerStats>().leafCount--;
			
		}

	}
}
