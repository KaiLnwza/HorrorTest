using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupleLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(NewBehaviourScript.getgift==true)
        {
            transform.position = new Vector2(248, -3f);
        }
    }
}
