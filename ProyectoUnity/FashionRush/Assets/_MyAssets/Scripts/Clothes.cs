using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour
{
    public ClothType clothType;

    public TintesType tintesType;

    public RopaType ropaType;


    public Clothes clothOnManiquiTop;
    public Clothes clothOnManiquiBot;
}

public enum ClothType
{
    Tela,
    Tijeras,
    Patron,
    Ropa
}

public enum RopaType
{
    None = 0,
    CamisetaCorta = 1,
    CamisetaLarga = 2,
    PantalonCorto = 3,
    PantalonLargo = 4,
    Falda = 5
    
}

public enum BordadoType
{
    None = 0,
    Flor = 1,
    Sol = 2
}

public enum TintesType
{
    Blanco = 0,
    Rojo = 1,
    Azul = 2,
    Negro = 3
    
}
