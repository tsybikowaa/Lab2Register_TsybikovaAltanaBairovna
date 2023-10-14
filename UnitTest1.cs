using System;
using Microsoft.Win32;
using NUnit.Framework;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Collections.Generic;
using System.IO;

namespace TestLab2
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CheckRegister_PasswordMissingSpecialSymbol_ReturnsFalseAndErrorMessage()
        {
            // Arrange
            string login = "validlogin";
            string password = "Password123";
            string password2 = "Password123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual(("False", "В пароле отсутствует минимум один специальный символ"), result);
        }

        [Test]
        public void CheckRegister_EmptyLogin_ReturnsFalseWithErrorMessage()
        {
            // Arrange
            string login = "";
            string password = "Password123";
            string password2 = "Password123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
     
            Assert.AreEqual(("False","Пустая строка в качестве логина"), result);
        }

        [Test]
        public void CheckRegister_ShortLogin_ReturnsFalseWithErrorMessage()
        {
            // Arrange
            string login = "user";
            string password = "Password123";
            string password2 = "Password123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
     
            Assert.AreEqual(("False","Длина логина меньше 5 символов"), result);
        }


        [Test]
        public void CheckRegister_ExistingUser_ReturnsFalseWithErrorMessage()
        {
            //// Arrange
            string login = "user11";
            string password = "Password123";
            string password2 = "Password123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
   
            Assert.AreEqual(("False","Пользователь с таким логином уже зарегистрирован"), result);
        }

        [Test]
        public void CheckRegister_ExistingUser_ReturnsFalseWithErrorMessage22()
        {
            //// Arrange
            string login = "user22";
            string password = "Password123";
            string password2 = "Password123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert

            Assert.AreEqual(("False", "Пользователь с таким логином уже зарегистрирован"), result);
        }

        [Test]
        public void CheckRegister_ExistingUser_ReturnsFalseWithErrorMessage33()
        {
            //// Arrange
            string login = "user33";
            string password = "Password123";
            string password2 = "Password123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert

            Assert.AreEqual(("False", "Пользователь с таким логином уже зарегистрирован"), result);
        }

        [Test]
        public void CheckRegister_InvalidLoginSymbols_ReturnsFalseWithErrorMessage()
        {
            // Arrange
            string login = "user@123";
            string password = "Password123";
            string password2 = "Password123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert

            Assert.AreEqual(("False","Логин содержит символы, отличные от латиницы, цифр и знака подчеркивания"), result);
        }

        [Test]
        public void CheckRegister_InvalidPhone_ReturnsFalseWithErrorMessage()
        {
            // Arrange
            string login = "+123-456-7890";
            string password = "Password123";
            string password2 = "Password123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
 
            Assert.AreEqual(("False","Номер телефона не удовлетворяет заданному формату +x-xxx-xxx-xxxx"), result);
        }

        [Test]
        public void CheckRegister_InvalidEmail_ReturnsFalseWithErrorMessage()
        {
            // Arrange
            string login = "user@example";
            string password = "Password123";
            string password2 = "Password123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
       
            Assert.AreEqual(("False","Email не удовлетворяет общему формату xxx@xxx.xxx"), result);
        }

        [Test]
        public void CheckRegister_EmptyPassword_ReturnsFalseWithErrorMessage()
        {
            // Arrange
            string login = "user1";
            string password = "";
            string password2 = "";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert

            Assert.AreEqual(("False","Пустая строка в качестве пароля"), result);
        }

        [Test]
        public void CheckRegister_ShortPassword_ReturnsFalseAndErrorMessage()
        {
            // Arrange
            string login = "validlogin";
            string password = "short";
            string password2 = "short";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual(("False", "Длина пароля меньше 7 символов"), result);
        }


        [Test]
        public void CheckRegister_PasswordMismatch_ReturnsFalseWithErrorMessage()
        {
            // Arrange
            string login = "user1";
            string password = "Password123";
            string password2 = "Password456";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert

            Assert.AreEqual(("False","Заданные пароли совпадают"), result);
        }

        [Test]
        public void CheckRegister_InvalidPasswordSymbols_ReturnsFalseWithErrorMessage()
        {
            // Arrange
            string login = "user1";
            string password = "Password@123";
            string password2 = "Password@123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert

            Assert.AreEqual(("False","В пароле присутствуют недопустимые символы"), result);
        }

        [Test]
        public void CheckRegister_PasswordMissingUppercase_ReturnsFalseWithErrorMessage()
        {
            // Arrange
            string login = "user1";
            string password = "password123";
            string password2 = "password123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
     
            Assert.AreEqual(("False","В пароле отсутствует минимум одна заглавная буква"), result);
        }

        [Test]
        public void CheckRegister_PasswordMissingLowercase_ReturnsFalseWithErrorMessage()
        {
            // Arrange
            string login = "user1";
            string password = "PASSWORD123";
            string password2 = "PASSWORD123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
     
            Assert.AreEqual(("False","В пароле отсутствует минимум одна строчная буква"), result);
        }

        [Test]
        public void CheckRegister_PasswordMissingDigit_ReturnsFalseWithErrorMessage()
        {
            // Arrange
            string login = "user1";
            string password = "Password";
            string password2 = "Password";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
           
            Assert.AreEqual(("False","В пароле отсутствует минимум одна цифра"), result);
        }

        [Test]
        public void CheckRegister_PasswordMissingSpecialSymbol_ReturnsFalseWithErrorMessage()
        {
            // Arrange
            string login = "user1";
            string password = "Password123";
            string password2 = "Password123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            
            Assert.AreEqual(("False","В пароле отсутствует минимум один специальный символ"), result);
        }
        [Test]
        public void CheckRegister_InvalidLoginFormat_ReturnsFalseAndErrorMessage()
        {
            // Arrange
            string login = "invalid login";
            string password = "ValidPassword123";
            string password2 = "ValidPassword123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual(("False", "Логин содержит символы, отличные от латиницы, цифр и знака подчеркивания"), result);
        }

        [Test]
        public void CheckRegister_PasswordsNotEqual_ReturnsFalseAndErrorMessage()
        {
            // Arrange
            string login = "validlogin";
            string password = "ValidPassword123";
            string password2 = "DifferentPassword123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual(("False", "Заданные пароли не совпадают"), result);
        }
        [Test]
        public void CheckRegister_ValidData_ReturnsTrueAndEmptyErrorMessage()
        {
            // Arrange
            string login = "validlogin";
            string password = "ValidPassword123!";
            string password2 = "ValidPassword123!";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual(("True", "Регистрация прошла успешно"), result);
        }

        [Test]
        public void CheckRegister_InvalidPasswordFormat_ReturnsFalseAndErrorMessage()
        {
            // Arrange
            string login = "validlogin";
            string password = "Invalid Password";
            string password2 = "Invalid Password";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual(("False", "В пароле присутствуют недопустимые символы"), result);
        }

    }


    //[Test]
    //public void CheckRegister_EmptyLogin_ReturnsFalseAndErrorMessage()
    //{
    //    // Arrange
    //    string login = "";
    //    string password = "ValidPassword123";
    //    string password2 = "ValidPassword123";

    //    // Act
    //    var result = Register.CheckRegister(login, password, password2);

    //    // Assert
    //    Assert.AreEqual(("False", "Пустая строка в качестве логина"), result);
    //}

    //[Test]
    //public void CheckRegister_ShortLogin_ReturnsFalseAndErrorMessage()
    //{
    //    // Arrange
    //    string login = "short";
    //    string password = "ValidPassword123";
    //    string password2 = "ValidPassword123";

    //    // Act
    //    var result = Register.CheckRegister(login, password, password2);

    //    // Assert
    //    Assert.AreEqual(("False", "Длина логина меньше 5 символов"), result);
    //}

    //[Test]
    //public void CheckRegister_ExistingUser_ReturnsFalseAndErrorMessage()
    //{
    //    // Arrange
    //    string login = "user11";
    //    string password = "ValidPassword123";
    //    string password2 = "ValidPassword123";

    //    // Act
    //    var result = Register.CheckRegister(login, password, password2);

    //    // Assert
    //    Assert.AreEqual(("False", "Пользователь с таким логином уже зарегистрирован"), result);
    //}

    //[Test]
    //public void CheckRegister_InvalidLoginFormat_ReturnsFalseAndErrorMessage()
    //{
    //    // Arrange
    //    string login = "invalid login";
    //    string password = "ValidPassword123";
    //    string password2 = "ValidPassword123";

    //    // Act
    //    var result = Register.CheckRegister(login, password, password2);

    //    // Assert
    //    Assert.AreEqual(("False", "Логин содержит символы, отличные от латиницы, цифр и знака подчеркивания"), result);
    //}

    //[Test]
    //public void CheckRegister_EmptyPassword_ReturnsFalseAndErrorMessage()
    //{
    //    // Arrange
    //    string login = "validlogin";
    //    string password = "";
    //    string password2 = "";

    //    // Act
    //    var result = Register.CheckRegister(login, password, password2);

    //    // Assert
    //    Assert.AreEqual(("False", "Пустая строка в качестве пароля"), result);
    //}

    //[Test]
    //public void CheckRegister_ShortPassword_ReturnsFalseAndErrorMessage()
    //{
    //    // Arrange
    //    string login = "validlogin";
    //    string password = "short";
    //    string password2 = "short";

    //    // Act
    //    var result = Register.CheckRegister(login, password, password2);

    //    // Assert
    //    Assert.AreEqual(("False", "Длина пароля меньше 7 символов"), result);
    //}

    //[Test]
    //public void CheckRegister_PasswordsNotEqual_ReturnsFalseAndErrorMessage()
    //{
    //    // Arrange
    //    string login = "validlogin";
    //    string password = "ValidPassword123";
    //    string password2 = "DifferentPassword123";

    //    // Act
    //    var result = Register.CheckRegister(login, password, password2);

    //    // Assert
    //    Assert.AreEqual(("False", "Заданные пароли не совпадают"), result);
    //}

    //[Test]
    //public void CheckRegister_InvalidPasswordFormat_ReturnsFalseAndErrorMessage()
    //{
    //    // Arrange
    //    string login = "validlogin";
    //    string password = "Invalid Password";
    //    string password2 = "Invalid Password";

    //    // Act
    //    var result = Register.CheckRegister(login, password, password2);

    //    // Assert
    //    Assert.AreEqual(("False", "В пароле присутствуют недопустимые символы"), result);
    //}

    //[Test]
    //public void CheckRegister_PasswordMissingUppercase_ReturnsFalseAndErrorMessage()
    //{
    //    // Arrange
    //    string login = "validlogin";
    //    string password = "password123";
    //    string password2 = "password123";

    //    // Act
    //    var result = Register.CheckRegister(login, password, password2);

    //    // Assert
    //    Assert.AreEqual(("False", "В пароле отсутствует минимум одна заглавная буква"), result);
    //}

    //[Test]
    //public void CheckRegister_PasswordMissingLowercase_ReturnsFalseAndErrorMessage()
    //{
    //    // Arrange
    //    string login = "validlogin";
    //    string password = "PASSWORD123";
    //    string password2 = "PASSWORD123";

    //    // Act
    //    var result = Register.CheckRegister(login, password, password2);

    //    // Assert
    //    Assert.AreEqual(("False", "В пароле отсутствует минимум одна строчная буква"), result);
    //}

    //[Test]
    //public void CheckRegister_PasswordMissingDigit_ReturnsFalseAndErrorMessage()
    //{
    //    // Arrange
    //    string login = "validlogin";
    //    string password = "Password";
    //    string password2 = "Password";

    //    // Act
    //    var result = Register.CheckRegister(login, password, password2);

    //    // Assert
    //    Assert.AreEqual(("False", "В пароле отсутствует минимум одна цифра"), result);
    //}

    //[Test]
    //public void CheckRegister_PasswordMissingSpecialSymbol_ReturnsFalseAndErrorMessage()
    //{
    //    // Arrange
    //    string login = "validlogin";
    //    string password = "Password123";
    //    string password2 = "Password123";

    //    // Act
    //    var result = Register.CheckRegister(login, password, password2);

    //    // Assert
    //    Assert.AreEqual(("False", "В пароле отсутствует минимум один специальный символ"), result);
    //}

    //[Test]
    //public void CheckRegister_ValidData_ReturnsTrueAndEmptyErrorMessage()
    //{
    //    // Arrange
    //    string login = "validlogin";
    //    string password = "ValidPassword123!";
    //    string password2 = "ValidPassword123!";

    //    // Act
    //    var result = Register.CheckRegister(login, password, password2);

    //    // Assert
    //    Assert.AreEqual(("True", "Регистрация прошла успешно"), result);
    //}

}
