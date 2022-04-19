# DunAndBradTest
Home Assignment - .Net Developer 

## Description
-Create a server-side with API proxy with three methods which can: GET results. <br />
-Server-side should be built in a layered structure and result from Data-Base should be via Stored Procedure.<br />
-GET should return a JSON response with an array of objects.


## Installation
-Download the project from: https://github.com/alonakeren/DunAndBradTest <br />
-Use SQLQuerySP.sql file to create stored procedures in your DB. 

## Usage 

-The first method should accept parameter (year) and return The AGENT_CODE who has the highest sum of ADVANCE_AMOUNT in the first quarter of the specific year sent in the parameter

WebApi: <br />
http://localhost:53955/orders/2021

The result is: <br />
[
  {
    "AGENT_CODE": "A004  ",
    "SUM_ADVANCE_AMOUNT": 1700.0
  }
]

-The second method should accept two parameters first is a list (list of AGENT_CODE) and the second is int. 
The method should return a list of agents with order (ORD_NUM, ORD_AMOUNT, ADVANCE_AMOUNT, ORD_DATE, CUST_CODE, AGENT_CODE, ORD_DESCRIPTION).
Only One order for an agent. 

WebApi: <br />
http://localhost:53955/orders/A004,A008/2

The result is: <br />
[
  {
    "ORD_NUM": 201013,
    "ORD_AMOUNT": 300.0,
    "ADVANCE_AMOUNT": 200.0,
    "ORD_DATE": "2020-10-02T00:00:00",
    "CUST_CODE": "C00023",
    "AGENT_CODE": "A004  ",
    "ORD_DESCRIPTION": "ADR"
  },
  {
    "ORD_NUM": 200101,
    "ORD_AMOUNT": 3000.0,
    "ADVANCE_AMOUNT": 1000.0,
    "ORD_DATE": "2021-07-15T00:00:00",
    "CUST_CODE": "C00001",
    "AGENT_CODE": "A008  ",
    "ORD_DESCRIPTION": "ADR"
  }
]

-The third method should accept two parameters first is a number and the Second is a year. 
The method should return a list of agents (AGENT_CODE, AGENT_NAME, PHONE_NO) that have more or equal of orders 
compared to the number in the first value, in the year given in the second value.

WebApi: <br />
http://localhost:53955/agents/3/2021

The result is: <br />
[
  {
    "AGENT_CODE": "A002  ",
    "AGENT_NAME": "Mukesh                                  ",
    "PHONE_NO": "029-12358964   "
  },
  {
    "AGENT_CODE": "A004  ",
    "AGENT_NAME": "Ivan                                    ",
    "PHONE_NO": "008-22544166   "
  },
  {
    "AGENT_CODE": "A005  ",
    "AGENT_NAME": "Anderson                                ",
    "PHONE_NO": "045-21447739   "
  },
  {
    "AGENT_CODE": "A008  ",
    "AGENT_NAME": "Alford                                  ",
    "PHONE_NO": "044-25874365   "
  }
]



