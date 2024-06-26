using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine_Coser : MonoBehaviour
{

    public bool coserReady;

    public bool comenzarCoser;

    public float tiempoCoser;

    public float maxTiempoCoser;

    public RopaType patron;

    public Image fillBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (comenzarCoser)
        {
            tiempoCoser += Time.deltaTime;

            fillBar.fillAmount = tiempoCoser / maxTiempoCoser;

            if (tiempoCoser >= maxTiempoCoser)
            {
                coserReady = true;
                comenzarCoser = false;
                tiempoCoser = 0;
            }

        }
    }

    public void EmpezarCoser()
    {
        comenzarCoser = true;



    }
}
