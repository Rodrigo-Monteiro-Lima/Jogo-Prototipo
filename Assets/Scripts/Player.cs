using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Attributes")]
    public float speed;
    public float jumpForce;
    public int hp;
    public int apple;

    [Header("Components")]
    public Rigidbody2D rig;
    public Animator anim;
    public SpriteRenderer sprite;

    [Header("UI")]
    public TextMeshProUGUI appleText;
    public TextMeshProUGUI lifeText;
    public GameObject gameOver;


    private Vector2 direction;
    private bool isGrounded;
    private bool recovery;
    private int count = 0;

    void Start()
    {
      lifeText.text = hp.ToString();
      Time.timeScale = 1;
      DontDestroyOnLoad(gameObject);
    //   FindObjectOfType<CinemachineVirtualCamera>().Follow = transform;
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        Jump();
        PlayAnim();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        rig.velocity = new Vector2(direction.x * speed, rig.velocity.y);
    }

    void Jump()
    {
        if (count < 2)
        {
            if(Input.GetButtonDown("Jump") /*&& isGrounded*/)
            {
            count++;
                // anim.SetInteger("transition", 2);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                // isGrounded = false;
            }

        } else {
            count = 0;
        }
    }

    void Death()
    {
        if(hp <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void PlayAnim()
    {
        if(direction.x > 0)
        {
            if(isGrounded)
            {
            anim.SetInteger("transition", 1);
            }

            transform.eulerAngles = new Vector2(0, 0);
        }

         if(direction.x < 0)
        {   
            if(isGrounded)
            {
            anim.SetInteger("transition", 1);
            }

            transform.eulerAngles = new Vector2(0, 180);
        }

        if(direction.x == 0 && isGrounded)
        {        
            anim.SetInteger("transition", 0);            
        }
    }

    public void Hit()
    {
        if(!recovery)
        {
        StartCoroutine(Flick());
        }
    }

    IEnumerator Flick()
    {   
        recovery = true;
        hp--;
        Death();
        lifeText.text = hp.ToString();
        sprite.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1, 1, 1, 1);
        recovery = false;
    }

    public void IncreaseScore()
    {
        apple++;
        appleText.text = apple.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
         if(other.gameObject.layer == 6)
        {
            isGrounded = true;
        }  
    }
}
