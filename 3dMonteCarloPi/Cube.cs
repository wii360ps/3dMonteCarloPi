using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3dMonteCarloPi
{
    public class Cube : DrawableGameComponent
    {
        
        private static Camera camera;
        private Matrix world;
        private Model myModel;

        protected static int cubeCount = 0;

        public Cube(float x, float y, float z, Model model, Game game) : base(game)
        {
            myModel = model;
            world = Matrix.Identity;
            world = Matrix.CreateTranslation(x, y, z);
            camera = Camera.getCamera(GraphicsDevice, game);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public void updateCube(float x, float y, float z, Model model)
        {
            myModel = model;
            world = Matrix.CreateTranslation(x, y, z);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (ModelMesh mesh in myModel.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.AmbientLightColor = new Vector3(1.0f, 0, 0);
                    effect.EnableDefaultLighting();
                    effect.World = world;
                    effect.Projection = camera.Projection;
                    effect.View = camera.View;
                }
                mesh.Draw();
            }
            base.Draw(gameTime);
        }
    }
}
