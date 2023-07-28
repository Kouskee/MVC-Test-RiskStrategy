using Infrastructure.Enums;
using Infrastructure.Models;

namespace Infrastructure.DataModels
{
    public class DataPlaceholder : IDisposable
    {
        public DataPlaceholder()
        {
            FillData();
        }

        private async void FillData()
        {
            using (var context = new CompanyContext())
            {
                var company1 = new Company
                {
                    Name = "Super Mart of the West",
                    Adress = "702 SW 8th Street",
                    City = Cities.Bent,
                    State = States.Arka,
                    Phone = "(800) 555-2797"
                };

                var company2 = new Company
                {
                    Name = "Electronics Deport",
                    Adress = "Moscow 809",
                    City = Cities.SanJose,
                    State = States.Some,
                    Phone = "(800) 595-3232"
                };

                await context.AddRangeAsync(new List<Company> { company1, company2 });
                context.SaveChanges();

                var employees = await FillDataEmployees(context, company1, company2);
                FillDataHistory(context, company1, company2);

                context.SaveChanges();

                FillDataNotes(context, employees);

                context.SaveChanges();
            }

            Dispose();
        }

        private async Task<List<Employee>> FillDataEmployees(CompanyContext context, Company company1, Company company2)
        {
            var employee1 = new Employee
            {
                FirstName = "John",
                LastName = "Heart",
                Title = "Mr.",
                BirthDate = new DateOnly(1997, 1, 21),
                Position = EmployeePosition.CEO,
                Company = company1
            };

            var employee2 = new Employee
            {
                FirstName = "Olivia",
                LastName = "Peyton",
                Title = "Ms.",
                BirthDate = new DateOnly(1994, 3, 12),
                Position = EmployeePosition.CEO,
                Company = company1
            };

            var employee3 = new Employee
            {
                FirstName = "Robert",
                LastName = "Reagan",
                Title = "Mr.",
                BirthDate = new DateOnly(1975, 12, 30),
                Position = EmployeePosition.AGE,
                Company = company2
            };

            var employees = new List<Employee> { employee1, employee2, employee3 };
            await context.AddRangeAsync(employees);

            return employees;
        }

        private async void FillDataHistory(CompanyContext context, Company company1, Company company2)
        {
            var history = new List<CompanyOrder>
            {
                new CompanyOrder
                {
                    OrderDate = new DateOnly(2013, 11, 12),
                    StoreCity = Cities.LasVegas,
                    Company = company1
                },
                new CompanyOrder
                {
                    OrderDate = new DateOnly(2013, 11, 14),
                    StoreCity = Cities.LasVegas,
                    Company = company1
                },
                new CompanyOrder
                {
                    OrderDate = new DateOnly(2013, 11, 18),
                    StoreCity = Cities.LasVegas,
                    Company = company1
                },
                new CompanyOrder
                {
                    OrderDate = new DateOnly(2013, 11, 22),
                    StoreCity = Cities.Denv,
                    Company = company2
                },
                new CompanyOrder
                {
                    OrderDate = new DateOnly(2013, 11, 30),
                    StoreCity = Cities.LasVegas,
                    Company = company2
                },
            };

            await context.AddRangeAsync(history);
        }

        private async void FillDataNotes(CompanyContext context, List<Employee> employees)
        {
            var history = new List<CompanyNote>
            {
                new CompanyNote
                {
                    InvoiceNumber = 35703,
                    Employee = employees[0].FirstName + " " + employees[0].LastName,
                    Company = employees[0].Company!
                },
                new CompanyNote
                {
                    InvoiceNumber = 35711,
                    Employee = employees[1].FirstName + " " + employees[1].LastName,
                    Company = employees[1].Company!
                },
                new CompanyNote
                {
                    InvoiceNumber = 35714,
                    Employee = employees[2].FirstName + " " + employees[2].LastName,
                    Company = employees[2].Company!
                }
            };

            await context.AddRangeAsync(history);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
