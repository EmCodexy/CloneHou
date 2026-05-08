using UnityEngine;

public class Paradox : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private Renderer bckgrnrn;

    // Update is called once per frame
    void Update()
    {
        bckgrnrn.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
