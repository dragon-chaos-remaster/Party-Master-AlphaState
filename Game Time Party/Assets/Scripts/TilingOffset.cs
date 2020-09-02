using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public enum TilingAxis { xAxis,yAxis,Both }
public class TilingOffset : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] TilingAxis tilingAxis;
    Vector2 offset;
    [SerializeField] float tilingSpeed;

    [Range(0.1f, 2f)]
    [SerializeField] float tilingAcceleration;
    
   
    [SerializeField] float imageScale;
    
    public void TilingEffect()
    {
        offset.x += tilingSpeed * Time.deltaTime * tilingAcceleration;
        offset.y += tilingSpeed * Time.deltaTime * tilingAcceleration;
        Vector2 imageOffset = new Vector2(offset.x, offset.y);
        Vector2 imageSize = new Vector2(imageScale, imageScale);
        switch (tilingAxis)
        {
            case TilingAxis.xAxis:
                image.uvRect = new Rect(new Vector2(imageOffset.x,0), imageSize);
                break;
            case TilingAxis.yAxis:
                image.uvRect = new Rect(new Vector2(0,imageOffset.y), imageSize);
                break;
            case TilingAxis.Both:
                image.uvRect = new Rect(imageOffset, imageSize);
                break;

        }
    }
    void Update()
    {
        TilingEffect();
    }
}
