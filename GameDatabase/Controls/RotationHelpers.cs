﻿using EditorDatabase.Model;
using System;

namespace Controls
{
    public static class RotationHelpers
    {
        public static Vector2 Direction( float angle )
        {
            return new Vector2( ( float ) Math.Sin( angle * Math.PI / 180f ), -( float ) Math.Cos( angle * Math.PI / 180f ) );
        }

        //public static float Angle(Vector2 direction)
        //{
        //    var result = Mathf.Atan2(direction.y, direction.x);
        //    if (result < 0) result += Mathf.PI * 2;
        //    return result * Mathf.Rad2Deg;
        //}

        //public static bool Equals(float firstAngle, float secondAngle)
        //{
        //    return Mathf.Approximately(Mathf.DeltaAngle(firstAngle, secondAngle), 0);
        //}

        //public static Vector2 Transform(Vector2 point, float angle)
        //{
        //    var angleRadians = angle * Mathf.Deg2Rad;
        //    return new Vector2(
        //            point.x * Mathf.Cos(angleRadians) - point.y * Mathf.Sin(angleRadians),
        //            point.y * Mathf.Cos(angleRadians) + point.x * Mathf.Sin(angleRadians));
        //}
    }
}