using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelectScript : MonoBehaviour
{
    public void selectScene() {
       /* switch (gameObject.name)
        {
            case "catchUpScene":
                SceneManager.LoadScene("KlevleevSceneCatchUp");
                break;
        }
        */
        switch(Random.Range(0,3))
        {
            case 0:
                SceneManager.LoadScene("CoinGrab");
                break;
            case 1:
                SceneManager.LoadScene("FallingBlocks");
                break;
            case 2:
                SceneManager.LoadScene("CatchUp");
                break;
            default:
                SceneManager.LoadScene("Menu");
                break;
        };
    }
}
