using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Comanda : MonoBehaviour
{
    public Clothes ropaTop;
    public Clothes ropaBot;

    public float countDown = 100f;

    public Image TopSprite;
    public Image BotSprite;

    public Sprite[] sprites;
    
    void Start()
    {

        ropaTop.ropaType = (RopaType)Random.Range(1, 3);
        ropaTop.tintesType = (TintesType)Random.Range(0, 4);

        ropaBot.ropaType = (RopaType)Random.Range(3, 6);
        ropaBot.tintesType = (TintesType)Random.Range(0, 4);

        if(ropaTop.ropaType == RopaType.CamisetaCorta)
        {
            switch ((TintesType)ropaTop.tintesType)
            {
                case TintesType.Blanco:
                    TopSprite.sprite = sprites[0];
                    break;
                case TintesType.Rojo:
                    TopSprite.sprite = sprites[1];
                    break;
                case TintesType.Azul:
                    TopSprite.sprite = sprites[2];
                    break;
                case TintesType.Negro:
                    TopSprite.sprite = sprites[3];
                    break;
                default:
                    break;
            }
        }
        if (ropaTop.ropaType == RopaType.CamisetaLarga)
        {
            switch ((TintesType)ropaTop.tintesType)
            {
                case TintesType.Blanco:
                    TopSprite.sprite = sprites[4];
                    break;
                case TintesType.Rojo:
                    TopSprite.sprite = sprites[5];
                    break;
                case TintesType.Azul:
                    TopSprite.sprite = sprites[6];
                    break;
                case TintesType.Negro:
                    TopSprite.sprite = sprites[7];
                    break;
                default:
                    break;
            }
        }
        if (ropaBot.ropaType == RopaType.PantalonCorto)
        {
            switch ((TintesType)ropaBot.tintesType)
            {
                case TintesType.Blanco:
                    BotSprite.sprite = sprites[8];
                    break;
                case TintesType.Rojo:
                    BotSprite.sprite = sprites[9];
                    break;
                case TintesType.Azul:
                    BotSprite.sprite = sprites[10];
                    break;
                case TintesType.Negro:
                    BotSprite.sprite = sprites[11];
                    break;
                default:
                    break;
            }
        }
        if (ropaBot.ropaType == RopaType.PantalonLargo)
        {
            switch ((TintesType)ropaBot.tintesType)
            {
                case TintesType.Blanco:
                    BotSprite.sprite = sprites[12];
                    break;
                case TintesType.Rojo:
                    BotSprite.sprite = sprites[13];
                    break;
                case TintesType.Azul:
                    BotSprite.sprite = sprites[14];
                    break;
                case TintesType.Negro:
                    BotSprite.sprite = sprites[15];
                    break;
                default:
                    break;
            }
        }
        if (ropaBot.ropaType == RopaType.Falda)
        {
            switch ((TintesType)ropaBot.tintesType)
            {
                case TintesType.Blanco:
                    BotSprite.sprite = sprites[16];
                    break;
                case TintesType.Rojo:
                    BotSprite.sprite = sprites[17];
                    break;
                case TintesType.Azul:
                    BotSprite.sprite = sprites[18];
                    break;
                case TintesType.Negro:
                    BotSprite.sprite = sprites[19];
                    break;
                default:
                    break;
            }
        }


        print(ropaTop.ropaType);
        print(ropaTop.tintesType);
        print(ropaBot.ropaType);
        print(ropaBot.tintesType);
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if(countDown <= 0)
        {
            Destroy(gameObject);
        }
    }
}
