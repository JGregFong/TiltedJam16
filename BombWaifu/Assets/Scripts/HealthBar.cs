using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    float percentage = 1.0f;
    float fullHealth;
    GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = this.transform.GetChild(0).gameObject;
        fullHealth = healthBar.GetComponent<RectTransform>().anchoredPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPercentage(float currentHealth, float maxHealth)
    {   
        percentage = currentHealth / maxHealth;
        healthBar.GetComponent<RectTransform>().localScale = new Vector3(percentage, 1.0f, 1.0f);
        Vector3 scaledPosition = new Vector3(fullHealth * percentage, 0.0f, 0.0f);
        healthBar.GetComponent<RectTransform>().anchoredPosition = scaledPosition;
    }
}
