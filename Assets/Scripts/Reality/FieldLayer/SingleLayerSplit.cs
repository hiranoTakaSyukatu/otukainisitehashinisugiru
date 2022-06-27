using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleLayerSplit : MonoBehaviour
{

    public void SetGameObject(GameObject[] gameObjects)
    {
        foreach (var item in gameObjects)
        {
            var tmp = item.transform.position;
            tmp.z = item.transform.position.y;
            if (item.TryGetComponent(out SpriteRenderer spriteRenderer))
            {
                
                spriteRenderer.sortingOrder = -(int)(tmp.z * 100);
            }
        }
    }
}
