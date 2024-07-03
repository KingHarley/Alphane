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

        public static Vector2 GetDirectionForEnemy(Vector3 enemyPos, Vector3 playerPos)
            => (playerPos - enemyPos).normalized;
    }
}
