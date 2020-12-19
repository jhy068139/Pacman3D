using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class point_bar : MonoBehaviour
{
    public Image countbar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()

    {

        PlayerHPbar();

    }



    public void PlayerHPbar()

    {

        float point = PlayerControl.count; //캐릭터 hp를 받아옴

        countbar.fillAmount = point / 100f;


    }
}
