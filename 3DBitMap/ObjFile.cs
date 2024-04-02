using System.Globalization;
using System.Numerics;

namespace _3DObjects
{
    public class ObjFile
    {
        public List<Vector3> Vertices { get; set; }
        public List<Vector3> nVertices { get; set; }
        public List<Vector3> tVertices { get; set; }
        public List<int> VerticesIndex { get; set; } 
        public List<int> nVerticesIndex { get; set; }
        public List<int> tVerticesIndex { get; set; }

        public ObjFile(string path)
        {
            Vertices = new List<Vector3>();
            nVertices = new List<Vector3>();
            tVertices = new List<Vector3>();
            VerticesIndex = new List<int>();
            nVerticesIndex = new List<int>();
            tVerticesIndex = new List<int>();

            NumberFormatInfo numberFormatInfo = new()
            { NumberDecimalSeparator = ".", };

            using (StreamReader sr = new(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    if (parts[0] == "v")
                    {
                        Vertices.Add(new Vector3(float.Parse(parts[1], numberFormatInfo), float.Parse(parts[2], numberFormatInfo), float.Parse(parts[3], numberFormatInfo)));
                    }
                    else if (parts[0] == "vn")
                    {
                        nVertices.Add(new Vector3(float.Parse(parts[1], numberFormatInfo), float.Parse(parts[2], numberFormatInfo), float.Parse(parts[3], numberFormatInfo)));
                    }
                    else if (parts[0] == "f")
                    {
                        for(int i = 1; i < 4; i++)
                        {
                            string[] part = parts[i].Split('/');
                            VerticesIndex.Add(int.Parse(part[0]));
                            //tVerticesIndex.Add(int.Parse(part[1]));
                            nVerticesIndex.Add(int.Parse(part[2]));
                        }                                           
                    }
                }
            }
        }
    }
}
