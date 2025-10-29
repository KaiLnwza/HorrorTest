using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gm_logic : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody2D rb;
    public GameObject gm;
    public GameObject cleargm;
    public GameObject cleartrash;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gm.transform.Translate(Vector2.right*speed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    
    {
        if (collision.gameObject.CompareTag ("Finish"))
        {
            gm.SetActive(false);
            cleartrash.SetActive(false);
            Logic.passed_3=true;
        }
    }
}
