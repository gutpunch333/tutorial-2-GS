using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public GameObject player;
    
    public GameObject winObj;
    public GameObject loseObj;
    public SpriteRenderer sr;

    public float speed;

    public Text score;
    public Text lives;

    public int scoreValue = 0;
    private int livesValue = 3;

    Animator anim;

    

    // Start is called before the first frame update
    void Start()
    {
        
        rd2d = GetComponent<Rigidbody2D>();
        score.text = "Score: " + scoreValue.ToString();
        lives.text = "Lives: " + livesValue.ToString();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        if ((hozMovement == 0) && (vertMovement == 0))
        {
            anim.SetInteger("State", 0);
        }
        else if ((hozMovement != 0) && (vertMovement == 0))
        {
            anim.SetInteger("State", 1);
        }
        else
        {
            anim.SetInteger("State", 2);
        }
 

    }

    void Update()

{
   
        if (Input.GetKeyDown(KeyCode.A))

        {
            sr.flipX=true;
          //anim.SetInteger("State", 1);

         }

     /*if (Input.GetKeyUp(KeyCode.A))

        {

          anim.SetInteger("State", 0);

         }*/

     if (Input.GetKeyDown(KeyCode.D))

        {
           sr.flipX=false;
          //anim.SetInteger("State", 1);

         }

     /*if (Input.GetKeyUp(KeyCode.D))

        {

          anim.SetInteger("State", 0);

         } 

         if (Input.GetKeyDown(KeyCode.W))

        {

          anim.SetInteger("State", 2);

         }*/

    
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = "Score: " + scoreValue.ToString();
            if (scoreValue == 4)
            {
                player.transform.position = new Vector2(15, 43);
                livesValue = 3;
                lives.text = "Lives: " + livesValue.ToString();
            }
            if (scoreValue == 8)
            {
                winObj.SetActive(true);
            }
           
            
            Destroy(collision.collider.gameObject);
        }

        if (collision.collider.tag == "Enemy")
        {
            livesValue = livesValue - 1;
            lives.text = "Lives: " + livesValue.ToString();
            Destroy(collision.collider.gameObject);
            if (livesValue <= 0){
                Destroy(player.gameObject);
                loseObj.SetActive(true);
            }
            
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse); //the 3 in this line of code is the player's "jumpforce," and you change that number to get different jump behaviors.  You can also create a public variable for it and then edit it in the inspector.
            }
        } 
        
        
    }
}
