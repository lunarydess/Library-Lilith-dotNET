namespace Lilith.Utility {
	public sealed class ColorConverter {
		/// <summary>
		/// Converts an decimal color to a RGBA color value.
		/// </summary>
		/// <param name="color">An decimal we want the color values from.</param>
		/// <returns>An color array value. The entries represent red, green, blue, and alpha.</returns>
		public static float[] DecToRgba(in int color) => new[]
		{ ((color >> 16) & 0xFF) / 255.0F,
		  ((color >> 8)  & 0xFF) / 255.0F,
		  (color         & 0xff) / 255.0F,
		  ((color >> 24) & 0xFF) / 255.0F };

		/// <summary>
		/// Converts an RGBA color to a decimal color value.
		/// </summary>
		/// <param name="color">An array where the first four entries represent red, green, blue, and alpha.</param>
		/// <returns>A decimal color value.</returns>
		public static int RgbaToDec(params float[] color) => color.Length is < 3 or > 4 ?
																 -1 :
																 RgbaToDec(red: color[0],
																		   green: color[1],
																		   blue: color[2],
																		   alpha: color.Length == 4 ?
																			   color[4] :
																			   1.0F);

		/// <summary>
		/// Converts RGBA color components to a decimal color value.
		/// </summary>
		/// <param name="red">The red value of the color.</param>
		/// <param name="green">The green value of the color.</param>
		/// <param name="blue">The blue value of the color.</param>
		/// <param name="alpha">The alpha value of the color.</param>
		/// <returns>A decimal color value.</returns>
		public static int RgbaToDec(in float red, in float green, in float blue, in float alpha) =>
			(((int)(alpha * 255.0F) & 0xFF) << 24) |
			(((int)(red   * 255.0F) & 0xFF) << 16) |
			(((int)(green * 255.0F) & 0xFF) << 8)  |
			((int)(blue * 255.0F) & 0xFF);

		/// <summary>
		/// Converts HSV color components to an RGBA float array with alpha set to 1.0.
		/// </summary>
		/// <param name="hue">The hue of the HSV color.</param>
		/// <param name="saturation">The saturation of the HSV color.</param>
		/// <param name="value">The value of the HSV color.</param>
		/// <returns>An RGBA float array with alpha set to 1.0.</returns>
		public static float[] HsvToRgba(in float hue, in float saturation, in float value) =>
			HsvaToRgba(hue: hue, saturation: saturation, value: value, alpha: 1.0F);

		/// <summary>
		/// Converts HSVa color components to an RGBA float array.
		/// </summary>
		/// <param name="hue">The hue of the HSVa color.</param>
		/// <param name="saturation">The saturation of the HSVa color.</param>
		/// <param name="value">The value of the HSVa color.</param>
		/// <param name="alpha">The alpha of the HSVa color.</param>
		/// <returns>An RGBA float array.</returns>
		public static float[] HsvaToRgba(in float hue, in float saturation, in float value, in float alpha) {
			int hi = (int)Math.Round(value: hue * 6.0F, digits: 0);

			float f = (hue * 6.0F) - hi;

			float q = value * (1.0F - (f * saturation));
			float p = value * (1.0F - saturation);
			float t = value * (1.0F - ((1.0F - f) * saturation));

			return hi switch
			{ 0     => new[] { value, t, p, alpha },
			  1     => new[] { q, value, p, alpha },
			  2     => new[] { p, value, t, alpha },
			  3     => new[] { p, q, value, alpha },
			  4     => new[] { t, p, value, alpha },
			  var _ => new[] { value, p, q, alpha } };
		}

		/// <summary>
		/// Converts HSV color components to a decimal color value.
		/// </summary>
		/// <param name="hue">The hue of the HSV color.</param>
		/// <param name="saturation">The saturation of the HSV color.</param>
		/// <param name="value">The value of the HSV color.</param>
		/// <returns>A decimal color value.</returns>
		public static int HsvToDec(in float hue, in float saturation, in float value) =>
			HsvaToDec(hue: hue, saturation: saturation, value: value, alpha: 1.0F);

		/// <summary>
		/// Converts HSVa color components to a decimal color value.
		/// </summary>
		/// <param name="hue">The hue of the HSVa color.</param>
		/// <param name="saturation">The saturation of the HSVa color.</param>
		/// <param name="value">The value of the HSVa color.</param>
		/// <param name="alpha">The alpha of the HSVa color.</param>
		/// <returns>A decimal color value.</returns>
		public static int HsvaToDec(in float hue, in float saturation, in float value, in float alpha) =>
			RgbaToDec(color: HsvaToRgba(hue: hue, saturation: saturation, value: value, alpha: alpha));
	}
}