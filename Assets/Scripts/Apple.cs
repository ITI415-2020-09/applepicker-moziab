using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    public static float bottomY = -20f;
   
    void Update()
    {

        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            if (this.gameObject.CompareTag("Apple"))
            {


                ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
                apScript.AppleDestroyed();
            }
        }
    }
}