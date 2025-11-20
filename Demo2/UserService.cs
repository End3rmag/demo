using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Demo2.Context;
using Demo2.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo2.Services
{
    public class UserService
    {
        
        private Foruser002Context con;

        public UserService(Foruser002Context context)
        {
            con = context;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public (bool success, string message) Register(string email, string password, string confirmPassword, string firstName, string lastName)
        {
            try
            {
                if (password != confirmPassword)
                    return (false, "Пароли не совпадают");

                if (con.Users.Any(u => u.Email == email))
                    return (false, "Пользователь с таким email уже существует");

                var user = new User
                {
                    Email = email,
                    Password = HashPassword(password),
                    FirstName = firstName,
                    LastName = lastName,
                    RegistDate = DateTime.Now
                };

                con.Users.Add(user);
                con.SaveChanges();

                return (true, "Регистрация прошла успешно");
            }
            catch (Exception ex)
            {
                new Window2($"Ошибка регистрации: {ex.Message}").ShowDialog(this);
                return ;
            }
        }
        public (bool success, User user, string message) Login(string email, string password)
        {
            try
            {
                var hashedPassword = HashPassword(password);
                var user = con.Users.FirstOrDefault(u => u.Email == email && u.Password == hashedPassword);

                if (user == null)
                    return (false, null, "Неверный email или пароль");

                return (true, user, "Авторизация прошла успешно");
            }
            catch (Exception ex)
            {
                return (false, null, $"Ошибка авторизации: {ex.Message}");
            }
        }
    }
}
