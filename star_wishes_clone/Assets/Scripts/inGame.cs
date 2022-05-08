using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inGame : MonoBehaviour
{

    public Text textoPontuacao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.textoPontuacao.text = (points.Pontuacao + "x");

    }
}
