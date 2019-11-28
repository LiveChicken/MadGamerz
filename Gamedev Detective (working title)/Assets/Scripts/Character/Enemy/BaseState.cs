using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]
public abstract class BaseState : MonoBehaviour {


     public BaseState NextState;

     public StateMachine myStateMachine;

     private void Start() {
          //throw new System.NotImplementedException();
          myStateMachine = GetComponent<StateMachine>();
          
     }

     

         

     

     //  public Transform Target;

    // public int Importance;

     public abstract void OnActivate();
     
    public abstract System.Type Perform();

     public abstract void OnDeactivate();



}
