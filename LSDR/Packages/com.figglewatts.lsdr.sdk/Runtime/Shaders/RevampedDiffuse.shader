Shader "LSDR/RevampedDiffuse"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Tint ("Tint Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
        }
        Pass
        {
            ZTest LEqual
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #pragma multi_compile_fog
            #include "LSDR.cginc"

            v2f vert(appdata v)
            {
                return revampedVert(v);
            }

            sampler2D _MainTex;
            fixed4 _Tint;

            fragOut frag(v2f input)
            {
                return revampedFragCutout(input, _MainTex, _Tint);
            }
            ENDCG
        }
    }
}