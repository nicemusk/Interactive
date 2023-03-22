using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class scAPI : MonoBehaviour
{
    public Text txt;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("UnityWebRepuestGet");
    }

   IEnumerator UnityWebRepuestGet()
    {
        string apikey = "p3Qc2LDLyHenX8OtZHA%2F68cgFTgZBd6bADgdMLZmVZQcx1UkUP3QqTf6Pmqn0qd6gSipoFXREVsCxNRuejK4og%3D%3D";
        string url = "http://www.culture.go.kr/openapi/rest/publicperformancedisplays/period";
        url += "?ServiceKey=" + apikey; // Service Key
        //url += "&keyword=";
        //url += "&sortStdr=1";
        //url += "&ComMsgHeader=";
        //url += "&RequestTime=20100810:23003422";
        //url += "&CallBackURI=";
        //url += "&MsgBody=";
        //url += "&from=20100101";
        //url += "&to=20101201";
        //url += "&cPage=1";
        //url += "&rows=10";
        //url += "&place=1";
        //url += "&gpsxfrom=129.101";
        //url += "&gpsyfrom=35.142";
        //url += "&gpsxto=129.101";
        //url += "&gpsyto=35.142";

        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if(www.error == null)
        {
            Debug.Log("정상 작동");
            txt.text = www.downloadHandler.text;

        }
        else
        {
            Debug.Log("Error");
        }

       
    }
}
