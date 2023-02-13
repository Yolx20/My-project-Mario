using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeakPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControler>())
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
