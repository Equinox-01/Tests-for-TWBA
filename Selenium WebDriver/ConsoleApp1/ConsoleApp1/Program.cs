using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    delegate void TestExecutor();

    class Program
    {
        public static void ExceptionManager(TestExecutor indata, string number)
        {
            try
            {
                indata();
                Console.WriteLine(number + " тест выполнен");
            }
            catch
            {
                Console.WriteLine(number + " тест провален");
            }
        }

        [TestFixture]
        public class Tester
        {
            private OpenQA.Selenium.IWebDriver driver;
            private StringBuilder verificationErrors;
            private string baseURL;
            private bool acceptNextAlert = true;

            [SetUp]
            public void SetupTest()
            {
                driver = new OpenQA.Selenium.Chrome.ChromeDriver();
                baseURL = "http://svyatoslav.biz/testlab/megaform.php";
                verificationErrors = new StringBuilder();
            }

            [TearDown]
            public void TeardownTest()
            {
                try
                {
                    driver.Quit();
                }
                catch (Exception)
                {
                    // Ignore errors if unable to close the browser
                }
                Assert.AreEqual("", verificationErrors.ToString());
            }

            [Test]
            public void The1Test()
            {
                driver.Navigate().GoToUrl(baseURL + "/testlab/megaform.php");
                try
                {
                    Assert.AreEqual("", driver.FindElement(By.Name("name_l")).Text);
                }
                catch (AssertionException e)
                {
                    verificationErrors.Append(e.Message);
                }
                try
                {
                    Assert.AreEqual("", driver.FindElement(By.Name("name_f")).Text);
                }
                catch (AssertionException e)
                {
                    verificationErrors.Append(e.Message);
                }
                try
                {
                    Assert.AreEqual("", driver.FindElement(By.Name("name_m")).Text);
                }
                catch (AssertionException e)
                {
                    verificationErrors.Append(e.Message);
                }
            }
            [Test]
            public void The2Test()
            {
                driver.Navigate().GoToUrl(baseURL + "/testlab/megaform.php");
                Assert.AreEqual("01", driver.FindElement(By.Name("bd_d")).Text);
                Assert.AreEqual("01", driver.FindElement(By.Name("bd_m")).Text);
                Assert.AreEqual("1970", driver.FindElement(By.Name("bd_y")).Text);
            }
            [Test]
            public void The3Test()
            {
                driver.Navigate().GoToUrl(baseURL + "/testlab/megaform.php");
                Assert.AreEqual("off", driver.FindElement(By.XPath("(//input[@name='gender'])[1]")).GetAttribute("value"));
                Assert.AreEqual("off", driver.FindElement(By.XPath("(//input[@name='gender'])[2]")).GetAttribute("value"));
            }
            [Test]
            public void The4Test()
            {
                driver.Navigate().GoToUrl(baseURL + "/testlab/megaform.php");
                new SelectElement(driver.FindElement(By.Name("cnt"))).SelectByText("[выбрать]");
                Assert.AreEqual(1, driver.FindElements(By.XPath("//select[@name='reg' and (@disable='' or @disable='disable')]")).Count);
                Assert.AreEqual(1, driver.FindElements(By.XPath("//select[@name='city' and (@disable='' or @disable='disable')]")).Count);
            }
            [Test]
            public void The5Test()
            {
                driver.Navigate().GoToUrl(baseURL + "/testlab/megaform.php");
                Assert.AreEqual(1, driver.FindElements(By.XPath("//select[@name='reg' and @disabled='disabled']")).Count);
                new SelectElement(driver.FindElement(By.Name("cnt"))).SelectByText("Беларусь");
                Assert.AreEqual(1, driver.FindElements(By.XPath("//select[@name='reg']")).Count);
            }
            [Test]
            public void The6Test()
            {
                driver.Navigate().GoToUrl(baseURL + "/testlab/megaform.php");
                driver.FindElement(By.Name("go")).Click();
                Assert.AreEqual("Не указана фамилия\nНе указано имя\nНе указано отчество\nНе указан пол\nНеверный пароль", driver.FindElement(By.CssSelector("b")).Text);
            }
            [Test]
            public void The7Test()
            {
                driver.Navigate().GoToUrl(baseURL + "/testlab/megaform.php");
                Assert.AreEqual(1, driver.FindElements(By.XPath("//textarea[@name='family']")).Count);
                Assert.AreEqual(1, driver.FindElements(By.XPath("//textarea[@name='bio']")).Count);
            }
            [Test]
            public void The8Test()
            {
                driver.Navigate().GoToUrl(baseURL + "/testlab/megaform.php");
                Assert.AreNotEqual("window.getComputedStyle(window.document.querySelector('input')).getPropertyValue('background-color');", "rgb(204, 230, 255)");
            }
            [Test]
            public void The9Test()
            {
                driver.Navigate().GoToUrl(baseURL + "/testlab/megaform.php");
                driver.FindElement(By.Name("name_l")).Clear();
                driver.FindElement(By.Name("name_l")).SendKeys("Вересковский");
                driver.FindElement(By.Name("name_f")).Clear();
                driver.FindElement(By.Name("name_f")).SendKeys("Станислав");
                driver.FindElement(By.Name("name_m")).Clear();
                driver.FindElement(By.Name("name_m")).SendKeys("Васильевич");
                driver.FindElement(By.Name("bd_d")).Clear();
                driver.FindElement(By.Name("bd_d")).SendKeys("28");
                driver.FindElement(By.Name("bd_m")).Clear();
                driver.FindElement(By.Name("bd_m")).SendKeys("05");
                driver.FindElement(By.Name("bd_y")).Clear();
                driver.FindElement(By.Name("bd_y")).SendKeys("1998");
                driver.FindElement(By.Name("gender")).Click();
                new SelectElement(driver.FindElement(By.Name("cnt"))).SelectByText("Беларусь");
                new SelectElement(driver.FindElement(By.Name("reg"))).SelectByText("Минская");
                new SelectElement(driver.FindElement(By.Name("city"))).SelectByText("Минск");
                driver.FindElement(By.Name("login")).Clear();
                driver.FindElement(By.Name("login")).SendKeys("equinox");
                driver.FindElement(By.Name("password1")).Clear();
                driver.FindElement(By.Name("password1")).SendKeys("1234");
                driver.FindElement(By.Name("password2")).Clear();
                driver.FindElement(By.Name("password2")).SendKeys("1234");
                driver.FindElement(By.Name("family")).Click();
                driver.FindElement(By.Name("bio")).Clear();
                driver.FindElement(By.Name("bio")).SendKeys("Некоторая информация.");
                driver.FindElement(By.Name("photo")).Clear();
                driver.FindElement(By.Name("photo")).SendKeys("C:\\Users\\Voyager\\Desktop\\Изображения\\фотошопотбога.jpg");
                driver.FindElement(By.Name("go")).Click();
                Assert.AreEqual("Спасибо, регистрация успешно завершена", driver.FindElement(By.CssSelector("html")).Text);
            }
            [Test]
            public void The10Test()
            {
                driver.Navigate().GoToUrl(baseURL + "/testlab/megaform.php");
                driver.FindElement(By.Name("go")).Click();
                driver.FindElement(By.Name("name_l")).Clear();
                driver.FindElement(By.Name("name_l")).SendKeys("f");
                Assert.IsFalse(IsAlertPresent());
            }
            private bool IsElementPresent(By by)
            {
                try
                {
                    driver.FindElement(by);
                    return true;
                }
                catch (OpenQA.Selenium.NoSuchElementException)
                {
                    return false;
                }
            }

            private bool IsAlertPresent()
            {
                try
                {
                    driver.SwitchTo().Alert();
                    return true;
                }
                catch (NoAlertPresentException)
                {
                    return false;
                }
            }

            private string CloseAlertAndGetItsText()
            {
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    string alertText = alert.Text;
                    if (acceptNextAlert)
                    {
                        alert.Accept();
                    }
                    else
                    {
                        alert.Dismiss();
                    }
                    return alertText;
                }
                finally
                {
                    acceptNextAlert = true;
                }
            }
        }

        static void Main(string[] args)
        {
            Tester t = new Tester();
            t.SetupTest();
            ExceptionManager(() => t.The1Test(), "Первый");
            ExceptionManager(() => t.The2Test(), "Второй");
            ExceptionManager(() => t.The3Test(), "Третий");
            ExceptionManager(() => t.The4Test(), "Четвёртый");
            ExceptionManager(() => t.The5Test(), "Пятый");
            ExceptionManager(() => t.The6Test(), "Шестой");
            ExceptionManager(() => t.The7Test(), "Седьмой");
            ExceptionManager(() => t.The8Test(), "Восьмой");
            ExceptionManager(() => t.The9Test(), "Девятый");
            ExceptionManager(() => t.The10Test(), "Десятый");
            try { t.TeardownTest(); } catch { }
            Console.ReadKey();
        }
    }
}