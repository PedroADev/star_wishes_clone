using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FaseConcluida : MonoBehaviour
{
    public Text textoPontuacao;


    public void ExibirFinal()

    {

        this.gameObject.SetActive(true);
        this.textoPontuacao.text = (points.Pontuacao + "x");
        Time.timeScale = 0;

    }

    public void EsconderFinal()

    {

        this.gameObject.SetActive(false);

    }

    public void ProximaFase()

    {

        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Fase01");
        }

    }

}
