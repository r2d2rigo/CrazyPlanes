// Copyright (c) 2014 Rodrigo 'r2d2rigo' Diaz
// Textures Copyright (c) Kenney - http://kenney.nl/
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Content;
using SharpDX.Toolkit.Graphics;

namespace CrazyPlanes
{
    internal class CrazyPlanesGame : Game
    {
        private GraphicsDeviceManager deviceManager;
        private Texture2D planeTexture;
        private SpriteBatch spriteBatch;

        public CrazyPlanesGame()
        {
            deviceManager = new GraphicsDeviceManager(this);
            deviceManager.PreferredBackBufferWidth = 480;
            deviceManager.PreferredBackBufferHeight = 800;

            this.Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.planeTexture = this.Content.Load<Texture2D>("Plane");

            base.LoadContent();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Vector2 planePosition = new Vector2(
                (this.GraphicsDevice.BackBuffer.Width / 2.0f) - (this.planeTexture.Width / 2.0f),
                (this.GraphicsDevice.BackBuffer.Height / 2.0f) - (this.planeTexture.Height / 2.0f));

            this.spriteBatch.Begin(SpriteSortMode.Deferred, this.GraphicsDevice.BlendStates.NonPremultiplied);
            this.spriteBatch.Draw(this.planeTexture, planePosition, Color.White);
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
