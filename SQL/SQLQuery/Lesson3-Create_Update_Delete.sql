--CREATE TABLE EM.DemoTable(
    --ColA INT,
    --ColB INT UNIQUE,
    --ColC VARCHAR(10) UNIQUE,
    --ColD VARCHAR(10) NOT NULL,
    --ColE VARCHAR(10),
    --ColF VARCHAR(10)
    --CONSTRAINT [PK_EM_DemoTable] PRIMARY KEY CLUSTERED (ColE,ColF)
--)

INSERT INTO EM.DemoTable(ColA,ColB,ColC,ColD,ColE,ColF)
VALUES (1, 2, 'test', 'test2', 'test3', 'test4')

INSERT INTO EM.DemoTable(ColA,ColB,ColC,ColD,ColE,ColF)
VALUES (2, 3, 'test2', 'test2', 'test3', 'test5')

EXEC sp_rename 'EM.DemoTable.ColA', 'ColAA', 'COLUMN'

SELECT * FROM EM.DemoTable;

INSERT INTO EM.DemoTable(ColC, ColD, ColE, ColF)
VALUES ('test4','test2','test3','test7')

UPDATE EM.DemoTable
SET ColAA=5, ColB=9, ColD='test4'
WHERE ColE='test3' AND ColF='test7'

SELECT * FROM EM.DemoTable
WHERE ColE='test3' AND ColF='test7'

DELETE FROM EM.DemoTable
WHERE ColE='test3' AND ColF='test7'

CREATE TABLE EM.Category(
    CategoryID INT IDENTITY PRIMARY KEY CLUSTERED,
    CategoryName NVARCHAR(20) NOT NULL UNIQUE,
    CategoryDescription NVARCHAR(1000)
)

CREATE TABLE EM.Product(
    ProductID INT IDENTITY PRIMARY KEY CLUSTERED,
    CategoryID INT REFERENCES EM.Category(CategoryID),
    ProductName NVARCHAR(50) NOT NULL UNIQUE,
    ProductDescription NVARCHAR(100)
)

INSERT INTO EM.Category(CategoryName, CategoryDescription)
VALUES('Hardware','Things you put inside a computer')

INSERT INTO EM.Category(CategoryName, CategoryDescription)
VALUES('Software','Things you install')

SELECT * FROM EM.Category

INSERT INTO EM.Product(CategoryID, ProductName, ProductDescription)
VALUES(1,'CPU','AMD Ryzen7 5800x')

INSERT INTO EM.Product(CategoryID, ProductName, ProductDescription)
VALUES(2,'Windows11','Operating System')

SELECT * FROM EM.Product

INSERT INTO EM.Product(CategoryID, ProductName, ProductDescription)
VALUES(
    (SELECT CategoryID FROM EM.Category WHERE CategoryName = 'Hardware'),
    'RAM',
    'Random Access Memory'
)
