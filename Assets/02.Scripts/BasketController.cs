using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class BasketController : MonoBehaviour
{
    public AudioClip SEapple;
    public AudioClip SEbomb;
    AudioSource aud;
    public UnityEngine.UI.Text TimeUI;
    public UnityEngine.UI.Text ScoreUI;

    int score = 0;
    float time = 30.0f;



    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        time -= Time.deltaTime;
        TimeUI.text = time.ToString("F1") + "s";
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Apple"))       // CompareTag가 좀 더 빠르다
        {
            Debug.Log("apple");
            score += 100;
            aud.PlayOneShot(SEapple);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bomb")
        {
            Debug.Log("bomb");
            score /= 2;
            aud.PlayOneShot(SEbomb);
            Destroy(collision.gameObject);
        }
        ScoreUI.text = score + "pt";
    }
}
