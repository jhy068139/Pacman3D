using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public Vector3 Destination = new Vector3(0, 0, 0);
        public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Tkljfdsj;fdasjjas;fdj");

            other.transform.localPosition = target.transform.position;
            soundManager.instance.PlaySound();
        }
    }
}
