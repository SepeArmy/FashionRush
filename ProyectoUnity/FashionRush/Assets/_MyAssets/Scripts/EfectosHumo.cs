using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectosHumo : MonoBehaviour
{

    public ParticleSystem humito = null;

    // Start is called before the first frame update
    void Start()
    {
        humito = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarEfecto()
    {
        print("bd");
        humito.Play();
    }
}
