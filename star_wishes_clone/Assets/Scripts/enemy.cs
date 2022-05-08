using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public Rigidbody2D rigidbody;

    public float speedMin;
    public float speedMax;
  

    private float speedY;



    // Start is called before the first frame update
    void Start()
    {
        this.speedY = Random.Range(this.speedMin, this.speedMax);
    }

    // Update is called once per frame
    void Update()
    {
        this.rigidbody.velocity = new Vector2(0, -this.speedY);

    }

    public void Destroy() 
    {
        
    points.Pontuacao++;
     

       
    Destroy(this.gameObject);
    }
}
