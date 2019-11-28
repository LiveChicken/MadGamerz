using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

     public Transform Target { get; private set; }
     
     public StateMachine StateMachine => GetComponent<StateMachine>();
     
     
     

}
