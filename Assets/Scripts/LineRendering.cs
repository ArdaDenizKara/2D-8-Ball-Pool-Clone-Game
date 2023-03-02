using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRendering : MonoBehaviour
{
    #region Fields
    public LineRenderer lineRender;
    #endregion
    #region Functions
    private void Awake()
    {
        lineRender = GetComponent<LineRenderer>();
    }
    public void RenderLine(Vector3 startPoint , Vector3 endPoint)
    {
        lineRender.positionCount = 2;
        Vector3[] dots = new Vector3[2];
        dots[0] = startPoint;
        dots[1] = endPoint;
        lineRender.SetPositions(dots);
    }
    public  void EndRenderLine()
    {
        lineRender.positionCount = 0;
    }
    #endregion
}
