using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace UnofficialCalamityWhips.Armor
{
    public class HeadpatLayer : PlayerDrawLayer
    {
        private int frame;
        private int frameCounter;

        private int frameSpeed = 12;
        private int maxFrames = 5; //make sure to change this to however many frames are in your accessory

        public override bool IsHeadLayer => true; // you'll wanna include this in yours since it's on the player's head
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            bool hasbigflag = false; // this is where you'll put your player bools for whether or not to draw the accessory, i didn't use this here so idk if its needed but just to be safe
            if (drawInfo.drawPlayer.GetModPlayer<NewPlayerStats>().hasHeadpat)
            {
                hasbigflag = true; 
            }
            return hasbigflag;
        }
        public override Position GetDefaultPosition() => new BeforeParent(PlayerDrawLayers.FaceAcc);

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            Player player = Main.LocalPlayer;
            NewPlayerStats modPlayer = drawPlayer.GetModPlayer<NewPlayerStats>();
            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            int dyeShader = drawPlayer.dye?[0].dye ?? 0;

            Vector2 headPosition = drawInfo.helmetOffset +
                new Vector2(
                    (int)(drawInfo.Position.X - (float)(drawInfo.drawPlayer.bodyFrame.Width / 2) + (float)(drawInfo.drawPlayer.width / 2)),
                    (int)(drawInfo.Position.Y + (float)drawInfo.drawPlayer.height - (float)drawInfo.drawPlayer.bodyFrame.Height))
                + drawInfo.drawPlayer.headPosition
                + drawInfo.headVect;
            int secondyoffset;
            var bodFrame = drawPlayer.bodyFrame;
            if (bodFrame.Y == bodFrame.Height * 7 || bodFrame.Y == bodFrame.Height * 8 || bodFrame.Y == bodFrame.Height * 9
                || bodFrame.Y == bodFrame.Height * 14 || bodFrame.Y == bodFrame.Height * 15 || bodFrame.Y == bodFrame.Height * 16)
                secondyoffset = 2;
            else
                secondyoffset = 0;
            headPosition -= Main.screenPosition;
           
            if (modPlayer.hasHeadpat) // player bool here too
            {
                frameCounter++;
                if (drawInfo.drawPlayer.velocity != Vector2.Zero) {
                    frameSpeed = 8;
                }
                else {
                    frameSpeed = 12;
                }
                if (frameCounter >= frameSpeed)
                {
                    frameCounter = 0;
                    frame++;
                    if (frame >= maxFrames)
                    {
                        frame = 0; 
                    }
                }
                Texture2D texture = ModContent.Request<Texture2D>("UnofficialCalamityWhips/Armor/DivineHeadpat").Value; // change this to your texture path
                Rectangle yFrame = texture.Frame(1, maxFrames, 0, frame);
                Vector2 pos = new Vector2(headPosition.X, headPosition.Y - secondyoffset - 7); // the -20 here is the horizontal offset that you'll be changing, the -12 is the vertical. 
                DrawData dat = new DrawData(texture, pos, yFrame, drawInfo.colorArmorBody, 0f, new Vector2(texture.Width / 2f, texture.Height / 2f / maxFrames), 1, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 1);
                dat.shader = dyeShader;
                drawInfo.DrawDataCache.Add(dat);
            }
            else
            {
                frame = 0;
                frameCounter = 0;
            }
            
        }
    }
}
