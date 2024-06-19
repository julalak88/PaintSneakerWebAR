Shader "Unlit/Cutoff"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Cull Off

        ZWrite on
        ColorMask 0

        Pass
        { }

    }
}
