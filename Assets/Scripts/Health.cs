using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Pawn myPawn;
    public Controller myController;

    // Start is called before the first frame update
    void Start()
    {
        myPawn = GetComponent<Pawn>();
        myController = GetComponent<Controller>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount, Pawn owner)
    {
        currentHealth = currentHealth - amount;

        if (currentHealth <= 0)
        { //Pretend the breath of the wild game over sound effect is playing as you read this. It won't change anything, but it'll be funny.
            Die(owner);
        }
    }

    public void HealDamage(float amount)
    {
        currentHealth = currentHealth + amount;

        if (currentHealth > maxHealth)
        { //prevents health from being above the maximum
            currentHealth = maxHealth;
        }
    }

    public void Die(Pawn killer)
    { //TODO: Give points to the killer
        Destroy(myController);
        Destroy(gameObject);
    }
}
