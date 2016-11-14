using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScreenController : MonoBehaviour {

    Image Logo;
    Image Title;
    float startTime;

	// Use this for initialization
	void Start () {

        Logo = GameObject.Find("Logo").GetComponent<Image>();
        Title = GameObject.Find("Title").GetComponent<Image>();
        startTime = Time.time;

        Color temp = Logo.color;
        temp.a = 0f;
        Logo.color = temp;

        temp = Title.color;
        temp.a = 0f;
        Title.color = temp;
        
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.touchCount > 0 || Input.anyKeyDown) {
            SceneManager.LoadScene("mainMenu");
        }

        float delta = Time.time - startTime;
        Color temp = Logo.color;
        Vector3 tempPos;

        if (delta > 2.5f && Logo.color.a < 1) {
            temp.a += 0.003f;
            Logo.color = temp;
        }

        temp = Title.color;
        if(delta > 6.7f && Title.color.a < 1) {
            temp.a += 0.008f;
            Title.color = temp;
        }

        if(delta > 9.0f) {
            Title.GetComponent<Transform>().Rotate(new Vector3(0.0f, 0.0f, 4.0f));
            tempPos = Title.GetComponent<Transform>().position;
            tempPos.x += 15;
            tempPos.y += 20;
            Title.GetComponent<Transform>().position = tempPos;


            if (Logo.transform.rotation.eulerAngles.z > 300.0f) {
                Logo.GetComponent<Transform>().Rotate(new Vector3(0.0f, 0.0f, -4.0f));
            }

            tempPos = Logo.GetComponent<Transform>().position;
            tempPos.x += -10;
            Logo.transform.position = tempPos;

        }

        if(delta > 12.0f) {
            SceneManager.LoadScene("mainMenu");
        }

	}
}
