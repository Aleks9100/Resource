using ResourceTable.Table;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using ResourceDatabase.Table;
using System.Data.Entity.Validation;
using ClosedXML.Excel;

namespace ResourceDatabase
{
    public class ResourceModel : DbContext
    {
        // Контекст настроен для использования строки подключения "ResourceDatabase" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "ResourceDatabase.ResourceDatabase" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "ResourceDatabase" 
        // в файле конфигурации приложения.
        public ResourceModel()
            : base("name=ResourceDatabase")
        {
            if (Operators.Count() == 0) 
            {
                AddOperator("admin", "admin", 0, "admin");
                AddDepartmentOrOrganization("Отдел Директора", "Department");
                AddDepartmentOrOrganization("ОРЛЗ", "Organization");
                AddPosition("Директор");
                AddWorking_Group("Группа директора");
                AddPeople("Алексей", "Петров", "Петрович", "89123456781", "241", 1, 1, 1);
                AddResource("Cisco", DateTime.Now, DateTime.Now.AddMonths(5), 1);
                AddComputer("12445121", "172.168.14.12", "Компьютер директора", "Director", "domen", 1, 1);
                
                Accounts.Add(new Account()
                {
                    LastNamePeople = "Петров",
                    Login = "PetrovAP",
                    Type_Account="Cisco"
                });
                Accounts.Add(new Account()
                {
                    LastNamePeople = "Иванов",
                    Login = "IvnovAP",
                    Type_Account = "Cisco"
                });
                var pass = new Password()
                {
                    Passwords = Encryption.Encrypt("Petrov", Admins.FirstOrDefault(i => i.Title == "admin0").Key, Admins.FirstOrDefault(i => i.Title == "admin0").Sol),
                    Flag = Admins.FirstOrDefault(i => i.Title == "admin0").Flag,
                    AccountID = 1
                };
                var pass1 = new Password()
                {
                    Passwords = Encryption.Encrypt("Ivanov", Admins.FirstOrDefault(i => i.Title == "admin0").Key, Admins.FirstOrDefault(i => i.Title == "admin0").Sol),
                    Flag = Admins.FirstOrDefault(i => i.Title == "admin0").Flag,
                    AccountID = 2
                };
                Passwords.Add(pass);
                Passwords.Add(pass1);
                SaveChanges();
            }
        }

        #region Tables
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Computer> Computers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Operator> Operators { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<People> Peoples { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Working_Group> Working_Groups { get; set; }
        #endregion
        #region AddTable 
        public string AddComputer(string indificator, string iP, string description, string name, string domen, int working_GroupID, int peopleID)
        {
            try
            {
                Computer computer = new Computer()
                {
                    Indificator = indificator,
                    IP = iP,
                    Description = description,
                    Domen = domen,
                    Name = name,
                    Working_GroupID = working_GroupID,
                    PeopleID = peopleID
                };
                Computers.Add(computer);
                Working_Groups.FirstOrDefault(i=>i.Working_GroupID == working_GroupID).Computers.Add(computer);
                SaveChanges();
                return "Запись успешно добавлена";
            }
            catch (Exception ex) { return ex.Message; }

        }
        public string AddDepartmentOrOrganization(string title, string nameTable)
        {
            try
            {
                if (nameTable == "Department")
                {
                    Departments.Add(new Department()
                    {
                        Title = title
                    });
                }
                else if (nameTable == "Organization")
                {
                    Organizations.Add(new Organization()
                    {
                        Title = title
                    });
                   
                }
                SaveChanges();
                return "Запись успешно добавлена";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string AddOperator(string login, string password, int peopleID,string status)
        {
            //try
            //{
                bool rep = false;
                var operators = Operators.ToList();
                foreach(var o in operators) 
                {
                    if (o.Login == login)
                        rep = true;
                }
                if (!rep)
                {
                    int count = 0;
                    string passwordE = Encryption.DefaultKey();
                    string solE = Encryption.DefaultSol();
                    if (status == "admin")
                    {
                        foreach (var st in Operators.Where(i => i.UserStatus.Contains("admin")).ToList()) { count++; }
                        status = "admin" + count;
                        AddAdmin(status);
                        //if (Admins.Count() != 1)
                        //{
                        //    var p = Passwords.ToList();
                        //    var a = Admins.ToList();
                        //    Password password1 = new Password { Flag = admin.Flag, Passwords = Encryption.Encrypt(Encryption.Decrypt(p[0].Passwords, a[0].Key), admin.Key) };
                        //    Passwords.Add(password1);
                        //    SaveChanges();
                        //}
                    }
                    if (peopleID == 0)
                    {
                        Operators.Add(new Operator()
                        {
                            Login = login,
                            Password = Encryption.Encrypt(password, passwordE, solE),
                            UserStatus = status
                        });
                    }
                    else
                    {
                        Operators.Add(new Operator()
                        {
                            Login = login,
                            Password = Encryption.Encrypt(password, passwordE, solE),
                            PeopleID = peopleID,
                            UserStatus = status
                        });
                    }
                    SaveChanges();

                    return "Запись успешно добавлена";
                }
                else
                    return "Пользователь с таким логином уже существует";
            //}
            //catch (Exception ex) { return ex.Message; }
        }
        public void AddAdmin(string status) 
        {
            string key = Encryption.GetUniqueKey(8);
            string flag = Encryption.GetUniqueKey(16);
            string sol = Encryption.GetUniqueKey(12);
            Admins.Add(new Admin() 
            {
                Title = status,
                Key = key,
                Sol=sol,
                Flag = flag
            });
            SaveChanges();
            if (Accounts.Count() != 0 && Admins.Count() != 1) 
            {
                var account = Accounts.ToList();
                var admin = Admins.ToList(); 
                for (int i = 0; i < account.Count(); i++)
                {
                    var flags = admin[0].Flag;
                    var logins = account[i].Login;
                    var pass = Passwords.FirstOrDefault(c=>c.Flag == flags && c.AccountID == Accounts.FirstOrDefault(a => a.Login == logins).AccountID).Passwords;
                    var keyA = admin[0].Key;
                    var solA = admin[0].Sol;
                    Password password = new Password()
                    {
                        PasswordID = account.Count() + 1,
                        AccountID = account[i].AccountID,
                        Flag = flag,
                        Passwords = Encryption.Encrypt(Encryption.Decrypt(pass, keyA,solA), key,sol)
                    };
                    account[i].Passwords.Add(password) ;
                    Passwords.Add(password);
                    SaveChanges();
                }
            }
                    
        }
        public string AddPeople(string firstName, string lastName, string middleName, string phone, string phoneVoIP, int idDep,int IdOrg,int IdPos)
        {
            try
            {
                People people = new People()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    Phone = phone,
                    PhoneVoIP = phoneVoIP,
                    PositionID =IdPos,
                    OrganizationID =IdOrg,
                    DepartmentID = idDep,                  
                };
                Peoples.Add(people);
                Departments.FirstOrDefault(i => i.DepartmentID == idDep).People.Add(people);
                Organizations.FirstOrDefault(i => i.OrganizationID == IdOrg).People.Add(people);
                Positions.FirstOrDefault(i => i.PositionID == IdPos).People.Add(people);
                SaveChanges();
                return "Запись успешно добавлена";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string AddPosition(string title)
        {
            try
            {
                Positions.Add(new Position()
                {
                    Title = title
                });
                SaveChanges();
                return "Запись успешно добавлена";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string AddResource(string title, DateTime date_Start, DateTime date_End, int peopleID)
        {
            try
            {
                Resource resource = new Resource()
                {
                    Title = title,
                    Date_Start = date_Start,
                    Date_End = date_End,
                    PeopleID = peopleID
                };
                Resources.Add(resource);
                Peoples.FirstOrDefault(i => i.PeopleID == peopleID).Resources.Add(resource);
                SaveChanges();
                return "Запись успешно добавлена";
            }
            catch (Exception ex) { return ex.Message; }
        }
       
        public string AddWorking_Group(string title) 
        {
            try 
            {
                Working_Groups.Add(new Working_Group()
                {
                    Title=title
                });
                SaveChanges();
                return "Запись успешно добавлена";
            }
            catch (Exception ex) { return ex.Message; }
        }
        #endregion
        #region EditTable        
        public string EditComputer(int id,string indificator, string iP, string description, string name, string domen, int working_GroupID, int peopleID)
        {
            try
            {
                var item = Computers.FirstOrDefault(i=>i.ComputerID == id);
                Working_Groups.FirstOrDefault(i => i.Working_GroupID == item.Working_GroupID).Computers.Remove(item);
                item.Indificator = indificator;
                item.IP = iP;
                item.Description = description;
                item.Domen = domen;
                item.Name = name;
                item.Working_GroupID = working_GroupID;
                item.PeopleID = peopleID;
                Working_Groups.FirstOrDefault(i => i.Working_GroupID == working_GroupID).Computers.Add(item);
                SaveChanges();
                   return "Запись успешно изменена";
            }
            catch (Exception ex) { return ex.Message; }

        }
        public string EditDepartmentOrOrganization(int id,string title, string nameTable)
        {
            try
            {
                if (nameTable == "Department")
                {
                    var item = Departments.FirstOrDefault(i => i.DepartmentID == id);
                    item.Title = title;
                }
                else if (nameTable == "Organization")
                {
                    var item = Organizations.FirstOrDefault(i => i.OrganizationID == id);
                    item.Title = title;
                }
                SaveChanges();
                   return "Запись успешно изменена";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string EditOperator(int id,string login, string password, int peopleID)
        {
            try
            {
                var item = Operators.FirstOrDefault(i=>i.OperatorID == id);
                item.Login = login;
                item.Password = password;
                item.PeopleID = peopleID;
                SaveChanges();
                   return "Запись успешно изменена";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string EditPeople(int id,string firstName, string lastName, string middleName, string phone, string phoneVoIP, int idDep, int IdOrg, int IdPos)
        {
            try
            {
                var item = Peoples.FirstOrDefault(i => i.PeopleID == id);
                Departments.FirstOrDefault(i => i.DepartmentID == item.DepartmentID).People.Remove(item);
                Organizations.FirstOrDefault(i => i.OrganizationID == item.OrganizationID).People.Remove(item);
                Positions.FirstOrDefault(i => i.PositionID == item.PositionID).People.Remove(item);
                item.FirstName = firstName;
                item.LastName = lastName;
                item.MiddleName = middleName;
                item.Phone = phone;
                item.PhoneVoIP = phoneVoIP;
                item.PositionID = IdPos;
                item.OrganizationID = IdOrg;
                item.DepartmentID = idDep;
                Departments.FirstOrDefault(i => i.DepartmentID == idDep).People.Add(item);
                Organizations.FirstOrDefault(i => i.OrganizationID == IdOrg).People.Add(item);
                Positions.FirstOrDefault(i => i.PositionID == IdPos).People.Add(item);
                SaveChanges();
                return "Запись успешно изменена";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string EditPosition(int id,string title)
        {
            try
            {
                var item = Positions.FirstOrDefault(i => i.PositionID == id);
                item.Title = title;
                SaveChanges();
                   return "Запись успешно изменена";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string EditResource(int id,string title, DateTime date_Start, DateTime date_End, int peopleID)
        {
            try
            {
                var item = Resources.FirstOrDefault(i=>i.ResourceID == id);
                Peoples.FirstOrDefault(i => i.PeopleID == item.PeopleID).Resources.Remove(item);
                item.Title = title;
                item.Date_Start = date_Start;
                item.Date_End = date_End;
                item.PeopleID = peopleID;
                Peoples.FirstOrDefault(i => i.PeopleID == peopleID).Resources.Add(item);
                SaveChanges();
                   return "Запись успешно изменена";
            }
            catch (Exception ex) { return ex.Message; }
        }
   
        public string EditWorking_Group(int id,string title)
        {
            try
            {
                var item = Working_Groups.FirstOrDefault(i => i.Working_GroupID == id);
                item.Title = title;
                SaveChanges();
                   return "Запись успешно изменена";
            }
            catch (Exception ex) { return ex.Message; }
        }
        #endregion
        #region RemoveTable
        public string RemoveComputer(int id)
        {
            try
            {
                var item = Computers.FirstOrDefault(i => i.ComputerID == id);
                Working_Groups.FirstOrDefault(i => i.Working_GroupID == item.Working_GroupID).Computers.Remove(item);
                Computers.Remove(item);
                SaveChanges();
                return "Запись успешно удалена";
            }
            catch (Exception ex) { return ex.Message; }

        }
        public string RemoveDepartmentOrOrganization(int id, string nameTable)
        {
            try
            {
                if (nameTable == "Department")
                {
                    var item = Departments.FirstOrDefault(i => i.DepartmentID == id);
                    Departments.Remove(item);
                }
                else if (nameTable == "Organization")
                {
                    var item = Organizations.FirstOrDefault(i => i.OrganizationID == id);
                    Organizations.Remove(item);
                }
                SaveChanges();
                return "Запись успешно удалена";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string RemoveOperator(int id)
        {
            try
            {
                int count = 0;
                foreach (var Id in Operators.ToList())
                {
                    if (Id.UserStatus.Contains("admin"))
                        count++;
                }
                var item = Operators.FirstOrDefault(x => x.OperatorID == id);
                if (item.OperatorID == id)
                    return "Нельзя удалить самого себя";
                if (item.UserStatus.Contains("admin") && count == 1)
                    return "Нельзя удалить последнего админа";
                if (item.UserStatus.Contains("admin")) 
                {
                    var admin = Admins.FirstOrDefault(i => i.Title == item.UserStatus);
                    Admins.Remove(admin);
                    Passwords.Remove(Passwords.FirstOrDefault(i => i.Flag == admin.Flag));
                    SaveChanges();
                }
                Operators.Remove(item);
                SaveChanges();
                return "Запись успешно удалена";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string RemovePeople(int id)
        {
            try
            {
                var item = Peoples.FirstOrDefault(i => i.PeopleID == id);
                Departments.FirstOrDefault(i => i.DepartmentID == item.DepartmentID).People.Remove(item);
                Organizations.FirstOrDefault(i => i.OrganizationID == item.OrganizationID).People.Remove(item);
                Positions.FirstOrDefault(i => i.PositionID == item.PositionID).People.Remove(item);
                Peoples.Remove(item);
                SaveChanges();
                return "Запись успешно удалена";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string RemovePosition(int id)
        {
            try
            {
                var item = Positions.FirstOrDefault(i => i.PositionID == id);
                Positions.Remove(item);
                SaveChanges();
                return "Запись успешно удалена";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string RemoveResource(int id)
        {
            try
            {
                var item = Resources.FirstOrDefault(i => i.ResourceID == id);
                Peoples.FirstOrDefault(i => i.PeopleID == item.PeopleID).Resources.Remove(item);
                Resources.Remove(item);
                SaveChanges();
                return "Запись успешно удалена";
            }
            catch (Exception ex) { return ex.Message; }
        }
     
        public string RemoveWorking_Group(int id)
        {
            try
            {
                var item = Working_Groups.FirstOrDefault(i => i.Working_GroupID == id);
                Working_Groups.Remove(item);
                SaveChanges();
                return "Запись успешно удалена";
            }
            catch (Exception ex) { return ex.Message; }
        }
        #endregion
        #region GetTable
        public List<Account> GetAccount() => Accounts.ToList();
        public List<Account> GetAccountInId(int id) => Accounts.Where(i=>i.AccountID == id).ToList();
        public List<Resource> GetResource() => Resources.ToList();
        public List<Computer> GetComputer() => Computers.ToList();
        public List<Department> GetDepartment() => Departments.ToList();
        public string GetKey(string status) => Admins.FirstOrDefault(i=>i.Title == status).Key;
        public List<Operator> GetOperator() => Operators.ToList();
        public List<Organization> GetOrganization() => Organizations.ToList();
        public List<People> GetPeople() => Peoples.ToList();
        public List<Position> GetPosition() => Positions.ToList();    
        public List<Working_Group> GetWorking_Group() => Working_Groups.ToList();
        int count = 0;
        public string GetPassword(int id)
        {
            count++;
            var flag = Admins.FirstOrDefault(a => a.Title == Operators.FirstOrDefault(c => c.OperatorID == id).UserStatus).Flag;
            var key = Admins.FirstOrDefault(a => a.Title == Operators.FirstOrDefault(c => c.OperatorID == id).UserStatus).Key;
            string pass = "";
            int countPas = 1;
            foreach(var p in Passwords.Where(i => i.Flag == flag).ToList())
            {
                if (countPas > count)
                    break;
                pass = p.Passwords;
                countPas++;
            }
            return pass;
        } 
        public string GetPasswordD(int id,string login)
        {
            var flag = Admins.FirstOrDefault(a => a.Title == Operators.FirstOrDefault(c => c.OperatorID == id).UserStatus).Flag;
            var key = Admins.FirstOrDefault(a => a.Title == Operators.FirstOrDefault(c => c.OperatorID == id).UserStatus).Key;
            var sol = Admins.FirstOrDefault(a => a.Title == Operators.FirstOrDefault(c => c.OperatorID == id).UserStatus).Sol;
            var p = Passwords.FirstOrDefault(i => i.Flag == flag && i.AccountID == Accounts.FirstOrDefault(a=>a.Login == login).AccountID).Passwords;
            string d = Encryption.Decrypt(p,key,sol);
            return d;
        }
        #endregion
        #region Report
        public string ReportResource()
        {
            try
            {
                string message = "";
                string dir = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(@"ResourceDatabase.dll", ""); 
                var workbook = new XLWorkbook();
                workbook.AddWorksheet();
                var worksheet = workbook.Worksheet(1);
                worksheet.Cell("A1").Value = "Название";
                worksheet.Cell("B1").Value = "Дата начала";
                worksheet.Cell("C1").Value = "Дата окончания";
                worksheet.Cell("D1").Value = "Фамилия сотрудника";
                int row = 2;
                var resource = Resources.ToList();
                if (resource != null)
                {
                    foreach (var item in resource)
                    {
                        worksheet.Cell("A" + row).Value = item.Title;
                        worksheet.Cell("B" + row).Value = item.Date_Start.ToString("dd/MM/yyyy");
                        worksheet.Cell("C" + row).Value = item.Date_End.ToString("dd/MM/yyyy");
                        worksheet.Cell("D" + row).Value = item.People.LastName;
                        row++;
                    }
                    message = "Успешно";
                }
                else
                    message = "Нет данных для вывода";
                
                worksheet.Columns().AdjustToContents();
                string fileName = $@"{dir}\Отчет\Ресурсы.xlsx";
                workbook.SaveAs(fileName);
                System.Diagnostics.Process.Start(fileName);

                return message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }  
        public string ReportResourceEndIn3Days() 
        {
            try
            {
                string message = "";
                string dir = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(@"ResourceDatabase.dll", ""); 
                var workbook = new XLWorkbook();
                workbook.AddWorksheet();
                var worksheet = workbook.Worksheet(1);
                worksheet.Cell("A1").Value = "Название";
                worksheet.Cell("B1").Value = "Дата начала";
                worksheet.Cell("C1").Value = "Дата окончания";
                worksheet.Cell("D1").Value = "Фамилия сотрудника";
                int row = 2;
                DateTime _3Days = DateTime.Now.AddDays(3);
                var resource = Resources.Where(i=>i.Date_End <= _3Days).ToList();
                if (resource != null)
                {
                    foreach (var item in resource)
                    {
                        worksheet.Cell("A" + row).Value = item.Title;
                        worksheet.Cell("B" + row).Value = item.Date_Start.ToString("dd/MM/yyyy");
                        worksheet.Cell("C" + row).Value = item.Date_End.ToString("dd/MM/yyyy");
                        worksheet.Cell("D" + row).Value = item.People.LastName;
                        row++;
                    }
                    message = "Успешно";
                }
                else
                    message = "Нет данных для вывода";

                worksheet.Columns().AdjustToContents();
                string fileName = $@"{dir}\Отчет\3 дня.xlsx";
                workbook.SaveAs(fileName);
                System.Diagnostics.Process.Start(fileName);
                return message;
            }
            catch (Exception ex) 
            { 
                return ex.Message; 
            }
        }
        public string ReportResourceInPeople(int idPeople)
        {
            try
            {
                string message = "";
                string dir = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(@"ResourceDatabase.dll", "");
                var workbook = new XLWorkbook();
                workbook.AddWorksheet();
                var worksheet = workbook.Worksheet(1);
                worksheet.Cell("A1").Value = "Название";
                worksheet.Cell("B1").Value = "Дата начала";
                worksheet.Cell("C1").Value = "Дата окончания";
                int row = 2;
                string FIO = Peoples.FirstOrDefault(i => i.PeopleID == idPeople).Full_Name();
                var resource = Resources.Where(i => i.PeopleID <= idPeople).ToList();
                if (resource != null)
                {
                    foreach (var item in resource)
                    {
                        worksheet.Cell("A" + row).Value = item.Title;
                        worksheet.Cell("B" + row).Value = item.Date_Start.ToString("dd/MM/yyyy");
                        worksheet.Cell("C" + row).Value = item.Date_End.ToString("dd/MM/yyyy");
                        row++;
                    }
                    message = "Успешно";
                    worksheet.Cell("A"+(row+1)).Value = "Сотрудник: " + FIO;
                }
                else
                    message = "Нет данных для вывода";

                worksheet.Columns().AdjustToContents();
                string fileName = $@"{dir}\Отчет\Ресурсы {FIO}.xlsx";
                workbook.SaveAs(fileName);
                System.Diagnostics.Process.Start(fileName);
                return message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
        #region Search
        public List<Account> SearchAccount(string login, string typeAccount, string lastname) => Accounts
            .Where(i => i.LastNamePeople == lastname || i.Login == login || i.Type_Account == typeAccount)
            .ToList();
        public List<Resource> SearchResource(string title,DateTime dateStart,DateTime dateEnd,int idpeople) => Resources
            .Where(i=>i.Title == title || i.Date_Start == dateStart || i.Date_End == dateEnd || i.PeopleID ==idpeople)
            .ToList();
        public List<Computer> SeacrhComputer(string indificator,string ip,string name,string domen,int wgID,int peopleId) => Computers
            .Where(i=>i.Indificator == indificator || i.IP == ip || i.Name==name || i.PeopleID == peopleId || i.Domen == domen || i.Working_GroupID == wgID)
            .ToList();
        public List<Department> SearchDepartment(string title) => Departments
            .Where(i => i.Title == title)
            .ToList();
        public List<Operator> SearchOperator(string login,string status) => Operators
            .Where(i=>i.Login==login || i.UserStatus.Contains(status))
            .ToList();
        public List<Organization> SearchOrganization(string title) => Organizations
            .Where(i => i.Title == title)
            .ToList();
        public List<People> SeacrhPeople(string fName,string lName,string mName,string phonVoIp,int positionId,int organizationId,int departamentID) 
            => Peoples
            .Where(i=>i.FirstName == fName || i.LastName == lName || i.MiddleName == mName || i.PhoneVoIP == phonVoIp || i.PositionID == positionId || i.OrganizationID == organizationId || i.DepartmentID == departamentID)
            .ToList();
        public List<Position> SearchPosition(string title) => Positions
            .Where(i => i.Title == title)
            .ToList();
        public List<Working_Group> SearchWorking_Group(string title) => Working_Groups
            .Where(i=>i.Title == title)
            .ToList();
        #endregion
        public int Authorization(string login, string password) 
        {
            int id = -1;
            var item = Operators.FirstOrDefault(i=>i.Login == login);
            if (item != null)
            {
                if (password == Encryption.Decrypt(item.Password, Encryption.DefaultKey(),Encryption.DefaultSol()))
                    {
                        id = item.OperatorID;
                    }
            }
            return id;
        }
        public bool StatusAdmin(int id)
        {
            if (Operators.FirstOrDefault(i => i.OperatorID == id).UserStatus.Contains("admin"))
            {
                return true;
            }
            else
                return false;
        }
        public int ConvertorObjectInInt(object text) 
        {
            return Convert.ToInt32(text);
        }

        
    }
}