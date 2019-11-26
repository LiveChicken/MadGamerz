using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]
public abstract class Behavior : MonoBehaviour {


     public int Importance;

     public abstract void OnActivate();
     
    // public abstract void Perform();

     public abstract void OnDeactivate();



}
