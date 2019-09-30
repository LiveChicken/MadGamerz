using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG_Common
{
    public static class RandomBy {

        public static bool Percent(float chance) {

            float clampedChance = Mathf.Clamp(chance, 0f, 100f);

            return clampedChance > UnityEngine.Random.Range(0, 100f); 

        }

    }
}
