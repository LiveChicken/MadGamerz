using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;


public class Inspectable : MonoBehaviour {



    public CinemachineVirtualCamera CVCamera;
    
    private static float moveTime = 1f;
    
    
    
    
    private Vector3 OriginalPosition;
    private Quaternion OriginalRotation;
    private Transform OriginalParent;


    public UnityEvent OnInspect;

    public UnityEvent OnUninspect;

    // Start is called before the first frame update
    void Start() {

        OriginalPosition = transform.position;
        OriginalRotation = transform.rotation;
        
        OnInspect.AddListener(Inspect);

    }

    void Inspect() {

        if (CVCamera != null) {

            CVCamera.gameObject.SetActive(true);
            
        }

        GameManager.GM.CanMove = false;

    }



    public void ReturnToOrigin() {

        transform.DOMove(OriginalPosition, moveTime);
        transform.DORotate(OriginalRotation.eulerAngles, moveTime);
        transform.parent = OriginalParent;
        

        if (CVCamera != null) {

            CVCamera.gameObject.SetActive(false);

        }

        GameManager.GM.CanMove = true;
        
        OnUninspect?.Invoke();
        
        //UnityEngine.UI.Selectable.
        
        
    }
}
