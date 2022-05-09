using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inGame : MonoBehaviour
{

    public Text textoPontuacao;
    public BarraVida barraVida;

    private player player;

    // Start is called before the first frame update
   private void Start()
    {

        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();

    }

    // Update is called once per frame
    void Update()
    {

        this.barraVida.ExibirVida(this.player.Vida);

        this.textoPontuacao.text = (points.Pontuacao + "x");

    }
}
