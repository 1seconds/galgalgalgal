Shader "Hidden/Colorblind"
{
  Properties
 {
      _MainTex("Texture", 2D) = "white" {}
   }
  SubShader
  {
      Cull Off ZWrite Off ZTest Always

      Pass
       {
          CGPROGRAM
          #pragma target 3.0

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;

            #pragma vertex vert
            #pragma fragment frag

         #include "UnityCG.cginc"

          // says which matrix we should use in fragment shader
          // this is passed from the Csharp script
           uniform int type;

         // color-shifting matrices
      

           struct v2f {
               float4 pos : SV_POSITION;
              float2 uv : TEXCOORD0;
         } ;

          // vertex shader
           v2f vert(appdata_img v)
            {
              v2f o;
             o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = MultiplyUV(UNITY_MATRIX_TEXTURE0, v.texcoord);
              return o;
          }
        half4 temp = {1.0f,1.0f,1.0f,1.0f};

         // fragment shader
         half4 frag(v2f i) : SV_Target
          {   
               // read the color from input texture
               half4 color =  tex2D(_MainTex, i.uv);
               if(type==0) return color;
               else return half4( half4((1.0 - color.rgb), color.a));              
          }       
          ENDCG
      }

 }
}