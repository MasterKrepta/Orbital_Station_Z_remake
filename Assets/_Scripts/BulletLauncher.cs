using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncher : MonoBehaviour, ILauncher {

    [SerializeField]
    Projectile bullet;

    public void Launch(Weapon weapon) {
        var go = Instantiate(bullet, weapon.transform.position, weapon.transform.rotation);
        go.Launch(weapon.transform);

    }




}
