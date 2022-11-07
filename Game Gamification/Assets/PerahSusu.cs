using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerahSusu : MonoBehaviour
{
    [SerializeField] private Image SusuPenuh;
    // Start is called before the first frame update
    void Start()
    {
        SusuPenuh.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isiSusu()
    {
        SusuPenuh.fillAmount += 0.1f;
    }
}
