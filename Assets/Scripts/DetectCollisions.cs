using Unity.VisualScripting;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public GameObject enemyExplosionPrefab;
    public AudioClip explosionSound;
    private  AudioSource explosionAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        explosionAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.CompareTag("Enemy"))

        if (other.CompareTag("Player"))
        {
            //  explosionAudio.PlayOneShot(explosionSound, 1.0f);
            Instantiate(enemyExplosionPrefab, other.gameObject.transform.position, other.gameObject.transform.rotation);
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            Destroy(gameObject);
            FindFirstObjectByType<GameManager>().EndGame();
            //FindFirstObjectByType<PlayerController>().PlayerExplosion();
            }
        else
        {

            Debug.Log("Hit enemy collison " + other.name);
            Instantiate(enemyExplosionPrefab, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            FindFirstObjectByType<GameManager>().UpdateScore(125);
            Destroy(other.gameObject);
            Destroy(gameObject);


        }

    }
}
