using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.LIBRARY.RDBMModels;

namespace UserManagement.LIBRARY.RDBMProviders
{
    public class UserProvider : RDBMBaseProvider
    {
        String defaultPassWord = "Iloveopsr1998";
        public User[] getAllUser()
        {
            return base.db.Users.ToArray();
        }


        public String createUser(User user)
        {
            try
            {
                base.db.Users.Add(user);
                base.db.SaveChanges();
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public User getUserByEmail(String Email)
        {
            return base.db.Users.Where(u => u.Email == Email).FirstOrDefault();
        }


        public User getUserById(int ID)
        {
            try
            {
                return base.db.Users.Where(u => u.ID == ID).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool editUser(int ID, User user)
        {
            try
            {
                User edit = base.db.Users.Where(u => u.ID == ID).FirstOrDefault();

                edit.Email = (user.Email != null || user.Email != "") ? (user.Email) : (edit.Email);
                //if(user.Password == null || user.Password == "")
                //{
                //    edit.Password = edit.Password;
                //}
                //else
                //{
                //    edit.Password = new SecureCipher().Encrypt(user.Password);
                //}
                edit.Password = (user.Password == null || user.Password == "") ? (edit.Password) : (new SecureCipher().Encrypt(user.Password));
                edit.Firstname = user.Firstname;
                edit.Lastname = user.Lastname;
                edit.Phone = user.Phone;
                edit.Position = user.Position;
                edit.Birthday = user.Birthday;
                edit.Address = user.Address;
                edit.Image = user.Image;
                base.db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }


        public List<User> GetAllListUser()
        {
            return base.db.Users.ToList();
        }

        public String Count(int ID)
        {
            try
            {
                Roll_Call check = base.db.Roll_Call.Where(c => c.UserID == ID).FirstOrDefault();
                Monthly_Schedule set = base.db.Monthly_Schedule.Where(m => m.UserID == ID).FirstOrDefault();
                if (set != null)
                {
                    if (check == null)
                    {
                        check = new Roll_Call();
                        check.Count = true;
                        check.UserID = ID;
                        check.Created = DateTime.Today;
                        base.db.Roll_Call.Add(check);
                        base.db.SaveChanges();
                    }
                    else
                    {
                        check.Count = true;
                        check.Created = DateTime.Today;
                        base.db.SaveChanges();
                    }
                    set.TotalCount = (set.TotalCount != null) ? (set.TotalCount + 1) : (1);
                    base.db.SaveChanges();
                    return "true";
                }
                else
                {
                    return "MonthlyScheduleNotSet";
                }

            }
            catch (Exception)
            {
                return "false";
            }

        }

        public Monthly_Schedule getDataMonth(int ID)
        {
            return base.db.Monthly_Schedule.Where(u => u.UserID == ID).FirstOrDefault();
        }

        public bool saveMonthlySchedule(int ID, DateTime startday, DateTime endday)
        {
            Monthly_Schedule select = base.db.Monthly_Schedule.Where(u => u.UserID == ID).FirstOrDefault();
            if (select == null)
            {
                select = new Monthly_Schedule();
                select.BeginDay = startday;
                select.EndDay = endday;
                select.UserID = ID;
                base.db.Monthly_Schedule.Add(select);
                base.db.SaveChanges();
            }
            else
            {
                select.BeginDay = startday;
                select.EndDay = endday;
                base.db.SaveChanges();
            }

            return true;
        }

        public bool isMonthlyScheduleSet(int ID)
        {
            try
            {
                Monthly_Schedule select = base.db.Monthly_Schedule.Where(u => u.UserID == ID).FirstOrDefault();
                if (select != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public Salary getSalaryOfUserByID(int ID)
        {
            try
            {
                Monthly_Schedule select = base.db.Monthly_Schedule.Where(u => u.UserID == ID).FirstOrDefault();
                PaymentPerDay paymentOfDay = base.db.PaymentPerDays.Where(u => u.UserID == ID).FirstOrDefault();
                Double salary = 0;
                if(select != null)
                {
                    if(paymentOfDay == null)
                    {
                        paymentOfDay = base.db.PaymentPerDays.Where(u => u.UserID == null).FirstOrDefault();
                    }
                    salary = Convert.ToInt32(select.TotalCount) * Convert.ToDouble(paymentOfDay.Money);
                    Salary UserSalary = base.db.Salaries.Where(u => u.UserID == ID).FirstOrDefault();
                    if(UserSalary != null)
                    {
                        UserSalary.Payment = Convert.ToDecimal(salary);
                        base.db.SaveChanges();
                        return UserSalary;
                    }
                    else
                    {
                        UserSalary = new Salary();
                        UserSalary.MonthID = select.ID;
                        UserSalary.UserID = ID;
                        UserSalary.Payment = Convert.ToDecimal(salary);
                        UserSalary.PayMentOfUserID = paymentOfDay.ID;
                        base.db.Salaries.Add(UserSalary);
                        base.db.SaveChanges();
                        return UserSalary;
                    }
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
