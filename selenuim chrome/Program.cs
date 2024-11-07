using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


class Program
{
    public static IWebElement WaitForElementVisible(IWebDriver driver, By locator, int timeoutInSeconds)
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("Element not found within the timeout period.");
            return null;
        }
    }

    static void Main(string[] args)
    {
        // Указываем путь к ChromeDriver (можно не указывать, если драйвер в PATH)
        var options = new ChromeOptions();

        // Если вы хотите использовать конкретный путь к браузеру Chromium, укажите его здесь:
        options.BinaryLocation = @"C:\Users\User\AppData\Local\Chromium\Application\chrome.exe"; // Замените на путь к вашему Chromium

        // Создаем экземпляр ChromeDriver с указанными опциями
        using (IWebDriver driver = new ChromeDriver(options))
        {
            // Открываем страницу
            driver.Navigate().GoToUrl("http://ssl.budgetplan.minfin.ru");

            IWebElement myElement = WaitForElementVisible(driver, By.LinkText("Вход по сертификату"), 300);

            if (myElement != null)
            {
                myElement.Click();
            }

            // Выводим заголовок страницы в консоль
            //Console.WriteLine("Page Title: " + driver.Title);

            // Ожидаем, чтобы страница была открыта
            //Console.ReadLine();

            // Закрываем браузер
            driver.Quit();
        }
    }
}
