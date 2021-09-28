Shader "UIBackground"
{
    Properties
    {
	 // Stencil Mask Stuff.
	_StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _ColorMask ("Color Mask", Float) = 15

        [NoScaleOffset]Texture2D_58e8b6057b4b439fa9522220fb8b6aa7("UI Texture", 2D) = "white" {}
        [NoScaleOffset]Texture2D_b0a9516f8a4c4647a2b2c70399c43940("Background", 2D) = "white" {}
    }
    SubShader
    {
        Tags
        {
            // RenderPipeline: <None>
            "RenderType"="Transparent"
            "Queue"="Transparent+0"
        }
        Pass
        {
            Stencil
	    {
    	        Ref [_Stencil]
                Comp [_StencilComp]
                Pass [_StencilOp]
                ReadMask 255
                WriteMask 255
	    }

	    ColorMask [_ColorMask]

            // Name: <None>
            Tags
            {
                // LightMode: <None>
            }

            // Render State
            // RenderState: <None>

            // Debug
            // <None>

            // --------------------------------------------------
            // Pass

            HLSLPROGRAM

            // Pragmas
            #pragma vertex vert
        #pragma fragment frag

            // DotsInstancingOptions: <None>
            // HybridV1InjectedBuiltinProperties: <None>

            // Keywords
            // PassKeywords: <None>
            // GraphKeywords: <None>

            // Defines
            #define ATTRIBUTES_NEED_TEXCOORD0
            #define VARYINGS_NEED_TEXCOORD0
            /* WARNING: $splice Could not find named fragment 'PassInstancing' */
            #define SHADERPASS SHADERPASS_PREVIEW
        #define SHADERGRAPH_PREVIEW
            /* WARNING: $splice Could not find named fragment 'DotsInstancingVars' */

            // Includes
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Packing.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/EntityLighting.hlsl"
        #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/ShaderVariables.hlsl"
        #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/ShaderVariablesFunctions.hlsl"
        #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/Functions.hlsl"

            // --------------------------------------------------
            // Structs and Packing

            struct Attributes
        {
            float3 positionOS : POSITION;
            float4 uv0 : TEXCOORD0;
            #if UNITY_ANY_INSTANCING_ENABLED
            uint instanceID : INSTANCEID_SEMANTIC;
            #endif
        };
        struct Varyings
        {
            float4 positionCS : SV_POSITION;
            float4 texCoord0;
            #if UNITY_ANY_INSTANCING_ENABLED
            uint instanceID : CUSTOM_INSTANCE_ID;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
            #endif
        };
        struct SurfaceDescriptionInputs
        {
            float4 uv0;
        };
        struct VertexDescriptionInputs
        {
        };
        struct PackedVaryings
        {
            float4 positionCS : SV_POSITION;
            float4 interp0 : TEXCOORD0;
            #if UNITY_ANY_INSTANCING_ENABLED
            uint instanceID : CUSTOM_INSTANCE_ID;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
            #endif
        };

            PackedVaryings PackVaryings (Varyings input)
        {
            PackedVaryings output;
            output.positionCS = input.positionCS;
            output.interp0.xyzw =  input.texCoord0;
            #if UNITY_ANY_INSTANCING_ENABLED
            output.instanceID = input.instanceID;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            output.cullFace = input.cullFace;
            #endif
            return output;
        }
        Varyings UnpackVaryings (PackedVaryings input)
        {
            Varyings output;
            output.positionCS = input.positionCS;
            output.texCoord0 = input.interp0.xyzw;
            #if UNITY_ANY_INSTANCING_ENABLED
            output.instanceID = input.instanceID;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            output.cullFace = input.cullFace;
            #endif
            return output;
        }

            // --------------------------------------------------
            // Graph

            // Graph Properties
            CBUFFER_START(UnityPerMaterial)
        float4 Texture2D_58e8b6057b4b439fa9522220fb8b6aa7_TexelSize;
        float4 Texture2D_b0a9516f8a4c4647a2b2c70399c43940_TexelSize;
        CBUFFER_END

        // Object and Global properties
        SAMPLER(SamplerState_Linear_Repeat);
        TEXTURE2D(Texture2D_58e8b6057b4b439fa9522220fb8b6aa7);
        SAMPLER(samplerTexture2D_58e8b6057b4b439fa9522220fb8b6aa7);
        TEXTURE2D(Texture2D_b0a9516f8a4c4647a2b2c70399c43940);
        SAMPLER(samplerTexture2D_b0a9516f8a4c4647a2b2c70399c43940);

            // Graph Functions
            
        void Unity_Multiply_float(float4 A, float4 B, out float4 Out)
        {
            Out = A * B;
        }

            // Graph Vertex
            // GraphVertex: <None>

            // Graph Pixel
            struct SurfaceDescription
        {
            float4 Out;
        };

        SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
        {
            SurfaceDescription surface = (SurfaceDescription)0;
            UnityTexture2D _Property_07060310f58a4a33af74e4e825600de5_Out_0 = UnityBuildTexture2DStructNoScale(Texture2D_58e8b6057b4b439fa9522220fb8b6aa7);
            float4 _SampleTexture2D_402821e5d5a84277882a7da66073b141_RGBA_0 = SAMPLE_TEXTURE2D(_Property_07060310f58a4a33af74e4e825600de5_Out_0.tex, _Property_07060310f58a4a33af74e4e825600de5_Out_0.samplerstate, IN.uv0.xy);
            float _SampleTexture2D_402821e5d5a84277882a7da66073b141_R_4 = _SampleTexture2D_402821e5d5a84277882a7da66073b141_RGBA_0.r;
            float _SampleTexture2D_402821e5d5a84277882a7da66073b141_G_5 = _SampleTexture2D_402821e5d5a84277882a7da66073b141_RGBA_0.g;
            float _SampleTexture2D_402821e5d5a84277882a7da66073b141_B_6 = _SampleTexture2D_402821e5d5a84277882a7da66073b141_RGBA_0.b;
            float _SampleTexture2D_402821e5d5a84277882a7da66073b141_A_7 = _SampleTexture2D_402821e5d5a84277882a7da66073b141_RGBA_0.a;
            UnityTexture2D _Property_3828bce8cb0e4d15a54e4578f141989a_Out_0 = UnityBuildTexture2DStructNoScale(Texture2D_b0a9516f8a4c4647a2b2c70399c43940);
            float4 _SampleTexture2D_e5671237c56948379c61aa23e35ae2eb_RGBA_0 = SAMPLE_TEXTURE2D(_Property_3828bce8cb0e4d15a54e4578f141989a_Out_0.tex, _Property_3828bce8cb0e4d15a54e4578f141989a_Out_0.samplerstate, IN.uv0.xy);
            float _SampleTexture2D_e5671237c56948379c61aa23e35ae2eb_R_4 = _SampleTexture2D_e5671237c56948379c61aa23e35ae2eb_RGBA_0.r;
            float _SampleTexture2D_e5671237c56948379c61aa23e35ae2eb_G_5 = _SampleTexture2D_e5671237c56948379c61aa23e35ae2eb_RGBA_0.g;
            float _SampleTexture2D_e5671237c56948379c61aa23e35ae2eb_B_6 = _SampleTexture2D_e5671237c56948379c61aa23e35ae2eb_RGBA_0.b;
            float _SampleTexture2D_e5671237c56948379c61aa23e35ae2eb_A_7 = _SampleTexture2D_e5671237c56948379c61aa23e35ae2eb_RGBA_0.a;
            float4 _Multiply_a0ab028b0f8242bd9f8aecc57429dc6b_Out_2;
            Unity_Multiply_float(_SampleTexture2D_402821e5d5a84277882a7da66073b141_RGBA_0, _SampleTexture2D_e5671237c56948379c61aa23e35ae2eb_RGBA_0, _Multiply_a0ab028b0f8242bd9f8aecc57429dc6b_Out_2);
            surface.Out = all(isfinite(_Multiply_a0ab028b0f8242bd9f8aecc57429dc6b_Out_2)) ? half4(_Multiply_a0ab028b0f8242bd9f8aecc57429dc6b_Out_2.x, _Multiply_a0ab028b0f8242bd9f8aecc57429dc6b_Out_2.y, _Multiply_a0ab028b0f8242bd9f8aecc57429dc6b_Out_2.z, 1.0) : float4(1.0f, 0.0f, 1.0f, 1.0f);
            return surface;
        }

            // --------------------------------------------------
            // Build Graph Inputs

            SurfaceDescriptionInputs BuildSurfaceDescriptionInputs(Varyings input)
        {
            SurfaceDescriptionInputs output;
            ZERO_INITIALIZE(SurfaceDescriptionInputs, output);





            output.uv0 =                         input.texCoord0;
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN output.FaceSign =                    IS_FRONT_VFACE(input.cullFace, true, false);
        #else
        #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
        #endif
        #undef BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN

            return output;
        }

            // --------------------------------------------------
            // Main

            #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/PreviewVaryings.hlsl"
        #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/PreviewPass.hlsl"

            ENDHLSL
        }
    }
    FallBack "Hidden/Shader Graph/FallbackError"
}