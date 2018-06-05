using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour  {

    private ILauncher launcher;

    [SerializeField] Transform barrel;
    [SerializeField]float refreshRate = 0.5f;

    float nextFire;

    private void Awake() {
        launcher = GetComponent<ILauncher>();
    }

    private void Update() {
        GetInput();
    }

    void GetInput() {
        float triggers = Input.GetAxis("Triggers");
        if (triggers < 0 && CanFire()) {
            Fire();
        }
    }

    bool CanFire() {
        return Time.time >= nextFire;
    }

    public void Fire() {
        nextFire = Time.time + refreshRate;
        launcher.Launch(this);
    }
}