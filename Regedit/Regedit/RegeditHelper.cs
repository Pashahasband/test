using Microsoft.Win32;
using NLog;
using System;
using System.Security.AccessControl;

namespace Regedit
{
    class RegeditHelper
    {
        public const string COMPANY_NAME = "CompanyName";
        public const string PRODUCT_NAME = "ProductName";

        // Приватный логгер для класса
        private static Logger log = LogManager.GetCurrentClassLogger();

        public static void SetRegistryKeyValue(string keyName, string KeyValue)
        {
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE", true))
            {
                log.Debug($"Проверяем наличие ключа {COMPANY_NAME} в ветке SOFTWARE.");
                if (rk.OpenSubKey(COMPANY_NAME, true) == null)
                {
                    log.Debug($"Ключ {COMPANY_NAME} отсутствует в ветке SOFTWARE. Создаем его.");
                    rk.CreateSubKey(COMPANY_NAME, true);
                    log.Debug($"Ключ {COMPANY_NAME} создан в ветке SOFTWARE.");
                }

                using (RegistryKey companyRegKey = rk.OpenSubKey(COMPANY_NAME, true))
                {
                    log.Debug($"Проверяем наличие ключа {PRODUCT_NAME} в ветке {COMPANY_NAME}.");
                    if (companyRegKey.OpenSubKey(PRODUCT_NAME, true) == null)
                    {
                        log.Debug($"Ключ {PRODUCT_NAME} отсутствует в ветке {COMPANY_NAME}. Создаем его.");
                        companyRegKey.CreateSubKey(PRODUCT_NAME, true);
                        log.Debug($"Ключ {PRODUCT_NAME} создан в ветке {COMPANY_NAME}.");
                    }

                    using (RegistryKey productRegKey = companyRegKey.OpenSubKey(PRODUCT_NAME, true))
                    {
                        log.Debug($"Задаем значение для ключа {keyName} равным {KeyValue} в ветке {PRODUCT_NAME}.");
                        productRegKey.SetValue(keyName, KeyValue);
                        log.Debug("Значение ключа установлено.");

                        RegistrySecurity rs = new RegistrySecurity();

                        string user = Environment.UserDomainName + "\\" + Environment.UserName;

                        rs.AddAccessRule(new RegistryAccessRule(user,
                        RegistryRights.ReadKey,
                        InheritanceFlags.None,
                        PropagationFlags.None,
                        AccessControlType.Allow));

                        log.Debug($"Задаем парава доступа для ветки {PRODUCT_NAME}.");
                        productRegKey.SetAccessControl(rs);
                        log.Debug("Права доступа для ветки заданы успешно.");
                    }
                }
            }
        }
    }
}
