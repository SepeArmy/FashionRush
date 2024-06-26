using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VueltaMenu : MonoBehaviour
{

    InputActions inputActions;

    private void Awake()
    {
        inputActions = new InputActions();

        //Interact

       
            inputActions.Player1.Salida.started += ctx => SceneManager.LoadScene(0);
        


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
