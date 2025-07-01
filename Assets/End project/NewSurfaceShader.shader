Shader "Custom/StencilWindow"
{
    Properties
    {
        _MainTex ("Window Content Tex", 2D) = "white" {}
        _Color   ("Tint Color", Color) = (1,1,1,1)
    }

    SubShader
    {
        // Make sure both passes render after regular opaque geometry
        Tags { "RenderType"="Opaque" "Queue"="Geometry+1" }

        /////////////////////////////////////////////////////
        // 1) MASK PASS: write Ref=2 into the stencil buffer
        /////////////////////////////////////////////////////
        Pass
        {
            name "StencilMask"

            // don't draw any color
            ColorMask 0
            ZWrite Off

            Stencil
            {
                Ref 2
                Comp Always   // always pass
                Pass Replace  // replace stencil with Ref
            }
        }

        /////////////////////////////////////////////////////
        // 2) CONTENT PASS: only draw where stencil == 2
        /////////////////////////////////////////////////////
        Pass
        {
            name "StencilContent"

            // only draw pixels if stencil == 2
            Stencil
            {
                Ref 2
                Comp Equal   // succeed only where buffer == Ref
                Pass Keep    // keep the stencil value
            }

            // restore normal color and depth writes
            ColorMask RGBA
            ZWrite On

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4   _MainTex_ST;
            float4   _Color;

            struct appvert
            {
                float4 vertex : POSITION;
                float2 uv     : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv         : TEXCOORD0;
                float4 clipPos    : SV_POSITION;
            };

            v2f vert(appvert v)
            {
                v2f o;
                o.clipPos = UnityObjectToClipPos(v.vertex);
                o.uv      = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 tex = tex2D(_MainTex, i.uv);
                return tex * _Color;
            }
            ENDCG
        }
    }

    // Fallback if unsupported
    Fallback "Diffuse"
}
