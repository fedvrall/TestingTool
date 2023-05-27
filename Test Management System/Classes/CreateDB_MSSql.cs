using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Management_System.Classes
{
    internal class CreateDB_MSSql
    {
        public string connString { get; set; }
        public SqlConnection conn { get; set; }

        public string name { get; set; }

        public CreateDB_MSSql()
        {
            connString = @"Data Source=FEDVRALL-DESKTO\SQLEXPRESS; Initial Catalog=Testing_Tool;  Integrated Security=True";
            conn = new SqlConnection(connString);
            name = "Testing_Tool";
        }

        public void CreateOnlyDB()
        {
            conn.Open();
            /*            string creatingDB = "CREATE DATABASE " + name + " ;";
                        SqlCommand cmd = new SqlCommand(creatingDB, conn);
                        cmd.ExecuteNonQuery();*/
        }

        public void CreateReferenceTablesInDB()
        {
            // Таблица стран
            string createCountryTable = "use " + name + "; create table Country(" +
                "CountryID int identity (1, 1) primary key, " +
                "CountryName nvarchar(50) not null, " +
                "CountryNameTranslation nvarchar(50) not null); ";
            SqlCommand CreateCountryTable = new SqlCommand(createCountryTable, conn);
            CreateCountryTable.ExecuteNonQuery();

            // Таблица вариантов количества пользователей в команде
            string createAmountOfUsersTable = "use " + name + "; create table AmountOfUsers(" +
                "AmountID int identity (1, 1) primary key, " +
                "AmountLowerBound int not null, " +
                "AmountUpperBound int not null); ";
            SqlCommand CreateAmountOfUsersTable = new SqlCommand(createAmountOfUsersTable, conn);
            CreateAmountOfUsersTable.ExecuteNonQuery();

            // Таблица ролей
            string createRoleTable = "use " + name + "; create table Role(" +
                "RoleID int identity (1, 1) primary key, " +
                "RoleName nvarchar(30) not null, " +
                "RoleNameTranslation nvarchar(30) not null); ";
            SqlCommand CreateRoleTable = new SqlCommand(createRoleTable, conn);
            CreateRoleTable.ExecuteNonQuery();

            // Таблица критичности бага
            string createBugSeverityTable = "use " + name + "; create table BugSeverity " +
                "(BugSeverityID int identity (1, 1) primary key, " +
                "BugSeverityName nvarchar(20) not null, " +
                "BugSeverityNameTranslation nvarchar(20) not null);";
            SqlCommand СreateBRSeverityTable = new SqlCommand(createBugSeverityTable, conn);
            СreateBRSeverityTable.ExecuteNonQuery();

            // Приоритет бага
            string createBugPriorityTable = "use " + name + "; create table BugPriority " +
                "(BugPriorityID int identity (1, 1) primary key, " +
                "BugPriorityName nvarchar(20) not null," +
                "BugPriorityNameTranslation nvarchar(20) not null);";
            SqlCommand СreateBRPriorityTable = new SqlCommand(createBugPriorityTable, conn);
            СreateBRPriorityTable.ExecuteNonQuery();

            // Статус баг-репорта
            string createBRStatusTable = "use " + name + "; create table BugReportStatus " +
                "(BRStatusID int identity (1, 1) primary key, " +
                "BRStatusName nvarchar(20) not null," +
                "BRStatusNameTranslation nvarchar(20) not null); ";
            SqlCommand СreateBRStatusTable = new SqlCommand(createBRStatusTable, conn);
            СreateBRStatusTable.ExecuteNonQuery();

            // Статус чек-листа
            string createCLStatusTable = "use " + name + "; create table CheckListStatus " +
               "(CLStatusID int identity (1, 1) primary key, " +
               "CLStatusDescription nvarchar(20) not null," +
               "CLStatusDescriptionTranslation nvarchar(20) not null); ";
            SqlCommand СreateCLStatusTable = new SqlCommand(createCLStatusTable, conn);
            СreateCLStatusTable.ExecuteNonQuery();

            // Приоритет чек-листа
            string createCLPriorityTable = "use " + name + "; create table CheckListPriority " +
               "(CLPriorityID int identity (1, 1) primary key, " +
               "CLPriorityDescription nvarchar(20) not null," +
               "CLPriorityDescriptionTranslation nvarchar(20) not null); ";
            SqlCommand CreateCLPriorityTable = new SqlCommand(createCLPriorityTable, conn);
            CreateCLPriorityTable.ExecuteNonQuery();

            // Приоритет тест-кейсов
            string createTCPriorityTable = " use " + name + "; create table TestCasePriority " +
                "(TCPriorityID int identity (1, 1) primary key, " +
                "TCPriorityDescription nvarchar(20) not null, " +
                "TCPriorityDescriptionTranslation nvarchar(20) not null); ";
            SqlCommand СreateTCPriorityTable = new SqlCommand(createTCPriorityTable, conn);
            СreateTCPriorityTable.ExecuteNonQuery();

            // Критичность тест-кейсов
            string createTCSeverityTable = " use " + name + "; create table TestCaseSeverity " +
                "(TCSeverityID int identity (1, 1) primary key, " +
                "TCSeverityDescription nvarchar(20) not null, " +
                "TCSeverityDescriptionTranslation nvarchar(20) not null); ";
            SqlCommand СreateTCSeverityTable = new SqlCommand(createTCSeverityTable, conn);
            СreateTCSeverityTable.ExecuteNonQuery();

            // Вид тест-кейсов
            string createTCViewTable = "use " + name + "; create table TestCaseType " +
                "(TCTypeID int identity (1, 1) primary key, " +
                "TCTypeDescription nvarchar(100) not null," +
                "TCTypeDescriptionTranlation nvarchar(100) not null); ";
            SqlCommand CreateTCViewTable = new SqlCommand(createTCViewTable, conn);
            CreateTCViewTable.ExecuteNonQuery();

            // Поведение тест-кейса
            string createTCBehaviorTable = "use " + name + "; create table TestCaseBehavior " +
                "(TCBehaviorID int identity (1, 1) primary key, " +
                "TCBehaviorDescription nvarchar(100) not null," +
                "TCBehaviorDescriptionTranlation nvarchar(100) not null); ";
            SqlCommand CreateTCBehaviorTable = new SqlCommand(createTCBehaviorTable, conn);
            CreateTCBehaviorTable.ExecuteNonQuery();

            //Статус тест-кейса
            string createTCStatusTable = "use " + name + "; create table TestCaseStatus " +
                "(TCStatusID int identity (1, 1) primary key, " +
                "TCStatusDescription nvarchar(100) not null," +
                "TCStatusDescriptionTranlation nvarchar(100) not null); ";
            SqlCommand CreateTCStatusTable = new SqlCommand(createTCStatusTable, conn);
            CreateTCStatusTable.ExecuteNonQuery();
        }

        public void FillReferenceTablesInDB()
        {
            // Заполнение ролей
            string insertIntoRoleTable = " insert into Role values " +
                "('Administrator', 'Администратор')," +
                "('TeamLead', 'Руководитель команды')," +
                "('Tester', 'Тестировщик');";
            SqlCommand InsertIntoRoleTable = new SqlCommand(insertIntoRoleTable, conn);
            InsertIntoRoleTable.ExecuteNonQuery();

            // Заполнение стран
            string insertIntoCountryTable = " insert into Country (CountryName, CountryNameTranslation) values" +
                "('USA', 'США')," +
                "('Canada', 'Канада')," +
                "('Mexico', 'Мексика')," +
                "('Brazil', 'Бразилия')," +
                "('Argentina', 'Аргентина')," +
                "('Germany', 'Германия')," +
                "('France', 'Франция')," +
                "('Spain', 'Испания')," +
                "('Russia', 'Россия')," +
                "('China', 'Китай'); ";
            SqlCommand InsertIntoCountryTable = new SqlCommand(insertIntoCountryTable, conn);
            InsertIntoCountryTable.ExecuteNonQuery();

            // Заполнение критичности БР
            string insertIntoBRSeverityTable = "insert into BugSeverity values " +
                "('Trivial', 'Тривиальный')," +
                "('Minor', 'Незначительный')," +
                "('Major', 'Значительный')," +
                "('Critical', 'Критический')," +
                "('Blocker', 'Блокирующий');";
            SqlCommand InsertIntoBRSeverityTable = new SqlCommand(insertIntoBRSeverityTable, conn);
            InsertIntoBRSeverityTable.ExecuteNonQuery();

            // Заполнение приоритета БР
            string insertIntoBRPriorityTable = "insert into BugPriority values" +
                "('Low', 'Низкий'), " +
                "('Medium', 'Средний'), " +
                "('High', 'Высокий'); ";
            SqlCommand InsertIntoBRPriorityTable = new SqlCommand(insertIntoBRPriorityTable, conn);
            InsertIntoBRPriorityTable.ExecuteNonQuery();

            // Заполнение статуса БР
            string insertIntoBRStatusTable = "insert into BugReportStatus values " +
                "('Open', 'Открыт'), " +
                "('In Progress', 'В работе'), " +
                "('Ready for check', 'Исправлен'), " +
                "('Closed', 'Закрыт'), " +
                "('Rejected', 'Отклонён'), " +
                "('Deferred', 'Отсрочен'), " +
                "( 'Reopened', 'Переоткрыт'); ";
            SqlCommand InsertIntoBDStatusTable = new SqlCommand(insertIntoBRStatusTable, conn);
            InsertIntoBDStatusTable.ExecuteNonQuery();

            // Заполнение статуса чек-листа
            string insertIntoCLStatusTable = "insert into CheckListStatus values " +
                "('Passed', 'Пройден'), " +
                "('Failed', 'Не пройден'), " +
                "('Not run', 'Не запущен'), " + // по умолчанию
                "('Blocked', 'Заблокирован'); ";
            SqlCommand InsertIntoCLStatusTable = new SqlCommand(insertIntoCLStatusTable, conn);
            InsertIntoCLStatusTable.ExecuteNonQuery();

            // Заполнение приоритета чек-листа
            string insertIntoCLPriorityTable = "insert into CheckListPriority values" +
                "('Low', 'Низкий'), " +
                "('Medium', 'Средний'), " +
                "('High', 'Высокий'); ";
            SqlCommand InsertIntoCLPriorityTable = new SqlCommand(insertIntoCLPriorityTable, conn);
            InsertIntoCLPriorityTable.ExecuteNonQuery();

            // Заполнение приоритета тест-кейса
            string insertIntoTCPriorityTable = "insert into TestCasePriority values" +
                "('Low', 'Низкий'), " +
                "('Medium', 'Средний'), " +
                "('High', 'Высокий'); ";
            SqlCommand InsertIntoTCPriorityTable = new SqlCommand(insertIntoTCPriorityTable, conn);
            InsertIntoTCPriorityTable.ExecuteNonQuery();

            // Заполнение критичности тест-кейса
            string insertIntoTCSeverityTable = "insert into TestCaseSeverity values " +
                "('Trivial', 'Тривиальный')," +
                "('Minor', 'Незначительный')," +
                "('Major', 'Значительный')," +
                "('Critical', 'Критический')," +
                "('Blocker', 'Блокирующий');";
            SqlCommand InsertIntoTCSeverityTable = new SqlCommand(insertIntoTCSeverityTable, conn);
            InsertIntoTCSeverityTable.ExecuteNonQuery();

            // Заполнение поведения тест-кейса
            string insertIntoTCBehaviorTable = " insert into TestCaseBehavior values " +
                "('Negative', 'Негативный'), " +
                "('Positive', 'Позитивный'), " +
                "('Destructive', 'Деструктивный'); ";
            SqlCommand InsertIntoTCBehaviorTable = new SqlCommand(insertIntoTCBehaviorTable, conn);
            InsertIntoTCBehaviorTable.ExecuteNonQuery();

            // Заполнение типа тест-кейса
            string insertIntoTCTypeTable = "insert into TestCaseType values " +
                "('Functional', 'Функциональное тестирование')," +
                "('Smoke', 'Дымовое тестирование')," +
                "('Regression', 'Регрессионное тестирование')," +
                "('Security', 'Тестирование безопасности')," +
                "('Usability', 'Тестирование на удобство использования')," +
                "('Performance', 'Тестирование производительности')," +
                "('Acceptance', 'Тестирование на ошибки пользователя')," +
                "('Compatibility', 'Тестирование совместимости')," +
                "('Integration', 'Интеграционное тестирование')," +
                "('Recovery', 'Тестирование восстановления после сбоя')," +
                "('Automated', 'Автоматизированное тестирование')," +
                "('Exploratory', 'Эксплоративное тестирование');";
            SqlCommand InsertIntoTCTypeTable = new SqlCommand(insertIntoTCTypeTable, conn);
            InsertIntoTCTypeTable.ExecuteNonQuery();

            // Заполнение статуса тест-кейса
            string insertIntoTCStatusTable = " insert into TestCaseStatus values " +
                "('Passed', 'Пройден'), " +
                "('Failed', 'Провален'), " +
                "('Blocked', 'Блокирован'), " +
                "('Skipped', 'Пропущен'), " +
                "('Draft', 'Не выполнен'), " +
                "('In progress', 'В тестировании'); ";
            SqlCommand InsertIntoTCStatusTable = new SqlCommand(insertIntoTCStatusTable, conn);
            InsertIntoTCStatusTable.ExecuteNonQuery();
            conn.Close();
        }

        public void CreateMainTablesInDB()
        {
            // Таблица компаний
            string createCompanyTable = "use " + name + "; create table Company(" +
                "CompanyID int identity (1, 1) primary key, " +
                "CompanyName nvarchar(255) not null, " +
                "CompanyLabel nvarchar(10) not null, " +
                "CountryID int not null," +
                "AmountID int not null, " +
                "CONSTRAINT UC_CompanyLabel UNIQUE (CompanyLabel), " +
                "foreign key (CountryID) references Country (CountryID)," +
                "foreign key (AmountID) references AmountOfUsers (AmountID)); ";
            SqlCommand CreateCompanyTable = new SqlCommand(createCompanyTable, conn);
            CreateCompanyTable.ExecuteNonQuery();

            // Таблица пользователей
            string createUserTable = "use " + name + "; create table Userinfo " +
                "(UserID int not null identity (1, 1) primary key, " +
                "FirstName nvarchar(25) not null, " +
                "LastName nvarchar(25) not null, " +
                "Login nvarchar(20) not null, " +
                "Password nvarchar(20) not null, " +
                "RoleID int not null," +
                "CompanyID int not null," +
                "foreign key (RoleID) references Role (RoleID)," +
                "foreign key (CompanyID) references Company (CompanyID)); ";
            SqlCommand CreateUserTable = new SqlCommand(createUserTable, conn);
            CreateUserTable.ExecuteNonQuery();

            // Таблица заказчиков
            string createCustomerTable = "use " + name + "; create table Customer " +
                "(CustomerID int identity (1, 1) primary key, " +
                "CustomerFirstName nvarchar (25) not null, " +
                "CustomerLastName nvarchar (25) not null, " +
                "CustomerPhone nvarchar (20) not null, " +
                "CustomerEmail nvarchar (100) not null, " +
                "CustomerNotes nvarchar (255)); ";
            SqlCommand CreateCustomerTable = new SqlCommand(createCustomerTable, conn);
            CreateCustomerTable.ExecuteNonQuery();

            // Таблица проектов
            string createProjectTable = "use " + name + "; create table Project " +
                "(ProjectID nvarchar (50) not null primary key, " +
                "ProjectName nvarchar (255) not null, " +
                "CompanyID int not null, " +
                "ProjectDateOfCreation date not null, " +
                "ProjectDateOfDeadLine date, " +
                "ProjectNotes nvarchar(500), " +
                "CustomerID int not null, " +
                "foreign key (CustomerID) references Customer (CustomerID)," +
                "foreign key (CompanyID) references Company(CompanyID)); ";
            SqlCommand CreateProjectTable = new SqlCommand(createProjectTable, conn);
            CreateProjectTable.ExecuteNonQuery();

            // Таблица проектной документации
            string createProjectDocumentationTable = "use " + name + "; create table ProjectDocumentation " +
                "(ProjectDocumentationID int identity (1, 1) primary key, " +
                "ProjectID nvarchar (50) not null, " +
                "ProjectDocumentationAttachment nvarchar(500) not null, " +
                "foreign key (ProjectID) references Project(ProjectID)); ";
            SqlCommand CreateProjectDocumentationTable = new SqlCommand(createProjectDocumentationTable, conn);
            CreateProjectDocumentationTable.ExecuteNonQuery();

            // Таблица чек-листов
            string createCheckListTable = "use " + name + "; create table CheckList " +
                "(CheckListID nvarchar (50) not null primary key, " +
                "CLSummary nvarchar (255) not null, " +
                "ProjectID nvarchar (50) not null, " +
                "CLDescription nvarchar (255), " + // Что делает чек-лист
                "CLPersentageOfPassed decimal(3, 2) not null," +
                "foreign key (ProjectID) references Project(ProjectID)); ";
            SqlCommand CreateCheckListTable = new SqlCommand(createCheckListTable, conn);
            CreateCheckListTable.ExecuteNonQuery();

            // Таблица пунктов чек-листа
            string createCheckListItemTable = "use " + name + "; create table CheckListItem " +
                "(CheckListItemID nvarchar (50) not null primary key, " +
                "CheckListItemDescription nvarchar (1000) not null, " +
                "CLStatusID int not null, " +
                "CLComment nvarchar (255) not null, " +
                "CheckListID nvarchar (50) not null, " +
                "CLAttachment nvarchar(255), " +
                "ProjectID nvarchar (50) not null, " +
                "UserID int, " +
                "DataOfExecution date, " +
                "CLPriorityID int, " +
                "foreign key (UserID) references UserInfo(UserID)," +
                "foreign key (ProjectID) references Project(ProjectID)," +
                "foreign key (CLPriorityID) references CheckListPriority(CLPriorityID)," +
                "foreign key (CLStatusID) references CheckListStatus(CLStatusID)," +
                "foreign key (CheckListID) references CheckList(CheckListID)); ";
            SqlCommand CreateCheckListItemTable = new SqlCommand(createCheckListItemTable, conn);
            CreateCheckListItemTable.ExecuteNonQuery();


            // Таблица тест-сьютов
            string createTestSuiteTable = "use " + name + "; create table TestSuite " +
                "(TestSuiteID nvarchar (50) not null primary key, " +
                "TestSuiteSummary nvarchar (255) not null, " +
                "TestSuiteDescription  nvarchar (1000) not null, " +
                "TestSuiteLabel char (3) not null, " +
                "TestSuitePreconditions nvarchar(255), " +
                "TestSuiteParentID nvarchar (50), " +
                "ProjectID nvarchar (50) not null, " +
                "unique (TestSuiteLabel)," +
                "foreign key (ProjectID) references Project(ProjectID)," +
                "foreign key (TestSuiteParentID) references TestSuite(TestSuiteID)); ";
            SqlCommand CreateTestSuiteTable = new SqlCommand(createTestSuiteTable, conn);
            CreateTestSuiteTable.ExecuteNonQuery();


            //Таблица тест-кейсов
            string createTestCaseTable = "use " + name + "; create table TestCase " + // создание таблицы чек-листов
                "(TestCaseID nvarchar (50) not null primary key, " +
                "TestCaseSummary nvarchar (255) not null, " +
                "TestCaseDescription nvarchar(1000), " +
                "TestCaseSteps nvarchar (255) not null, " +
                "TestCaseExpectedResult nvarchar(255) not null, " +
                "TestCaseActualResult nvarchar(255) not null, " +
                "TCStatusID int not null, " +
                "TestCaseTestData nvarchar(255) not null, " +
                "TestSuiteID nvarchar (50) not null, " +
                "CreatorUserID int not null, " +
                "TestCaseCreationDate date not null, " +
                "ExecutorUserID int not null, " +
                "TestCaseExecutionDate date not null," +
                "TestCaseEnvironment nvarchar(255) not null, " +
                "TCTypeID int, " +
                "TCBehaviorID int, " +
                "TCPriorityID int, " +
                "TCSeverityID int, " +
                "ProjectID nvarchar (50) not null, " +
                "TestCaseAttachment nvarchar(255), " +
                "TestCasePrecondition nvarchar (255), " +
                "TestCasePostcondition nvarchar (255), " +
                "foreign key (ProjectID) references Project(ProjectID)," +
                "foreign key (TestSuiteID) references TestSuite(TestSuiteID), " +
                "foreign key (CreatorUserID) references Userinfo(UserID), " +
                "foreign key (ExecutorUserID) references Userinfo(UserID), " +
                "foreign key (TCStatusID) references TestCaseStatus(TCStatusID), " +
                "foreign key (TCTypeID) references TestCaseType(TCTypeID), " +
                "foreign key (TCBehaviorID) references TestCaseBehavior(TCBehaviorID), " +
                "foreign key (TCPriorityID) references TestCasePriority(TCPriorityID), " +
                "foreign key (TCSeverityID) references TestCaseSeverity(TCSeverityID)); ";
            SqlCommand CreateTestCaseTable = new SqlCommand(createTestCaseTable, conn);
            CreateTestCaseTable.ExecuteNonQuery();

            // Таблица баг-репортов
            string createBRTable = "use " + name + "; create table BugReport " + // таблица баг-репортов
               "(BugReportID nvarchar (50) not null primary key, " +
               "BugReportSummary nvarchar(255) not null," +
               "BugEnvironment nvarchar(255) not null, " +
               "BugSteps text not null, " +
               "BugExpectedResult text not null, " +
               "BugActualResult text not null, " + // Остальные поля по выбору
               "BugPreconditions nvarchar(255), " +
               "BugTestData nvarchar(255), " +
               "BugAttachment nvarchar(255), " +

               "BugSeverityID int, " +
               "BugPriorityID int, " +
               "BRStatusID int, " +
               "ProjectID nvarchar (50) not null, " +
               "UserID int not null, " +

               "DateOfCreation date not null, " +
               "BugReportRemark text, " +
               "BugComponentOfSW nvarchar(255) , " +
               "BugVersionOfSW nvarchar(100) , " +
               "TestCaseID nvarchar(50), " + // Ссылка на тест-кейс, если баг был найден во время тестирования
                                             //"VersionID int, " + позже создадим таблицу внутри проекта с номерами версий. А пока что без неё
                                             // Версия, в которой баг был исправлен
               "foreign key (UserID) references Userinfo(UserID)," +
               "foreign key (TestCaseID) references TestCase(TestCaseID)," +
               "foreign key (ProjectID) references Project(ProjectID)," +
               "foreign key (BugSeverityID) references BugSeverity(BugSeverityID)," +
               "foreign key (BugPriorityID) references BugPriority(BugPriorityID)," +
               "foreign key (BRStatusID) references BugReportStatus(BRStatusID)) ;";
            SqlCommand createNewBRTable = new SqlCommand(createBRTable, conn);
            createNewBRTable.ExecuteNonQuery();

        }
    }
}
