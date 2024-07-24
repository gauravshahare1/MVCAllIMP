create database ValidationDB
go
use ValidationDB
go
Create table Student
(
RollNumber int primary key identity,
Name varchar(50),
Gender varchar(10),
Mobile char(10),
Email varchar(100),
Age int
)

insert into Student values('Vishal','Male','9595164928','g@g.com',27)
go
Create Proc usp_AllStudents
as
begin
	Select RollNumber, Name, Gender, Mobile,Email, Age from Student
end
go
Create Proc usp_InsertStudent
@Name varchar(50),@Gender varchar(10),@Mobile char(10),@Email varchar(100),@Age int,
@Status bit output
as
begin
	begin try
	if not exists (select Rollnumber from Student where Mobile = @Mobile or Email= @Email)
	begin
	insert into Student values(@Name, @Gender, @Mobile, @Email, @Age)
	set @status = 1
	end 
	else
	begin
		set @Status=0
	end
	end try

	begin catch
	set @Status =0
	end catch
End

go
Create Proc usp_UpdateStudent
@Name varchar(50),@Gender varchar(10),@Mobile char(10),@Email varchar(100),@Age int,
@Status bit output, @RollNumber int
as
begin
	begin try
	if  exists (select Rollnumber from Student where RollNumber=@RollNumber)
	begin
	Update Student 
		set Name= @Name, Gender= @Gender, Mobile=@Mobile, Email= @Email, Age= @Age
		Where RollNumber=@RollNumber
	set @status = 1
	end 
	else
	begin
		set @Status=0
	end
	end try

	begin catch
	set @Status =0
	end catch
End
go
alter Proc usp_DeleteStudent
@Status bit output, @RollNumber int
as
begin
	begin try
	begin transaction 
	if  exists (select Rollnumber from Student where RollNumber=@RollNumber)
	begin
	Delete from Student where RollNumber= @RollNumber
	set @status = 1
	end 
	else
	begin
		set @Status=0
	end
	commit
	end try

	begin catch
 
	set @Status =0
	rollback
	end catch
End
go
Create Proc usp_StudentByRollnumber
@RollNumber int 
as
begin
	Select RollNumber, Name, Gender, Mobile,Email, Age from Student 
	where RollNumber= @RollNumber
end


Select * from Student

alter table student 
add Password varchar(30)

alter table student 
add AdmissionDate date


alter Proc usp_InsertStudent
@Name varchar(50),@Gender varchar(10),@Mobile char(10),@Email varchar(100),@Age int,
@Password varchar(30), @AdmissionDate date, @Status bit output
as
begin
	begin try
	if not exists (select Rollnumber from Student where Mobile = @Mobile or Email= @Email)
	begin
	insert into Student values(@Name, @Gender, @Mobile, @Email, @Age, @Password, @AdmissionDate)
	set @status = 1
	end 
	else
	begin
		set @Status=0
	end
	end try

	begin catch
	set @Status =0
	end catch
End


Alter Proc usp_AllStudents
as
begin
	Select RollNumber, Name, Gender, Mobile,Email, Age, Password, AdmissionDate  from Student
end