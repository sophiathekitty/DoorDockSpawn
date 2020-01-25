using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockPoint : MonoBehaviour
{
    public DoorTag doorTag;
    public DockPoint targetDock;
    public Color color;
    private Vector3 gizmoPos = new Vector3(0f, 1f, 0f);
    private Vector3 gizmoSize = new Vector3(1f, 2f, 1f);
    private Room room;
    // Start is called before the first frame update
    void Start()
    {
        room = transform.parent.GetComponent<Room>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LinkDock(DockPoint dockPoint)
    {
        targetDock = dockPoint;
        AlignDock();
        dockPoint.targetDock = this;
    }
    public void UnlinkDock()
    {
        if (targetDock == null) return;
        targetDock.targetDock = null;
        targetDock = null;
    }

    public Vector3 OffsetPossition()
    {
        return new Vector3(
                            targetDock.transform.position.x - transform.localPosition.x,
                            targetDock.transform.position.y - transform.localPosition.y,
                            targetDock.transform.position.z - transform.localPosition.z);
    }

    public void AlignDock()
    {
        if (targetDock == null || targetDock.doorTag != doorTag) return;
        transform.parent.position = OffsetPossition();

        float offset = 0f;
        if (transform.localEulerAngles.y == 180 || transform.localEulerAngles.y == 0)
            offset = 180;

        if (doorTag.mirror)
            transform.parent.transform.RotateAround(transform.position, Vector3.up, targetDock.transform.eulerAngles.y + transform.localEulerAngles.y + offset);
        else
            transform.parent.transform.RotateAround(transform.position, Vector3.up, targetDock.transform.eulerAngles.y - transform.localEulerAngles.y);

    }


    /// <summary>
    /// 
    /// </summary>
    public void OnDrawGizmos()
    {

        Gizmos.matrix = transform.localToWorldMatrix;
        if (doorTag != null)
        {
            Gizmos.color = new Color(doorTag.color.r, doorTag.color.g, doorTag.color.b, doorTag.color.a);
            Gizmos.DrawCube(doorTag.pos, doorTag.size);
        }
        else
        {
            Gizmos.color = new Color(color.r, color.g, color.b, 0.15f);
            Gizmos.DrawCube(gizmoPos, gizmoSize);
        }

        Gizmos.color = new Color(color.r, color.g, color.b, 0.75f);
        Gizmos.DrawLine(Vector3.zero, Vector3.forward * 2f);
        Gizmos.DrawLine(Vector3.forward * 2f, new Vector3(1f, 0f, 1f));
        Gizmos.DrawLine(Vector3.forward * 2f, new Vector3(-1f, 0f, 1f));

    }


    /// <summary>
    /// 
    /// </summary>
    public void OnDrawGizmosSelected()
    {

        Gizmos.matrix = transform.localToWorldMatrix;
        if (doorTag != null)
        {
            Gizmos.color = new Color(doorTag.color.r, doorTag.color.g, doorTag.color.b, 0.75f);
            Gizmos.DrawCube(doorTag.pos, doorTag.size);
        }
        else
        {
            Gizmos.color = new Color(color.r, color.g, color.b, 0.75f);
            Gizmos.DrawCube(gizmoPos, gizmoSize);
        }

        Gizmos.color = new Color(color.r, color.g, color.b, 0.75f);
        Gizmos.DrawLine(Vector3.zero, Vector3.forward * 2f);
        Gizmos.DrawLine(Vector3.forward * 2f, new Vector3(1f, 0f, 1f));
        Gizmos.DrawLine(Vector3.forward * 2f, new Vector3(-1f, 0f, 1f));
    }

}
