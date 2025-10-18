using System.Collections;
using UnityEngine;

public class DeleteAfterExplosion : MonoBehaviour
{

    public int secondsUntilDeletion = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DestroyAfterExplosion());
    }


    private IEnumerator DestroyAfterExplosion()
    {
        yield return new WaitForSeconds(secondsUntilDeletion);
        Destroy(gameObject);
    }


}
