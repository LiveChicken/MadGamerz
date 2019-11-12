using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal.VR;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.SceneManagement;


public class Health : MonoBehaviour {


    public int MaxHealth;

    private int currentHealth;

    [Tooltip("Am I armoured and invincible to most attacks")]
    public bool Reinforced;
      
    [Space]
    public UnityEvent OnHealthLost;

    public UnityEvent OnHealthGained;

    public UnityEvent OnReinforcedHit;

    [Space]
    public UnityEvent OnZeroHealth;
    
    

    private bool hasDied;

    private void Start() {
        currentHealth = MaxHealth;
    }


   public void ChangeHealth(int value, bool Heavy = false) {

       if (!Heavy && Reinforced) {
         Debug.Log("AHAHAHAH I am invincible!");
           
           OnReinforcedHit?.Invoke();
           
           return;
       }

       if (!hasDied) {
            currentHealth += value;

            if (value < 0) {
              OnHealthLost?.Invoke();
            } else {

                OnHealthGained?.Invoke();
                
            }

            currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);

            if (currentHealth <= 0) {

                OnZeroHealth?.Invoke();
                hasDied = true;

            }
        }

    }


   


}
