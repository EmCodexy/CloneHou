using UnityEngine;

public class NoCursor : MonoBehaviour
{
    void Update()
    {
        Cursor.visible = false;
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
    }
}
