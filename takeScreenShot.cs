using UnityEngine;
using System.Collections;
using System.IO;

public class TakeScreenShot : MonoBehaviour
{
    Texture2D screenCap;
    Texture2D border;
    bool shot = false;

    //Use this for initialization
    void Start()
    {
        screenCap = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);  //1
        //border = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false); //2
        border.Apply();
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            StartCoroutine("Capture");
            //Capture;
        }

    }
    void OnGUI()
    {
        //GUI.DrawTexture(new Rect(1, 1, 430, 2), border, ScaleMode.StretchToFill); //top
        //GUI.DrawTexture(new Rect(1, 327, 430, 2), border, ScaleMode.StretchToFill); //bottom
        //GUI.DrawTexture(new Rect(1, 1, 2, 327), border, ScaleMode.StretchToFill); //left
        //GUI.DrawTexture(new Rect(430, 1, 2, 327), border, ScaleMode.StretchToFill); //right

        if (shot)
        {
            GUI.DrawTexture(new Rect(10, 10, 60, 40), screenCap, ScaleMode.StretchToFill);
        }
    }

    IEnumerator Capture()
    {
        yield return new WaitForEndOfFrame();
        screenCap.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        //screenCap.ReadPixels(new Rect(1, 1, 430, 327), 0, 0);
        screenCap.Apply();

        //Encode texture into PNG
        byte[] bytes = screenCap.EncodeToPNG();
        //object.Destroy(screenCap);

        //For testing purposes,also write to a file in the project folder
        File.WriteAllBytes(Application.dataPath + "/SavedScreen.png", bytes);
        shot = true;
    }
}