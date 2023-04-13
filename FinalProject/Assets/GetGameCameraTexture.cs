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
        texture = camera.targetTexture;
        rawimage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {

        rawimage.texture = texture;
    }
}
