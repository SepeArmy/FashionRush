using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ComandasManager : MonoBehaviour
{

    public Comanda comandaPrefab;

    public Transform comandasParent;

    public List<Comanda> comandasList = new List<Comanda>();

    public Image gameOverImage;

    public Text scoreText;

    public float comandaTime;
    public float startComandaTime;

    public int limiteComandas;

    public float score;

    public float time;

    public Text textoTiempo;
    void Start()
    {
        StartCoroutine(CreateComandaCloth());
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        textoTiempo.text = ((int)time).ToString();
        if (time < 0)
        {
            StartCoroutine(GameOverCoroutine());
            
        }
    }

    IEnumerator CreateComandaCloth()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(startComandaTime);

            if (comandasList.Count < limiteComandas)
            {
                Comanda clon = Instantiate(comandaPrefab, comandasParent);

                comandasList.Add(clon);

                yield return new WaitForSeconds(comandaTime);
            }

        }
       

        
    }


    IEnumerator GameOverCoroutine()
    {
        scoreText.text = score.ToString();
        while (gameOverImage.GetComponent<CanvasGroup>().alpha < 1)
        {
            gameOverImage.GetComponent<CanvasGroup>().alpha += Time.deltaTime/3;
            yield return new WaitForSeconds(0);
        }
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(3);
    }
    public void ComandaFinished(Comanda comanda)
    {
        comandasList.Remove(comanda);
        score++;
    }
}

