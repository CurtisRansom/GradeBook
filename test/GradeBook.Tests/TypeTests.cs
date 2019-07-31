using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {   
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {

            WriteLogDelegate log = ReturnMessage;
            
            //log = new WriteLogDelegate(ReturnMessage);
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            name = MakeUppercase(name);

            Assert.Equal("SCOTT",name);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert .Equal(42,x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt() { return 3; }
        
        [Fact]
        public void CSharpPassByReference()
        {
            // Arrange
            var book1 = GetBook("Book 1");
           
            GetBookSetName(ref book1, "New Name");

            // Act
            

            // Assert
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpPassByValue()
        {
            // Arrange
            var book1 = GetBook("Book 1");
           
            GetBookSetName(book1, "New Name");

            // Act
            

            // Assert
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // Arrange
            var book1 = GetBook("Book 1");
           
            SetName(book1, "New Name");

            // Act
            

            // Assert
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // Act
            

            // Assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            // Act
            

            // Assert
           Assert.Same(book1, book2);
           Assert.True(Object.ReferenceEquals(book1,book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
