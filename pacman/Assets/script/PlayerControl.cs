using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(CharacterController))]

public class PlayerControl : MonoBehaviour
{
    public Light player_light;
    public GameObject playerSpowner;
    public float limitTime = 0;
    public Text text_timer;

    public Text text_speed;


    public SC sc;

    public int limit = 352;
    private int life=3;

    public Image[] LifImg;

    public GameObject monsterSpowner;

    public static int count = 0;
    public Transform player;

    public Text countText;

    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float upDownRange = 90;
    public float jumpSpeed = 5;
    public float downSpeed = 5;

    private Vector3 speed;
    private float forwardSpeed;
    private float sideSpeed;

    private float rotLeftRight;
    private float rotUpDown;
    private float verticalRotation = 0f;

    private float verticalVelocity = 0f;


    private CharacterController cc;



    public Toggle nearcamera;
    public Toggle minimap;


    public Image countbar;
    public Image speedbar;


    // Use this for initialization
    void Start()
    {



        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        countText.text = "Point: ";

    }
    private void SetCountText()
    {
        if (count >= limit)
        {
            sc.call();

            sc.time = limitTime;
            insertRank(count);
            SceneManager.LoadScene("GameClear");
            sc.exScenename = SceneManager.GetActiveScene().name.ToString();
            Cursor.lockState = CursorLockMode.Confined; // 게임 창 밖으로 마우스가 안나감
        }
    }

    public void PlayerHPbar()

    {

        float point = PlayerControl.count; //캐릭터 hp를 받아옴

        countbar.fillAmount = point / 300f;


    }
    public void Playerspeedbar()

    {


        speedbar.fillAmount = (movementSpeed-5) / 4;


    }


    // Update is called once per frame
    void Update()
    {
        PlayerHPbar();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (nearcamera.isOn == false)
            {
                nearcamera.isOn = true;
                minimap.isOn = false;
            }
            else if (nearcamera.isOn == true)
            {
                nearcamera.isOn = false;
                minimap.isOn = true;
            }

        }

        if (life <= 0)
        {
            sc.exScenename = SceneManager.GetActiveScene().name.ToString();
            print(SceneManager.GetActiveScene().name.ToString());
            sc.call();
            sc.num = count;
            insertRank(count);
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.Confined; // 게임 창 밖으로 마우스가 안나감
        }
        SpeedSet();
        FPMove();
        FPRotate();
        SetCountText();
        timerset();
        Playerspeedbar();
    }

    void insertRank(int Score)//count를 점수로 받기
    {
        for(int i = 0; i < 5; i++)
        {
            if (Score > PlayerPrefs.GetInt(i.ToString()))
            {
                for(int j = 4 - i; j > 0; j--)
                {
                    PlayerPrefs.SetInt(j.ToString(), PlayerPrefs.GetInt((j - 1).ToString()));
                }
                PlayerPrefs.SetInt(i.ToString(), Score);
                break;
            }
        }
    }

    void demage()
    {

        for(int index = 0; index < 3; index++)
        {
            LifImg[index].color = new Color(1, 1, 1, 0);
        }

        for (int index = 0; index < life; index++)
        {
            LifImg[index].color = new Color(1, 1, 1, 1);
        }
    }
    void timerset()
    {
        limitTime += Time.deltaTime;
        text_timer.text = "TIME : " + Mathf.Round(limitTime);
    }

    void SpeedSet()
    {
        text_speed.text = "SPEED : " + (movementSpeed-5)*2;
    }



    //Player의 x축, z축 움직임을 담당
    void FPMove()
    {

        forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        //막아 놓은 점프 기능
        //if (cc.isGrounded && Input.GetButtonDown ("Jump"))
        //verticalVelocity = jumpSpeed;
        //if (!cc.isGrounded)
        //verticalVelocity = downSpeed;


        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed;

        cc.Move(speed * Time.deltaTime);
    }

    //Player의 회전을 담당
    void FPRotate()
    {
        //좌우 회전
        rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, rotLeftRight, 0f);

        //상하 회전
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            countText.text = "Point: " + count;
            soundManager.instance.PlaySound();
        }

        if (other.gameObject.CompareTag("light_up"))
        {
            other.gameObject.SetActive(false);
            player_light.spotAngle = player_light.spotAngle + 15;
            countText.text = "Point: " + count;
            soundManager.instance.PlaySound();
        }

        if (other.gameObject.CompareTag("speed_up"))
        {
            other.gameObject.SetActive(false);
            movementSpeed = movementSpeed + 0.5f;
            text_speed.text = "SPEED: " + movementSpeed;
            soundManager.instance.speed_sound();
        }

        if (other.gameObject.CompareTag("life_up"))
        {
            if (life < 3)
            {
                other.gameObject.SetActive(false);
                life = life + 1;
                demage();
                soundManager.instance.life_sound();
            }

        }


        if (other.gameObject.CompareTag("monster"))
        {
            other.gameObject.transform.position = monsterSpowner.transform.position;
            player.gameObject.transform.localPosition = playerSpowner.transform.position;
            print("접촉");
            life--;
            demage();
        }


    }
}
