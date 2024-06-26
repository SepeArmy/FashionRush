using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public Comanda comandaPrefab;

    public GameObject papeleria;
    public bool papeleriaCheck;
    public GameObject maquinaTela;
    public bool maquinaTelaCheck;
    public GameObject mesa;
    public bool mesa10Check;
    public bool mesa11Check;
    public bool mesa20Check;
    public bool mesa21Check;
    public GameObject maquinaPatron;
    public bool maquinaPatron1Check;
    public bool maquinaPatron2Check;
    public GameObject maquinaCoser;
    public bool maquinaCoserCheck;
    public GameObject maquinaTintar;
    public bool maquinaTintar1Check;
    public bool maquinaTintar2Check;
    public GameObject maniqui;
    public bool maniquiCheck;

    public Transform comandasParent;

    public Comanda comandaATerminar;

    public ArrowAnimation arrowTutorial;

    public PlayerInteraction player;

    public Machines mesaMachine;
    public Machine_Patron patronMachine;
    public Machine_Tinte tinteMachine;

    public int nPatron;
    public int nTinte;
    public bool player1;
    void Start()
    {
        if (player1)
        {
            comandaPrefab.ropaTop.clothType = ClothType.Ropa;
            comandaPrefab.ropaTop.tintesType = TintesType.Rojo;
            comandaPrefab.ropaTop.ropaType = RopaType.CamisetaLarga;
            comandaPrefab.ropaBot.clothType = ClothType.Ropa;
            comandaPrefab.ropaBot.tintesType = TintesType.Negro;
            comandaPrefab.ropaBot.ropaType = RopaType.PantalonLargo;

            comandaATerminar = Instantiate(comandaPrefab, comandasParent);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!papeleriaCheck)
        {
            arrowTutorial.originalPos = papeleria.transform.position;
        }
        else if (!maquinaTelaCheck)
        {
            arrowTutorial.originalPos = maquinaTela.transform.position;
        }
        else if (!mesa10Check)
        {
            arrowTutorial.originalPos = mesa.transform.position;
        }
        else if (!maquinaPatron1Check)
        {
            arrowTutorial.originalPos = maquinaPatron.transform.position;
        }
        else if (!mesa11Check)
        {
            arrowTutorial.originalPos = mesa.transform.position;
        }
        else if (!maquinaPatron2Check)
        {
            arrowTutorial.originalPos = maquinaPatron.transform.position;
        }
        else if (!maquinaCoserCheck)
        {
            arrowTutorial.originalPos = maquinaCoser.transform.position;
        }
        else if (!mesa20Check)
        {
            arrowTutorial.originalPos = mesa.transform.position;
        }
        else if (!maquinaTintar1Check)
        {
            arrowTutorial.originalPos = maquinaTintar.transform.position;
        }
        else if (!mesa21Check)
        {
            arrowTutorial.originalPos = mesa.transform.position;
        }
        else if (!maquinaTintar2Check)
        {
            arrowTutorial.originalPos = maquinaTintar.transform.position;
        }
        else if (!maniquiCheck)
        {
            arrowTutorial.originalPos = maniqui.transform.position;
        }



        if (player.clothOnHand != null && player.clothOnHand.clothType == ClothType.Tijeras)
        {
            papeleriaCheck = true;
        }
        if (player.clothOnHand != null && player.clothOnHand.clothType == ClothType.Tela)
        {
            maquinaTelaCheck = true;
        }
        if (mesaMachine.clothOnMachine != null && mesaMachine.clothOnMachine.clothType == ClothType.Tela)
        {
            mesa10Check = true;
        }
        if (patronMachine.nPatron == nPatron)
        {
            maquinaPatron1Check = true;
        }
        if (player.clothOnHand != null && mesaMachine.clothOnMachine == null && patronMachine.nPatron == nPatron)
        {
            mesa11Check = true;
        }
        if (player.clothOnHand != null && player.clothOnHand.clothType == ClothType.Patron)
        {
            maquinaPatron2Check = true;
        }
        if (player.clothOnHand != null && player.clothOnHand.clothType == ClothType.Ropa)
        {
            maquinaCoserCheck = true;
        }       


        if (mesaMachine.clothOnMachine != null && mesaMachine.clothOnMachine.clothType == ClothType.Ropa)
        {
            mesa20Check = true;
        }
        if (tinteMachine.nTinte == nTinte)
        {
            maquinaTintar1Check = true;
        }
        if (player.clothOnHand != null && mesaMachine.clothOnMachine == null && player.clothOnHand.clothType == ClothType.Ropa && tinteMachine.nTinte == nTinte)
        {
            mesa21Check = true;
        }
        if (player.clothOnHand != null && player.clothOnHand.tintesType != TintesType.Blanco)
        {
            maquinaTintar2Check = true;
        }
    }
}
