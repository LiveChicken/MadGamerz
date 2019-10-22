using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ButtonPrompt : MonoBehaviour {
    public Image PromptImage;
    public TMP_Text PromptText;

    public void SetPrompt(string prompt) {

        PromptImage.sprite = GameManager.GM.MasterBSM.GetXboxSprite(prompt);
        PromptText.text = ""; 

    }

}
