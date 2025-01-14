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
            Assert.Equal(expectedLength, length);
        }
    }
}
