create table Address(
Id int primary key,
CityName nvarchar(50),
DistrictName nvarchar(200),
Foreign Key (Id) REFERENCES Houses(Id)
)