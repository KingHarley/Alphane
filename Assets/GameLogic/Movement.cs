using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace GameLogic
{
    internal static class Movement
    {
        static Unity.Mathematics.Random Random = Unity.Mathematics.Random.CreateFromIndex(1);
        public static Vector2 GetDirectionForPlayer()
        {
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }

        public static Vector2 GetDirectionBetweenVectors(Vector3 currentPos, Vector3 targetPos)
            => (targetPos - currentPos).normalized;

        public static float GetDistance(Vector3 pos1, Vector3 pos2)
            => (pos1 - pos2).magnitude;

        public static Vector2 GetRandomDirection()
        {
            return new Vector2(Random.NextFloat(-1, 1), Random.NextFloat(-1, 1)).normalized;
        }

        public static Vector2 GetRandomPositionAtDistance(Vector2 reference, int distance)
            => (GetRandomDirection() * distance) + reference;
    }
}
