using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        [Fact]
        public void WrtieLogDelegateCanPointToAMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            var result = log("hello");
            Assert.Equal("hello", result);
        }
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Adel";
            

            Assert.Equal("Adel",name);
        }

        [Fact]
        public void ValueTypePassByValue()
        {
            //arrange section
            var x = GetInt();
            SetInt(ref x);

            //act section
            
            
            //assert section
            Assert.Equal(42, x);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //arrange section
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            //act section
            
            
            //assert section
            Assert.Equal("New Name", book1.Name);
        }


        [Fact]
        public void CSharpIsPassByValue()
        {
            //arrange section
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            //act section
            
            
            //assert section
            Assert.Equal("Book 1", book1.Name);
        }
        [Fact]
        public void CSharpCanPassByReference()
        {
            //arrange section
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            //act section
            
            
            //assert section
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]//indicates a test method
        public void GetBookReturnsDifferentObjects()
        {
            //arrange section
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //act section
            
            
            //assert section
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesReferenceSameObject()
        {
            //arrange section
            var book1 = GetBook("Book 1");
            var book2 = book1;

            //act section
            
            
            //assert section
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));     
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }

        private void SetName(Book book, String name)
        {
            book.Name = name;
        }

        private void GetBookSetName(Book book, String name)
        {
            book = new Book(name);
        }

        private void GetBookSetName(ref Book book, String name)
        {
            book = new Book(name);
        }

        private int GetInt()
        {
            return 3;
        }
        private void SetInt(ref int x)
        {
            x = 42;
        }
        private void MakeUpperCase(String str)
        {
            str.ToUpper();
        }

        string ReturnMessage(string message)
        {
            return message;
        }
    }
}
