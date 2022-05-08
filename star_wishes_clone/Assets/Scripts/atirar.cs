using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atirar : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        //Obter a posicao atual do tiro
        Vector2 position = transform.position;

        //Computar a nova posicao do tiro
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        //Atualizar a posicao do tiro
        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Se o tiro sair do limite da tela ele e destruido
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }
    //Fazendeo a interacao do lazer com o inimigo
    public void OnTriggerEnter2D(Collider2D collider)
    {
       if (collider.CompareTag("enemy"))
        {

            enemy enemy = collider.GetComponent<enemy>();
            enemy.Destroy();

            Destroy(this.gameObject);

        }
    }
}   
