using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float projectileDespawnTime;
    
    public void Shoot(GameObject bulletPrefab, float shootForce, float damageDone, Transform offset, Pawn shooter)
    {
        //before we can shoot bullet, we need a bullet to shoot -Sun Tzu, probably
        GameObject theBullet = Instantiate(bulletPrefab, offset.position, transform.rotation);
        //listen i'm running out of energy to make these comments entertaining, we need the data from the prefab
        Projectile projectile = theBullet.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.damageDone = damageDone;
            projectile.owner = shooter;
        }

        Rigidbody bulletRb = theBullet.GetComponent<Rigidbody>();
        if(bulletRb != null)
        {//Use the force! (to move the bullet very fast)
            bulletRb.AddForce(transform.forward * shootForce);
        }
        //Just like in real life, bullets spontaneously dematerialize after a certain amount of time.
        Destroy(theBullet, projectileDespawnTime);  
    }
}
