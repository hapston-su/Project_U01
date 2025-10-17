using UnityEngine;

public class Projectile : MonoBehaviour
{


    public float speed = 500f;
    private Vector3 direction;
    private bool isLaunched = false;

    public void Launch(Vector3 shootDirection)
    {
        direction = shootDirection.normalized;
        isLaunched = true;
        Destroy(gameObject, 3f);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {
        if (!isLaunched) return;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
