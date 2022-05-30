using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVida : MonoBehaviour
{
    [SerializeField]
    private int quantidadeVidas;

    [SerializeField]
    private ParticleSystem particulaPrefab;


    public int QuantidadeVidas
    {
        get
        {
            return this.quantidadeVidas;
        }
    }

   public void Coletar()
    {

        ParticleSystem particula = Instantiate(this.particulaPrefab, this.transform.position, Quaternion.identity);

        Destroy(particula.gameObject, 1f);

   

        Destroy(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
