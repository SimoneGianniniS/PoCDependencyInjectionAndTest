using PoCDependecyInjection.BLL.Helper;

namespace PoCDependencyInjection.Test.Helper
{
    public class StringExtensionTest
    {
        [Fact(Skip = "Non serve")]
        public void Skip_test() { }

        //[Fact(Timeout =30)] // posso anche fermare(far fallire) i test asincroni nel caso impieghi più di un tot per essere eseguito Timeout =
        //public async Task FactTimeout_TimeoutLessThanProcessingTime_ThrowTestTimeoutException()
        //{
        //    var timeoutTask = Task.Delay(50);
        //    var res = await Task.WhenAny(timeoutTask);            
        //}

        #region fact
        [Fact]
        public void HasValue_ValidString_Return_True()
        {
            //setup
            var input = "pippo";
            //act
            var hasValue = input.HasValue(true);
            //verify
            Assert.True(hasValue);
        }

        [Fact]
        public void HasValue_ValidString_AllowWhiteSpace_Return_True()
        {
            var test = " ";

            var hasValue = test.HasValue(false);

            Assert.True(hasValue);
        }

        [Fact]
        public void HasValue_InvalidString_Return_False()
        {
            var input = " ";

            var hasValue = input.HasValue();

            Assert.False(hasValue);
        }
       

        [Fact]
        public void HasValue_ValidString_AllowWhiteSpace_Return_False()
        {
            var test = string.Empty;

            var hasValue = test.HasValue(false);

            Assert.False(hasValue);
        }

        //... a seguire altre possibili combinazioni in input
        #endregion

        #region theory
        [Theory]
        [InlineData("pippo", true)]
        [InlineData("pippo", false)]
        [InlineData(" ", false)]        
        public void HasValue_ValidString_Theory_Return_True(string? input, bool allowWhiteSpaceAsEmpty) 
        {

            var hasValue = input.HasValue(allowWhiteSpaceAsEmpty);

            Assert.True(hasValue);
        }
        
        [Theory]
        [InlineData(" ", true)]
        [InlineData("", true)]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData(null, true)]
        public void HasValue_InvalidString_Theory_Return_False(string? input, bool allowWhiteSpaceAsEmpty)
        {

            var hasValue = input.HasValue(allowWhiteSpaceAsEmpty);

            Assert.False(hasValue);
        }
        #endregion
    }
}
