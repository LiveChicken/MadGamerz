using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EmitOnDestroy : MonoBehaviour
{
          [System.Serializable]
     public struct Emitable {

          public GameObject GameObjectToEmit;
          public int EmissionCount;
          public Vector3 LocalEmissionPoint;
          public bool InheritRotation;

     }

     public Emitable[] ToEmit;


     private void OnDestroy() {

          foreach (var E in ToEmit) {

               for (int i = 0; i < E.EmissionCount; i++) {

                    GameObject temp = Instantiate(E.GameObjectToEmit);
                    temp.transform.position = transform.position + E.LocalEmissionPoint;

                    if (E.InheritRotation) {
                         temp.transform.rotation = transform.rotation;
                    } else {
                      temp.transform.rotation = Quaternion.Euler(Vector3.zero);
                    }

               }

          }
          
     }


}


