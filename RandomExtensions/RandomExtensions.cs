using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RandomExtensions
{
    public static class MonoGameRandomExtensions
    {
        #region MonoGame

        public static Vector2 NextVector2Unit(this Random r) => Vector2.Normalize(new Vector2(r.NextFloat(), r.NextFloat()));

        public static Vector3 NextVector3Unit(this Random r) => Vector3.Normalize(new Vector3(r.NextFloat(), r.NextFloat(), r.NextFloat()));

        public static Color NextColor(this Random r) => new Color(NextVector3Unit(r));

        #endregion MonoGame

        #region Collections

        public static T Choose<T>(this Random rand, IList<T> list) => list[rand.Next(list.Count)];

        public static T Choose<T>(this Random rand, T[] items) => items[rand.Next(items.Length)];

        #endregion Collections

        public static float NextFloat(this Random rand) => (float) rand.NextDouble();

    }
}