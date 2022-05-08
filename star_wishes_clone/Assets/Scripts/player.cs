using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public float velocidadeMovimento;
    

    public GameObject shoot_1; //Esse e o prefab do tiro
    public GameObject shoot_position1;


    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("enemy"))
        {
            Vida--;
            enemy enemy = collider.GetComponent<enemy>();
            enemy.Destroy();    

        }

    }


    public int vidas;


   


    // Start is called before the first frame update
    void Start()
    {
        this.vidas = 5;
        points.Pontuacao = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //E, finalmente, vamos atirar :D
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet01 = (GameObject)Instantiate(shoot_1);
            bullet01.transform.position = shoot_position1.transform.position;
        }



        float horizontal =  Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float velocidadeX = (horizontal * this.velocidadeMovimento);
        float velocidadeY = (vertical * this.velocidadeMovimento);

        this.rigidbody.velocity = new Vector2(velocidadeX, velocidadeY);
       
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
            if (this.vidas < 0)
            {
                this.vidas = 0;            }
        }
    }

  


   

}
