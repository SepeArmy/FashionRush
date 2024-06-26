using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentajasManager : MonoBehaviour
{
    public HardAdvantage hardAdvantage;
    public SoftAdvantage softAdvantage;
    public VelcroAdvantage velcroAdvantage;

    public float instantiationRate;

    void Start()
    {
        StartCoroutine(AdvantageInstantiator());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AdvantageInstantiator()
    {
        while (true)
        {
            yield return new WaitForSeconds(instantiationRate);
            
            if (transform.childCount < 5)
            {
                switch (Random.Range(0, 3)) // Random.Range(0, 3)
                {
                    case 0:
                        HardAdvantage cloneHard = Instantiate(hardAdvantage, new Vector3(Random.Range(-13, -1.50f), 2.50f, Random.Range(17.33f, 28.25f)), Quaternion.identity, transform);
                        Destroy(cloneHard.gameObject, 5f);
                        break;
                    case 1:
                        SoftAdvantage cloneSoft = Instantiate(softAdvantage, new Vector3(Random.Range(-13, -1.50f), 2.50f, Random.Range(17.33f, 28.25f)), Quaternion.identity, transform);
                        Destroy(cloneSoft.gameObject, 5f);

                        break;
                    case 2:
                        VelcroAdvantage cloneVelcro = Instantiate(velcroAdvantage, new Vector3(Random.Range(-13, -1.50f), 2.50f, Random.Range(17.33f, 28.25f)), Quaternion.identity, transform);
                        Destroy(cloneVelcro.gameObject, 5f);

                        break;
                }
            }
            
        }
        
    }
}
