using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{

    public TextMesh RankingTxt;
    public Text Ranking;
    public bool isRanking = false;
    public GameObject RankingMenu;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Ranking.text =
                "Ranking\n\n" +
                "1 등 :" + PlayerPrefs.GetInt("0") + "\n\n" +
                "2 등 :" + PlayerPrefs.GetInt("1") + "\n\n" +
                "3 등 :" + PlayerPrefs.GetInt("2") + "\n\n" +
                "4 등 :" + PlayerPrefs.GetInt("3") + "\n\n" +
                "5 등 :" + PlayerPrefs.GetInt("4");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
