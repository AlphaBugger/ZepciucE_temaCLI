using System;
using System.Drawing;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace ProiectCLI
{
    class SimpleWindow : GameWindow
    {
        float rotationSpeed = 90.0f;
        float angle = 0.0f;
        Color[] triangleColors = new Color[3]; // TEMA LAB 3 Cerința 8: Culorile celor 3 vertexuri ale triunghiului
        float[,] triangleVertices = new float[3, 2]; // TEMA LAB 3 Cerința 8: Coordonatele vertexurilor triunghiului

        public SimpleWindow() : base(800, 600)
        {
            VSync = VSyncMode.On;

            // Inițializare culori pentru fiecare vertex
            triangleColors[0] = Color.Blue; // Vertex 1 - Albastru
            triangleColors[1] = Color.Green; // Vertex 2 - Verde
            triangleColors[2] = Color.Red; // Vertex 3 - Roșu
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.Black);
            LoadTriangleData("triangle.txt"); // TEMA LAB 3 Cerința 8: Încărcarea coordonatelor triunghiului dintr-un fișier text
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

            // TEMA LAB 3 Cerința 8: Modificarea culorii fiecărui vertex pe baza tastelor apăsate
            if (keyboard[Key.W]) ChangeColor(0, 10); // Creșterea roșului pentru vertex 1
            if (keyboard[Key.S]) ChangeColor(0, -10); // Scăderea roșului pentru vertex 1
            if (keyboard[Key.A]) ChangeColor(1, 10); // Creșterea verde pentru vertex 2
            if (keyboard[Key.D]) ChangeColor(1, -10); // Scăderea verde pentru vertex 2
            if (keyboard[Key.Up]) ChangeColor(2, 10); // Creșterea albastrului pentru vertex 3
            if (keyboard[Key.Down]) ChangeColor(2, -10); // Scăderea albastrului pentru vertex 3
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Rotate(angle, 0.0f, 0.0f, 1.0f);

            GL.Begin(PrimitiveType.Triangles);
            for (int i = 0; i < 3; i++)
            {
                GL.Color3(triangleColors[i]); // TEMA LAB 3 Cerința 8: Setarea culorii pentru fiecare vertex
                GL.Vertex2(triangleVertices[i, 0], triangleVertices[i, 1]); // TEMA LAB 3 Cerința 8: Desenarea vertexului
            }
            GL.End();

            SwapBuffers();
        }

        private void LoadTriangleData(string filename)
        {
            // TEMA LAB 3 Cerința 8: Citirea coordonatelor triunghiului din fișierul text
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        string line = sr.ReadLine();
                        string[] parts = line.Split(',');
                        triangleVertices[i, 0] = float.Parse(parts[0]);
                        triangleVertices[i, 1] = float.Parse(parts[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading triangle data: {ex.Message}");
            }
        }

        private void ChangeColor(int vertexIndex, int changeAmount)
        {
            // Modificarea valorilor RGB pentru fiecare vertex
            if (vertexIndex == 0) // Vertex 1
            {
                triangleColors[0] = ChangeColorComponent(triangleColors[0], changeAmount, "R");
                Console.WriteLine($"Vertex 1 RGB: {triangleColors[0].R}, {triangleColors[0].G}, {triangleColors[0].B}"); // TEMA LAB 3 Cerința 9: Afișarea valorilor RGB în consolă
            }
            else if (vertexIndex == 1) // Vertex 2
            {
                triangleColors[1] = ChangeColorComponent(triangleColors[1], changeAmount, "G");
                Console.WriteLine($"Vertex 2 RGB: {triangleColors[1].R}, {triangleColors[1].G}, {triangleColors[1].B}"); // TEMA LAB 3 Cerința 9: Afișarea valorilor RGB în consolă
            }
            else if (vertexIndex == 2) // Vertex 3
            {
                triangleColors[2] = ChangeColorComponent(triangleColors[2], changeAmount, "B");
                Console.WriteLine($"Vertex 3 RGB: {triangleColors[2].R}, {triangleColors[2].G}, {triangleColors[2].B}"); // TEMA LAB 3 Cerința 9: Afișarea valorilor RGB în consolă
            }
        }

        private Color ChangeColorComponent(Color color, int changeAmount, string channel)
        {
            int newValue;
            if (channel == "R")
            {
                newValue = color.R + changeAmount;
                return Color.FromArgb(Clamp(newValue), color.G, color.B);
            }
            else if (channel == "G")
            {
                newValue = color.G + changeAmount;
                return Color.FromArgb(color.R, Clamp(newValue), color.B);
            }
            else // B
            {
                newValue = color.B + changeAmount;
                return Color.FromArgb(color.R, color.G, Clamp(newValue));
            }
        }

        private int Clamp(int value)
        {
            // TEMA LAB 3 Cerința 9: Clamping the value between 0 and 255
            if (value < 0) return 0;
            if (value > 255) return 255;
            return value;
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
