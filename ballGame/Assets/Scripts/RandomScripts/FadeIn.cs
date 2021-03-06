using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    #region Public Variables
    #endregion
    #region Inspector Variables
    [SerializeField] private Color StartColor;
    [SerializeField] private Color EndColor;
    #endregion
    #region Private Variables
    private SpriteRenderer self;
    private float timer = 0f;
    #endregion
    #region Components
    #endregion

    private void Start()
    {
        self = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Timer();
    }

    private void FixedUpdate()
    {
        FadeInColour();
    }

    #region Method
    private void FadeInColour()
    {
        self.color = Color.Lerp(StartColor, EndColor, timer);
    }

    private void Timer()
    {
        timer += Time.deltaTime * 5;
    }
    #endregion
}
