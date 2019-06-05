using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float health;
    public Text Healthbar;

    void Start()
    {
        health = 100;
    }

    void Update()
    {
        /// Healthbar.text = health.ToString();
    }
}
