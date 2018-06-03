using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncher : MonoBehaviour, ILauncher {

    [SerializeField]
    Transform bullet;
    public void Launch(Weapon weapon) {
        var go = Instantiate(bullet);
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
