using ResourceTable.Table;
using ResourceTable.Table.Logins_Passwords;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        }

        #region Tables
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Computer> Computers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Operator> Operators { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<People> Peoples { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Working_Group> Working_Groups { get; set; }
        public virtual DbSet<Type_Account> Type_Accounts { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Domain_UZ> Domain_UZs { get; set; }
        #endregion
        #region AddTable
        public string AddAccount(string login, string password, int titleID, int accountID, int peopleID)
        {
            try
            {               
                      Accounts.Add(new Account()
                    {
                        Login = login,
                        Password = password,
                        AccountID = accountID,
                        PeopleID= peopleID,
                        Type_AccountID = titleID
                    });
                SaveChanges();
                return "Запись успешно добавлена";
            }
            catch (Exception ex) { return ex.Message; }
        }
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
        public string AddOperator(string login, string password, int roleID, int peopleID)
        {
            try
            {
                Operators.Add(new Operator()
                {
                    Login = login,
                    Password = password,
                    RoleID = roleID,
                    PeopleID = peopleID
                });
                SaveChanges();
                return "Запись успешно добавлена";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string AddPeople(string firstName, string lastName, string middleName, string phone, string phoneVoIP, List<int> ids)
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
                    PositionID = ids[0],
                    OrganizationID = ids[1],
                    DepartmentID = ids[2],
                    _1C_ERPID = ids[3],
                    Cisco_WebexID = ids[4],
                    DirectumID = ids[5],
                    Domain_UZID = ids[6],
                    KerioID = ids[7],
                    MailID = ids[8],
                    TruekonffID = ids[9]
                };
                Peoples.Add(people);
                Departments.FirstOrDefault(i => i.DepartmentID == ids[2]).People.Add(people);
                Organizations.FirstOrDefault(i => i.OrganizationID == ids[1]).People.Add(people);
                Positions.FirstOrDefault(i => i.PositionID == ids[0]).People.Add(people);
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
        public string AddRole(string title, List<Visibility> titleTable, List<Visibility> titleColumn) 
        {
            try 
            {
                Roles.Add(new Role()
                {
                    Title = title,
                    TitleTable = titleTable,
                    TitleColumn = titleColumn
                });
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
        //Додеписать метод

        //public string EditAccount(int id,string login, string password, string title,string status)
        //{
        //    try
        //    {             
        //        SaveChanges();
        //        return "Запись успешно изменена";
        //    }
        //    catch (Exception ex) { return ex.Message; }
        //}      
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
        public string EditOperator(int id,string login, string password, int roleID, int peopleID)
        {
            try
            {
                var item = Operators.FirstOrDefault(i=>i.OperatorID == id);
                item.Login = login;
                item.Password = password;
                item.RoleID = roleID;
                item.PeopleID = peopleID;
                SaveChanges();
                   return "Запись успешно изменена";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string EditPeople(int id,string firstName, string lastName, string middleName, string phone, string phoneVoIP, List<int> ids)
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
                item.PositionID = ids[0];
                item.OrganizationID = ids[1];
                item.DepartmentID = ids[2];
                item._1C_ERPID = ids[3];
                item.Cisco_WebexID = ids[4];
                item.DirectumID = ids[5];
                item.Domain_UZID = ids[6];
                item.KerioID = ids[7];
                item.MailID = ids[8];
                item.TruekonffID = ids[9];
                Departments.FirstOrDefault(i => i.DepartmentID == ids[2]).People.Add(item);
                Organizations.FirstOrDefault(i => i.OrganizationID == ids[1]).People.Add(item);
                Positions.FirstOrDefault(i => i.PositionID == ids[0]).People.Add(item);
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
        public string EditRole(int id,string title, List<Visibility> titleTable, List<Visibility> titleColumn)
        {
            try
            {
                var item = Roles.FirstOrDefault(i=>i.RoleID == id);
                item.Title = title;
                item.TitleTable = titleTable;
                item.TitleColumn = titleColumn;
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
        public string RemoveAccount(int id)
        {
            try
            {
                var item = Accounts.FirstOrDefault(i => i.AccountID == id);
                Accounts.Remove(item);
                SaveChanges();
                return "Запись успешно удалена";
            }
            catch (Exception ex) { return ex.Message; }
        }
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
                var item = Operators.FirstOrDefault(i => i.OperatorID == id);
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
        public string RemoveRole(int id)
        {
            try
            {
                var item = Roles.FirstOrDefault(i => i.RoleID == id);
                Roles.Remove(item);
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
        public List<Resource> GetResource() => Resources.ToList();
        public List<Computer> GetComputer() => Computers.ToList();
        public List<Department> GetDepartment() => Departments.ToList();
        public List<Operator> GetOperator() => Operators.ToList();
        public List<Organization> GetOrganization() => Organizations.ToList();
        public List<People> GetPeople() => Peoples.ToList();
        public List<Position> GetPosition() => Positions.ToList();
        public List<Role> GetRole() => Roles.ToList();
        public List<Working_Group> GetWorking_Group() => Working_Groups.ToList();
        #region GetInId       
        public Domain_UZ GetDomain_UZInId(int id) => Domain_UZs.FirstOrDefault(i => i.Domain_UZID == id);
        public Account GetKerioInId(int id) => Accounts.FirstOrDefault(i => i.AccountID == id);    
        public Resource GetResourceInId(int id) => Resources.FirstOrDefault(i=>i.ResourceID == id);
        public Computer GetComputerInId(int id) => Computers.FirstOrDefault(i => i.ComputerID == id);
        public Department GetDepartmentInId(int id) => Departments.FirstOrDefault(i => i.DepartmentID == id);
        public Operator GetOperatorInId(int id) => Operators.FirstOrDefault(i=>i.OperatorID == id);
        public Organization GetOrganizationInId(int id) => Organizations.FirstOrDefault(i=>i.OrganizationID == id);
        public People GetPeopleInId(int id) => Peoples.FirstOrDefault(i=>i.PeopleID == id);
        public Position GetPositionInId(int id) => Positions.FirstOrDefault(i=>i.PositionID == id);
        public Role GetRoleInId(int id) => Roles.FirstOrDefault(i=>i.RoleID == id);
        public Working_Group GetWorking_GroupInId(int id) => Working_Groups.FirstOrDefault(i=>i.Working_GroupID == id);
           #endregion

        public int Authorization(string login, string password) 
        {
            var item = Operators.FirstOrDefault(i=>i.Login == login && i.Password == password);
            if (item != null)
            {
                return item.OperatorID;
            }
            else return -1;
        }
        #endregion
    }
}