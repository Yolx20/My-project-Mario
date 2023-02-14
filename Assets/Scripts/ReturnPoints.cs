using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPoints : MonoBehaviour
{
    
    
        public TMPro.TMP_Text punctuationText;

        void Update()
        {
            punctuationText.text = "Puntuation: " + GameManager.instance.GetPunt();
        }
    
}
