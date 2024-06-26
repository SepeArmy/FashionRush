using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machines : MonoBehaviour
{

    public MachineType machineType;
    public Clothes clothOnMachine;

    public Transform clothPosition;



    public void PutCloth(Clothes clothes)
    {
       
        clothOnMachine = Instantiate(clothes, clothPosition.position, Quaternion.identity, clothPosition);


        
    }
}

public enum MachineType
{
    MTela,
    MCoser,
    MPapeleria,
    MTintes,
    MPatron,
    Papelera,
    Table


}