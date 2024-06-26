using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Machine_Patron : MonoBehaviour
{
    public bool patronReady;

    public bool comenzarPatronaje;

    public Sprite[] patrones;

    public int nPatron;

    public SpriteRenderer patronVisual;

    public float tiempoPatron;

    public float maxTiempoPatron;

    public Image fillBar;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (comenzarPatronaje)
        {
            tiempoPatron += Time.deltaTime;

            fillBar.fillAmount = tiempoPatron/maxTiempoPatron;
            if (tiempoPatron >= maxTiempoPatron)
            {
                patronReady = true;
                comenzarPatronaje = false;
                tiempoPatron = 0;
            }

        }
    }

    public void InteractPatron()
    {
        print(nPatron);
        nPatron++;

        if (nPatron > 4)
        {
            nPatron = 0;
        }
        patronVisual.sprite = patrones[nPatron];
        
        

       
    }

    public void EmpezarPatronaje()
    {
        comenzarPatronaje = true;
        
       

    }

}
