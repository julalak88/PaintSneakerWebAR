using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sneaker : MonoBehaviour
{
    [SerializeField] private string sneakerName; 
    [SerializeField] Texture2D uvMapping;
    [SerializeField] private int referenceWidth9_16, referenceHeight9_16, frameStartPointX9_16, frameStartPointY9_16;
    [SerializeField] private int referenceWidth3_4, referenceHeight3_4, frameStartPointX3_4, frameStartPointY3_4;
    private bool is3To4Ratio = false;
    public Texture2D GetUV()
    {
        return this.uvMapping;
    }

    public string GetName()
    {
        return this.sneakerName;
    }

    public int GetRefWidth()
    {
        if (is3To4Ratio == true)
        {
            return referenceWidth3_4;
        }
        else
        {
            return referenceWidth9_16;
        }
    }

    public int GetRefHeight()
    {
        if (is3To4Ratio == true)
        {
            return referenceHeight3_4;
        }
        else
        {
            return referenceHeight9_16;
        }
    }

    public int GetStartPointX()
    {
        if (is3To4Ratio == true)
        {
            return frameStartPointX3_4;
        }
        else
        {
            return frameStartPointX9_16;
        }
    }

    public int GetStartPointY()
    {
        if (is3To4Ratio == true)
        {
            return frameStartPointY3_4;
        }
        else
        {
            return frameStartPointY9_16;
        }
    }
    public void SetRatio(bool is3To4Ratio)
    {
        this.is3To4Ratio = is3To4Ratio;
    }
}
