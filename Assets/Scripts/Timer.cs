using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TMPro.TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "Tiempo"+ GameManager.instance.GetTime(); 
    }
}
