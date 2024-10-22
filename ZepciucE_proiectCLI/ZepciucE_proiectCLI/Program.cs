using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace ProiectCLI
{
    class SimpleWindow : GameWindow
    {
        float rotationSpeed = 90.0f;
        float angle = 0.0f;

        public SimpleWindow() : base(800, 600)
        {
            VSync = VSyncMode.On;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.Black);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
            float aspectRatio = Width / (float)Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-2, 2, -2, 2, -1, 1);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (keyboard[Key.Escape])
                Exit();

            if (keyboard[Key.Left])
                angle -= rotationSpeed * (float)e.Time;
            if (keyboard[Key.Right])
                angle += rotationSpeed * (float)e.Time;

            if (mouse[MouseButton.Left])
            {
                angle += rotationSpeed * (float)e.Time;
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Rotate(angle, 0.0f, 0.0f, 1.0f);

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.Red);
            GL.Vertex2(-0.5f, -0.5f);
            GL.Vertex2(0.5f, -0.5f);
            GL.Vertex2(0.5f, 0.5f);
            GL.Vertex2(-0.5f, 0.5f);
            GL.End();

            SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (SimpleWindow example = new SimpleWindow())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}


