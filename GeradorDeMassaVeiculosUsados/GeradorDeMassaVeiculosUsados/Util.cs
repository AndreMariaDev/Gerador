using App.Domain.Models;
using GeradorDeMassaVeiculosUsados.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeradorDeMassaVeiculosUsados
{
    public class Util
    {
        public async Task<List<T>> ReadFile<T>(String FileName) where T: DomainEntity
        {
            try
            {
                List<T> itens = new List<T>();
                using (System.IO.StreamReader sr = new StreamReader(String.Format("./Data/{0}.json", FileName))) 
                {
                    itens = JsonSerializer.Deserialize<List<T>>(sr.ReadToEnd());
                }
                return itens;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<T>> ReadFileNew<T>(String FileName)
        {
            try
            {
                List<T> itens = new List<T>();
                using (System.IO.StreamReader sr = new StreamReader(String.Format("./Data/{0}.json", FileName)))
                {
                    itens = JsonSerializer.Deserialize<List<T>>(sr.ReadToEnd());
                }
                return itens;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task WriteFile<T>(List<T> itens) where T : DomainEntity
        {
            String fileName = itens[0].GetType().Name;
            using (FileStream fs = File.Create(String.Format("./Data/{0}.json", fileName)))
            {
                JsonSerializerOptions jso = new JsonSerializerOptions();
                jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                await JsonSerializer.SerializeAsync(fs, itens, jso);
            }
        }

        public async Task WriteFileSql(List<string> itens,String fileName)
        {
            var path = String.Format("./Data/{0}.sql", fileName);

            // Create a file to write to.

            using (StreamWriter w = File.AppendText(path))
            {
                foreach (var item in itens)
                {
                    w.WriteLine(item);
                }
                w.Flush();
            }
        }

        public String GetBoard() 
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        public String GetLogin()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        public String GetPhone()
        {
            var chars = "0123456789";
            var stringCharsBegin = new char[5];
            var stringCharsEnd = new char[4];
            var random = new Random();

            for (int i = 0; i < stringCharsBegin.Length; i++)
            {
                stringCharsBegin[i] = chars[random.Next(chars.Length)];
            }

            for (int i = 0; i < stringCharsEnd.Length; i++)
            {
                stringCharsEnd[i] = chars[random.Next(chars.Length)];
            }

            return String.Format("(11) {0}-{1}", new String(stringCharsBegin), new String(stringCharsEnd));
        }

        public String GetEmail(String name)
        {
            String emailName = name.Replace(" ", ".");
            String email = String.Format("{0}@gmail.com", emailName);
            return email;
        }

        public String GetSerialNumber()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[12];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        public async Task<List<Vehicle>> GetVehicle() 
        {
            List<Brand> brandList = null;
            List<Vehicle> vehicleList = new List<Vehicle>();
            try
            {
                brandList = await this.ReadFile<Brand>("brand");
                int code = 1;
                foreach (var brand in brandList)
                {
                    foreach (var model in brand.VehiclesModel)
                    {
                        Random rnd = new Random();
                        int year = rnd.Next(2010, 2020);
                        int price = rnd.Next(20000, 50000);
                        int Km = rnd.Next(80, 120);

                        List<String> ImageGallery = new List<string>();
                        for (int i = 0; i < 4; i++)
                        {
                            ImageGallery.Add(Guid.NewGuid().ToString());
                        }

                        vehicleList.Add(new Vehicle()
                        {
                            Id = Guid.NewGuid(),
                            Code = 0,
                            CodeBrand = brand.Code,
                            CodeModel = model.Code,
                            CodeProductType = 1,
                            CodeStatus = 1,
                            CodeRecord = 0,
                            Record = null,
                            Name = String.Format("{0} {1} - ano {2}", model.Name, brand.Name, year),
                            Board = GetBoard(),
                            Price = String.Format("R$ {0},00", price),
                            PreviousPrice = String.Format("R$ {0},00", price),
                            SoldVehicle = false,
                            GrossWeight = "1t",
                            CombinedWeight = "1.3T",
                            Mileage = String.Format("Km {0}", Km),
                            ModelYear = String.Format("{0}", year),
                            SerialNumber = this.GetSerialNumber(),
                            LastInspection = String.Format("{0}", year == 2020 ? year : year + 1),
                            RegisterNumber = this.GetSerialNumber(),
                            RegistrationYear = String.Format("{0}", year == 2020 ? year : year + 1),
                            UserCode = "AMERICAS\\GANDRED",
                            CreateDate = DateTime.Now,
                            OtherInformation = "Veículo creado por insert de massa de dados.",
                            IsActive = true,
                            ImageGallery = String.Join(",", ImageGallery),
                            Proposals = null,
                        });
                    }
                    code++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vehicleList;
        }

        public async Task<List<Immobile>> GetImmobile()
        {
            List<Immobile> immobileList = new List<Immobile>();

            List<String> typeImmobile = new List<String>();
            typeImmobile.Add("Casa");
            typeImmobile.Add("Apartamento");
            typeImmobile.Add("Galpão");
            typeImmobile.Add("Predio");
            typeImmobile.Add("Terreno");

            List<String> city = new List<String>();
            city.Add("São Paulo SP");
            city.Add("Rio de Jameiro RJ");
            city.Add("Belo Horizonte MG");

            Dictionary<String,String> addressList = new Dictionary<String, String>();

            addressList.Add("São Paulo SP 0","Av. Brg. Faria Lima, 1478 - Pinheiros , 01451-001");
            addressList.Add("São Paulo SP 1", "Av. Rebouças, 990 - Pinheiros , 05402-000");
            addressList.Add("São Paulo SP 2", "Av. Engenheiro Luís Carlos Berrini, 105 , 04571-010");
            addressList.Add("São Paulo SP 3", "R. Olimpíadas - Vila Olímpia");
            addressList.Add("São Paulo SP 4", "R. Funchal - Vila Olímpia , 04551-060");
            addressList.Add("Rio de Jameiro RJ 0", "R. Nascimento Silva, 107 - Ipanema 22421-025");
            addressList.Add("Rio de Jameiro RJ 1", "Av. Atlântica 1702 - Copacabana");
            addressList.Add("Belo Horizonte MG 0", "RUA DOS CAETÉS 51");
            addressList.Add("Belo Horizonte MG 1", "RUA JACUÍ 51");

            try
            {
                int code = 1;

                foreach (var address in addressList)
                {
                    Random rnd = new Random();
                    int year = rnd.Next(2010, 2020);
                    int price = rnd.Next(200000, 500000);
                    int indexType = rnd.Next(0, 5);
                    int indexCity = rnd.Next(0, 4);

                    List<String> ImageGallery = new List<string>();
                    for (int i = 0; i < 4; i++)
                    {
                        ImageGallery.Add(Guid.NewGuid().ToString());
                    }

                    immobileList.Add(new Immobile()
                    {
                        Id = Guid.NewGuid(),
                        Code = 0,
                        CodeProductType = 6,
                        CodeStatus = 1,
                        Name = String.Format("{0}", typeImmobile[indexType]),
                        Price = String.Format("R$ {0},00", price),
                        SoldImmobile = false,
                        RegistrationNumber = this.GetSerialNumber(),
                        RegistrationYear = String.Format("{0}", year == 2020 ? year : year + 1),
                        UserCode = "AMERICAS\\GANDRED",
                        CreateDate = DateTime.Now,
                        OtherInformation = "Veículo creado por insert de massa de dados.",
                        IsActive = true,
                        ImageGallery = String.Join(",", ImageGallery),
                        Proposals = null,
                        CodeTypeImmoble = ((typeImmobile[indexType] == "Casa" || typeImmobile[indexType] == "Apartamento" || typeImmobile[indexType] == "Predio") ? 1 : 2),
                        Location = String.Format("{0} - {1}", address.Value, address.Key)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return immobileList;
        }

        public async Task<List<User>> GetNewUser() 
        {
            List<User> Users = new List<User>();
            List<UserName> ListName = new List<UserName>();
            ListName.Add(new UserName() { FirstName = "António", LastName = "António Carlos Jobin" });
            ListName.Add(new UserName() { FirstName = "António", LastName = "António Carlos Belchior" });
            ListName.Add(new UserName() { FirstName = "Ana", LastName = "Ana Henkel" });
            ListName.Add(new UserName() { FirstName = "Bruno", LastName = "Bruno Zanarelli" });
            ListName.Add(new UserName() { FirstName = "Beatriz", LastName = "Beatriz Segal" });
            ListName.Add(new UserName() { FirstName = "Carlos", LastName = "Carlos Palugan" });
            ListName.Add(new UserName() { FirstName = "Debora", LastName = "Debora Roder" });
            ListName.Add(new UserName() { FirstName = "Joaquim", LastName = "Roder di Maria" });
            ListName.Add(new UserName() { FirstName = "Paula", LastName = "Grotti" });
            ListName.Add(new UserName() { FirstName = "Francisco", LastName = "Francisco Roder di Maria" });

            try
            {
                Random rnd = new Random();

                foreach (var item in ListName)
                {
                    Users.Add(new User()
                    {
                        Id = Guid.NewGuid(),
                        Code = 0,
                        UserCode = "AMERICAS\\GANDRED",
                        Email = this.GetEmail(item.LastName),
                        Name = item.LastName,
                        UserProfile = null,
                        IDProfile = 1,
                        UserCodeExternal = String.Format(@"AMERICAS\{0}", GetLogin()),
                        CreateDate = DateTime.Now,
                        DateUpdate = null,
                        IsActive = true,
                    });
                }

                return Users;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public async Task CreateUsers()
        {

            try
            {
                var listusers = await this.GetNewUser();
                await this.WriteFile<User>(listusers);

                var proposalv = await GetVehicleProposal();
                await this.WriteFile<VehicleProposal>(proposalv);

                var proposal = await GetImmobileProposal();
                await this.WriteFile<ImmobileProposal>(proposal);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task CreateAssets() 
        {
            
            try
            {
                var listVehicle = await this.GetVehicle();
                await this.WriteFile<Vehicle>(listVehicle);

                var listImmobile = await this.GetImmobile();
                await this.WriteFile<Immobile>(listImmobile);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task CreateModelByBrandJson()
        {
            List<NewBrand> brandNewList = null;
            List<Brand> brandList = new List<Brand>();
            try
            {
                brandNewList = await this.ReadFileNew<NewBrand>("brandHomolog");
                var list = brandNewList.GroupBy(x => x.brand).Select(y => new { Name = y.Key});
                foreach (var brand in list)
                {
                    var vehicles = brandNewList.Where(x => x.brand == brand.Name);
                    List<VehicleModel> vehicleModelList = new List<VehicleModel>();
                    foreach (var vehicle in vehicles)
                    {
                        vehicleModelList.Add(new VehicleModel()
                        {
                            Code = 0,
                            Id = Guid.NewGuid(),
                            IsActive = true,
                            CreateDate = DateTime.UtcNow,
                            DateUpdate = null,
                            UserCode = "1234567",
                            Name = vehicle.model,
                            CodeBrand = 0,
                        });
                    }

                    brandList.Add(new Brand()
                    {
                        Code = 0,
                        Id = Guid.NewGuid(),
                        CreateDate = DateTime.UtcNow,
                        IsActive = true,
                        UserCode = "1234567",
                        Name = brand.Name,
                        VehiclesModel = vehicleModelList
                    });
                }
                await this.WriteFile<Brand>(brandList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task CreateModelByBrandSql()
        {

            List<NewBrand> brandNewList = null;
            try
            {
                brandNewList = await this.ReadFileNew<NewBrand>("brandHomolog");
                var list = brandNewList.GroupBy(x => x.brand).Select(y => new { Name = y.Key });
                foreach (var brand in list)
                {
                    var vehicles = brandNewList.Where(x => x.brand == brand.Name);
                    List<String> vehicleModelList = new List<String>();
                    foreach (var vehicle in vehicles)
                    {
                        //VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7});
                        vehicleModelList.Add(
                            String.Format(
                                "INSERT INTO public.tbl_modelo_veiculo(cod_model, " + "\"" + "Id" + "\"" + ", statu_ativo, dat_criac, dat_atual, cod_usuar, nom_model, " + "\"" + "cod_Brand"+ "\"" + ") VALUES({0}, '{1}', {2}, '{3}', {4}, '{5}', '{6}', {7});",
                                0,
                                Guid.NewGuid(),
                                true,
                                DateTime.UtcNow,
                                "null",
                                "1234567",
                                vehicle.model,
                                vehicle.brandCode)
                        );
                    }
                    List<String> brandList = new List<String>();
                    brandList.Add(String.Format(
                        @"INSERT INTO public.tbl_marca(cod_marca, " + "\"" + "Id" + "\"" + ",statu_ativo, dat_criac, dat_atual, cod_usuar, nom_marca) VALUES({0}, '{1}', {2}, '{3}', {4}, '{5}', '{6}'); ",
                        0,
                        Guid.NewGuid(),
                        true,
                        DateTime.UtcNow,
                        "null",
                        "1234567",
                        brand.Name
                    ));
                    await this.WriteFileSql(brandList, "script_brand");
                    await this.WriteFileSql(vehicleModelList, "script_brand");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<VehicleProposal>> GetVehicleProposal() 
        {
            List<Vehicle> vehicleList = await this.ReadFile<Vehicle>("vehicle"); 
            List <VehicleProposal> vehicleProposalList = new List<VehicleProposal>();
            var users = await GetNewUser();
            try
            {
                foreach (var item in vehicleList)
                {
                    Random rnd = new Random();
                    int year = rnd.Next(2010, 2020);
                    int Km = rnd.Next(80, 120);

                    foreach (var user in users)
                    {
                        int price = rnd.Next(20000, 50000);
                        vehicleProposalList.Add(new VehicleProposal()
                        {
                            Code = 0,
                            CodeVehicle = item.Code,
                            Name = user.Name,
                            Email = user.Email,
                            Phone = GetPhone(),
                            OtherInformation = "Proposta para Veículo creado por insert de massa de dados.",
                            ProposalValue = String.Format("R$ {0},00", price),
                            ProposalValueCoin = price,
                            CodeAssets = 1,
                            TypeAssets = item.CodeProductType,
                            CreateDate = DateTime.Now,
                            Id = Guid.NewGuid(),
                            IsActive = true,
                            UserCode = user.UserCodeExternal,
                            UserCodeClient = user.UserCodeExternal
                        });
                    }
                }

                return vehicleProposalList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ImmobileProposal>> GetImmobileProposal()
        {
            List<Immobile> immobileList = await this.ReadFile<Immobile>("immobile");
            List<ImmobileProposal> immobileProposalList = new List<ImmobileProposal>();
            var users = await GetNewUser();
            try
            {
                foreach (var item in immobileList)
                {
                    Random rnd = new Random();
                    int year = rnd.Next(2010, 2020);
                    int Km = rnd.Next(80, 120);

                    foreach (var user in users)
                    {
                        int price = rnd.Next(20000, 50000);
                        immobileProposalList.Add(new ImmobileProposal()
                        {
                            Code = 0,
                            CodeImmobile = item.Code,
                            Name = user.Name,
                            Email = user.Email,
                            Phone = GetPhone(),
                            OtherInformation = "Proposta para Immobile creado por insert de massa de dados.",
                            ProposalValue = String.Format("R$ {0},00", price),
                            ProposalValueCoin = price,
                            CodeAssets = 1,
                            TypeAssets = item.CodeProductType,
                            CreateDate = DateTime.Now,
                            Id = Guid.NewGuid(),
                            IsActive = true,
                            UserCode = user.UserCodeExternal,
                            UserCodeClient = user.UserCodeExternal
                        });
                    }
                }

                return immobileProposalList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    public class UserName 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
