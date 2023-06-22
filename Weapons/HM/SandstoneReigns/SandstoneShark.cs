using Microsoft.Xna.Framework;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using Terraria.ID;

namespace UnofficialCalamityWhips.Weapons.HM.SandstoneReigns
{
	public class SandstoneShark : ModProjectile
	{

		bool firstTime = true;
		public override void SetStaticDefaults() {
			// Total count animation frames
			Main.projFrames[Projectile.type] = 4;
		}
		public override void SetDefaults() {
			Projectile.width = 118; // The width of projectile hitbox
			Projectile.height = 43; // The height of projectile hitbox

			Projectile.aiStyle = 0; // The ai style of the projectile (0 means custom AI). For more please reference the source code of Terraria
			Projectile.DamageType = DamageClass.Summon; // What type of damage does this projectile affect?
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			//Projectile.light = 1f; // How much light emit around the projectile
			Projectile.tileCollide = false; // Can the projectile collide with tiles?
			Projectile.scale = 1f;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			Projectile.Opacity = .7f;
						Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
		}

		Vector2 target; //The target the shark focuses on

		List<Vector2> _allPositions;

		Vector2 _initialPosition;

		int pointNum = 30;
		int curveIndex;
		Vector2 end;

		float speed = 12f;
		int show = 0;

		private float Timer { //Timer is used for whip draw code 
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}

		public override bool PreAI() {


			NPC k = Main.player[Projectile.owner].GetModPlayer<NewPlayerStats>().whipTarget;

			//gets the current minion target

			if (k != null  && k.active && firstTime) { //if k exists and is attackable, it becomes the target
				
				target = k.Center+ new Vector2(0, -30f); //sets target to slightly above it's center for accuracy

				firstTime = false; //makes sure this code only runs once

				_initialPosition = Projectile.Center;
				_allPositions = new List<Vector2>(pointNum);


				//All the Main.NewText stuff is debug code that you can enable if you want to understand how this works
				//Main.NewText("start X " + _initialPosition.X + " start Y " + _initialPosition.Y, 150, 250, 150);



				//gets all the points the shark follows on a parabola
				_allPositions = PointParabola(target, _initialPosition, pointNum);
				end  = _allPositions[pointNum-1];

				//Main.NewText("mid X " + target.X + " mid Y " + target.Y, 150, 250, 150);

					//Main.NewText("end X " + end.X + " end Y " + end.Y, 150, 250, 150);


				//this sets the projectiles velocity towards the first point on the parabola
				Projectile.velocity = (_allPositions[curveIndex] - Projectile.position).SafeNormalize(Vector2.Zero) * speed;	

			}
			return true;

		}


		private List<Vector2> PointParabola(Vector2 vertex, Vector2 intercept, int num)
		{
			List<Vector2> toReturn = new List<Vector2>(); //Points on parabola
			double p = Math.Abs(vertex.X - intercept.X); //Half width of parabola, vertex - intercept 
			double d = p*2; //full width of parabola
			//Main.NewText("curve width " + p, 150, 250, 150);
			


			//This is the vertex form formula, but solving for A as the unknown
			//It uses the intecept as x1 and y1 to solve for a
			double a = (intercept.Y - vertex.Y) / (Math.Pow((intercept.X - vertex.X),2));

			//Main.NewText("A parabola " + a, 150, 250, 150);
			for (int i = 0; i < num; i++) //get a number of points equal to num
			{
				float div = i/(float)num; //divides the points into equal spaces
				//Main.NewText("percentage " + div, 150, 250, 150);
				double x = (d * div)+intercept.X;//find x of point by


				//vertex form parabola = a(x-h)^2 + k h = x vertex, k = y vertex, a = magnitude
				//solves for the y of the point
				double y = a*Math.Pow((x-vertex.X),2) + vertex.Y;

				//adds the point to the list
				Vector2 point = new Vector2((float)x, (float)y);
				toReturn.Add(point);
			}
			return toReturn;
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

			// If found, change the velocity of the projectile and turn it in the direction of the target
			// Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero



			//This uses a timer to decide when to allow another shark to spawn
			Timer++;

			if (Timer == 50) {
				//Main.player[Projectile.owner].GetModPlayer<NewPlayerStats>().sandstoneSoldier = false;
			}

	
			if (++Projectile.frameCounter >= 5) { //Changes animation frame every 5 ingame frames
				Projectile.frameCounter = 0;
				// Or more compactly Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
				if (++Projectile.frame >= Main.projFrames[Projectile.type]) {
					Projectile.frame = 0;
				}
			}



			//If within 10 units of the target point, move towards the next target
			if (MathF.Abs(Projectile.Center.X - _allPositions[curveIndex].X) < 10f) {
				//Main.NewText("vel X " + Projectile.velocity.X + " vel Y " + Projectile.velocity.Y, 150, 250, 150);
				curveIndex++;
				//Main.NewText("point X " + _allPositions[curveIndex].X + " point Y " + _allPositions[curveIndex].Y, 150, 250, 150);
			
				if (curveIndex >= pointNum) { //prevents index out of bounds
					curveIndex = pointNum - 1;
				}		
				Projectile.velocity = (_allPositions[curveIndex] - Projectile.position).SafeNormalize(Vector2.Zero) * speed;
			}
			
			/*if (show < 10) {
				Main.NewText("pos X " + Projectile.Center.X + " pos Y " + Projectile.Center.Y, 150, 250, 150);
				show++;
			}*/

			Projectile.spriteDirection = Projectile.direction; //flip sprite to meet direction

			//Okay, this is a bit complcated
			//This uses the ? operator to save space, it's basically a fancy if statement
			//It works of the form (logic statement) ? (value if true) : (value if false)
			int yNeg = Projectile.velocity.X <= 0 ? -1 : 1;
			//This statement checks if the Projectile's y velocity is less than or equal to 0
			//If it is it is set to -1, otherwise it is set to 1
			//This is used to properly rotate the shark with it's velocity

			int xNeg = Projectile.velocity.Y >= 0 ? -1 : 1;
			//Same thing for x

			//rotates shark according to velocity
			Projectile.rotation = new Vector2(Math.Abs(Projectile.velocity.X*xNeg),Projectile.velocity.Y*yNeg).ToRotation();


			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.SandstormInABottle ,0, 0, 25, default(Color), .7f);


			//These dusts are debug and will draw the parabola, useful for understanding the code

			/*foreach (Vector2 point in _allPositions) {
				int dust2 = Dust.NewDust(point, 5, 5, DustID.SandstormInABottle ,0, 0, 25, default(Color), .7f);
				Main.dust[dust2].velocity = Vector2.Zero;
			}

			for (int i = 0; i < 8; i++)
			{
				int dust2 = Dust.NewDust(_initialPosition, 5, 5, DustID.RedTorch ,Main.rand.Next(-5,5), Main.rand.Next(-5,5), 25, default(Color), .7f);
				//Main.dust[dust2].velocity = Vector2.Zero;
			}

			for (int i = 0; i < 8; i++)
			{
				int dust2 = Dust.NewDust(end, 5, 5, DustID.GreenTorch ,Main.rand.Next(-5,5), Main.rand.Next(-5,5), 25, default(Color), .7f);
				//Main.dust[dust2].velocity = Vector2.Zero;
			}

			for (int i = 0; i < 8; i++)
			{
				int dust2 = Dust.NewDust(target, 5, 5, DustID.PurpleTorch ,Main.rand.Next(-5,5), Main.rand.Next(-5,5), 25, default(Color), .7f);
				//Main.dust[dust2].velocity = Vector2.Zero;
			}*/

			//releases dust as it flies
			Main.dust[dust].velocity /= 2f;
		}

		public override void Kill(int timeLeft) {
			// This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
			for (int i = 0; i < 8; i++)
			{
				int dust = Dust.NewDust(Projectile.position, 10, 10, DustID.SandstormInABottle ,Main.rand.Next(-5,5), Main.rand.Next(-5,5), 25, default(Color), 1f);
			}
			//releases dust on death
			//Main.player[Projectile.owner].GetModPlayer<NewPlayerStats>().sandstoneSoldier = false;
			//as soon as it dies, another can spawn, this is to prevent softlocks

			//this is not foolproof, and I'll need to rework this to fix some bugs
			
			
		}

	}
}
