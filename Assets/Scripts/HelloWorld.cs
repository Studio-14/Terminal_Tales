using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    private int count;
    private bool buttonPressed;
    
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        buttonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        float jumpInput = Input.GetAxisRaw("Jump");

        if ((jumpInput >= 1) && (!buttonPressed))
        {
            buttonPressed = true;
            count++;
            Debug.Log("Hello world #" + count);
        }
        else if (buttonPressed && (jumpInput < 1))
        {
            buttonPressed = false;
        }
    }
}
