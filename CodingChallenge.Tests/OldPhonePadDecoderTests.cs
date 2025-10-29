namespace CodingChallenge.Tests
{
    public class OldPhonePadTests
    {
        [Theory]
        [InlineData("33#", "E")]
        [InlineData("227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8 88777444666*664#", "TURING")]
        public void OldPhonePad_ValidInputs_ReturnsExpected(string input, string expected)
        {
            var actual = OldPhonePadDecoder.OldPhonePad(input);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void OldPhonePad_ShouldWarnForUnknownKeySet_ErrorStream()
        {
            // Arrange
            using var sw = new StringWriter();
            var originalError = Console.Error;
            Console.SetError(sw);

            // Act
            var actual = OldPhonePadDecoder.OldPhonePad("0#");

            Console.SetError(originalError);

            // Assert: text warning should appear in error output
            var output = sw.ToString();
            Assert.Contains("Warning: '0' not found in phonePad dictionary. Skipping.", output);
            Assert.Equal("", actual);
        }
    }
}

