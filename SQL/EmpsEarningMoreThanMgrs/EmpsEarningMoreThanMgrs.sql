/* Write your T-SQL query statement below */

/*
+----+-------+--------+-----------+      +----+-------+--------+-----------+   
| Id | Name  | Salary | ManagerId |      | Id | Name  | Salary | ManagerId |
+----+-------+--------+-----------+      +----+-------+--------+-----------+
| 1  | Joe   | 70000  | 3         |      | 3  | Sam   | 60000  | NULL      |
| 2  | Henry | 80000  | 4         |      | 4  | Max   | 90000  | NULL      |
| 3  | Sam   | 60000  | NULL      |      
| 4  | Max   | 90000  | NULL      |      
+----+-------+--------+-----------+      +----+-------+--------+-----------+

 
 */
 
SELECT emp.NAME AS Employee
FROM   employee emp
       INNER JOIN employee mgr
               ON ( emp.managerid = mgr.id
                    AND emp.salary > mgr.salary ) 
