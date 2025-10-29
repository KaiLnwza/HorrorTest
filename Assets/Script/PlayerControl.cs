using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Logic : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed=20;
    public GameObject player;
    bool RightCross = false;
    bool LeftCross = false;
    bool firstcross=false;
    public GameObject Guide;
    public GameObject GuideL;
    public static bool passed_3;
    public float originalScaleX;
    public bool movable = true;
    float Crossing = 5f;
    bool crossingleft = false;
    bool crossingright = false;
    public GameObject Logblock;
    public static bool firstwarp = false;
    bool climb = false;
    bool climbing = false;
    bool grounded = true;
    bool firstclimb=false;
    

    // Start is called before the first frame update
    void Start()
    {
        Guide.SetActive(false);
        originalScaleX = Mathf.Abs(transform.localScale.x);
        passed_3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerWorldPosition = transform.position;
        float xPosition = playerWorldPosition.x;
        // Player Position Check
        if (NewBehaviourScript.slow == true)
        {
            speed = 5;
        }
        else if (NewBehaviourScript.Final==true)
        {
            speed= 3;
        }
        else
        {
            speed = 20;
        }
        // speed adjust 
        if (NewBehaviourScript.Traveling != true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            if (movable == true)
            {
               
                Vector2 movement = new Vector2(moveHorizontal, 0f);

                
                if (moveHorizontal > 0)
                {
                    //player.transform.Translate(Vector2.right * speed * Time.deltaTime);
                    // Face right
                    transform.localScale = new Vector3(originalScaleX, transform.localScale.y, transform.localScale.z);
                }
                else if (moveHorizontal < 0)
                {

                    // Face left by making the X scale negative
                    transform.localScale = new Vector3(-originalScaleX, transform.localScale.y, transform.localScale.z);
                    //player.transform.Translate(Vector2.left * speed * Time.deltaTime);
                }
                if (NewBehaviourScript.Traveling == true)
                {
                    moveHorizontal = 0;
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0f;
                }
                else
                {
                    rb.velocity = movement * speed;
                }
            }

           
            //Player movement
            if (LeftCross == true && Input.GetKeyDown(KeyCode.J)&&crossingright!=true)
            {
                Logblock.SetActive(false);
                movable = false;
                crossingleft = true;
                firstcross = true; 
            }
        if (RightCross == true && Input.GetKeyDown(KeyCode.J) && crossingleft != true)
            {
                Logblock.SetActive(false);
                crossingright = true;
                movable = false;
            }
            //Cross Logic
        }
        if (crossingleft == true&&LeftCross == true)
        {
            rb.velocity = Vector2.zero;
            player.transform.Translate(Vector2.right * Crossing * Time.deltaTime);
        }
        if (crossingright == true&& RightCross == true)
        {
            rb.velocity = Vector2.zero;
            player.transform.Translate(Vector2.left * Crossing * Time.deltaTime);
        }

        if (NewBehaviourScript.gift_accept==true&&grounded==true&&climb == true && Input.GetKeyDown(KeyCode.J)&&NewBehaviourScript.getgift!=true)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            movable = false;
            climbing = true;
            grounded = false;
            Guide.SetActive(false);
            firstclimb = true;

        }
        if(climbing==true)
        {
            player.transform.Translate(Vector2.up * Crossing * Time.deltaTime);
            rb.gravityScale = 0f;
        }
        //lamp climbing
        
    }
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("QTE"))
        {

            LeftCross = true;
            if (firstcross == false)
            {
                Guide.SetActive(true);
            }
            //not text after first cross
        }
        if (collision.gameObject.CompareTag("QTE2"))
        {

            RightCross = true;
        }
        if (collision.gameObject.CompareTag("Text"))
        {
            GuideL.SetActive(false);
        }
        if (collision.gameObject.CompareTag("WarpText"))
        {
            if (firstwarp != true)
            {
                Guide.SetActive(true);
            }
        }
        if (collision.gameObject.CompareTag("QuestText") && NewBehaviourScript.quest_check == true)
        {
            if (NewBehaviourScript.firstpick != true)
            {
                Guide.SetActive(true);
            }
        }
        if (collision.gameObject.CompareTag("Lamp")&& NewBehaviourScript.gift_accept == true )
        {
            if (firstclimb!=true)
            {
                Guide.SetActive(true);
            }
            climb = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("QuestText") && NewBehaviourScript.quest_check == true)
        {
            Guide.SetActive(false);
        }
        if (collision.gameObject.CompareTag("QTE"))
        {
            
            Guide.SetActive(false);
        }
        if (collision.gameObject.CompareTag("QTE2"))
        {
            
            
        }
        if (collision.gameObject.CompareTag("LeftRight"))
        {
            LeftCross = false;
            Logblock.SetActive(true);
            crossingleft = false;
            movable = true;
            
        }
        if (collision.gameObject.CompareTag("RightLeft"))
        {
            RightCross = false;
            Logblock.SetActive(true);
            crossingright = false;
            movable = true;
        }
        if (collision.gameObject.CompareTag("WarpText"))
        {
            Guide.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Lamp"))
        {
            rb.gravityScale = 10f;
            climb = false;
            climbing = false;
            Guide.SetActive(false );
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            movable = true;
            grounded = true;
        }
    }
}
