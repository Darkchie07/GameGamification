using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PerahSusu : MonoBehaviour
{
    [SerializeField] private Image SusuPenuh;
    public SusuJatuh susuJatuh;
    private float timer;
    public bool isCooldowm;
    public TMP_Text cooldownMessage;
    public Image kupon;
    public Sprite[] ListKupon;

    public Image tetesanSusu;
    // Start is called before the first frame update
    void Start()
    {
        SusuPenuh.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldowm)
        {
            timer += Time.deltaTime;
            if (timer >= 1800)
            {
                timer = 0;
                isCooldowm = false;
            }
        }

        if (SusuPenuh.fillAmount == 1)
        {
            kupon.gameObject.SetActive(true);
            var idx = Random.Range(0, ListKupon.Length);
            kupon.sprite = ListKupon[idx];
            SusuPenuh.fillAmount = 0;
        }
    }

    public void isiSusu()
    {
        if (!isCooldowm)
        {
            if (SusuPenuh.fillAmount != 1f && !susuJatuh.isIsi)
            {
                susuJatuh.gameObject.SetActive(true);
                susuJatuh.isIsi = true;
                StartCoroutine(IsiSusu());
                isCooldowm = true;
            }
        }
        else
        {
            StartCoroutine(TextMessage());
            
        }
    }

    private IEnumerator IsiSusu()
    {
        yield return new WaitForSeconds(2f);
        SusuPenuh.fillAmount += 0.1f;
    }
    
    private IEnumerator TextMessage()
    {
        cooldownMessage.gameObject.SetActive(true);
        cooldownMessage.text = "Perah kembali dalam " + (int) ((1800 - timer)/60) + " menit";
        yield return new WaitForSeconds(2f);
        cooldownMessage.gameObject.SetActive(false);
    }

    public void CloseKupon()
    {
        kupon.gameObject.SetActive(false);
    }
}
