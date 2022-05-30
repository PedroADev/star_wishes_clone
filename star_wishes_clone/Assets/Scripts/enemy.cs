using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public Rigidbody2D rigidbody;

    public float speedMin;
    public float speedMax;
    private float speedY;

    public ParticleSystem particulaExplosaoPrefab;

    [SerializeField]
    [Range(0, 100)]
    private float chanceSoltarItemVida;

    [SerializeField]
    private ItemVida itemVidaPrefab;




    // Start is called before the first frame update
    void Start()
    {
        this.speedY = Random.Range(this.speedMin, this.speedMax);
    }

    // Update is called once per frame
    void Update()
    {
        this.rigidbody.velocity = new Vector2(0, -this.speedY);


        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);
        if (posicaoNaCamera.y <0)
        {
            //inimigo saiu da area da camera
            player player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
            player.Vida--;
            Destroy(this.gameObject);
        }

    }

    public void Destroy() 
    {
        
    points.Pontuacao++;
        SoltarItemVida();


     ParticleSystem particulaExplosao = Instantiate(this.particulaExplosaoPrefab, this.transform.position, Quaternion.identity);
      
        Destroy(particulaExplosao.gameObject, 1f);


       
    Destroy(this.gameObject);
    }

    private void SoltarItemVida()
    {
        float chanceAleatoria = Random.Range(0f, 100f);
        if (chanceAleatoria <= this.chanceSoltarItemVida)
        {
            Instantiate(this.itemVidaPrefab, this.transform.position, Quaternion.identity);
        }

    }
}
