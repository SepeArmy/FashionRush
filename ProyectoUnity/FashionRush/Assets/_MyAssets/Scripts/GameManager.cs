using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager THIS;

    public float score;

    private void Awake()
    {
        if (THIS == null)
        {
            THIS = this;
            DontDestroyOnLoad(gameObject);
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else Destroy(gameObject);

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
