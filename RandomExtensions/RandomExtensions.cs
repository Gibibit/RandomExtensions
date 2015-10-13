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
        
        public static Matrix NextRotationX(this Random r) => Matrix.CreateRotationX(r.NextFloat()*MathHelper.TwoPi);
        public static Matrix NextRotationY(this Random r) => Matrix.CreateRotationY(r.NextFloat()*MathHelper.TwoPi);
        public static Matrix NextRotationZ(this Random r) => Matrix.CreateRotationZ(r.NextFloat()*MathHelper.TwoPi);

        /// <summary>
        /// Rotates a Vector2 to a random direction
        /// </summary>
        public static Vector2 NextRotateVector2(this Random r, Vector2 v) => r.NextVector2Unit()*v.Length();

        /// <summary>
        /// Rotates a Vector3 to a random direction
        /// </summary>
        public static Vector3 NextRotateVector3(this Random r, Vector3 v) => r.NextVector3Unit()*v.Length();

        #endregion MonoGame

        #region Collections

        /// <summary>
        /// Chooses a random element from a given list.
        /// </summary>
        public static T Choose<T>(this Random r, IList<T> list) => list[r.Next(list.Count)];

        /// <summary>
        /// Chooses a random element from a given array or parameters.
        /// </summary>
        public static T Choose<T>(this Random r, params T[] items) => items[r.Next(items.Length)];

        #endregion Collections

        public static float NextFloat(this Random r) => (float) r.NextDouble();

        #region Strings

        public static string NextString(this Random r, int length)
        {
            var result = "";
            for (int i = 0; i < length; i++) result += r.NextChar();
            return result;
        }

        public static char NextChar(this Random r) => (char) r.Next(char.MaxValue);

        // Some useful ASCII numbers
        private const int ASCII_FIRST_NON_CTRL_CHAR = 32;
        private const int ASCII_LAST_CHAR = 255;

        public static char NextASCIIChar(this Random r) => (char) (r.Next(ASCII_FIRST_NON_CTRL_CHAR, ASCII_LAST_CHAR + 1));

        public static string NextASCIIString(this Random r, int length)
        {
            var result = "";
            for (int i = 0; i < length; i++) result += r.NextASCIIChar();
            return result;
        }

        #endregion Strings

    }
}