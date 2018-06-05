using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable {

    [SerializeField] float maxHealth = 3f;
    [SerializeField] float currentHealth;

    private void OnEnable() {
        
    }

    private void OnDisable() {
        
    }

    public void Die() {
        EventManager.CallOnEnemyDeath();
        Destroy(this.gameObject);
        
    }

    public void TakeDamage(float dmg) {
        currentHealth -= dmg;
        if(currentHealth <= 0) {
            Die();
        }
    }

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
	}
	

}
