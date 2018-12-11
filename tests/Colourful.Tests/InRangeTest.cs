using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Colourful.Tests
{
    public class InRangeTest
    {
        public static readonly IEnumerable<object[]> IsInRangeData = new[]
        {
            new object[] { 0.5, 0.5, 0.5, true },
            new object[] { 0.0, 0.0, 0.0, true },
            new object[] { 1.0, 1.0, 1.0, true },
            new object[] { 1.1, 0.0, 0.0, false },
            new object[] { 0.0, 1.1, 0.0, false },
            new object[] { 0.0, 0.0, 1.1, false },
            new object[] { 1.1, -0.1, 1.1, false },
        };

        public static readonly IEnumerable<object[]> CropRangeData = new[]
        {
            new object[] { 0.5, 0.5, 0.5, 0.5, 0.5, 0.5 },
            new object[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
            new object[] { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 },
            new object[] { 1.1, 0.0, 0.0, 1.0, 0.0, 0.0 },
            new object[] { 0.0, 1.1, 0.0, 0.0, 1.0, 0.0 },
            new object[] { 0.0, 0.0, 1.1, 0.0, 0.0, 1.0 },
            new object[] { 1.1, -0.1, 1.1, 1.0, 0.0, 1.0 },
        };

        /// <summary>
        /// Tests <see cref="RGBColor.IsInRange" />
        /// </summary>
        [Theory]
        [MemberData(nameof(IsInRangeData))]
        public void RGBColorIsInRange(double r, double g, double b, bool expected)
        {
            // arrange
            var color = new RGBColor(r, g, b);

            // assert
            Assert.Equal(expected, color.IsInRange);
        }

        /// <summary>
        /// Tests <see cref="RGBColor.IsInRange" />
        /// </summary>
        [Theory]
        [MemberData(nameof(IsInRangeData))]
        public void LinearRGBColorIsInRange(double r, double g, double b, bool expected)
        {
            // arrange
            var color = new LinearRGBColor(r, g, b);

            // assert
            Assert.Equal(expected, color.IsInRange);
        }

        /// <summary>
        /// Tests <see cref="RGBColor.CropRange" />
        /// </summary>
        [Theory]
        [MemberData(nameof(CropRangeData))]
        public void RGBColorCropRange(double inputR, double inputG, double inputB, double expectedR, double expectedG, double expectedB)
        {
            // arrange
            var input = new RGBColor(inputR, inputG, inputB);
            var expected = new RGBColor(expectedR, expectedG, expectedB);

            // act
            var actual = input.CropRange();

            // assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Tests <see cref="LinearRGBColor.CropRange" />
        /// </summary>
        [Theory]
        [MemberData(nameof(CropRangeData))]
        public void LinearRGBColorCropRange(double inputR, double inputG, double inputB, double expectedR, double expectedG, double expectedB)
        {
            // arrange
            var input = new LinearRGBColor(inputR, inputG, inputB);
            var expected = new LinearRGBColor(expectedR, expectedG, expectedB);

            // act
            var actual = input.CropRange();

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
