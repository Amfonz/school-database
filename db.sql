USE master
GO
CREATE DATABASE school
GO
USE school
GO
CREATE TABLE STUDENT (
  ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  FIRST_NAME VARCHAR(50) NOT NULL,
  LAST_NAME VARCHAR(50) NOT NULL,
  DATE_OF_BIRTH DATE NOT NULL,
  LOCKER_NUM INT
);

CREATE TABLE TEACHER (
  ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  FIRST_NAME VARCHAR(50) NOT NULL,
  LAST_NAME VARCHAR(50) NOT NULL,
  SALARY INT,
  EMPLOYMENT_START DATE NOT NULL
);

CREATE TABLE DEPARTMENT_STAFF (
  DEPT_NAME VARCHAR(20) NOT NULL PRIMARY KEY,
  ID INT NOT NULL FOREIGN KEY REFERENCES TEACHER(ID)
);

CREATE TABLE LOCKER (
  LOCKER_NUMBER INT NOT NULL PRIMARY KEY,
  COMBINATION_1 INT NOT NULL,
  COMBINATION_2 INT NOT NULL,
  COMBINATION_3 INT NOT NULL,
  ID INT NOT NULL FOREIGN KEY REFERENCES STUDENT(ID)
);
