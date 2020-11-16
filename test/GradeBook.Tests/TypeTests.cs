using System;
using Xunit;

namespace GradeBook.Tests
{


    public delegate string  WriteLogDelegate(string logMessage);
    public class TypeTests 
    {
      int count = 0;


      [Fact]
      public void WriteLogDelegateCanPointToMethod()
      {
       //Given//

        WriteLogDelegate log = ReturnMessage;             
       //When//

        log += ReturnMessage;
        log += IncrementCount;
       //Then//

        var result = log("Ola!");
        Assert.Equal(3, count);
      }
      
      string IncrementCount(string message)
      {
        count++;
        return message.ToLower();
      }

      string ReturnMessage(string message)
      {
        count++;
        return message;
      }

      [Fact]
      public void CanSetNameFromReference()
      {
        var book1 = GetBook("Book 1");
        SetName(book1, "New Name");

        Assert.Equal("New Name", book1.Name);
      }

      private void SetName(Book book, string name)
      {
         book.Name = name;
      }


      [Fact]
      public void StringBehaveLikeValueTypes()
      {
         string name = "Matheus";
         var upper = MakeUpperCase(name);

         Assert.Equal("Matheus", name);
         Assert.Equal("MATHEUS", upper);


      }

      private string MakeUpperCase(string parameter)
      {
        return parameter.ToUpper(); 
      }




        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
          var book1 = GetBook("Book 1");
          var book2 = GetBook("Book 2");

          Assert.Equal("Book 1", book1.Name);
          Assert.Equal("Book 2", book2.Name);
          Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
          var book1 = GetBook("Book 1");
          var book2 = book1;

          Assert.Equal(book1, book2);
          Assert.True(Object.ReferenceEquals(book1, book2));

        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
