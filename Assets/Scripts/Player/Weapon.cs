using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private Vector3 position;
    public GameObject bulletRef;
    public float timeCooldown;
    private bool isCoolDown = true;
    public SoundControl soundControl;

    private void Start()
    {
        PoolManager.instance.CreatePool(bulletRef, 50);
    }

    public void Shoot(int index)
    {
        if (isCoolDown){
            soundControl.ApplySound("Shoot");
            PoolManager.instance.ReuseObject(bulletRef, transform.position, transform.rotation);
            isCoolDown = false;
            Invoke("ShootAgain", timeCooldown);
        }
    }

    public void ShootAgain()
    {
        isCoolDown = true;
    }


}
