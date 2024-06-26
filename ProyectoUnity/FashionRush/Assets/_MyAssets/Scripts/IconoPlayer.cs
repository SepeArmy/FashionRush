using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class IconoPlayer : MonoBehaviour
{
    public Image sprite;
    public Sprite[] sprites;
    public PlayerInteraction player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.clothOnHand != null)
        {
            sprite.color = Color.white ;

            if(player.clothOnHand.clothType == ClothType.Tijeras)
                sprite.sprite = sprites[20];

            if (player.clothOnHand.clothType == ClothType.Tela)
                sprite.sprite = sprites[21];

            if(player.clothOnHand.clothType == ClothType.Patron)
            {
                if (player.clothOnHand.ropaType == RopaType.CamisetaCorta)
                    sprite.sprite = sprites[22];
                if (player.clothOnHand.ropaType == RopaType.CamisetaLarga)
                    sprite.sprite = sprites[23];
                if (player.clothOnHand.ropaType == RopaType.PantalonCorto)
                    sprite.sprite = sprites[24];
                if (player.clothOnHand.ropaType == RopaType.PantalonLargo)
                    sprite.sprite = sprites[25];
                if (player.clothOnHand.ropaType == RopaType.Falda)
                    sprite.sprite = sprites[26];
            }
            if (player.clothOnHand.ropaType == RopaType.CamisetaCorta)
            {
                switch ((TintesType)player.clothOnHand.tintesType)
                {
                    case TintesType.Blanco:
                        sprite.sprite = sprites[0];
                        break;
                    case TintesType.Rojo:
                        sprite.sprite = sprites[1];
                        break;
                    case TintesType.Azul:
                        sprite.sprite = sprites[2];
                        break;
                    case TintesType.Negro:
                        sprite.sprite = sprites[3];
                        break;
                    default:
                        break;
                }
            }
            if (player.clothOnHand.ropaType == RopaType.CamisetaLarga)
            {
                switch ((TintesType)player.clothOnHand.tintesType)
                {
                    case TintesType.Blanco:
                        sprite.sprite = sprites[4];
                        break;
                    case TintesType.Rojo:
                        sprite.sprite = sprites[5];
                        break;
                    case TintesType.Azul:
                        sprite.sprite = sprites[6];
                        break;
                    case TintesType.Negro:
                        sprite.sprite = sprites[7];
                        break;
                    default:
                        break;
                }
            }
            if (player.clothOnHand.ropaType == RopaType.PantalonCorto)
            {
                switch ((TintesType)player.clothOnHand.tintesType)
                {
                    case TintesType.Blanco:
                        sprite.sprite = sprites[8];
                        break;
                    case TintesType.Rojo:
                        sprite.sprite = sprites[9];
                        break;
                    case TintesType.Azul:
                        sprite.sprite = sprites[10];
                        break;
                    case TintesType.Negro:
                        sprite.sprite = sprites[11];
                        break;
                    default:
                        break;
                }
            }
            if (player.clothOnHand.ropaType == RopaType.PantalonLargo)
            {
                switch ((TintesType)player.clothOnHand.tintesType)
                {
                    case TintesType.Blanco:
                        sprite.sprite = sprites[12];
                        break;
                    case TintesType.Rojo:
                        sprite.sprite = sprites[13];
                        break;
                    case TintesType.Azul:
                        sprite.sprite = sprites[14];
                        break;
                    case TintesType.Negro:
                        sprite.sprite = sprites[15];
                        break;
                    default:
                        break;
                }
            }
            if (player.clothOnHand.ropaType == RopaType.Falda)
            {
                switch ((TintesType)player.clothOnHand.tintesType)
                {
                    case TintesType.Blanco:
                        sprite.sprite = sprites[16];
                        break;
                    case TintesType.Rojo:
                        sprite.sprite = sprites[17];
                        break;
                    case TintesType.Azul:
                        sprite.sprite = sprites[18];
                        break;
                    case TintesType.Negro:
                        sprite.sprite = sprites[19];
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            sprite.color = Color.clear;
        }
        
    }
}
