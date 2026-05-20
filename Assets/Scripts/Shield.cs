using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Player player;
    public GameObject shield;
    // Update is called once per frame

    private void Start()
    {
        player = GetComponentInParent<Player>();
        shield.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            shield.SetActive(!shield.activeSelf);
            //transform.position = new Vector2(11,11);
            //ScoreUI.
        }
        //else
        //{
        //    shield.SetActive(false);
        //    //transform.position = new Vector2(0, 0);

        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EB"))
        {
            collision.gameObject.GetComponent<Projectiles>().jjk();
           
        }
    }


}
