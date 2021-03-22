using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //paddle and mouse moving together
        float mousePosition_x = Mathf.Clamp((Input.mousePosition.x / Screen.width) * 14 + 1,1.1f,14.9f);// x 1-15
        Vector2 paddlePos = new Vector2(mousePosition_x,transform.position.y);//paddle script position
        transform.position = paddlePos;


    }
}
