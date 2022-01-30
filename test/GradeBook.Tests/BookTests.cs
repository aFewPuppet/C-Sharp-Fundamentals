using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        
        [Fact]//indicates a test method
        public void BookCalculateStatistics()
        {
            //arrange section
            var book = new Book("");
            book.addGrade(89.1);
            book.addGrade(90.5);
            book.addGrade(77.3);

            //act section
            var result = book.getStatistics();
            
            //assert section
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High);
            Assert.Equal(77.3, result.Low);
            Assert.Equal('B', result.letterGrade);
            

        }
    }
}
