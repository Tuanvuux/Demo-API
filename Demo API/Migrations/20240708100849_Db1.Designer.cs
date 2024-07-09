﻿// <auto-generated />
using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Demo_API.Migrations
{
    [DbContext(typeof(APIDbContext))]
    [Migration("20240708100849_Db1")]
    partial class Db1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entities.AccTransaction", b =>
                {
                    b.Property<long>("Txn_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("TXN_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Txn_Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("ACCOUNT_ID");

                    b.Property<float>("Amount")
                        .HasColumnType("real")
                        .HasColumnName("AMOUNT");

                    b.Property<int?>("ExcutionBranchId")
                        .HasColumnType("int")
                        .HasColumnName("EXCUTION_BRANCH_ID");

                    b.Property<DateTime>("Fund_Avail_Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("FUNDS_AVAIL_DATE");

                    b.Property<int?>("TellerEmpId")
                        .HasColumnType("int")
                        .HasColumnName("TELLER_EMP_ID");

                    b.Property<DateTime>("TxnDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("TXN_DATE");

                    b.Property<string>("TxnTypeCd")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("TXN_TYPE_CD");

                    b.HasKey("Txn_Id");

                    b.ToTable("ACC_TRANSACTION");
                });

            modelBuilder.Entity("DAL.Entities.Account", b =>
                {
                    b.Property<int>("Account_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ACCOUNT_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Account_Id"));

                    b.Property<float?>("AvailBalance")
                        .HasColumnType("real")
                        .HasColumnName("AVAIL_BALANCE");

                    b.Property<DateOnly?>("CloseDate")
                        .HasColumnType("date")
                        .HasColumnName("CLOSE_DATE");

                    b.Property<DateOnly?>("LastActivityDay")
                        .HasColumnType("date")
                        .HasColumnName("LAST_ACTIVITY_DATE");

                    b.Property<int>("OpenBranchId")
                        .HasColumnType("int")
                        .HasColumnName("OPEN_BRANCH_ID");

                    b.Property<DateOnly>("OpenDate")
                        .HasColumnType("date")
                        .HasColumnName("OPEN_DATE");

                    b.Property<int>("OpenEmpId")
                        .HasColumnType("int")
                        .HasColumnName("OPEN_EMP_ID");

                    b.Property<float?>("PendingBalance")
                        .HasColumnType("real")
                        .HasColumnName("PENDING_BALANCE");

                    b.Property<string>("ProductCd")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("PRODUCT_CD");

                    b.Property<string>("Status")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("STATUS");

                    b.HasKey("Account_Id");

                    b.ToTable("ACCOUNT");
                });

            modelBuilder.Entity("DAL.Entities.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BRANCH_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BranchId"));

                    b.Property<string>("Address")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("ADDRESS");

                    b.Property<string>("City")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CITY");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NAME");

                    b.Property<string>("State")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("STATE");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("ZIP_CODE");

                    b.HasKey("BranchId");

                    b.ToTable("BRANCH");
                });

            modelBuilder.Entity("DAL.Entities.Business", b =>
                {
                    b.Property<int>("CustId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CUST_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustId"));

                    b.Property<DateOnly?>("IncorpDate")
                        .HasColumnType("date")
                        .HasColumnName("INCORP_DATE");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("NAME");

                    b.Property<string>("StateId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("STATE_ID");

                    b.HasKey("CustId");

                    b.ToTable("BUSINESS");
                });

            modelBuilder.Entity("DAL.Entities.Customer", b =>
                {
                    b.Property<int>("CustId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CUST_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustId"));

                    b.Property<string>("Address")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("ADDRESS");

                    b.Property<string>("City")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CITY");

                    b.Property<string>("CustTypeCd")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("CUST_TYPE_CD");

                    b.Property<string>("FedId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("FED_ID");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("POSTAL_CODE");

                    b.Property<string>("State")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("STATE");

                    b.HasKey("CustId");

                    b.ToTable("CUSTOMER");
                });

            modelBuilder.Entity("DAL.Entities.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DEPT_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeptId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NAME");

                    b.HasKey("DeptId");

                    b.ToTable("DEPARTMENT");
                });

            modelBuilder.Entity("DAL.Entities.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EMP_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpId"));

                    b.Property<int?>("DeptId")
                        .HasColumnType("int")
                        .HasColumnName("DEPT_ID");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("END_DATE");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("LAST_NAME");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("START_DAY");

                    b.Property<int?>("SuperiorEmpId")
                        .HasColumnType("int")
                        .HasColumnName("SUPERIOR_EMP_ID");

                    b.Property<string>("Title")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("TITLE");

                    b.HasKey("EmpId");

                    b.ToTable("EMPLOYEE");
                });

            modelBuilder.Entity("DAL.Entities.Individual", b =>
                {
                    b.Property<int>("Cust_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CUST_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cust_Id"));

                    b.Property<DateOnly>("BirthDay")
                        .HasColumnType("date")
                        .HasColumnName("BIRTH_DAY");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("LAST_NAME");

                    b.HasKey("Cust_Id");

                    b.ToTable("INDIVIDUAL");
                });

            modelBuilder.Entity("DAL.Entities.Product", b =>
                {
                    b.Property<string>("ProductCd")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("PRODUCT_CD");

                    b.Property<DateTime?>("DateOffered")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE_OFFERED");

                    b.Property<DateTime?>("DateRetired")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE_RETIRED");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("ProductCd");

                    b.ToTable("PRODUCT");
                });

            modelBuilder.Entity("DAL.Entities.ProductType", b =>
                {
                    b.Property<string>("ProductTypeCd")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("PRODUCT_TYPE_CD");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NAME");

                    b.HasKey("ProductTypeCd");

                    b.ToTable("PRODUCT_TYPE");
                });
#pragma warning restore 612, 618
        }
    }
}
