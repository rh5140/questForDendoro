using UnityEngine;
// https://stackoverflow.com/questions/71626887/how-do-get-a-2d-sprite-to-face-the-camera-in-a-3d-unity-game

public class Billboard : MonoBehaviour
{
    public Transform cam;
    public Vector3 offset;
    private void Start()
    {
        cam = Camera.main.transform;
        offset = new Vector3(0f,0f,0f);
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward + offset);
    }
}
