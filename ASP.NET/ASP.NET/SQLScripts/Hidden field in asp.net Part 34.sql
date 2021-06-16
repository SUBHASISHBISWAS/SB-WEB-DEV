Create Table tblEmployees
(
 Id int Primary Key,
 Name nvarchar(50),
 Gender nvarchar(10),
 DeptName nvarchar(10)
)

Insert into tblEmployees values(201, 'Mark', 'Male', 'IT')
Insert into tblEmployees values(202, 'Steve', 'Male', 'Payroll')
Insert into tblEmployees values(203, 'John', 'Male', 'HR') 


Select Id, Name, Gender, DeptName from tblEmployees