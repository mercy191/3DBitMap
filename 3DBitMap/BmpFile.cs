using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace _3DBitMap
{
    public class BmpFile
    {
        public Image Image { get; set; }
        public Bitmap Bitmap { get; set; }

        public BmpFile(string path) 
        {
            Image = Image.FromFile(path);
            Bitmap = new Bitmap(Image, Image.Width, Image.Height);
        }
    }
}
