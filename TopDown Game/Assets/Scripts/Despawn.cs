using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    SpriteRenderer rend;

    public float despawnTime = 5f;
    public float fadeTime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        StartCoroutine(Delete());
        StartCoroutine(FadeAway());
    }


    IEnumerator Delete()
    {
       
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }
    IEnumerator FadeAway()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(fadeTime);
        }
        
    }
}
