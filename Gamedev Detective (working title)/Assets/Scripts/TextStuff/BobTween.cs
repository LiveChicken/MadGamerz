using System.Collections;
using System.Collections.Generic;
using CharTween;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class BobTween : MonoBehaviour {

     private TMP_Text text;

     private void Start() {

          text = GetComponent<TMP_Text>();

          var tweener = text.GetCharTweener();

          for (var i = 0; i < tweener.CharacterCount; ++i) {
               // Move characters in a circle
               var circleTween = tweener.DOCircle(i, 0.5f, 5f)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Restart);

               // Oscillate character color between yellow and white
               var colorTween = tweener.DOColor(i, Color.yellow, 0.5f)
                    .SetLoops(-1, LoopType.Yoyo);

               // Offset animations based on character index in string
               var timeOffset = Mathf.Lerp(0, 1, i / (float) (tweener.CharacterCount - 1));
               circleTween.fullPosition = timeOffset;
               colorTween.fullPosition  = timeOffset;
          }
     }


     
     
}
