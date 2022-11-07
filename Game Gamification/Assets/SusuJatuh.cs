using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusuJatuh : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isIsi;
    private Vector3 posisiAwal;
    private float timer;
    void Start()
    {
        posisiAwal = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIsi)
        {
            transform.Translate(new Vector3(0, -264, this.transform.position.z) * Time.deltaTime);
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                timer = 0;
                isIsi = false;
                this.gameObject.transform.position = posisiAwal;
                this.gameObject.SetActive(false);
            }
        }
    }
}
