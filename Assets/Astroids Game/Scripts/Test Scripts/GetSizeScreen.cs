using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSizeScreen : MonoBehaviour
{

    public Vector3 ScreenTop;
    public Vector3 ScreenBottom;


    // Start is called before the first frame update
    void Start()
    {
        ScreenTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        ScreenBottom = Camera.main.ScreenToWorldPoint(Vector3.zero);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        if (transform.position.y > ScreenTop.y)
            pos.y = ScreenBottom.y;

        if (transform.position.y < ScreenBottom.y)
            pos.y = ScreenTop.y;

        if (transform.position.x > ScreenTop.x)
            pos.x = ScreenBottom.x;

        if (transform.position.x < ScreenBottom.x)
            pos.x = ScreenTop.x;


        transform.position = pos;
    }


}
