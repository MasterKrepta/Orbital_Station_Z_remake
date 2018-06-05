using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{

    Rigidbody rb;
    [SerializeField] float speed = 10;
    [SerializeField] float dmgAmount = 1;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch(Transform dir) {
        rb.velocity = dir.forward * speed;
    }



    private void OnTriggerEnter(Collider other) {
        //TODO create hit partical
        
        if (other.GetComponent<IDamagable>() != null) {
            //Debug.Log("TakeDamage: " + other.name);
            Destroy(this.gameObject);
            other.GetComponent<IDamagable>().TakeDamage(dmgAmount);
        }
        else {
            //TODO Pool this object
            Destroy(this.gameObject);
        }
    }

    private void Update() {
        Destroy(this.gameObject, 2f);
    }
}
