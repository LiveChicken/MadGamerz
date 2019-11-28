using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class StateMachine : MonoBehaviour {

     public Dictionary<Type, BaseState> AvailableStates;
     
     public BaseState CurrentState { get; private set; }

     public Transform Target;

     public event Action<BaseState> OnStateChanged;

     private void Start() {

          
         
          setup();
     }

     void setup() {
          AvailableStates = new Dictionary<Type, BaseState>();
          
         // AvailableStates.Clear();

          BaseState[] states = GetComponents<BaseState>();

          Debug.Log(states.Length);
          
          foreach (BaseState BS in states) {
               
               
               AvailableStates.Add(BS.GetType(), BS);
               
          }
          


     }


     private void Update() {

          if (CurrentState == null) {

               CurrentState = AvailableStates.Values.First();

          }

          var nextState = CurrentState?.Perform();

          if (nextState != null && nextState != CurrentState.GetType()) {


               SwitchToNewState(nextState);


          }


     }

    public void SwitchToNewState(Type nextState) {

         CurrentState.OnDeactivate();
         
          CurrentState = AvailableStates[nextState];
          OnStateChanged?.Invoke(CurrentState);
         
         CurrentState.OnActivate();

     }



}
