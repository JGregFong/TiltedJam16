using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    float percentage = 1.0f;
    GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = this.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.localScale = new Vector3(percentage, 1.0f, 1.0f);
    }

    public void SetPercentage(float currentHealth)
    {
        percentage = currentHealth / 100;
    }
}
