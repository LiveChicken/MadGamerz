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

    public static class Curve {

        public static Vector3 GetQuadraticCurvePoint(float t, Vector3 p0, Vector3 p1, Vector3 p2) {
            float u  = 1 - t;
            float tt = t * t;
            float uu = u * u;
            return (uu * p0) + (2 * u * t * p1) + (tt * p2);
        }
        
    }


    public static class Checks {

        public static bool IsAxisAvailable(string axisName) {
            try {
                Input.GetAxis(axisName);
                return true;
            } catch (UnityException exc) {
                return false;
            }
        }

       public static  bool IsButtonAvailable(string btnName) {
            try {
                Input.GetButton(btnName);
                return true;
            } catch (UnityException exc) {
                return false;
            }
        }



        public static bool CompareLayers(LayerMask mask, GameObject other) {

            if ((mask & 1 << other.layer) == 1 << other.layer) {

                return true;

            }

            return false;

        }

    }



}
