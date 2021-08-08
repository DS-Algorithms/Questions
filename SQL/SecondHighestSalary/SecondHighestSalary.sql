/*
 max-salary = Find max salary
 select max salary where salary != max-salary

*/
Select max(salary) from employee where salary <(
select Max(Salary)
From Employee)
