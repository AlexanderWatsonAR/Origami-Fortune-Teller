#ifndef DIFFRACTION_LIGHTING_INCLUDED
#define DIFFRACTION_LIGHTING_INCLUDED

// Spectral Colour Schemes
// By Alan Zucconi
// Website: www.alanzucconi.com
// Twitter: @AlanZucconi

// Example of different spectral colour schemes
// to convert visible wavelengths of light (400-700 nm) to RGB colours.

// The function "spectral_zucconi6" provides the best approximation
// without including any branching.
// Its faster version, "spectral_zucconi", is advised for mobile applications.


float saturatef(float x)
{
    return min(1.0, max(0.0, x));
}

float3 saturatef3(float3 x)
{
    return min(float3(1, 1, 1), max(float3(0, 0, 0), x));
}

float3 bump3(float3 x)
{
    float3 y = float3(1, 1, 1) - x * x;
    y = max(y, float3(0, 0, 0));
    return y;
}

float3 bump3y(float3 x, float3 yoffset)
{
    float3 y = float3(1, 1, 1) - x * x;
    y = saturatef3(y - yoffset);
    return y;
}

float3 spectral_zucconi(float w)
{
    // w: [400, 700]
    // x: [0,   1]
    float x = saturatef((w - 400.0) / 300.0);

    const float3 cs = float3(3.54541723, 2.86670055, 2.29421995);
    const float3 xs = float3(0.69548916, 0.49416934, 0.28269708);
    const float3 ys = float3(0.02320775, 0.15936245, 0.53520021);

    return bump3y(cs * (x - xs), ys);
}

float3 spectral_zucconi6(float w)
{
    // w: [400, 700] nanometres.
    // x: [0,   1] normalised value.
    // https://www.alanzucconi.com/2017/07/15/improving-the-rainbow-2/
    float x = saturatef((w - 400.0) / 300.0);

    const float3 c1 = float3(3.54585104, 2.93225262, 2.41593945);
    const float3 x1 = float3(0.69549072, 0.49228336, 0.27699880);
    const float3 y1 = float3(0.02312639, 0.15225084, 0.52607955);

    const float3 c2 = float3(3.90307140, 3.21182957, 3.96587128);
    const float3 x2 = float3(0.11748627, 0.86755042, 0.66077860);
    const float3 y2 = float3(0.84897130, 0.88445281, 0.73949448);

    return
        bump3y(c1 * (x - x1), y1) +
        bump3y(c2 * (x - x2), y2);
}

float3 spectral_gems(float w)
{
    // w: [400, 700]
    // x: [0,   1]
    float x = saturatef((w - 400.0) / 300.0);

    return bump3
    (float3
    (
        4. * (x - 0.75),	// Red
        4. * (x - 0.5),	// Green
        4. * (x - 0.25)	// Blue
    )
    );
}

float3 spectral_bruton(float w)
{
	float3 c;

	if (w >= 380. && w < 440.)
		c = float3
		(
			-(w - 440.) / (440. - 380.),
			0.0,
			1.0
		);
	else if (w >= 440. && w < 490.)
		c = float3
		(
			0.0,
			(w - 440.) / (490. - 440.),
			1.0
		);
	else if (w >= 490. && w < 510.)
		c = float3
		(0.0,
			1.0,
			-(w - 510.) / (510. - 490.)
		);
	else if (w >= 510. && w < 580.)
		c = float3
		(
			(w - 510.) / (580. - 510.),
			1.0,
			0.0
		);
	else if (w >= 580. && w < 645.)
		c = float3
		(
			1.0,
			-(w - 645.) / (645. - 580.),
			0.0
		);
	else if (w >= 645. && w <= 780.)
		c = float3
		(1.0,
			0.0,
			0.0
		);
	else
		c = float3
		(0.0,
			0.0,
			0.0
		);

	return saturate(c);
}

float3 spectral_spektre(float l)
{
	float r = 0.0, g = 0.0, b = 0.0;
	if ((l >= 400.0) && (l < 410.0)) { float t = (l - 400.0) / (410.0 - 400.0); r = +(0.33 * t) - (0.20 * t * t); }
	else if ((l >= 410.0) && (l < 475.0)) { float t = (l - 410.0) / (475.0 - 410.0); r = 0.14 - (0.13 * t * t); }
	else if ((l >= 545.0) && (l < 595.0)) { float t = (l - 545.0) / (595.0 - 545.0); r = +(1.98 * t) - (t * t); }
	else if ((l >= 595.0) && (l < 650.0)) { float t = (l - 595.0) / (650.0 - 595.0); r = 0.98 + (0.06 * t) - (0.40 * t * t); }
	else if ((l >= 650.0) && (l < 700.0)) { float t = (l - 650.0) / (700.0 - 650.0); r = 0.65 - (0.84 * t) + (0.20 * t * t); }
	if ((l >= 415.0) && (l < 475.0)) { float t = (l - 415.0) / (475.0 - 415.0); g = +(0.80 * t * t); }
	else if ((l >= 475.0) && (l < 590.0)) { float t = (l - 475.0) / (590.0 - 475.0); g = 0.8 + (0.76 * t) - (0.80 * t * t); }
	else if ((l >= 585.0) && (l < 639.0)) { float t = (l - 585.0) / (639.0 - 585.0); g = 0.82 - (0.80 * t); }
	if ((l >= 400.0) && (l < 475.0)) { float t = (l - 400.0) / (475.0 - 400.0); b = +(2.20 * t) - (1.50 * t * t); }
	else if ((l >= 475.0) && (l < 560.0)) { float t = (l - 475.0) / (560.0 - 475.0); b = 0.7 - (t)+(0.30 * t * t); }

	return float3(r, g, b);
}

#endif