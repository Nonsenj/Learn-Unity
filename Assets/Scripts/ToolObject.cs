using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolObject : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeing = false;

    // Update is called once per frame
    void Update()
    {
        if (isBeing == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);

        }

    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            isBeing = true;


        }
    }

    private void OnMouseUp()
    {
        isBeing = false;
        this.gameObject.transform.localPosition = new Vector3(7.41f, -3.22f, 0);
    }
}
