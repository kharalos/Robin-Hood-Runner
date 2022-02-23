using UnityEngine;

public class SwerveInput : MonoBehaviour
{
    public static bool swerveLeft, swerveRight;

    private bool isDraging;
    private float lastFrameFingerPositionX;
    private float moveFactorX;
    public float MoveFactorX => moveFactorX;

    private void Update()
    {
        if(!isDraging)
            swerveLeft = swerveRight = false;

        /*#region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
            isDraging = true;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
            isDraging = false;
        }
        #endregion*/

        #region Mobile Input
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                lastFrameFingerPositionX = Input.touches[0].position.x;
                isDraging = true;
            }
            else if (Input.touches[0].phase == TouchPhase.Moved || Input.touches[0].phase == TouchPhase.Stationary)
            {
                moveFactorX = Input.touches[0].position.x - lastFrameFingerPositionX;
                lastFrameFingerPositionX = Input.touches[0].position.x;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                moveFactorX = 0f;
                isDraging = false;
            }
        }
        #endregion

        if (moveFactorX > 0)
        {
            swerveRight = true;
            swerveLeft = false;
        }
        else if (moveFactorX < 0)
        {
            swerveLeft = true;
            swerveRight = false;
        }
    }

    private void Reset()
    {
        isDraging = false;
    }
}