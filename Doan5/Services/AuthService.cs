using Doan5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doan5.Services
{
    public interface IAuthService
    {
        Taikhoan Authenticate(string username, string password);
        Taikhoan Create(Taikhoan user, string password);
    }

    public class AuthService: IAuthService
    {
        private readonly Doan5Context _context;

        public AuthService(Doan5Context context)
        {
            _context = context;
        }

        public Taikhoan Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Taikhoan.FirstOrDefault(x => x.TenTk == username && x.Matkhau == password);

            // check if username exists
            if (user == null)
                return null;

            // authentication successful
            return user;
        }

        public Taikhoan Create(Taikhoan user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Vui lòng nhập mật khẩu");

            if (_context.Taikhoan.Any(x => x.TenTk == user.TenTk))
                throw new Exception("Tài khoản \"" + user.TenTk + "\" đã được đăng ký bởi tài khoản khác");

            user.Matkhau = password;

            _context.Taikhoan.Add(user);
            _context.SaveChanges();

            return user;
        }
    }
}
