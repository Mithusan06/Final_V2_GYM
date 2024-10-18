using Gym_Fees.Entity;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;

namespace Gym_Fees.DataBase
{
    public class AppDbContext
    {
        private readonly string _Connection;

        public AppDbContext(string connectionString)
        {
            _Connection = connectionString;
        }
        
        public void Initialize()
        {

                using (var sqlConnection = new SqlConnection(_Connection))
                {
                    sqlConnection.Open();
                    var createTableCommand = sqlConnection.CreateCommand();
                    createTableCommand.CommandText = @"
                        IF NOT EXISTS (SELECT * FROM SYS.TABLES WHERE NAME = 'Members')
                        BEGIN 
                            CREATE TABLE Members (
                                MemberId UNIQUEIDENTIFIER PRIMARY KEY,
                                FullName NVARCHAR(25) NOT NULL,
                                NicNumber NVARCHAR(25) NOT NULL,
                                PhoneNumber NVARCHAR(25) NOT NULL,
                                UserName NVARCHAR(25) NOT NULL,
                                Password NVARCHAR(25) NOT NULL,
                                Userole NVARCHAR(25) NOT NULL,
                                Image  NVARCHAR(200) NOT NULL,
                                DateofRegistration DATETIME NOT NULL
                              );
                        END
                    ";
                    createTableCommand.ExecuteNonQuery();
                createTableCommand.CommandText = @"
                        IF NOT EXISTS (SELECT * FROM SYS.TABLES WHERE NAME = 'Pendingedits')
                        BEGIN 
                            CREATE TABLE Pendingedits (
                                PendingeditId UNIQUEIDENTIFIER PRIMARY KEY,
                                            MemberId UNIQUEIDENTIFIER  NOT NULL,

                                FullName NVARCHAR(25) NOT NULL,
                                NicNumber NVARCHAR(25) NOT NULL,
                                PhoneNumber NVARCHAR(25) NOT NULL,
                                UserName NVARCHAR(25) NOT NULL,
                               
                           
                              );
                        END
                    ";
                createTableCommand.ExecuteNonQuery();
                createTableCommand.CommandText = @"
                                     IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Notification')
                                            CREATE TABLE Notification(
                                           N_Id UNIQUEIDENTIFIER PRIMARY KEY,
                                            MemberId UNIQUEIDENTIFIER  NOT NULL,
                                            N_Type NVARCHAR(50) NOT NULL, 
                                            N_Status NVARCHAR(50) NOT NULL)      
                                    ";
                createTableCommand.ExecuteNonQuery();
                createTableCommand.CommandText = @"
        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name='Payment')

                     CREATE TABLE Payment(
                     PaymentId UNIQUEIDENTIFIER PRIMARY KEY,
                     MemberId  UNIQUEIDENTIFIER NOT NULL,
                       Amount DECIMAL (15,2) NOT NULL,
                    Paymentmethod NVARCHAR(45) NOT NULL,
                   PaymentType NVARCHAR(45) NOT NULL,
                    PaymentStatus  NVARCHAR(45) NOT NULL,
                    PaymentDate DATE NOT NULL,
                     NextpaymentDate DATE NOT NULL)";
                createTableCommand.ExecuteNonQuery();
                createTableCommand.CommandText = @"
                        IF NOT EXISTS (SELECT * FROM SYS.TABLES WHERE NAME = 'Pendingprograms')
                        BEGIN 
                            CREATE TABLE Pendingprograms (
                               PendingprogramId UNIQUEIDENTIFIER PRIMARY KEY,
                                           TrainingId UNIQUEIDENTIFIER  NOT NULL,
                                            MemberId UNIQUEIDENTIFIER  NOT NULL,
                                Cardio NVARCHAR(250) NOT NULL,
                                Weighttraining NVARCHAR(25) NOT NULL,
                                
                               
                           
                              );
                        END
                    ";
                createTableCommand.ExecuteNonQuery();
                createTableCommand.CommandText = @"
                        IF NOT EXISTS (SELECT * FROM SYS.TABLES WHERE NAME = 'Trainingprogram')
                        BEGIN 
                            CREATE TABLE Trainingprogram (
                               TrainingId UNIQUEIDENTIFIER PRIMARY KEY,
                                          
                                            MemberId UNIQUEIDENTIFIER  NOT NULL,
                                Cardio NVARCHAR(250) NOT NULL,
                                Weighttraining NVARCHAR(25) NOT NULL,
                                
                               
                           
                              );
                        END
                    ";
                createTableCommand.ExecuteNonQuery();
            }
        }
    }
}

//CONSTRAINT FK_Pendingedits_MemberId FOREIGN KEY (MemberId) REFERENCES Members(MemberId),

