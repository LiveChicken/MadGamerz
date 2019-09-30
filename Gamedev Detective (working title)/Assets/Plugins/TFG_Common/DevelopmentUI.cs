using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace TFG_Common {



    public class DevelopmentUI : MonoBehaviour {

        public TMP_Text FPSCounter;
        public int FPSChecksPerSecond;

        void OnEnable() {

            StartCoroutine(FPSUpdate());

        }

        private void OnDisable() {
            
            StopAllCoroutines();
            
        }


        IEnumerator FPSUpdate() {

            while (true) {

                yield return new WaitForSecondsRealtime(1f/FPSChecksPerSecond);
                FPSCounter.text = ((int) (1f / Time.deltaTime)) + " fps";
                
                
            }
            
        }


    }
}
