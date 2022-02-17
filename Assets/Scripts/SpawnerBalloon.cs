using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBalloon : MonoBehaviour
{
    [SerializeField]
    private GameObject balloon;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
        Debug.Log(Screen.width);
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(1);
        Vector3 temp = transform.position;
        temp.x = Random.Range(-(Camera.main.orthographicSize * Screen.width / Screen.height) + 1, Camera.main.orthographicSize * Screen.width / Screen.height) - 1;
        Instantiate(balloon, temp, Quaternion.identity);
        StartCoroutine(Spawner());
    }
}
