
select EmpLname + ' ' +  EmpFname as 'Employee Name' , salary from employee;

select * from employee where commission is null;

select EmpFname, EmpLname, salary from employee where EmpId=137; --initial
update employee set salary=salary*1.10 where EmpId=137;
select EmpFname, EmpLname, salary from employee where EmpId=137; --updated

select EmpFname, EmpLname, isnull(commission,0) from employee ;

select count(*) as 'Count of Employees' from employee;

select count(distinct relation) from dependent;

select EmpLname, EmpFname, FORMAT(hiredate, 'dd MMM yyyy')  from employee; --hiredate format 'dd mmm yyyy'

select FORMAT(hiredate, 'dd/MM/yyyy') from employee;

select round(avg(datediff(day,hiredate,getdate())/365),1) as 'Avg Year',  --employment years for employees
       round(max(datediff(day,hiredate,getdate())/365),1) as 'Max Year',
       round(min(datediff(day,hiredate,getdate())/365),1) as 'Min Year' from employee;

select EmpId, count(*) as 'Has Dependent' from dependent group by EmpId having count(*)>=2  ; --employees has more then 2 dependent

select avg(commission) from employee;
select avg(isnull(commission,0)) from employee;

select sum(salary) as 'Total Salary', dept_Id, PositionId from employee group by dept_Id, PositionId; --sum of the salarys of employees who works on the same department and position

select dept_Id, count(EmpId) as 'Employee Count' from employee group by dept_Id;

select avg(salary), dept_Id from employee group by dept_Id having avg(salary)>22000;

select EmpLname, EmpFname, case
when salary>100000 then 'HIGH'
when salary>50000 then 'MEDIUM'
else 'LOW'
end "Salary Message" from employee;

select EmpLname, EmpFname, dept_Name from employee e, department d where e.dept_Id=d.dept_Id; 

select e.EmpFname+ ' ' +e.EmpLname as 'Employee Name', s.EmpFname+ ' ' +s.EmpLname as 'Supervisor Name' from employee e, employee s where e.supervisor=s.EmpId and e.EmpId=453;

select e.EmpLname+' '+e.EmpFname as 'Employee Name', 
       e.salary 'Employee Salary', 
	   s.EmpLname+' '+s.EmpFname as 'Supervisor Name', 
	   s.salary as 'Supervisor Salary' 
from employee e, employee s where e.supervisor=s.EmpId;

select EmpLname, EmpFname, salary, levelNo from employee, emplevel where salary between lowsalary and highsalary; --emplevel

select EmpLname, EmpFname, dept_Name, position_Desc, qual_Desc 
from employee e, department d, position p, qualification q 
where e.dept_Id=d.dept_Id and e.PositionId=p.PositionId and e.qual_Id=q.qual_Id;

select EmpLname, EmpFname, dept_Id, depDOB, relation  --normal
from employee e, dependent d where e.EmpId=d.EmpId;

select EmpLname, EmpFname, dept_Id, depDOB, relation -- with left outer join
from employee e left outer join dependent d
on e.EmpId=d.EmpId;

select EmpLname, EmpFname, dept_Name, round(datediff(day,hiredate,getdate())/365,1) YEARS 
from employee e, department d where e.dept_Id=d.dept_Id order by YEARS desc;

select e.EmpLname, e.EmpFname, q.qual_Desc 
from employee e, position p, qualification q 
where p.PositionId=e.PositionId and e.qual_Id=q.qual_Id and p.position_Desc='DEVELOPER';

select sum(salary) from employee e, qualification q                         --total salaries of employees who have 'BACHELORS' qualification
where e.qual_Id = q.qual_Id and q.qual_Desc = 'BACHELORS';


select dept_Name from employee e, department d where e.dept_Id=d.dept_Id and EmpLname='SNOW' and EmpFname='John';
select dept_Name from department where dept_Id=(select dept_Id from employee where EmpLname='SNOW' and EmpFname='John');

select EmpLname, EmpFname from employee where EmpId=(select supervisor from employee where EmpId=453);

select EmpLname, EmpFname from employee where qual_Id=(select qual_Id from employee where EmpLname='Snow' and EmpFname='John');


EXEC sp_rename 'department.Manager EmpId', 'Manager', 'COLUMN';

select EmpId, EmpFname, EmpLname, e.dept_Id, dept_Name
                          from employee e 
                          inner join department d on e.dept_Id=d.dept_Id;

select distinct Salary from Employee e1 where 2=(select count(distinct Salary) from Employee e2 where e1.salary<=e2.salary);
