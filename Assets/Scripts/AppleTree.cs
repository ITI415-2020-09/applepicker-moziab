using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AppleTree : MonoBehaviour
{   
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public float speed = 10f;
    public float leftAndRightEdge = 22f;
    public float chanceToChangeDirections = 0.02f;
    public float secondsBetweenAppleDrops = 1f;

    public GameObject poisonapplePrefab;
    public float chanceToDropPoisonApple = 0.05f;


    void Start()
    {
        Invoke("DropApple", 2f);
    }

  void DropApple()
    {
        if (Random.value < chanceToDropPoisonApple)
        {
            GameObject poisonapple = Instantiate<GameObject>(poisonapplePrefab);
            poisonapple.transform.position = transform.position;
            Invoke("DropApple", secondsBetweenAppleDrops);
        }
        else
        {

            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
            Invoke("DropApple", secondsBetweenAppleDrops);
        }
    }
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        } 
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
