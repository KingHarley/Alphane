using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace GameLogic
{
    internal static class Movement
    {
        public static Vector2 GetDirectionForPlayer()
        {
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }

        public static Vector2 GetDirectionBetweenVectors(Vector3 currentPos, Vector3 targetPos)
            => (targetPos - currentPos).normalized;

        public static float GetDistance(Vector3 pos1, Vector3 pos2)
            => (pos1 - pos2).magnitude;
    }
}
