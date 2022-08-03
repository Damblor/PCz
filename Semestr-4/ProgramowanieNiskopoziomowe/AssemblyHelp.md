# Windows x64 calling convention

## Parameters
First four parameters are passed in registers:
| |integer or ptr to object that cannot fit in register|floating-point|
|--|--|--|
|1.|RCX|XMM0|
|2.|RDX|XMM1|
|3.|R8|XMM2|
|4.|R9|XMM3|

#### Example: 
  ```cpp
  void test(int, float, int, float)
  ```
  |Parameter|Location|
  |--|--|
  |1.|RCX|
  |2.|XMM1|
  |3.|R8|
  |4.|XMM3|

And rest on stack in reverse order
| |mem operand|if type size <= 8Bytes|if type size > 8Bytes|
|--|--|--|--|
|5.|[RBP + 16]|value|pointer to value|
|6.|[RBP + 24]|value|pointer to value|
|7.|[RBP + 32]|value|pointer to value|
|8..|...|value|pointer to value|

#### Example: 
  ```cpp 
  void test(int, float, int, float, int, float) 
  ```
  |Parameter|Location|
  |--|--|
  |1.|RCX|
  |2.|XMM1|
  |3.|R8|
  |4.|XMM3|
  |5.|[RBP + 16]|
  |6.|[RBP + 24]|

## Return value
|Return type|Return location|
|--|--|
|integer|RAX|
|floating-point|XMM0|
|type with size > 8Bytes|Caller needs to provide pointer to location where value should be returned as first parameter|

#### Example: 
  ```cpp
  struct A { int64_t a, b; };
  A test(float, int);
  ```
  |Parameter|Location|
  |--|--|
  |1.|RCX = points to location where function should return value|
  |2.|XMM1|
  |3.|R8|

## Object functions
  Caller must provide pointer to `this` object as first parameter, even before return pointer (if return value size exceeds 8Bytes)
#### Example without returning value
  ```cpp
  class A
  {
  public:
    void test(int, float);
  };
  
  A a;
  a.test(1, 2.2);
  ```
  |Parameter|Location|
  |--|--|
  |1.|RCX = points to `this`|
  |2.|RDX|
  |3.|XMM2|
  
#### Example with return value exceeding 8Bytes
  ```cpp
  struct B { int64_t a, b; };
  
  class A
  {
  public:
    B test(int, float);
  };
  
  A a;
  B b = a.test(1, 2.2);
  ```
  |Parameter|Location|
  |--|--|
  |1.|RCX = points to `this` (`a`)|
  |1.|RDX = points to return location (`b`)|
  |2.|R8|
  |3.|XMM3|

## Saved registers
|Caller|Callee|
|--|--|
|RAX, RCX, RDX, R8, R9, R10, R11, XMM0-5|RBX, RBP, RDI, RSI, RSP, R12, R13, R14, R15, XMM6-15|