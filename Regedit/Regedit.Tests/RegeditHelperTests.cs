using Microsoft.Win32;
using System;
using Xunit;

namespace Regedit.Tests
{
    public class RegeditHelperTests
    {
        [Fact]
        public void SetRegistryKeyValueTest()
        {
            string keyName = "TestKey";
            string keyValue = "TestKeyValue";

            RegeditHelper.SetRegistryKeyValue(keyName, keyValue);
            
            string testResultValue = Registry.LocalMachine.OpenSubKey("SOFTWARE")
                .OpenSubKey(RegeditHelper.COMPANY_NAME)?.OpenSubKey(RegeditHelper.PRODUCT_NAME)?.GetValue(keyName).ToString();

            Registry.LocalMachine.DeleteSubKeyTree(RegeditHelper.COMPANY_NAME, false);

            Assert.Equal(keyValue, testResultValue);
        }
    }
}
