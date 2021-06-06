using ResourceTable.Table;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ResourceDatabase
{
    //public class WorkJson
    //{
    //    public static async Task AddJsonAdmin(Admin admin)
    //    {
    //        List<Admin> admins = new List<Admin>();
    //        List<Account> accounts = new List<Account>();
    //        string k = "";
    //        using (FileStream read = new FileStream("admin.json", FileMode.Open))
    //        {
    //            var jsonadmins = await JsonSerializer.DeserializeAsync<List<Admin>>(read);
    //            admins.AddRange(jsonadmins);
    //            admins.Add(admin);
    //        }
    //        using (FileStream fs = new FileStream("admin.json", FileMode.Create))
    //        {
    //            var options = new JsonSerializerOptions
    //            {
    //                AllowTrailingCommas = true
    //            };
    //            await JsonSerializer.SerializeAsync<List<Admin>>(fs, admins, options);
    //        }
    //        k = admins[0].Key;
    //        using (FileStream read = new FileStream("acc.json", FileMode.Open))
    //        {
    //            accounts = await JsonSerializer.DeserializeAsync<List<Account>>(read);
    //            foreach (var account in accounts)
    //            {
    //                account.Password.Add(Encryption.Encrypt(Encryption.Decrypt(accounts[0].Password[0], k), admin.Key));
    //            }
    //        }
    //        using (FileStream fs = new FileStream("acc.json", FileMode.Create))
    //        {
    //            var options = new JsonSerializerOptions
    //            {
    //                AllowTrailingCommas = true
    //            };
    //            await JsonSerializer.SerializeAsync<List<Account>>(fs, accounts, options);
    //        }
    //    }
    //    public static async Task AddJsonAccount(Account account)
    //    {
    //        List<Account> list = new List<Account>();
    //        using (FileStream read = new FileStream("acc.json", FileMode.Open))
    //        {
    //            list = await JsonSerializer.DeserializeAsync<List<Account>>(read);
    //            list.Add(account);
    //        }
    //        using (FileStream fs = new FileStream("acc.json", FileMode.Create))
    //        {
    //            var options = new JsonSerializerOptions
    //            {
    //                AllowTrailingCommas = true
    //            };
    //            await JsonSerializer.SerializeAsync<List<Account>>(fs, list, options);
    //        }
    //    }    
    //}
}
