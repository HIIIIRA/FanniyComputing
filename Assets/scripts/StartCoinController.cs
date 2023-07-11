using System.Collections;
using UnityEngine;

public class StartCoinController : MonoBehaviour
{
    public AudioClip getCoin;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioSourceController.instance.PlayOneShot(getCoin);
            Destroy(gameObject);
        }
    }
}
