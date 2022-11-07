using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusuJatuh : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isIsi;
    private Vector2 posisiAwal;
    private float timer;
    public Transform tujuan;
    public PerahSusu perahSusu;
    void Start()
    {
        posisiAwal = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIsi)
        {
            transform.position = Vector2.MoveTowards(transform.position, tujuan.position, 150 * Time.deltaTime);
            if (Vector2.Distance(transform.position, tujuan.position) <= 0)
            {
                isIsi = false;
                perahSusu.isDasar = true;
                tujuan.position = new Vector3(tujuan.position.x, tujuan.position.y + 10, tujuan.position.x);
                perahSusu.SusuPenuh.fillAmount += 0.1f;
                this.gameObject.transform.position = posisiAwal;
                this.gameObject.SetActive(false);
            }
            // transform.Translate(new Vector3(0, -264, this.transform.position.z) * Time.deltaTime);
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Batas"))
    //     {
    //         Debug.Log("Nabrak");
    //         isIsi = false;
    //         this.gameObject.transform.position = posisiAwal;
    //         this.gameObject.SetActive(false);
    //     }
    // }
}
