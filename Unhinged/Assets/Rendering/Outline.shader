Shader "Custom/Outline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Outline("Outline Width", Range(0.02, 0.2)) = .02
        _OutlineColor("Outline Color", Color) = (0,0,0,1)
    }
    SubShader
    {
        
        Tags{"Queue" = "Transparent"}
        
        Cull Off
        Lighting Off
        ZWrite off
        Blend One OneMinusSrcAlpha
        
        Pass
        {
           
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ PIXELSNAP_ON

            #include "UnityCG.cginc"

            struct v2f
            {
                float2 texcoord : TEXCOORD0;
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
            };

            sampler2D _MainTex;
            float _Outline;
            fixed4 _OutlineColor;

            v2f vert (appdata_base v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                o.vertex = UnityPixelSnap(o.vertex);
                fixed4 uv;
                uv.xy = v.texcoord.xy;
                uv.zw = 0;
                o.color = tex2Dlod(_MainTex,uv).a == 0 ? _OutlineColor : tex2Dlod(_MainTex, uv);
                o.color = tex2Dlod(_MainTex,uv);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col;
                fixed4 normalCol = tex2D(_MainTex, i.texcoord);
                float2 coordCalc;
                coordCalc.x = (i.texcoord.x + _Outline/2)/(1+_Outline);
                coordCalc.y = (i.texcoord.y + _Outline/2)/(1+_Outline);
                col.rgb = normalCol.a < .2 && tex2D(_MainTex, coordCalc).a > .2 ? _OutlineColor.rgb : normalCol.rgb;
                col.a = tex2D(_MainTex, coordCalc).a > .2 ? 1 : 0;
                if(tex2D(_MainTex, coordCalc).a < .2) {col.rgb = 0;}
                return col;
            }
            ENDCG
        }
    }
}
