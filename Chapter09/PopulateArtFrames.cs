using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[System.Serializable]
//public struct ArtInfo
//{
//    public Texture image;
//    public string title;
//    public string artist;
//    public string description;
//}

public class PopulateArtFrames : MonoBehaviour
{
    public List<ArtInfo> artInfos = new List<ArtInfo>();

    void Start()
    {
        int index = 0;
        foreach (Transform artwork in transform)
        {
            artwork.GetComponent<ArtworkController>().SetArtInfo(artInfos[index]);

            index++;
            if (index == artInfos.Count || artInfos[index]==null)
                break;
        }
    }


}
