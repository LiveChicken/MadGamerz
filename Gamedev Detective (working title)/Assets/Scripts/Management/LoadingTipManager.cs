using System.Collections;
using System.Collections.Generic;
using TFG_SP;
using TMPro;
using UnityEngine;

public class LoadingTipManager : MonoBehaviour {

    public LoadingTips Tips;

     public TMP_Text Text;

     [SerializeField]
     [TextArea(3, 8)]
     private string currentTip;


     private void OnEnable() {
          
          GenerateLine();
          
     }

     public void GenerateLine() {

          currentTip = Tips.dataArray[RandomBy.ZeroMax(Tips.dataArray.Length)].English;

          Text.text = currentTip;

     }


}
