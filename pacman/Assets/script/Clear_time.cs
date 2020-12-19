using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class Clear_time : MonoBehaviour
{

    public Text Timer_txt;

    GameObject StageManager;

    // Start is called before the first frame update
    void Start()
    {

        StageManager = GameObject.Find("StageNum");
        Timer_txt.text = "CLEAR TIME : " + Mathf.Round(StageManager.GetComponent<SC>().time);
    }

}
