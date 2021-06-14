using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public GameObject effect;
    public GameObject explosionSound;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().health--;
            other.GetComponent<Player>().RandomShake();
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(explosionSound, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
