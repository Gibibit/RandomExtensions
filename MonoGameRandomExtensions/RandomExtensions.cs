using System;
using Microsoft.Xna.Framework;

namespace RandomExtensions.MonoGame
{
    public static class MonoGameRandomExtensions
    {
        public static Vector2 NextVector2Unit(this Random rand) => Vector2.Normalize(new Vector2((float) rand.NextDouble(), (float) rand.NextDouble()));
    }
}