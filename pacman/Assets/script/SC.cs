using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC : MonoBehaviour
{
    public float time=0;
    public int num = 0;
    public GameObject stageNumObject;
    public string exScenename;

    // Start is called before the first frame update
    public void call()
    {
        DontDestroyOnLoad(stageNumObject);
    }
}
