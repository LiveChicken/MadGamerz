﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;


public class Inspectable : MonoBehaviour {

    private static float moveTime = 1f;
    
    private Vector3 OriginalPosition;
    private Quaternion OriginalRotation;


    public UnityEvent OnInspect;

    // Start is called before the first frame update
    void Start() {

        OriginalPosition = transform.position;
        OriginalRotation = transform.rotation;

    }

   

    public void ReturnToOrigin() {

        transform.DOMove(OriginalPosition, moveTime);
        transform.DORotate(OriginalRotation.eulerAngles, moveTime);

    }
}
