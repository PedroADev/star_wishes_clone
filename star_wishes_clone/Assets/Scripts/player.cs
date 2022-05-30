using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public float velocidadeMovimento;
    

    public GameObject shoot_1; //Esse e o prefab do tiro
    public GameObject shoot_position1;

    public SpriteRenderer spriteRenderer;

    private const int QuantidadeMaximaVidas = 5;

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("enemy"))
        {
            Vida--;
            enemy enemy = collider.GetComponent<enemy>();
            enemy.Destroy();    

        } 
        
        else if (collider.CompareTag("ItemVida"))
        {
            ItemVida itemVida = collider.GetComponent<ItemVida>();
               Vida += itemVida.QuantidadeVidas;
            itemVida.Coletar();
        }

    }


    public int vidas;

    private FimJogo telaFimJogo;


   


    // Start is called before the first frame update
    void Start()
    {
        this.vidas = QuantidadeMaximaVidas;
        points.Pontuacao = 0;

        GameObject fimJogoGameObject = GameObject.FindGameObjectWithTag("TelaFimJogo");
        this.telaFimJogo = fimJogoGameObject.GetComponent<FimJogo>();
        this.telaFimJogo.Esconder();


    }

    // Update is called once per frame
    void Update()
    {
        //E, finalmente, vamos atirar :D
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet01 = (GameObject)Instantiate(shoot_1);
            bullet01.transform.position = shoot_position1.transform.position;
            GetComponent<AudioSource>().Play();
        }



        float horizontal =  Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float velocidadeX = (horizontal * this.velocidadeMovimento);
        float velocidadeY = (vertical * this.velocidadeMovimento);

        this.rigidbody.velocity = new Vector2(velocidadeX, velocidadeY);

        VerificarLimiteTela();
       
    }

    private void VerificarLimiteTela()
    {

        Vector2 posicaoAtual = this.transform.position;

        float metadeLargura = Largura / 2f;
        float metadeAltura = Altura / 2f;


        Camera camera = Camera.main;
        Vector2 limiteInferiorEsquerdo = camera.ViewportToWorldPoint(Vector2.zero);
        Vector2 limiteSuperiorDireito = camera.ViewportToWorldPoint(Vector2.one);

        float pontoReferenciaEsquerdo = posicaoAtual.x - metadeLargura;
        float pontoReferenciaDireito = posicaoAtual.x + metadeLargura;


        if(pontoReferenciaEsquerdo < limiteInferiorEsquerdo.x)
        {

            this.transform.position = new Vector2(limiteInferiorEsquerdo.x + metadeLargura, posicaoAtual.y);

        }
        else if (pontoReferenciaDireito > limiteSuperiorDireito.x)
        {

            this.transform.position = new Vector2(limiteSuperiorDireito.x - metadeLargura, posicaoAtual.y);

        }

        posicaoAtual = this.transform.position;

        float pontoReferenciaSuperior = posicaoAtual.y + metadeAltura;
        float pontoReferenciaInferior = posicaoAtual.y - metadeAltura;

        if (pontoReferenciaSuperior > limiteSuperiorDireito.y)
        {

            this.transform.position = new Vector2(posicaoAtual.x, limiteSuperiorDireito.y - metadeAltura);

        }
        else if (pontoReferenciaInferior < limiteInferiorEsquerdo.y)
        {

            this.transform.position = new Vector2(posicaoAtual.x, limiteInferiorEsquerdo.y + metadeAltura);

        }


    }

    private float Largura
    {

        get
        {

            Bounds bounds = this.spriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.x;

        }

    }


    private float Altura
    {

        get
        {

            Bounds bounds = this.spriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.y;

        }

    }



    public int Vida
    {
        get
        {
            return this.vidas;
        }
        set
        {
            this.vidas = value;
            if (this.vidas > QuantidadeMaximaVidas)
            {
                this.vidas = QuantidadeMaximaVidas;
            }

            else if (this.vidas < 0)
            {
                this.vidas = 0;
                this.gameObject.SetActive(false);

                //exibir tela de fim de jogo
                telaFimJogo.Exibir();

            }
        }
    }






}


//🗿🗿

  
