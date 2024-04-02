using System.Numerics;

namespace _3DObjects
{
    public class Camera
    {
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        public Pivot Pivot { get; private set; }
        public float ScreenDist { get; private set; }
        public float ObserveRange { get; private set; }
        public float Scale => ScreenWidth / (float)(2 * ScreenDist * Math.Tan(ObserveRange / 2));

        public Camera(Vector3 center, float screenDist, float observeRange, int screenWidth, int screenHeight)
        {
            Pivot = Pivot.BasePivot(center);
            ScreenDist = screenDist;
            ObserveRange = observeRange;
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
        }

        public Vector2 ScreenProection(Vector3 v)
        {
            Vector3 local = Pivot.ToLocalCoords(v);

            //игнорируем точки сзади камеры
            if (local.Z < ScreenDist)
            {
                return new Vector2(float.NaN, float.NaN);
            }
            
            //через подобные треугольники находим проекцию и умножаем ее на коэффициент растяжения
            var delta = ScreenDist / local.Z * Scale;
            var proection = new Vector2(local.X, local.Y) * delta;

            //этот код нужен для перевода проекции в экранные координаты
            var screen = proection + new Vector2(ScreenWidth / 2, -ScreenHeight / 2);
            var screenCoords = new Vector2(screen.X, -screen.Y);

            //если точка принадлежит экранной области - вернем ее
            if (screenCoords.X >= 0 && screenCoords.X < ScreenWidth && screenCoords.Y >= 0 && screenCoords.Y < ScreenHeight)
            {
                return screenCoords;
            }
            return new Vector2(float.NaN, float.NaN);
        }
    }

}
