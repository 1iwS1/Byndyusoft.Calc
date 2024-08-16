namespace Calc.Tests
{
  public class MainProgramTests
  {
    [Theory]
    [InlineData("5+7")]
    public void Main_InputString5plus7_ReturnDouble(string expression)
    {
      // Arrange
      double checkWith = 5.0 + 7.0;


      // Act
      var result = Program.Main([expression]);


      // Assert
      Assert.Equal(checkWith, result);
    }
  }
}
