/*
 max-salary = Find max salary
 select max salary where salary != max-salary

*/
SELECT Max(salary) AS SecondHighestSalary
FROM   employee
WHERE  salary <> (SELECT Max(salary)
                  FROM   employee) 