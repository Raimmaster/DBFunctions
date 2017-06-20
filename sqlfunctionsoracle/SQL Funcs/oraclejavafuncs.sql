--------------------------------------------------------
-- Archivo creado  - martes-junio-20-2017   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Function DEC2HEX
--------------------------------------------------------

  CREATE OR REPLACE NONEDITIONABLE FUNCTION "SYSTEM"."DEC2HEX" (binary number) return nvarchar2 as language java
name 'SQLFunctionsOracle.DEC2HEX(int) return java.lang.String';

/
--------------------------------------------------------
--  DDL for Function COMPARE
--------------------------------------------------------

  CREATE OR REPLACE NONEDITIONABLE FUNCTION "SYSTEM"."COMPARE" (str1 VARCHAR2, str2 VARCHAR2) return VARCHAR2 as language java
name 'SQLFunctionsOracle.COMPARE(java.lang.String, java.lang.String) return java.lang.String';

/
--------------------------------------------------------
--  DDL for Function C2F
--------------------------------------------------------

  CREATE OR REPLACE NONEDITIONABLE FUNCTION "SYSTEM"."C2F" (binary number) return NUMBER as language java
name 'SQLFunctionsOracle.C2F(double) return double';

/
--------------------------------------------------------
--  DDL for Function PING
--------------------------------------------------------

  CREATE OR REPLACE NONEDITIONABLE FUNCTION "SYSTEM"."PING" (host VARCHAR2) return NUMBER as language java
name 'SQLFunctionsOracle.PING(java.lang.String) return int';

/
--------------------------------------------------------
--  DDL for Function REPEAT
--------------------------------------------------------

  CREATE OR REPLACE NONEDITIONABLE FUNCTION "SYSTEM"."REPEAT" (str VARCHAR2, toRepeat number) return varchar2 as language java
name 'SQLFunctionsOracle.REPEAT(java.lang.String, int) return java.lang.String';

/
--------------------------------------------------------
--  DDL for Function BIN2DEC
--------------------------------------------------------

  CREATE OR REPLACE NONEDITIONABLE FUNCTION "SYSTEM"."BIN2DEC" (binary nvarchar2) return number as language java
name 'SQLFunctionsOracle.BIN2DEC(java.lang.String) return java.lang.Integer';

/
--------------------------------------------------------
--  DDL for Function PMT
--------------------------------------------------------

  CREATE OR REPLACE NONEDITIONABLE FUNCTION "SYSTEM"."PMT" (tasa number, periodos number, prestamo number) return NUMBER as language java
name 'SQLFunctionsOracle.PMT(double, int, double) return double';

/
--------------------------------------------------------
--  DDL for Function FACTORIAL
--------------------------------------------------------

  CREATE OR REPLACE NONEDITIONABLE FUNCTION "SYSTEM"."FACTORIAL" (num number) return NUMBER as language java
name 'SQLFunctionsOracle.Factorial(int) return int';

/
--------------------------------------------------------
--  DDL for Function HEX2DEC
--------------------------------------------------------

  CREATE OR REPLACE NONEDITIONABLE FUNCTION "SYSTEM"."HEX2DEC" (num VARCHAR2) return NUMBER as language java
name 'SQLFunctionsOracle.HEX2DEC(java.lang.String) return int';

/
--------------------------------------------------------
--  DDL for Function F2C
--------------------------------------------------------

  CREATE OR REPLACE NONEDITIONABLE FUNCTION "SYSTEM"."F2C" (binary number) return number as language java
name 'SQLFunctionsOracle.F2C(double) return double';

/
--------------------------------------------------------
--  DDL for Function TRIM2
--------------------------------------------------------

  CREATE OR REPLACE NONEDITIONABLE FUNCTION "SYSTEM"."TRIM2" (str VARCHAR2, str2 VARCHAR2) return nvarchar2 as language java
name 'SQLFunctionsOracle.trim2(java.lang.String, java.lang.String) return java.lang.String';

/
--------------------------------------------------------
--  DDL for Function DEC2BIN
--------------------------------------------------------

  CREATE OR REPLACE NONEDITIONABLE FUNCTION "SYSTEM"."DEC2BIN" (num number) return varchar2 as language java
name 'SQLFunctionsOracle.DEC2BIN(int) return java.lang.String';

/
