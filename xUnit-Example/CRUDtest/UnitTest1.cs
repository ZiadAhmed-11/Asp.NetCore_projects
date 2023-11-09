namespace CRUDtest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            Mymath mm=new Mymath();
            int a=10, b=20;
            int expected = 30;
            //Act
            int actual=mm.Add(a,b);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}