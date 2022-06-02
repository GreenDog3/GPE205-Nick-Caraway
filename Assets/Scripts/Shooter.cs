using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float projectileDespawnTime;

   public void Shoot(GameObject bulletPrefab, float shootForce, float damageDone, Transform offset, Pawn shooter)
    {
        // make bullet
        GameObject theBullet = Instantiate(bulletPrefab, offset.position, transform.rotation);
        //gib data
        Projectile projectile = theBullet.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.damageDone = damageDone;
            projectile.owner = shooter;
        }


        //pew pew with great force

        Rigidbody bulletRb = theBullet.GetComponent<Rigidbody>();
        if(bulletRb != null)
        {
            bulletRb.AddForce(transform.forward * shootForce);
        }
        Destroy(theBullet, projectileDespawnTime);
    }
}
