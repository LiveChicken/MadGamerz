using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VR;
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour {


    public int MaxHealth;

    private int currentHealth;
      
    [Space]
    public UnityEvent OnHealthLost;

    public UnityEvent OnHealthGained;
    
    [Space]
    public UnityEvent OnZeroHealth;

    private bool hasDied;

    private void Start() {
        currentHealth = MaxHealth;
    }


   public void ChangeHealth(int value) {


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
