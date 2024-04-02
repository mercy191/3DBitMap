using System.Numerics;

namespace _3DObjects
{
    public abstract class Primitive
    {
        //Локальный базис объекта
        public Pivot Pivot { get; protected set; }
        //Локальные вершины
        public Vector3[] LocalVertices { get; protected set; }
        //Глобальные вершины
        public Vector3[] GlobalVertices { get; protected set; }
        //Индексы вершин
        public int[] VerticesIndexes { get; protected set; }

        public void Move(Vector3 v)
        {
            Pivot?.Move(v);

            for (int i = 0; i < LocalVertices?.Length; i++)
                GlobalVertices[i] += v;
        }

        public void Scale(float k)
        {
            for (int i = 0; i < LocalVertices.Length; i++)
                LocalVertices[i] *= k;

            for (int i = 0; i < LocalVertices.Length; i++)
                GlobalVertices[i] = Pivot.ToGlobalCoords(LocalVertices[i]);
        }

        public void Rotate(float angle, string axis)
        {
            Pivot.Rotate(angle, axis);

            for (int i = 0; i < LocalVertices.Length; i++)
                GlobalVertices[i] = Pivot.ToGlobalCoords(LocalVertices[i]);
        }

        public IEnumerable<Polygon> GetPolygons()
        {
            for (int i = 0; i < VerticesIndexes.Length; i += 3)
            {
                Vector3 v1, v2, v3;

                // индексы вершин полигона
                var i1 = VerticesIndexes[i];
                var i2 = VerticesIndexes[i + 1];
                var i3 = VerticesIndexes[i + 2];
                // вершины полигона
                v1 = GlobalVertices[i1 - 1];
                v2 = GlobalVertices[i2 - 1];
                v3 = GlobalVertices[i3 - 1];

                yield return new Polygon(v1, v2, v3);
            }
        }
    }

    public class Polygon
    {
        public Vector3 v1;
        public Vector3 v2;
        public Vector3 v3;

        public Polygon(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }
    }

}
