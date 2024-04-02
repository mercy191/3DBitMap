using System.Numerics;
using System.Media;
using System.Windows.Forms;
using System.Drawing;
using _3DBitMap;

namespace _3DObjects
{
    public partial class Form1 : Form
    {
        Horizon horizon;
        BmpFile bmpFile;

        ObjFile objFile;
        Shape shape;
        Camera camera;
        Rasterizer rasterizer;
        Rasterizer.RasterizeDelegate rasterizeDelegate;

        public Form1()
        {
            InitializeComponent();
        }
        private void OpenButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new()
            { };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                bmpFile = new BmpFile(dialog.FileName);
                horizon = new Horizon(bmpFile, pictureBox1);
                horizon.DrawSurface(pictureBox1);
            }
        }

        private void HorizonXRotateButton_Click(object sender, EventArgs e)
        {
            horizon.RotateSurface(Convert.ToSingle(Math.PI / 18), "x");
            horizon.DrawSurface(pictureBox1);
        }

        private void HorizonYRotateButton_Click(object sender, EventArgs e)
        {
            horizon.RotateSurface(Convert.ToSingle(Math.PI / 18), "y");
            horizon.DrawSurface(pictureBox1);
        }

        private void HorizonZRotateButton_Click(object sender, EventArgs e)
        {
            horizon.RotateSurface(Convert.ToSingle(Math.PI / 18), "z");
            horizon.DrawSurface(pictureBox1);
        }

        private void OpenButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new()
            { };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                objFile = new ObjFile(dialog.FileName);
                shape = new Shape(new Vector3(0, 0, 0), objFile);
                camera = new Camera(new Vector3(0, 0, -7), 5, Convert.ToSingle(Math.PI / 2), pictureBox1.Width, pictureBox1.Height);
                rasterizer = new Rasterizer(camera);

                rasterizeDelegate = rasterizer.DrawObject;
                rasterizeDelegate(shape, pictureBox1);
            }
        }

        private void RobertsButton_Click(object sender, EventArgs e)
        {
            rasterizeDelegate = rasterizer.RasterizeRoberts;
            rasterizeDelegate(shape, pictureBox1);
        }

        private void ZbufferButton_Click(object sender, EventArgs e)
        {
            rasterizeDelegate = rasterizer.RasterizeZBuffer;
            rasterizeDelegate(shape, pictureBox1);
        }

        private void ScaleUpButoon_Click(object sender, EventArgs e)
        {
            shape.Scale(2.0f);
            rasterizeDelegate(shape, pictureBox1);
        }

        private void ScaleDownButoon_Click(object sender, EventArgs e)
        {
            shape.Scale(0.5f);
            rasterizeDelegate(shape, pictureBox1);
        }

        private void LeftMoveButton_Click(object sender, EventArgs e)
        {
            shape.Move(new Vector3(-1, 0, 0));
            rasterizeDelegate(shape, pictureBox1);
        }

        private void RightMoveButton_Click(object sender, EventArgs e)
        {
            shape.Move(new Vector3(1, 0, 0));
            rasterizeDelegate(shape, pictureBox1);
        }

        private void UpMoveButoon_Click(object sender, EventArgs e)
        {
            shape.Move(new Vector3(0, 1, 0));
            rasterizeDelegate(shape, pictureBox1);
        }

        private void DownMoveButton_Click(object sender, EventArgs e)
        {
            shape.Move(new Vector3(0, -1, 0));
            rasterizeDelegate(shape, pictureBox1);
        }

        private void ForwardMoveButton_Click(object sender, EventArgs e)
        {
            shape.Move(new Vector3(0, 0, 1));
            rasterizeDelegate(shape, pictureBox1);
        }

        private void BackMoveButton_Click(object sender, EventArgs e)
        {
            shape.Move(new Vector3(0, 0, -1));
            rasterizeDelegate(shape, pictureBox1);
        }

        private void XRotateButton_Click(object sender, EventArgs e)
        {
            shape.Rotate(0.017f, "x");
            rasterizeDelegate(shape, pictureBox1);
        }

        private void YRotateButton_Click(object sender, EventArgs e)
        {
            shape.Rotate(0.017f, "y");
            rasterizeDelegate(shape, pictureBox1);
        }

        private void ZRotateButton_Click(object sender, EventArgs e)
        {
            shape.Rotate(0.017f, "z");
            rasterizeDelegate(shape, pictureBox1);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                    shape?.Scale(1.1f);
                    break;
                case Keys.Subtract:
                    shape?.Scale(0.9f);
                    break;
                case Keys.W:
                    shape?.Move(new Vector3(0, 0, 1));
                    break;
                case Keys.S:
                    shape?.Move(new Vector3(0, 0, -1));
                    break;
                case Keys.A:
                    shape?.Move(new Vector3(-1, 0, 0));
                    break;
                case Keys.D:
                    shape?.Move(new Vector3(1, 0, 0));
                    break;
                case Keys.X:
                    shape?.Rotate(0.017f, "x");
                    break;
                case Keys.Y:
                    shape?.Rotate(0.017f, "y");
                    break;
                case Keys.Z:
                    shape?.Rotate(0.017f, "z");
                    break;
                default:
                    return;
            }
            rasterizeDelegate(shape, pictureBox1);
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                shape?.Move(new Vector3(0, 1, 0));
            else
                shape?.Move(new Vector3(0, -1, 0));

            rasterizeDelegate(shape, pictureBox1);
        }
    }
}
