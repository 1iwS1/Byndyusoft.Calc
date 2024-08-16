namespace Calc.Tests
{
  public class MainProgramTests
  {
    [Theory]
    [InlineData("5+7")]
    [InlineData("-4/2+7-(-9)")]
    public void Main_InputString5plus7_ReturnIntResult(string expression)
    {
      // Act
      var result = Program.Main([expression]);

      // Assert
      Assert.Equal(1, result);
    }
  }
}
