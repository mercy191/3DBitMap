using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DBitMap
{
    public class Horizon
    {
        public Vector3[,] Points { get; set; }
        public Bitmap Bitmap { get; set; }
        

        public Horizon(BmpFile bmpFile, PictureBox pictureBox) 
        {
            Bitmap = bmpFile.Bitmap;
            Points = new Vector3[Bitmap.Width, Bitmap.Height];               
            SetIntencesBitmap();
        }

        private void SetIntencesBitmap()
        {
            for (int x = 0; x < Bitmap.Width; x++)
            {
                for (int z = 0; z < Bitmap.Height; z++)
                {
                    int intences = (Bitmap.GetPixel(x, z).R + Bitmap.GetPixel(x, z).G + Bitmap.GetPixel(x, z).B) / 3;
                    Points[x, z].X = x - Bitmap.Width / 2;
                    Points[x, z].Y = intences - Bitmap.Height / 2;
                    Points[x, z].Z = z - Bitmap.Height / 2;
                }
            }         
        }

        public void DrawSurface(PictureBox pictureBox)
        {
            Bitmap newBitmap = new Bitmap(Bitmap.Width * 2, Bitmap.Height * 2);

            int[] YMax = new int[newBitmap.Width];
            int[] YMin = new int[newBitmap.Width];
            for (int i = 0; i < YMax.Length; i++)
                YMin[i] = YMax[i] = int.MaxValue;

            int rows = Points.GetUpperBound(0) + 1;
            int columns = Points.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    int x = Convert.ToInt32(Points[i, j].X) + newBitmap.Width / 2;
                    int y = 255 - (Convert.ToInt32(Points[i, j].Y) + newBitmap.Height / 2);
                    if (YMin[x] == int.MaxValue)
                    {
                        newBitmap.SetPixel(x, Bitmap.Height - y - 1, Color.Black);
                        YMin[x] = YMax[x] = y;
                    }
                    else if (y < YMin[x])
                    {
                        newBitmap.SetPixel(x, Bitmap.Height - y - 1, Color.Red);
                        YMin[x] = y;
                    }
                    else if (y > YMax[x])
                    {
                        newBitmap.SetPixel(x, Bitmap.Height - y - 1, Color.Black);
                        YMax[x] = y;
                    }
                }               
            }
            pictureBox.Image = newBitmap;
        }
        
        public void RotateSurface(float angle, string axis)
        {
            if (axis == "x")
                RotateSurfaceAlongX(angle);
            else if (axis == "y")
                RotateSurfaceAlongY(angle);
            else if (axis == "z")
                RotateSurfaceAlongZ(angle);
        }

        private void RotateSurfaceAlongX(float angle)
        {
            Matrix4x4 Rx = Matrix4x4.CreateRotationX(angle);
            int rows = Points.GetUpperBound(0) + 1;
            int columns = Points.Length / rows;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    Points[i, j] = Vector3.Transform(Points[i, j], Rx);
                }
                    
        }

        private void RotateSurfaceAlongY(float angle)
        {
            Matrix4x4 Ry = Matrix4x4.CreateRotationY(angle);
            int rows = Points.GetUpperBound(0) + 1;
            int columns = Points.Length / rows;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    Points[i, j] = Vector3.Transform(Points[i, j], Ry);
                }
                    
        }

        private void RotateSurfaceAlongZ(float angle)
        {
            Matrix4x4 Rz = Matrix4x4.CreateRotationZ(angle);
            int rows = Points.GetUpperBound(0) + 1;
            int columns = Points.Length / rows;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    Points[i, j] = Vector3.Transform(Points[i, j], Rz);
                }

        }

    }
}
