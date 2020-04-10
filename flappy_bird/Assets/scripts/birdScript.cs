using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class birdScript : MonoBehaviour
{
    public float speed;
    public float powerJump;
    public int score;
    public GameObject canvas;
    public AudioClip[] voiceFiles;
    public Text record;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
       canvas.SetActive(false);
       Time.timeScale = 1;
       score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.A))
        {
            
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * powerJump);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "trigger")
        {

            col.gameObject.transform.parent.root.gameObject.GetComponent<path>().isTouch = true;
            score++;
            GetComponent<AudioSource>().PlayOneShot(voiceFiles[1], 1);
           
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "obstacle")
        {
            EndGame();
        }
    }
    void EndGame()
    {
        Time.timeScale = 0;
        GetComponent<AudioSource>().PlayOneShot(voiceFiles[2], 1);
        canvas.SetActive(true);
        if (score > PlayerPrefs.GetInt("Record"))
        {
            PlayerPrefs.SetInt("Record", score);
        }


        scoreText.text = score.ToString();
        record.text = PlayerPrefs.GetInt("Record").ToString();
    }



public void Replay()
    {
        Application.LoadLevel("game");
    }

}
