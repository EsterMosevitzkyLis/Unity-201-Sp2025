Shader "Custom/StencilShader"
{
    SubShader
    {

    Pass
    {

    ColorMask 0
    ZWrite Off

        Stencil
    
        {
        Ref 2
        Comp Always
        Pass Replace
        }

    }
    }

}
