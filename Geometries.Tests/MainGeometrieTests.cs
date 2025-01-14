using FluentAssertions;
using Geometries.Contracts;
using NSubstitute;
using System.Reflection.PortableExecutable;

namespace Geometries.Tests
{
    public class MainGeometrieTests
    {
        [Theory]
        [InlineData(1,10)]
        [InlineData(5, 50)]
        [InlineData(10, 100)]
        public void GetLength_MockGeometrie_CorrectLength(int numberOfGeometries, int expectedLength)
        {
            // Arrange 
            var mockGeometrie = Substitute.For<IGeometry>();
            mockGeometrie.GetLength().Returns(10);

            var list = new List<IGeometry>();
            for (int i = 0; i < numberOfGeometries; i++)
            {
                list.Add(mockGeometrie);
            }
            var mainGeometrie = new MainGeometry(list);

            // Act
            var length = mainGeometrie.GetLength();

            // Assert
            length.Should().Be(expectedLength);
        }

        [Theory]
        [InlineData(1, 10)]
        [InlineData(5, 50)]
        [InlineData(10, 100)]
        public void GetArea_MockGeometrie_CorrectArea(int numberOfGeometries, int expectedArea)
        {
            // Arrange 
            var mockGeometrie = Substitute.For<IGeometry>();
            mockGeometrie.GetArea().Returns(10);
            var list = new List<IGeometry>();
            for (int i = 0; i < numberOfGeometries; i++)
            {
                list.Add(mockGeometrie);
            }

            var mainGeometrie = new MainGeometry(list);

            // Act
            var area = mainGeometrie.GetArea();

            // Assert
            area.Should().Be(expectedArea);

        }
    }
}
