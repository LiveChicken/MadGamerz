using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactable2D : MonoBehaviour {

  //  private LayerMask cursorLayer;// = LayerMask.GetMask(LayerMask.LayerToName(11));
    // Start is called before the first frame update

    public UnityEvent OnCursorEnter;
    public UnityEvent OnClick;
    public UnityEvent OnCursorExit;

    


    public void Click() {

        OnClick?.Invoke();

    }


    private void OnTriggerEnter2D(Collider2D other) {
        
        if (TFG_SP.Checks.CompareLayers(LayerMask.GetMask("2D Cursor"), other.gameObject)){

            OnCursorEnter?.Invoke();
            
        }

    }

    private void OnTriggerExit2D(Collider2D other) {

        if (TFG_SP.Checks.CompareLayers(LayerMask.GetMask("2D Cursor"), other.gameObject)) {

            OnCursorExit?.Invoke();

        }

    }
    

}
