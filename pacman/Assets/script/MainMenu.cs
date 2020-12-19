using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    GameObject StageManager;
    public SC sc;
    public Text Ranking;
    public Color none;
    public GameObject Rank_can;
    string exname;
    // Start is called before the first frame update
    void Start()
    {
        StageManager = GameObject.Find("StageNum");

        Rank_can.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickNewGame()
    {
        print("시작");
        

        SceneManager.LoadScene("Game");
    }

    public void OnClickRankinicate()
    {
        print("리셋");
        for(int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(i.ToString(),0);

        }
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

    public void OnClickRank()
    {
        print("랭킹");
        Rank_can.SetActive(true);
    }
    public void OnClickRank_close()
    {
        print("랭킹");
        Rank_can.SetActive(false);
    }
    public void OnClickCloseGame()
    {
        print("끝");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
    public void OnClickNew()
    {

        exname = StageManager.GetComponent<SC>().exScenename;
        SceneManager.LoadScene(exname);
        /*        if (exname == "Game")
                {
                    SceneManager.LoadScene("Game");

                }
                else if (exname == "horror_mode")
                {
                    SceneManager.LoadScene("horror_mode");

                }
                else if (exname == "high_game")
                {
                    SceneManager.LoadScene("high_game");

                }*/
    }
    public void OnClickHome()
    {
        print("시작");

        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickHigh()
    {
        print("하이모드");

        SceneManager.LoadScene("high_game");
    }

    public void OnClickExplain()
    {
        print("시작");

        SceneManager.LoadScene("GameExplain");
    }
    public void OnClickHorror()
    {
        print("시작");

        SceneManager.LoadScene("horror_mode");
    }
}
