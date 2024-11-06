// MyHLSL.fx

// Sampler declaration for textures
sampler2D TextureSampler : register(s0);

// World-View-Projection matrix
float4x4 WorldViewProjMatrix; // World-view-projection matrix
float4x4 RotationMatrix; // Rotation matrix
float4 Scale; // Scale vector
float Transparency; // Transparency value

// Vertex Shader Input for textured rendering (Position + TexCoord)
struct VertexShaderInput_Textured
{
    float4 Position : POSITION; // Input vertex position
    float2 TexCoord : TEXCOORD0; // Input texture coordinates
};

// Vertex Shader Input for colored rendering (Position + Color)
struct VertexShaderInput_Colored
{
    float4 Position : POSITION; // Input vertex position
    float4 Color : COLOR0; // Input color
};

// Vertex Shader Output for textured rendering
struct VertexShaderOutput_Textured
{
    float4 Position : SV_POSITION; // Transformed position for the pixel shader
    float2 TexCoord : TEXCOORD0; // Passed-through texture coordinates
};

// Vertex Shader Output for colored rendering
struct VertexShaderOutput_Colored
{
    float4 Position : SV_POSITION; // Transformed position for the pixel shader
    float4 Color : COLOR0; // Passed-through color
};

// Vertex Shader for textured rendering
VertexShaderOutput_Textured VertexShaderFunction_Textured(VertexShaderInput_Textured input)
{
    VertexShaderOutput_Textured output;

    // Transform the vertex position using the WorldViewProjMatrix and RotationMatrix
    output.Position = mul(input.Position, mul(RotationMatrix, WorldViewProjMatrix));
    output.TexCoord = input.TexCoord; // Pass-through texture coordinates

    return output;
}

// Vertex Shader for colored rendering
VertexShaderOutput_Colored VertexShaderFunction_Colored(VertexShaderInput_Colored input)
{
    VertexShaderOutput_Colored output;

    // Transform the vertex position using the WorldViewProjMatrix
    output.Position = mul(input.Position, WorldViewProjMatrix);
    output.Color = input.Color; // Pass-through color (including transparency)

    return output;
}

// Pixel Shader for textured rendering
float4 PixelShaderFunction_Textured(VertexShaderOutput_Textured input) : SV_TARGET
{
    // Sample the texture using the texture coordinates
    float4 color = tex2D(TextureSampler, input.TexCoord);
    
    // Apply transparency to the texture
    color.a *= Transparency; // Modify alpha channel with transparency value

    return color; // Return the final color
}

// Pixel Shader for colored rendering
float4 PixelShaderFunction_Colored(VertexShaderOutput_Colored input) : SV_TARGET
{
    // Just apply transparency to the color
    input.Color.a *= Transparency; // Modify alpha channel with transparency value

    return input.Color; // Return the final color
}

// Technique for textured rendering
technique Technique_Textured
{
    pass P0
    {
        VertexShader = compile vs_4_0_level_9_1 VertexShaderFunction_Textured();
        PixelShader = compile ps_4_0_level_9_1 PixelShaderFunction_Textured();
    }
}

// Technique for colored rendering
technique Technique_Colored
{
    pass P0
    {
        VertexShader = compile vs_4_0_level_9_1 VertexShaderFunction_Colored();
        PixelShader = compile ps_4_0_level_9_1 PixelShaderFunction_Colored();
    }
}

// Add Pretransformed technique that uses the colored vertex shader and pixel shader
technique Pretransformed
{
    pass P0
    {
        VertexShader = compile vs_4_0_level_9_1 VertexShaderFunction_Colored();
        PixelShader = compile ps_4_0_level_9_1 PixelShaderFunction_Colored();
    }
}