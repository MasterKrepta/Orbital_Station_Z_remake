using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable {

    [SerializeField] float maxHealth = 3f;
    [SerializeField] float currentHealth;
    [SerializeField] float dmgAmount = 1;

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

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponentInParent<IDamagable>() != null) {
            other.GetComponentInParent<IDamagable>().TakeDamage(dmgAmount);
        }
    }

    


}
