using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TwoScene_Logic : MonoBehaviour
{
    bool warpright=false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (warpright == true && Input.GetKeyDown(KeyCode.E)&& Logic.passed_3==true)
        {
            SceneManager.LoadScene("3_Clear");
        }
        else if(warpright == true && Input.GetKeyDown(KeyCode.E) && Logic.passed_3 == false)
        {
            SceneManager.LoadScene("3_Village");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    
    
    {
        
        if (collision.gameObject.CompareTag("WarpRight"))
        {
            warpright = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("WarpRight"))
        {
            warpright = false;
        }
    }
}
