using System.Numerics;

namespace _3DObjects
{
    public class Pivot
    {
        public Vector3 Center { get; set; }
        public Vector3 XAxis { get; set; }
        public Vector3 YAxis { get; set; }
        public Vector3 ZAxis { get; set; }

        public Matrix4x4 LocalCoordsMatrix => new
            (
                XAxis.X, YAxis.X, ZAxis.X, 0,
                XAxis.Y, YAxis.Y, ZAxis.Y, 0,
                XAxis.Z, YAxis.Z, ZAxis.Z, 0,
                0, 0, 0, 1
            );

        public Matrix4x4 GlobalCoordsMatrix => new
            (
                XAxis.X, XAxis.Y, XAxis.Z, 0,
                YAxis.X, YAxis.Y, YAxis.Z, 0,
                ZAxis.X, ZAxis.Y, ZAxis.Z, 0,
                0, 0, 0, 1
            );

        public Pivot(Vector3 center, Vector3 xaxis, Vector3 yaxis, Vector3 zaxis)
        {
            Center = center;
            XAxis = xaxis;
            YAxis = yaxis;
            ZAxis = zaxis;
        }

        public static Pivot BasePivot(Vector3 center) => new(center, new Vector3(1, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 0, 1));

        public Vector3 ToGlobalCoords(Vector3 local)
        {
            return Vector3.Transform(local, GlobalCoordsMatrix) + Center;
        }

        public Vector3 ToLocalCoords(Vector3 global)
        {
            return  Vector3.Transform((global - Center), LocalCoordsMatrix);
        }

        public void Move(Vector3 v)
        {
            Center += v;
        }

        public void Rotate(float angle, string axis)
        {
            if (axis == "x")
                RotateAlongX(angle);
            else if (axis == "y")
                RotateAlongY(angle);
            else if (axis == "z")
                RotateAlongZ(angle);
        }

        private void RotateAlongX(float angle)
        {   
            Matrix4x4 Rx = Matrix4x4.CreateRotationX(angle);
            XAxis = Vector3.Transform(XAxis, Rx);
            YAxis = Vector3.Transform(YAxis, Rx);
            ZAxis = Vector3.Transform(ZAxis, Rx);
        }

        private void RotateAlongY(float angle)
        {
            Matrix4x4 Ry = Matrix4x4.CreateRotationY(angle);
            XAxis = Vector3.Transform(XAxis, Ry);
            YAxis = Vector3.Transform(YAxis, Ry);
            ZAxis = Vector3.Transform(ZAxis, Ry);
        }

        private void RotateAlongZ(float angle)
        {
            Matrix4x4 Rz = Matrix4x4.CreateRotationZ(angle);
            XAxis = Vector3.Transform(XAxis, Rz);
            YAxis = Vector3.Transform(YAxis, Rz);
            ZAxis = Vector3.Transform(ZAxis, Rz);
        }
    }

}
