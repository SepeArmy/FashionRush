using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_Tinte : MonoBehaviour
{
    public bool tinteReady;

    

    public Sprite[] tintes;

    public int nTinte;

    public SpriteRenderer tinteVisual;

    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void InteractTinte()
    {
        print(nTinte);
        nTinte++;
        if (nTinte > 3)
        {
            nTinte = 0;
        }
        tinteVisual.sprite = tintes[nTinte];
        
        

       
    }

   
}
