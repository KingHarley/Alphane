using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class Stats : MonoBehaviour
    {
        public int Health;
        public int Damage;
        public int DamageRate;
        public float SecondsSinceLastDamage;
        public bool IsReadyToDamage = true;

        public void TakeDamage(int damage)
        {
            print($"{name}: Taking {damage} damage");
            Health -= Health >= damage ? damage : Health;
            print($"{name}: Updated health {Health}");
        }

        public void TriggerDamageCooldown()
        {
            print($"{name}: Triggering cooldown");
            IsReadyToDamage = false;
            SecondsSinceLastDamage = 0;
        }

        public void FixedUpdate()
        {
            if (!IsReadyToDamage)
            {
                SecondsSinceLastDamage += Time.deltaTime;
                if (SecondsSinceLastDamage > DamageRate)
                    IsReadyToDamage = true;
            }
        }
    }
}
