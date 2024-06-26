using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimation : MonoBehaviour
{
    //adjust this to change speed
    float speed = 5f;
    //adjust this to change how high it goes
    float height = 0.3f;

    public Vector3 originalPos;
    private void Start()
    {

    }
    void Update()
    {
        //get the objects current position and put it in a variable so we can access it later with less code
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(originalPos.x, newY * height + 2, originalPos.z);
    }
}
