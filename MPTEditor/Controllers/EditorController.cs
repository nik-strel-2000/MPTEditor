using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MPTEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPTEditor.Controllers
{
    public class EditorController : Controller
    {
        public ApplicationContext db;

        public EditorController(ApplicationContext content)
        {
            this.db = content;
        }
        public async Task<IActionResult> UpdeteTable()
        {
            int ID = Convert.ToInt32(Request.Query["ID"]);
            int value = Convert.ToInt32(Request.Query["Value"]);
            int idRecord = Convert.ToInt32(Request.Query["ID_Record"]);
            if (value == 1) { value = 2; } else { value = 1; };

            var repos = await (from m in db.Attendance
                         select new DobleAttendance
                         {
                             Id_Record = m.Id_Record,
                             Contract_id = m.Contract_id,
                             Month = m.Month,
                             Year = m.Year,
                             dates = new List<int>() {m.one , m.two ,m.three ,m.four ,m.five ,m.six ,m.seven ,m.eight
                                            ,m.nine ,m.ten ,m.eleven ,m.twelve ,m.thirteen ,m.fourteen ,m.fifteen ,m.sixteen
                                            ,m.seventeen ,m.eighteen ,m.nineteen ,m.twenty ,m.twentyOne ,m.twentyTwo ,m.twentyThree
                                            ,m.twentyFour ,m.twentyFive ,m.twentySix ,m.twentySeven ,m.twentyEight ,m.twentyNine ,m.thirty ,m.thirtyOne}
                         }).ToListAsync();
            var whereRepos = repos.Where(p => p.Id_Record == idRecord); 
            Attendance attendance = new Attendance {
                Id_Record = whereRepos.First().Id_Record,
                Contract_id = whereRepos.First().Contract_id,
                Month = whereRepos.First().Month,
                Year = whereRepos.First().Year,
                one= whereRepos.First().dates[0],
                two= whereRepos.First().dates[1],
                three= whereRepos.First().dates[2],
                four= whereRepos.First().dates[3],
                five= whereRepos.First().dates[4],
                six= whereRepos.First().dates[5],
                seven= whereRepos.First().dates[6],
                eight= whereRepos.First().dates[7],
                nine= whereRepos.First().dates[8],
                ten= whereRepos.First().dates[9],
                eleven= whereRepos.First().dates[10],
                twelve= whereRepos.First().dates[11],
                thirteen= whereRepos.First().dates[12],
                fourteen= whereRepos.First().dates[13],
                fifteen= whereRepos.First().dates[14],
                sixteen= whereRepos.First().dates[15],
                seventeen= whereRepos.First().dates[16],
                eighteen= whereRepos.First().dates[17],
                nineteen= whereRepos.First().dates[18],
                twenty= whereRepos.First().dates[19],
                twentyOne= whereRepos.First().dates[20],
                twentyTwo= whereRepos.First().dates[21],
                twentyThree= whereRepos.First().dates[22],
                twentyFour= whereRepos.First().dates[23],
                twentyFive= whereRepos.First().dates[24],
                twentySix= whereRepos.First().dates[25],
                twentySeven= whereRepos.First().dates[26],
                twentyEight = whereRepos.First().dates[27],
                twentyNine= whereRepos.First().dates[28],
                thirty= whereRepos.First().dates[29],
                thirtyOne= whereRepos.First().dates[30]

            };
            switch (ID) {

                case 1:
                    {
                        attendance.one = value;
                    }
                    break;
                case 2:
                    {
                        attendance.two = value;
                    }
                    break;
                case 3:
                    {
                        attendance.three = value;
                    }
                    break;
                case 4:
                    {
                        attendance.four = value;
                    }
                    break;
                case 5:
                    {
                        attendance.five = value;
                    }
                    break;
                case 6:
                    {
                        attendance.six = value;
                    }
                    break;
                case 7:
                    {
                        attendance.seven = value;
                    }
                    break;
                case 8:
                    {
                        attendance.eight = value;
                    }
                    break;
                case 9:
                    {
                        attendance.nine = value;
                    }
                    break;
                case 10:
                    {
                        attendance.ten = value;
                    }
                    break;
                case 11:
                    {
                        attendance.eleven = value;
                    }
                    break;
                case 12:
                    {
                        attendance.twelve = value;
                    }
                    break;
                case 13:
                    {
                        attendance.thirteen = value;
                    }
                    break;
                case 14:
                    {
                        attendance.fourteen = value;
                    }
                    break;
                case 15:
                    {
                        attendance.fifteen = value;
                    }
                    break;
                case 16:
                    {
                        attendance.sixteen = value;
                    }
                    break;
                case 17:
                    {
                        attendance.seventeen = value;
                    }
                    break;
                case 18:
                    {
                        attendance.eighteen = value;
                    }
                    break;
                case 19:
                    {
                        attendance.nineteen = value;
                    }
                    break;
                case 20:
                    {
                        attendance.twenty = value;
                    }
                    break;
                case 21:
                    {
                        attendance.twentyOne = value;
                    }
                    break;
                case 22:
                    {
                        attendance.twentyTwo = value;
                    }
                    break;
                case 23:
                    {
                        attendance.twentyThree = value;
                    }
                    break;
                case 24:
                    {
                        attendance.twentyFour = value;
                    }
                    break;
                case 25:
                    {
                        attendance.twentyFive = value;
                    }
                    break;
                case 26:
                    {
                        attendance.twentySix = value;
                    }
                    break;
                case 27:
                    {
                        attendance.twentySeven = value;
                    }
                    break;
                case 28:
                    {
                        attendance.twentyEight = value;
                    }
                    break;
                case 29:
                    {
                        attendance.twentyNine = value;
                    }
                    break;
                case 30:
                    {
                        attendance.thirty = value;
                    }
                    break;
                case 31:
                    {
                        attendance.thirtyOne = value;
                    }
                    break;
            }

            await db.SaveChangesAsync();

            db.Update(attendance);

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(EditTableAttendance));
        }
        
        public async Task<IActionResult> UpdeteTablePayment()
        {
            int ID = Convert.ToInt32(Request.Query["ID"]);
            int value = Convert.ToInt32(Request.Query["Value"]);
            int idRecord = Convert.ToInt32(Request.Query["ID_Record"]);
            if (value == 1) { value = 2; } else { value = 1; };

            var repos = await (from m in db.Payment_register
                               select new DoblePayment
                               {
                                   Id_Record = m.Id_Record,
                                   Contract_id = m.Contract_id,
                                   Month = m.Month,
                                   Year = m.Year,
                                   dates = new List<int>() {m.one , m.two ,m.three ,m.four ,m.five ,m.six ,m.seven ,m.eight
                                            ,m.nine ,m.ten ,m.eleven ,m.twelve ,m.thirteen ,m.fourteen ,m.fifteen ,m.sixteen
                                            ,m.seventeen ,m.eighteen ,m.nineteen ,m.twenty ,m.twentyOne ,m.twentyTwo ,m.twentyThree
                                            ,m.twentyFour ,m.twentyFive ,m.twentySix ,m.twentySeven ,m.twentyEight ,m.twentyNine ,m.thirty ,m.thirtyOne}
                               }).ToListAsync();

            var whereRepos = repos.Where(p => p.Id_Record == idRecord);
            PaymentRegister payment = new PaymentRegister
            {
                Id_Record = whereRepos.First().Id_Record,
                Contract_id = whereRepos.First().Contract_id,
                Month = whereRepos.First().Month,
                Year = whereRepos.First().Year,
                one = whereRepos.First().dates[0],
                two = whereRepos.First().dates[1],
                three = whereRepos.First().dates[2],
                four = whereRepos.First().dates[3],
                five = whereRepos.First().dates[4],
                six = whereRepos.First().dates[5],
                seven = whereRepos.First().dates[6],
                eight = whereRepos.First().dates[7],
                nine = whereRepos.First().dates[8],
                ten = whereRepos.First().dates[9],
                eleven = whereRepos.First().dates[10],
                twelve = whereRepos.First().dates[11],
                thirteen = whereRepos.First().dates[12],
                fourteen = whereRepos.First().dates[13],
                fifteen = whereRepos.First().dates[14],
                sixteen = whereRepos.First().dates[15],
                seventeen = whereRepos.First().dates[16],
                eighteen = whereRepos.First().dates[17],
                nineteen = whereRepos.First().dates[18],
                twenty = whereRepos.First().dates[19],
                twentyOne = whereRepos.First().dates[20],
                twentyTwo = whereRepos.First().dates[21],
                twentyThree = whereRepos.First().dates[22],
                twentyFour = whereRepos.First().dates[23],
                twentyFive = whereRepos.First().dates[24],
                twentySix = whereRepos.First().dates[25],
                twentySeven = whereRepos.First().dates[26],
                twentyEight = whereRepos.First().dates[27],
                twentyNine = whereRepos.First().dates[28],
                thirty = whereRepos.First().dates[29],
                thirtyOne = whereRepos.First().dates[30]
            };
            switch (ID)
            {

                case 1:
                    {
                        payment.one = value;
                    }
                    break;
                case 2:
                    {
                        payment.two = value;
                    }
                    break;
                case 3:
                    {
                        payment.three = value;
                    }
                    break;
                case 4:
                    {
                        payment.four = value;
                    }
                    break;
                case 5:
                    {
                        payment.five = value;
                    }
                    break;
                case 6:
                    {
                        payment.six = value;
                    }
                    break;
                case 7:
                    {
                        payment.seven = value;
                    }
                    break;
                case 8:
                    {
                        payment.eight = value;
                    }
                    break;
                case 9:
                    {
                        payment.nine = value;
                    }
                    break;
                case 10:
                    {
                        payment.ten = value;
                    }
                    break;
                case 11:
                    {
                        payment.eleven = value;
                    }
                    break;
                case 12:
                    {
                        payment.twelve = value;
                    }
                    break;
                case 13:
                    {
                        payment.thirteen = value;
                    }
                    break;
                case 14:
                    {
                        payment.fourteen = value;
                    }
                    break;
                case 15:
                    {
                        payment.fifteen = value;
                    }
                    break;
                case 16:
                    {
                        payment.sixteen = value;
                    }
                    break;
                case 17:
                    {
                        payment.seventeen = value;
                    }
                    break;
                case 18:
                    {
                        payment.eighteen = value;
                    }
                    break;
                case 19:
                    {
                        payment.nineteen = value;
                    }
                    break;
                case 20:
                    {
                        payment.twenty = value;
                    }
                    break;
                case 21:
                    {
                        payment.twentyOne = value;
                    }
                    break;
                case 22:
                    {
                        payment.twentyTwo = value;
                    }
                    break;
                case 23:
                    {
                        payment.twentyThree = value;
                    }
                    break;
                case 24:
                    {
                        payment.twentyFour = value;
                    }
                    break;
                case 25:
                    {
                        payment.twentyFive = value;
                    }
                    break;
                case 26:
                    {
                        payment.twentySix = value;
                    }
                    break;
                case 27:
                    {
                        payment.twentySeven = value;
                    }
                    break;
                case 28:
                    {
                        payment.twentyEight = value;
                    }
                    break;
                case 29:
                    {
                        payment.twentyNine = value;
                    }
                    break;
                case 30:
                    {
                        payment.thirty = value;
                    }
                    break;
                case 31:
                    {
                        payment.thirtyOne = value;
                    }
                    break;
            }

            await db.SaveChangesAsync();

            db.Update(payment);

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(EditTablePayment));
        }
        [Authorize(Roles = "Преподаватель")]
        public async Task<IActionResult> EditTableAttendance()
        {
            var tableAttendace = await (from m in db.Attendance
                                        join t in db.Contracts on m.Contract_id equals t.Id_Contract
                                        join s in db.Listeners on t.Listener_Id equals s.Id_Listener
                                        select new DobleAttendance
                                        {
                                            Id_Record = m.Id_Record,
                                            FIO = s.LastName + " " + s.FirstName + " " + s.MiddleName,
                                            Code_contract = t.Code_contract,
                                            Contract_id = m.Contract_id,
                                            Month = m.Month,
                                            Year = m.Year,
                                            dates = new List<int>() {m.one , m.two ,m.three ,m.four ,m.five ,m.six ,m.seven ,m.eight
                                            ,m.nine ,m.ten ,m.eleven ,m.twelve ,m.thirteen ,m.fourteen ,m.fifteen ,m.sixteen
                                            ,m.seventeen ,m.eighteen ,m.nineteen ,m.twenty ,m.twentyOne ,m.twentyTwo ,m.twentyThree
                                            ,m.twentyFour ,m.twentyFive ,m.twentySix ,m.twentySeven ,m.twentyEight ,m.twentyNine ,m.thirty ,m.thirtyOne}
                                        }).ToListAsync();

            return await Task.Run(() => View(tableAttendace));
        }
        [HttpGet]
        [Authorize(Roles = "Преподаватель")]
        public async Task<IActionResult> EditTablePayment()
        {
            var tableAttendace = await (from m in db.Payment_register
                                        join t in db.Contracts on m.Contract_id equals t.Id_Contract
                                        join s in db.Listeners on t.Listener_Id equals s.Id_Listener
                                        select new DoblePayment
                                        {
                                            Id_Record = m.Id_Record,
                                            FIO = s.LastName + " " + s.FirstName + " " + s.MiddleName,
                                            Code_contract = t.Code_contract,
                                            Contract_id = m.Contract_id,
                                            Month = m.Month,
                                            Year = m.Year,
                                            dates = new List<int>() {m.one , m.two ,m.three ,m.four ,m.five ,m.six ,m.seven ,m.eight
                                            ,m.nine ,m.ten ,m.eleven ,m.twelve ,m.thirteen ,m.fourteen ,m.fifteen ,m.sixteen
                                            ,m.seventeen ,m.eighteen ,m.nineteen ,m.twenty ,m.twentyOne ,m.twentyTwo ,m.twentyThree
                                            ,m.twentyFour ,m.twentyFive ,m.twentySix ,m.twentySeven ,m.twentyEight ,m.twentyNine ,m.thirty ,m.thirtyOne}
                                        }).ToListAsync();

            return await Task.Run(() => View(tableAttendace));
        } 
        [HttpGet]
        [Authorize(Roles = "Преподаватель")]
        public async Task<IActionResult> AddListeners()
        {
            return await Task.Run(() => View());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Преподаватель")]
        public async Task<IActionResult> AddListeners(Listeners listener)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var list = await db.Listeners.FirstOrDefaultAsync(u => u.Email == listener.Email);
                    if (list == null)
                    {
                        if (listener.NumberPhone < 1000000000)
                        {
                            ModelState.AddModelError("", "Не верный номер");
                            return await Task.Run(() => View());
                        }
                        Listeners repos;
                        if (listener.MiddleName != null)
                        {
                            repos = new Listeners
                            {
                                Email = listener.Email,
                                FirstName = listener.FirstName,
                                LastName = listener.LastName,
                                MiddleName = listener.MiddleName,
                                NumberPhone = listener.NumberPhone
                            };
                        }
                        else
                        {
                            repos = new Listeners
                            {
                                Email = listener.Email,
                                FirstName = listener.FirstName,
                                LastName = listener.LastName,
                                NumberPhone = listener.NumberPhone
                            };
                        }
                        db.Add(repos);
                        await db.SaveChangesAsync();
                        return RedirectToAction("AddListeners", "Editor");
                    }
                    ModelState.AddModelError("", "Пользователь с такой почтой зарегистрирован");
                    return await Task.Run(() => View());
                }
                return await Task.Run(() => View());

            }
            catch
            {
                ModelState.AddModelError("", "Некорректные данные");
                return await Task.Run(() => View());
            }



        }
        
        public async Task<IActionResult> ListListeners()
        {
            return View(await db.Listeners.ToListAsync());
        }
        [HttpGet]
        [Authorize(Roles = "Преподаватель")]
        public async Task<IActionResult> AddAttendance()
        {
            return await Task.Run(() => View());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Преподаватель")]
        public async Task<IActionResult> AddAttendance(Attendance attendance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var list = await db.Attendance.FirstOrDefaultAsync(u => u.Contract_id == attendance.Contract_id && u.Month == attendance.Month && u.Year == attendance.Year);
                    if (list == null)
                    {
                        if (attendance.Year > 2000)
                        {
                            Attendance repos = new Attendance
                            {
                                Contract_id = attendance.Contract_id,
                                Year = attendance.Year,
                                Month = attendance.Month
                            };
                            db.Add(repos);
                            await db.SaveChangesAsync();
                            return RedirectToAction("AddAttendance", "Editor");
                        }
                        ModelState.AddModelError("", "Год слишком мало");
                        return await Task.Run(() => View());
                    }
                    ModelState.AddModelError("", "Пользователь с таким контрактом уже учтен");
                    return await Task.Run(() => View());
                }
                ModelState.AddModelError("", "Заполните все поля");
                return await Task.Run(() => View());
            }
            catch
            {
                ModelState.AddModelError("", "Введены не корректные данные");
                return await Task.Run(() => View());
            }

        }


        public async Task<IActionResult> DeleteAttendance()
        {
            int ID = Convert.ToInt32(Request.Query["ID"]);

            Attendance attendance = new Attendance
            {
                Id_Record = ID
            };

            db.Remove(attendance);
            await db.SaveChangesAsync();

            return RedirectToAction("EditTableAttendance", "Editor");
        }

        [HttpGet]
        [Authorize(Roles = "Преподаватель")]
        public async Task<IActionResult> AddPayment()
        {
            return await Task.Run(() => View());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Преподаватель")]
        public async Task<IActionResult> AddPayment(PaymentRegister attendance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var list = await db.Payment_register.FirstOrDefaultAsync(u => u.Contract_id == attendance.Contract_id && u.Month == attendance.Month && u.Year == attendance.Year);
                    if (list == null)
                    {
                        if(attendance.Year > 2000)
                        {
                            PaymentRegister repos = new PaymentRegister
                            {
                                Contract_id = attendance.Contract_id,
                                Year = attendance.Year,
                                Month = attendance.Month
                            };
                            db.Add(repos);
                            await db.SaveChangesAsync();
                            return RedirectToAction("AddPayment", "Editor");
                        }
                        ModelState.AddModelError("", "Год слишком мало");
                        return await Task.Run(() => View());
                    }
                    ModelState.AddModelError("", "Пользователь с таким контрактом уже учтен");
                    return await Task.Run(() => View());
                }
                return await Task.Run(() => View());
            }
            catch
            {
                ModelState.AddModelError("", "Введены не корректные данные");
                return await Task.Run(() => View());
            }
        }
        public async Task<IActionResult> DeletePayment()
        {
            int ID = Convert.ToInt32(Request.Query["ID"]);

            PaymentRegister payment = new PaymentRegister
            {
                Id_Record = ID
            };

            db.Remove(payment);
            await db.SaveChangesAsync();

            return RedirectToAction("EditTablePayment", "Editor");
        }
    }
}
