using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;

    void Update()
    {
        // move
        float h = Input.GetAxisRaw("Horizontal");
        // Horizontal (Boder Right, Border Left) collision
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h = 0;
        float v = Input.GetAxisRaw("Vertical");
        // Vertical (Boder Top, Border Bottom) collision
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            v = 0;
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Border Physics collision Trigger Enter
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                // Top Border
                case "Top":
                    isTouchTop = true;
                    break;
                // Bottom Border
                case "Bottom":
                    isTouchBottom = true;
                    break;
                // Right Border
                case "Right":
                    isTouchRight = true;
                    break;
                // Left Border
                case "Left":
                    isTouchLeft = true;
                    break;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        // Border Physics collision Trigger Enter
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                // Top Border
                case "Top":
                    isTouchTop = false;
                    break;
                // Bottom Border
                case "Bottom":
                    isTouchBottom = false;
                    break;
                // Right Border
                case "Right":
                    isTouchRight = false;
                    break;
                // Left Border
                case "Left":
                    isTouchLeft = false;
                    break;

            }
        }
    }
}
