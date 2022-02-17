using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BollonControl : MonoBehaviour
{
    [SerializeField]
    private GameObject balloon;
    [SerializeField]
    private int _score = 1;
    [SerializeField]
    private GameObject particleSystem;
    private Rigidbody2D myBody;
    private Animator animation;
    private float balloonMove;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        balloonMove = Random.Range(100, 400);
    }

    // Update is called once per frame
    void Update()
    {
        myBody.velocity = new Vector2(myBody.velocity.x, balloonMove * Time.deltaTime);
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 balloonPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        Vector2 fireX = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
        if (Input.GetButtonDown("Fire1"))
        {
            if (Mathf.Abs(mousePosition.x - balloonPosition.x) < 0.5f && Mathf.Abs(mousePosition.y - balloonPosition.y) < 0.5f)
            {
                animation.SetBool("isExplosion", true);
                Destroy(gameObject, 0.7f);
                GameManager.Instance.CollectItem(_score);
                StartCoroutine(Spawner());

            }
        }
        if (balloonPosition.y > 6)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject o = Instantiate(particleSystem, transform.position, Quaternion.identity) as GameObject;
        Destroy(o, 5f);

    }
}
