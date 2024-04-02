using System.Numerics;

namespace _3DObjects
{
    public class Shape : Primitive
    {
        public Shape(Vector3 center, ObjFile objFile)
        {          
            LocalVertices = [.. objFile.Vertices];

            GlobalVertices = [.. objFile.Vertices];

            VerticesIndexes = [.. objFile.VerticesIndex];

            Pivot = Pivot.BasePivot(center);

        }
    }
}