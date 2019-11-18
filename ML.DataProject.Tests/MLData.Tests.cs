using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ML.DataProject;
using MoralesLarios.Data.Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ML.DataProject.Tests
{
    [TestClass]
    public class UnitTest1
    {

        private string conectionString = ConnectionSettingsSettings.GetConnectionString();
        private SqlConnection connection;


        private DPGenericRepository<Employees>   repositoryEmployees;
        private DPGenericRepository<Departments> repositoryDepartments;


        [TestInitialize]
        public void Initialize()
        {
            /// Create Repository

            connection = new SqlConnection(conectionString);

            repositoryEmployees   = new DPGenericRepository<Employees>  (connection);
            repositoryDepartments = new DPGenericRepository<Departments>(connection);
        }



        [TestMethod]
        public void All()
        {
            var result = repositoryEmployees.All();

            Assert.IsNotNull(result);
        }



        [TestMethod]
        public void GetData1()
        {
            object parameters = new { Name = "Peter", Age = 30, Incomes = 35000 };

            var employeesPeter30years35000Incomes = repositoryEmployees.GetData(parameters);

            Assert.IsNotNull(employeesPeter30years35000Incomes);
        }

        [TestMethod]
        public void GetData2()
        {
            string qry = "SELECT * FROM EMPLOYEES WHERE AGE > @Age AND INCOMES > @Incomes";

            object parameters = new { Age = 30, Incomes = 35000 };

            var employeesMore30yearsMore35000 = repositoryEmployees.GetData(qry, parameters);


            Assert.IsNotNull(employeesMore30yearsMore35000);
        }

        [TestMethod]
        public void Find()
        {
            object pk = new { EmployeeID = 3 };

            var employee3 = repositoryEmployees.Find(pk);

            Assert.IsNotNull(employee3);
        }


        [TestMethod]
        public void Add1()
        {
            var newEmployee = new Employees
            {
                Name = "Lucas",
                Age = 19,
                Incomes = 15000,
                DepartmentID = 3,
                EntryDate = DateTime.Today
            };

            var rowsInserted = repositoryEmployees.Add(newEmployee);

            Assert.AreEqual(1, rowsInserted);
        }

        [TestMethod]
        public void Add2()
        {
            var newEmployees = new List<Employees>()
                                    {
                                        new Employees
                                        {
                                            Name         = "Lucas",
                                            Age          = 19,
                                            Incomes      = 15000,
                                            DepartmentID = 3,
                                            EntryDate    = DateTime.Today
                                        },
                                        new Employees
                                        {
                                            Name         = "Edgar",
                                            Age          = 64,
                                            Incomes      = 100000,
                                            DepartmentID = 3,
                                            EntryDate    = DateTime.Today
                                        }
                                    };


            var rowsInserted = repositoryEmployees.Add(newEmployees);


            Assert.AreEqual(2, rowsInserted);
        }


        [TestMethod]
        public void Remove()
        {
            object pk = new { EmployeeID = 5 };

            repositoryEmployees.Remove(pk);
        }


        //[TestMethod]
        ////[ExpectedException(typeof(ArgumentException))]
        //public void Remove_NotExist_throwException()
        //{
        //    object pk = new { EmployeeID = -9999 };

        //    repositoryEmployees.Remove(pk);
        //}


        [TestMethod]
        public void Update()
        {
            object pk = new { EmployeeID = 1 };

            var employeeOne = repositoryEmployees.Find(pk);

            employeeOne.DepartmentID = 2;
            employeeOne.Incomes = 300000;

            var rowUpdated = repositoryEmployees.Update(employeeOne, pk);


            Assert.AreEqual(1, rowUpdated);
        }


        [TestMethod]
        public void InsertOrUpdate()
        {
            var employee = new Employees
            {
                EmployeeID   = 99,
                Name         = "Lucas",
                Age          = 19,
                Incomes      = 15000,
                DepartmentID = 3,
                EntryDate    = DateTime.Today
            };


            var pk = new { employee.EmployeeID };

            /// we don't know if employee exists
            /// InsertOrUpdate method be responsible for INSERT OR UPDATE
            var rowModified = repositoryEmployees.InstertOrUpdate(employee, pk);



            Assert.AreEqual(1, rowModified);
        }




        [TestCleanup]
        public void Clean()
        {
            connection.Dispose();
            //repository.Dispose();
        }
    }
}
