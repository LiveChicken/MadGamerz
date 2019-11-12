using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuitDialog : MonoBehaviour {

    public Button FirstSelected;


    private void OnEnable() {
        
        FirstSelected.Select();
        
    }

    public void QuitGame() {

        Application.Quit();
        
    }
}
