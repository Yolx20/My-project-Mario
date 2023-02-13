using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 5;
    private bool facingRight = true;
    private float horizontalMove;
    public Animator animator;
    public int jumpPower = 35;//cuanto salta el personaje
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;//si esta en el suelo

    public bool isCrouch;
    private float jumpTimeCounter;//contador de tiempo
    public float jumpTime;//tiempo de salto
    private bool isJumping;//si estoy saltando

    public static bool death;
    public static bool growUp;
    public static bool isStarUp;
    public static bool isFlowerUp;
    private float countdown = 0.5f;
    private float starCount = 12f;

    public Transform fireSpawn;
    public GameObject fireBall;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        death = false;
        growUp = false;
        isStarUp = false;
    }
     void FixedUpdate()
    {
        if (isCrouch)
        {

        }
        horizontalMove = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));//para que se mueva en horizontal y math para que el numero no sea negativo en speed - parametres
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y); 
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        animator.SetBool("IsGrounded", isGrounded); 
       if(horizontalMove<0.0f && facingRight)
        {
            FlipPlayer();
        } 
       if (horizontalMove > 0.0f && !facingRight)
        {
            FlipPlayer();
        }
        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded) 
        {
            Jump();
        }

        if(Input.GetKey(KeyCode.Space)&& isJumping)
        {
            if(jumpTimeCounter>0)
            {
                rb.velocity = Vector2.up * jumpPower;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if (death)
        {
            speed = 0;
            jumpPower = 0;
            animator.SetTrigger("Death");
            countdown -= Time.deltaTime;
            if (countdown > 0f)
            {
                Invoke("Death", 0.5f);
            }

            if(transform.position.y< -30 )
            SceneManager.LoadScene("SampleScene"); //para volver a llamar al personaje a escena despues de su muerte
        }

        if (growUp)
        {   //para que el personaje crezca cuando coje el champi
            animator.SetBool("GrowUp", growUp);
            if (Input.GetKey(KeyCode.DownArrow))
            {
                isCrouch = true;
                animator.SetBool("IsCrouch", isCrouch);
                speed = 0;
            }

            if (!Input.GetKey(KeyCode.DownArrow)&& isGrounded)
            {
                isCrouch = false;
                animator.SetBool("IsCrouch", isCrouch);
            }

            if (isFlowerUp)
            {
                animator.SetBool("IsFlowerUp", isFlowerUp);
                if (Input.GetKeyDown(KeyCode.C))
                {
                    animator.SetBool("Shooting", true);
                    Instantiate(fireBall, fireSpawn.position, fireSpawn.rotation);
                }
                else
                {
                    animator.SetBool("Shooting", false);
                }
            }
        }

        if (isStarUp)
        {
            starCount -= Time.deltaTime * 1;

            if(starCount > 0)
            {
                animator.SetBool("isStarUp", isStarUp);

                if(starCount<2&&starCount > 0)
                {
                    animator.SetBool("IsStarUp", false);
                    animator.SetBool("StarEnd", true);
                }
            }
            else
            {
                animator.SetBool("StarEnd", false);
                starCount = 12f;
                isStarUp = false;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("void"))
        {
            SceneManager.LoadScene("SampleScene");
        } 
    }
    void FlipPlayer()
    {//para que el personaje gire la cara en x de un lado a otro
      facingRight =! facingRight;
        Vector2 playerScale = gameObject.transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;  
    }

    void Jump() 
    {
        rb.velocity=Vector2.up*jumpPower;
        isJumping = true;
        jumpTimeCounter = jumpTime;
    }

    void Death()
    {
        GetComponent<Collider2D>().isTrigger = true; 
        rb.velocity = new Vector2(rb.velocity.x, 5f);
    }
        
    //parte19
}
