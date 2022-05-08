using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_squid : MonoBehaviour
{
    public enemy inimigoOriginal;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        this.timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.timer += Time.deltaTime;
        if (this.timer >= 2f){
            this.timer = 0;

            Vector2 positionMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 positionMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            float positionX = Random.Range(positionMin.x, positionMax.x);
            Vector2 positionEnemy = new Vector2(positionX, positionMax.y);
            
            Instantiate(this.inimigoOriginal, positionEnemy, Quaternion.identity);
        }
    }
}
