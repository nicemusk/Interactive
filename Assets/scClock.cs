using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class scClock : MonoBehaviour
{
    public RectTransform transform_hour;
    public RectTransform transform_min;
    public RectTransform transform_sec;
    public Text text_date;
    public Text text_get;
    public Button button_get;

    private float hour;
    private float min;
    private float sec;



    private void Start()
    {
        Init_UI();
        Init_Time();
    }

    private void Init_Time()
    {
        if (IsInvoking("Update_Time"))
            CancelInvoke("Update_Time");
        InvokeRepeating("Update_Time", 0, 0.2f);
    }

    private void Init_UI()
    {
        transform_hour.pivot = new Vector2(0.5f, 0.1f);
        transform_min.pivot = new Vector2(0.5f, 0.1f);
        transform_sec.pivot = new Vector2(0.5f, 0.1f);

        button_get.onClick.RemoveAllListeners();
        button_get.onClick.AddListener(Get_Time);
    }

    //CodeFinder 코드파인더
    //From https://codefinder.janndk.com/
    private void Update_Time()
    {

        DateTime now = DateTime.Now;
        hour = (now.Hour / 12f) * 360f + (now.Minute / 60f) * 30f;
        min = (now.Minute / 60f) * 360f;
        sec = (now.Second / 60f) * 360f;

        transform_hour.localRotation = Quaternion.Euler(0f, 0f, -hour);
        transform_min.localRotation = Quaternion.Euler(0f, 0f, -min);
        transform_sec.localRotation = Quaternion.Euler(0f, 0f, -sec);

        text_date.text = string.Format("{0}\n{1} {2}/{3}", now.ToString("tt"), now.DayOfWeek.ToString().ToUpper().Substring(0, 3), now.Month, now.Day);

    }
    private void Get_Time()
    {
        DateTime now = DateTime.Now;
        text_get.text = string.Format("{0}\n{1}/{2} {3}", now.ToString("tt hh:mm:ss"), now.Month, now.Day, now.DayOfWeek.ToString().ToUpper().Substring(0, 3));
        if(text_get.text == null)
        { text_get.text = "00:00"; }
        Debug.LogError(text_get.text);
    }
}
