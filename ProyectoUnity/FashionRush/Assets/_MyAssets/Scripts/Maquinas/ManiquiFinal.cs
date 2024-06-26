using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManiquiFinal : MonoBehaviour
{
    public Clothes clothOnManiquiTop;
    public Clothes clothOnManiquiBot;

    public ComandasManager comandasManager;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PutCloth(Clothes clothes)
    {
        print("asdgvasfgfh");

        if (clothes.ropaType == RopaType.CamisetaCorta || clothes.ropaType == RopaType.CamisetaLarga)
        {
            clothOnManiquiTop = Instantiate(clothes, transform.GetChild(1).GetChild(0).position, Quaternion.identity, transform.GetChild(1).GetChild(0));
        }
        else
        {
            clothOnManiquiBot = Instantiate(clothes, transform.GetChild(1).GetChild(1).position, Quaternion.identity, transform.GetChild(1).GetChild(1));
        }
        
        if(comandasManager != null)
        {
            foreach (Comanda comanda in comandasManager.comandasList)
            {
                if (clothOnManiquiBot == comanda.ropaBot && clothOnManiquiTop == comanda.ropaTop)
                {
                    comandasManager.ComandaFinished(comanda);
                    Destroy(clothOnManiquiTop.gameObject);
                    Destroy(clothOnManiquiBot.gameObject);
                    break;
                }
            }
        }
        if(comandasManager == null)
        {
            if (clothOnManiquiTop != null && clothOnManiquiBot != null)
            {
                SceneManager.LoadScene(2);
            }
        }
        
        
         


    }
}
