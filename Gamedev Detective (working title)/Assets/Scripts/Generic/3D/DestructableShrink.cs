using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DestructableShrink : Destructable
{


     public override void DestroyMe(float t) {

          Destroy(gameObject, t);
          transform.DOScale(Vector3.zero, t);

     }

}
