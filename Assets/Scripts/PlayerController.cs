using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float speed; //  контроль скорости
    public float jumpForce; // переменная прыжка, указывает на то,
                            // как высоко прыгает персонаж

    private float moveInput; // указывает на то, какие клавиши мы будем нажимать 
    private Rigidbody2D rb; // добавляем физику, необоходим для того,
                            // чтобы объекты могли воспринимаать друг друга

  
    private bool isGrounded; //переменная, которая опеределяет,
                             //находится ли игрок на земле 
    public float checkRadius; // на каком расстоянии от игрока воспринимать землю 

    public Transform groundCheck; //проверяет есть ли земля или нет
    public LayerMask whatIsGround; //что является землей 

    private int extraJumps; //будет указывать количество прыжков
    public int extraJumpsValue;

    [SerializeField] private AudioSource jumpSoundEffect;

    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void FixedUpdate() 
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); 
                                                // окружность будет генерироваться под
                                               // ногами игрока и считывать на полу он или нет


        moveInput = Input.GetAxis("Horizontal"); // если вправо, то значение = 1,
                                                // если влево = -1
        rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y); // скорость, по у
                                                                      // смещение без необходимости
    }


    private void Update()
    {
        if (isGrounded == true) 
        {
            extraJumps = extraJumpsValue;
        }


        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0) 
        {
            jumpSoundEffect.Play();

            rb.velocity = Vector2.up * jumpForce; //мощность, с которой мы прыгаем,
                                                  //умножается на направление
            extraJumps--; // ограничивает количество прыжков
        }else if (Input.GetKeyDown(KeyCode.Space)&& extraJumps == 0 && isGrounded == true)
        {
            jumpSoundEffect.Play();
            rb.velocity = Vector2.up * jumpForce;
        }



       if(Input.GetAxis("Horizontal") < 0) // если идет влево (для того, чтобы развернуть персонажа)
       {
            GetComponent<SpriteRenderer>().flipX = true;
       }
       if(Input.GetAxis("Horizontal") > 0) // если идет вправо (для того, чтобы развернуть персонажа)
       {
            GetComponent<SpriteRenderer>().flipX = false;
       }
       
    }
}
