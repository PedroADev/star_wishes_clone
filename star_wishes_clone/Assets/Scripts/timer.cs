using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{

    public Text timeLevel_txt;
    public float timeLevel;
    private FaseConcluida telaFaseConcluida;

    // Start is called before the first frame update
    void Start()
    {

        timeLevel = 90f;



    }

    // Update is called once per frame
    void Update()
    {

        timeLevel = timeLevel - Time.deltaTime;
        timeLevel_txt.text = timeLevel.ToString("0");



    }
}
