using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace _3DObjects
{
    public class Rasterizer
    {
        public Vector3[] ZBuffer { get; protected set; }
        public int[] VisibleIndexes {  get; protected set; }
        //public Color[] ColorIndexes { get; protected set; }
        public int VisibleCount { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Camera Camera {  get; protected set; }

        public delegate void RasterizeDelegate(Primitive primitive  , PictureBox pictureBox);

        public Rasterizer(Camera camera)
        {
            Width = camera.ScreenWidth;
            Height = camera.ScreenHeight;
            Camera = camera;
        }

        public void DrawObject(Primitive primitive, PictureBox pictureBox)
        {
            pictureBox.Image = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(pictureBox.Image);

            for (int i = 0; i < primitive.VerticesIndexes.Length; i += 3)
            {
                // индексы вершин полигона
                var i1 = primitive.VerticesIndexes[i];
                var i2 = primitive.VerticesIndexes[i + 1];
                var i3 = primitive.VerticesIndexes[i + 2];
                // вершины полигона
                var v1 = primitive.GlobalVertices[i1 - 1];
                var v2 = primitive.GlobalVertices[i2 - 1];
                var v3 = primitive.GlobalVertices[i3 - 1];
                // рисуем полигон
                //проекции вершин
                Vector2 p1 = Camera.ScreenProection(v1);
                Vector2 p2 = Camera.ScreenProection(v2);
                Vector2 p3 = Camera.ScreenProection(v3);

                //рисуем полигон        
                PointF point1 = new(p1.X, p1.Y);
                PointF point2 = new(p2.X, p2.Y);
                PointF point3 = new(p3.X, p3.Y);

                graphics.DrawLine(new Pen(Color.Black), point1, point2);
                graphics.DrawLine(new Pen(Color.Black), point2, point3);
                graphics.DrawLine(new Pen(Color.Black), point1, point3);
            }
        }

        public void RasterizeRoberts(Primitive primitive, PictureBox pictureBox)
        {
            pictureBox.Image = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(pictureBox.Image);

            foreach (Polygon polygon in primitive.GetPolygons())
            {
                // вершины полигона
                Vector3 v1 = polygon.v1;
                Vector3 v2 = polygon.v2;
                Vector3 v3 = polygon.v3;
                Vector3 w = primitive.Pivot.Center;

                float v1x = v1.X - v2.X;
                float v2x = v3.X - v2.X;
                float v1y = v1.Y - v2.Y;
                float v2y = v3.Y - v2.Y;
                float v1z = v1.Z - v2.Z;
                float v2z = v3.Z - v2.Z;

                float A = v1y * v2z - v2y * v1z;
                float B = v1z * v2x - v2z * v1x;
                float C = v1x * v2y - v2x * v1y;
                float D = -(A * v1.X + B * v1.Y + C * v1.Z);

                float m = -Math.Sign(A * w.X + B * w.Y + C * w.Z + D);
                A *= m;
                B *= m;
                C *= m;
                D *= m;

                if (A * Camera.Pivot.Center.X + B * Camera.Pivot.Center.Y + C * Camera.Pivot.Center.Z + D > 0)
                {
                    Vector2 pv1 = Camera.ScreenProection(v1);
                    Vector2 pv2 = Camera.ScreenProection(v2);
                    Vector2 pv3 = Camera.ScreenProection(v3);

                    PointF point1 = new(pv1.X, pv1.Y);
                    PointF point2 = new(pv2.X, pv2.Y);
                    PointF point3 = new(pv3.X, pv3.Y);

                    graphics.DrawLine(new Pen(Color.Black), point1, point2);
                    graphics.DrawLine(new Pen(Color.Black), point2, point3);
                    graphics.DrawLine(new Pen(Color.Black), point1, point3);
                }
            }
        }

        public void RasterizeZBuffer(Primitive primitive, PictureBox pictureBox)
        {
            pictureBox.Image = new Bitmap(Width, Height);
            VisibleIndexes = new int[Width * Height];
            //ColorIndexes = new Color[Width * Height];
            ZBuffer = new Vector3[Width * Height];
            VisibleCount = 0;

            //int xRGB = 175;
            //int yRGB = 145;
            //int zRGB = 125;         
            
            foreach (Polygon polygon in primitive.GetPolygons())
            {
                //if(xRGB < 0 || yRGB < 0 || zRGB < 0)
                //{
                //    xRGB = 175;
                //    yRGB = 145;
                //    xRGB = 125;
                //}
                //Color color = Color.FromArgb(zRGB, xRGB, yRGB); 
                ComputePolygon(polygon.v1, polygon.v2, polygon.v3, new Color());
                //xRGB -= 4;
                //yRGB -= 4;
                //zRGB -= 4;
            }

            for (int i = 0; i < VisibleCount; i++)
            {
                Vector3 vec = ZBuffer[VisibleIndexes[i]];
                Vector2 proection = Camera.ScreenProection(vec);
                ((Bitmap)pictureBox.Image).SetPixel(Convert.ToInt32(proection.X), Convert.ToInt32(proection.Y), Color.DarkGray);//ColorIndexes[VisibleIndexes[i];
            }            
        }

        private void ComputePolygon(Vector3 v1, Vector3 v2, Vector3 v3, Color color)
        {
            //находим проекцию полигона
            var v1p = Camera.ScreenProection(v1);
            var v2p = Camera.ScreenProection(v2);
            var v3p = Camera.ScreenProection(v3);

            //упорядочиваем точки по x - координате
            //Заметьте, также меняем исходные точки - они должны соответствовать проекциям
            if (v1p.X > v2p.X) { (v1p, v2p) = (v2p, v1p); (v1, v2) = (v2, v1); }
            if (v2p.X > v3p.X) { (v2p, v3p) = (v3p, v2p); (v2, v3) = (v3, v2); }
            if (v1p.X > v2p.X) { (v1p, v2p) = (v2p, v1p); (v1, v2) = (v2, v1); }

            Vector3 deltaUp, deltaDown;
            float deltaUpY, deltaDownY;

            //считаем количество шагов для построения линии алгоритмом Брезенхема
            int x12 = Math.Max((int)v2p.X - (int)v1p.X, 1);
            int x13 = Math.Max((int)v3p.X - (int)v1p.X, 1);

            //теперь помимо проекций будем интерполировать и исходные точки
            float dy12 = (v2p.Y - v1p.Y) / x12; Vector3 dr12 = (v2 - v1) / x12;
            float dy13 = (v3p.Y - v1p.Y) / x13; Vector3 dr13 = (v3 - v1) / x13;

            if (dy12 > dy13) { deltaUp = dr12; deltaDown = dr13; deltaUpY = dy12; deltaDownY = dy13; }
            else { deltaUp = dr13; deltaDown = dr12; deltaUpY = dy13; deltaDownY = dy12; }

            ComputePolyPart(v1, deltaUp, deltaDown, x12, 1, v1p, deltaUpY, deltaDownY, color);

            //аналогично обрабатываем вторую часть треугольника
            int x32 = Math.Max(Math.Abs((int)v2p.X - (int)v3p.X), 1);
            int x31 = Math.Max(Math.Abs((int)v1p.X - (int)v3p.X), 1);

            float dy32 = (v2p.Y - v3p.Y) / x32; Vector3 dr32 = (v2 - v3) / x32; 
            float dy31 = (v1p.Y - v3p.Y) / x31; Vector3 dr31 = (v1 - v3) / x31; 

            if (dy32 > dy31) { deltaUp = dr32; deltaDown = dr31; deltaUpY = dy32; deltaDownY = dy31; }
            else { deltaUp = dr31; deltaDown = dr32; deltaUpY = dy31; deltaDownY = dy32; }

            ComputePolyPart(v3, deltaUp, deltaDown, x32, -1, v3p, deltaUpY, deltaDownY, color);
        }

        private void ComputePolyPart(Vector3 start, Vector3 deltaUp, Vector3 deltaDown,
            int xSteps, int xDir, Vector2 pixelStart, float deltaUpPixel, float deltaDownPixel, Color color)
        {
            int pixelStartX = (int)pixelStart.X;

            Vector3 up = start - deltaUp, 
                    down = start - deltaDown;
            float pixelUp = pixelStart.Y - deltaUpPixel, 
                    pixelDown = pixelStart.Y - deltaDownPixel;

            for (int i = 0; i <= xSteps; i++)
            {
                up += deltaUp; pixelUp += deltaUpPixel;
                down += deltaDown; pixelDown += deltaDownPixel;
                int steps = ((int)pixelUp - (int)pixelDown);
                Vector3 delta = steps == 0 ? Vector3.Zero : (up - down) / steps;
                Vector3 position = down;

                for (int g = 0; g <= steps; g++)
                {
                    position += delta;
                    var proection = new Point(pixelStartX + i * xDir, (int)pixelDown + g);
                    int index = proection.Y * Width + proection.X;
                    //проверка на глубину
                    if (index > 0 && index < Width * Height)
                    {
                        if (ZBuffer[index].Z == 0)
                        {
                            ZBuffer[index] = position;
                            VisibleIndexes[VisibleCount] = index;
                            //ColorIndexes[index] = color;
                            ++VisibleCount;
                        }
                        else if (ZBuffer[index].Z > position.Z)
                        {
                            ZBuffer[index] = position;
                            //ColorIndexes[index] = color;
                        }
                    }

                }
            }
        }      
    }
}
