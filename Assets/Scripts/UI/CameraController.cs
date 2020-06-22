using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Variables
    private bool doMovement = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float scrollMultiplier = 10f;
    public Vector2 scrollLimits = new Vector2(10, 80);
    #endregion

    void Update()
    {
        #region Game Over
        //if the game is over we cant move
        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }
        #endregion

        #region Escape Movement
        //If we press the escape key toggle if we can move
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        //If we cant do movement then stop before we apply movement
        if (!doMovement)
        {
            return;
        }
        #endregion

        #region Apply Movement Input
        //Do movement off the input
        if (Input.GetAxisRaw("Vertical") > 0 || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetAxisRaw("Vertical") < 0 || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetAxisRaw("Horizontal") > 0 || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetAxisRaw("Horizontal") < 0 || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        #endregion

        #region Scrolling
        //Zoom in and out off the input within the bounds
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        //print(scroll.ToString());
        Vector3 pos = transform.position;

        pos.y -= scroll * scrollMultiplier * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, scrollLimits.x, scrollLimits.y);

        transform.position = pos;
        #endregion
    }
}
