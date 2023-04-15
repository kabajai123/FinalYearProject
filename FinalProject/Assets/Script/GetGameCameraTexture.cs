using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GetGameCameraTexture : MonoBehaviour
{
    public Camera camera;
    RenderTexture texture;
    RawImage rawimage;
    // Start is called before the first frame update
    void Start()
    {
        if (camera.targetTexture == null)
        {
            texture = RenderTexture.GetTemporary(720, 400, 16, RenderTextureFormat.ARGB32);
            camera.targetTexture = texture;
        }
        else
        {
            texture = camera.targetTexture;
        }

        rawimage = GetComponent<RawImage>();

    }

    // Update is called once per frame
    void Update()
    {

        if (texture != null && texture.IsCreated())
        {
            rawimage.texture = texture;
        }
    }

    void OnDestroy()
    {
        if (texture != null)
        {
            RenderTexture.ReleaseTemporary(texture);
            texture = null;
        }
    }

}
