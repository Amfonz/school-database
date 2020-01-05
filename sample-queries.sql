USE SCHOOL
/*

*/

/* Students */

/*  Find all students whose last name starts with a vowel        */
SELECT * FROM STUDENTS WHERE SUBSTRING(LAST_NAME,1,1) IN ('A','E','I','O','U');

SELECT * FROM STUDENTS WHERE LAST_NAME LIKE '[AEIOU]%';

/* Find all students whose first name has the ael or iel suffix */
SELECT *  FROM STUDENTS WHERE RIGHT(FIRST_NAME,3) LIKE 'ael' OR RIGHT(FIRST_NAME,3) LIKE 'iel';

/* QUERY  THE OLDEST STUDENT 
  note depending on the year in the record generator the ages might appear strange (too young, old etc) adjust if it matters to you.
*/
/* OLDEST STUDENT WITH AGE*/
 SELECT top 1 id,FIRST_NAME,LAST_NAME, DATEDIFF(DAY,DATE_OF_BIRTH,CURRENT_TIMESTAMP)/365 AS YEARS, DATEDIFF(DAY,DATE_OF_BIRTH,CURRENT_TIMESTAMP) % 365 AS DAYS 
 FROM STUDENTS 
 order by YEARS DESC, DAYS DESC;


 /*     add 14 years to the ages of all students            */
 UPDATE STUDENTS SET DATE_OF_BIRTH = DATEADD(YEAR,-14,DATE_OF_BIRTH);

/* Pivot the table and get a count for the number of students born in each month. Month abbreviation should be the column name*/


/* NON PIVOTED VERSION */
SELECT 
CASE
  WHEN MONTH(DATE_OF_BIRTH) = 1 THEN 'JAN'
  WHEN MONTH(DATE_OF_BIRTH) = 2 THEN 'FEB'
  WHEN MONTH(DATE_OF_BIRTH) = 3 THEN 'MAR'
  WHEN MONTH(DATE_OF_BIRTH) = 4 THEN 'APR'
  WHEN MONTH(DATE_OF_BIRTH) = 5 THEN 'MAY'
  WHEN MONTH(DATE_OF_BIRTH) = 6 THEN 'JUN'
  WHEN MONTH(DATE_OF_BIRTH) = 7 THEN 'JLY'
  WHEN MONTH(DATE_OF_BIRTH) = 8 THEN 'AUG'
  WHEN MONTH(DATE_OF_BIRTH) = 9 THEN 'SEPT'
  WHEN MONTH(DATE_OF_BIRTH) = 10 THEN 'OCT'
  WHEN MONTH(DATE_OF_BIRTH) = 11 THEN 'NOV'
  ELSE 'DEC'
END AS Month, COUNT(*) FROM STUDENTS GROUP BY Month(DATE_OF_BIRTH);


/* LOCKERS */

/* GET STUDENT 45'S LOCKER COMBINATION, RETURN IT AS A SINGLE STRING  FORMAT WITH '-' BETWEEN EACH NUMBER*/

SELECT 
CAST(LOCKERS.COMBINATION_1 AS VARCHAR) + '-' + CAST(LOCKERS.COMBINATION_2 AS VARCHAR) + '-' + CAST(LOCKERS.COMBINATION_3 AS VARCHAR)  
FROM LOCKERS JOIN STUDENTS ON STUDENTS.LOCKER_NUMBER = LOCKERS.LOCKER_NUMBER WHERE STUDENTS.ID = 45;

/* Students might be sharing a locker find the locker with the most students occupying it   */

SELECT TOP 1 LOCKER_NUMBER, COUNT(*) AS OCCUPANTS FROM STUDENTS GROUP BY LOCKER_NUMBER ORDER BY OCCUPANTS DESC;

/* RETURN A LIST OF LOCKERS THAT ARE NOT OCCUPIED */

SELECT LOCKERS.LOCKER_NUMBER as Not_Occupied FROM LOCKERS LEFT JOIN STUDENTS ON STUDENTS.LOCKER_NUMBER = LOCKERS.LOCKER_NUMBER WHERE STUDENTS.ID IS NULL;

/* SHOW A COUNT OF HOW MANY LOCKERS ARE BEING USED BY MORE THAN 1 PERSON */
SELECT COUNT(SUB.C) AS LOCKERS_SHARED FROM (SELECT LOCKER_NUMBER, COUNT(*) AS C FROM STUDENTS GROUP BY LOCKER_NUMBER HAVING COUNT(*) > 1) AS SUB;


/*  find the total spending of each department  */
select department_name, sum(spending) as spending from (select teachers.id as id,round(sum(staff_purchase.amount * staff_purchase.price),2) as spending from teachers join staff_purchase on teachers.id = staff_purchase.id group by teachers.id) as sub join department_staff on department_staff.id = sub.id group by department_name order by spending desc;


/* find the total spending of each staff member  if they did not spend return 0 instead of null */

 select teachers.id, (teachers.FIRST_NAME + ' ' + teachers.LAST_NAME) as Teacher_Name,
 case 
 when round(sum(staff_purchase.amount * staff_purchase.price),2) is null then 0 else round(sum(staff_purchase.amount * staff_purchase.price),2) 
 end as spending 
 from staff_purchase right join teachers on teachers.id = staff_purchase.id group by teachers.id, teachers.FIRST_NAME, teachers.LAST_NAME;

 /*   FIND DEPARTMENT WITH HIGHEST AVG SALARY               */
SELECT top 1 department_name, avg(salary) FROM TEACHERS JOIN DEPARTMENT_STAFF ON TEACHERS.ID = DEPARTMENT_STAFF.ID group by department_name order by avg(salary) desc


/*                        
  Your a rookie if you've been at the school less than 3 years
  a veteran if > 2 years but < 7
  a journey man for 7+
  categorize the teachers
*/

SELECT
CASE
WHEN DATEDIFF(YEAR,EMPLOYMENT_START,CURRENT_TIMESTAMP) < 3 then 'Rookie'
WHEN DATEDIFF(YEAR,EMPLOYMENT_START,CURRENT_TIMESTAMP) >= 3 AND DATEDIFF(YEAR,EMPLOYMENT_START,CURRENT_TIMESTAMP) < 7 then 'Veteran'
Else 'Journeyman'
End as categorization from Teachers;
