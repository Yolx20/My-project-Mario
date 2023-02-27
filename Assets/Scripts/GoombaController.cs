using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour
{
    public int speed;
    private bool moveRight;//para saber a donde se mueve
    private bool isCrushed;
    public Animator animator;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight) 
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }

        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("tube") || (collision.gameObject.CompareTag("enemies")))
        {
            if (moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }

            if (collision.gameObject.tag == "Player")
            {
                float yOffset = 0.5f;
                if (transform.position.y+yOffset  < collision.transform.position.y)
                {
                    player.GetComponent<Rigidbody2D>().velocity = Vector2.up * 7;//para que de un ligero saltito a la hora de matar a un goomba
                    isCrushed = true;
                    animator.SetBool("IsCrushed", isCrushed);
                    speed = 0;
                    Invoke("Death", 1);
                   
                }
                else
                {
                    PlayerControler.death = true; 
                }
            }
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

}
