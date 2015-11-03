using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace HermansGameDev.RandomExtensions
{
    public static class RandomExtensions
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

        #region Float

        public static float NextFloat(this Random r) => (float) r.NextDouble();

        #endregion

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

        /// <summary>
        /// Returns a random (non-control code) ASCII character.
        /// </summary>
        public static char NextCharASCII(this Random r) => (char) (r.Next(ASCII_FIRST_NON_CTRL_CHAR, ASCII_LAST_CHAR + 1));

        /// <summary>
        /// Returns a random ASCII string of specified length that does not contain any control code characters.
        /// </summary>
        public static string NextStringASCII(this Random r, int length)
        {
            var result = "";
            for (int i = 0; i < length; i++) result += r.NextCharASCII();
            return result;
        }

        // ASCII lowercase letter codes
        private const int ASCII_LOWER_A = 97;
        private const int ASCII_LOWER_Z = 122;

        public static char NextCharLowerAlphabetic(this Random r) => (char) r.Next(ASCII_LOWER_A, ASCII_LOWER_Z + 1);

        public static string NextStringLowerAlphabetic(this Random r, int length)
        {
            var result = "";
            for (int i = 0; i < length; i++) result += r.NextCharLowerAlphabetic();
            return result;
        }

        #endregion Strings

        /// <summary>
        /// Creates a Distribution using specified values and their frequencies. A distribution can be used to retrieve random values with desired frequencies.
        /// </summary>
        /// <typeparam name="T">Type of the values in the distribution</typeparam>
        /// <param name="rand">The random instance used to select values</param>
        /// <param name="distribution">Dictionary of values and frequencies with Dictionary keys acting as values and Dictionary values acting as frequencies.</param>
        /// <returns>An instance of Distribution which returns the specified values in the specified frequencies.</returns>
        public static Distribution<T> NextDistribution<T>(this Random rand, Dictionary<T, int> distribution) => new Distribution<T>(rand, distribution);
    }
}