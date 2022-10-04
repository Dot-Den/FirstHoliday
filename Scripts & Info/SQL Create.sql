USE FirstHoliday

--Creation of tables

CREATE TABLE Hotel
(
HotelID INT IDENTITY(1,1) NOT NULL,
HolHotel VARCHAR(255) NOT NULL,
StarRating INT NOT NULL,
PricePerNight DECIMAL(18,2) NOT NULL,
CityID INT NOT NULL,
PRIMARY KEY(HotelID),
CONSTRAINT chk_StarRating CHECK (StarRating IN (1, 2, 3, 4, 5))
);

CREATE TABLE Holiday
(
HolidayID INT IDENTITY(1,1) NOT NULL,
HolTypeID INT NOT NULL,
HotelID INT NOT NULL,
PRIMARY KEY (HolidayID),
);

CREATE TABLE HolCategory
(
HolTypeID INT IDENTITY(1,1) NOT NULL,
HolType VARCHAR(50) NOT NULL,
PRIMARY KEY (HolTypeID),
);

CREATE TABLE City
(
CityID INT IDENTITY(1,1) NOT NULL,
HolCity VARCHAR(250) NOT NULL,
CountryID INT NOT NULL,
TerrainID INT NOT NULL,
TemperatureID INT NOT NULL,
NightLifeID INT NOT NULL,
PRIMARY KEY (CityID),
);

CREATE TABLE LocType
(
TerrainID INT IDENTITY(1,1) NOT NULL,
TerrainType VARCHAR(100) NOT NULL,
PRIMARY KEY (TerrainID),
);

CREATE TABLE CityTemperature
(
TemperatureID INT IDENTITY(1,1) NOT NULL,
TemperatureRating VARCHAR(60) NOT NULL,
PRIMARY KEY (TemperatureID),
);

CREATE TABLE Country
(
CountryID INT IDENTITY(1,1) NOT NULL,
HolCountry VARCHAR(250) NOT NULL,
ContinentID INT NOT NULL,
PRIMARY KEY(CountryID),
);

CREATE TABLE Continent
(
ContinentID INT IDENTITY(1,1) NOT NULL,
HolContinent VARCHAR(250) NOT NULL,
PRIMARY KEY(ContinentID),
);

CREATE TABLE CityNightLife
(
NightLifeID INT IDENTITY(1,1) NOT NULL,
NightLifeType VARCHAR(60) NOT NULL,
PRIMARY KEY(NightLifeID),
);

-- Foreign keys added to tables

ALTER TABLE City
ADD FOREIGN KEY (CountryID) REFERENCES Country(CountryID);

ALTER TABLE City
ADD FOREIGN KEY (TerrainID) REFERENCES LocType(TerrainID);

ALTER TABLE City
ADD FOREIGN KEY (TemperatureID) REFERENCES CityTemperature(TemperatureID);

ALTER TABLE City
ADD FOREIGN KEY (NightLifeID) REFERENCES CityNightLife(NightLifeID);

ALTER TABLE Holiday
ADD FOREIGN KEY (HotelID) REFERENCES Hotel(HotelID);

ALTER TABLE Holiday
ADD FOREIGN KEY (HolTypeID) REFERENCES HolCategory(HolTypeID);

ALTER TABLE Country
ADD FOREIGN KEY (ContinentID) REFERENCES Continent(ContinentID);

ALTER TABLE Hotel
ADD FOREIGN KEY (CityID) REFERENCES City(CityID);

-- Data for tables

-- Continent

INSERT INTO Continent(HolContinent)
	VALUES('Asia');
	
INSERT INTO Continent(HolContinent)
	VALUES('Africa');
	
INSERT INTO Continent(HolContinent)
	VALUES('North America');
	
INSERT INTO Continent(HolContinent)
	VALUES('Europe');
	
INSERT INTO Continent(HolContinent)
	VALUES('Australia');
	
INSERT INTO Continent(HolContinent)
	VALUES('Antarctica');
	
INSERT INTO Continent(HolContinent)
	VALUES('Arctic');
	
-- CityTemperature

INSERT INTO CityTemperature(TemperatureRating)
	VALUES('Cold');
	
INSERT INTO CityTemperature(TemperatureRating)
	VALUES('Mild');
	
INSERT INTO CityTemperature(TemperatureRating)
	VALUES('Hot');
	
-- LocType

INSERT INTO LocType(TerrainType)
	VALUES('Sea');
	
INSERT INTO LocType(TerrainType)
	VALUES('City');
	
INSERT INTO LocType(TerrainType)
	VALUES('Mountain');

-- CityNightLife

INSERT INTO CityNightLife(NightLifeType)
	VALUES('Quiet');
	
INSERT INTO CityNightLife(NightLifeType)
	VALUES('Average');
	
INSERT INTO CityNightLife(NightLifeType)
	VALUES('Bustling');	
	
-- Country

INSERT INTO Country(HolCountry, ContinentID)
	VALUES('Indonesia', 1);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('USA', 3);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('Ireland', 4);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('Morocco', 2);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('Australia', 5);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('The Maldives', 2);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('France', 4);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('South Africa', 2);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('French Polynesia', 5);

INSERT INTO Country(HolCountry, ContinentID)
	VALUES('U.A.E', 1);

INSERT INTO Country(HolCountry, ContinentID)
	VALUES('Croatia', 4);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('Scotland', 4);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('Italy', 4);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('Bhutan', 1);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('India', 1);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('New Zealand', 5);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('Cuba', 3);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('Japan', 1);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('Antarctica', 6);
	
INSERT INTO Country(HolCountry, ContinentID)
	VALUES('Greenland', 7);
	
-- City

INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Bali', 1, 3, 2, 3);

INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('New Orleans', 2, 2, 2, 1);

INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Ventry', 3, 1, 2, 1);

INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Marrakech', 4, 3, 1, 2);

INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Sydney', 5, 1, 3, 2);

INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Feridhoo', 6, 1, 2, 1);

INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Paris', 7, 2, 2, 3);

INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Cape Town', 8, 1, 2, 3);

INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Dubai', 9, 3, 3, 3);

INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Bora Bora', 10, 1, 2, 2);
	
INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('New York', 2, 2, 2, 3);

INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Dubrovnik', 11, 1, 2, 1);
	
INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Edinburgh', 12, 2, 2, 2);
	
INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Rome', 13, 2, 2, 1);
	
INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Paro Valley', 14, 3, 2, 1);
	
INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Jaipur', 15, 1, 3, 2);
	
INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Waikato', 16, 3, 2, 1);
	
INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Havana', 17, 2, 2, 3);

INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Tokyo', 18, 2, 2, 2);
	
INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Base Marambio', 19, 3, 1, 1);
	
INSERT INTO City(HolCity, CountryID, TerrainID, TemperatureID, NightLifeID)
	VALUES('Graham Land', 20, 3, 1, 1);

-- Hotel

INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('Uptown', 3, 120, 1);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('Relaxamax', 4, 28, 2);

INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('WindyBeach', 3, 42, 3);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('Twighlight', 5, 50, 4);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('Too3', 5, 67, 5);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('Castaway', 3, 120, 6);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('Eiffel Park', 4, 45, 7);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('The Cape', 4, 78, 8);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('Desert Dreams', 4, 67, 9);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('1Views', 3, 54, 10);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('Apple2', 3, 27, 11);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('IslandHopper', 5, 78, 12);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('CastleTown', 3, 53, 13);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('WineValley', 5, 25, 14);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('WearyTraveller', 5, 54, 15);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('3Times', 4, 67, 16);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('ForestRetreat', 4, 89, 17);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('Casablanca', 5, 29, 18);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('Tech2', 3, 71, 19);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('Ice3el', 5, 270, 20);
	
INSERT INTO Hotel(HolHotel, StarRating, PricePerNight, CityID)
	VALUES('NorthStar', 5, 250, 21);

-- HolCategory

INSERT INTO HolCategory(HolType)
	VALUES('Active')
	
INSERT INTO HolCategory(HolType)
	VALUES('Lazy')

-- Holiday

INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(1, 1);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(2, 2);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(1, 3);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(2, 4);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(2, 5);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(2, 6);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(1, 7);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(1, 8);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(1, 9);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(1, 10);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(1, 11);

INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(1, 12);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(2, 13);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(2, 14);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(1, 15);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(2, 16);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(1, 17);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(2, 18);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(1, 19);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(1, 20);
	
INSERT INTO Holiday(HolTypeID, HotelID)
	VALUES(1, 21);