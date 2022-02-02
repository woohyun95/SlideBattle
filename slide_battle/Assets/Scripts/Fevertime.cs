using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Fevertime : MonoBehaviour
{
    TextMeshProUGUI tmp;
    float fontSize;
    float modifySpeed;
    private void Start() {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
        fontSize = tmp.fontSize;
        modifySpeed = 1;
    }
    void FixedUpdate()
    {
        if (fontSize < 70) {
            modifySpeed *= -1;
        }
        else if (fontSize > 90) {
            modifySpeed *= -1;
        }

        fontSize += modifySpeed;
        tmp.fontSize = fontSize;
        tmp.outlineColor = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1));
        
    }
}
