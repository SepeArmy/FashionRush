using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerInteraction : MonoBehaviour
{
    InputActions inputActions;


    public ParticleSystem efectosHumo;

    public Clothes clothOnHand;


    public Clothes closestCloth;
    public Machine_Patron machine_PatronClose;
    public Machine_Tinte machine_TinteClose;
    public Machine_Coser machine_CoserClose;

    public AudioSource audioSource;
    public AudioClip[] sonidos;

    public Machines closestMachine;

    public ManiquiFinal maniquiFinalClose;

    public Clothes telaPrefab;
    public Clothes tijerasPrefab;
    public Clothes bordadoPrefab;
    public Clothes patronPrefab;
    public Clothes ropaPrefab;

    public Player playerNum;
    private void Awake()
    {
        inputActions = new InputActions();

        //Interact

        if (playerNum == Player.Player1)
        {
            inputActions.Player1.Interact.started += ctx => Interaction();
        }
        if (playerNum == Player.Player2)
        {
            inputActions.Player2.Interact.started += ctx => Interaction();
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.transform.childCount > 0 && other.transform.GetChild(0).TryGetComponent<ParticleSystem>(out ParticleSystem particulas))
        {
            efectosHumo = particulas;
        }

        if (other.gameObject.TryGetComponent<Clothes>(out Clothes cloth))
        {
            closestCloth = cloth;
            print(closestCloth.clothType);
        }
        else if(other.gameObject.TryGetComponent<Machines>(out Machines machines))
        {
            closestMachine = machines;
            print(closestMachine.machineType);
            if (other.gameObject.TryGetComponent<Machine_Patron>(out Machine_Patron machine_Patron))
            {
                machine_PatronClose = machine_Patron;
            }
            else if (other.gameObject.TryGetComponent<Machine_Tinte>(out Machine_Tinte machine_tinte))
            {
                machine_TinteClose = machine_tinte;
            }
            else if (other.gameObject.TryGetComponent<Machine_Coser>(out Machine_Coser machine_coser))
            {
                machine_CoserClose = machine_coser;
            }
        }
        else if (other.gameObject.TryGetComponent<ManiquiFinal>(out ManiquiFinal maniquiFinal))
        {
            maniquiFinalClose = maniquiFinal;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.childCount > 0 && other.transform.GetChild(0).TryGetComponent<ParticleSystem>(out ParticleSystem particulas))
        {
            efectosHumo = null;
        }
        if (other.gameObject.TryGetComponent<Clothes>(out Clothes cloth))
        {
            closestCloth = null;
            print("null");
        }
        else if (other.gameObject.TryGetComponent<Machines>(out Machines machines))
        {
            closestMachine = null;
            if (other.gameObject.TryGetComponent<Machine_Patron>(out Machine_Patron machine_Patron))
            {
                machine_PatronClose = null;
            }
            else if (other.gameObject.TryGetComponent<Machine_Tinte>(out Machine_Tinte machine_tinte))
            {
                machine_TinteClose = null;
            }
            else if (other.gameObject.TryGetComponent<Machine_Coser>(out Machine_Coser machine_coser))
            {
                machine_CoserClose = null;
            }
        }
        else if (other.gameObject.TryGetComponent<ManiquiFinal>(out ManiquiFinal maniquiFinal))
        {
            maniquiFinalClose = null;
        }
        
    }

    public void Interaction()
    {

        #region Maniqui interaction
        if (maniquiFinalClose != null)
        {
            if (clothOnHand == null)
            {
                if(maniquiFinalClose.clothOnManiquiBot != null)
                {
                    clothOnHand = Instantiate(maniquiFinalClose.clothOnManiquiBot, transform.position, Quaternion.identity, transform);
                    Destroy(maniquiFinalClose.clothOnManiquiBot.gameObject);
                }
                else if(maniquiFinalClose.clothOnManiquiTop != null)
                {
                    clothOnHand = Instantiate(maniquiFinalClose.clothOnManiquiTop, transform.position, Quaternion.identity, transform);
                    Destroy(maniquiFinalClose.clothOnManiquiTop.gameObject);
                }
               
            }
            if(clothOnHand.clothType == ClothType.Ropa)
            {
                print("a");
                maniquiFinalClose.PutCloth(clothOnHand);
                Destroy(clothOnHand.gameObject);
            }
        }

        #endregion

        if (clothOnHand != null && closestMachine != null)
        {

            switch (closestMachine.machineType)
            {
                case MachineType.MTela:

                    if(clothOnHand.clothType == ClothType.Tijeras)
                    {
                        audioSource.PlayOneShot(sonidos[3]);
                        efectosHumo.Play();

                        Destroy(clothOnHand.gameObject);
                        clothOnHand = Instantiate(telaPrefab, transform.position, Quaternion.identity, transform);
                    }

                    

                    break;

                case MachineType.MCoser:

                    if (clothOnHand.clothType == ClothType.Patron)
                    {
                        machine_CoserClose.EmpezarCoser();
                        audioSource.PlayOneShot(sonidos[2]);
                        efectosHumo.Play();

                        machine_CoserClose.patron = clothOnHand.ropaType;
                        Destroy(clothOnHand.gameObject);

                    }
                    break;

                case MachineType.MTintes:

                    

                    if(clothOnHand.clothType == ClothType.Ropa)
                    {
                   
                        audioSource.PlayOneShot(sonidos[1]);
                        efectosHumo.Play();

                        //print(machine_PatronClose.nPatron);
                        clothOnHand.tintesType = (TintesType)(machine_TinteClose.nTinte);
                    }



                    break;

                case MachineType.MPatron:



                    if (clothOnHand.clothType == ClothType.Tela)
                    {
                        //closestMachine.PutCloth(clothOnHand);
                        Destroy(clothOnHand.gameObject);
                        machine_PatronClose.EmpezarPatronaje();
                        audioSource.PlayOneShot(sonidos[4]);
                        efectosHumo.Play();



                    }


                    break;

                case MachineType.Table:
                    
                    if(closestMachine.clothOnMachine == null)
                    {
                        audioSource.PlayOneShot(sonidos[5]);

                        print("table");
                        closestMachine.PutCloth(clothOnHand);
                        Destroy(clothOnHand.gameObject);
                    }
                   
                    
                    break;

                case MachineType.Papelera:

                    Destroy(clothOnHand.gameObject);
                    audioSource.PlayOneShot(sonidos[6]);
                    efectosHumo.Play();



                    break;

                default:
                    break;
            }
        }
        
        else if(clothOnHand == null && closestMachine != null)
        {
            switch (closestMachine.machineType)
            {
                

                case MachineType.MPapeleria:

                    efectosHumo.Play();

                    clothOnHand = Instantiate(tijerasPrefab, transform.position, Quaternion.identity, transform);
                    audioSource.PlayOneShot(sonidos[5]);

                    break;

                case MachineType.MTintes:



                    if (clothOnHand == null)
                    {
                        machine_TinteClose.InteractTinte();
                       
                        audioSource.PlayOneShot(sonidos[7]);

                    }


                    break;

                case MachineType.MCoser:

                    

                    if (machine_CoserClose.coserReady)
                    {
                        machine_CoserClose.coserReady = false;
                        clothOnHand = Instantiate(ropaPrefab, transform.position, Quaternion.identity, transform);
                        clothOnHand.clothType = ClothType.Ropa;
                        clothOnHand.ropaType = machine_CoserClose.patron;
                        audioSource.PlayOneShot(sonidos[5]);
                        efectosHumo.Play();



                    }

                    break;

                case MachineType.MPatron:

                    if (!machine_PatronClose.patronReady && !machine_PatronClose.comenzarPatronaje)
                    {
                        machine_PatronClose.InteractPatron();
                        audioSource.PlayOneShot(sonidos[7]);
                        



                    }

                    if (machine_PatronClose.patronReady)
                    {
                        machine_PatronClose.patronReady = false;
                        clothOnHand = Instantiate(patronPrefab, transform.position, Quaternion.identity, transform);
                        clothOnHand.clothType = ClothType.Patron;
                        audioSource.PlayOneShot(sonidos[5]);
                        efectosHumo.Play();


                        //print(machine_PatronClose.nPatron);
                        clothOnHand.ropaType = (RopaType)(machine_PatronClose.nPatron +1); 
                    }

                    break;


                default:
                    break;
            }

            
            if (clothOnHand == null && closestMachine.machineType == MachineType.Table && closestMachine.clothOnMachine != null)
            {
                clothOnHand = Instantiate(closestMachine.clothOnMachine, transform.position, Quaternion.identity, transform);
                Destroy(closestMachine.clothOnMachine.gameObject);
                audioSource.PlayOneShot(sonidos[5]);


            }



        }
        
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
