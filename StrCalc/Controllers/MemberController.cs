using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StrCalc.DataContext;
using StrCalc.Models;
using StrCalc.ViewModels;
using System.Linq;
using StrCalcLibrary;

namespace StrCalc.Controllers
{
    public class MemberController : Controller
    {

        private readonly WilksPoint _wp;
        private readonly WilksRank _wr;

        public MemberController(WilksPoint wp, WilksRank wr)
        {
            _wp = wp;
            _wr = wr;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginMember model)
        {
            // ID, PW - 필수
            if (ModelState.IsValid)
            {
                using (var db = new StrCalcDbContext())
                {
                    // Linq - 메서드 체이닝
                    var user = db.Members.FirstOrDefault(u => u.Id.Equals(model.Id) && u.Pw.Equals(model.Pw));
                    if (user != null)
                    {
                        // 로그인 성공 - session attribute 생성
                        HttpContext.Session.SetInt32("LOGIN_USER", user.No);
                        return RedirectToAction("MemberDetails", "Member");  // 로그인 성공 페이지로 이동
                    }
                }
                // 로그인 실패
                ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");
            }
            return View(model);
        }

        public IActionResult Regist()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Regist(Member model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StrCalcDbContext())
                {
                    db.Members.Add(model);        // 메모리까지 올리기
                    db.SaveChanges();           // 실제 sql까지 = commit
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Logout()
        {
            // 세션 어트리뷰트 삭제
            HttpContext.Session.Remove("LOGIN_USER");

            // 모든 세션 어트리뷰트 삭제
            //HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult MemberDetails()
        {
            var no = HttpContext.Session.GetInt32("LOGIN_USER");

            using (var db = new StrCalcDbContext())
            {
                var user = db.Members.FirstOrDefault(u => u.No.Equals(no));
                return View(user);
            }
        }

        public IActionResult PerformanceDetails()
        {
            var no = HttpContext.Session.GetInt32("LOGIN_USER");

            using (var db = new StrCalcDbContext())
            {
                var user = db.MPfmc.FirstOrDefault(u=>u.No.Equals(no));
                return View(user);
            }
        }

        public IActionResult EditMember()
        {
            var no = HttpContext.Session.GetInt32("LOGIN_USER");

            using (var db = new StrCalcDbContext())
            {
                var user = db.Members.FirstOrDefault(u => u.No.Equals(no));
                return View(user);
            }
        }

        [HttpPost]
        public IActionResult EditMember(EditMember member)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StrCalcDbContext())
                {
                    var no = HttpContext.Session.GetInt32("LOGIN_USER");
                    var user = db.Members.FirstOrDefault(u => u.No.Equals(no));

                    user.Pw = member.Pw;
                    user.NickName = member.NickName;
                    user.Email = member.Email;
                    db.SaveChanges();

                    return RedirectToAction("MemberDetails", "Member");
                }
            }
            return View();
        }

        public IActionResult EditPerformance()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditPerformance(EditPerformance performance)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StrCalcDbContext())
                {
                    var no = HttpContext.Session.GetInt32("LOGIN_USER");
                    var _performance = db.MPfmc.FirstOrDefault(u => u.No.Equals(no));

                    _performance.BP = performance.BP;
                    _performance.DL = performance.DL;
                    _performance.SQT = performance.SQT;
                    _performance.Gender = performance.Gender;
                    _performance.Height = performance.Height;
                    _performance.Weight = performance.Weight;
                    var _big3Weight = (performance.BP + performance.DL + performance.SQT);
                    _performance.Big3Weight = _big3Weight.ToString();
                    var point = _wp.Coeff(performance.Weight, _big3Weight, performance.Gender);
                    _performance.WP = float.Parse(point + "");
                    var _weightclass = _wr.weightClass(performance.Weight);
                    _performance.WR = _wr.getRank(point, _weightclass);
                    db.SaveChanges();

                    return RedirectToAction("PerformanceDetails", "Member");
                }
            }
            return View();
        }

        public IActionResult Withdraw()
        {
            var no = HttpContext.Session.GetInt32("LOGIN_USER");
            using (var db = new StrCalcDbContext())
            {
                var user = db.Members.FirstOrDefault(u => u.No.Equals(no));
                db.Members.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Logout", "Member");
            }
        }
    }
}