using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameOverScore : MonoBehaviour
{

    public Text ScoreText;

    GameObject StageManager;

    // Start is called before the first frame update
    void Start()
    {
        
        StageManager = GameObject.Find("StageNum");
        ScoreText.text = "Score: " + StageManager.GetComponent<SC>().num;
    }


}
