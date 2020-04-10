using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class path : MonoBehaviour

{
    public bool isTouch;

    public GameObject pipes;

    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch)
        {
           
            Invoke("nextAssign", 5f);
            isTouch = false;
        }

    }
    void nextAssign()
    {
        transform.position = transform.position + new Vector3(14, 0, 0);

        float yPos = Random.Range(-4f, 1f);
        Debug.Log(yPos.ToString());

        pipes.transform.localPosition = new Vector3(0, yPos, 0);


    }
}
