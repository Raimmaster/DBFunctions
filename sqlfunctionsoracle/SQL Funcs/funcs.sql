SELECT DEC2BIN(16) from DUAL;--1
SELECT DEC2BIN(26) from DUAL;--2
SELECT REPEAT('hola', 5) from DUAL;--3
SELECT F2C(80.5) FROM DUAL;--4
SELECT C2F(30.5) FROM DUAL;--5
SELECT TRIM2('aaaaaahola vosaaaaa', 'a') FROM DUAL;--6
SELECT Factorial(6) FROM DUAL;--7
SELECT DEC2HEX(46) FROM DUAL;--8
SELECT HEX2DEC('AF') FROM DUAL;--9
SELECT COMPARE('yaa', 'heyyy') FROM DUAL;--10
SELECT PMT(0.05, 12, 5000) FROM DUAL;--11
SELECT PING ('google.com') FROM DUAL;--12
--show error function BIN2DEC;
begin
dbms_java.grant_permission( 'SYSTEM', 'SYS:java.net.SocketPermission', 'google.com', 'resolve' );
dbms_java.grant_permission( 'SYSTEM', 'SYS:java.net.SocketPermission', '172.217.8.78:80', 'connect,resolve' );
end;

--DEFS
--public static String COMPARE(String str1, String str2)
    
create or replace 
function  COMPARE(str1 VARCHAR2, str2 VARCHAR2) return VARCHAR2 as language java
name 'SQLFunctionsOracle.COMPARE(java.lang.String, java.lang.String) return java.lang.String';

--public static double PMT(double tasa, int numPeriodos, double prestamo){
    
create or replace 
function  PING(host VARCHAR2) return NUMBER as language java
name 'SQLFunctionsOracle.PING(java.lang.String) return int';

create or replace 
function  DEC2HEX(binary number) return nvarchar2 as language java
name 'SQLFunctionsOracle.DEC2HEX(int) return java.lang.String';
