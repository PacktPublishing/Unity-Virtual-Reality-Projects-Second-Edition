using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtworkController : MonoBehaviour {

    public Transform frame;
    public GameObject image;
    public Text title;
    public Text artist;
    public Text description;
    public GameObject detailsCanvas;
    
    void Start()
    {
        detailsCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            detailsCanvas.SetActive(true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            detailsCanvas.SetActive(false);
        }
    }

    public void SetArtInfo(ArtInfo info)
    {
        Renderer rend = image.GetComponent<Renderer>();
        Material material = rend.material;
        material.mainTexture = info.image;
        frame.localScale = TextureToScale(info.image, frame.localScale.z);

        title.text = info.title;
        artist.text = info.artist;
        description.text = info.description;
    }

    private Vector3 TextureToScale(Texture texture, float depth)
    {
        Vector3 scale = Vector3.one;
        scale.z = depth;
        if (texture.width > texture.height)
        {
            scale.y = (float)texture.height / (float)texture.width;
        } else
        {
            scale.x = (float)texture.width / (float)texture.height;
        }
        return scale;
    }
}
