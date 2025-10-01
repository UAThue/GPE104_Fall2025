using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Bullet bulletToShoot;
    public Transform firePoint;
    public AudioClip fireSound;
    private AudioSource audioSource;

    private void Start()
    {
        // Get the audiosource component
        audioSource = GetComponent<AudioSource>();
    }
    public void Shoot()
    {
        Shoot(bulletToShoot);
    }
    public void Shoot( Bullet bulletToShoot )
    {
        // Instantiate the bullet we plan to shoot
        Bullet theBullet = Instantiate<Bullet>(bulletToShoot, firePoint.position, firePoint.rotation );

        // Play the sound
        AudioSource.PlayClipAtPoint(fireSound, transform.position, 1.0f);
        //audioSource.PlayOneShot(fireSound);

        //audioSource.clip = fireSound;
        //audioSource.Play();
    }
}
