using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal.VR;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.SceneManagement;


public class Health : MonoBehaviour {


    public int MaxHealth;

    [HideInInspector]
    public int currentHealth { get; private set; }

    [Tooltip("Am I armoured and invincible to most attacks")]
    public bool Reinforced;

    public float InvincibilityTime = 0f;

    private bool Invincible;
      
    [Space]
    public UnityEvent OnHealthLost;

    public UnityEvent OnHealthGained;

    public UnityEvent OnReinforcedHit;

    [Space]
    public UnityEvent OnZeroHealth;
    
    
    [HideInInspector]
    public bool hasDied;

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

               if (!Invincible || value > 0) {
                   currentHealth += value;
               }

               if (value < 0) {
                   OnHealthLost?.Invoke();

                   StartCoroutine(InvincibilityTimer());

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

    IEnumerator InvincibilityTimer() {

        if (Invincible) {

            yield break;
        }

        Invincible = true;
        
        yield return new WaitForSeconds(InvincibilityTime);

        Invincible = false;

    }





}
