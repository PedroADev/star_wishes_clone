using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class points
{

    private static int score;

    public static int Pontuacao {
        get {
           return score;
        }

        set {
            score = value;

            if (score < 0) {
                score = 0;
            }

            Debug.Log("Pontuação alterada para: " + Pontuacao);

        }

    }


}
