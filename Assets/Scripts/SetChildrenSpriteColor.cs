using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class SetChildrenSpriteColor : MonoBehaviour
{

    public Color color = Color.white;

    private SpriteRenderer[] renderers;

    private void Awake()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        for(int i = 0; i < renderers.Length; i++)
        {
            renderers[i].color = color;
        }
    }
}
