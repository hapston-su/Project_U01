using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;


public class PlayerController : MonoBehaviour
{
public float horizontalInput;
public float verticalInput;
public float speed = 100.0f;
public GameObject shellPrefab;
public Transform firePoint;
public ParticleSystem playerExplosionParticle;
public GameObject shellExplosionPrefab;
public AudioClip shootSound;
private AudioSource shootAudio;
public bool isGameActive;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootAudio = GetComponent<AudioSource>();  
        isGameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player Control Is Game Active1: " + isGameActive);
        isGameActive = FindFirstObjectByType<GameManager>().isGameActive;
        if (!isGameActive) return;
        Debug.Log("Player Control Is Game Active2: " + isGameActive);
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = transform.position.z;
            transform.Rotate(Vector3.up * horizontalInput * speed * Time.deltaTime);

            //transform.position = new Vector3(transform.position.x, transform.position.y, zRange);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Launch a projectile from the player
                ShootShell();
                GameObject shellExplosion = Instantiate(shellExplosionPrefab, transform.position, transform.rotation);
                shellExplosion.GetComponent<ParticleSystem>().Play();
                FindFirstObjectByType<GameManager>().UpdateScore(-25);
            }
        
    }


    private void ShootShell()
    {
        GameObject bullet = Instantiate(shellPrefab, firePoint.position, firePoint.rotation);
        Vector3 shootDir = firePoint.forward;  // can be based on camera, mouse, etc.
        bullet.GetComponent<Projectile>().Launch(shootDir);
        shootAudio.PlayOneShot(shootSound, 1.0f);
    }

    public void PlayerExplosion()
    {
        // Play explosion particle effect
        if (playerExplosionParticle != null)
        {
            playerExplosionParticle.Play();
        }
        else
        {
            Debug.LogWarning("No ParticleSystem component found on the player for explosion effect.");
        }
        Debug.Log("Player has exploded.");
    }

}
