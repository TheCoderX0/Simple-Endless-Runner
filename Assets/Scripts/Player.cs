using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    //public float speed = 10;
    public float increment;
    public float maxY = 3;
    public float minY = -3;

    private Vector2 targetPos;

    [Header("Health")]
    public int health;

    [Header("Effects & Display")]
    public GameObject moveEffect;
    public Animator camAnim;
    public Text healthDisplay;

    [Header("GameObjects")]
    public GameObject spawner;
    public GameObject scoreManagerCollider;
    public GameObject restartDisplay;

    [Header("Sound")]
    public GameObject explosionPlayerSound;
    public GameObject movePlayerSound;

    void Update()
    {
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            Instantiate(explosionPlayerSound, transform.position, Quaternion.identity);
            spawner.SetActive(false);
            scoreManagerCollider.SetActive(false);
            restartDisplay.SetActive(true);
            Destroy(gameObject);
        }

        //transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY)
        {
            RandomShake();
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            Instantiate(movePlayerSound, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
            transform.position = targetPos;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY)
        {
            RandomShake();
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            Instantiate(movePlayerSound, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
            transform.position = targetPos;
        }
    }

    public void RandomShake()
    {
        int random = Random.Range(0, 4);
        if (random == 0)
        {
            camAnim.SetTrigger("shake");
        }
        else if (random == 1)
        {
            camAnim.SetTrigger("shake 2");
        }
        else if (random == 2)
        {
            camAnim.SetTrigger("shake 3");
        }
        else if (random == 3)
        {
            camAnim.SetTrigger("shake 4");
        }
    }

}
