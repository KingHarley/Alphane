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
        public static Vector3 CalculateNewPosition(Vector3 currentPosition, float speed)
        {

            var distance = speed * Time.deltaTime;
            var displacement = distance * GetDirectionUnitVector();
            return currentPosition + displacement;
        }

        public static Vector3 GetDirectionUnitVector()
        {
            var allKeyVecs = new List<Vector3>();

            if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.W))
                allKeyVecs.Add(Vector3.up);
            if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.S))
                allKeyVecs.Add(Vector3.down);
            if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.D))
                allKeyVecs.Add(Vector3.right);
            if (Input.GetKey(KeyCode.A)  || Input.GetKeyDown(KeyCode.A))
                allKeyVecs.Add(Vector3.left);

            var seed = Vector3.zero;

            return allKeyVecs.Aggregate(seed, (accum, vec) => accum + vec).normalized;
        }
    }
}
