using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, IWeapon
{
    [SerializeField] GameObject bullet;
    public void Shoot(GameObject muzzle)
    {
        Instantiate(bullet, muzzle.transform);
    }

    public GameObject WeaponMuzzle()
    {
        throw new System.NotImplementedException();
    }
}
