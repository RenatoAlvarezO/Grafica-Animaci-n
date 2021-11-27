using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Animacion
{
    public class Game : GameWindow
    {
        private int TextureType = 2;

        public Stage stage;
        private Stage _stage2;
        private int angleCounter = 0;

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState inputKey = Keyboard.GetState();

            base.OnUpdateFrame(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            Color backgroundColor = Color.FromArgb(255, 65, 87, 63);
            GL.ClearColor(backgroundColor);

            int orthoSize = 5;
            GL.Ortho(-orthoSize, orthoSize, -orthoSize, orthoSize, -orthoSize, orthoSize);
            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);

            stage.Draw();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }
    }
}